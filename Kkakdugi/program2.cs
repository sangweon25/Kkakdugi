namespace Kkakdugi
{
    internal class program
    {
        static void Character(string[] args)
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");

            Console.Write("원하시는 행동을 입력해주세요.");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("1. 직업..");
                    break;
                case "0":
                    Console.WriteLine("0. 나가기");
                    break;
            }
        }
    }
}

    
