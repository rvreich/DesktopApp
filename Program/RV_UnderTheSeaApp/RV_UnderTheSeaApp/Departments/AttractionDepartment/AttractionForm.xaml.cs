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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i < 3; i++)
            {
                //QrEncoder encoder = new QrEncoder(ErrorCorrectionLevel.M);
                //QrCode qrCode;
                //encoder.TryEncode(i.ToString(), out qrCode);
                //WriteableBitmapRenderer wRenderer = new WriteableBitmapRenderer(
                //    new FixedModuleSize(6, QuietZoneModules.Two),
                //    Colors.Black, Colors.White
                //);
                //WriteableBitmap wBitmap = new WriteableBitmap(
                //    150,
                //    150,
                //    150,
                //    150,
                //    PixelFormats.Gray8,
                //    null
                //);
                //wRenderer.Draw(wBitmap, qrCode.Matrix);
                //CodeGeneratorForm code = new CodeGeneratorForm(wBitmap);
                //code.Show();
                
            }
        }
    }
}
