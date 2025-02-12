using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Xml.Linq;

namespace Kkakdugi
{
    public class Result 

    {
        //public void BattleEnd(string name, int lv, int maxHp, int atk)
        //{
        //    int monster = 4;
        //    int killCount = 0;

        //    Console.Clear();
        //    Console.WriteLine("Battle!! - Result");
        //    while (maxHp > 0 && monster > 0)
        //    {

        //        maxHp -= atk;
        //        monster--;
        //        killCount++;

        //        if (maxHp > 0 && monster <= 0) // 플레이어가 살아 있고, 모든 몬스터를 잡았을 때 승리
        //        {
        //            Console.WriteLine("Victory\n");
        //            Console.WriteLine($"던전에서 몬스터 {killCount}를 잡았습니다.\n");
        //            Console.WriteLine($"Lv.{lv} {name}\nHp 100 -> {maxHp}\n");
        //            break;
        //        }
        //        else if (monster > 0 && maxHp <= 0) // 플레이어 체력이 0 이하 일때, 몬스터가 아직 남아있으면 패배
        //        {
        //            Console.WriteLine("You Lose\n");
        //            Console.WriteLine($"Lv.{lv} {name}\nHp 100 -> {maxHp}\n");
        //            break;
        //        } // 플레이어가 죽거나, 몬스터를 모두 처치하면 break;에 의해 반복문 종료.

        //    }
        //    Console.WriteLine("0. 다음");
        //    Console.Write(">>");
        //    Console.ReadLine();
        //    int intput = InputManager.GetInput(0, 0);

        //    if (intput == 0)
        //    {
        //        // 게임 종료시 메인화면
        //        SceneManager.GetInstance().MainScene();
        //    }

        //}

    }
}