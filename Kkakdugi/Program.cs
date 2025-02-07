using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    static public class ConsoleUtility
    {
        static public int GetInput(int min, int max)
        {
            while (true)
            {
                Console.WriteLine("");
                if (int.TryParse(Console.ReadLine(), out int input) && (input >= min) && (input <= max))
                    return input;

                Console.WriteLine("잘못된 입력입니다. 다시 입력해 주세요");

                switch (input)
                {
                    case 0:
                        //GameStartScene
                        break;

                }
            }
        }
    }
    internal class Program
    {
        public void Result(string[] args)
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

                if (playerHP > 0 && monster == 0)
                {
                    Console.WriteLine("Victory");
                    Console.WriteLine("던전에서 몬스터 3마리를 잡았습니다.");
                    Console.WriteLine($"Lv.1 Chad\nHp -> {playerHP}");
                    break;
                }
                else if (monster > 0 && playerHP == 0)
                {
                    Console.WriteLine("You Lose");
                    Console.WriteLine($"Lv.1 Chad\nHp -> {playerHP}");
                    break;
                }

            }
            Console.WriteLine("0. 다음");
            Console.Write(">>");
            Console.ReadLine();
            int intput = ConsoleUtility.GetInput(0, 0);



        }

    }


}
