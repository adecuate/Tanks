using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Apple: IPicture
    {
        Image img;
        AppleImg appleImg = new AppleImg();

        int x, y;

        public Apple(int x, int y)
        {
            img = appleImg.Img;
            this.x = x;
            this.y = y;
        }

        public Image Img
        {
            get
            {
                return img;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

        }
    }
}
