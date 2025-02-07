using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    internal class SceneManager
    {
        List<StartBattle_.Monster> monsters;

        public SceneManager()
        {

            monsters = new List<StartBattle_.Monster>
            {
                new StartBattle_.Monster("몬스터1",2,15,5),
                new StartBattle_.Monster("몬스터2",3,10,9),
                new StartBattle_.Monster("몬스터3",5,25,8),
            };
        }


        //매개변수로 들어온 몬스터가 공격 
        public void EnemyPhase(StartBattle_.Monster monster)
        {
            Console.WriteLine("Battle!!\n");
            Console.WriteLine("Player을(를) 맞췄습니다. [데미지 :monsters.atk]");

            //if 플레이어가 Dead상태가 아니라면 공격하지 않는다.
            //플레이어 데미지 받는 함수는 플레이어 내부에 구현 예정
            Console.WriteLine("Lv. {player.Level} {player.Name}");
            Console.WriteLine("HP {player.Hp} -> player.Hp - monsters.atk\n");
            Console.WriteLine("0. 다음\n");

            Console.WriteLine("대상을 선택해주세요.");
            Console.Write(">>");
            Console.ReadLine();

        }
    }
}
