using System;

namespace DailyAssignmentCSharp
{
    internal class Singleton
    {
        public class BattleManager
        {
            // 전역 접근
            private static BattleManager _instance;

            // 싱글톤 패턴
            public static BattleManager Inst
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new BattleManager();
                    }

                    return _instance;
                }
            }

            public void AAA()
            {
                Console.WriteLine("호냐냥~");
            }
        }

        public class TestClass
        {
            public void BBB()
            {
                Console.WriteLine("테스트용 클래스");
                BattleManager.Inst.AAA();
            }
        }

        static void Main(string[] args)
        {
            // new로 새로운 객체를 직접 선언하지 않아도 사용 가능
            BattleManager.Inst.AAA();

            TestClass test = new TestClass();

            test.BBB();
        }
    }
}
