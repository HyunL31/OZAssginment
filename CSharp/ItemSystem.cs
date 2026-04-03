using System;
using System.Collections.Generic;

namespace DailyAssignmentCSharp
{
    internal class ItemSystem
    {
        public class Character
        {
            private string _characterName;
            private int _hp;
            private int _mp;
            private int _atk;
            private int _def;

            public Character(string characterName, int hp, int mp, int atk, int def)
            {
                this._characterName = characterName;
                this._hp = hp;
                this._mp = mp;
                this._atk = atk;
                this._def = def;
            }

            public string GetName()
            {
                return _characterName;
            }

            public void SetHP(int hp)
            {
                this._hp += hp;
            }

            public void SetMP(int mp)
            {
                this._mp += mp;
            }

            public void SetATK(int atk)
            {
                this._atk += atk;
            }

            public void SetDEF(int def)
            {
                this._def += def;
            }

            public void PrintCharacter()
            {
                Console.WriteLine($"==========={this._characterName}===========");

                Console.WriteLine($"- HP: {this._hp}\n- MP: {this._mp}\n- ATK: {this._atk}\n- DEF: {this._def}\n===============================\n");
            }
        }

        // 부모 클래스
        public class Item
        {
            private int _id;
            private string _name;
            private string _description;
            private int _count;

            public Item(string name, string description)
            {
                this._name = name;
                this._description = description;
            }

            public void ItemInit(int id, int count)
            {
                this._id = id;
                this._count = count;
            }

            // 오버라이딩
            public virtual void UseItem(Character character)
            {
                if (this._count > 0)
                {
                    this._count--;

                    Console.WriteLine($"{character.GetName()}이(가) {this._name}을(를) 사용했습니다.");
                    Console.WriteLine($"{this._description}");
                }
                else
                {
                    Console.WriteLine($"남은 {this._name}이(가) 없습니다.");
                }
            }

            public void PrintItem()
            {
                Console.WriteLine($"==========={this._name}===========");

                Console.WriteLine($"- ID: {this._id}\n- 설명: {this._description}\n- 개수: {this._count}\n===============================\n");
            }
        }

        // 상속 (자식 클래스)
        public class HPPotion : Item
        {
            public HPPotion(string name, string description) : base(name, description) { }

            public override void UseItem(Character character)
            {
                Console.WriteLine("HP가 +10 상승했습니다.");

                character.SetHP(10);
                base.UseItem(character);
            }

            public void StaminaUp()
            {
                Console.WriteLine("HP가 늘어났습니다!! 생존 가능성이 늘어났습니다!!");
            }
        }

        public class MPPotion : Item
        {
            public MPPotion(string name, string description) : base(name, description) { }

            public override void UseItem(Character character)
            {
                Console.WriteLine("MP가 +10 상승했습니다.");

                character.SetMP(10);
                base.UseItem(character);
            }

            public void ManaUp()
            {
                Console.WriteLine("마나 포인트가 늘어났습니다! 곧 대마법사가 될 수 있을지도 모르겠군요!");
            }
        }

        public class  ATKPotion : Item
        {
            public ATKPotion(string name, string description) : base(name, description) { }

            public override void UseItem(Character character)
            {
                Console.WriteLine("ATK가 +10 상승했습니다.");

                character.SetATK(10);
                base.UseItem(character);
            }

            public void PowerUp()
            {
                Console.WriteLine("공격력이 늘어났습니다!! 아무래도 전사가 될 운명이었나봅니다!");
            }
        }

        public class DEFPotion : Item
        {
            public DEFPotion(string name, string description) : base(name, description) { }

            public override void UseItem(Character character)
            {
                Console.WriteLine("DEF가 +10 상승했습니다.");

                character.SetDEF(10);
                base.UseItem(character);
            }

            public void DefenseUp()
            {
                Console.WriteLine("방어력이 늘어났습니다!! 모두가 당신의 등 뒤에 있습니다!");
            }
        }

        static void Main(string[] args)
        {
            Character player = new Character("이주현", 50, 50, 50, 50);
            player.PrintCharacter();

            List<Item> inventory = new List<Item>()
            { new HPPotion("HP 포션", "HP를 상승시켜줍니다."), new MPPotion("MP 포션", "MP를 상승시켜줍니다."),
                new ATKPotion("공격력 포션", "공격력을 상승시켜줍니다."), new DEFPotion("방어력 포션", "방어력을 상승시켜줍니다.")};

            for (int i = 0; i <  inventory.Count; i++)
            {
                inventory[i].ItemInit(i + 1, 3);
            }

            foreach(Item item in inventory)
            {
                item.UseItem(player);

                // 클래스 형변환 1
                if (item is HPPotion)
                {
                    HPPotion hpPotion = item as HPPotion;

                    hpPotion.StaminaUp();
                }
                else if (item is MPPotion)
                {
                    MPPotion mpPotion = item as MPPotion;

                    mpPotion.ManaUp();
                }
                else
                {
                    // 클래스 형변환 2
                    ATKPotion atkPotion = item as ATKPotion;

                    if (atkPotion != null)
                    {
                        atkPotion.PowerUp();
                    }
                    else
                    {
                        DEFPotion dEFPotion = item as DEFPotion;

                        dEFPotion.DefenseUp();
                    }
                }

                Console.WriteLine();
            }

            foreach(Item item in inventory)
            {
                item.PrintItem();
            }

            player.PrintCharacter();
        }
    }
}
