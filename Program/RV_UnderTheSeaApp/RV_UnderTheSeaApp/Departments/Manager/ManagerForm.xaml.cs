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

namespace RV_UnderTheSeaApp.Departments.Manager
{
    /// <summary>
    /// Interaction logic for ManagerForm.xaml
    /// </summary>
    public partial class ManagerForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public ManagerForm()
        {
            InitializeComponent();
            RefreshWorkerData();
            RefreshReportData();
        }

        private void RefreshWorkerData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID, WORKERNAME, PERFORMANCEINDEX FROM Workers WHERE ACTIVEWORKER = 1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            workerDataGrid.ItemsSource = dt.DefaultView;
            con.Close();
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
            cmd.CommandText = "SELECT * FROM ConfirmationReports WHERE RECEIVER = 'MANA'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            reportDataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void RefreshWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshWorkerData();
        }

        private void UpdateDataButton_Click(object sender, RoutedEventArgs e)
        {
            String id = id_box.Text.ToString();
            String approval = approvalComboBox.SelectionBoxItem.ToString();
            if(id == "" || approval == "")
            {
                MessageBox.Show("Please fill out the required section");
            }
            else
            {
                int appr = (approval == "Approved") ? 1 : 0;
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE ConfirmationReports SET APPROVED = "+ appr +" WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
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
