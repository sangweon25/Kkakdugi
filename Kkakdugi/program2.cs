namespace Kkakdugi
{
    internal class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");

            //캐릭터 객체 생성 및 초기화
            Character player = new Character
            {
                Level = 1,
                Name = "Chad",
                Job = "전사",
                Attack = 10,
                Defense = 5,
                Health = 100,
                Gold = 1500
            };

            bool gameRunning = true;

            while (gameRunning)
            {
                // 캐릭터 상태 보기 출력
                player.DisplayStatus();

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
}

    
