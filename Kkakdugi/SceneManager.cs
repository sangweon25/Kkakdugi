using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    internal class SceneManager
    {
        List<Monster> monsters;

        public SceneManager()
        {

            monsters = new List<Monster>
            {
                new Monster("몬스터1",2,15,5),
                new Monster("몬스터2",3,10,9),
                new Monster("몬스터3",5,25,8),
            };
        }

        // 몬스터 정보 출력
        public void MonsterPrintInfo()
        {
            Console.WriteLine("Battle!!");
            Random random = new Random();
            List<Monster> monsters = new List<Monster>
            {
                 new Monster("솔트", 1, 10, 3),
                 new Monster("슈가", 2, 10, 5),
                 new Monster("다이콘", 3, 15, 10),
                 new Monster("레드파우더", 5, 25, 15)
            };
            List<Monster> randmonsters = new List<Monster>();

            int rand = random.Next(1,monsters.Count+1);

            for (int i = 0; i < rand; i++)
            {
                int monsterIndex = random.Next(monsters.Count); // 0~3번까지의 인덱스 랜덤선택
                randmonsters.Add(monsters[monsterIndex]); // 랜덤 인덱스를 랜덤으로 생겨난 몬스터 리스트에 저장
            }
            foreach (Monster m in randmonsters)
            {
                m.MonsterState(m);
            }
        }
        //매개변수로 들어온 몬스터가 공격 
        public void EnemyPhase(Monster monster,Player player)
        {
            Console.WriteLine("Battle!!\n");
            Console.WriteLine($"{player} 을(를) 맞췄습니다. [데미지 :{monster.Atk}]");

            //if 플레이어가 Dead상태가 아니라면 공격하지 않는다.
            //플레이어 데미지 받는 함수는 플레이어 내부에 구현 예정
            Console.WriteLine($"Lv. {player.Lv} {player.Name}");
            Console.WriteLine($"HP {player.Hp} -> {player.RecieveDamage(monster.Atk)}\n");

            InputManager.inputNext();

        }
    }
}
