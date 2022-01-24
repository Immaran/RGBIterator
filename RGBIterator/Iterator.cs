using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace RGBIterator
{
    class Iterator
    {
        private short _step = 51; // works the best with divisors of 255 (1, 3, 5, 15, 17, 51, 85, 255); lower step = smoother changes

        private List<int> _RGB;

        private static Iterator _instance = new Iterator();

        private Iterator()
        {
            _RGB = new List<int> { 255, 0, 0 };
        }

        public static Iterator getIterator()
        {
            return _instance;
        }

        public Color Next()
        {
            for(byte i = 0; i < 3; i++)
            {
                if (_RGB[i] == 0)
                {
                    if (_RGB[(i + 1) % 3] == 255)
                    {
                        if (_RGB[(i + 2) % 3] != 255)
                        {
                            increase((i + 2) % 3);
                            break;
                        }
                        else
                        {
                            reduce((i + 1) % 3);
                            break;
                        }
                    }
                    else
                    {
                        if (_RGB[(i + 1) % 3] != 0)
                        {
                            reduce((i + 1) % 3);
                            break;
                        }
                        else
                        {
                            increase(i);
                            break;
                        }
                    }
                }
            }

            return Color.FromRgb((byte)_RGB[0], (byte)_RGB[1], (byte)_RGB[2]);
        }

        private void reduce(int index)
        {
            _RGB[index] = _RGB[index] - _step;

            if (_RGB[index] < 0) _RGB[index] = 0;
        }

        private void increase(int index)
        {
            _RGB[index] = _RGB[index] + _step;

            if (_RGB[index] > 255) _RGB[index] = 255;
        }

        public Boolean isDone()
        {
            return false; // it never ends
        }
    }
}
