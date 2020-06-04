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
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace RV_UnderTheSeaApp.Departments.AttractionDepartment
{
    /// <summary>
    /// Interaction logic for AttractionForm.xaml
    /// </summary>
    public partial class AttractionForm : Window
    {
        private DatabaseConnection db = DatabaseConnection.Instance;

        public AttractionForm()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            SqlConnection con = db.getConnection();
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ID, WORKERNAME FROM Workers WHERE WORKERPOSITION = 'ATTR'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void Generate_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Confirmation", "Generate Ticket ?", MessageBoxButton.YesNo);
            if(messageBoxResult == MessageBoxResult.Yes)
            {
                int count = int.Parse(ticket_amount_box.Text.ToString().Trim());
                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        SqlConnection con = db.getConnection();
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT COUNT(*) From Tickets";
                        SqlDataReader reader = cmd.ExecuteReader();
                        int id = 0;
                        while (reader.Read())
                        {
                            id = 1 + int.Parse(reader[0].ToString().Trim());
                        }
                        Console.WriteLine(id);
                        GenerateQR(id);
                        insertTicketData();
                    }
                    FeeForm feeForm = new FeeForm(count);
                    feeForm.Show();
                }
            }
        }

        private void GenerateQR(int id)
        {
            QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode;
            encoder.TryEncode(id.ToString(), out qrCode);
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
            CodeGeneratorForm code = new CodeGeneratorForm(wBitmap);
            code.Show();
        }

        private void insertTicketData()
        {
            SqlConnection con = db.getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Tickets (DATE_CREATED) VALUES(@date)";
            cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Validate_btn_Click(object sender, RoutedEventArgs e)
        {
            String id = validation_box.Text.ToString().Trim();
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
            con.Close();
        }

        private void Logout_button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
            this.Close();
        }

        private void Generate_report_Click(object sender, RoutedEventArgs e)
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
            cmd.CommandText = "SELECT COUNT(*) FROM Tickets WHERE YEAR(DATE_CREATED) = " + date[2] + " AND MONTH(DATE_CREATED) = " + date[0];
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                amount = int.Parse(reader[0].ToString());
            }
            reader.Close();
            cmd.CommandText = "SELECT ID FROM Audits WHERE YEAR(AUDITDATE) = " + date[2] + " AND MONTH(AUDITDATE) = " + date[0] + " AND DEPARTMENT = 'ATTR'";
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cmd.CommandText = "UPDATE Audits SET AMOUNT = " + (amount * 60000).ToString() + " WHERE ID = " + reader[0];
                }
                reader.Close();
                cmd.ExecuteNonQuery();
            }
            else
            {
                reader.Close();
                cmd.CommandText = "INSERT INTO Audits(AUDITDATE, DEPARTMENT,AMOUNT) VALUES(@date, @dept, @amount)";
                cmd.Parameters.AddWithValue("@date", System.DateTime.Now);
                cmd.Parameters.AddWithValue("@dept", "ATTR");
                cmd.Parameters.AddWithValue("@amount", (amount * 60000));
                cmd.ExecuteNonQuery();
            }
            con.Close();
            MessageBox.Show("Audit for month " + date[0] + ", year " + date[2] + " has been sent!");
        }
    }
}
