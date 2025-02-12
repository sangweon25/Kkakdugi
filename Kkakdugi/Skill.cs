using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    public class Skill
    {
        public string Name { get; set; }  // 스킬 이름
        public int MpCost { get; set; }   // MP 소모량
        public Action<Player, List<Monster>> Effect { get; set; }  // 스킬 효과를 정의하는 델리게이트
        public string Description { get; set; } // 스킬 설명 추가
        
        public Skill(string name, int mpCost, Action<Player, List<Monster>> skillEffect, string description)
        {
            Name = name;
            MpCost = mpCost;
            Effect = skillEffect;
            Description = description;
        }

        // 스킬 실행
        public void Execute(Player player, List<Monster> monsters)
        {
            Effect(player, monsters);
        }


    }


    public class SkillList
    {
        public static void TargetCheck(Monster target)
        {
            if (target.Hp < 0)
            {
                target.Hp = 0; // 0이하로 내려감 방지
                target.isDead = true; //죽었음
            }
        }

        // 스킬 리스트 (스킬들 초기화)
        public static List<Skill> Skills = new List<Skill>
        {
            // 전사 스킬
            new Skill("알파 스트라이크", 10, (player, monsters) =>
            {
                foreach (var target in monsters)
                {
                    if (target.Hp <= 0)
                    {
                        continue; //이미 죽은 몬스터는 넘김
                    }

                    // 적이 살아있다면 공격
                    int damage = player.Atk * 2;
                    Console.WriteLine($"{player.Name}은(는) {target.Name}에게 {damage}만큼 공격했다!");
                    target.Hp -= damage;

                    // 공격 후, 해당 적이 죽었는지 확인
                    TargetCheck(target);

                    // 첫 번째 적을 처리한 후에는 그만 진행하고, 나머지 적은 넘어가도록 break
                    break;
                }
               
            }, "첫 번째 적을 2배의 데미지로 단일 공격 합니다."),

            new Skill("더블 스트라이크", 15, (player, monsters) =>
            {
                Random random = new Random();

                // 살아있는 적 리스트 만들기
                var aliveMonsters = monsters.Where(m => !m.isDead).ToList();

                // 살아있는 적이 1명일 경우
                if (aliveMonsters.Count == 1)
                {
                    int target = monsters.IndexOf(aliveMonsters[0]);
                    int damage = (int)(player.Atk * 1.5);
                    Console.WriteLine($"{player.Name}은(는) {monsters[target].Name}에게 {damage}만큼 공격했다!");
                    monsters[target].Hp -= damage;

                    if (monsters[target].Hp <= 0)
                    {
                        monsters[target].Hp = 0;
                        monsters[target].isDead = true;
                    }
                }
                else if (aliveMonsters.Count > 1)
                {
                    // 살아있는 적이 2명 이상일 경우
                    int firstTarget = random.Next(aliveMonsters.Count);
                    int secondTarget = random.Next(aliveMonsters.Count);

                    // 첫 번째 적이 죽었으면 다시 살아있는 적을 선택
                    while (aliveMonsters[firstTarget].isDead)
                    {
                        firstTarget = random.Next(aliveMonsters.Count);
                    }

                    // 두 번째 적이 첫 번째 적과 같거나 죽었으면 다시 살아있는 적을 선택
                    while (aliveMonsters[secondTarget].isDead || secondTarget == firstTarget)
                    {
                        secondTarget = random.Next(aliveMonsters.Count);
                    }

                    int damage = (int)(player.Atk * 1.5);
                    Console.WriteLine($"{player.Name}은(는) {aliveMonsters[firstTarget].Name}와 {aliveMonsters[secondTarget].Name}에게 각각 {damage}만큼 공격했다!");

                    // 데미지 입히기
                    aliveMonsters[firstTarget].Hp -= damage;
                    aliveMonsters[secondTarget].Hp -= damage;

                    // 타켓이 죽었을 때 세부설정
                    if (aliveMonsters[firstTarget].Hp <= 0)
                    {
                        aliveMonsters[firstTarget].Hp = 0;
                        aliveMonsters[firstTarget].isDead = true;
                    }

                    
                    if (aliveMonsters[secondTarget].Hp <= 0)
                    {
                        aliveMonsters[secondTarget].Hp = 0;
                        aliveMonsters[secondTarget].isDead = true;
                    }
                }
            }, "랜덤한 2마리의 적에게 1.5배의 데미지를 입힙니다."),

            // 마법사 스킬
            new Skill("파이어볼", 15, (player, monsters) =>
            {
                foreach (var target in monsters)
                {
                    if (target.Hp <= 0)
                    {
                        continue; //이미 죽은 몬스터는 넘김
                    }

                    // 적이 살아있다면 공격
                    int damage = (int)(player.Atk * 1.5);
                    Console.WriteLine($"{player.Name}은(는) {target.Name}에게 파이어볼을 날려 {damage}만큼 피해를 주었다!");
                    target.Hp -= damage;

                    // 공격 후, 해당 적이 죽었는지 확인
                    TargetCheck(target);

                    // 첫 번째 적을 처리한 후에는 그만 진행하고, 나머지 적은 넘어가도록 break
                    break;
                }
            }, "첫 번째 적에게 1.5배의 데미지를 주는 파이어볼을 시전합니다."),

            new Skill("메테오", 40, (player, monsters) =>
            {
                int totalDamage = player.Atk * 2;
                Console.WriteLine($"{player.Name}은(는) 하늘에서 메테오를 소환하여 모든 적에게 {totalDamage}의 피해를 주었다!");
                foreach (var monster in monsters)
                {
                    monster.Hp -= totalDamage;

                    TargetCheck(monster);
                    //// 몬스터의 HP가 0 이하이면 isDead를 true로 설정
                    //if (monster.Hp <= 0)
                    //{
                    //    monster.Hp = 0;  // HP가 0 이하로 떨어지지 않도록 설정
                    //    monster.isDead = true;  // 죽은 몬스터로 설정
                    //}
                }
               

            }, "모든 적에게 2배의 데미지를 주는 메테오를 소환합니다."),

            // 도적 스킬
            new Skill("백스탭", 10, (player, monsters) =>
            {
                foreach (var target in monsters)
                {
                    if (target.Hp <= 0)
                    {
                        continue; //이미 죽은 몬스터는 넘김
                    }

                    // 적이 살아있다면 공격
                    int damage = player.Atk * 2;
                    Console.WriteLine($"{player.Name}은(는) {target.Name}에게 {damage}만큼 공격했다!");
                    target.Hp -= damage;

                    // 공격 후, 해당 적이 죽었는지 확인
                    TargetCheck(target);

                    // 첫 번째 적을 처리한 후에는 그만 진행하고, 나머지 적은 넘어가도록 break
                    break;
                }
            }, "뒤에서 적을 기습 공격하여 2배의 데미지를 입힙니다."),

            new Skill("칼날 폭풍", 35, (player, monsters) =>
            {
                Random random = new Random();

                // 살아있는 적 리스트 만들기
                var aliveMonsters = monsters.Where(m => !m.isDead).ToList();

                // 살아있는 적이 1명일 경우
                if (aliveMonsters.Count == 1)
                {
                    int target = monsters.IndexOf(aliveMonsters[0]);
                    int damage = (int)(player.Atk * 1.5);
                    Console.WriteLine($"{player.Name}은(는) 휘몰아치는 칼날로 {monsters[target].Name}에게 {damage}만큼 공격했다!");
                    monsters[target].Hp -= damage;

                    if (monsters[target].Hp <= 0)
                    {
                        monsters[target].Hp = 0;
                        monsters[target].isDead = true;
                    }
                }
                else if (aliveMonsters.Count > 1)
                {
                    // 살아있는 적이 2명 이상일 경우
                    int firstTarget = random.Next(aliveMonsters.Count);
                    int secondTarget = random.Next(aliveMonsters.Count);

                    // 첫 번째 적이 죽었으면 다시 살아있는 적을 선택
                    while (aliveMonsters[firstTarget].isDead)
                    {
                        firstTarget = random.Next(aliveMonsters.Count);
                    }

                    // 두 번째 적이 첫 번째 적과 같거나 죽었으면 다시 살아있는 적을 선택
                    while (aliveMonsters[secondTarget].isDead || secondTarget == firstTarget)
                    {
                        secondTarget = random.Next(aliveMonsters.Count);
                    }

                    int damage = (int)(player.Atk * 1.5);
                    Console.WriteLine($"{player.Name}은(는) 휘몰아치는 칼날로\n{aliveMonsters[firstTarget].Name}와 {aliveMonsters[secondTarget].Name}에게 각각 {damage}만큼 공격했다!");

                    // 데미지 입히기
                    aliveMonsters[firstTarget].Hp -= damage;
                    aliveMonsters[secondTarget].Hp -= damage;

                    // 타켓이 죽었을 때 세부설정
                    if (aliveMonsters[firstTarget].Hp <= 0)
                    {
                        aliveMonsters[firstTarget].Hp = 0;
                        aliveMonsters[firstTarget].isDead = true;
                    }


                    if (aliveMonsters[secondTarget].Hp <= 0)
                    {
                        aliveMonsters[secondTarget].Hp = 0;
                        aliveMonsters[secondTarget].isDead = true;
                    }
                }
            }, "두 명의 랜덤한 적에게 1.5배의 데미지를 주는 칼날 폭풍을 사용합니다."),
        };

        
    }
}
