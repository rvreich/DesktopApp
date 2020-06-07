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

namespace RV_UnderTheSeaApp.Departments.PurchasingDepartment
{
    /// <summary>
    /// Interaction logic for PurchasingForm.xaml
    /// </summary>
    public partial class PurchasingForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public PurchasingForm()
        {
            InitializeComponent();
            RefreshRequestData();
        }

        private void RefreshRequestData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM ConfirmationReports WHERE RECEIVER = 'PURC'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            requestDataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            String content = report_box.Text.ToString();
            if(content == "")
            {
                MessageBox.Show("Please fill out the report!!");
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
                cmd.CommandText = "INSERT INTO GeneralReports (REPORTDATE, DEPARTMENT, CONTENT) VALUES(@reda, @dept, @cont)";
                cmd.Parameters.AddWithValue("@reda", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "PURC");
                cmd.Parameters.AddWithValue("@cont", content);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Purchasing report sent!!");
            }
            report_box.Text = "";
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
            this.Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            String id = id_box.Text.ToString();
            String confirmation = confirmationComboBox.SelectionBoxItem.ToString();
            int conf = -1;
            if (id == "" || confirmation == "")
            {
                MessageBox.Show("Please fill out ID / Confirmation section");
            }
            else
            {
                conf = (confirmation == "Approved") ? 1 : 0;
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE ConfirmationReports SET APPROVED = " + conf + " WHERE ID = " + id;
                con.Close();
                MessageBox.Show("Done");
            }
            id_box.Text = "";
            RefreshRequestData();
        }
    }
}
