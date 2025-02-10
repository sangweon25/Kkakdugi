namespace Kkakdugi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SceneManager sceneManager = new SceneManager();
        
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            // 출력.예외 포함..if
            //GetInput(switch문 케이스 범위만큼 입력)
            int input = InputManager.GetInput(1,3);
            switch (input)
            {
                case 1:
                    //상태보기 창으로 이동
                    break;
                case 2:
                    //전투시작 창으로 이동
                    Console.Clear();
                    sceneManager.MonsterPrintInfo();
                    break;
                case 3:
                    Console.Clear();
                    sceneManager.StoreScene();
                    break;
             
            }

            //Console.WriteLine("상태 보기");
            //Console.WriteLine("캐릭터의 정보가 표시됩니다.");

            ////캐릭터 객체 생성 및 초기화
            //bool gameRunning = true;
            //while (gameRunning)
            //{
            //    // 캐릭터 상태 보기 출력
            //    Console.Write("원하시는 행동을 입력해주세요.");
            //    string str = Console.ReadLine();
            //    switch (str)
            //    {
            //        case "1":
            //            Console.WriteLine("1");
            //            break;
            //        case "0":
            //            Console.WriteLine("0. 나가기");
            //            break;

            //    }
            //}
        }//Main Method
    }//class Program
}//namespace