using System;

namespace DailyAssignmentCSharp
{
    internal class Event1
    {
        public class Player
        {
            public string Name { get; set; }

            public void WakeUp(int hour)
            {
                Console.WriteLine($"{this.Name}은(는) {hour}에 일어났습니다.");
            }

            public void Lazy(int hour)
            {
                Console.WriteLine($"{this.Name}은(는) {hour}에도 일어나지 않고 게으르게 누워있습니다.");
            }
        }

        public class Alarm
        {
            public event Action<int> OnAlarm;

            public void Morning(int hour)
            {
                Console.WriteLine($"오전 {hour}시입니다. 일어날 시간입니다.");
                OnAlarm?.Invoke(hour);
            }
        }

        static void Main(string[] args)
        {
            Alarm alarm = new Alarm();

            Player player1 = new Player();
            Player player2 = new Player();

            player1.Name = "까르륵";
            player2.Name = "아하하";

            // 여기에 매개변수 넣는 게 아니라 Invoke 할 때 들어감!
            alarm.OnAlarm += player1.WakeUp;
            alarm.OnAlarm += player2.Lazy;

            alarm.Morning(8);
        }
    }
}
