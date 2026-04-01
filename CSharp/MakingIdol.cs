using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace DailyAssignmentCSharp
{
    internal class MakingIdol
    {
        public enum Gern
        {
            Dance,
            Rock,
            HipHop,
            Ballad
        }

        public class Trainee
        {
            private string _name;
            private int _dance;
            private int _sing;
            private int _aegyo;
            private bool _isDebut = false;

            public Trainee(string name)
            {
                this._name = name;

                // 구글: C#에서 난수는 Random 클래스를 동적 할당 후 생성 가능
                Random random = new Random();

                this._dance = random.Next(50, 80);
                this._sing = random.Next(50, 80);
                this._aegyo = random.Next(50, 80);
            }

            public string GetName()
            {
                return this._name;
            }

            public void PrintTrainee()
            {
                Console.WriteLine("==========================================");
                Console.WriteLine($"- 이름: {this._name}");
                
                if (this._dance >= 100)
                {
                    Console.WriteLine($"- 춤: 100");
                }
                else
                {
                    Console.WriteLine($"- 춤: {this._dance}");
                }

                if (this._sing >= 100)
                {
                    Console.WriteLine($"- 노래: 100");
                }
                else
                {
                    Console.WriteLine($"- 노래: {this._sing}");
                }

                if (this._aegyo >= 100)
                {
                    Console.WriteLine($"- 애교: 100");
                }
                else
                {
                    Console.WriteLine($"- 애교: {this._aegyo}");
                }

                Console.WriteLine("==========================================");
            }

            public void PassDebut(Group group)
            {
                if (this._dance >= 100 && this._sing >= 100 && this._aegyo >= 100 && !this._isDebut)
                {
                    Console.WriteLine($"연습생 {this._name}이(가) 데뷔조에 들어갔습니다!");
                    this._isDebut = true;
                    group.AddMember();
                }
            }

            public void PracticeDance()
            {
                Console.WriteLine($"연습생 {this._name}이(가) 춤을 연습합니다.");

                Random random = new Random();
                int randomNum = random.Next(25, 60);

                Thread.Sleep(1000);

                Console.WriteLine($"연습생 {this._name}의 춤 실력이 +{randomNum}만큼 증가했습니다.");

                this._dance += randomNum;

                Thread.Sleep(1000);

                this.PrintTrainee();
            }

            public void PracticeSing()
            {
                Console.WriteLine($"연습생 {this._name}이(가) 노래를 연습합니다.");

                Random random = new Random();
                int randomNum = random.Next(25, 60);

                Thread.Sleep(1000);

                Console.WriteLine($"연습생 {this._name}의 노래 실력이 +{randomNum}만큼 증가했습니다.");

                this._sing += randomNum;

                Thread.Sleep(1000);

                this.PrintTrainee();
            }

            public void PracticeAegyo()
            {
                Console.WriteLine($"연습생 {this._name}이(가) 애교를 연습합니다.");

                Random random = new Random();
                int randomNum = random.Next(25, 60);

                Thread.Sleep(1000);

                Console.WriteLine($"연습생 {this._name}의 애교 실력이 +{randomNum}만큼 증가했습니다.");

                this._aegyo += randomNum;

                Thread.Sleep(1000);

                this.PrintTrainee();
            }
        }

        public class Group
        {
            private string _groupName;
            private Gern _gern;
            private int _memberCount = 0;
            private bool _isDebut = false;

            public Group(string groupName, Gern gern = Gern.Dance)
            {
                this._groupName = groupName;
                this._gern = gern;
            }

            public bool GetIsDebut()
            {
                return this._isDebut;
            }

            public int GetMemberCount()
            {
                return this._memberCount;
            }

            public void PrintGroup()
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine($"- 그룹명: {this._groupName}");
                
                if (this._gern == Gern.Dance)
                {
                    Console.WriteLine("- 장르: 댄스");
                }
                else if (this._gern == Gern.Rock)
                {
                    Console.WriteLine($"- 장르: 락");
                }
                else if (this._gern == Gern.HipHop)
                {
                    Console.WriteLine($"- 장르: 힙합");
                }
                else if (this._gern == Gern.Ballad)
                {
                    Console.WriteLine($"- 장르: 발라드");
                }

                Console.WriteLine($"- 멤버 수: {this._memberCount}");
                Console.WriteLine("==========================================");
            }

            public void AddMember()
            {
                this._memberCount++;
            }

            public void CompleteDebut()
            {
                Console.WriteLine("축하드립니다!!\n데뷔에 성공했습니다!!\n");
                this._isDebut = true;

                return;
            }

            public void FailDebut()
            {
                Console.WriteLine("아쉽게도 데뷔에 실패했습니다...\n기획사는 폐업을 하게 되었네요....");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("당신은 폐업 위기에 처한 기획사 사장...");
            Thread.Sleep(1000);
            Console.WriteLine("회사의 연습생들은 3명이지만...");
            Thread.Sleep(1000);
            Console.WriteLine("그들 모두가 아이돌 데뷔의 마지노선이라 불리우는 만 24세에 다다랐다...");
            Thread.Sleep(1000);
            Console.WriteLine("이제 더 이상은 물러날 곳이 없다!");
            Thread.Sleep(1000);
            Console.WriteLine("세 명의 연습생을 훈련시키고 데뷔시켜 회사의 폐업을 막아라!");

            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("\n=======Making Idol======\n");

            Thread.Sleep(500);

            Console.WriteLine("데뷔시킬 그룹명을 정해주세요.");
            Console.Write("그룹명: ");
            string groupName = Console.ReadLine();

            Console.WriteLine("\n");

            Thread.Sleep(500);

            Console.WriteLine("그룹의 음악 장르를 정해주세요.");
            Console.WriteLine("1. 댄스\n2. 락\n3. 힙합\n4. 발라드");
            // Console.Read() 사용하면 다음에 ReadLine() 사용할 때 버퍼가 남아 입력이 안됨
            int groupGern = int.Parse(Console.ReadLine());

            Group group = new Group(groupName, (Gern)groupGern - 1);
            group.PrintGroup();

            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("\n연습생 3명의 이름을 각각 알려주세요.");

            List<Trainee> trainees = new List<Trainee>();

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"연습생 {i + 1}: ");
                string traineeName = Console.ReadLine();

                Trainee trainee = new Trainee(traineeName);
                trainees.Add(trainee);
            }

            Thread.Sleep(1000);
            Console.Clear();

            for (int i = 0; i < 14; i++)
            {
                Console.WriteLine($"앞으로 {14 - i}일 동안 연습생들을 훈련시켜 데뷔시키세요.");
                Console.WriteLine("세 명의 연습생이 모두 데뷔조에 들어갈 경우 정식 데뷔가 가능합니다.");

                Thread.Sleep(1000);

                for (int j = 0; j < 3; j++)
                {
                    trainees[j].PrintTrainee();
                }

                Console.WriteLine("무엇을 할까요?");
                Console.WriteLine("1. 춤 연습\n2. 노래 연습\n3. 애교 연습");

                int playerInput = int.Parse(Console.ReadLine());

                Console.WriteLine("누구한테 시킬까요?");

                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"{j + 1}. {trainees[j].GetName()}");
                }

                int memberInput = int.Parse(Console.ReadLine());

                if (playerInput == 1)
                {
                    trainees[memberInput - 1].PracticeDance();
                }
                else if (playerInput == 2)
                {
                    trainees[memberInput - 1].PracticeSing();
                }
                else if (playerInput == 3)
                {
                    trainees[memberInput - 1].PracticeAegyo();
                }

                trainees[memberInput - 1].PassDebut(group);

                Thread.Sleep(1000);

                group.PrintGroup();

                Thread.Sleep(1000);

                if (group.GetMemberCount() >= 3)
                {
                    group.CompleteDebut();
                    break;
                }

                Thread.Sleep(1000);
                Console.Clear();
            }

            if (!group.GetIsDebut())
            {
                group.FailDebut();
            }
        }
    }
}
