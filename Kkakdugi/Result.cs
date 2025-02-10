using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kkakdugi
{

    internal class Result
    {
        public void Result1()
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
                else if (monster > 0 && playerHP <= 0)
                {
                    Console.WriteLine("You Lose");
                    Console.WriteLine($"Lv.1 Chad\nHp -> {playerHP}");
                    break;
                }

            }
            Console.WriteLine("0. 다음");
            Console.Write(">>");
            Console.ReadLine();
            //int intput = InputManager.GetInput(0, 0);

            //if (intput == 0)
            //{
            //    sceneManager.MainScene();
            //}
        }

    }
}