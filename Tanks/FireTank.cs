using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class FireTank
    {
        FireTankImg ftImg = new FireTankImg();
        Image currentImg;

        public Image CurrentImg
        {
            get
            {
                return currentImg;
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

        Image[] img;

        int x, y;

        public FireTank(int x, int y)
        {
            this.x = x;
            this.y = y;
            img = ftImg.Img1;
            PutCurrentImage();
        }

        public void Burn()
        {
            PutCurrentImage();
        }

        int k;
        protected void PutCurrentImage()
        {
            currentImg = img[k];
            k++;

            if (k == 5)
                k = 0;
        }


    }
}
