using System; 
using System.Drawing;
using System.Threading;

namespace PerlinNoiseBlurForm.PerlinNoise
{
    class Handler
    { 
        static Color[,] I, O;
        static int numberOfThreads; 
        static PerlinNoise noise;
        static Blur blur;

        static void noiseThread(object threadNumber)
        {
            for (int x = (int)threadNumber; x < O.GetLength(0); x += numberOfThreads)
            {
                for (int y = 0; y < O.GetLength(1); y++)
                {
                    byte R = (byte)((noise.Process(x, y) + I[x, y].R) / 2),
                         G = (byte)((noise.Process(x, y) + I[x, y].G) / 2),
                         B = (byte)((noise.Process(x, y) + I[x, y].B) / 2);

                    O[x, y] = Color.FromArgb(R, G, B);
                }
            }
        }

        static void blurThread(object threadNumber)
        {
            for (int x = (int)threadNumber; x < O.GetLength(0); x += numberOfThreads)
            {
                for (int y = 0; y < O.GetLength(1); y++)
                {
                    O[x, y] = blur.Process(x, y); 
                }
            }
        }

        public static Bitmap Process(Bitmap img, int N = 1)
        {
            I = new Color[img.Width, img.Height];

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    I[i, j] = img.GetPixel(i, j);
                }
            } 

            O = new Color[img.Width, img.Height];

            numberOfThreads = N;
            Thread[] threadsForNoise = new Thread[numberOfThreads];
            Thread[] threadsForBlur = new Thread[numberOfThreads];

            noise = new PerlinNoise(img.Width, img.Height, 20, 20, new Random().Next(0, 100)); 
             
            for (int i = 0; i < numberOfThreads; i++)
            {
                threadsForNoise[i] = new Thread(new ParameterizedThreadStart(noiseThread));
                threadsForNoise[i].Start(i);
            }

            for (int i = 0; i < numberOfThreads; i++)
            {
                threadsForNoise[i].Join();
            }

            blur = new Blur(O, O.GetLength(0), O.GetLength(1));

            for (int i = 0; i < numberOfThreads; i++)
            {
                threadsForBlur[i] = new Thread(new ParameterizedThreadStart(blurThread));
                threadsForBlur[i].Start(i);
            }

            for (int i = 0; i < numberOfThreads; i++)
            {
                threadsForBlur[i].Join();
            }

            Bitmap result = new Bitmap(O.GetLength(0), O.GetLength(1));

            for (int i = 0; i < O.GetLength(0); i++)
            {
                for (int j = 0; j < O.GetLength(1); j++)
                {
                    result.SetPixel(i, j, O[i, j]);
                }
            }

            return result;
        }
    }
}
