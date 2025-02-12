using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    internal class SceneManager
    {
        Player player = new Player("무", "전사", 1, 100, 10,5, 1500);
        Attack_ attack = new Attack_();
        Inventory_ inventory = new Inventory_();
        private static SceneManager? sceneManager;

        public List<Monster> randmonsters = new List<Monster>();

        public List<Monster> monsters = new List<Monster>
        {
            new Monster("솔트", 1, 10, 3,false),
            new Monster("슈가", 2, 10, 5,false),
            new Monster("다이콘", 3, 15, 10,false),
            new Monster("레드파우더", 5, 25, 15,false)
        };

        //GetInstance 메서드 호출시 싱글톤 객체인 sceneManager를 리턴
        //다른 클래스에서 sceneManager의 메서드를 호출할수있다.
        public static SceneManager GetInstance()
        {
            if (sceneManager == null)
            {
                sceneManager = new SceneManager();
            }
            return sceneManager;
        }
        //퀘스트 배열 생성
        List<Quest> quests = new List<Quest>()
        {
            new Quest("구매 퀘스트","상점에서 나뭇가지를 구매하세요","500골드"),
            new Quest("장착 퀘스트","구입한 나뭇가지를 장착하세요","300골드"),
            new Quest("처치 퀘스트","몬스터를 5마리 처치하세요.","무껍질",5)
        };

        //itemList 안에 넣고 싶은 아이템 초기화
        List<Item> itemList = new List<Item>
        {
            new Item(AbilityType.방어구,"무껍질",2,"무를 보호해주는 껍질이다.",500),
            new Item(AbilityType.방어구,"나무판자",4,"나무 판자안에 무는 더욱 안전해보인다.",1000),
            new Item(AbilityType.무기,"나뭇가지",2,"흔해빠진 나뭇가지다.",500),
            new Item(AbilityType.무기,"돌칼",4,"약간은 날카로운 돌이다.",1000),
        };

        public void SetRandomMonsters()
        {
            randmonsters.Clear();  // 기존 리스트를 초기화

            Random random = new Random();
            int rand = random.Next(1, monsters.Count + 1);  // 개수 최소 1부터 랜덤 설정

            for (int i = 0; i < rand; i++)
            {
                int monsterIndex = random.Next(monsters.Count);  // 몬스터 선택
                randmonsters.Add(monsters[monsterIndex].Clone());  // 새로운 몬스터 객체 추가
            }
        }

        public void EndBattle()
        {
            // 전투 끝났을 때 새로운 랜덤 몬스터 리스트로 설정
            SetRandomMonsters();
        }

        //게임 초기화면 메인 씬
        public void MainScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 전투 시작");
            Console.WriteLine("5. 퀘스트");
            Console.WriteLine();
            // 출력.예외 포함..if
            //GetInput(switch문 케이스 범위만큼 입력)
            
            
            int input = InputManager.GetInput(1, 5);
            switch (input)
            {
                case 1:
                    //상태보기 창으로 이동
                    StatusScreen();
                    break;
                case 2:
                    //인벤토리 창으로 이동
                    Console.Clear();
                    inventory.ItemprintInfo();
                    InventoryChoice();
                    break;
                case 3:
                    Console.Clear();
                    StoreScene();
                    break;
                case 4:
                    //전투시작 창으로 이동
                    Console.Clear();
                    MonsterPrintInfo();
                    break;
                case 5:
                    //퀘스트 창으로 이동
                    Console.Clear();
                    QuestSelectScene();
                    break;
            }
        }
        //상태보기 창
        public void StatusScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("상태 보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            //플레이어 데이터 값 출력 함수
            player.StatusDisplay();
            Console.WriteLine();
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
        //2.전투시작 입장시 화면
        public void MonsterPrintInfo()
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();

            SetRandomMonsters();

            // 'randmonsters'에 있는 몬스터 출력
            foreach (Monster m in randmonsters)
            {
                m.MonsterState(m);
            }

            // 플레이어 출력
            player.PrintPlayer();
            Console.WriteLine();

            Console.WriteLine("0. 전투 취소");
            Console.WriteLine("1. 공격");
            Console.WriteLine();

            int input = InputManager.GetInput(0, 1);
            if (input == 1)
            {
                Console.Clear();
                AttackStart(randmonsters, player);  // 기존 몬스터 리스트 사용
            }
            else
            {
                MainScene();
            }
        }//MonsterPrintInfo Method

        public void AttackStart(List<Monster> monster, Player player)
        {
            bool inBattle = true;
            player.BeforeHp = player.Hp;
            while(inBattle)
            {
                
                Console.WriteLine("Battle!!");
                Console.WriteLine(); 

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
                    MainScene();
                }
                else if (num > 0 && num <= monster.Count) 
                {
                    if (monster[num - 1].isDead == false) //안 죽었을 때
                    {
                        Console.WriteLine($"선택한 몬스터는 {monster[num - 1].Name}");
                        //공격
                        attack.Attack(monster[num - 1], player);
                    }
                    else // 죽었다면? 이미 죽은 몬스터 선택시
                    {
                        Console.Clear();
                        Console.WriteLine("잘못된 입력입니다.\n");
                    }

                }
                else // 0도 아니고 몬스터 카운트보다 작은 숫자도 아닐 때 
                {
                    Console.Clear();
                    Console.WriteLine("잘못된 입력입니다.\n");
                }

                if (monster.All(m => m.isDead)) //몬스터가 모두 죽었다면
                {
                    inBattle = false;
                    BattleEnd(player.Name, player.Lv, player.BeforeHp, player.Hp,  player.Atk);
                    EndBattle();  // 전투 종료 후 새로운 랜덤 몬스터 설정
                }
                
            }
        }
        public void BattleEnd(string name, int lv, int beforeHp, int Hp, int atk)
        {
            int killCount = randmonsters.Count(m => m.isDead);


            Console.Clear();
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine();

            if (player.Hp > 0 && killCount == randmonsters.Count)// 플레이어가 살아 있고, 몬스터를 다 잡았을 때
            {
                // AttackStart 에서 몬스터가 죽을때 카운터 올라가는 코드 추가
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Victory");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine($"던전에서 몬스터 {killCount}를 잡았습니다.\n");
                Console.WriteLine($"Lv.{lv} {name}\nHp {beforeHp} -> {player.Hp}\n");
            }

            else if (player.Hp <= 0) // 플레이어 체력이 0 이하 일때
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Lose\n");
                Console.ResetColor();
                Console.WriteLine($"Lv.{lv} {name}\nHp {beforeHp} -> 0\n");
            } // 플레이어가 죽거나, 몬스터를 모두 처치하면 종료.

            
            Console.WriteLine("0. 다음");
            Console.WriteLine();
            int intput = InputManager.GetInput(0, 0);

            if (intput == 0)
            {
                // 게임 종료시 메인화면
                SceneManager.GetInstance().MainScene();
            }

        }


        //매개변수로 들어온 몬스터가 공격 
        public void EnemyPhase(Monster monster, Player player)
        {
            //적이 죽지않고 hp가 0보다 클때 이쪽으로 와야함.
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Battle!!\n");
            Console.ResetColor();
            //몬스터 공격
            Console.WriteLine($"Lv.{monster.Lev} {monster.Name} 의 공격!");
            //플레이어 이름, 받은 데미지

            Console.Write($"{player.Name} 을(를) 맞췄습니다. [데미지 :");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{monster.Atk}");
            Console.ResetColor();
            Console.WriteLine("]\n");
            Console.WriteLine($"Lv. {player.Lv} {player.Name}");
            //플레이어 체력 감소
            Console.WriteLine($"HP {player.Hp} -> {player.RecieveDamage(monster.Atk)}\n");

            //0으로 다음 넘어가는 함수
            if(InputManager.InputNext() == 0)
            {
                Console.Clear();
                if(player.Hp > 0)
                {
                    //플레이어가 죽지 않았을때 플레이어의 차례로 넘어가야함.
                    //첫번째 매개변수 배열아니라 EnemyPhase에서 받은 monster넣어줘야하는데 AttackStart는 배열로 받아서 처리하기때문에
                    //안딘다.
                    //AttackStart(monsters, player);
                }
                else
                {
                    //만약 플레이어가 죽었다면 result화면으로 가야함.
                    BattleEnd(player.Name, player.Lv, player.BeforeHp, player.Hp, player.Atk);
                }
            }

        }//EnemyPhase Method

        
        //=============================인벤토리=============================

        public void InventoryChoice()
        {
            Console.WriteLine("\n\n1. 장착 관리\n");
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
                    EquipChoice();
                    break;
            }    
        }
        public void EquipChoice()
        {
            //Inventory_ inventory = new Inventory_();
            
            while (true)
            {
                inventory.ItemprintInfo();
                Console.WriteLine("\n\n0. 나가기");

                // 인벤토리의 보유한 아이템 리스트 수만큼 입력받기
                int input = InputManager.GetInput(0, inventory.getitems.Count);
                
                inventory.ToggleEquipItem(input - 1,player); // 인덱스 번호 - 1을 하면 선택한 번호의 아이템 착용
                Console.Clear(); 
                if (input == 0)
                {
                    Console.Clear();
                    MainScene();
                }

            }
        }

        //==================================================================

        //===============================상점===============================

        public void StoreScene()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("상점");
            Console.ResetColor();

            //아이템 목록 출력 함수 
            PrintStore(false);
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
            bool buyScene = true;
            while (state)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("상점 - 구매");
                Console.ResetColor();
                PrintStore(buyScene);
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
                            inventory.AddItem(itemList[input-1]);
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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("상점 - 판매");
            Console.ResetColor();
            PrintStore(true);
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

        public void PrintStore(bool buyScene)
        {
            Console.WriteLine("\n[아이템 목록]");
            Console.WriteLine();
            //출력될 아이템 정보를 보여주는 행 역할 메서드
            SortingString();
            Console.WriteLine("===================================================================");
            for (int i = 0; i < itemList.Count; i++)
            {
                if (buyScene == true)
                    Console.Write($"{i+1}.");
                itemList[i].PrintItems();
            }
        }

        //아이템 상점에 출력될 문자열 간격을 맞춰주는 함수
        public void SortingString()
        {
            Console.WriteLine("{0,-15}| {1,-15}| {2,-15}| {3,-15}| {4,-15}|", "분류", "이름", "능력치", "설명", "가격");
        }
        //==================================================================

        //===============================퀘스트===============================
        public void QuestSelectScene()
        {
            
            Console.WriteLine("Quest!!\n");
            //퀘스트 배열을 출력

            //퀘스트 배열 이름만출력
            for (int i = 0; i < quests.Count; i++)
            {
                Console.Write($"{i+1}. ");
                Console.Write(quests[i].QuestName);
                //IsClear ==true일때 퀘스트완료 , 수락시 진행 중, 수락 안했으면 공백
                Console.WriteLine(quests[i].IsAccept ? "[진행 중]": quests[i].IsClear ? "[퀘스트 완료]" : " " ); 
            }
            Console.WriteLine("\n");
            Console.WriteLine("0. 나가기\n");
            int input = InputManager.GetInput(0, quests.Count);

            if (0 == input)
                MainScene();
            else
            {
                quests[input - 1].QuestAcceptScene();
            }
        }//QuestScene Method



    }//class SceneManager
}//namespace
