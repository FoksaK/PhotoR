using System;
using System.Collections.Generic;
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
    }
}
