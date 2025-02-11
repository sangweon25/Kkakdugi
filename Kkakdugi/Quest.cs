﻿using System;
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
        public bool IsAccept { get; private set; }
        public bool IsClear { get; private set; }
        public int Requirements { get; private set; }
        public int CurrentValue { get; private set; }

        public Quest(string name, string desc,string reward, int requirements = 0)
        {
            QuestName = name;
            QuestDescription = desc;
            QuestReward = reward;
            IsAccept = false;
            IsClear = false;
            Requirements = requirements;
            CurrentValue = 0;
        }

        public void QuestAcceptScene()
        {
            //퀘스트 이름, 내용출력
            bool isClear = false;
            Console.Clear();
            Console.WriteLine("Quest!!\n");
            Console.WriteLine(QuestName);
            Console.WriteLine();
            Console.WriteLine(QuestDescription);
            Console.WriteLine();
            //퀘스트 조건이 있다면
            if(Requirements != 0)
                Console.WriteLine($"- 몬스터 {Requirements}마리 처치 ({CurrentValue}/{Requirements})\n");

            //퀘스트 보상
            Console.WriteLine("-보상-");
            Console.WriteLine(QuestReward);
            Console.WriteLine();
            if (IsClear == true)
                isClear = true;
            int input = InputManager.QuestInput(isClear);
            switch(input)
            {
                case 0:
                    Console.Clear();
                    SceneManager.GetInstance().QuestSelectScene();
                    break;
                case 1:
                    //출력된 퀘스트 수락
                    Console.Clear();
                    if(IsAccept ==true)
                        Console.WriteLine("이미 수락된 퀘스트입니다.\n");
                    else if(IsClear == true)
                        Console.WriteLine("이미 완료된 퀘스트입니다.\n");
                    if(IsAccept == false && IsClear ==false)
                        IsAccept = true;
                    SceneManager.GetInstance().QuestSelectScene();
                    break;
            }
        }//QuestAcceptScene Method
        public void BuyCheck(Item item)
        {
            item.Name = "나뭇가지";
        }

    }
}
