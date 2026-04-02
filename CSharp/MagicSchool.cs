using System;

namespace DailyAssignmentCSharp
{
    internal class MagicSchool
    {
        public enum Dorm
        {
            None,
            Slytherin,
            Gryffindor,
            Hufflepuff,
            Ravenclaw
        }

        public class Wizard
        {
            private string _name;
            private int _age;
            private Dorm _dormitory;

            public Wizard(string name, int age, Dorm dormitory)
            {
                this._name = name;
                this._age = age;
                this._dormitory = dormitory;
            }

            public string GetName()
            {
                return this._name;
            }

            public virtual void PrintWizard()
            {
                Console.WriteLine($"- 이름: {this._name}\n- 나이: {this._age}\n- 기숙사: {this._dormitory}");
            }
        }

        public class Student : Wizard
        {
            private int _power = 0;

            public Student(string name, int age, Dorm dormitory) : base(name, age, dormitory) { }

            public void LearnMagic(string magic, Professor professor)
            {
                Random random = new Random();
                int randomNum = random.Next(0, 2);

                if (randomNum == 0)
                {
                    Console.WriteLine($"{base.GetName()}은(는) {magic} 주문을 배웠습니다!");

                    this._power += professor.GetTeachingPower();
                    professor.SetTeachingPower(10);
                }
                else
                {
                    Console.WriteLine($"{base.GetName()}은(는) {magic} 주문을 배우지 못했습니다....");

                    professor.SetTeachingPower(-10);
                }
            }

            public override void PrintWizard()
            {
                Console.WriteLine("==========학생=========");
                base.PrintWizard();
                Console.WriteLine($"- 마력: {this._power}");
            }
        }

        public class Professor : Wizard
        {
            private int _teachingPower = 0;

            public Professor(string name, int age, Dorm dormitory) : base(name, age, dormitory) { }

            public void SetTeachingPower(int teachingPower)
            {
                this._teachingPower += teachingPower;
            }

            public int GetTeachingPower()
            {
                return _teachingPower;
            }

            public void TeachMagic(string magic, Student student)
            {
                Console.WriteLine($"{base.GetName()}은(는) {magic} 주문을 가르쳤습니다.");

                student.LearnMagic(magic, this);
            }

            public override void PrintWizard()
            {
                Console.WriteLine("==========교수=========");
                base.PrintWizard();
                Console.WriteLine($"- 교수력: {this._teachingPower}");
            }
        }

        static void Main(string[] args)
        {
            Student student = new Student("해리포터", 11, Dorm.Gryffindor);

            Professor professor = new Professor("맥고나걸", 56, Dorm.Gryffindor);
            professor.SetTeachingPower(30);

            student.PrintWizard();
            professor.PrintWizard();

            professor.TeachMagic("변신술", student);

            student.PrintWizard();
            professor.PrintWizard();
        }
    }
}
