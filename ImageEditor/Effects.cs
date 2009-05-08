using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using AForge;

namespace ExtensionMethods
{
    public static class Effects
    {
        public static Bitmap ToSepia(this Bitmap bitmap)
        {
            AForge.Imaging.Filters.Sepia filter = new AForge.Imaging.Filters.Sepia();
            return filter.Apply(bitmap);
        }

        public static Bitmap ToPixalation(this Bitmap bitmap)
        {
            AForge.Imaging.Filters.Pixellate filter = new AForge.Imaging.Filters.Pixellate();
            return filter.Apply(bitmap);
        }

        public static Bitmap resize(this Bitmap bitmap, int width, int height)
        {
            AForge.Imaging.Filters.ResizeBicubic filter = new AForge.Imaging.Filters.ResizeBicubic(width, height);
            return filter.Apply(bitmap);
        }

        public static Bitmap rotate(this Bitmap bitmpa, int degrees)
        {
            AForge.Imaging.Filters.RotateBicubic filter = new AForge.Imaging.Filters.RotateBicubic(degrees);
            return filter.Apply(bitmpa);
        }
    }
}