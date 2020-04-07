using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Tanks
{
    class TankImg
    {
        Image[] up = new Image[] { Properties.Resources.Tank0_11,
            Properties.Resources.Tank0_1I1,
            Properties.Resources.Tank0_1II1,
            Properties.Resources.Tank0_1III1,
            Properties.Resources.Tank0_1IV1};
        Image[] down = new Image[] { Properties.Resources.Tank_01,
            Properties.Resources.Tank_01I,
            Properties.Resources.Tank_01II,
            Properties.Resources.Tank_01III,
            Properties.Resources.Tank_01IV};
        Image[] right = new Image[] { Properties.Resources.Tank10,
            Properties.Resources.Tank101,
            Properties.Resources.Tank102,
            Properties.Resources.Tank103,
            Properties.Resources.Tank104};
        Image[] left = new Image[] { Properties.Resources.Tank_10,
            Properties.Resources.Tank_101,
            Properties.Resources.Tank_102,
            Properties.Resources.Tank_103,
            Properties.Resources.Tank_104};

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
