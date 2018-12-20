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

        
        private void Get_Stations(string text, ListBox listBox)
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

        public string Get_TableFromDataGrid()
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

        private void Get_Grid()
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

            //Jedes Resulatat zur Liste hinzufügen
            foreach (Connection connection in connections.ConnectionList)
            {
                dtt_connections.Rows.Add(Get_Date(connection.From.Departure), connection.From.Station.Name, Get_Time(connection.From.Departure), connection.To.Station.Name, Get_Time(connection.To.Arrival), connection.To.Platform);
            }

            dgvFahrplan.DataSource = dtt_connections;
            UseWaitCursor = false;
        }

        private void Get_2_Grid()
        {
            DataTable dtt_routes = new DataTable();
            dtt_routes.Columns.Add("Zeit");
            dtt_routes.Columns.Add("Nach");
            dtt_routes.Columns.Add("Linie");

            //Definieren der Station für die Abfahrtstafel (Inhalt der Textbox wird übergeben)
            Station station = transport.GetStations(txtVon.Text).StationList.First();
            StationBoardRoot departures = transport.GetStationBoard(station.Name, station.Id); //Beispiel für station.name ist Luzern, Beispiel für station.Id = 8505000

            foreach (StationBoard station_b in departures.Entries)
            {
                dtt_routes.Rows.Add(Get_Time(station_b.Stop.Departure.ToString()), station_b.To, (station_b.Category + " " + station_b.Number)); //Jede Linie die gefunden wird, wird hier durchgegangen
            }

            dgvFahrplan.DataSource = dtt_routes;
        }
        private string Get_Date(string date1)
        {
            string date2 = date1.Remove(10);
            DateTime date3 = Convert.ToDateTime(date2);
            return date3.ToString("dd.MM.yyyy");
        }

        private string Get_Time(string time1) //Zeit kommt so 13:25:00 und die letzen 2 Stellen :00 werden hier gelöscht.
        {
            string time2 = time1.Remove(0, 11);
            time2 = time2.Remove(5);
            return time2;
        }

        private void txtVon_TextChanged(object sender, EventArgs e)
        {
            Get_Stations(txtVon.Text, lbxVon);
        }

        private void txtNach_TextChanged(object sender, EventArgs e)
        {
            Get_Stations(txtNach.Text, lbxNach);


        }

        private void lbxVon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtVon.Text = lbxVon.SelectedItem.ToString();
            lbxVon.Visible = false;

            if(btnSuchen.Visible == true)
            {
                txtNach.Focus();
            }
            else
            {
                btnAbfahrt.Focus();
            }
        }

        private void lbxNach_SelectedIndexChanged(object sender, EventArgs e)
        {
            // macht es möglich dass man doppel klick auf einen vorschlag drücken kann und der dann eingefügt wird
            txtNach.Text = lbxNach.SelectedItem.ToString();
            
            //lässt die list box nach dem doppel klick verschwinden
            lbxNach.Visible = false;
        }

        private void btnSuchen_Click(object sender, EventArgs e)
        {
            // Wenn man den knopf Abfahrt gedrückt hat, die felder Von und Nach leer lässt kommt die fehler meldung dass man eine station angeben muss.
            // Wenn man den knopf Abfahrt gedrückt hat und etwas eingegeben hatt wird die tabelle abgerufen
            if (txtVon.Text == string.Empty)
            {
                MessageBox.Show("Geben sie in die Textboxen von und nach eine Station ein", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Get_Grid();
            }
        }

        private void btnAbfahrt_Click(object sender, EventArgs e)
        {
            // Wenn man den knopf Abfahrt gedrückt hat und das feld Von leer lässt kommt die fehler meldung dass man eine station angeben muss.
            // Wenn man den knopf Abfahrt gedrückt hat und etwas eingegeben hatt wird die tabelle abgerufen
            if (btnAbfahrt.Text == string.Empty)
            {
                MessageBox.Show("Geben sie in die Textboxen von und nach eine Station ein", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Get_2_Grid();
            }
        }

        private void rdoAbfahrt_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAbfahrt.Checked)
            {
                btnSuchen.Visible = false;
                txtNach.Visible = false;
                lbxNach.Visible = false;
                btnAbfahrt.Visible = true;
                lblNach.Visible = false;
                dtpDatum.Visible = false;
                dtpTime.Visible = false;
            }
        }

        private void rdoSuche_CheckedChanged(object sender, EventArgs e)
        {
            //Wenn der radiobutton Suche gedrückt wurde erscheint alles wider bis auf den knopf abfahrt der verschwindet
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

        private void creategmapstation(string x, string y)
        {
            string url = "https://www.google.ch/maps/place/" + x + "," + y;
            wbGmaps.Navigate(url);
        }

        private void btnGmaps_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Gib eine Station an","Station nicht gefunden", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            btnclose.Visible = false;
            wbGmaps.Visible = false;
        }

        private void txtVon_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Down)
            {
                lbxVon.Focus();
                lbxVon.SelectedIndex = -1;
            }
            if(e.KeyCode == Keys.Up)
            {
                lbxVon.Focus();
                lbxVon.SelectedIndex = +1;
            }
        }

        private void lbxVon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btnSuchen.Visible == true)
                {
                    txtVon.Text = Convert.ToString(lbxVon.SelectedItem);
                    lbxVon.Visible = false;
                    txtNach.Focus();
                }
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
            /*if (e.KeyCode == Keys.Down)
            {
                lbxNach.Focus();                            Ich habe hier versuch zu machen dass ich mit den pfeil tasten in der listbox rumsuchen kann
                lbxNach.SelectedIndex = -1;                 aber aus irgendeinem grund drückt es enter ich habe den fehler nicht gefunden
            }
            if (e.KeyCode == Keys.Up)                           
            {
                lbxNach.Focus();
                lbxNach.SelectedIndex = +1;
            }*/
        }

        private void lbxNach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNach.Text = Convert.ToString(lbxNach.SelectedItem);
                lbxNach.Visible = false;
                btnSuchen.Focus();

            }
        }

        private void btnEmailsenden_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
                MessageBox.Show("Bitte geben Sie eine Email-Adresse ein!");
            else
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("modul319.severinvonrotz@gmail.com");
                    mail.To.Add(new MailAddress(Convert.ToString(this.txtEmail)));
                    mail.Subject = "Fahrplan tabelle";
                    mail.Body = "Das ist die Email für den fahrplan den sie wollten. ";
                    mail.Body += "<b>" + Get_TableFromDataGrid() + "</b>";
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
    }
}
