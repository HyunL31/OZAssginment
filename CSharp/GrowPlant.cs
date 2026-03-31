using System;

namespace DailyAssignmentCSharp
{
    enum Environment
    {
        Sunlight,
        Water,
        Darkness,
        Nutrients
    }

    enum State
    {
        Seed,
        Sprout,
        Flower,
        Die,
        Dead
    }

    class Plant
    {
        private string _plantName;
        private Environment _environment;
        private State _plantState = State.Seed;
        private int _hp = 50;
        private int waterCount = 0;

        public Plant(string name, Environment environment)
        {
            this._plantName = name;
            this._environment = environment;
        }

        public string GetPlantName()
        {
            return this._plantName;
        }

        public void SetState(State state)
        {
            this._plantState = state;
        }

        public State GetState()
        {
            return this._plantState;
        }

        public int GetWaterCount()
        {
            return waterCount;
        }

        public Environment GetEnvironment()
        {
            return this._environment;
        }

        public void Watering()
        {
            this.waterCount++;
        }

        public void PrintState(Owner player)
        {
            if (this._plantState == State.Seed)
            {
                Console.WriteLine("아직 씨앗 상태입니다.\n물을 주세요.\n");
            }
            else if (this._plantState == State.Sprout)
            {
                Console.WriteLine($"{this._plantName} 이(가) 점점 자라고 있습니다.\n");
            }
            else if (this._plantState == State.Flower)
            {
                Console.WriteLine("꽃이 피어났습니다!\n");
                player.Win(this);
            }
            else if (this._plantState == State.Die)
            {
                Console.WriteLine($"{this._plantName} 이(가) 죽어가고 있습니다...\n긍정적인 감정이 필요합니다...\n");
            }
            else
            {
                Console.WriteLine($"{this._plantName} 이(가) 시들었습니다...\n");
                player.Lose(this);
            }
        }
    }

    class Owner
    {
        private string _ownerName;
        private int _sad = 0;
        private int _angry = 0;
        private int _calm = 0;
        private int _happy = 0;

        public Owner(string ownerName)
        {
            this._ownerName = ownerName;
        }

        public int GetSad()
        {
            return this._sad;
        }

        public int GetAngry()
        {
            return this._angry;
        }

        public int GetCalm()
        {
            return this._calm;
        }

        public int GetHappy()
        {
            return this._happy;
        }

        public string GetName()
        {
            return this._ownerName;
        }

        public void CalculateEmotion(int userToday)
        {
            if (userToday == 1)
            {
                this._sad += 10;
            }
            else if (userToday == 2)
            {
                this._angry += 10;
            }
            else if (userToday == 3)
            {
                this._calm += 10;
            }
            else if (userToday == 4)
            {
                this._happy += 10;
            }
        }

        public void WaterPlant(Plant plant)
        {
            plant.Watering();
        }

        public void Win(Plant plant)
        {
            Console.WriteLine($"성공적으로 {plant.GetPlantName()}을(를) 키웠습니다.\n축하드립니다!!");
        }

        public void Lose(Plant plant)
        {
            Console.WriteLine($"안타깝게 {plant.GetPlantName()}은(는) 시들었습니다...\n다시 시작해주세요...");
        }

        public void Normal(Plant plant)
        {
            Console.WriteLine($"꽃을 피우지는 못했지만 {plant.GetPlantName()}은(는) 건강합니다. 다시 시작해주세요.");
        }
    }

    internal class GrowPlant
    {
        static void Main(string[] args)
        {
            Console.WriteLine("당신의 이름은 무엇인가요?");
            Console.Write("이름: ");
            string ownerName = Console.ReadLine();

            Owner player = new Owner(ownerName);

            Console.WriteLine("키울 식물의 이름은 무엇인가요?");
            Console.Write("식물 이름: ");
            string plantName = Console.ReadLine();

            Console.WriteLine("현재의 감정은 어떤신가요?");
            Console.WriteLine("1. 슬픔\n2. 화남\n3. 차분함\n4. 행복함");

            int userEmotion = int.Parse(Console.ReadLine());

            Environment environment = Environment.Sunlight;

            if (userEmotion == 1)
            {
                environment = Environment.Water;
            }
            else if (userEmotion == 2)
            {
                environment = Environment.Darkness;
            }
            else if (userEmotion == 3)
            {
                environment = Environment.Sunlight;
            }
            else if (userEmotion == 4)
            {
                environment = Environment.Nutrients;
            }

            Plant plant = new Plant(plantName, environment);

            Console.WriteLine($"오늘부터 7일동안 {plant.GetPlantName()}을(를) 키우게 됩니다.\n무럭무럭 자라도록 잘 키워봅시다!");

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"\nDay {i + 1}");
                plant.PrintState(player);

                if (plant.GetState() == State.Flower || plant.GetState() == State.Dead)
                {
                    break;
                }

                Console.WriteLine("1을 눌러 물을 주세요.");
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1)
                {
                    player.WaterPlant(plant);
                }

                if ((i + 1) - plant.GetWaterCount() >= 5)
                {
                    plant.SetState(State.Dead);
                    break;
                }
                else if ((i + 1) - plant.GetWaterCount() >= 3)
                {
                    plant.SetState(State.Die);
                }

                Console.WriteLine("오늘의 감정은 어떠신가요?");
                Console.WriteLine("1. 슬픔\n2. 화남\n3. 차분함\n4. 행복함");
                int userToday = int.Parse(Console.ReadLine());

                player.CalculateEmotion(userToday);

                if (player.GetSad() >= 30 || player.GetAngry() >= 30)
                {
                    plant.SetState(State.Dead);
                    break;
                }

                if (plant.GetWaterCount() >= 6)
                {
                    plant.SetState(State.Flower);
                }
                else if (plant.GetWaterCount() >= 3)
                {
                    plant.SetState(State.Sprout);
                }
                else
                {
                    plant.SetState(State.Seed);
                }
            }

            if (plant.GetState() == State.Flower)
            {
                player.Win(plant);
            }
            else if (plant.GetState() == State.Dead)
            {
                player.Lose(plant);
            }
            else
            {
                player.Normal(plant);
            }

            Console.ReadLine();
        }
    }
}