using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    internal class StartBattle_
    {
        // 랜덤한 수의 몬스터 등장. 중복 등장 O
        // 몬스터의 레벨 체력 공격력 설정
        // 캐릭터 정보 띄우기. 레벨 이름 직업 체력.
        // 1. 공격 입력 창 띄우기
        internal class StartBattle
        {
            // 전투 시작 화면

            public void StartbattleScene()
            {
                Console.WriteLine("Battle!!");


            }

        }


        public class Monster
        {
            // 몬스터의 이름 레벨 체력 공격력 설정
            public string Name { get; set; }
            public int Lev { get; set; }
            public int Hp { get; set; }
            public int Atk { get; set; }

        }

        public class Salt : Monster
        {
            public void SaltScene()
            {
                Console.WriteLine();
            }
        }

        public class Daikon : Monster
        {
            public void DaikonScene()
            {
                Console.WriteLine();
            }

        }
        public class Redpowder : Monster
        {
            public void RedpowderScene()
            {
                Console.WriteLine();

            }

        }

    }
}
