﻿using System;
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

namespace RV_UnderTheSeaApp.Departments.RestaurantDepartment.KitchenDivision
{
    /// <summary>
    /// Interaction logic for KitchenRoomForm.xaml
    /// </summary>
    public partial class KitchenRoomForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public KitchenRoomForm()
        {
            InitializeComponent();
            RefreshOrderData();
            RefreshReportData();
        }

        private void RefreshOrderData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID, AMOUNT, ORDERSTATUS, CHAIRNUM FROM OrderScripts WHERE ISPAY = 0";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            orderDataGrid.ItemsSource = dt.DefaultView;
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
            cmd.CommandText = "SELECT ID, REPORTDATE, CONTENT FROM GeneralReports WHERE DEPARTMENT = 'KITC'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            reportDataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void RequestButton_Click(object sender, RoutedEventArgs e)
        {
            String content = request_box.Text.ToString();
            if(content == "")
            {
                MessageBox.Show("Please fill out the request report!!");
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
                cmd.CommandText = "INSERT INTO ConfirmationReports (REPORTDATE, DEPARTMENT, CONTENT, APPROVED, RECEIVER) VALUES (@reda, @dept, @cont, @appr, @rece)";
                cmd.Parameters.AddWithValue("@reda", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "KITC");
                cmd.Parameters.AddWithValue("@cont", content);
                cmd.Parameters.AddWithValue("@appr", 0);
                cmd.Parameters.AddWithValue("@rece", "PURC");
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Request has been sent!!");
            }
            request_box.Text = "";
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
            String status = orderStatusComboBox.SelectionBoxItem.ToString();
            if(id == "" || status == "")
            {
                MessageBox.Show("Please fill out ID/Status section!!");
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
                cmd.CommandText = "UPDATE OrderScripts SET ORDERSTATUS = '" + status + "' WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Order has been updated!!");
                RefreshOrderData();
            }
            id_box.Text = "";
        }
    }
}
