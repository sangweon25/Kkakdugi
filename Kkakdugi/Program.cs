namespace Kkakdugi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerHP = 100;
            int monster = 3;
            Random random = new Random();

            while (playerHP > 0 && monster > 0)
            {
                int damage = random.Next(10);
                playerHP -= damage;
                monster--;

                Console.WriteLine("Battle!! - Result");

                if(playerHP > 0 && monster == 0)
                {
                    Console.WriteLine("Victory");
                    break;
                }
                else if (monster > 0 && playerHP == 0)
                {
                    Console.WriteLine("You Lose");
                    break;
                }

            }
        }
    }
}
