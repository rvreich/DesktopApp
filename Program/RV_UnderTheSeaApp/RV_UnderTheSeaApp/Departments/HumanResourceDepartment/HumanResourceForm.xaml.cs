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

namespace RV_UnderTheSeaApp.Departments.HumanResourceDepartment
{
    /// <summary>
    /// Interaction logic for HumanResourceForm.xaml
    /// </summary>
    public partial class HumanResourceForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public HumanResourceForm()
        {
            InitializeComponent();
            RefreshWorkerData();
            RefreshReportData();
            RefreshPermitData();
        }

        public void RefreshWorkerData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID, WORKERNAME, WORKERSALARY, WORKERPOSITION, PERFORMANCEINDEX FROM Workers WHERE ACTIVEWORKER = 1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            workerDataGrid.ItemsSource = dt.DefaultView;
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
            cmd.CommandText = "SELECT * FROM GeneralReports WHERE DEPARTMENT = 'HURD'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            reportDataGrid.ItemsSource = dt.DefaultView;
        }

        private void RefreshPermitData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM PermitReports";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            permitDataGrid.ItemsSource = dt.DefaultView;
        }

        private void InsertWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            String username = username_box.Text.ToString();
            String password = password_box.Text.ToString();
            String workername = workername_box.Text.ToString();
            String gender = genderComboBox.SelectionBoxItem.ToString();
            String salary = salary_box.Text.ToString();
            DateTime? dobDateTime = dobDatePicker.SelectedDate;
            String position = position_box.Text.ToString();
            String performance = performance_box.Text.ToString();

            if (username == "" || password == "" || workername == "" || gender == "" || salary == "" || !dobDateTime.HasValue || position == "" || performance == "")
            {
                MessageBox.Show("Please fill out the required section");
            }
            else
            {
                String dob = dobDateTime.Value.ToString();
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Workers (WORKERUSERNAME, WORKERPASSWORD, WORKERNAME, WORKERGENDER, WORKERSALARY, WORKERDOB, WORKERPOSITION, ACTIVEWORKER, PERFORMANCEINDEX) VALUES(@wuse, @wpas, @wnam, @wgen, @wsal, @wdob, @wpos, @awor, @pind)";
                cmd.Parameters.AddWithValue("@wuse", username);
                cmd.Parameters.AddWithValue("@wpas", password);
                cmd.Parameters.AddWithValue("@wnam", workername);
                cmd.Parameters.AddWithValue("@wgen", gender);
                cmd.Parameters.AddWithValue("@wsal", salary);
                cmd.Parameters.AddWithValue("@wdob", dob);
                cmd.Parameters.AddWithValue("@wpos", position);
                cmd.Parameters.AddWithValue("@awor", 1);
                cmd.Parameters.AddWithValue("@pind", 5);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Worker data has been added!!");
            }
            RefreshWorkerData();
            username_box.Text = "";
            password_box.Text = "";
            workername_box.Text = "";
            salary_box.Text = "";
            position_box.Text = "";
            performance_box.Text = "";
        }

        private void DeleteWorkerButton_Click(object sender, RoutedEventArgs e)
        {
            String id = worker_id_box.Text.ToString();
            if(id == "")
            {
                MessageBox.Show("Please fill out ID section");
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
                cmd.CommandText = "UPDATE Workers SET ACTIVEWORKER = 0 WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has been deleted!!");
            }
            RefreshWorkerData();
            worker_id_box.Text = "";
        }

        private void SendRequestButton_Click(object sender, RoutedEventArgs e)
        {
            String request = requestBox.Text.ToString();
            String dept = departmentComboBox.SelectionBoxItem.ToString();

            if(request == "" || dept == "")
            {
                MessageBox.Show("Please fill out the required section");
            }
            else
            {
                if (dept == "Manager")
                    dept = "MANA";
                else if (dept == "Accounting Finance")
                    dept = "ACFI";
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ConfirmationReports (REPORTDATE, DEPARTMENT, CONTENT, APPROVED, RECEIVER) VALUES(@reda, @dept, @cont, @appr, @rece)";
                cmd.Parameters.AddWithValue("@reda", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "HURD");
                cmd.Parameters.AddWithValue("@cont", request);
                cmd.Parameters.AddWithValue("@appr", 0);
                cmd.Parameters.AddWithValue("@rece", dept);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Request has been sent");
            }
            requestBox.Text = "";
        }

        private void RefreshReportButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshReportData();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
            this.Close();
        }

        private void UpdatePermitButton_Click(object sender, RoutedEventArgs e)
        {
            String permit_id = permit_id_box.Text.ToString();
            String approval = permitStatusComboBox.SelectionBoxItem.ToString();
            if(permit_id == "" || approval == "")
            {
                MessageBox.Show("Please fill out ID / Approval section");
            }
            else
            {
                SqlConnection con = db.getConnection();
                int conf = (approval == "Approved") ? 1 : 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE PermitReports SET APPROVED = " + conf + " WHERE ID = " + permit_id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Permit has been updated");
            }
            RefreshPermitData();
        }

        private void UpdateWorkerIndexButton_Click(object sender, RoutedEventArgs e)
        {
            String id = worker_id_box.Text.ToString();
            String performance = performance_box.Text.ToString();
            if (id == "" || performance == "")
            {
                MessageBox.Show("Please fill out ID / Performance Index section");
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
                cmd.CommandText = "UPDATE Workers SET PERFORMANCEINDEX = "+ performance + " WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Performance has been updated!!");
            }
            RefreshWorkerData();
            worker_id_box.Text = "";
            performance_box.Text = "";
        }

        private void UpdateWorkerSalaryButton_Click(object sender, RoutedEventArgs e)
        {
            String id = worker_id_box.Text.ToString();
            String salary = salary_box.Text.ToString();
            if (id == "" || salary == "")
            {
                MessageBox.Show("Please fill out ID / Salary section");
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
                cmd.CommandText = "UPDATE Workers SET WORKERSALARY = "+ salary +" WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Salary has been updated!!");
            }
            RefreshWorkerData();
            worker_id_box.Text = "";
            salary_box.Text = "";
        }

        private void RefreshPermitButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshPermitData();
        }
    }
}
