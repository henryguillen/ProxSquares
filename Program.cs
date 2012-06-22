using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.VideoSurveillance;
using System.Drawing;
using System.Linq;

using System.Collections.ObjectModel;
using System.IO;


namespace ProxSquaresWPF
{
    public class Program
    {


        public Image<Bgr, Byte> CreateImage(int[] radii, Bitmap shipsFile) {
            if (radii.Count() != 8)
                throw new ArgumentException();
            ;
            var source = new Image<Bgr, Byte>(shipsFile);

            int tileHeight = source.Height / (8 * 4); // 8 ships, 4 rows per ship
            int tileWidth = source.Width / 10; // 10 angles per row

            int max_radius = radii.Max()+1;

            var target = new Image<Bgr, Byte>(2*max_radius * 10, 2*max_radius * 8 * 4, new Bgr(Color.Black));

            for (int row_idx = 0; row_idx < 8 * 4; row_idx++)
            {
                int shipIndex = row_idx / 4;
                for (int col_idx = 0; col_idx < 10; col_idx++)
                {
                   Image<Bgr, Byte> subImage = source.GetSubRect(new Rectangle(new Point(col_idx * tileWidth, row_idx * tileHeight), new Size(tileWidth, tileHeight)));

                   target.ROI = new Rectangle(new Point(col_idx * (2 * max_radius) + (max_radius - tileWidth / 2), row_idx * (2 * max_radius) + (max_radius - tileHeight / 2)), new Size(subImage.Width, subImage.Height));

                   target.AddWeighted(subImage, 0, 1, 0).Copy(target, new Image<Gray, Byte>(target.Width, target.Height, new Gray(1)));

                   target.ROI = new Rectangle(new Point(col_idx * (2 * max_radius), row_idx * (2 * max_radius)), new Size(2*max_radius, 2*max_radius));

                   target.Draw(new Rectangle(new Point(max_radius - radii[shipIndex], max_radius - radii[shipIndex]), new Size(radii[shipIndex]*2, radii[shipIndex]*2)), new Bgr(Color.White), 1);
                
                   target.ROI = Rectangle.Empty;

                 
                }

            }

            return target;

        }
       
    }
}
