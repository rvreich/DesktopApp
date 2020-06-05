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

namespace RV_UnderTheSeaApp.Entries
{
    /// <summary>
    /// Interaction logic for PermitForm.xaml
    /// </summary>
    public partial class PermitForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public PermitForm(String id)
        {
            InitializeComponent();
            RefreshPermitData(id);
        }

        private void RefreshPermitData(String id)
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM PermitReports WHERE WID = " + id;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }
    }
}
