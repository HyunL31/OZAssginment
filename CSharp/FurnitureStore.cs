using System;
using System.Collections.Generic;

namespace DailyAssignmentCSharp
{

    internal class FurnitureStore
    {
        public class Furniture
        {
            private int _id;
            private string _name;
            private string _description;

            public void Init (int id, string name, string description)
            {
                this._id = id;
                this._name = name;
                this._description = description;
            }

            public int GetId()
            {
                return this._id;
            }

            public string GetName()
            {
                return this._name;
            }

            public string GetDescription()
            {
                return this._description;
            }
        }

        public class Store
        {
            private Dictionary<string, Furniture> _todayFurniture = new Dictionary<string, Furniture>();
            private int _money = 0;

            public Dictionary<string, Furniture> GetDict()
            {
                return this._todayFurniture;
            }

            public int GetMoney()
            {
                return this._money;
            }

            public void AddMoney(int money)
            {
                this._money += money;
            }

            public void BringTodayFurniture()
            {
                Console.WriteLine("오늘의 가구가 들어왔습니다. 총 10개입니다.");

                for (int i = 0; i < 10; i++)
                {
                    Furniture furniture = new Furniture();

                    Console.WriteLine("가구의 이름을 입력해주세요.");
                    string furnitureName = Console.ReadLine();
                    Console.WriteLine("가구의 기능을 입력해주세요.");
                    string furnitureDes = Console.ReadLine();

                    furniture.Init(i + 1, furnitureName, furnitureDes);

                    this._todayFurniture.Add(furnitureName, furniture);
                }
            }

            public void OpenStore()
            {
                Console.WriteLine("==============가구 상점 카탈로그==============");

                foreach (Furniture furniture in this._todayFurniture.Values)
                {
                    Console.WriteLine($"- 가구 ID: {furniture.GetId()}\n- 가구 이름: {furniture.GetName()}\n- 가구 설명: {furniture.GetDescription()}\n");
                }

                Console.WriteLine("==============================================");
            }
        }

        static void Main(string[] args)
        {
            Store store = new Store();
            int furnitureId = 11;

            Console.WriteLine("마법의 가구 상점에 오신 것을 환영합니다!\n");

            store.BringTodayFurniture();

            while (true)
            {
                Console.WriteLine("무엇을 할까요?\n");

                Console.WriteLine("1. 상점 열기 (재고 확인)\n2. 가구 분쇄\n3. 가구 구매\n4. 가구 판매\n5. 정산\n6. 종료하기");
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    store.OpenStore();
                }
                else if (userInput == 2)
                {
                    Console.WriteLine("분쇄할 가구의 이름을 입력해주세요.");
                    string furnitureName = Console.ReadLine();

                    if (!store.GetDict().ContainsKey(furnitureName))
                    {
                        Console.WriteLine("찾으시는 가구가 없습니다.");
                        continue;
                    }

                    store.GetDict().Remove(furnitureName);
                    Console.WriteLine($"{furnitureName}을(를) 분쇄하였습니다.");

                    store.AddMoney(100);
                    Console.WriteLine($"목재를 팔아 100원을 받았습니다.");
                }
                else if (userInput == 3)
                {
                    if (store.GetMoney() < 100)
                    {
                        Console.WriteLine("현재 돈이 100원 이하입니다.\n추가 가구를 구매할 수 없습니다.");
                        continue;
                    }

                    Console.WriteLine("가구의 이름을 입력해주세요.");
                    string furnitureName = Console.ReadLine();

                    Console.WriteLine("가구의 설명을 입력해주세요.");
                    string furnitureDes = Console.ReadLine();

                    if (store.GetDict().ContainsKey(furnitureName))
                    {
                        Console.WriteLine("이미 있는 가구입니다.");
                        continue;
                    }

                    store.AddMoney(-100);
                    Console.WriteLine("100원으로 가구를 구매했습니다.");

                    Furniture furniture = new Furniture();
                    furniture.Init(furnitureId, furnitureName, furnitureDes);
                    furnitureId++;

                    store.GetDict().Add(furnitureName, furniture);
                }
                else if (userInput == 4)
                {
                    Console.WriteLine("판매할 가구의 이름을 입력해주세요.");
                    string furnitureName = Console.ReadLine();

                    if (!store.GetDict().ContainsKey(furnitureName))
                    {
                        Console.WriteLine("찾으시는 가구가 없습니다.");
                        continue;
                    }

                    store.GetDict().Remove(furnitureName);
                    Console.WriteLine("가구를 판매해 100원을 벌었습니다.");

                    store.AddMoney(100);
                }
                else if (userInput == 5)
                {
                    Console.WriteLine($"현재 가게가 가진 돈은 {store.GetMoney()}원 입니다.");
                }
                else if (userInput == 6)
                {
                    Console.WriteLine("오늘 영업을 마감합니다. 감사합니다.");
                    break;
                }
            }
        }
    }
}
