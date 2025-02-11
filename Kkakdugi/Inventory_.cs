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
            if (getitems.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
                return;
            }
            
            foreach (Item items in getitems)
            {
                // 장착된 아이템에 [E] 표시
                string displayName = items.IsEquip ? "[E]" + items.Name : items.Name;
                Console.WriteLine(displayName);
            }
                    
        }

        
        
    }
    


}
