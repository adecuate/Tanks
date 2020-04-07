using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class HunterImg
    {
        Image[] up = new Image[] { Properties.Resources.HunterImg0_1,
            Properties.Resources.HunterImg0_11,
            Properties.Resources.HunterImg0_12,
            Properties.Resources.HunterImg0_13,
            Properties.Resources.HunterImg0_14};
        Image[] down = new Image[] { Properties.Resources.HunterImg_01,
            Properties.Resources.HunterImg_011,
            Properties.Resources.HunterImg_012,
            Properties.Resources.HunterImg_013,
            Properties.Resources.HunterImg_014};
        Image[] right = new Image[] { Properties.Resources.HunterImg10,
            Properties.Resources.HunterImg101,
            Properties.Resources.HunterImg102,
            Properties.Resources.HunterImg103,
            Properties.Resources.HunterImg104};
        Image[] left = new Image[] { Properties.Resources.HunterImg_10,
            Properties.Resources.HunterImg_101,
            Properties.Resources.HunterImg_102,
            Properties.Resources.HunterImg_103,
            Properties.Resources.HunterImg_104};
    

        public Image[] Up
        {
            get
            {
                return up;
            }

        }

        public Image[] Down
        {
            get
            {
                return down;
            }

        }

        public Image[] Right
        {
            get
            {
                return right;
            }

        }

        public Image[] Left
        {
            get
            {
                return left;
            }

        }   
    };
}
