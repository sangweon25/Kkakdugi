namespace Kkakdugi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SceneManager sceneManager = new SceneManager();

            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            // 출력.예외 포함..if
            int input = InputManager.GetInput(1, 2);
            switch (input)
            {
                case 1:
                    //상태보기 창으로 이동
                    StatusScreen();
                    break;
                case 2:
                    //전투시작 창으로 이동
                    Console.Clear();
                    sceneManager.MonsterPrintInfo();
                    break;

            }

            public void StatusScreen()
            {
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();

                //player.cs status-참조
                Player.StatusDisplay();

                Console.WriteLine();
                Console.WriteLine("1");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();

                int input = InputManager.GetInput(1, 2);
                switch (input)
                {
                    case 1:
                        //상태보기 창으로 이동
                        StatusScreen();
                        break;
                    case 2:
                        MainScreen();
                        break;
                }
            }
        }
    }
}