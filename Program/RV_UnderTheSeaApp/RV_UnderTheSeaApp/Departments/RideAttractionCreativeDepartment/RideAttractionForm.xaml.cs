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

namespace RV_UnderTheSeaApp.Departments.RideAttractionCreativeDepartment
{
    /// <summary>
    /// Interaction logic for RideAttractionForm.xaml
    /// </summary>
    public partial class RideAttractionForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public RideAttractionForm()
        {
            InitializeComponent();
            RefreshAttractionList();
            RefreshReportList();
        }

        private void RefreshAttractionList()
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

        private void RefreshReportList()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID, CONTENT, APPROVED FROM ConfirmationReports WHERE DEPARTMENT = 'RIAC'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            reportDataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            String receiver = comboBox.SelectionBoxItem.ToString();
            if(receiver == "Manager")
            {
                receiver = "MANA";
            }
            else
            {
                receiver = "PURC";
            }
            String content = reportBox.Text.ToString();
            if(content != "")
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ConfirmationReports (REPORTDATE, DEPARTMENT, CONTENT, APPROVED, RECEIVER) VALUES (@reda, @dept, @cont, @appr, @rece)";
                cmd.Parameters.AddWithValue("@reda", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "RIAC");
                cmd.Parameters.AddWithValue("@cont", content);
                cmd.Parameters.AddWithValue("@appr", 0);
                cmd.Parameters.AddWithValue("@rece", receiver);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Report has been sent!!");
            }
            else
            {
                MessageBox.Show("Please fill out the report");
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
            this.Close();
        }

        private void UpdateAttractionButton_Click(object sender, RoutedEventArgs e)
        {
            String id = id_box.Text.ToString();
            String cap = capacity_box.Text.ToString();
            if(id == "" || cap == "")
            {
                MessageBox.Show("Please fill ID / Capacity section");
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
                cmd.CommandText = "UPDATE Attractions SET CAPACITY = " + cap + " WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Attraction data updated!!");
            }
            id_box.Text = "";
            capacity_box.Text = "";
            RefreshAttractionList();
        }

        private void UpdateStatusButton_Click(object sender, RoutedEventArgs e)
        {
            String id = aid_box.Text.ToString();
            String status = constructionComboBox.SelectionBoxItem.ToString();
            if(id == "")
            {
                MessageBox.Show("Please fill out the id section");
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
                if(status == "DESTROYED")
                {
                    cmd.CommandText = "UPDATE Attractions SET ISACTIVE = 0 WHERE ID = " + id;
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "UPDATE Attractions SET CONSTRUCTIONSTATUS = '" + status + "' WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Construction status updated!!");
            }
            aid_box.Text = "";
            RefreshAttractionList();
        }
    }
}
