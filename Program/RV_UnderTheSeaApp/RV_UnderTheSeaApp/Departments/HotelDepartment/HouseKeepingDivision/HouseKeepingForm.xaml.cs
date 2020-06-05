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

namespace RV_UnderTheSeaApp.Departments.HotelDepartment.HouseKeepingDivision
{
    /// <summary>
    /// Interaction logic for HouseKeepingForm.xaml
    /// </summary>
    public partial class HouseKeepingForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public HouseKeepingForm()
        {
            InitializeComponent();
            RefreshReservationData();
        }

        private void RefreshReservationData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Reservations";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            reservationDataGrid.ItemsSource = dt.DefaultView;
        }

        private void SendReportButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            String content = "";
            content = report_box.Text.ToString();
            if (content != "")
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO GeneralReports (REPORTDATE, DEPARTMENT, CONTENT) VALUES(@reda, @dept, @cont)";
                cmd.Parameters.AddWithValue("@reda", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "HOKE");
                cmd.Parameters.AddWithValue("@cont", content);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Cleaning report sent!!");
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

        private void RefreshDataButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshReservationData();
        }
    }
}
