using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Samples.Kinect.ControlsBasics
{
    class PrintLetterDictionary
    {
        public static bool[,] A = new bool[5,4]{{false,true,true,false},
                                                {true,false,false,true},
                                                {true,true,true,true},
                                                {true,false,false,true},
                                                {true,false,false,true}};


        public static bool[,] B = new bool[5, 4]{   {true,true,true,false},
                                                    {true,false,false,true},
                                                    {true,true,true,false},
                                                    {true,false,false,true},
                                                    {true,true,true,false}};

        public static bool[,] C = new bool[5, 3]{  {false,true,true},
                                            {true,false,false},
                                            {true,false,false},
                                            {true,false,false},
                                            {false,true,true}};

        public static bool[,] D = new bool[5, 3]{  {true,true,false},
                                            {true,false,true},
                                            {true,false,true},
                                            {true,false,true},
                                            {true,true,false}};

        public static bool[,] E = new bool[5, 3]{  {true,true,true},
                                            {true,false,false},
                                            {true,true,true},
                                            {true,false,false},
                                            {true,true,true}};

        public static bool[,] F = new bool[5, 3]{  {true,true,true},
                                            {true,false,false},
                                            {true,true,true},
                                            {true,false,false},
                                            {true,false,false}};

        public static bool[,] G = new bool[5, 4]{  {false,true,true,false},
                                            {true,false,false,false},
                                            {true,false,true,true},
                                            {true,false,false,true},
                                            {false,true,true,false}};

        public static bool[,] H = new bool[5, 4]{  {true,false,false,true},
                                            {true,false,false,true},
                                            {true,true,true,true},
                                            {true,false,false,true},
                                            {true,false,false,true}};

        public static bool[,] I = new bool[5, 1]{  {true},
                                            {true},
                                            {true},
                                            {true},
                                            {true}};

        public static bool[,] J = new bool[5, 2]{  {false,true},
                                            {false,true},
                                            {false,true},
                                            {false,true},
                                            {true,false}};

        public static bool[,] K = new bool[5, 4]{   {true,false,false,true},
                                                    {true,false,true,false},
                                                    {true,true,false,false},
                                                    {true,false,true,false},
                                                    {true,false,false,true}};

        public static bool[,] L = new bool[5, 3]{  {true,false,false},
                                            {true,false,false},
                                            {true,false,false},
                                            {true,false,false},
                                            {true,true,true}};

        public static bool[,] M = new bool[5, 5]{  {true,false,false,false,true},
                                            {true,true,false,true,true},
                                            {true,false,true,false,true},
                                            {true,false,false,false,true},
                                            {true,false,false,false,true}};

        public static bool[,] N = new bool[5, 4]{  {true,false,false,true},
                                            {true,true,false,true},
                                            {true,false,true,true},
                                            {true,false,false,true},
                                            {true,false,false,true}};

        public static bool[,] O = new bool[5, 4]{  {false,true,true,false},
                                            {true,false,false,true},
                                            {true,false,false,true},
                                            {true,false,false,true},
                                            {false,true,true,false}};

        public static bool[,] P = new bool[5, 4]{  {true,true,true,false},
                                            {true,false,false,true},
                                            {true,true,true,false},
                                            {true,false,false,false},
                                            {true,false,false,false}};

        public static bool[,] Q = new bool[5, 5]{  {false,true,true,false,false},
                                            {true,false,false,true,false},
                                            {true,false,false,true,false},
                                            {true,false,false,true,false},
                                            {false,true,true,true,true}};

        public static bool[,] R = new bool[5, 4]{  {true,true,true,false},
                                            {true,false,false,true},
                                            {true,true,true,false},
                                            {true,false,true,false},
                                            {true,false,false,true}};

        public static bool[,] S = new bool[5, 3]{  {true,true,true},
                                            {true,false,false},
                                            {true,true,true},
                                            {false,false,true},
                                            {true,true,true}};

        public static bool[,] T = new bool[5, 5]{  {true,true,true,true,true},
                                            {false,false,true,false,false},
                                            {false,false,true,false,false},
                                            {false,false,true,false,false},
                                            {false,false,true,false,false}};

        public static bool[,] U = new bool[5, 4]{  {true,false,false,true},
                                            {true,false,false,true},
                                            {true,false,false,true},
                                            {true,false,false,true},
                                            {false,true,true,false}};

        public static bool[,] V = new bool[5, 5]{  {true,false,false,false,true},
                                            {true,false,false,false,true},
                                            {true,false,false,false,true},
                                            {false,true,false,true,false},
                                            {false,false,true,false,false}};

        public static bool[,] W = new bool[5, 5]{  {true,false,false,false,true},
                                            {true,false,false,false,true},
                                            {true,false,true,false,true},
                                            {true,false,true,false,true},
                                            {false,true,false,true,false}};

        public static bool[,] X = new bool[5, 3]{  {true,false,true},
                                            {true,false,true},
                                            {false,true,false},
                                            {true,false,true},
                                            {true,false,true}};

        public static bool[,] Y = new bool[5, 5]{  {true,false,false,false,true},
                                            {false,true,false,true,false},
                                            {false,false,true,false,false},
                                            {false,false,true,false,false},
                                            {false,false,true,false,false}};

        public static bool[,] Z = new bool[5, 3]{  {true,true,true},
                                            {false,false,true},
                                            {false,true,false},
                                            {true,false,false},
                                            {true,true,true}};

        public static bool[,] Homer = new bool[24, 19]{
            {false,false,false,false,false,true,true,true,true,true,true,false,false,false,false,false,false,false,false},
            {false,false,false,false,true,false,false,false,false,false,false,true,false,false,false,false,false,false,false},
            {false,false,false,true,false,false,false,false,false,false,false,false,true,false,false,false,false,false,false},
            {false,false,true,false,false,false,false,false,false,false,false,false,true,false,false,false,false,false,false},
            {false,false,true,false,false,false,false,false,false,false,false,false,true,true,true,false,false,false,false},
            {false,true,false,false,false,false,false,true,true,true,true,true,false,false,false,true,false,false,false},
            {false,true,false,false,false,false,true,false,false,false,false,true,false,false,false,false,true,false,false},
            {false,true,false,false,false,true,false,false,false,false,false,false,true,false,true,false,true,false,false},
            {false,true,false,false,false,true,false,false,false,false,false,false,true,false,false,false,true,false,false},
            {false,false,false,false,false,true,false,false,true,false,false,false,true,true,true,true,false,false,false},
            {false,true,true,false,false,false,true,false,false,false,false,true,false,false,false,false,true,false,false},
            {true,false,false,false,false,false,false,true,true,true,true,false,false,false,false,false,true,false,false},
            {true,false,false,false,false,false,false,false,false,false,false,false,true,true,true,true,false,false,false},
            {true,false,false,true,false,false,false,false,true,true,true,false,false,false,false,true,false,false,false},
            {false,true,true,false,false,false,false,false,true,false,false,false,false,false,false,false,false,true,false},
            {false,false,true,false,false,false,false,true,false,false,false,false,false,false,false,false,true,false,false},
            {false,false,true,false,false,false,true,false,false,false,false,false,false,false,false,false,false,false,true},
            {false,false,true,false,false,false,true,false,true,false,false,false,false,false,false,false,false,false,true},
            {false,false,true,false,false,false,true,false,true,true,true,true,true,true,true,true,true,true,false},
            {false,false,true,false,false,false,true,false,false,false,false,false,false,false,false,true,false,false,false},
            {false,false,true,false,false,false,false,true,false,false,false,false,false,false,true,false,false,false,false},
            {false,false,false,false,false,false,false,true,false,false,false,false,false,false,true,false,false,false,false},
            {false,false,false,false,false,false,false,false,true,false,false,false,false,true,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false,true,true,true,true,false,false,false,false,false,false}

        };

        public static bool[,] Smilie = new bool[18, 18]{
            {false,false,false,false,false,false,false,true,true,true,true,true,false,false,false,false,false,false},
            {false,false,false,false,true,true,true,false,false,false,false,false,true,true,false,false,false,false},
            {false,false,false,true,false,false,false,false,false,false,false,false,false,false,true,false,false,false},
            {false,false,true,false,false,false,false,false,false,false,false,false,false,false,false,true,false,false},
            {false,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true,false},
            {false,true,false,false,false,false,true,true,false,false,true,true,false,false,false,false,false,true},
            {false,true,false,false,false,false,true,true,false,false,true,true,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true},
            {true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true,false,true},
            {true,false,false,true,false,false,false,false,false,false,false,false,false,false,false,true,false,true},
            {false,true,false,true,false,false,false,false,false,false,false,false,false,false,true,false,false,true},
            {false,true,false,false,true,true,false,false,false,false,false,false,false,true,true,false,false,true},
            {false,false,true,false,false,true,true,false,false,false,false,false,true,true,false,false,true,false},
            {false,false,false, true,false,false,false,true,true,true,true,true,false,false,false,true,false,false},
            {false,false,false,false,true,false,false,false,false,false,false,false,false,false,true,false,false,false},
            {false,false,false,false,false,true,true,true,true,true,true,true,true,true,false,false,false,false}
           };

        public static bool[,] Heart = new bool[18, 18]{
            {false,false,false,false,true,true,true,false,false,false,false,false,true,true,true,false,false,false},
            {false,false,true,true,true,true,true,true,true,false,true,true,true,true,true,true,true,false},
            {false,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true},
            {false,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true},
            {true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true},
            {true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true},
            {true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true},
            {false,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true},
            {false,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true},
            {false,false,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,false},
            {false,false,false,true,true,true,true,true,true,true,true,true,true,true,true,true,false,false},
            {false,false,false,false,true,true,true,true,true,true,true,true,true,true,true,false,false,false},
            {false,false,false,false,false,true,true,true,true,true,true,true,true,true,false,false,false,false},
            {false,false,false,false,false,false,true,true,true,true,true,true,true,false,false,false,false,false},
            {false,false,false,false,false,false,false,true,true,true,true,true,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,true,true,true,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false,true,false,false,false,false,false,false,false,false},
            {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false}
           };
       
        public static bool[,] getPrintPatternByChar(char txt)
        {
            bool[,] printPattern = new bool[0,0];
            
            switch (txt)
            {
                case 'A': 
                    printPattern = A;
                    break;
                case 'B':
                    printPattern = B;
                    break;
                case 'C':
                    printPattern = C;
                    break;
                case 'D':
                    printPattern = D;
                    break;
                case 'E':
                    printPattern = E;
                    break;
                case 'F':
                    printPattern = F;
                    break;
                case 'G':
                    printPattern = G;
                    break;
                case 'H':
                    printPattern = H;
                    break;
                case 'I':
                    printPattern = I;
                    break;
                case 'J':
                    printPattern = J;
                    break;
                case 'K':
                    printPattern = K;
                    break;
                case 'L':
                    printPattern = L;
                    break;
                case 'M':
                    printPattern = M;
                    break;
                case 'N':
                    printPattern = N;
                    break;
                case 'O':
                    printPattern = O;
                    break;
                case 'P':
                    printPattern = P;
                    break;
                case 'Q':
                    printPattern = Q;
                    break;
                case 'R':
                    printPattern = R;
                    break;
                case 'S':
                    printPattern = S;
                    break;
                case 'T':
                    printPattern = T;
                    break;
                case 'U':
                    printPattern = U;
                    break;
                case 'V':
                    printPattern = V;
                    break;
                case 'W':
                    printPattern = W;
                    break;
                case 'X':
                    printPattern = X;
                    break;
                case 'Y':
                    printPattern = Y;
                    break;
                case 'Z':
                    printPattern = Z;
                    break;
                default:
                    break;
            }

            return printPattern;

        }
    }


}
