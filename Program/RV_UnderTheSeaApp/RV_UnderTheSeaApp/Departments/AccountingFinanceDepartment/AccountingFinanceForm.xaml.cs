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

namespace RV_UnderTheSeaApp.Departments.AccountingFinanceDepartment
{
    /// <summary>
    /// Interaction logic for AccountingFinanceForm.xaml
    /// </summary>
    public partial class AccountingFinanceForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public AccountingFinanceForm()
        {
            InitializeComponent();
            RefreshConfirmationData();
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
            cmd.CommandText = "SELECT ID, REPORTDATE, DEPARTMENT, CONTENT, APPROVED FROM ConfirmationReports WHERE RECEIVER = 'PURC' OR RECEIVER = 'ACFI'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            confirmationDataGrid.ItemsSource = dt.DefaultView;
        }

        private void SendResponseButton_Click(object sender, RoutedEventArgs e)
        {
            String response = response_box.Text.ToString();
            String department = departmentComboBox.SelectionBoxItem.ToString();
            if(response == "" || department == "")
            {
                MessageBox.Show("Please fill out the report / pick the department section");
            }
            else
            {
                if (department == "Attraction") department = "ATTR";
                else if (department == "Maintenance") department = "MAIN";
                else if (department == "Ride Attraction") department = "RIAC";
                else if (department == "Construction") department = "CONS";
                else if (department == "Dining Room") department = "DIRO";
                else if (department == "Kitchen") department = "KITC";
                else if (department == "Purchasing") department = "PURC";
                else if (department == "Front Office") department = "FROF";
                else if (department == "House Keeping") department = "HOKE";
                else if (department == "Sales Marketing") department = "SAMA";
                else if (department == "Human Resource") department = "HURD";
                else if (department == "Manager") department = "MANA";

                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO GeneralReports(REPORTDATE,DEPARTMENT,CONTENT) VALUES(@reda,@dept,@cont)";
                cmd.Parameters.AddWithValue("@reda", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", department);
                cmd.Parameters.AddWithValue("@cont", response);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("response has been sent!!");
            }
            response_box.Text = "";
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshConfirmationData();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            String id = id_box.Text.ToString().Trim();
            String conf = confirmationComboBox.SelectionBoxItem.ToString();
            if(id == "" || conf == "")
            {
                MessageBox.Show("Please fill out ID / Confirmation section");
            }
            else
            {
                int appr = (conf == "Approved") ? 1 : 0;
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE ConfirmationReports SET APPROVED = " + appr + " WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("request has been updated!!");
            }
            RefreshConfirmationData();
            id_box.Text = "";
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
            this.Close();
        }
    }
}
