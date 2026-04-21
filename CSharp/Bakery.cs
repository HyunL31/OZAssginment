using System;
using System.Collections.Generic;

namespace DailyAssignmentCSharp
{
    internal class Bakery
    {
        public interface IMakeAndSell
        {
            void Make();
            void Sell();
        }

        public class Player
        {
            public string Name { get; set; }
            public string StoreName { get; set; }
            public int Gold { get; set; }
            public int Bread {  get; set; }
            public int Drink { get; set; }

            public void PlayerInit(int gold, int bread, int drink)
            {
                Gold = gold;
                Bread = bread;
                Drink = drink;
            }
        }

        public class Food
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public int Count { get; set; }

            public Food(string name, int count)
            {
                Name = name;
                Count = count;
            }

            public virtual void PrintFood()
            {
                Console.WriteLine("===============================");
                Console.WriteLine($"- 이름: {this.Name}\n- 가격: {this.Price}\n- 개수: {this.Count}");
            }
        }

        public class Drink : Food, IMakeAndSell
        {
            public Drink(string name, int count, int price) : base(name, count)
            {
                Price = price;
            }

            public override void PrintFood()
            {
                base.PrintFood();
                Console.WriteLine($"- 종류: 음료");
                Console.WriteLine("===============================");
            }

            public void Make()
            {
                Console.WriteLine($"음료 {this.Name}을(를) 만들었습니다.");
                this.Count++;

                Console.WriteLine("100원을 지불했습니다.");
            }

            public void Sell()
            {
                Console.WriteLine($"음료 {this.Name}을(를) 팔았습니다.");
                this.Count--;

                Console.WriteLine($"{this.Price}원을 얻었습니다.");
            }
        }

        public class Bread : Food, IMakeAndSell
        {
            public Bread(string name, int count, int price) : base(name, count)
            {
                Price = price;
            }

            public override void PrintFood()
            {
                base.PrintFood();
                Console.WriteLine($"- 종류: 빵");
                Console.WriteLine("===============================");
            }

            public void Make()
            {
                Console.WriteLine($"빵 {this.Name}을(를) 만들었습니다.");
                this.Count++;

                Console.WriteLine("100원을 지불했습니다.");
            }

            public void Sell()
            {
                Console.WriteLine($"빵 {this.Name}을(를) 팔았습니다.");
                this.Count--;

                Console.WriteLine($"{this.Price}원을 얻었습니다.");
            }
        }

        static void Main(string[] args)
        {
            Player player = new Player();
            player.PlayerInit(100, 0, 0);

            Console.WriteLine("당신의 이름을 입력해주세요.");
            player.Name = Console.ReadLine();

            Console.WriteLine("오픈할 가게 이름을 입력해주세요.");
            player.StoreName = Console.ReadLine();

            Console.WriteLine($"카페 {player.StoreName}에 오신 것을 환영합니다.");
            Console.WriteLine("다섯 가지 메뉴를 판매할 수 있습니다.");

            Dictionary<string, Food> foods = new Dictionary<string, Food>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("어떤 메뉴를 판매할까요?");
                Console.WriteLine("1. 음료    2. 빵");
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    player.Drink++;
                    string drinkName;

                    while (true)
                    {
                        Console.WriteLine("음료의 이름을 입력해주세요.");
                        drinkName = Console.ReadLine();

                        if (foods.ContainsKey(drinkName))
                        {
                            Console.WriteLine("이미 있는 이름입니다.");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    Drink drink = new Drink(drinkName, 1, 200);
                    foods.Add(drinkName, drink);
                }
                else
                {
                    player.Bread++;
                    string breadName;

                    while (true)
                    {
                        Console.WriteLine("빵의 이름을 입력해주세요.");
                        breadName = Console.ReadLine();

                        if (foods.ContainsKey(breadName))
                        {
                            Console.WriteLine("이미 있는 이름입니다.");
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }

                    Bread bread = new Bread(breadName, 1, 300);
                    foods.Add(breadName, bread);
                }
            }

            Console.WriteLine($"카페 {player.StoreName}을(를) 오픈했습니다.");
            Console.WriteLine($"자본금이 0원이 되면 폐업합니다.\n자본금이 3000원이 되면 '카페의 신'이 되어 모두의 칭송을 받습니다.");

            while (true)
            {
                Console.WriteLine($"현재 자본금은 {player.Gold}원입니다.");

                if (player.Gold <= 0)
                {
                    Console.WriteLine($"아쉽게도 카페 {player.StoreName}은(는) 폐업을 하고 말았습니다...");
                    return;
                }
                else if (player.Gold >= 3000)
                {
                    break;
                }

                Console.WriteLine("무엇을 할까요?");
                Console.WriteLine("1. 메뉴 확인\n2. 빵 만들기\n3. 음료 만들기\n4. 빵 판매하기\n5. 음료 판매하기");
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    foreach (var food in foods)
                    {
                        food.Value.PrintFood();
                    }
                }
                else if (userInput == 2)
                {
                    if (player.Gold < 100)
                    {
                        Console.WriteLine("빵을 만들기 위해 100원이 필요합니다.\n자본금이 부족합니다.");
                        continue;
                    }
                    else if (player.Bread <= 0)
                    {
                        Console.WriteLine("만들 수 있는 메뉴가 없습니다.");
                        continue;
                    }

                    Console.WriteLine("어떤 빵을 만들까요?\n이름을 입력해주세요.");

                    foreach (var food in foods)
                    {
                        if (food.Value is Bread)
                        {
                            food.Value.PrintFood();
                        }
                    }

                    string breadName = Console.ReadLine();
                    Bread bread = foods[breadName] as Bread;
                    bread.Make();

                    player.Gold -= 100;
                }
                else if (userInput == 3)
                {
                    if (player.Gold < 100)
                    {
                        Console.WriteLine("음료를 만들기 위해 100원이 필요합니다.\n자본금이 부족합니다.");
                        continue;
                    }
                    else if (player.Drink <= 0)
                    {
                        Console.WriteLine("만들 수 있는 메뉴가 없습니다.");
                        continue;
                    }

                    Console.WriteLine("어떤 음료를 만들까요?\n이름을 입력해주세요.");

                    foreach (var food in foods)
                    {
                        if (food.Value is Drink)
                        {
                            food.Value.PrintFood();
                        }
                    }

                    string drinkName = Console.ReadLine();
                    Drink drink = foods[drinkName] as Drink;
                    drink.Make();

                    player.Gold -= 100;
                }
                else if (userInput == 4)
                {
                    if (player.Bread <= 0)
                    {
                        Console.WriteLine("판매할 수 있는 메뉴가 없습니다.");
                        continue;
                    }

                    Console.WriteLine("어떤 빵을 판매할까요?\n이름을 입력해주세요.");

                    foreach (var food in foods)
                    {
                        if (food.Value is Bread)
                        {
                            food.Value.PrintFood();
                        }
                    }

                    string breadName = Console.ReadLine();

                    if (foods[breadName].Count <= 0)
                    {
                        Console.WriteLine("판매할 수 있는 빵이 없습니다.");
                        continue;
                    }

                    Bread bread = foods[breadName] as Bread;
                    bread.Sell();

                    player.Gold += bread.Price;
                }
                else
                {
                    if (player.Drink <= 0)
                    {
                        Console.WriteLine("판매할 수 있는 메뉴가 없습니다.");
                        continue;
                    }

                    Console.WriteLine("어떤 음료를 판매할까요?\n이름을 입력해주세요.");

                    foreach (var food in foods)
                    {
                        if (food.Value is Drink)
                        {
                            food.Value.PrintFood();
                        }
                    }

                    string drinkName = Console.ReadLine();

                    if (foods[drinkName].Count <= 0)
                    {
                        Console.WriteLine("판매할 수 있는 음료가 없습니다.");
                        continue;
                    }

                    Drink drink = foods[drinkName] as Drink;
                    drink.Sell();

                    player.Gold += drink.Price;
                }
            }

            Console.WriteLine($"축하드립니다.\n'카페의 신'이 되었습니다.\n모두가 {player.Name}을(를) 칭송합니다.");
        }
    }
}
