﻿using Kkakdugi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

        public Monster Clone() //각각의 몬스터 객체를 만들기 위한 메서드 
        {
            return new Monster(Name, Lev, Hp, Atk, isDead);
        }

        public void MonsterState(Monster m)
        {
            Console.WriteLine($"Lv.{m.Lev} {m.Name} Hp {m.Hp}");
        }

    }
}
