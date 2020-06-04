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
    /// Interaction logic for TotalFeeForm.xaml
    /// </summary>
    public partial class TotalFeeForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public TotalFeeForm(String num, int amount)
        {
            InitializeComponent();
            tableLabel.Content = num;
            int total = (amount * 45000);
            totalLabel.Content = total.ToString();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            String feedback = feedback_box.Text.ToString();
            if(feedback != "")
            {
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO GeneralReports (REPORTDATE,DEPARTMENT,CONTENT) VALUES(@date,@dept,@cont)";
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "DIRO");
                cmd.Parameters.AddWithValue("@cont", feedback);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thank you for the feedback!!");
                con.Close();
            }
            feedback_box.Text = "";
        }
    }
}
