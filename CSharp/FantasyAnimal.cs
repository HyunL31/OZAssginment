using System;
using System.Collections.Generic;
using System.Threading;

namespace DailyAssignmentCSharp
{
    internal class FantasyAnimal
    {
        public enum Grade
        {
            Normal,
            Rare,
            Epic,
            Legendary
        }

        public class Character
        {
            private string _characterName;
            private List<FantasticCreature> _fantasticCreatures = new List<FantasticCreature>();

            public Character(string name)
            {
                this._characterName = name;
            }

            public string GetCharacterName()
            {
                return this._characterName;
            }

            public List<FantasticCreature> GetList()
            {
                return this._fantasticCreatures;
            }

            public void ChooseCreature()
            {
                Random random = new Random();
                int randomNum = random.Next(0, 4);

                Grade randomGrade = Grade.Normal;

                if (randomNum == 1)
                {
                    randomGrade = Grade.Rare;
                }
                else if (randomNum == 2)
                {
                    randomGrade = Grade.Epic;
                }
                else if (randomNum == 3)
                {
                    randomGrade = Grade.Legendary;
                }

                Console.WriteLine("\n1. 드래곤\n2. 유니콘\n3. 그리핀\n");
                int input = int.Parse(Console.ReadLine());

                Console.WriteLine("좋구나! 그럼 그 아이의 이름을 지어주렴.");
                string name = Console.ReadLine();

                if (input == 1)
                {
                    Dragon dragon = new Dragon(randomGrade, 1);
                    dragon.SetName(name);
                    this._fantasticCreatures.Add(dragon);
                }
                else if (input == 2)
                {
                    Unicorn unicorn = new Unicorn(randomGrade, 1);
                    unicorn.SetName(name);
                    this._fantasticCreatures.Add(unicorn);
                }
                else if (input == 3)
                {
                    Griffin griffin = new Griffin(randomGrade, 1);
                    griffin.SetName(name);
                    this._fantasticCreatures.Add(griffin);
                }
            }

            public void PrintDictionary()
            {
                Console.WriteLine($"================={this._characterName}의 도감=================");

                foreach (var creature in this._fantasticCreatures)
                {
                    Console.WriteLine($"--------------------------------------------------");
                    creature.PrintCreature();
                    Console.WriteLine($"--------------------------------------------------");
                }

                Console.WriteLine($"=====================================================");
            }
        }

        public class FantasticCreature
        {
            private string _name;
            private Grade _grade;
            private int _level;

            public FantasticCreature(Grade grade, int level, string name = "")
            {
                this._grade = grade;
                this._level = level;
            }

            public int GetLevel()
            {
                return this._level;
            }

            public void SetLevel(int num)
            {
                this._level += num;
            }

            public string GetName()
            {
                return this._name;
            }

            public void SetName(string name)
            {
                this._name = name;
            }

            public Grade GetGrade()
            {
                return this._grade;
            }

            public virtual void PrintCreature()
            {
                Console.WriteLine($"- 이름: {this._name}\n- 등급: {this._grade}\n- 레벨: {this._level}");
            }
        }

        public class Dragon : FantasticCreature
        {
            public Dragon(Grade grade, int level) : base(grade, level) { }

            public override void PrintCreature()
            {
                Console.WriteLine("- 종족: 드래곤");
                base.PrintCreature();
            }
        }

        public class Unicorn : FantasticCreature
        {
            public Unicorn(Grade grade, int level) : base(grade, level) { }

            public override void PrintCreature()
            {
                Console.WriteLine("- 종족: 유니콘");
                base.PrintCreature();
            }
        }

        public class Griffin : FantasticCreature
        {
            public Griffin(Grade grade, int level) : base(grade, level) { }

            public override void PrintCreature()
            {
                Console.WriteLine("- 종족: 그리핀");
                base.PrintCreature();
            }
        }

        public static void Win(Character player)
        {
            Console.WriteLine("축하한다! 이겼구나!");
            Thread.Sleep(1000);
            Console.WriteLine("누구를 데려가겠니?");

            player.ChooseCreature();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("오, 나는 '오박사'라고 한단다. 이름이 무엇이니?");
            string nameInput = Console.ReadLine();
            Character player = new Character(nameInput);

            Console.WriteLine($"반갑구나! {player.GetCharacterName()}!");
            Thread.Sleep(1000);
            Console.WriteLine("응? 지금부터 밖에 나가 모험을 하겠다고??");
            Console.WriteLine("1. 네\n2. YES\n3. Ja\n4. はい");
            Console.ReadLine();
            Console.WriteLine("바깥은 혼자다니기엔 위험하단다...!");
            Thread.Sleep(1000);
            Console.WriteLine("이 아이들 중 하나를 데려가려무나...!");
            Thread.Sleep(1000);

            player.ChooseCreature();

            Console.WriteLine("자, 이제 모험을 떠나거라...!");
            Thread.Sleep(1000);
            Console.WriteLine("혹시 다른 동물을 더 데리고 가고 싶다면 나에게 가위바위보를 이겨보렴.");
            Thread.Sleep(1000);

            while (true)
            {
                Console.WriteLine("이제 무엇을 할거니?\n");
                Thread.Sleep(1000);
                Console.WriteLine("\n1. 먹이주기\n2. 가위바위보\n3. 산책\n4. 도감 열기\n5. 동물 검색\n6. 종료\n");

                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    Console.WriteLine("음식을 먹은 동물들의 레벨이 올랐다!");

                    Thread.Sleep(1000);

                    foreach (var list in player.GetList())
                    {
                        list.SetLevel(1);
                        Console.WriteLine($"- {list.GetName()}의 레벨: {list.GetLevel()}");
                    }
                }
                else if (userInput == 2)
                {
                    Random random = new Random();
                    int randomNum = random.Next(0, 3);

                    Console.WriteLine("무엇을 낼까요?");
                    Console.WriteLine("1. 가위\n2. 바위\n3. 보");

                    int playerInput = int.Parse(Console.ReadLine());

                    if (randomNum == 0)
                    {
                        Console.WriteLine("오박사: 가위");

                        if (playerInput == 2)
                        {
                            Win(player);
                        }
                        else
                        {
                            Console.WriteLine("하핳!! 좀 더 연습이 필요하겠구나!! 다시 도전하렴");
                        }
                    }
                    else if (randomNum == 1)
                    {
                        Console.WriteLine("오박사: 바위");

                        if (playerInput == 3)
                        {
                            Win(player);
                        }
                        else
                        {
                            Console.WriteLine("하핳!! 좀 더 연습이 필요하겠구나!! 다시 도전하렴");
                        }
                    }
                    else
                    {
                        Console.WriteLine("오박사: 보");

                        if (playerInput == 1)
                        {
                            Win(player);
                        }
                        else
                        {
                            Console.WriteLine("하핳!! 좀 더 연습이 필요하겠구나!! 다시 도전하렴");
                        }
                    }
                }
                else if (userInput == 3)
                {
                    Console.WriteLine("산책을 한 동물들의 레벨이 올랐다!");

                    Thread.Sleep(1000);

                    foreach (var list in player.GetList())
                    {
                        list.SetLevel(2);
                        Console.WriteLine($"- {list.GetName()}의 레벨: {list.GetLevel()}");
                    }
                }
                else if (userInput == 4)
                {
                    player.PrintDictionary();
                }
                else if (userInput == 5)
                {
                    Console.WriteLine("무엇을 검색할까요?");
                    Console.WriteLine("1. 등급\n2. 레벨\n3. 이름");
                    int playerInput = int.Parse(Console.ReadLine());

                    bool isFind = false;

                    if (playerInput == 1)
                    {
                        Console.WriteLine("어떤 등급을 검색할까요?");
                        Console.WriteLine("1. Normal\n2. Rare\n3. Epic\n4. Legendary");
                        playerInput = int.Parse(Console.ReadLine());

                        Grade findGrade = Grade.Normal;

                        if (playerInput == 2)
                        {
                            findGrade = Grade.Rare;
                        }
                        else if (playerInput == 3)
                        {
                            findGrade = Grade.Epic;
                        }
                        else if (playerInput == 4)
                        {
                            findGrade = Grade.Legendary;
                        }

                        foreach (var list in player.GetList())
                        {
                            if (list.GetGrade() == findGrade)
                            {
                                isFind = true;
                                list.PrintCreature();
                            }
                        }
                    }
                    else if (playerInput == 2)
                    {
                        Console.WriteLine("몇 레벨을 검색할까요?");
                        playerInput = int.Parse(Console.ReadLine());

                        foreach (var list in player.GetList())
                        {
                            if (list.GetLevel() == playerInput)
                            {
                                isFind = true;
                                list.PrintCreature();
                            }
                        }
                    }
                    else if (playerInput == 3)
                    {
                        Console.WriteLine("어떤 이름을 검색할까요?");
                        string searchName = Console.ReadLine();

                        foreach (var list in player.GetList())
                        {
                            if (list.GetName() == searchName)
                            {
                                isFind = true;
                                list.PrintCreature();
                            }
                        }
                    }

                    if (!isFind)
                    {
                        Console.WriteLine("해당하는 동물을 찾을 수 없습니다.");
                    }
                }
                else if (userInput == 6)
                {
                    Console.WriteLine("종료합니다. 안녕히 가세요.");

                    break;
                }
            }
        }
    }
}
