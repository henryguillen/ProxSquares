using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Emgu.CV;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Interop;
using Emgu.CV.Structure;

namespace ProxSquaresWPF
{
    public static class Extensions
    {

        public static ImageSource AsImageSource(this Image<Bgr, Byte> image)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(image.Bitmap.GetHbitmap(),
                               IntPtr.Zero, Int32Rect.Empty,
                               BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
