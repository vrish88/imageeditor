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

    }
}