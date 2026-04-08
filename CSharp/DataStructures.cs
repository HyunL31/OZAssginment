using System;
using System.Collections.Generic;

namespace DailyAssignmentCSharp
{
    internal class DataStructures
    {
        static void Main(string[] args)
        {
            // 해시셋 예제
            HashSet<string> hs = new HashSet<string>();
            hs.Add("궁수");
            hs.Add("전사");
            hs.Add("힐러");
            hs.Add("법사");
            hs.Add("전사");       // 자동으로 무시

            Console.WriteLine("궁수, 전사, 힐러, 법사, 전사 입력 시 해시셋 개수");
            Console.WriteLine(hs.Count);

            // 스택
            Stack<int> st = new Stack<int>();

            st.Push(1);
            st.Push(2);
            st.Push(3);

            Console.WriteLine("\n1, 2, 3 입력 시 스택 출력 결과");
            Console.WriteLine(st.Pop());
            Console.WriteLine(st.Pop());
            Console.WriteLine(st.Pop());
            
            // 큐
            Queue<int> q = new Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            Console.WriteLine("\n1, 2, 3 입력 시 큐 출력 결과");
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
        }
    }
}
