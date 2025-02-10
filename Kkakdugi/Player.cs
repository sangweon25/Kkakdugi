using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
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
        public int Atk { get; set; }
        public int EquipAtk { get; set; }
        public int Def { get; set; }
        public int EquipDef { get; set; }
        public int Gold { get; set; }

        public Player(string name,string job, int lv, int maxHp, int atk, int gold, int def)
        {
            Name = name;
            Job = "전사";
            Lv = lv;
            Hp = maxHp;
            Atk = atk;
            Gold = gold;
            EquipAtk = 0;
            Def = def;
        }


        public void StatusDisplay()
        {
            Console.WriteLine($"Lv. {AuthenticationLevel.ToString("00")}");
            Console.WriteLine($"{Name} ({Job}");
            
            string str = EquipAtk == 0 ? $"공격력 : {Atk}" : $"공격력: {Atk + EquipAtk} (+{EquipAtk})";
            Console.WriteLine(str);
            str=EquipDef == 0 ? $"방어력 : {Def}" : $"방어력 : {Def + EquipDef} (+{EquipDef})";
            Console.WriteLine(str);
            
            Console.WriteLine($"체력: {Hp} / {MaxHp}");
            Console.WriteLine($"Gold : {Gold} G");
            
        }
        //플레이어 필드 내용 출력 함수
        public void PrintPlayer()
        {

        }

        public int RecieveDamage(int damage)
        {
            return Hp - damage;
        }

    }
}
