using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tanks
{
    delegate void Invoker();
    public partial class Controller_MainForm : Form
    {
        View view;
        Model model;
        bool isSound;
        Thread modelPlay;

        public Controller_MainForm() : this(260) { }
        public Controller_MainForm(int sizeField) : this(sizeField, 5) { }
        public Controller_MainForm(int sizeField, int amountTanks) : this(sizeField, amountTanks, 5) { }
        public Controller_MainForm(int sizeField, int amountTanks, int amountApples) : this(sizeField, amountTanks, amountApples, 10) { }    
        public Controller_MainForm(int sizeField, int amountTanks, int amountApples, int SpeedGame)
        {
            InitializeComponent();
            
            model = new Model(sizeField, amountTanks, amountApples, SpeedGame);
            model.changeStreep += new STREEP(ChangerStatusStrip);
            view = new View(model);
            this.Controls.Add(view);

            isSound = true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (model.gameStatus == GameStatus.playing)
            {
                modelPlay.Abort();
                model.gameStatus = GameStatus.stopping;
                StartStop_pictureBox.Image = Properties.Resources.PlayButton;
            }
            else
            {
                StartStop_pictureBox.Focus();
                model.gameStatus = GameStatus.playing;
                modelPlay = new Thread(model.Play);
                modelPlay.Start();
                StartStop_pictureBox.Image = Properties.Resources.PauseButton;
                ChangerStatusStrip();
                ChangerStatusStrip();
                view.Invalidate();
            }
        }
        private void Controller_MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modelPlay != null)
            {
                model.gameStatus = GameStatus.stopping;
                modelPlay.Abort();
            }

            DialogResult dr = MessageBox.Show("Game closing","Tanks",MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
        private void StartPause_pictureBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                case "A":
                    {
                        model.Packman.NextDirect_x = -1;
                        model.Packman.NextDirect_y = 0;
                    }
                    break;

                case "D":

                    {
                        model.Packman.NextDirect_x = 1;
                        model.Packman.NextDirect_y = 0;
                    }
                    break;

                case "W":
                    {
                        model.Packman.NextDirect_x = 0;
                        model.Packman.NextDirect_y = -1;
                    }
                    break;

                case "S":
                    {
                        model.Packman.NextDirect_x = 0;
                        model.Packman.NextDirect_y = 1;
                    }
                    break;
                case "Space":
                    {
                        model.Projectile.X = model.Packman.X;
                        model.Projectile.Y = model.Packman.Y;
                        model.Projectile.Direct_x = model.Packman.Direct_x;
                        model.Projectile.Direct_y = model.Packman.Direct_y;
                    }
                    break;
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            model.NewGame();
            StartStop_pictureBox.Image = Properties.Resources.PlayButton;
            view.Refresh();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"            A = Left
            S = Down
            D = Right
            W = Up
            Space = Fire");
        }
        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isSound = !isSound;
        }

        void ChangerStatusStrip()
        {
            Invoke(new Invoker(SetValueToStrip));       
        }
        void SetValueToStrip()
        {
            GameStatus_Strip.Text = model.gameStatus.ToString();
        }
    }
}
