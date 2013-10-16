using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DraftPixel
{
    public struct Pixel
        {
        public int x;
        public int y;
        }
    public DraftPixel(int x,int y)
    {
        this.DraftPixels = new bool[x, y];
    }
    bool[,] DraftPixels;
    public bool this[int i, int j]
    {
        get 
        { 
            return DraftPixels[i,j]; 
        }
        set 
        {
            DraftPixels[i, j] = value;
            /* set the specified index to value here */ 
        }
    }
}
