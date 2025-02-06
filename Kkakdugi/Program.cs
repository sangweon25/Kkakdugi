namespace Kkakdugi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            
            // 입력
            Console.Write("원하시는 행동을 입력해주세요.");
            string userInput = Console.ReadLine();
            
            // 출력.예외 포함..if
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("1. 상태 보기");
                    break;
                case "2":
                    Console.WriteLine("2. 전투 시작");
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }
            
        }
    }
}
