using RV_UnderTheSeaApp.Departments.AttractionDepartment;
using RV_UnderTheSeaApp.Departments.ConstructionDepartment;
using RV_UnderTheSeaApp.Departments.MaintenanceDepartment;
using RV_UnderTheSeaApp.Departments.RideAttractionCreativeDepartment;
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

namespace RV_UnderTheSeaApp
{
    /// <summary>
    /// Interaction logic for LoginWindows.xaml
    /// </summary>
    public partial class LoginWindows : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public LoginWindows()
        {
            InitializeComponent();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            String username = username_box.Text.ToString().Trim();
            String password = password_box.Text.ToString().Trim();
            String position = "";

            SqlConnection con = db.getConnection();
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Workers WHERE WORKERUSERNAME = '" + username + "' AND WORKERPASSWORD = '" + password + "'";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    position = reader[7].ToString();
                }
            }
            else
            {
                MessageBox.Show("Incorrect Username / Password");
                username_box.Text = "";
                password_box.Text = "";
            }
            con.Close();
            if (position.CompareTo("") != 0)
            {
                switchForm(position);
            }
        }

        private void switchForm(String position)
        {
            SqlConnection con = db.getConnection();
            switch (position)
            {
                case "ATTR":
                    AttractionForm attractionForm = new AttractionForm();
                    attractionForm.Show();
                    this.Close();
                    break;
                case "MAIN":
                    MaintenanceForm maintenanceForm = new MaintenanceForm();
                    maintenanceForm.Show();
                    this.Close();
                    break;
                case "RIAC":
                    RideAttractionForm rideAttractionForm = new RideAttractionForm();
                    rideAttractionForm.Show();
                    this.Close();
                    break;
                case "CONS":
                    ConstructionForm constructionForm = new ConstructionForm();
                    constructionForm.Show();
                    this.Close();
                    break;
                case "DIRO":
                    break;
                case "KITC":
                    break;
                case "PURC":
                    break;
                case "ACFI":
                    break;
                case "FROF":
                    break;
                case "HOKE":
                    break;
                case "SAMA":
                    break;
                case "HURD":
                    break;
                case "MANA":
                    break;
                default:
                    MessageBox.Show("ERROR: UNKNOWN POSITION DETECTED");
                    break;
            }
        }
    }
}
