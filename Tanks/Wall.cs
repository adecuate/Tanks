using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Wall: IPicture
    {
        Image img;
        WallImg wallImg = new WallImg();
        public Wall()
        {
            img = wallImg.Img;
        }

        public Image Img
        {
            get
            {
                return img;
            }
        }
         
    }
}
