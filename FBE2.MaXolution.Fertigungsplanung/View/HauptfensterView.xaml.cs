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
using MahApps.Metro.Controls;
using System.IO;
using System.Drawing.Imaging;
using FBE2.MaXolution.Fertigungsplanung.ViewModel;

namespace FBE2.MaXolution.Fertigungsplanung.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class HauptfensterView : MetroWindow
    {
        public HauptfensterView()
        {
            InitializeComponent();
            this.ToggleFlyout(0);
            this.DataContext = new HauptfensterViewModel();

            //BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            //var image =b.Encode(BarcodeLib.TYPE.CODE39, "7246587401.0001.M",600,90);
            //var bitmap = new System.Windows.Media.Imaging.BitmapImage();
            //bitmap.BeginInit();
            //MemoryStream memoryStream = new MemoryStream();
            //// Save to a memory stream...
            //image.Save(memoryStream, ImageFormat.Bmp);
            //// Rewind the stream...
            //memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            //bitmap.StreamSource = memoryStream;
            //bitmap.EndInit();
            //BImage.Source = bitmap;
        }

        private void StackPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.ToggleFlyout(0);
        }

        public void ToggleFlyout(int index)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
        }
    }
}
