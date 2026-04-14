using System;

namespace DailyAssignmentCSharp
{
    internal class PropertyPractice
    {
        public interface ISleep
        {
            void Sleep();
        }

        public interface IStudy
        {
            void Study();
        }

        public interface ISwimable
        {
            void FreestyleSwim();
            void BreastStroke();
        }

        public class Player : ISwimable, IStudy, ISleep
        {
            // 평범한 멤버 변수
            private string _name;
            private int _age;
            private int _gold;

            // 깔끔한 프로퍼티 (밖에서 멤버 변수 바꾸는 건 위험하니 private으로)
            public string Name { get; private set; }
            public int Age { get; private set; }
            public int Gold { get; private set; }

            // set은 private이라 밖에서 접근 못하니 안에 새로운 메서드 작성
            public void ChangeName(string value)
            {
                this.Name = value;
            }

            public void ChangeAge(int value)
            {
                this.Age = value;
            }

            public void ChangeGold(int value)
            {
                this.Gold = value;
            }

            // return과 value를 사용한 프로퍼티
            public string GetSetName
            {
                get { return this._name; }
                set
                {
                    this._name = value;
                }
            }

            public int GetSetAge
            {
                get { return this._age; }
                set
                {
                    this._age = value;
                }
            }

            public int GetSetGold
            {
                get { return this._gold; }
                set
                {
                    this._gold = value;
                }
            }

            // Get, Set 함수
            public string GetName()
            {
                return this._name;
            }

            public void SetName(string value)
            {
                this._name = value;
            }

            public int GetAge()
            {
                return this._age;
            }

            public void SetAge(int value)
            {
                this._age = value;
            }

            public int GetGold()
            {
                return this._gold;
            }

            public void SetGold(int value)
            {
                this._gold = value;
            }

            public void FreestyleSwim()
            {
                Console.WriteLine("이 친구는 자유형을 할 수 있습니다.\n숙연해질 정도로 느리네요...\n");
            }

            public void BreastStroke()
            {
                Console.WriteLine("평영은 형편없군요.\n");
            }

            public void Study()
            {
                Console.WriteLine("이제 공부를 합니다.\n아직 갈 길이 머네요...\n");
            }

            public void Sleep()
            {
                Console.WriteLine("이 친구는 잠을 오래 자는 것에는 누구보다 자신이 있습니다.\n");
            }
        }

        static void Main(string[] args)
        {
            Player character1 = new Player();
            Player character2 = new Player();

            // 기존 Get, Set 메서드
            character1.SetName("에이");
            character2.SetName("비");

            // 깔끔한 프로퍼티
            character1.ChangeAge(11);
            character2.ChangeAge(10);

            // return, value를 사용한 프로퍼티
            character1.GetSetGold = 100;
            character2.GetSetGold = 101;

            // 기존 Get, Set 메서드
            Console.WriteLine($"{character1.GetName()}은(는) 공부라는 것을 할 수 있나봅니다.");
            Console.WriteLine($"{character2.GetName()}은(는) 공부라는 것을 할 수 있나봅니다.");

            // 깔끔한 프로퍼티
            Console.WriteLine($"{character1.Age}세 입니다.");
            Console.WriteLine($"{character2.Age}세 입니다.");

            // return, value를 사용한 프로퍼티
            Console.WriteLine($"{character1.GetSetGold}원이 있습니다.");
            Console.WriteLine($"{character2.GetSetGold}원이 있습니다.");
        }
    }
}
