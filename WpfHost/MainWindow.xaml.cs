using System;
using System.Windows;
using System.Threading;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.IO;

namespace ProxSquaresWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Program Instance;


        
        public MainWindow()
        {
            InitializeComponent();
            Instance = new Program();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            BullshitSysopMessage.Visibility = Visibility.Visible;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            PreviewBox.Visibility = Visibility.Visible;
            Dispatcher.BeginInvoke(new ThreadStart(() =>
            {
                int radius_warbird = Int32.Parse(Radii_Warbird.Text);
                int radius_javelin = Int32.Parse(Radii_Javelin.Text);
                int radius_spider = Int32.Parse(Radii_Spider.Text);
                int radius_leviathan = Int32.Parse(Radii_Leviathan.Text);
                int radius_terrier = Int32.Parse(Radii_Terrier.Text);
                int radius_Weasel = Int32.Parse(Radii_Weasel.Text);
                int radius_Lancaster = Int32.Parse(Radii_Lancaster.Text);
                int radius_Shark = Int32.Parse(Radii_Shark.Text);

                var shipsFilePath = "ships.bmp";

                Bitmap ships = new Bitmap(new FileInfo(shipsFilePath).OpenRead());

                Image<Bgr, Byte> image = Instance.CreateImage(new int[] { radius_warbird,radius_javelin, radius_spider, radius_leviathan, radius_terrier, radius_Weasel, radius_Lancaster, radius_Shark }, ships);
                imgbox.Source = image.AsImageSource();
                imgbox.Height = image.Height;
                imgbox.Width = image.Width;
            }));
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "ships.bm2"; // Default file name
            dlg.DefaultExt = ".bm2"; // Default file extension
            dlg.Filter = "ships.bm2 (.bm2)|*.bm2"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;


                Dispatcher.BeginInvoke(new ThreadStart(() =>
                {
                    int radius_warbird = Int32.Parse(Radii_Warbird.Text);
                    int radius_javelin = Int32.Parse(Radii_Javelin.Text);
                    int radius_spider = Int32.Parse(Radii_Spider.Text);
                    int radius_leviathan = Int32.Parse(Radii_Leviathan.Text);
                    int radius_terrier = Int32.Parse(Radii_Terrier.Text);
                    int radius_Weasel = Int32.Parse(Radii_Weasel.Text);
                    int radius_Lancaster = Int32.Parse(Radii_Lancaster.Text);
                    int radius_Shark = Int32.Parse(Radii_Shark.Text);

                    var shipsFilePath = "ships.bmp";

                    Bitmap ships = new Bitmap(new FileInfo(shipsFilePath).OpenRead());

                    Image<Bgr, Byte> image = Instance.CreateImage(new int[] { radius_warbird, radius_javelin, radius_spider, radius_leviathan, radius_terrier, radius_Weasel, radius_Lancaster, radius_Shark }, ships);

                    image.ToBitmap().Save(filename);
                    
                }));
            }
        }


    }




}
