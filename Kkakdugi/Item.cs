using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    //아이템 무기,방어구 
    enum AbilityType
    {
        무기 = 0,
        방어구 = 1,
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
        public bool IsSold { get; set; }


        //아이템 생성자
        public Item(AbilityType abilType, string name, int abil, string desc,int gold )
        {
            Name = name;
            Description = desc; 
            Ability = abil;
            Type = abilType;
            Gold = gold;
            IsSold = false;
        }

        //아이템 장착 가능 여부
        public Item(bool IsEquip)
        {
            IsEquip = false; // 처음엔 장착x
        }

        public void ToggleEquip()
        {
            IsEquip = !IsEquip; // 장착 상태 반전
        }
        public void PrintItems(/*Item inItem*/)
        {
            //inItem의 타입, 이름, 능력치,설명,가격순으로 출력 // ? 아이템이 팔렸다면Sold Out 출력 : 아니라면 가격을 출력;
            string soldCheck = IsSold ?"Sold Out" : Gold.ToString();
            Console.WriteLine("{0,-15}| {1,-15}| {2,-15}| {3,-15}| {4,-15}",Type,Name,Ability,Description,soldCheck);
        }

    }//Item Class
}
