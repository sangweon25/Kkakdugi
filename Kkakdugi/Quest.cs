using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    internal class Quest
    {
        public string QuestName { get; private set; }
        public string QuestDescription { get; private set; }
        public string QuestReward { get; private set; }
        public bool IsClear { get; private set; }

        public Quest(string name, string desc,string reward)
        {
            QuestName = name;
            QuestDescription = desc;
            QuestReward = reward;
            IsClear = false;

        }
        public void QuestAcceptScene()
        {
            //퀘스트 이름, 내용출력
            Console.Clear();
            Console.WriteLine("Quest!!\n");
            Console.WriteLine(QuestName);
            Console.WriteLine();
            Console.WriteLine(QuestDescription);
            Console.WriteLine();
            //퀘스트 조건
            //퀘스트 조건이 충족될때마다 변수값이 변경되어야함.

            //퀘스트 보상
            Console.WriteLine(QuestReward);
            Console.WriteLine();
            int input = InputManager.QuestInput();
            switch(input)
            {
                case 0:
                    Console.Clear();
                    SceneManager.GetInstance().QuestSelectScene();
                    break;
                case 1:
                    //출력된 퀘스트 수락
                    break;
            }
        }
    }
}
