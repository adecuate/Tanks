using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tanks
{
    public delegate void STREEP();
    class Model
    {
        public event STREEP changeStreep;

        int collectedApples;
        int sizeField;
        int amountTanks;
        int amountApples;

        public int speedGame;
        public GameStatus gameStatus;

        Random r;
        Packman packman;
        Projectile projectile;
        List<Tank> tanks;
        List<FireTank> fireTank;

        public Wall wall;
        public List<Tank> Tanks
        {
            get
            {
                return tanks;
            }
        }
        public List<Apple> Apples
        {
            get
            {
                return apples;
            }
        }
        public Packman Packman
        {
            get
            {
                return packman;
            }
        }
        public Projectile Projectile
        {
            get
            {
                return projectile;
            }
        }
        public List<FireTank> FireTank
        {
            get
            {
                return fireTank;
            }
        }
        public List<Apple> apples;
        public Model(int sizeField, int amountTanks, int amountApples, int speedGame)
        {
            r = new Random();

     

            this.sizeField = sizeField;
            this.amountTanks = amountTanks;
            this.amountApples = amountApples;
            this.speedGame = speedGame;
            NewGame();
            
            
        }

        private void CreateApples()
        {
            int x, y;

            while (Apples.Count < amountApples)
            {
                x = r.Next(6) * 40;
                y = r.Next(6) * 40;

                bool flag = true;

                foreach (Apple a in Apples)
                {
                    if (a.X == x && a.Y == y)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    Apples.Add(new Apple(x, y));


            }

        }
        private void CreateTanks()
        {
            int x, y;
            
            while (tanks.Count < amountTanks+1)
            {

                if (tanks.Count == 0)
                    tanks.Add(new Hunter(sizeField, r.Next(6) * 40, r.Next(6) * 40));


                x = r.Next(6) * 40;
                y = r.Next(6) * 40;

                bool flag = true;

                foreach (Tank t in tanks)
                {
                    if (t.X == x && t.Y == y)
                    {
                        flag = false;
                        break;
                    }
                }
                    if (flag)
                            tanks.Add(new Tank(sizeField, x, y));

              
            } 
        }
        public void Play()
        {
            while (gameStatus == GameStatus.playing)
            {

                Thread.Sleep(speedGame);

                projectile.Run();
                packman.Run();
                // run for hunter
                ((Hunter)tanks[0]).Run(packman.X, packman.Y);

                for (int i=1; i<tanks.Count; i++)
                    tanks[i].Run();

                //burning tank

                foreach (FireTank ft in fireTank)
                    ft.Burn();

                for (int i = 1; i < tanks.Count; i++)
                    if (Math.Abs(tanks[i].X - projectile.X) < 11 && Math.Abs(tanks[i].Y - projectile.Y) < 11)
                    {
                        fireTank.Add(new FireTank(tanks[i].X, tanks[i].Y));
                        tanks.RemoveAt(i);
                        projectile.DefaultSettings();
                    }


                //tank+tank
                for (int i = 0; i < tanks.Count - 1; i++)
                    for (int j = i + 1; j < tanks.Count; j++)
                        if (
                                (Math.Abs(tanks[i].X - tanks[j].X) <= 20 &&  (tanks[i].Y == tanks[j].Y))
                            || 
                                (Math.Abs(tanks[i].Y - tanks[j].Y) <= 20 && (tanks[i].X == tanks[j].X))
                            ||
                                (Math.Abs(tanks[i].X - tanks[j].X) <= 20)  && (Math.Abs(tanks[i].Y - tanks[j].Y) <= 20)
                           )
                        {
                            if (i == 0)
                                ((Hunter)tanks[i]).TurnAround();
                            else
                                tanks[i].TurnAround();
                                tanks[j].TurnAround();
                        }
                // packman+tank
                for (int i = 0; i < tanks.Count; i++)
                    if (
                                (Math.Abs(tanks[i].X - packman.X) <= 20 && (tanks[i].Y == packman.Y))
                            ||
                                (Math.Abs(tanks[i].Y - packman.Y) <= 20 && (tanks[i].X == packman.X))
                            ||
                                (Math.Abs(tanks[i].X - packman.X) <= 20) && (Math.Abs(tanks[i].Y - packman.Y) <= 20)
                        )

                        gameStatus = GameStatus.loser;

                if (changeStreep != null)
                    changeStreep();

                //packman+apple
                for (int i = 0; i < apples.Count; i++)
                    if (Math.Abs(packman.X - apples[i].X) < 4 && Math.Abs(packman.Y - apples[i].Y) < 4)
                    {
                        apples[i] = new Apple(0+collectedApples*20, 260);
                        collectedApples++;
                    }

                if (collectedApples > 4)
                    gameStatus = GameStatus.winner;

                if (changeStreep != null)
                    changeStreep();

            }
        }      
        internal void NewGame()
        {
            collectedApples = 0;

            projectile = new Projectile();
            tanks = new List<Tank>();
            apples = new List<Apple>();
            packman = new Packman(sizeField);
            fireTank = new List<FireTank>();

            CreateTanks();
            CreateApples();

            wall = new Wall();

            gameStatus = GameStatus.stopping;

        }
    }
}
