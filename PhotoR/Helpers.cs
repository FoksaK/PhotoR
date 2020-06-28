using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using SkiaSharp;

namespace PhotoR
{
    public class Helpers
    {
        public static int s, d;

        public static List<SKColor> colors = new List<SKColor>();


        public static void Load(ref SKBitmap Bitmap, string src)
        {
            FileStream streamBG = new FileStream(src, FileMode.Open);

            Bitmap = SKBitmap.Decode(streamBG);
        }

        public static int GetDistance(SKColor current, SKColor match)
        {
            int redDifference;
            int greenDifference;
            int blueDifference;

            redDifference = current.Red - match.Red;
            greenDifference = current.Green - match.Green;
            blueDifference = current.Blue - match.Blue;

            return redDifference * redDifference + greenDifference * greenDifference + blueDifference * blueDifference;
        }

        public static bool Exist1(SKBitmap Image)
        {

            int sim1 = 400;
            int step = 10;


            for(int q = 10; q < Image.Height - 10; q = q + step)
            {

                for (int w = 10; w < Image.Width - 10; w = w + step)
                {

                    var a = Image.GetPixel(w, q);

                    if((GetDistance(a, SKColor.Parse("#000000")) < sim1)
                        ||
                        (GetDistance(a, SKColor.Parse("#996633")) < sim1)
                        ||
                        (GetDistance(a, SKColor.Parse("#FF0000")) < sim1)
                        ||
                        (GetDistance(a, SKColor.Parse("#FF9900")) < sim1)
                        ||
                        (GetDistance(a, SKColor.Parse("#FFFF00")) < sim1)
                        ||
                        (GetDistance(a, SKColor.Parse("#00FF00")) < sim1)
                        ||
                        (GetDistance(a, SKColor.Parse("#0000FF")) < sim1)
                        ||
                        (GetDistance(a, SKColor.Parse("#FF00FF")) < sim1)
                        ||
                        (GetDistance(a, SKColor.Parse("#CCCCCC")) < sim1)
                        ||
                        (GetDistance(a, SKColor.Parse("#FFFFFF")) < sim1)
                        )
                    {
                        for (int e = q - 50; e < q + 50; e = e + step)
                        {

                            for (int r = w - 50; r < Image.Width + 50; r = r + step)
                            {
                                if (r < 0)
                                {
                                    r = 0;
                                }
                                if (e < 0)
                                {
                                    e = 0;
                                }


                                var b = Image.GetPixel(r, e);

                                if (((GetDistance(b, SKColor.Parse("#000000")) < sim1)
                                    ||
                                    (GetDistance(b, SKColor.Parse("#996633")) < sim1)
                                    ||
                                    (GetDistance(b, SKColor.Parse("#FF0000")) < sim1)
                                    ||
                                    (GetDistance(b, SKColor.Parse("#FF9900")) < sim1)
                                    ||
                                    (GetDistance(b, SKColor.Parse("#FFFF00")) < sim1)
                                    ||
                                    (GetDistance(b, SKColor.Parse("#00FF00")) < sim1)
                                    ||
                                    (GetDistance(b, SKColor.Parse("#0000FF")) < sim1)
                                    ||
                                    (GetDistance(b, SKColor.Parse("#FF00FF")) < sim1)
                                    ||
                                    (GetDistance(b, SKColor.Parse("#CCCCCC")) < sim1)
                                    ||
                                    (GetDistance(b, SKColor.Parse("#FFFFFF")) < sim1))
                                    && (GetDistance(b, a) > sim1)
                                    )
                                {

                                    for (int y = q - 50; e < q + 50; e = e + step)
                                    {

                                        for (int x = w - 50; r < Image.Width + 50; r = r + step)
                                        {
                                            if (r < 0)
                                            {
                                                r = 0;
                                            }
                                            if (e < 0)
                                            {
                                                e = 0;
                                            }


                                            var c = Image.GetPixel(r, e);

                                            if (((GetDistance(b, SKColor.Parse("#000000")) < sim1)
                                                ||
                                                (GetDistance(b, SKColor.Parse("#996633")) < sim1)
                                                ||
                                                (GetDistance(b, SKColor.Parse("#FF0000")) < sim1)
                                                ||
                                                (GetDistance(b, SKColor.Parse("#FF9900")) < sim1)
                                                ||
                                                (GetDistance(b, SKColor.Parse("#FFFF00")) < sim1)
                                                ||
                                                (GetDistance(b, SKColor.Parse("#00FF00")) < sim1)
                                                ||
                                                (GetDistance(b, SKColor.Parse("#0000FF")) < sim1)
                                                ||
                                                (GetDistance(b, SKColor.Parse("#FF00FF")) < sim1)
                                                ||
                                                (GetDistance(b, SKColor.Parse("#CCCCCC")) < sim1)
                                                ||
                                                (GetDistance(b, SKColor.Parse("#FFFFFF")) < sim1))
                                                && (GetDistance(b, a) > sim1) && (GetDistance(b, c) > sim1)
                                                )
                                            {
                                                s = w;
                                                d = q;

                                                return true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            s = 0;
            d = 0;

            return false;
        }

        public static bool Exist2(SKBitmap Image)
        {
            int Sim1 = 200;
            int Sim = 40000;

            int Avg = 0;

            for (int i = 10; i < Image.Width; i += 10)
            {
                int z = 0;
                int sum = 0;


                for (int y = 10; y < Image.Height; y += 5) {

                    z++;

                    var a = Image.GetPixel(i, y);

                    int b = a.Red * a.Red + a.Green * a.Green + a.Blue + a.Blue;

                    sum += b;

                    if ((b - Avg > Sim || Avg - b > Sim) && Avg > 0 &&
                        ((GetDistance(a, Image.GetPixel(i, y + 10)) < Sim1) || (GetDistance(a, Image.GetPixel(i, y - 10)) < Sim1))
                       )
                    {       
                        s = i;
                        d = y;
                        return true;   
                    }

                }

                Avg = sum / z;

            }

            return false;
        }


            public static void Strips(SKBitmap Image)
        {

            //GetDistance(a, SKColor.Parse("#FF9900")) < 50;

        }
    }
}
