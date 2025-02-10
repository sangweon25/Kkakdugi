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
        Player player1 = new Player("김치", "음식", 1, 100, 15, 1000);
        Attack_ attack = new Attack_();
        List<Item> itemList = new List<Item>
        {
            new Item(AbilityType.방어구,"무껍질",2,"무를 보호해주는 껍질이다.",500),
            new Item(AbilityType.방어구,"나무판자",4,"나무 판자안에 무는 더욱 안전해보인다.",1000),
            new Item(AbilityType.무기,"나뭇가지",2,"흔해빠진 나뭇가지다.",500),
            new Item(AbilityType.무기,"돌칼",4,"약간은 날카로운 돌이다.",1000),
        };

        List<Monster> monsters;

        // 내 정보 받아오기
        // 테스트 용으로 모든 값을 임의로 집어넣었습니다 !
        Player player = new Player("손효정", "직업 없음", 1, 100, 10, 1000);

        public SceneManager() 
        {
            // 몬스터 정보 출력    

            monsters = new List<Monster>
            {
                new Monster("몬스터1",2,15,5,false),
                new Monster("몬스터2",3,10,9,false),
                new Monster("몬스터3",5,25,8,false),
            };
        }

        public void MonsterPrintInfo()
        {
            Console.WriteLine("Battle!!");
            Random random = new Random();
            List<Monster> monsters = new List<Monster>
            {
                new Monster("솔트", 1, 10, 3,false),
                new Monster("슈가", 2, 10, 5,false),
                new Monster("다이콘", 3, 15, 10,false),
                new Monster("레드파우더", 5, 25, 15,false)
            };

            List<Monster> randmonsters = new List<Monster>();

            int rand = random.Next(1, monsters.Count + 1);

            for (int i = 0; i < rand; i++)
            {
                int monsterIndex = random.Next(monsters.Count); // 0~3번까지의 인덱스 랜덤선택
                randmonsters.Add(monsters[monsterIndex]); // 랜덤 인덱스를 랜덤으로 생겨난 몬스터 리스트에 저장
            }
            foreach (Monster m in randmonsters)
            {
                m.MonsterState(m);
            }
            //플레이어 간단한 정보와 체력 출력
            player.PrintPlayer();

            Console.WriteLine();
            Console.WriteLine("1. 공격");
            Console.WriteLine();
            if (InputManager.GetInput(1, 1) == 1)
            {
                Console.Clear();
                //AttackInfo(randmonsters);
                AttackStart(randmonsters, player); //효정 추가
            }
        }//MonsterPrintInfo Method

        static void AttackStart(List<Monster> monster, Player player)
        {
            // 기본 화면 구성해보기 (우선 예제와 똑같이 했습니다)
            Console.WriteLine("Battle!!");
            Console.WriteLine(); // 한 줄 공백

            // 반복문 이용해서 리스트 출력
            for (int i = 0; i < monster.Count; i++)
            {
                if (monster[i].isDead == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{i + 1}. Lv.{monster[i].Lev} {monster[i].Name} HP dead");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{i + 1}. Lv.{monster[i].Lev} {monster[i].Name} HP {monster[i].Hp}");
                }

            }

            Console.WriteLine();


            Console.WriteLine("[내정보]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Lv} {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.Hp}/100");
            Console.WriteLine();
            Console.WriteLine("0. 취소");
            Console.WriteLine();
            Console.WriteLine("대상을 선택해주세요.");
            Console.Write(">>");

            //input 값 받아서 그에 맞는 조건문 넣기
            string Input = Console.ReadLine();
            int num = int.Parse(Input);

            //번호 확인 
            if (num == 0)
            {
                Console.WriteLine("전투 취소");
                //이전 화면으로 돌아가기 (?)
            }
            else if (num > 0 && num <= monster.Count + 1)
            {
                if (monster[num - 1].isDead == false) //안 죽었을 때
                {
                    Console.WriteLine($"선택한 몬스터는 {monster[num - 1]}");
                    //공격
                    Attack_.Attack(monster[num - 1], player);
                }
                else // 죽었다면?
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

            }
            else // 0도 아니고 몬스터 카운트보다 작은 숫자도 아닐 때 
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    
    public void AttackInfo(List<Monster> monster) // 공격 할 때 출력 할 창
    {
        // 기본 화면 구성해보기 (우선 예제와 똑같이 했습니다)
        Console.WriteLine("Battle!!");
        Console.WriteLine(); // 한 줄 공백

        // 반복문 이용해서 리스트 출력
        for (int i = 0; i < monster.Count; i++)
        {
            if (monster[i].isDead == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{i + 1}. Lv.{monster[i].Lev} {monster[i].Name} HP dead");
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine($"{i + 1}. Lv.{monster[i].Lev} {monster[i].Name} HP {monster[i].Hp}");
            }

        }

        Console.WriteLine();

        Console.WriteLine("[내정보]");
        Console.WriteLine();
        Console.WriteLine($"Lv.{player.Lv} {player.Name} ({player.Job})");
        Console.WriteLine($"HP {player.Hp}/100");
        Console.WriteLine();
        Console.WriteLine("0. 취소");
        Console.WriteLine();
        Console.WriteLine("대상을 선택해주세요.");
        Console.Write(">>");

        //input 값 받아서 그에 맞는 조건문 넣기

    }

    //매개변수로 들어온 몬스터가 공격 
    public void EnemyPhase(Monster monster, Player player)
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
        for (int i = 0; i < itemList.Count; i++)
        {
            itemList[i].PrintItems();
        }

    }

    //아이템 상점에 출력될 문자열 간격을 맞춰주는 함수
    public void SortingString()
    {
        Console.WriteLine("{0,-15}| {1,-15}| {2,-15}| {3,-15}| {4,-15}|", "분류", "이름", "능력치", "설명", "가격");
    }

    }//class SceneManager
}//namespace
