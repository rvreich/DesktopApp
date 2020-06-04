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

namespace RV_UnderTheSeaApp.Departments.RestaurantDepartment.DiningRoomDivision
{
    /// <summary>
    /// Interaction logic for DiningRoomForm.xaml
    /// </summary>
    public partial class DiningRoomForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public DiningRoomForm()
        {
            InitializeComponent();
            RefreshOrderData();
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

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            String id = validation_box.Text.ToString().Trim();
            if(id != "")
            {
                int diff = -1;
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Tickets WHERE ID = " + id;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String dateCreated = reader[1].ToString();
                        System.TimeSpan daysDiff = System.DateTime.Now - Convert.ToDateTime(dateCreated);
                        diff = (int)daysDiff.TotalDays;

                    }
                    if (diff == 0)
                    {
                        MessageBox.Show("Ticket Valid");
                    }
                    else
                    {
                        MessageBox.Show("Ticket Expired, please buy another ticket");
                    }
                }
                else
                {
                    MessageBox.Show("Ticket Invalid, please buy another ticket");
                }
                validation_box.Text = "";
                con.Close();
            }
            else
            {
                MessageBox.Show("Please fill out the needed form");
            }
            validation_box.Text = "";
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
            this.Close();
        }

        private void CheckTableButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) From OrderScripts WHERE ISPAY = 0";
            SqlDataReader reader = cmd.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = int.Parse(reader[0].ToString().Trim());
            }
            reader.Close();
            if(count > 6)
            {
                MessageBox.Show("Table is full!!");
            }
            else
            {
                MessageBox.Show("There exists empty table");
            }
            con.Close();
        }

        private void AuditButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = db.getConnection();
            int amount = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            String[] date = System.DateTime.Now.ToString().Split(new char[] { '/', ' ' }, StringSplitOptions.None);
            cmd.CommandText = "SELECT SUM(AMOUNT * 45000) FROM OrderScripts WHERE YEAR(DATE_CREATED) = " + date[2] + " AND MONTH(DATE_CREATED) = " + date[0] + " AND ISPAY = 1";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                amount = int.Parse(reader[0].ToString());
            }
            reader.Close();
            cmd.CommandText = "SELECT ID FROM Audits WHERE YEAR(AUDITDATE) = " + date[2] + " AND MONTH(AUDITDATE) = " + date[0] + " AND DEPARTMENT = 'DIRO'";
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cmd.CommandText = "UPDATE Audits SET AMOUNT = " + (amount).ToString() + " WHERE ID = " + reader[0];
                }
                reader.Close();
                cmd.ExecuteNonQuery();
            }
            else
            {
                reader.Close();
                cmd.CommandText = "INSERT INTO Audits(AUDITDATE, DEPARTMENT,AMOUNT) VALUES(@date, @dept, @amount)";
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "DIRO");
                cmd.Parameters.AddWithValue("@amount", (amount));
                cmd.ExecuteNonQuery();
            }
            con.Close();
            MessageBox.Show("Audit for month " + date[0] + ", year " + date[2] + " has been sent!");
        }

        private void InsertOrderButton_Click(object sender, RoutedEventArgs e)
        {
            String amount = amount_box.Text.ToString().Trim();
            String num = chairnum_box.Text.ToString().Trim();
            if(amount == "" || num == "")
            {
                MessageBox.Show("Please fill out amount and table number!!");
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
                cmd.CommandText = "INSERT INTO OrderScripts (DATE_CREATED, AMOUNT, ORDERSTATUS, ISPAY, CHAIRNUM) VALUES(@date, @amou, @orst, @ispa, @chnu)";
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@amou", amount);
                cmd.Parameters.AddWithValue("@orst", "CREATED");
                cmd.Parameters.AddWithValue("@ispa", 0);
                cmd.Parameters.AddWithValue("@chnu", num);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Order has been created!!");
            }
            RefreshOrderData();
            amount_box.Text = "";
            chairnum_box.Text = "";
            id_box.Text = "";
        }

        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            String id = id_box.Text.ToString();
            String status = orderStatusComboBox.SelectionBoxItem.ToString();
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
                cmd.CommandText = "UPDATE OrderScripts SET ORDERSTATUS = '" + status + "' WHERE ID = " + id + " AND ISPAY = 0";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Order has been updated!!");
            }
            RefreshOrderData();
            amount_box.Text = "";
            chairnum_box.Text = "";
            id_box.Text = "";
        }

        private void ShowFeeButton_Click(object sender, RoutedEventArgs e)
        {
            String num = chairnum_box.Text.ToString();
            if(num == "")
            {
                MessageBox.Show("Please fill out table number");
            }
            else
            {
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                int amount = 0;
                int id = 0;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT ID, AMOUNT FROM OrderScripts WHERE CHAIRNUM = " + num + " AND ISPAY = 0";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = int.Parse(reader[0].ToString().Trim());
                        amount = int.Parse(reader[1].ToString().Trim());
                    }
                }
                reader.Close();
                cmd.CommandText = "UPDATE OrderScripts SET ISPAY = 1 WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
                TotalFeeForm totalFeeForm = new TotalFeeForm(num, amount);
                totalFeeForm.Show();
            }
            RefreshOrderData();
            amount_box.Text = "";
            chairnum_box.Text = "";
            id_box.Text = "";
        }
    }
}
