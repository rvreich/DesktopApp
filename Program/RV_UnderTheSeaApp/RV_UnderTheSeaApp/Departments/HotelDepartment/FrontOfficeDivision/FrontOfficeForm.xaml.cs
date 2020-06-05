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

namespace RV_UnderTheSeaApp.Departments.HotelDepartment.FrontOfficeDivision
{
    /// <summary>
    /// Interaction logic for FrontOfficeForm.xaml
    /// </summary>
    public partial class FrontOfficeForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public FrontOfficeForm()
        {
            InitializeComponent();
            RefreshVisitorData();
            RefreshReservationData();
        }

        private void RefreshVisitorData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Visitors";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            visitorDataGrid.ItemsSource = dt.DefaultView;
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

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
            this.Close();
        }

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            String name = name_box.Text.ToString();
            String email = email_box.Text.ToString();

            if(name == "" || email == "")
            {
                MessageBox.Show("Please fill out Name / Email section");
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
                cmd.CommandText = "SELECT * FROM Visitors WHERE VISITORNAME = '" + name + "' AND EMAIL = '" + email + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Visitor data exists");
                }
                else
                {
                    MessageBox.Show("Visitor data not exists");
                }
            }
            RefreshVisitorData();
            name_box.Text = "";
            email_box.Text = "";
        }

        private void InsertVisitorButton_Click(object sender, RoutedEventArgs e)
        {
            String name = name_box.Text.ToString();
            String email = email_box.Text.ToString();

            if (name == "" || email == "")
            {
                MessageBox.Show("Please fill out Name / Email section");
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
                cmd.CommandText = "INSERT INTO Visitors (VISITORNAME, EMAIL) VALUES(@name,@email)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Visitor data has been added!!");
            }
            RefreshVisitorData();
            name_box.Text = "";
            email_box.Text = "";
        }

        private void UpdateVisitor_Click(object sender, RoutedEventArgs e)
        {
            String id = id_box.Text.ToString();
            String name = name_box.Text.ToString();
            String email = email_box.Text.ToString();

            if (id == "" || name == "" || email == "")
            {
                MessageBox.Show("Please fill out ID / Name / Email section");
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
                cmd.CommandText = "UPDATE Visitors SET VISITORNAME = '"+ name +"', EMAIL = '"+ email +"' WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Visitor data has been updated");
            }
            RefreshVisitorData();
            name_box.Text = "";
            email_box.Text = "";
        }

        private void ReserveButton_Click(object sender, RoutedEventArgs e)
        {
            String vid = visitor_id_box.Text.ToString();
            String room = roomnum_box.Text.ToString();
            DateTime? checkinDate = checkInDatePicker.SelectedDate;
            DateTime? checkoutDate = checkOutDatePicker.SelectedDate;

            if(vid != "" && room != "" && checkinDate.HasValue && checkoutDate.HasValue)
            {
                String checkin = checkinDate.Value.ToString();
                String checkout = checkoutDate.Value.ToString();
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Reservations (DATE_CREATED, VID, ROOMNUM, CHECKIN, CHECKOUT,DAMAGEFEE) VALUES (@date, @vid, @room, @cin, @cout, @dafe)";
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@vid", vid);
                cmd.Parameters.AddWithValue("@room", room);
                cmd.Parameters.AddWithValue("@cin", checkin);
                cmd.Parameters.AddWithValue("@cout", checkout);
                cmd.Parameters.AddWithValue("@dafe", 0);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Reservation added!!");
            }
            else
            {
                MessageBox.Show("Please fill out the required section");
            }
            RefreshReservationData();
            visitor_id_box.Text = "";
            roomnum_box.Text = "";
        }

        private void UpdateReservationButton_Click(object sender, RoutedEventArgs e)
        {
            String id = resid_box.Text.ToString();
            DateTime? checkinDate = checkInDatePicker.SelectedDate;
            DateTime? checkoutDate = checkOutDatePicker.SelectedDate;

            if (id != "" && checkinDate.HasValue && checkoutDate.HasValue)
            {
                String checkin = checkinDate.Value.ToString();
                String checkout = checkoutDate.Value.ToString();
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Reservations SET CHECKIN ='" + checkin + "', CHECKOUT = '" + checkout + "' WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Reservation updated!!");
            }
            else
            {
                MessageBox.Show("Please fill out the required section");
            }
            RefreshReservationData();
            resid_box.Text = "";
        }

        private void UpdateDamageFeeButton_Click(object sender, RoutedEventArgs e)
        {
            String id = resid_box.Text.ToString();
            String fee = damagefee_box.Text.ToString();

            if (id != "" && fee != "")
            {
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Reservations SET DAMAGEFEE = " + fee + " WHERE ID = " + id;
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Reservation updated!!");
            }
            else
            {
                MessageBox.Show("Please fill out ID / Damage Fee Section");
            }
            RefreshReservationData();
            resid_box.Text = "";
        }

        private void ShowFeedbackButton_Click(object sender, RoutedEventArgs e)
        {
            HotelFeedbacksForm hotelFeedbacksForm = new HotelFeedbacksForm();
            hotelFeedbacksForm.Show();
        }

        private void AuditButton_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = db.getConnection();
            int amount = 0;
            int fee = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            String[] date = System.DateTime.Now.ToString().Split(new char[] { '/', ' ' }, StringSplitOptions.None);
            cmd.CommandText = "SELECT COUNT(*) FROM Reservations WHERE YEAR(DATE_CREATED) = " + date[2] + " AND MONTH(DATE_CREATED) = " + date[0];
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                amount = int.Parse(reader[0].ToString());
            }
            reader.Close();
            cmd.CommandText = "SELECT SUM(DAMAGEFEE) FROM Reservations WHERE YEAR(DATE_CREATED) = " + date[2] + " AND MONTH(DATE_CREATED) = " + date[0];
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                fee = int.Parse(reader[0].ToString());
            }
            reader.Close();
            cmd.CommandText = "SELECT ID FROM Audits WHERE YEAR(AUDITDATE) = " + date[2] + " AND MONTH(AUDITDATE) = " + date[0] + " AND DEPARTMENT = 'FROF'";
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cmd.CommandText = "UPDATE Audits SET AMOUNT = " + ((amount * 100000) + fee).ToString() + " WHERE ID = " + reader[0];
                }
                reader.Close();
                cmd.ExecuteNonQuery();
            }
            else
            {
                reader.Close();
                cmd.CommandText = "INSERT INTO Audits(AUDITDATE, DEPARTMENT,AMOUNT) VALUES(@date, @dept, @amount)";
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "FROF");
                cmd.Parameters.AddWithValue("@amount", ((amount * 100000) + fee));
                cmd.ExecuteNonQuery();
            }
            con.Close();
            MessageBox.Show("Audit for month " + date[0] + ", year " + date[2] + " has been sent!");
        }
    }
}
