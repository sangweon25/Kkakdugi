using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    internal class Player
    {
        public enum JobType
        {
            전사,
            마법사,
            도적
        }
        //플레이어 능력치, 세부정보
        public string Name { get; set; }
        public int Lv { get; set; }
        public string Job { get; set; } 
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Atk { get; set; }
        public int EquipAtk { get; set; }
        public int Def { get; set; }
        public int EquipDef { get; set; }
        public int Gold { get; set; }

        public JobType Job_ { get; set; } //효정 추가
        public Player(string name, string job, int lv, int maxHp, int atk, int gold,JobType job_)
        {
            Name = name;
            Job = job;
            Lv = lv;
            MaxHp = maxHp;
            Hp = maxHp;
            Atk = atk;
            Gold = gold;
            SetStats(Job_);
        }

        private void SetStats(JobType job_)
        {
            switch (job_)
            {
                case JobType.전사:
                    Hp = 100;
                    Atk = 8;
                    Def = 10;
                    break;
                case JobType.마법사:
                    Hp = 100;
                    Atk = 12;
                    Def = 6;
                    break;
                case JobType.도적:
                    Hp = 100;
                    Atk = 11;
                    Def = 6;
                    break;
            }
        }
        public void StatusDisplay()
        {
            Console.WriteLine($"Lv. {Lv.ToString("00")}");
            Console.WriteLine($"{Name} ({Job})");

            string str = EquipAtk == 0 ? $"공격력 : {Atk}" : $"공격력: {Atk + EquipAtk} (+{EquipAtk})";
            Console.WriteLine(str);
            str = EquipDef == 0 ? $"방어력 : {Def}" : $"방어력 : {Def + EquipDef} (+{EquipDef})";
            Console.WriteLine(str);

            Console.WriteLine($"체력: {Hp} / {MaxHp}");
            Console.WriteLine($"Gold : {Gold} G");
        }

        //플레이어 필드 내용 출력 함수
        public void PrintPlayer()
        {
            Console.WriteLine("\n\n[내정보]\n");
            Console.WriteLine($"Lv.{Lv} {Name} ({Job})");
            Console.WriteLine($"HP {Hp}/{MaxHp}");
        }


        public int RecieveDamage(int damage)
        {
            if (Hp > 0)
                return Hp -= damage;
            else
                return Hp =0;
        }
        public int BuyItem(int gold)
        {
            return Gold -= gold;
        }

    }//Player Class
}
