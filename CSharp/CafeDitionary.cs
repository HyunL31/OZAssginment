using System;
using System.Collections.Generic;

namespace DailyAssignmentCSharp
{
    internal class CafeDictionary
    {
        public class Food
        {
            private string _name;
            private int _price;

            public Food(string name, int price)
            {
                this._name = name;
                this._price = price;
            }

            public string GetName()
            {
                return this._name;
            }
        }

        public class Drink : Food
        {
            public Drink(string name, int price) : base(name, price) { }

            public virtual void MakeDrink()
            {
                Console.WriteLine($"음료 {this.GetName()}을(를) 제작하고 있습니다.");
            }
        }

        public class Coffee : Drink
        {
            public Coffee(string name, int price) : base(name, price) { }

            public override void MakeDrink()
            {
                base.MakeDrink();
                Console.WriteLine("샷을 추출하고 있습니다.");
            }
        }

        public class Ade : Drink
        {
            public Ade(string name, int price) : base(name, price) { }

            public override void MakeDrink()
            {
                base.MakeDrink();
                Console.WriteLine("과일청을 담고 있습니다.");
            }
        }

        public class Bread : Food
        {
            public Bread(string name, int price) : base(name, price) { }

            public virtual void MakeBread()
            {
                Console.WriteLine($"빵 {this.GetName()}을(를) 제작하고 있습니다.");
            }
        }

        public class Croissant : Bread
        {
            public Croissant(string name, int price) : base(name, price) { }

            public override void MakeBread()
            {
                base.MakeBread();
                Console.WriteLine("오븐에서 굽고 있습니다.");
            }
        }

        static void Main(string[] args)
        {
            Dictionary<int, Food> order = new Dictionary<int, Food>();

            Console.WriteLine("주문할 커피의 수를 입력해주세요.");
            int coffeeNum = int.Parse(Console.ReadLine());

            Console.WriteLine("주문할 에이드의 수를 입력해주세요.");
            int adeNum = int.Parse(Console.ReadLine());

            Console.WriteLine("주문할 크루아상의 수를 입력해주세요.");
            int croissantNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < coffeeNum; i++)
            {
                Coffee coffee = new Coffee("아메리카노", 4500);

                order.Add(i, coffee);
            }

            for (int i = coffeeNum; i < coffeeNum + adeNum; i++)
            {
                Ade ade = new Ade("딸기 에이드", 5500);

                order.Add(i, ade);
            }

            for (int i = coffeeNum + adeNum; i < coffeeNum + adeNum + croissantNum; i++)
            {
                Croissant croissant = new Croissant("앙버터 크루아상", 4500);

                order.Add(i, croissant);
            }

            Random random = new Random();
            int randomNum = random.Next(0, order.Count);

            Console.WriteLine(randomNum);

            if (order[randomNum] is Drink drink)
            {
                drink.MakeDrink();
            }

            if (order[randomNum] is Bread bread)
            {
                bread.MakeBread();
            }
        }
    }
}