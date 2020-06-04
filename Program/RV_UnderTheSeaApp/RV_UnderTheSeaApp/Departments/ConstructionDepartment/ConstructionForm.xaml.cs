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

namespace RV_UnderTheSeaApp.Departments.ConstructionDepartment
{
    /// <summary>
    /// Interaction logic for ConstructionForm.xaml
    /// </summary>
    public partial class ConstructionForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public ConstructionForm()
        {
            InitializeComponent();
            RefreshReportData();
            RefreshAttractionData();
            RefreshConfirmationData();
        }

        private void RefreshReportData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID,CONTENT FROM ConfirmationReports WHERE DEPARTMENT = 'RIAC' AND APPROVED = 1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            reportDataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void RefreshAttractionData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID, ATTRACTIONNAME, CAPACITY, CONSTRUCTIONSTATUS FROM Attractions WHERE ISACTIVE = 1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            attractionDataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void RefreshConfirmationData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID, REPORTDATE, CONTENT FROM GeneralReports WHERE DEPARTMENT = 'CONS'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            confirmationDataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
            this.Close();
        }

        private void RequestButton_Click(object sender, RoutedEventArgs e)
        {
            String content = request_box.Text.ToString();
            if(content != "")
            {
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ConfirmationReports (DATE, DEPARTMENT, CONTENT, APPROVED, RECEIVER) VALUES(@date, @dept, @cont, @appr, @rece)";
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "CONS");
                cmd.Parameters.AddWithValue("@cont", content);
                cmd.Parameters.AddWithValue("@appr", 0);
                cmd.Parameters.AddWithValue("@rece", "PURC");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Request has been sent!!");
                con.Close();
            }
            else
            {
                MessageBox.Show("Please fill out the report");
            }
            request_box.Text = "";
        }

        private void InsertAttractionButton_Click(object sender, RoutedEventArgs e)
        {
            String name = attraction_name_box.Text.ToString();
            String capacity = capacity_box.Text.ToString();
            if(name != "" && capacity != "")
            {
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                DateTime today = DateTime.Today;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Attractions (ATTRACTIONNAME, CAPACITY, LASTMAINTENANCE, UPMAINTENANCE,ATTRACTIONSTATUS, CONSTRUCTIONSTATUS, ISACTIVE) VALUES (@atna, @capa, @lama, @upma, @atts, @cost, @isac)";
                cmd.Parameters.AddWithValue("@atna", name);
                cmd.Parameters.AddWithValue("@capa", capacity);
                cmd.Parameters.AddWithValue("@lama",System.DateTime.Now);
                cmd.Parameters.AddWithValue("@upma", today.AddDays(14.0f));
                cmd.Parameters.AddWithValue("@atts","MAINTAINED");
                cmd.Parameters.AddWithValue("@cost","CONSTRUCT");
                cmd.Parameters.AddWithValue("@isac",1);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Construction added!!");
            }
            else
            {
                MessageBox.Show("Please fill Name / Capacity section");
            }
            attraction_name_box.Text = "";
            capacity_box.Text = "";
            RefreshAttractionData();
        }

        private void UpdateStatusButton_Click(object sender, RoutedEventArgs e)
        {
            String id = id_box.Text.ToString();
            String status = comboBox.SelectionBoxItem.ToString();
            if(id == "" || status == "")
            {
                MessageBox.Show("Please fill out ID / Status section");
            }
            else
            {
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Attractions SET CONSTRUCTIONSTATUS = '" + status +"' WHERE ID =" + id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Construction status updated!!");
            }
            id_box.Text = "";
            RefreshAttractionData();
        }
    }
}
