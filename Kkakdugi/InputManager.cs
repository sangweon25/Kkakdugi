using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    //겹치는 입력 묶어주는 클래스
    static class InputManager
    {
        //switch문 사용할때 사용
        //min~ max 사이 입력을 받아서 switch로 input값을 넘겨주는 함수
        public static int GetInput(int min, int max)
        {
            while (true)
            {
                Console.Write("원하시는 행동을 입력해주세요.\n>>");
                if (int.TryParse(Console.ReadLine(), out int input) && min <= input && input <= max)
                    return input;
                else
                    Console.WriteLine("잘못된 입력입니다.\n");
            }
        }

        public static int inputNext()
        {
            while (true)
            {
                Console.Write("0. 다음\n\n>>");
                if (int.TryParse(Console.ReadLine(), out int input) && input == 0)
                    return input;
                else
                    Console.WriteLine("잘못된 입력입니다.\n");
            }
        }

        public static int WrongInput()
        {
            while (true)
            {
                Console.WriteLine("0. 다음");
                if (int.TryParse(Console.ReadLine(), out int input) && input == 0)
                    return input;
                else
                    Console.WriteLine("잘못된 입력입니다.\n");
            }
        }
    }
}
