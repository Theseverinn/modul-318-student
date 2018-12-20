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
            btnSuchen.Focus();
            lbxVon.Visible = false;
        }

        private void lbxNach_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNach.Text = lbxNach.SelectedItem.ToString();
            btnSuchen.Focus();
            lbxNach.Visible = false;
        }

        private void btnSuchen_Click(object sender, EventArgs e)
        {
            if(txtVon.Text == string.Empty)
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
            if (btnAbfahrt.Text != string.Empty)
            {
                Get_2_Grid();
            }
            else
            {
                MessageBox.Show("Bitte geben Sie einen Ort ein!");
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
            if (rdoSuche.Checked)
            {
                btnSuchen.Visible = true;
                txtNach.Visible = true;
                lbxNach.Visible = true;
                btnAbfahrt.Visible = false;
                lblNach.Visible = true;
                dtpDatum.Visible = true;
                dtpTime.Visible = true;
            }
        }
    }
}
