using System;

namespace DailyAssignmentCSharp
{
    internal class Calculator
    {
        static int Plus(int first, int second)
        {
            int plusResult = first + second;

            return plusResult;
        }

        static int Minus(int first, int second)
        {
            int minusResult = first - second;

            return minusResult;
        }

        static int Multiply(int first, int second)
        {
            int multipliedResult = first * second;

            return multipliedResult;
        }

        static int Divide(int first, int second)
        {
            int divideResult = 0;

            try
            {
                divideResult = first / second;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("0으로 나눌 수 없습니다.");
            }

            return divideResult;
        }

        static int Mod(int first, int second)
        {
            int modResult = 0;

            try
            {
                modResult = first % second;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("0으로 나눌 수 없습니다.");
            }

            return modResult;
        }

        static int Square(int first, int second)
        {
            int squareResult = 1;

            for (int i = 0; i < second; i++)
            {
                squareResult *= first;
            }

            return squareResult;
        }

        static void Everything(int first, int second)
        {
            Console.WriteLine($"{first} + {second} = {Plus(first, second)}");
            Console.WriteLine($"{first} - {second} = {Minus(first, second)}");
            Console.WriteLine($"{first} * {second} = {Multiply(first, second)}");
            Console.WriteLine($"{first} / {second} = {Divide(first, second)}");
            Console.WriteLine($"{first} % {second} = {Mod(first, second)}");
            Console.WriteLine($"{first} ^ {second} = {Square(first, second)}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("두 수를 입력받아 계산하는 \"계산기\"입니다.\n");

            Console.WriteLine("원하는 연산의 숫자 중 하나를 골라 입력해주세요.");
            Console.WriteLine("1. +\n2. -\n3. *\n4. /\n5.%\n6. 제곱\n7. 위의 모든 연산\n");
            int expression = int.Parse(Console.ReadLine());

            Console.WriteLine("연산할 두 수를 하나씩 입력해주세요.");
            
            Console.Write("첫 번째 수: ");
            int firstNum = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("두 번째 수: ");
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine("연산 결과를 출력합니다.\n");

            switch (expression)
            {
                case 1:
                    Console.WriteLine($"{firstNum} + {secondNum} = {Plus(firstNum, secondNum)}");
                    break;

                case 2:
                    Console.WriteLine($"{firstNum} - {secondNum} = {Minus(firstNum, secondNum)}");
                    break;

                case 3:
                    Console.WriteLine($"{firstNum} * {secondNum} = {Multiply(firstNum, secondNum)}");
                    break;

                case 4:;
                    Console.WriteLine($"{firstNum} / {secondNum} = {Divide(firstNum, secondNum)}");
                    break;

                case 5:
                    Console.WriteLine($"{firstNum} % {secondNum} = {Mod(firstNum, secondNum)}");
                    break;

                case 6:
                    Console.WriteLine($"{firstNum} ^ {secondNum} = {Square(firstNum, secondNum)}");
                    break;

                case 7:
                    Everything(firstNum, secondNum);
                    break;
            }

            Console.ReadLine();
        }
    }
}
