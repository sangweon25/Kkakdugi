using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    public class Player
    {
        public enum JobType //임의로 넣은 직업 타입
        {
            전사,
            마법사,
            도적
        }
        //플레이어 능력치, 세부정보
        public string Name { get; set; }
        public int Lv { get; set; }
        public int Mp { get; set; }
        public int MaxMp { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int BeforeHp { get; set; }
        public int Atk { get; set; }
        public int EquipAtk { get; set; }
        public int Def { get; set; }
        public int EquipDef { get; set; }
        public int Gold { get; set; }

        public JobType Job { get; set; } //효정 추가
        public List<Skill> Skills { get; set; } //스킬 클래스 선언
       
        public Player(string name, string job,int mp, int lv, int maxHp, int atk,int def, int gold)
        {
            Name = name;
            Lv = lv;

            Mp = mp;
            MaxMp = 50;

            MaxHp = maxHp;
            BeforeHp = maxHp;
            Hp = maxHp;

            Atk = atk;
            Def = def;
            Gold = gold;

            Skills = new List<Skill>(); //스킬 리스트 초기화
        }

        public void SetJob(JobType newJob)
        {
            Job = newJob;
            SetStats(newJob); //직업에 맞는 스탯 세팅
            SetSkills(newJob); //직업에 맞는 스킬 세팅
        }

        public void SetName(string name)
        {
            Name = name;
        }
        private void SetStats(JobType Job)
        {
            switch (Job)
            {
                case JobType.전사:
                    MaxHp = 110;
                    Hp = 110;
                    Atk = 8;
                    Def = 10;
                    break;
                case JobType.마법사:
                    MaxHp = 100;
                    Hp = 100;
                    Atk = 12;
                    Def = 6;
                    break;
                case JobType.도적:
                    MaxHp = 105;
                    Hp = 105;
                    Atk = 11;
                    Def = 6;
                    break;
            }
        }

        public void SetSkills(JobType job)
        {
            Skills.Clear(); //기존 스킬 제거

            // 직업에 맞는 스킬만 추가
            switch (job)
            {
                case JobType.전사:
                    Skills.Add(SkillList.Skills[0]);  // 알파 스트라이크
                    Skills.Add(SkillList.Skills[1]);  // 더블 스트라이크
                    break;

                case JobType.마법사:
                    Skills.Add(SkillList.Skills[2]);  // 파이어볼
                    Skills.Add(SkillList.Skills[3]);  // 메테오
                    break;

                case JobType.도적:
                    Skills.Add(SkillList.Skills[4]);  // 백스탭
                    Skills.Add(SkillList.Skills[5]);  // 칼날 폭풍
                    break;
            }
        }

        public void StatusDisplay() 
        {
            Console.WriteLine($"Lv. {Lv.ToString("00")}");
            Console.WriteLine($"{Name} ({Job})"); 

            string str = EquipAtk == 0 ? $"공격력 : {Atk}" : $"공격력: {Atk} (+{EquipAtk})";
            Console.WriteLine(str);
            str = EquipDef == 0 ? $"방어력 : {Def}" : $"방어력 : {Def} (+{EquipDef})";
            Console.WriteLine(str);

            Console.WriteLine($"체력: {Hp} ");
            Console.WriteLine($"Gold : {Gold} G");
        }

        //플레이어 필드 내용 출력 함수
        public void PrintPlayer() 
        {
            Console.WriteLine("\n[내정보]\n");
            Console.WriteLine($"Lv.{Lv} {Name} ({Job})");
            Console.WriteLine($"HP {Hp}/{MaxHp}");
            Console.WriteLine($"MP {Mp}/{MaxMp}");
            Console.WriteLine();
        }

        public int RecieveDamage(int damage)
        {
            //Hp가 음수면 0리턴
            if (Hp - damage < 0)
                return Hp = 0;
            // Hp가 0보다 크면 Hp에서 데미지를 뺀다 아니면 0
            return Hp > 0 ? Hp -= damage : Hp = 0;
        }
        public int BuyItem(int gold)
        {
            return Gold -= gold;
        }
        
        public void EquipItem(int itemAtk = 0,int itemDef = 0)//장착할때 아이템의 능력치를 더해줌
        {
            EquipAtk += itemAtk;
            Atk += itemAtk;
            EquipDef += itemDef;
            Def += itemDef;
        }

        public void UnEquipItem(int itemAtk = 0, int itemDef = 0)//해제할때 아이템의 능력치를 빼줌
        {
            Atk -= itemAtk;
            EquipAtk -= itemAtk;
            Def -= itemDef;
            EquipDef -= itemDef;
        }

    }//Player Class
}
