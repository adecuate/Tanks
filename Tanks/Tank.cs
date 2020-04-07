using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class Tank : IRun, ITurn, ITransparent, ICurrentPicture
    {
        private void PutImg()
        {
            if (direct_x == 1)
                img = tankImg.Right;
            if (direct_x == -1)
                img = tankImg.Left;
            if (direct_y == 1)
                img = tankImg.Down;
            if (direct_y == -1)
                img = tankImg.Up;
        }

        private TankImg tankImg = new TankImg();

        protected Image[] img;
        protected Image currentImg;
        protected int sizeField;
        protected int x, y, direct_x, direct_y;
        protected static Random r;
        protected int k;
        protected void PutCurrentImage()
        {
            currentImg = img[k];
            k++;

            if (k == 5)
                k = 0;
        }



        public void Turn()
        {
            
                if (r.Next(5000) < 2500) //vertical movement
                {
                    if (Direct_y == 0)
                    {
                        direct_x = 0;
                        while (Direct_y == 0)
                            Direct_y = r.Next(-1, 2);
                    }
                }
                else //gorizontal movement
                {
                    if (Direct_x == 0)
                    {
                        direct_y = 0;
                        while (Direct_x == 0)
                            Direct_x = r.Next(-1, 2);
                    }
                }
            PutImg();
            }
        public void Transparent()
        {
            
            if (x == -1)
                x = sizeField - 21;
            if (x == sizeField - 19)
                x = 1;
            if (y == -1)
                y = sizeField - 21;
            if (y == sizeField - 19)
                y = 1;
        }
        public void Run()
        {
             
            x += direct_x;
            y += direct_y;
            if (Math.IEEERemainder(x, 40) == 0 && Math.IEEERemainder(y, 40) == 0)
                Turn();

            PutCurrentImage();



            Transparent();
        }
        public void TurnAround()
        {
            Direct_x = -1 * Direct_x;
            Direct_y = -1 * Direct_y;
            PutImg();
        }
        public Image CurrentImg
        {
            get { return currentImg; }
        }
        public Tank(int sizeField, int x, int y)
        {
            r = new Random();
            this.sizeField = sizeField;

            if (r.Next(5000) < 2500)
            {
                Direct_y = 0;
            loop:
                Direct_x = r.Next(-1, 2);
                if (Direct_x == 0)
                    goto loop;
            }
            else
            {
                Direct_x = 0;
            loop:
                Direct_y = r.Next(-1, 2);
                if (Direct_y == 0)
                    goto loop;
            }

            PutImg();

            PutCurrentImage();

            this.x = x;
            this.y = y;

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
        public int Direct_x
        {
            get
            {
                return direct_x;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_x = value;
                else direct_x = 0;
            }
        }
        public int Direct_y
        {
            get
            {
                return direct_y;
            }

            set
            {
                if (value == 0 || value == -1 || value == 1)
                    direct_y = value;
                else direct_y = 0;
            }
        }

    }
}
