using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Snakegame
{
    class Program
    {

        public bool isgameover=false;
        public enum dic {U,D,R,L };
        dic direct;
        public int H = 20;
        public int W = 20;

        public int x, y;

        public int xF, yF;
        public int score=0;

        public int []listchildx=new int[100];
        public int[] listchildy = new int[100];
        public int tail;
        public int prex, prey;
        public int prex2, prey2;

        public void setup()
        {
            Random r = new Random();
            xF = r.Next(1, W - 2);
            yF = r.Next(1, H - 2);

            x = r.Next(1, W - 2);
            y = r.Next(1, H - 2);

        }

        public void spawnFruit()
        {
            Random r = new Random();
            xF = r.Next(1, W - 2);
            yF = r.Next(1, H - 2);
        }

        public void logicgame()
        {
            prex = listchildx[0];
            prey = listchildy[0];
            listchildx[0] = x;
            listchildy[0] = y;
            for(int i=1;i<tail;i++)
            {
                prex2 = listchildx[i];
                prey2 = listchildy[i];
                listchildx[i] = prex;
                listchildy[i] = prey;
                prex = prex2;
                prey = prey2;
            }
            //for (int i= 0; i < listchildx.Length;i++)
            //{

            //}
            //for (int j = 0; j < listchildy.Length; j++)
            //{

            //}
            

            switch (direct)
            {
                case dic.U: { y--; break; }
                case dic.D: { y++; break; }
                case dic.L: { x--; break; }
                case dic.R: { x++; break; }
            }
            if((x<=0||x>=W||y<=0||y>=H-1))
            {
                isgameover = true;
            }
            for(int j=0;j<tail;j++)
            {
                if (x ==listchildx[j]&&y==listchildy[j])
                {
                    isgameover = true;
                }
            }
           
        }

        public void input()
        {
            char a = Console.ReadKey().KeyChar;
           switch (a)
            {
                case 'w': { direct = dic.U; break; }
                case 'a': { direct = dic.L; break; }
                case 'd': { direct = dic.R; break; }
                case 's': { direct = dic.D; break; }
            }
        }
        public void draw()
        {
            for(int i=0;i<H;i++)
            {
                for (int j = 0; j < W; j++)
                {
                    if (i == 0)
                    {
                        Console.Write("#");
                        if (j == W - 1) Console.WriteLine();
                    }

                    if(i>0&&i<H-1)
                    {

                        if (j == 0 || j == W - 1)
                        {
                            Console.Write("#");
                        }
                        else
                        {

                            if (i == yF && j == xF)
                            {
                                if (xF == x && yF == y)
                                {
                                    Console.Write("0");
                                    score++;
                                    tail++;
                                    spawnFruit();
                                }
                                else
                                    Console.Write("@");
                            }

                            else if (i == y && j == x)
                            {
                                Console.Write("0");
                                if (i == prex && j == prey)
                                {
                                   // Console.Write("0");
                                }
                            }

                            else
                            {

                                for(int k=0;k<tail;k++)
                                {
                                    if(j==listchildx[k]&&i==listchildy[k])
                                    {
                                        Console.Write("0");
                                    }
                                }

                                Console.Write(" ");
                            }

                            

                        }

                        if (j == W - 1) Console.WriteLine();

                    }
                   

                    if (i == H - 1)
                    {
                        Console.Write("#");
                    }

                   
                    //Console.WriteLine();
                }
            }
        }

        public void addtail()
        {

        }
        
        public void update()
        {
            setup();
            while(isgameover==false)
            {
               
                Console.Clear();
                draw();
                Console.WriteLine("Score: " + score);
                Console.WriteLine("D: " + direct);
                Console.WriteLine("X: " + x+" Y: "+y);
                Console.WriteLine("preX: " + prex + " preY: " + prey);
                Console.WriteLine("H: " + H + " W: " + W);
                input();
                logicgame();
                //Console.Clear();
                Thread.Sleep(20);
                Console.ReadKey();

            }
        }

        static void Main(string[] args)
        {
            Program a = new Program();
            a.update();
        }
    }
}
