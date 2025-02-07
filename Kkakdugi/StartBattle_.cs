using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kkakdugi
{
    // 랜덤한 수의 몬스터 등장. 중복 등장 O
    // 몬스터의 레벨 체력 공격력 설정
    // 캐릭터 정보 띄우기. 레벨 이름 직업 체력.
    // 1. 공격 입력 창 띄우기
    internal class StartBattle_
    {
        // 전투 시작 화면

        public void StartbattleScene()
        {
            Console.WriteLine("Battle!!");

        }
    }

    // 몬스터 클래스 생성
    public class Monster
    {
        // 몬스터의 이름 레벨 체력 공격력 설정
        public string Name { get; set; }
        public int Lev { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }

        // 생성자로 몬스터 속성 초기화
        public Monster(string name, int lev, int hp, int atk)
        {
            Name = name;
            Lev = lev;
            Hp = hp;
            Atk = atk;
        }

        // 몬스터 정보 출력
        public void PrintInfo()
        {
            Console.WriteLine($"Lv.{Lev} {Name} Hp {Hp}");
        }





    }




}


/* 메인에다가 할 것
 * 몬스터 리스트 생성 //  List<Monster> monsters = new List<Monster>();
 * {
        new Monster("솔트", 1, 10, 3),
        new Monster("슈가",2, 10, 5),
        new Monster("다이콘", 3, 15, 10),
        new Monster("레드파우더", 5, 25, 15)
    }; // 몬스터 초기화값 입력
 랜덤 몬스터 생성하기 위해 // Random random = new Random(); 입력
랜덤한 숫자로 생성하기 위해 // int randomnum = rand.Next(1, 5); // 1~4 까지
 */