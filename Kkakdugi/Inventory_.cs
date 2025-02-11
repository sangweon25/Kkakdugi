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
        private List<Item> item;
        public Inventory_()
        {
            item = new List<Item>();
        }
       
        // 인벤토리 창 선택시 아이템 목록 출력
        public void ItemprintInfo()
        {
            Console.WriteLine("[아이템 목록]\n"); 
            if (item.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
            }
            else
            {
                foreach ( Item items in item)
                {
                    Console.WriteLine(items);
                }
            }         
        }

    }
    


}
