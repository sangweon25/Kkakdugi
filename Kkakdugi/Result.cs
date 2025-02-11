using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kkakdugi
{
    internal class Result
    {
        internal class Player
        {
            //플레이어 능력치, 세부정보
            public string Name { get; set; }
            public int Lv { get; set; }
            public int Hp { get; set; }
            public int MaxHp { get; set; }

            public Player(string name, int lv, int maxHp)
            {
                Name = name;
                Lv = lv;
                Hp = maxHp;
            }
        }

        public class Monster
        {
            // 몬스터의 공격력 
            public int Atk { get; set; }

            // 생성자로 몬스터 속성 초기화
            public Monster(int atk)
            {
                Atk = atk;
            }
        }
        public static void Result1(string name, int lv, int maxHp, int atk)
        {
            int monster = 4;

            while (maxHp > 0 && monster > 0)
            {

                maxHp -= atk;
                monster--;

                Console.WriteLine("Battle!! - Result");

                if (maxHp > 0 && monster <= 0) // 플레이어가 살아 있고, 모든 몬스터를 잡았을 때 승리
                {
                    Console.WriteLine("Victory");
                    Console.WriteLine("던전에서 몬스터 3마리를 잡았습니다.");
                    Console.WriteLine($"Lv.{lv} {name}\nHp 100 -> {maxHp}");
                    break;
                }
                else if (monster > 0 && maxHp <= 0) // 플레이어 체력이 0 이하 일때, 몬스터가 아직 남아있으면 패배
                {
                    Console.WriteLine("You Lose");
                    Console.WriteLine($"Lv.{lv} {name}\nHp 100 -> {maxHp}");
                    break;
                } // 플레이어가 죽거나, 몬스터를 모두 처치하면 break;에 의해 반복문 종료.

            }
            Console.WriteLine("0. 다음");
            Console.Write(">>");
            Console.ReadLine();
            int intput = InputManager.GetInput(0, 0);

            if (intput == 0)
            {
                // 게임 종료시 메인화면
                SceneManager.GetInstance().MainScene();
            }

        }


    }
}