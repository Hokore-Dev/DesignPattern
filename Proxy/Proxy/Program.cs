using System;

namespace Proxy
{
    class MainClass
    {
        interface IImage
        {
            void Display();
        }

        class RealImage : IImage
        {
            public string FileName { get; private set; }

            public RealImage(string fileName)
            {
                FileName = fileName;
                LoadFromFile();
            }

            private void LoadFromFile()
            {
                Console.WriteLine("Loading " + FileName);
            }

            public void Display()
            {
                Console.WriteLine("Displaying " + FileName);
            }
        }

        class ProxyImage : IImage
        {
            public string FileName { get; private set; }
            private IImage image;

            public ProxyImage(string fileName)
            {
                FileName = fileName;
            }

            public void Display()
            {
                if (image == null)
                    image = new RealImage(FileName);
                image.Display();
            }
        }

        public static void Main(string[] args)
        {
            IImage image = new ProxyImage("HiRes_Image");
            for (int i = 0; i < 10; i++)
                image.Display();
        }
    }
}
