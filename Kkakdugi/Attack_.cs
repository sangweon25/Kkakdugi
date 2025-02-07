using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    internal class Attack_
    {
        
        /*
        public class Monster //임의로 만든 플레이어 클래스 입니다. 
        {
            public string Name { get; set; }
            public int Lev { get; set; }
            public int Hp { get; set; }
            public int Atk { get; set; }
            //내가 필요해서 추가한 사항 (효정)
            public bool isDead { get; set; }

            public Monster(string name, int lev, int hp, int atk, bool dead)
            {
                Name = name;
                Lev = lev;
                Hp = hp;
                Atk = atk;
                isDead = dead; //추가 했습니다.

            }
        }

        public class Player //임의로 만든 플레이어 클래스 입니다. 
        {
            public int Lev { get; set; }
            public string Name { get; set; }
            public string Job { get; set; }
            public int Hp { get; set; }
            public int Atk { get; set; }
            //방어력 같은 세부 옵션이 있지만 일단 최소 정보만 적어놨습니다.

            public Player(string name, int lev, int hp, int atk, string job)
            {
                Name = name;
                Lev = lev;
                Hp = hp;
                Atk = atk;
                Job = job;
            }
        }
        */

        public static void Attack(Monster monster, Player player)
        {
            // 호출이 됐으면 해당하는 몬스터를 공격
            // 몬스터 체력 -= 플레이어 공격력

            //오차 구현
            //공격력의 10% 계산 
            double AttackMultiple = player.Atk * 0.1;

            //소수점은 올림처리하기
            int CellingNum = (int)Math.Ceiling(AttackMultiple);

            //랜덤 추출 
            Random rand = new Random();
            int randomDamage = rand.Next(- CellingNum, CellingNum + 1); //최대, 최소값 생성해서 그 중에 랜덤으로 선택 

            //최종 데미지 저장
            int FinalAtk = player.Atk + randomDamage;

            monster.Hp -= FinalAtk;

            //테스트 출력 CellingNum등 다른 변수 값을 알아보기 위해 잠시 적어뒀습니다.
            //Console.WriteLine($"테스트 : {CellingNum},{randomDamage},{FinalAtk}");

            //만약 몬스터의 hp가 0 이하라면?
            if (monster.Hp <= 0)
            {
                monster.isDead = true;
            }

            //공격 후 결과화면 출력 창 이동
            AttackResult(monster, player, FinalAtk);

        }

        public static void AttackResult(Monster monster, Player player, int FinalAtk)
        {
            Console.Clear();
            Console.WriteLine("Battle!!");
            Console.WriteLine();
            Console.WriteLine($"{player.Name}의 공격!");
            Console.WriteLine($"Lv.{monster.Lev} {monster.Name}을(를) 맞췄습니다. [데미지 : {FinalAtk}]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{monster.Lev} {monster.Name}");

            // 몬스터 출력 여부 다르게 하기
            if (monster.Hp <= 0)
            {
                Console.WriteLine($"HP {monster.Hp + FinalAtk} -> [Dead]");
            }
            else
            {
                Console.WriteLine($"HP {monster.Hp + FinalAtk} -> {monster.Hp}");
            }

            Console.WriteLine();
            Console.WriteLine("0. 다음");

            string Input = Console.ReadLine();
            int num = int.Parse(Input);

            if (num == 0)
            {
                //Enemy Phase로 넘어가기
                Console.WriteLine("Enemy Phase 시작");
            }
        }

        /*
        static void Main(string[] args)
        {
            // 리스트로 테스트 몬스터 만들기
            List<Monster> monster = new()
        {
            new Monster("미니언", 2, 15, 6, false),
            new Monster("대포미니언", 5, 25, 10, false),
            new Monster("공허충", 3, 0, 8, true)
        };

            //리스트 번호 받아오기

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
            // 내 정보 받아오기
            Player player = new Player("손효정", 1, 100, 10, "전사");
            // 테스트 용으로 모든 값을 임의로 집어넣었습니다 !

            Console.WriteLine("[내정보]");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Lev} {player.Name} ({player.Job})");
            Console.WriteLine($"HP {player.Hp}/100");
            Console.WriteLine();
            Console.WriteLine("0. 취소");
            Console.WriteLine();
            Console.WriteLine("대상을 선택해주세요.");
            Console.Write(">>");

            //input 값 받아서 그에 맞는 조건문 넣기
            string Input = Console.ReadLine();
            int num = int.Parse(Input);
            //임시 코드
            Console.WriteLine($"입력 값은 {Input}입니다.");

            //공격 관련 동작 코드 구상
            //번호 확인 (그에 맞는 번호를 눌렀는가)
            if (num == 0)
            {
                Console.WriteLine("전투 취소");
                //이전 화면으로 돌아가기 (?)
            }
            else if (num > 0 && num <= monster.Count)
            {
                if (monster[num].isDead == false) //안 죽었을 때
                {
                    Console.WriteLine($"선택한 몬스터는 {num}");
                    Attack(monster[num - 1], player);
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
        */
    }
}

