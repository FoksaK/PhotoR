using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using SkiaSharp;

namespace PhotoR
{
    public class Helpers
    {
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

        public static bool Exist(int x, int y, SKBitmap Image)
        {
            for(int q = 0; q<Image.Height; q = q + 10)
            {
                for (int p = 0; p < Image.Width; p = p + 10)
                {
                    var a = Image.GetPixel(x + p, y + q);

                    if (GetDistance(a, SKColor.Parse("#000000")) < 5000) //#FF9900
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
