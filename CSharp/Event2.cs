using System;

namespace DailyAssignmentCSharp
{
    internal class Event2
    {
        public class User
        {
            public string Name {  get; set; }

            public event Action OnEat;

            public void EatFood()
            {
                Console.WriteLine($"{this.Name}은(는) 음식을 열심히 먹기 시작합니다.");
            }

            public void Pray()
            {
                Console.WriteLine($"{this.Name}은(는) 기도를 합니다.");
                OnEat += EatFood;

                OnEat?.Invoke();
            }
        }

        public class Oven
        {
            public int Minute {  get; set; }
            public int Current { get; set; }

            public void OnCompleteFood(Action onEat)
            {
                Console.WriteLine("음식이 완성되었습니다.");
                onEat?.Invoke();
            }
        }

        static void Main(string[] args)
        {
            User user = new User();
            user.Name = "에헤헤";

            Oven oven = new Oven();
            oven.Minute = 50;
            oven.Current = 0;

            Console.WriteLine("1 입력 시 10분이 지나갑니다.");

            while (true)
            {
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    oven.Current += 10;

                    Console.WriteLine($"{oven.Current}분이 지났습니다.");
                }
                else
                {
                    Console.WriteLine("다시 입력해주세요.");
                }

                if (oven.Current >= 50)
                {
                    oven.OnCompleteFood(user.Pray);
                    break;
                }
            }
        }
    }
}
