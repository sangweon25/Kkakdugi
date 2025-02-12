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

    

        public Quest(string name, string desc,string reward)
        {
            QuestName = name;
            QuestDescription = desc;
            QuestReward = reward;

        }

   

    }
}
