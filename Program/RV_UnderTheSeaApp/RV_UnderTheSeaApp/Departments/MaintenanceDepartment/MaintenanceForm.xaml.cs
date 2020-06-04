using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RV_UnderTheSeaApp.Departments.MaintenanceDepartment
{
    /// <summary>
    /// Interaction logic for MaintenanceForm.xaml
    /// </summary>
    public partial class MaintenanceForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public MaintenanceForm()
        {
            InitializeComponent();
            RefreshAttractionData();
        }

        public void RefreshAttractionData()
        {
            SqlConnection con = db.getConnection();
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID,ATTRACTIONNAME,LASTMAINTENANCE,UPMAINTENANCE,ATTRACTIONSTATUS FROM Attractions WHERE ISACTIVE = 1 AND CONSTRUCTIONSTATUS = 'ESTABLISH'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void UpdateAttractionButton_Click(object sender, RoutedEventArgs e)
        {
            String upcomingDate = "";
            String id = id_box.Text.ToString().Trim();
            String maintenanceStatus = comboBox.SelectionBoxItem.ToString();
            DateTime? upcomingMaintenance = datePicker.SelectedDate;
            if (upcomingMaintenance.HasValue)
            {
                upcomingDate = upcomingMaintenance.Value.ToString();
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Attractions SET LASTMAINTENANCE = '" + System.DateTime.Now + "', UPMAINTENANCE = '" + upcomingDate + "', ATTRACTIONSTATUS = '" + maintenanceStatus + "' WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                RefreshAttractionData();
                con.Close();
                MessageBox.Show("Attraction maintenance date updated!!");
                id_box.Text = "";
            }
            else
            {
                if(id == "")
                {
                    MessageBox.Show("Please insert attraction id");
                }
                else
                {
                    MessageBox.Show("Please pick upcoming maintenance date");
                }
            }
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            String content = "";
            content = report_box.Text.ToString();
            if(content != "")
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO GeneralReports (REPORTDATE, DEPARTMENT, CONTENT) VALUES(@reda, @dept, @cont)";
                cmd.Parameters.AddWithValue("@reda", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "MAIN");
                cmd.Parameters.AddWithValue("@cont", content);
                cmd.ExecuteNonQuery();
                RefreshAttractionData();
                con.Close();
                MessageBox.Show("Maintenance report sent!!");
                report_box.Text = "";
            }
            else
            {
                MessageBox.Show("Fill out your report please");
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
            this.Close();
        }
    }
}
