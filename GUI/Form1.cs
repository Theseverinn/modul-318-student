using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwissTransport;
using System.Net.Mail;

namespace GUI
{
    public partial class Form1 : Form
    {

        Transport transport = new Transport();
        Coordinate coordinate = new Coordinate();
        

        public Form1()
        {
            InitializeComponent();
        }

        #region Methoden

        private void GetStations(string text, ListBox listBox)
        {
            try
            {
                if (text.Length >= 3)
                {
                    listBox.Items.Clear();
                    Stations stations = transport.GetStations(text);
                    foreach (Station station in stations.StationList)
                    {
                        listBox.Items.Add(station.Name);
                        listBox.Visible = true;
                        listBox.BringToFront();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error", "Station wurde nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public string GetTableFromDataGrid()
        {
            StringBuilder strTable = new StringBuilder();
            try
            {
                strTable.Append("<table border='1' cellpadding='0' cellspacing='0'>");
                strTable.Append("<tr>");
                foreach (DataGridViewColumn col in dgvFahrplan.Columns)
                {
                    strTable.AppendFormat("<th>{0}</th>", col.HeaderText);
                }
                strTable.Append("</tr>");
                for (int i = 0; i < dgvFahrplan.Rows.Count; i++)
                {
                    strTable.Append("<tr>");
                    foreach (DataGridViewCell cell in dgvFahrplan.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            strTable.AppendFormat("<td>{0}</td>", cell.Value.ToString());
                        }
                    }
                    strTable.Append("</tr>");
                }
                strTable.Append("</table>");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return strTable.ToString();
        }

        private void GetGrid()
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dtt_connections = new DataTable();
            dtt_connections.Columns.Add("Datum");
            dtt_connections.Columns.Add("Von");
            dtt_connections.Columns.Add("Abfahrt");
            dtt_connections.Columns.Add("Nach");
            dtt_connections.Columns.Add("Ankunft");
            dtt_connections.Columns.Add("Gleis");

            //Abfrage
            Connections connections = transport.GetConnections(txtVon.Text, txtNach.Text, dtpDatum.Value.ToString("yyyy-MM-dd"), dtpTime.Text);

            //fügt jede station zu den listen hinzu
            foreach (Connection connection in connections.ConnectionList)
            {
                dtt_connections.Rows.Add(GetDate(connection.From.Departure), connection.From.Station.Name, GetTime(connection.From.Departure), connection.To.Station.Name, GetTime(connection.To.Arrival), connection.To.Platform);
            }

            dgvFahrplan.DataSource = dtt_connections;
            UseWaitCursor = false;
        }

        private void GetGrid2()
        {
            DataTable dtt_routes = new DataTable();
            dtt_routes.Columns.Add("Zeit");
            dtt_routes.Columns.Add("Nach");
            dtt_routes.Columns.Add("Linie");

            
            Station station = transport.GetStations(txtVon.Text).StationList.First();
            StationBoardRoot departures = transport.GetStationBoard(station.Name, station.Id); 

            foreach (StationBoard station_b in departures.Entries)
            {
                dtt_routes.Rows.Add(GetTime(station_b.Stop.Departure.ToString()), station_b.To, (station_b.Category + " " + station_b.Number)); 
            }

            dgvFahrplan.DataSource = dtt_routes;
        }

        private string GetDate(string date1)
        {
            string date2 = date1.Remove(10);
            DateTime date3 = Convert.ToDateTime(date2);
            return date3.ToString("dd.MM.yyyy");
        }

        private string GetTime(string time1) 
        {
            //z.B. zei 14:42:00 die sekunden anzahl "00" wird hier entfernt
            string time2 = time1.Remove(0, 11);
            time2 = time2.Remove(5);
            return time2;
        }

        #endregion

        #region Such und Abfahrts funktion

        private void txtVon_TextChanged(object sender, EventArgs e)
        {
            //ruft die Stations vorschlläge in der listbox von ab
            GetStations(txtVon.Text, lbxVon);
        }

        private void txtNach_TextChanged(object sender, EventArgs e)
        {
            //ruft die Stations vorschlläge in der listbox Nach ab
            GetStations(txtNach.Text, lbxNach);
        }

        private void lbxVon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Durch das kann man mit doppel klick auf eine Station in den vorschläge sie in die text box einfügen.
            txtVon.Text = lbxVon.SelectedItem.ToString();
            lbxVon.Visible = false;

            //fals der radiobutton für das suchen sichtbar ist wird der fokus auf die textbox nach gesetzt
            if(btnSuchen.Visible == true)
            {
                txtNach.Focus();
            }
            //fals nicht geht der fokus auf den knopf abfahrt.
            else
            {
                btnAbfahrt.Focus();
            }
        }

        private void lbxNach_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // macht es möglich dass man doppel klick auf einen vorschlag drücken kann und der dann eingefügt wird
            txtNach.Text = lbxNach.SelectedItem.ToString();

            //lässt die list box nach dem doppel klick verschwinden
            lbxNach.Visible = false;
        }

        private void btnSuchen_Click(object sender, EventArgs e)
        {
            // fals mann die map noch offen hat wird sie versteckt dass man den fahrplan sieht
            btnclose.Visible = false;
            wbGmaps.Visible = false;
            // Wenn man den knopf Abfahrt gedrückt hat und die felder Von und Nach leer lässt kommt die fehler meldung dass man eine station angeben muss.
            // Wenn man den knopf Abfahrt gedrückt hat und etwas eingegeben hatt wird die tabelle abgerufen
            if (txtVon.Text == string.Empty)
            {
                MessageBox.Show("Geben sie in die Textboxen von und nach eine Station ein", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GetGrid();
            }
        }

        private void btnAbfahrt_Click(object sender, EventArgs e)
        {
            // fals mann die map noch offen hat wird sie versteckt dass man den fahrplan sieht
            btnclose.Visible = false;
            wbGmaps.Visible = false;
            // Wenn man den knopf Abfahrt gedrückt hat und das feld Von leer lässt kommt die fehler meldung dass man eine station angeben muss.
            // Wenn man den knopf Abfahrt gedrückt hat und etwas eingegeben hatt wird die tabelle abgerufen
            if (btnAbfahrt.Text == string.Empty)
            {
                MessageBox.Show("Geben sie in die Textboxen von und nach eine Station ein", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                GetGrid2();
            }
        }

        private void txtVon_Click(object sender, EventArgs e)
        {
            // nach dem man in der list box einen ort doppel klickt verschwindet die lbx und so erscheint sie wieder wenn man auf die textbox drückt
            lbxVon.Visible = true;
        }

        private void txtNach_Click(object sender, EventArgs e)
        {
            // nach dem man in der list box einen ort doppel klickt verschwindet die lbx und so erscheint sie wieder wenn man auf die textbox drückt
            lbxNach.Visible = true;
        }

        private void txtVon_KeyDown(object sender, KeyEventArgs e)
        {
            // Mit der pfeil taste runter kann man in der listbox Von eine auswahl nach unten gehen wenn man in der textbox Von ist. 
            if (e.KeyCode == Keys.Down)
            {
                lbxVon.Focus();
                lbxVon.SelectedIndex = -1;
            }

            // Mit der pfeil taste hoch kann man in der listbox Von eine auswahl nach oben gehen wenn man in der textbox Von ist.
            if (e.KeyCode == Keys.Up)
            {
                lbxVon.Focus();
                lbxVon.SelectedIndex = +1;
            }
        }

        private void lbxVon_KeyDown(object sender, KeyEventArgs e)
        {
            // mit der taste enter kann man die auswahl von der listbox in die text box einfügen.
            if (e.KeyCode == Keys.Enter)
            {
                //  wenn der radiobutton suchen angekreuzt ist geht der fokus auf textbox nach
                if (btnSuchen.Visible == true)
                {
                    txtVon.Text = Convert.ToString(lbxVon.SelectedItem);
                    lbxVon.Visible = false;
                    txtNach.Focus();
                }
                // sonst geht der fokus auf den knop abfahrt
                else
                {

                    txtVon.Text = Convert.ToString(lbxVon.SelectedItem);
                    lbxVon.Visible = false;
                    btnAbfahrt.Focus();
                }
            }
        }

        private void txtNach_KeyDown(object sender, KeyEventArgs e)
        {
            // Mit der pfeil taste runter kann man in der listbox Nach eine auswahl nach unten gehen wenn man in der textbox Nach ist.
            if (e.KeyCode == Keys.Down)
            {
                lbxNach.Focus();
                lbxNach.SelectedIndex = -1;
            }
            // Mit der pfeil taste hoch kann man in der listbox Nach eine auswahl nach oben gehen wenn man in der textbox Nach ist.
            if (e.KeyCode == Keys.Up)
            {
                lbxNach.Focus();
                lbxNach.SelectedIndex = +1;
            }
        }

        private void lbxNach_KeyDown(object sender, KeyEventArgs e)
        {
            // mit der taste enter kann man die auswahl von der listbox in die text box einfügen und der fokus geht auf den knopf suchen.
            if (e.KeyCode == Keys.Enter)
            {
                txtNach.Text = Convert.ToString(lbxNach.SelectedItem);
                lbxNach.Visible = false;
                btnSuchen.Focus();

            }
        }

        #endregion

        #region Radio buttons

        private void rdoAbfahrt_CheckedChanged(object sender, EventArgs e)
        {
            //Wenn der radiobutton Suche gedrückt wurde verschwindet alles bis auf den knopf abfahrt der erscheint.
            if (rdoAbfahrt.Checked)
            {
                btnSuchen.Visible = false;
                txtNach.Visible = false;
                lbxNach.Visible = false;
                btnAbfahrt.Visible = true;
                lblNach.Visible = false;
                dtpDatum.Visible = false;
                
            }
        }

        private void rdoSuche_CheckedChanged(object sender, EventArgs e)
        {
            //Wenn der radiobutton Suche gedrückt wurde erscheint alles wider bis auf den knopf abfahrt der verschwindet.
            if (rdoSuche.Checked)
            {
                // 
                btnSuchen.Visible = true;
                txtNach.Visible = true;
                lbxNach.Visible = true;
                btnAbfahrt.Visible = false;
                lblNach.Visible = true;
                dtpDatum.Visible = true;
                dtpTime.Visible = true;
            }
        }

        #endregion

        #region Email

        private void btnEmailsenden_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
                MessageBox.Show("Gib in das feld Email deine Email ein", "Keine Email eingegeben", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("modul319.severinvonrotz@gmail.com");
                    mail.To.Add(new MailAddress(Convert.ToString(this.txtEmail)));
                    mail.Subject = "Fahrplan tabelle";
                    mail.Body = "Das ist die Email für den fahrplan den sie wollten. ";
                    mail.Body += "<b>" + GetTableFromDataGrid() + "</b>";
                    mail.IsBodyHtml = true;
                    SmtpClient SmtpServer = new SmtpClient();
                    SmtpServer.Host = "smtp.gmail.com";
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("modul319.severinvonrotz@gmail.com", "Kennwort$11");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    MessageBox.Show("Email wurde erfolgreich gesendet");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        #region Googlemaps

        private void txtStation_TextChanged(object sender, EventArgs e)
        {
            GetStations(txtStation.Text, lbxStation);
        }

        private void txtStation_Click(object sender, EventArgs e)
        {
            lbxStation.Visible = true;
        }

        private void lbxStation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtStation.Text = Convert.ToString(lbxStation.SelectedItem);
                lbxStation.Visible = false;
                btnGmaps.Focus();

            }
        }

        private void txtStation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                lbxStation.Focus();
                lbxStation.SelectedIndex = -1;
            }
            if (e.KeyCode == Keys.Up)
            {
                lbxStation.Focus();
                lbxStation.SelectedIndex = +1;
            }
        }

        private void lbxStation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtStation.Text = lbxStation.SelectedItem.ToString();
            lbxStation.Visible = false;
        }

        private void btnGmaps_Click(object sender, EventArgs e)
        {
            lbxStation.Visible = false;
            btnclose.Visible = true;
            wbGmaps.Visible = true;
            if (txtStation.Text != string.Empty)
            {
                Stations stations = transport.GetStations(txtStation.Text);
                Station station = stations.StationList[0];
                creategmapstation(Convert.ToString(station.Coordinate.XCoordinate).Replace(',', '.'), Convert.ToString(station.Coordinate.YCoordinate).Replace(',', '.'));
            }
            else
            {
                MessageBox.Show("Gib eine Station an", "Station nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void creategmapstation(string x, string y)
        {
            string url = "https://www.google.ch/maps/place/" + x + "," + y;
            wbGmaps.Navigate(url);
        }

        private void googleMapsStationsNearUrl()
        {
            string url = "https://www.google.com/maps/search/transit+stop+near/";
            wbGmaps.Navigate(url);
        }

        private void btnNear_Click(object sender, EventArgs e)
        {
            googleMapsStationsNearUrl();
            wbGmaps.Visible = true;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            btnclose.Visible = false;
            wbGmaps.Visible = false;
        }


        #endregion
    }
}
