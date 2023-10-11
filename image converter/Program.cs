using image_converter;
using System.Drawing;
using System.Drawing.Imaging;

public static class start
{
    static Bitmap img;
    static int imageHeight;
    static int imageWidth;

    static int monitorHeight;
    static int monitorWidth;
    public static void Main(String[] args)
    {
        Console.WriteLine("X size");
        int xinput = int.Parse(Console.ReadLine());
        Console.WriteLine("Y size");
        int yinput = int.Parse(Console.ReadLine()) / 2;
        for (int i = 0; i < args.Length; i++)
        {






            if (args.Length > 0)
            {
                using StreamWriter file = new($"img{i}.txt");
                List<string> lines = new();
                Console.WriteLine("{0}", args[i]);
               

                if (File.Exists(args[i]))
                {

                    img = new Bitmap(args[i]);
                    int width = img.Width;
                    int height = img.Height;
                    double widthStep = img.Width / (double)xinput * 2;
                    double heightStep = img.Height / (double)yinput * 3;
                    Console.WriteLine(widthStep);
                    Console.WriteLine(heightStep);


                    for (double y = 0; y < height - heightStep; y += heightStep / 3)
                    {
                        string line = "";
                        string background = "";
                        string text = "";
                        for (double x = 0; x < width - widthStep; x += widthStep / 2)
                        {


                            Color[] pixels = new Color[] {img.GetPixel((int)x, (int)y), img.GetPixel((int)(x + widthStep *0.5), (int)y),
                                                                img.GetPixel((int)x, (int)(y + 1/3 * heightStep)), img.GetPixel((int)(x + widthStep *0.5),  (int)(y + 1/3* heightStep)),
                                                                img.GetPixel((int)x, (int)(y + 2/3* heightStep)), img.GetPixel((int)(x + widthStep *0.5),  (int)(y + 2/3* heightStep)) };

                            ColorCell colorCell = ColorCompair.SelectIcon(pixels);
                            line += " " + (int)(colorCell.ColorIndex + 128);
                            background += colorCell.BackgroundColor;
                            text += colorCell.TextColor;
                        }
                        //    file.WriteLine(line);
                        file.WriteLine(background);
                        // file.WriteLine(text);
                    }
                    file.Close();
                    Console.WriteLine(i);
                }
            }
        }
        Console.ReadLine();
    }
}
