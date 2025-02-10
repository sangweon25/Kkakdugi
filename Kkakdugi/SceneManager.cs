using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    internal class SceneManager
    {
        Player player = new Player("김치", "음식", 1, 100, 15, 1000);
        Attack_ attack = new Attack_();
        List<Item> itemList = new List<Item>
        {
            new Item(AbilityType.방어구,"무껍질",2,"무를 보호해주는 껍질이다.",500),
            new Item(AbilityType.방어구,"나무판자",4,"나무 판자안에 무는 더욱 안전해보인다.",1000),
            new Item(AbilityType.무기,"나뭇가지",2,"흔해빠진 나뭇가지다.",500),
            new Item(AbilityType.무기,"돌칼",4,"약간은 날카로운 돌이다.",1000),
        };

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

            player.PrintPlayer();

            Console.WriteLine();
            Console.WriteLine("1. 공격");
            Console.WriteLine();
            if(InputManager.GetInput(1,1) == 1)
            {
                Console.Clear();
                //현재 AttackInfo내에 player객체를 넘겨줘서 사용해야함.
                attack.AttackInfo(randmonsters);
            }
        }//MonsterPrintInfo Method

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

        }//EnemyPhase Method

        //===============================상점===============================

        public void StoreScene()
        {
            Console.WriteLine("Store");

            Console.WriteLine("[아이템 목록]");
            Console.WriteLine();
            //Console.WriteLine("|분류\t|이름\t\t|능력치\t|설명\t\t\t|가격|");
            SortingString();
            Console.WriteLine("===================================================================");
            for(int i =0; i < itemList.Count; i++)
            {
                itemList[i].PrintItems();
            }

        }

        //아이템 상점에 출력될 문자열 간격을 맞춰주는 함수
        public void SortingString()
        {
            Console.WriteLine("{0,-15}| {1,-15}| {2,-15}| {3,-15}| {4,-15}|", "분류","이름","능력치","설명","가격");
        }
    }//class SceneManager
}//namespace
