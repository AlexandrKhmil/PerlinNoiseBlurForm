using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerlinNoiseBlurForm.PerlinNoise
{
    class Blur
    {
        int lengthX, lengthY;
        Color[,] I; 
        float[,] W = new float[10, 10]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        };

        public Blur(Color[,] I, int lengthX, int lengthY, float[,] W = null)
        {
            this.I = I; 

            this.lengthX = lengthX;
            this.lengthY = lengthY;

            this.W = W ?? this.W;
        } 

        public Color Process(int posX, int posY)
        {
            float sumR = 0,
                  sumG = 0,
                  sumB = 0,
                  sumW = 0;

            int k = W.GetLength(0) / 2;

            for (int i = 0; i < W.GetLength(0); i++)
            {
                for (int j = 0; j < W.GetLength(1); j++)
                {
                    bool indexIsInRange =
                        !(posX + i - k < 0) &
                        !(posY + j - k < 0) &
                        !(posX + i - k > lengthX - 1) &
                        !(posY + j - k > lengthY - 1);

                    if (indexIsInRange)
                    {
                        sumR += I[posX + i - k, posY + j - k].R * W[i, j];
                        sumG += I[posX + i - k, posY + j - k].G * W[i, j];
                        sumB += I[posX + i - k, posY + j - k].B * W[i, j];
                        sumW += W[i, j];
                    }
                }
            }

            byte R = (byte)(sumR / sumW),
                 G = (byte)(sumG / sumW),
                 B = (byte)(sumB / sumW);

            Color result = Color.FromArgb(R, G, B);

            return result;
        } 
    }
}
