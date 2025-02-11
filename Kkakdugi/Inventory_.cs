using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    internal class Inventory_
    {
        // 보유한 아이템 리스트 생성
        private List<Item> getitems;

        public Inventory_()
        {
            getitems = new List<Item>();
        }

        public void AddItem(Item item)
        {
            getitems.Add(item); // 아이템 추가
        }
        // 인벤토리 창 선택시 아이템 목록 출력
        public void ItemprintInfo()
        {
            Console.WriteLine("[아이템 목록]\n");
            for (int i = 0; i < getitems.Count; i++) // 인벤토리 아이템 출력
            {
                string displayName = getitems[i].IsEquip ? "[E] " + getitems[i].Name : getitems[i].Name;// IsEquip이 true라면 [E] 표시 아니라면 아이템 이름만
                Console.WriteLine($"{i + 1}. {displayName}"); // 아이템 번호와 이름 출력
              
            }
            if (getitems.Count == 0)
            {
                Console.WriteLine("보유한 아이템이 없습니다.");

            }
        }
        public void ToggleEquipItem(int index)
        {
            if (index >= 0 && index < getitems.Count)
            {
                getitems[index].ToggleEquip(); // 선택한 아이템 장착 및 해제 변경
                
            }

        }

    }

}
