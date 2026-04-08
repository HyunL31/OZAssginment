using System;
using System.Collections.Generic;

namespace DailyAssignmentCSharp
{
    internal class FantasyDictionary
    {
        public class FantasyAnimal
        {
            private string _name;
            private int _age;

            public FantasyAnimal(string name, int age)
            {
                this._name = name;
                this._age = age;
            }

            public virtual void PrintDict()
            {
                Console.WriteLine($"- 이름: {this._name}\n- 나이: {this._age}");
                Console.WriteLine("==============================================");
            }
        }

        public class Unicorn : FantasyAnimal
        {
            public Unicorn(string name, int age) : base(name, age) { }

            public override void PrintDict()
            {
                Console.WriteLine("- 종족: 유니콘");
                base.PrintDict();
            }
        }

        public class Dragon : FantasyAnimal
        {
            public Dragon(string name, int age) : base(name, age) { }

            public override void PrintDict()
            {
                Console.WriteLine("- 종족: 드래곤");
                base.PrintDict();
            }
        }

        public class Griffin : FantasyAnimal
        {
            public Griffin(string name, int age) : base(name, age) { }

            public override void PrintDict()
            {
                Console.WriteLine("- 종족: 그리핀");
                base.PrintDict();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("당신은 5마리의 동물을 발견하였습니다.\n이름을 지어주고 도감을 만드세요.");
            Dictionary<int, FantasyAnimal> fantasyDict = new Dictionary<int, FantasyAnimal>();

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("어떤 동물을 발견하셨나요?");
                Console.WriteLine("1. 유니콘\n2. 드래곤\n3. 그리핀");
                int input = int.Parse(Console.ReadLine());

                Console.WriteLine("이름은 뭐라고 지을까요?");
                string animalName = Console.ReadLine();
                int animalAge = random.Next(1, 1000);

                if (input == 1)
                {
                    Unicorn unicorn = new Unicorn(animalName, animalAge);
                    fantasyDict.Add(i + 1, unicorn);
                }
                else if (input == 2)
                {
                    Dragon dragon = new Dragon(animalName, animalAge);
                    fantasyDict.Add(i + 1, dragon);
                }
                else if (input == 3)
                {
                    Griffin griffin = new Griffin(animalName, animalAge);
                    fantasyDict.Add(i + 1, griffin);
                }
            }

            while (true)
            {
                Console.WriteLine("원하는 메뉴를 선택해주세요.");

                Console.WriteLine("1. 도감 열기\n2. 검색\n3. 종료");
                int input = int.Parse(Console.ReadLine());
                
                if (input == 1)
                {
                    if (fantasyDict.Count == 0)
                    {
                        Console.WriteLine("도감에 남아있는 동물이 없습니다.\n종료합니다.");
                        break;
                    }

                    for (int i = 1; i <= 5; i++)
                    {
                        if (!fantasyDict.ContainsKey(i))
                        {
                            continue;
                        }

                        fantasyDict[i].PrintDict();
                    }
                }
                else if (input == 2)
                {
                    Console.WriteLine("동물의 번호를 입력해주세요.");
                    int searchInput = int.Parse(Console.ReadLine());

                    if (!fantasyDict.ContainsKey(searchInput))
                    {
                        Console.WriteLine("동물을 찾을 수 없습니다.");
                        continue;
                    }

                    fantasyDict[searchInput].PrintDict();
                    fantasyDict.Remove(searchInput);
                }
                else if (input == 3)
                {
                    Console.WriteLine("종료합니다.");
                    break;
                }
            }
        }
    }
}
