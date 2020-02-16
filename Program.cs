using System;
using System.Threading;
using static System.Console;

namespace Asg9
{
    class Program
    {
        static void Main(string[] args)
        {

            Player player1 = new Player();
            player1.PlayerName = "Mona";
            //player1.PlayerHealth = -1;
           // player1.PlayerHealth = 100;
            WriteLine("{0} health: {1}", player1.PlayerName, player1.PlayerHealth);

            Player player2 = new Player("Dave");
            WriteLine("{0} health: {1}", player2.PlayerName, player2.PlayerHealth);
            //player2.PlayerHealth = 100;

            void PrintHealth()
            {
                WriteLine("{0} health: {1}", player1.PlayerName, player1.PlayerHealth);
                WriteLine("{0} health: {1}", player2.PlayerName, player2.PlayerHealth);
            }

            do
            {
                Thread.Sleep(3000);

                WriteLine("\n{0} is attacking {1}", player1.PlayerName, player2.PlayerName);
                player1.AttackDave(player2);

                if (player2.PlayerHealth == 0)
                {
                    WriteLine("{0} won! ", player1.PlayerName);
                    break;
                }

                PrintHealth();

                Thread.Sleep(3000);


                WriteLine("\n{0} is attacking {1}", player2.PlayerName, player1.PlayerName);
                player2.AttackMona(player1);

                if (player1.PlayerHealth == 0)
                {
                    WriteLine("{0} won!", player2.PlayerName);
                    break;
                }

                PrintHealth();
            } while (player1.PlayerHealth > 0 || player2.PlayerHealth > 0);

            WriteLine("game over");
            WriteLine("{0} health: {1} {2} health: {3} ", player1.PlayerName, player1.PlayerHealth, player2.PlayerName, player2.PlayerHealth);






        }


    } // end class program


    class Player
    {
        public Player(String name)
        {
            this.PlayerName = name;
            this.playerHealth = 100;
        }
        public Player()
        {
            this.playerHealth = 100;
        }
        private int playerHealth;// = 100;
        public String PlayerName { get; set; }

        bool life = true;
        public int PlayerHealth
        {

            get
            {
                return playerHealth;
            }
            set
            {
                if (value > 0 && value < 100)
                {
                    playerHealth = value;
                }
                else if (value <= 0)
                {
                    playerHealth = 0;
                    //WriteLine("health can not be less than 0 or over 100");
                    // throw new Exception("health must be between 0 and 100");
                }
                else
                {
                    WriteLine("health can not be less than 0 or over 100");

                }
            }
        } // end PlayerHealth

        public void AttackDave(Player player)
        {
            Random attackPlayer = new Random();
            int attackPoints = attackPlayer.Next(25);

            Random attackStyle = new Random();
            int attacks = attackStyle.Next(3);

            if (attackPoints < 15)
            {
                if (attacks == 0)
                {
                    WriteLine("\n -- Mona called the cops on Dave!");
                }
                if (attacks == 1)
                {
                    WriteLine("\n -- Mona hot waxed Dave's legs!");
                }
                if (attacks == 2)
                {
                    WriteLine("\n -- Mona stole Dave's rent money!");
                }
                player.PlayerHealth -= attackPoints;

            }
            else
            {
                WriteLine("\n --attack failed");
            }
        }

        public void AttackMona(Player player)
        {
            Random attackPlayer = new Random();
            int attackPoints = attackPlayer.Next(25);

            Random attackStyle = new Random();
            int attacks = attackStyle.Next(3);

            if (attackPoints < 15)
            {
                if (attacks == 0)
                {
                    WriteLine("\n -- Dave cut the power and scared Mona with a weapon!");
                }
                if (attacks == 1)
                {
                    WriteLine("\n -- Dave lit a newport and made mona smoke it through her nose!");
                }
                if (attacks == 2)
                {
                    WriteLine("\n -- Dave stole Mona's DVDs");
                }
                player.PlayerHealth -= attackPoints;

            }
            else
            {
                WriteLine("\n --attack failed");
            }
        }





    } // end class Player
} // end namespace