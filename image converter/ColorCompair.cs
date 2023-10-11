using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace image_converter
{
    static class ColorCompair
    {
        private static Color[] colors = {
        ColorTranslator.FromHtml("#F0F0F0" ),//white
        ColorTranslator.FromHtml("#F2B233" ),//orange
        ColorTranslator.FromHtml("#E57FD8" ),//maganta
        ColorTranslator.FromHtml("#99B2F2" ),//lightblue
         ColorTranslator.FromHtml("#DEDE6C" ),//yellow
        ColorTranslator.FromHtml("#7FCC19" ),//lime
        ColorTranslator.FromHtml("#F2B2CC" ),//pink
        ColorTranslator.FromHtml("#4C4C4C" ),//gray
         ColorTranslator.FromHtml("#999999" ),      //light gray
         ColorTranslator.FromHtml("#4C99B2" ),
          ColorTranslator.FromHtml("#B266E5" ),
           ColorTranslator.FromHtml("#3366CC" ),
           ColorTranslator.FromHtml("#7F664C" ),
            ColorTranslator.FromHtml("#57A64E" ),
           ColorTranslator.FromHtml("#CC4C4C" ),
         ColorTranslator.FromHtml("#191919" )


        };


        private static string[] color =
        {   "0", "1" , "2","3", "4",  "5",  "6","7","8" ,"9","a","b","c","d","e","f" };

        public static string ClosestColor(Color colorIn)
        {
            double closest = 1000;
            int index = 0;
            for (int i = 0; i < colors.Length; i++)
            {
                Color color = colors[i];
                double distance = Math.Sqrt(Math.Pow(colorIn.R - color.R, 2) + Math.Pow(colorIn.G - color.G, 2) + Math.Pow(colorIn.B - color.B, 2));
                if (distance < closest)
                {
                    closest = distance;
                    index = i;
                }
            }

            return color[index];
        }
        public static string Average(Color[] colorIN)
        {

            int distance = 1000;

            int r = 0, g = 0, b = 0;
            foreach (Color item in colorIN)
            {
                r += item.R;
                g += item.G;
                b += item.B;
            }

            return ClosestColor(Color.FromArgb(255, r / colorIN.Length, g / colorIN.Length, b / colorIN.Length));



        }

        public static string AverageWithout(Color[] colorIN, string excluse)
        {

            int distance = 1000;

            int r = 0, g = 0, b = 0;

            int count = 0;
            foreach (Color item in colorIN)
            {
                if (excluse != ClosestColor(item))
                {
                    r += item.R;
                    g += item.G;
                    b += item.B;
                    count++;
                }

            }
            if (count == 0)
            {
                return excluse;
            }
            return ClosestColor(Color.FromArgb(255, r / count, g / count, b / count));



        }

        public static ColorCell SelectIcon(Color[] colorsin)
        {
            String? secondColor = Average(colorsin);
            String firstColor = AverageWithout(colorsin, secondColor);
            int selector = 0;


            for (int i = 0; i < colorsin.Length; i++)
            {
                if (ClosestColor(colorsin[i]) != firstColor)
                {
                    selector += i ^ 2;

                }
            }


            return new(firstColor, secondColor, selector);
        }

    }
}
