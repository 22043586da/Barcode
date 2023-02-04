using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

namespace BarcodeTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var barcode = new BarcodeGenerator.CustomBarCodeGenerator();
            Bitmap im = barcode.Encode("1123456",12,8);
            
            var ms = new MemoryStream();
            im.Save(ms,ImageFormat.Bmp);

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = ms;
            image.CacheOption= BitmapCacheOption.OnLoad;
            image.EndInit();

            IMAGEBarcode.Source = image;

        }
    }
}
