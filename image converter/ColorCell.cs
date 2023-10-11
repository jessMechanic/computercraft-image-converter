using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image_converter
{
    class ColorCell
    {
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }

        public int ColorIndex { get; set; }

        public ColorCell(string backgroundColor, string textColor, int colorIndex)
        {
            BackgroundColor = backgroundColor;
            TextColor = textColor;
            ColorIndex = colorIndex;
        }
    }
}
