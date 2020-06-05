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

namespace RV_UnderTheSeaApp.Departments.SalesMarketingDepartment
{
    /// <summary>
    /// Interaction logic for SalesMarketingForm.xaml
    /// </summary>
    public partial class SalesMarketingForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public SalesMarketingForm()
        {
            InitializeComponent();
            RefreshAdsData();
            RefreshReportData();
        }

        private void RefreshAdsData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Ads WHERE ISACTIVE = 1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            adsDataGrid.ItemsSource = dt.DefaultView;
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
            cmd.CommandText = "SELECT * FROM GeneralReports WHERE DEPARTMENT = 'SAMA'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            reportDataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
            this.Close();
        }

        private void SendRequestButton_Click(object sender, RoutedEventArgs e)
        {
            String content = report_box.Text.ToString();
            String dept = departmentComboBox.SelectionBoxItem.ToString();
            if(content == "" || dept == "")
            {
                MessageBox.Show("Please fill out the required section");
            }
            else
            {
                if (dept == "Purchase")
                    dept = "PURC";
                else if (dept == "Accounting Finance")
                    dept = "ACFI";
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ConfirmationReports (REPORTDATE, DEPARTMENT, CONTENT, APPROVED, RECEIVER) VALUES (@reda, @dept, @cont, @appr, @rece)";
                cmd.Parameters.AddWithValue("@reda", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "SAMA");
                cmd.Parameters.AddWithValue("@cont", content);
                cmd.Parameters.AddWithValue("@appr", 0);
                cmd.Parameters.AddWithValue("@rece", dept);
                cmd.ExecuteNonQuery();
                MessageBox.Show("request has been sent!!");
                con.Close();
            }
            report_box.Text = "";
        }

        private void InsertAdsButton_Click(object sender, RoutedEventArgs e)
        {
            String ads_content = ads_box.Text.ToString();
            if(ads_content == "")
            {
                MessageBox.Show("Please fill out the ads");
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
                cmd.CommandText = "INSERT INTO Ads (DATE_CREATED, CONTENT, ISACTIVE) VALUES (@date, @cont, @isac)";
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@cont", ads_content);
                cmd.Parameters.AddWithValue("@isac", 1);
                cmd.ExecuteNonQuery();
                MessageBox.Show("ads has been saved!!");
                con.Close();
            }
            RefreshAdsData();
            ads_box.Text = "";
        }

        private void UpdateAdsButton_Click(object sender, RoutedEventArgs e)
        {
            String id = id_box.Text.ToString();
            String ads_content = ads_box.Text.ToString();
            if (id == "" || ads_content == "")
            {
                MessageBox.Show("Please fill out the ID / Ads content section");
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
                cmd.CommandText = "UPDATE Ads SET CONTENT = '" + ads_content + "' WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("ads content has been updated!!");
                con.Close();
            }
            RefreshAdsData();
            ads_box.Text = "";
        }

        private void DeleteAdsButton_Click(object sender, RoutedEventArgs e)
        {
            String id = id_box.Text.ToString();
            if (id == "")
            {
                MessageBox.Show("Please fill out the ID section");
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
                cmd.CommandText = "UPDATE Ads SET ISACTIVE = 0 WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                MessageBox.Show("ads has been deleted!!");
                con.Close();
            }
            RefreshAdsData();
            ads_box.Text = "";
        }

        private void RefreshReportButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshReportData();
        }
    }
}
