using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using RV_UnderTheSeaApp.Departments.RestaurantDepartment.RestaurantHelper;

namespace RV_UnderTheSeaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public MainWindow()
        {
            InitializeComponent();
            DisplayData();
            
        }
        
        public void encode(String content)
        {
            QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode;
            encoder.TryEncode(content, out qrCode);
            WriteableBitmapRenderer wRenderer = new WriteableBitmapRenderer(
                new FixedModuleSize(6, QuietZoneModules.Two),
                Colors.Black, Colors.White
            );
            WriteableBitmap wBitmap = new WriteableBitmap(
                150,
                150,
                150,
                150,
                PixelFormats.Gray8,
                null
            );
            wRenderer.Draw(wBitmap, qrCode.Matrix);
            image.Source = wBitmap;
        }

        public void DisplayData()
        {
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM TestTable";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }

        public void UpdateData(String content)
        {
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE TestTable SET TNAME ='" + content + "' WHERE ID = 1";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicked","Mouse Click Notification");

            
            String content = textBox.Text.TrimEnd();
            //UpdateData(content);
            //DisplayData();
            //encode(content);
            //demoLogin(content);
            insertTicket();
        }

        private void insertTicket()
        {
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Tickets (DATE_CREATED) VALUES(@date)";
            cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void demoLogin(String content)
        {
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM TestTable WHERE ID = " + content;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                }
            }
            else
            {
                MessageBox.Show("No Revelant ID");
            }
            con.Close();
        }

        private void validateTicket()
        {
            SqlConnection con = db.getConnection();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Tickets WHERE ID = 1";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                String dateCreated = reader[1].ToString();
                System.TimeSpan daysDiff = System.DateTime.Now - Convert.ToDateTime(dateCreated);
                int diff = (int)daysDiff.TotalDays;
                Console.WriteLine(diff);
            }
            con.Close();
        }

        private void DemoStatePatter()
        {
            Order order = new Order(new CreateOrderState());
            order.StartOrder(); // ini dipanggil terus buat statenya
        }
    }
}
