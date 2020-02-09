using System;
using System.Collections.Generic;

namespace MatrixLayerRotationPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            Version1.matrixRotation(new List<List<int>>()
            {
                new List<int>(){1, 2, 3, 4 },
                new List<int>(){7, 8, 9, 10},
                new List<int>(){13, 14, 15, 16},
                new List<int>(){19, 20, 21, 22},
                new List<int>(){25, 26, 27, 28},
            }, 7);
        }
    }
}
