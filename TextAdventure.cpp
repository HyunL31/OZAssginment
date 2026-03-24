#include <iostream>

using namespace std;

int day = 30;

enum State
{
	Alive,
	Death,
	Clear
};

class Player
{
public:
	string name;
	int hp;
	int food;
	int water;
	State state;

//private:
	// 지피티: Player 클래스 밖에서 생성자를 사용하고 있기 때문에 private으로 만들면 안된다.
	Player(string name, int hp, int food, int water, State state)
	{
		this->name = name;
		this->hp = hp;
		this->food = food;
		this->water = water;
		this->state = state;
	}
};

// 지피티: 매개변수는 값 복사이기에 변화가 반영되지 않는다. (그냥 Player player는 값 복사, &를 붙여줘야 참조 복사)
// 값을 바꾸지 않고 출력을 하는 함수이기에 만약을 대비해 const(상수) 추가
void CurrentState(const Player& player)
{
	cout << "-------------------------------------------------\n"
		<< "플레이어 이름: " << player.name << "\n" << "체력: " << player.hp << "\n" << "음식 지수: " << player.food << "\n" << "물 지수: " << player.water << "\n"
		<< "-------------------------------------------------\n";
}

// 값을 바꾸는 함수이므로 상수 X
void CheckState(Player& player)
{
	if (day <= 0 && player.hp > 0)
	{
		player.state = Clear;
		cout << "구조대가 도착할 때까지 무사히 살아남았습니다. 축하드립니다.\n";
	}
	else if (day >= 0 && (player.hp <= 0 || player.food <= 0 || player.water <= 0))
	{
		player.state = Death;
		cout << "안타깝게도 당신은 사망했습니다.\nRIP입니다.\n";
	}
}

void FightMonster(Player& player)
{
	int fightCount = rand() % 10;
	int deductHP = rand() % 30;

	for (int i = 0; i < fightCount; i++)
	{
		cout << "몬스터의 공격으로 " << deductHP << "데미지를 얻었습니다.\n";

		player.hp -= deductHP;

		cout << "몬스터를 공격하여 " << deductHP << "데미지를 주었습니다.\n";
	}
}

void Move(Player& player)
{
	// 구글링: 랜덤한 정수 가져오기 (% 최대 범위 + 최소 범위)
	int randomNum1 = rand() % 5 + 1;
	int randomNum2 = rand() % 10;
	int randomGet = rand() % 3;
	int randomMonster = rand() % 2;

	switch (randomNum1)
	{
	case 1:
	{
		day -= randomNum2;
		player.food -= 40;
		player.water -= 60;

		cout << "이동에 " << randomNum2 << "일이 소요되었습니다.\n음식 지수 -40\n물 지수 -60\n";
		break;
	}
	case 2:
	{
		day -= randomNum2;
		player.food -= 20;
		player.water -= 20;

		cout << "이동에 " << randomNum2 <<"일이 소요되었습니다.\n음식 지수 -20\n물 지수 -20\n";
		break;
	}
	case 3:
	{
		day -= randomNum2;
		player.food -= 40;
		player.water -= 60;

		cout << "이동에 " << randomNum2 << "일이 소요되었습니다.\n음식 지수 -40\n물 지수 -60\n";
		break;
	}
	case 4:
	{
		day -= randomNum2;
		player.food -= 50;
		player.water -= 60;

		cout << "이동에 " << randomNum2 << "일이 소요되었습니다.\n음식 지수 -50\n물 지수 -60\n";
		break;
	}
	}

	if (randomMonster == 1)
	{
		FightMonster(player);
	}
	else
	{
		cout << "안전한 지역입니다.\n";
	}
	
	if (randomGet == 0)
	{
		player.water += 20;
		cout << "물을 얻었습니다.\n+물\n";
	}
	else if (randomGet == 1)
	{
		player.food += 20;
		cout << "과일을 얻었습니다.\n+음식\n";
	}
	else
	{
		player.hp += 10;
		cout << "의문의 식물을 얻었습니다.\n+체력\n";
	}

	CurrentState(player);
	CheckState(player);
}

int main()
{
	cout << "-------------------------------------------------\n" << "당신은 미지의 행성에 탐사를 나왔다가 고립되었습니다.\n"
		<< "지구에서 보낸 구조대가 도착하기까지는 30일의 시간이 남았습니다.\n"
		<< "그 전에 죽지 않고 살아남을 수 있도록 이 행성을 탐사하세요.\n"
		<< "※경고: 행성의 곳곳에는 위험이 도사리고 있습니다.※\n"
		<< "※경고: 음식 지수, 물 지수, 체력이 0이 되면 사망합니다.※\n"
		<< "-------------------------------------------------\n";

	// 원래 코드: Player player = new Player("User", 100, 100, 100, Alive);
	// 지피티의 수정 결과: 객체 자체를 스택 영역에 생성하였기에 new 사용 X (Player* player 이면 위 코드가 맞다... 잘 모르겟다...)
	Player player("User", 100, 100, 100, Alive);

	cout << "당신의 이름을 알려주세요.\n";
	cin >> player.name;

	player.hp = 100;
	player.food = 100;
	player.water = 100;

	CurrentState(player);

	while (true)
	{
		cout << "-------------------------------------------------\n" << "이동할 지역의 번호를 선택해 주세요.\n"
			<< "1. 동쪽\n" << "2. 서쪽\n" << "3. 남쪽\n" << "4. 북쪽\n" << "5. 게임 종료\n" << "-------------------------------------------------\n";

		int playerChoice;
		cin >> playerChoice;

		if (playerChoice < 0 || playerChoice > 4)
		{
			cout << "이동할 수 없는 장소입니다. 다시 선택해주세요.\n";
			
			continue;
		}
		else if (playerChoice == 5)
		{
			cout << "게임을 종료합니다. 감사합니다.\n";
			return 0;
		}

		Move(player);
	
		if (player.state == Death || player.state == Clear)
		{
			return 0;
		}
	}

	return 0;
}