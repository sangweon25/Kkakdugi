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

        //플레이어 능력치, 세부정보
        public string Name { get; set; }
        public int Lv { get; set; }
        public string Job { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int BeforeHp { get; set; }
        public int Atk { get; set; }
        public int EquipAtk { get; set; }
        public int Def { get; set; }
        public int EquipDef { get; set; }
        public int Gold { get; set; }

        public Player(string name, string job, int lv, int maxHp, int atk, int gold)
        {
            Name = name;
            Job = job;
            Lv = lv;
            MaxHp = maxHp;
            BeforeHp = maxHp;
            Hp = maxHp;
            Atk = atk;
            Gold = gold;
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
