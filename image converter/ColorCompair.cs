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
        ColorTranslator.FromHtml("#FFFFFF" ),//white
        ColorTranslator.FromHtml("#e2e2e2" ),//orange
        ColorTranslator.FromHtml("#c6c6c6" ),//maganta
        ColorTranslator.FromHtml("#aaaaaa" ),//lightblue
         ColorTranslator.FromHtml("#8d8d8d" ),//yellow
        ColorTranslator.FromHtml("#717171" ),//lime
        ColorTranslator.FromHtml("#555555" ),//pink
        ColorTranslator.FromHtml("#383838" ),//gray
         ColorTranslator.FromHtml("#1c1c1c" ) };
     

        private static string[] color =
        {   " ", "." , ":","X", "░",  "▄",  "▒","▓","█"
            
            
           
           
            
            
           
            
            
        };
        
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
            if(count == 0)
            {
                return excluse;
            }
            return ClosestColor(Color.FromArgb(255, r / count, g / count, b / count));



        }

        public static ColorCell SelectIcon(Color[] colorsin)
        {  
            String? secondColor =Average(colorsin);
            String firstColor = AverageWithout(colorsin, secondColor); 
            int selector = 0;
          

            for (int i = 1; i < colorsin.Length; i++)
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
