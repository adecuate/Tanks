using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class FireTankImg
    {
        Image[] Img = new Image[]
        {
            Properties.Resources.FireTankImg1,
            Properties.Resources.FireTankImg2,
            Properties.Resources.FireTankImg3,
            Properties.Resources.FireTankImg4,
            Properties.Resources.FireTankImg5
        };

        public Image[] Img1
        {
            get
            {
                return Img;
            }

        }
    }
}
