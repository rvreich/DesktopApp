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
    /// Interaction logic for HotelFeedbacksForm.xaml
    /// </summary>
    public partial class HotelFeedbacksForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public HotelFeedbacksForm()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            String content = feedback_box.Text.ToString();
            if (content != "")
            {
                SqlConnection con = db.getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO GeneralReports (REPORTDATE, DEPARTMENT, CONTENT) VALUES (@reda, @dept, @cont)";
                cmd.Parameters.AddWithValue("@reda", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "FROF");
                cmd.Parameters.AddWithValue("@cont", content);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thank you for the feedbacks");
            }
            feedback_box.Text = "";
        }
    }
}
