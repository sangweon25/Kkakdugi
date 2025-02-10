namespace Kkakdugi
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            SceneManager sceneManager = new SceneManager();

            sceneManager.MainScene();

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
        public void StatusScreen()
        {
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
                
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
            }
        }
    }//class Program
    
}//namespace