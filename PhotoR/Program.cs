using System;
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

                if (Exist2(Image))
                {
                    Console.WriteLine("Ano");
                }
                else
                {
                    Console.WriteLine("Ne");
                }

                Console.WriteLine(s + " : " + d);
                Console.WriteLine(Image.Width);
                Console.WriteLine(Image.Height);

                Strips(Image);

                foreach (SKColor color in colors)
                {
                    Console.WriteLine(color);
                }
            
           
        }
    }
}
