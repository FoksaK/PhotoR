﻿using System;
using PhotoR;
using SkiaSharp;

namespace PhotoR
{
    class Program: Helpers
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string uri = Console.ReadLine();
            SKBitmap Image = null;

            Load(ref Image, uri);

            Console.WriteLine(Image.GetPixel(0, 0));
        }
    }
}
