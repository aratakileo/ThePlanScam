using UnityEngine;

namespace Pexty.Utils
{
    public static class ColorUtil
    {
        public static Color fromArgb(int argb) {
            System.Drawing.Color c = System.Drawing.Color.FromArgb(argb);
            return new Color(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f);
        }
        public static Color fromRgb(int rgb) {
            System.Drawing.Color c = System.Drawing.Color.FromArgb(rgb);
            return new Color(c.R / 255f, c.G / 255f, c.B / 255f, 1f);
        }

        public static int toArgb(Color color) {
            return System.Drawing.Color.FromArgb((int)(color.a * 255f), (int)(color.r * 255f), (int)(color.g * 255f), (int)(color.b * 255f)).ToArgb();
        }
    }
}
