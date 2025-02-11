using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Kkakdugi
{

    internal class Attack_
    {
        public void Attack(Monster monster, Player player)
        {
            bool isCritical = false; //치명타
            bool isEvasion = false; //회피

            Random rand = new Random();
            //오차 구현
            //공격력의 10% 계산 
            double AttackMultiple = player.Atk * 0.1;

            //소수점은 올림처리하기
            int CellingNum = (int)Math.Ceiling(AttackMultiple);

            int randomDamage = rand.Next(-CellingNum, CellingNum + 1); //최대, 최소값 생성해서 그 중에 랜덤으로 선택 

            //최종 데미지 저장
            double FinalAtk = player.Atk + randomDamage;
            
            //회피 구현 (10% 확률)
            if (rand.Next(1,101) <= 10) //10%확률로 회피
            {
                isEvasion = true;

            }
            else // 회피 안했으니 공격
            {
                //치명타 구현 (15% 확률)
                if (rand.Next(1, 101) <= 15)
                {
                    isCritical = true;
                    double critical = 1.6;
                    FinalAtk = FinalAtk * critical;
                }

                monster.Hp -= (int)FinalAtk;

                //만약 몬스터의 hp가 0 이하라면?
                if (monster.Hp <= 0)
                {
                    monster.isDead = true;
                }
            }

            AttackResult(monster, player, FinalAtk, isCritical, isEvasion);
        }

        public  void AttackResult(Monster monster, Player player, double FinalAtk, bool isCritical, bool isEvasion)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Battle!!");
            Console.ResetColor(); // 컬러 리셋

            Console.WriteLine();
            Console.WriteLine($"{player.Name} 의 공격!");

            //회피 했다면
            if (isEvasion)
            {
                Console.Write($"Lv.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{monster.Lev} ");
                Console.ResetColor();
                Console.WriteLine($"{monster.Name}을(를) 공격했지만 아무일도 일어나지 않았습니다.");
                Console.WriteLine();
                Console.WriteLine("0. 다음");

                //InputManager.inputNext();
                string Input = Console.ReadLine();
                int num = int.Parse(Input);

                if (num == 0)
                {
                    //Enemy Phase로 넘어가기
                    Console.WriteLine("Enemy Phase 시작");

                    SceneManager.GetInstance().EnemyPhase(monster, player);
                }
            }
            else if(monster.isDead == false) //공격을 맞았지만 죽지 않았을때
            {
                Console.Write($"Lv.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{monster.Lev} ");
                Console.ResetColor();
                Console.Write($"{monster.Name}을(를) 맞췄습니다. [데미지 : ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{FinalAtk}");
                Console.ResetColor();
                Console.Write("]");

                //만약 치명타가 터졌다면
                if (isCritical)
                {
                    Console.WriteLine(" - 치명타 공격 !!");
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.Write($"Lv.");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write($"{monster.Lev} ");
                Console.ResetColor();
                Console.WriteLine($"{monster.Name}");

                // 몬스터 출력 여부 다르게 하기
                if (monster.Hp <= 0)
                {
                    Console.WriteLine($"HP {monster.Hp + (int)FinalAtk} -> [Dead]");
                }
                else
                {
                    Console.WriteLine($"HP {monster.Hp + (int)FinalAtk} -> {monster.Hp}");
                }

                Console.WriteLine();
                Console.WriteLine("0. 다음");

                //InputManager.inputNext();
                string Input = Console.ReadLine();
                int num = int.Parse(Input);

                if (num == 0)
                {
                    //Enemy Phase로 넘어가기 (상원님 여기에 연결시켜주시면 됩니다.)
                    Console.WriteLine("Enemy Phase 시작");
                    SceneManager.GetInstance().EnemyPhase(monster, player);
                }
            }

            
        }

    }
}

