using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

namespace Kkakdugi
{
    public class Result // ()매개변수 안에다가 이미 정의된 플레이어와 몬스터함수를 가져오고 밑에 변수 고치기
    {
        public Player  // 플레이어와 몬스터를 다른방법으,로 가져오기
        {
            Player player = new Player("깍두기","무", 1, 100, 10, 1000);
            Monster monster = new Monster(" ", 1, 10, 11, false);
            public void Player(string name, int lv, int maxHp)
            {
                player.Name = name;
            player.Lv = lv;
            player.Hp = maxHp;
            }
        }

        public static void BattleEnd(string name, int lv, int maxHp, int atk)
        {
            int monster = 4;
            int killCount = 0;

            while (maxHp > 0 && monster > 0)
            {

                maxHp -= atk;
                monster--;
                killCount++;

                Console.WriteLine("Battle!! - Result");

                if (maxHp > 0 && monster <= 0) // 플레이어가 살아 있고, 모든 몬스터를 잡았을 때 승리
                {
                    Console.WriteLine("Victory");
                    Console.WriteLine($"던전에서 몬스터 {killCount}를 잡았습니다.");
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