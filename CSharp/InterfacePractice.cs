using System;
using System.Collections.Generic;

namespace DailyAssignmentCSharp
{
    internal class InterfacePractice
    {
        public interface ISleep
        {
            // 7.3에서는 사용 불가능... 8 이상에서 사용 가능
            /*void Sleep()
            {
                Console.WriteLine("잠을 오래 자는 것에는 자신이 있습니다.");
            }*/

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

        public class Pet : ISwimable, ISleep
        {
            public void FreestyleSwim()
            {
                Console.WriteLine("강아지 마루는 자유형을 꽤 잘 할 겁니다.\n");
            }

            public void BreastStroke()
            {
                Console.WriteLine("아마 평영도 할 줄 알 겁니다.\n");
            }

            public void Sleep()
            {
                Console.WriteLine("강아지 마루는 하루 18시간을 잡니다.\n부럽군요...\n");
            }
        }

        static void Main(string[] args)
        {
            Player character1 = new Player();
            Player character2 = new Player();
            Pet pet = new Pet();

            List<ISleep> sleepCreature = new List<ISleep>();

            sleepCreature.Add(character1);
            sleepCreature.Add(character2);
            sleepCreature.Add(pet);

            foreach (ISleep sleep in sleepCreature)
            {
                if (sleep is IStudy)
                {
                    IStudy study = sleep as IStudy;

                    Console.WriteLine("공부라는 것을 할 수 있나봅니다.");
                    study.Study();
                }
                else
                {
                    ISwimable swimable = sleep as ISwimable;

                    Console.WriteLine("수영도 할 수 있나봅니다.");
                    swimable.FreestyleSwim();
                    swimable.BreastStroke();
                }
            }
        }
    }
}
