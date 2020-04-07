using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    class PackmanImg
    {
        Image[] up = new Image[] 
        {
            Properties.Resources.PackmanImg0_1,
            Properties.Resources.PackmanImg0_11,
            Properties.Resources.PackmanImg0_12,
            Properties.Resources.PackmanImg0_13,
            Properties.Resources.PackmanImg0_14
        };
        Image[] down = new Image[] 
        {
            Properties.Resources.PackmanImg_01,
            Properties.Resources.PackmanImg_011,
            Properties.Resources.PackmanImg_012,
            Properties.Resources.PackmanImg_013,
            Properties.Resources.PackmanImg_014
        };
        Image[] right = new Image[] 
        {
            Properties.Resources.Packman10,
            Properties.Resources.Packman101,
            Properties.Resources.Packman102,
            Properties.Resources.Packman103,
            Properties.Resources.Packman104
        };
        Image[] left = new Image[] 
        {
            Properties.Resources.PackmanImg_10,
            Properties.Resources.PackmanImg_101,
            Properties.Resources.PackmanImg_102,
            Properties.Resources.PackmanImg_103,
            Properties.Resources.PackmanImg_104
        };

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
    }
}
