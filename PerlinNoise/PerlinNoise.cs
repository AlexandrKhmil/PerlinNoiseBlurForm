using System; 

namespace PerlinNoiseBlurForm.PerlinNoise
{
    class PerlinNoise
    {
        public float[,][] Net;
        int lengthX,
            lengthY;

        public PerlinNoise(int lengthX, int lengthY, int w = 5, int h = 5, int seed = 0)
        {
            Net = new float[w, h][];

            var random = new Random(seed);

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {

                    Net[x, y] = RandomVector(random.Next(0, 4));
                }
            }

            this.lengthX = lengthX;
            this.lengthY = lengthY;
        }

        float[] RandomVector(int initialState)
        {
            switch (initialState)
            {
                case 0: return new float[] { 0, 1 };
                case 1: return new float[] { 0, -1 };
                case 2: return new float[] { 1, 0 };
                default: return new float[] { -1, 0 };
            }
        }

        float ScalarMult(float[] a, float[] b)
        {
            return a[0] * b[0] + a[1] * b[1];
        }

        float Quintic(float t)
        {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        float LinearInterpolation(float a, float b, float t)
        {
            return a + (b - a) * t;
        }

        public byte Process(int posX, int posY)
        {
            float x = (float)posX / lengthX * (Net.GetLength(0) - 1),
                  y = (float)posY / lengthY * (Net.GetLength(1) - 1);

            int netX = (int)x,
                netY = (int)y;

            int[] indexTopLeft = { netX, netY },
                  indexTopRight = { netX + 1, netY },
                  indexBottomLeft = { netX, netY + 1 },
                  indexBottomRight = { netX + 1, netY + 1 };

            x -= netX;
            y -= netY;

            float[] distanceToTopLeft = new float[] { x, y },
                    distanceToTopRight = new float[] { x - 1, y },
                    distanceToBottomLeft = new float[] { x, y - 1 },
                    distanceToBottomRight = new float[] { x - 1, y - 1 };

            float scalarTopLeft = ScalarMult(distanceToTopLeft, Net[indexTopLeft[0], indexTopLeft[1]]),
                  scalarTopRight = ScalarMult(distanceToTopRight, Net[indexTopRight[0], indexTopRight[1]]),
                  scalarBottomLeft = ScalarMult(distanceToBottomLeft, Net[indexBottomLeft[0], indexBottomLeft[1]]),
                  scalarBottomRight = ScalarMult(distanceToBottomRight, Net[indexBottomRight[0], indexBottomRight[1]]);

            x = Quintic(x);
            y = Quintic(y); 

            float linearResult = LinearInterpolation(LinearInterpolation(scalarTopLeft,    scalarTopRight,    x),
                                                     LinearInterpolation(scalarBottomLeft, scalarBottomRight, x),
                                                     y);

            byte result = (byte)((linearResult + 1) / 2 * 255);

            return result;
        }
    }
}
