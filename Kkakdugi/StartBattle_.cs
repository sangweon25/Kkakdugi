﻿using Kkakdugi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kkakdugi
{
    // 랜덤한 수의 몬스터 등장. 중복 등장 O
    // 몬스터의 레벨 체력 공격력 설정
    // 캐릭터 정보 띄우기. 레벨 이름 직업 체력.
    // 1. 공격 입력 창 띄우기

    // 몬스터 클래스 생성
    public class Monster
    {
        internal bool isDead;

        // 몬스터의 이름 레벨 체력 공격력 설정
        public string Name { get; set; }
        public int Lev { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        
        // 생성자로 몬스터 속성 초기화
        public Monster(string name, int lev, int hp, int atk, bool Dead)
        {
            Name = name;
            Lev = lev;
            Hp = hp;
            Atk = atk;
            isDead= Dead; //효정 추가 
        }
        public void MonsterState(Monster m)
        {
            Console.WriteLine($"Lv.{m.Lev} {m.Name} Hp {m.Hp}");
        }
    }
}


//메인에다가 할 것
// * 몬스터 리스트 생성 //  List<Monster> monsters = new List<Monster>();
// * {
//        new Monster("솔트", 1, 10, 3),
//        new Monster("슈가", 2, 10, 5),
//        new Monster("다이콘", 3, 15, 10),
//        new Monster("레드파우더", 5, 25, 15)
//    }; // 몬스터 초기화값 입력
//랜덤 몬스터 생성하기 위해 // Random random = new Random(); 입력
//랜덤한 숫자로 생성하기 위해 // int randomnum = rand.Next(1, 5); // 1~4 까지
// 랜덤으로 생겨난 몬스터들을 저장할 리스트 생성 // List<Monster> randmonsters = new List<Monster>();
//1~4 마리의 몬스터가 랜덤으로 등장 시키기 위해 반복문 사용
//// for (int i = 0; i <randmonsters; i++)
//{ int monsterIndex = rand.Next(monsters.Count); // 0~3번까지의 인덱스 랜덤선택
//randmonsters.Add(monsters[monsterIndex]); // 랜덤 인덱스를 랜덤으로 생겨난 몬스터 리스트에 저장
//}
//// foreach ( Monster monsters in randmonsters)
//{
//    monster.PrintInfo();
//} // 리스트에 있는걸 반복 순환 시키는 foreach를 써서 몬스터 클래스의 출력 메서드 호출
