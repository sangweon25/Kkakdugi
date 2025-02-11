using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        public void MainScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 회복아이템");
            Console.WriteLine();
            // 출력.예외 포함..if
            //GetInput(switch문 케이스 범위만큼 입력)
            int input = InputManager.GetInput(1, 4);
            switch (input)
            {
                case 1:
                    //상태보기 창으로 이동
                    StatusScreen();
                    break;
                case 2:
                    //전투시작 창으로 이동
                    Console.Clear();
                    MonsterPrintInfo();
                    break;
                case 3:
                    Console.Clear();
                    StoreScene();
                    break;
                case 4:
                    Console.Clear();
                    PotionScene();
                    break;
            }
        }
        public void StatusScreen()
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();

            player.StatusDisplay();
            Console.WriteLine();
            Console.WriteLine("1");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int input = InputManager.GetInput(0,0);
            switch (input)
            {
                case 0:
                    //상태보기 창으로 이동
                    MainScene();
                    break;
            }
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
            Console.Clear();
            Console.WriteLine("Battle!!\n");
            Console.WriteLine($"{player} 을(를) 맞췄습니다. [데미지 :{monster.Atk}]");

            //if 플레이어가 Dead상태가 아니라면 공격하지 않는다.
            //플레이어 데미지 받는 함수는 플레이어 내부에 구현 예정
            Console.WriteLine($"Lv. {player.Lv} {player.Name}");
            Console.WriteLine($"HP {player.Hp} -> {player.RecieveDamage(monster.Atk)}\n");

            if(InputManager.inputNext() == 0)
            {
                Console.Clear();
                AttackStart(monsters,player);
            }

        }//EnemyPhase Method

        
        //=============================인벤토리=============================

        public void InventoryChoice()
        {
            Console.WriteLine("1. 장착 관리\n");
            Console.WriteLine("0. 나가기");
            int input = InputManager.GetInput(0, 1);
            
            switch (input)
            {
                case 0:
                    Console.Clear();
                    MainScene();
                    break;
                case 1:
                    Console.Clear();
                    break;
            }    
        }
        //==================================================================
        
        //===============================상점===============================

        public void StoreScene()
        {
            Console.WriteLine("Store");

            //아이템 목록 출력 함수 
            PrintStore();
            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기\n");
            int input = InputManager.GetInput(0, 2);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    StoreBuyScene();
                    break;
                case 2:
                    Console.Clear();
                    StoreSellScene();
                    break;
                default:
                    Console.Clear();
                    MainScene();
                    break;
            }
        }//StoreScene Method

        public void StoreBuyScene()
        {
            bool state = true;
            while (state)
            {
                Console.WriteLine("Store - Buy");
                PrintStore();
                Console.WriteLine("0. 나가기\n");
                int input = InputManager.GetInput(0, itemList.Count);
                if (0 < input && input <= itemList.Count)
                {
                    //구매완료라면
                    if (itemList[input - 1].IsSold == true)
                    {
                        Console.Clear();
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                    }
                    else
                    {
                        //구매하지 않았는데 보유금액이 충분하면
                        if (player.Gold >= itemList[input - 1].Gold)
                        {
                            player.BuyItem(itemList[input - 1].Gold);
                            //플레이어 인벤토리에 Add(itemList[input - 1]) 추가해야함.
                            itemList[input - 1].IsSold = true;
                            Console.Clear();
                            Console.WriteLine("구매를 완료했습니다.\n");
                        }
                        else // 보유금액이 부족
                        {
                            Console.Clear();
                            Console.WriteLine("Gold가 부족합니다.\n");
                        }
                    }
                }
                else if(input == 0)
                {
                    MainScene();
                }
            }
        }//StoreBuyScene Method

        public void StoreSellScene()
        {
            Console.WriteLine("Store - Sell");
            PrintStore();
            Console.WriteLine("0. 나가기\n");
            int input = InputManager.GetInput(0, 0);
            switch (input)
            {
                case 0:
                    Console.Clear();
                    MainScene();
                    break;
            }

        }//StoreSellScene Method

        public void PrintStore()
        {
            Console.WriteLine("\n[아이템 목록]");
            Console.WriteLine();
            //출력될 아이템 정보를 보여주는 행 역할 메서드
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

        // 회복 포션 사용
        public void PotionScene()
        {
            Console.WriteLine("회복");
            Console.WriteLine("포션을 사용하면 체력을 30 회복 할 수 있습니다. (남은 포션 : //3 )");

            Console.WriteLine("\n1. 사용하기");
            Console.WriteLine("0. 나가기\n");
            int input = InputManager.GetInput(0, 1);
            switch (input)
            {
                case 1:
                    Console.Clear();
                    StoreBuyScene();
                    break;

                default:
                    Console.Clear();
                    MainScene();
                    break;
            }
        }
    }//class SceneManager
}//namespace
