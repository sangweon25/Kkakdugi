using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    enum AbilityType
    {
        Attack = 0,
        Defense = 1,
    }
    
    internal class Item
    {
        //아이템 세부 정보
        public string Name { get; set; }
        public string Description { get; set; }
        public int Ability { get; set; }
        public  AbilityType Type{ get; set; }
        public int Gold{ get; set; }
        public bool IsEquip {  get; set; }


        public Item(string name, string desc,int abil, AbilityType abilType,int gold )
        {
            Name = name;
            Description = desc; 
            Ability = abil;
            Type = abilType;
            Gold = gold;
        }

    }
}
