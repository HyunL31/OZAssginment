#include <iostream>
#include <windows.h>	// Sleep()
#include <ctime>
#include <cstdlib>
#include <string>

using namespace std;

#define MAX_SIZE 15

enum Type
{
	Water,
	Fire,
	Air,
	Earth,
	TYPE_COUNT
};

float multiplier[TYPE_COUNT][TYPE_COUNT] = { {1.0, 1.5, 0.8, 1.2}, {0.7, 1.0, 1.5, 0.8}, {1.2, 0.8, 1.0, 1.5}, {1.5, 1.2, 0.7, 1.0} };

class Character
{
public:
	string name;
	string job;
	bool isAlive;
	int hp;
	int atk;
	int def;
	int gold;
	Type type;

	Character(string name, string job, bool isAlive, int hp, int atk, int def, int gold, Type type)
	{
		this->name = name;
		this->job = job;
		this->isAlive = isAlive;
		this->hp = hp;
		this->atk = atk;
		this->def = def;
		this->gold = gold;
		this->type = type;
	}

	virtual ~Character(){}

	virtual void Attack(Character* target)
	{
		cout << job << " " << name << "이(가) " << target->name << "을(를) 공격합니다!\n";
	}

	void Damage(Character* attacker, Character* defender)
	{
		int damage = (attacker->atk * multiplier[attacker->type][defender->type] - (defender->def * 0.3));

		if (damage <= 0)
		{
			damage = 0;
		}

		defender->hp -= damage;
		cout << attacker->name << "의 공격으로 " << defender->name << "이(가) -" << damage << "데미지를 입었습니다!\n";

		if (defender->hp <= 0)
		{
			defender->Die();
		}
	}

	virtual void Die()
	{
		cout << job << " " << name << "이(가) 사망하였습니다.\n\n";

		isAlive = false;
	}
};

class WaterBender : public Character
{
public:
	WaterBender(string name) :Character(name, "워터 밴더", true, 100, 100, 100, 0, Water) {}

	void Attack(Character* target) override
	{
		Character::Attack(target);

		cout << "쏟아지는 물로 뜨거운 전장을 차갑게 식힙니다!\n";
	}

	void Die() override
	{
		Character::Die();

		cout << "푸른 물결 속으로 조용히 스며듭니다...\n";
	}
};

class FireBender : public Character
{
public:
	FireBender(string name) :Character(name, "파이어 밴더", true, 100, 100, 100, 0, Fire) {}

	void Attack(Character* target) override
	{
		Character::Attack(target);

		cout << "타오르는 화염으로 맹렬한 공격을 펼칩니다!\n";
	}

	void Die() override
	{
		Character::Die();

		cout << "불꽃이 꺼지며 마지막 재가 바람에 흩어집니다...\n";
	}
};

class AirBender : public Character
{
public:
	AirBender(string name) :Character(name, "에어 밴더", true, 100, 100, 100, 0, Air) {}

	void Attack(Character* target) override
	{
		Character::Attack(target);

		cout << "휘몰아치는 태풍으로 부드럽게 공격을 이어나갑니다!\n";
	}

	void Die() override
	{
		Character::Die();

		cout << "흩어진 바람이 되어 세상에서 사라집니다...\n";
	}
};

class EarthBender : public Character
{
public:
	EarthBender(string name) :Character(name, "어스 밴더", true, 100, 100, 100, 0, Earth) {}

	void Attack(Character* target) override
	{
		Character::Attack(target);

		cout << "대지의 흔들림으로 적들이 서 있을 수 없습니다!\n";
	}

	void Die() override
	{
		Character::Die();

		cout << "대지에 돌아가 깊은 잠에 빠집니다...\n";
	}
};

class Monster : public Character
{
public:
	Monster(Type type) :Character("고블린", "몬스터", true, 90, 90, 90, 0, type) {}

	void Attack(Character* target) override
	{
		Character::Attack(target);

		cout << "비열하게 틈을 노려 공격합니다!\n";
	}

	void Die() override
	{
		Character::Die();

		cout << "몬스터가 비명을 지르며 쓰러집니다...\n";
	}
};

// 타이틀 씬 함수
int Title()
{
	int userInput;

	while (true)
	{
		cout << "=====================================\n" << "	    Vendor War\n" << "=====================================\n"
			<< "원하는 메뉴의 번호를 선택해주세요.\n\n" << "1. 게임 시작		2. 게임 방법\n" << "=====================================\n";

		cin >> userInput;

		if (userInput != 1 && userInput != 2)
		{
			cout << "잘못된 입력입니다.\n다시 입력해주세요.\n\n";

			Sleep(800);
		}
		else
		{
			system("cls");
			break;
		}
	}

	return userInput;
}

// 게임 방법 설명
void Rule()
{
	cout << "1. WASD 키를 이용해 움직일 수 있습니다.\n" << "2. ★는 당신이 서 있는 장소를 표시합니다.\n" << "3. ♥에 도착하면 당신은 \"비밀의 숲\"에서 탈출할 수 있습니다.\n"
		<< "4. ■에는 다양한 아이템을 획득할 수 있습니다.\n" << "5. 전투 중 아이템을 사용해 체력, 공격력, 방어력을 높일 수 있습니다.\n" << "6. ※에는 확정적으로 몬스터가 있으니 주의하세요.\n"
		<< "7. □은 비어있지만 일정 확률로 몬스터를 만날 수 있습니다.\n" << "8. 몬스터를 성공적으로 처치하면 일정 확률로 아이템을 얻을 수 있습니다.\n" << "9. 당신이 지나온 지역은 ●으로 표시됩니다.\n\n";

	cout << "계속하려면 아무 키나 입력하세요...\n";

	cin.ignore();
	cin.get();

	system("cls");
	Title();
}

// 게임 인트로
void Intro()
{
	cout << "물, Water.\n흙, Earth.\n불, Fire.\n공기, Air.\n각 원소를 하나씩 지배하는 4개의 나라가 조화를 이루며 살아가고 있습니다.\n"
		<< "하지만 얼마 전부터 대륙 중앙에 위치한 \"비밀의 숲\"에서 몬스터들이 나오기 시작했습니다.\n" << "희생자가 점차 늘어나자 각 나라의 지도자들은 각 원소를 다룰 수 있는 밴더들을 선발했습니다.\n"
		<< "그 밴더들은 몬스터들을 제거하기 위해 \"비밀의 숲\"으로 향했지만...\n" << "아직까지 그 누구도 돌아오지 못했습니다...\n" << "자, 이제는 당신의 차례입니다.\n"
		<< "과연 최고의 밴더인 당신은 무사히 \"비밀의 숲\"에서 살아남을 수 있을까요?\n\n";

	cout << "계속하려면 아무 키나 입력하세요...\n";

	cin.ignore();
	cin.get();

	system("cls");
}

// 몬스터, 아이템 스폰 함수
void ResetMap(string (*map)[MAX_SIZE])
{
	// 몬스터 추가
	for (int i = 0; i < MAX_SIZE; i++)
	{
		for (int j = 0; j < MAX_SIZE; j++)
		{
			int monsterNum = rand() % 5;

			if (monsterNum == 1)
			{
				map[i][j] = "※";
			}
		}
	}

	// 아이템 추가
	for (int i = 0; i < MAX_SIZE; i++)
	{
		for (int j = 0; j < MAX_SIZE; j++)
		{
			int itemNum = rand() % 8;

			if (itemNum == 1)
			{
				map[i][j] = "■";
			}
		}
	}

	// 플레이어, 도착지점 표시
	map[0][0] = "★";
	map[MAX_SIZE - 1][MAX_SIZE - 1] = "♥";
}

// 맵 출력 함수
void PrintMap(string (*map)[MAX_SIZE])
{
	for (int i = 0; i < MAX_SIZE; i++)
	{
		for (int j = 0; j < MAX_SIZE; j++)
		{
			cout << map[i][j] << " ";
		}

		cout << "\n";
	}
}

Character* PlayerFrom(string playerName)
{
	Character* player;

	while (true)
	{
		cout << "=====================================\n" << "당신의 출신지를 선택해주세요.\n\n"
			<< "1. 물의 부족	2. 불의 제국	3. 공기의 유목민	4. 흙의 왕국\n" << "=====================================\n";

		int userInput;
		cin >> userInput;

		if (userInput == 1)
		{
			player = new WaterBender(playerName);
			break;
		}
		else if (userInput == 2)
		{
			player = new FireBender(playerName);
			break;
		}
		else if (userInput == 3)
		{
			player = new AirBender(playerName);
			break;
		}
		else if (userInput == 4)
		{
			player = new EarthBender(playerName);
			break;
		}
		else
		{
			cout << "잘못된 입력입니다. 다시 입력해주세요.\n";
		}
	}

	return player;
}

void PrintPlayer(Character* player)
{
	cout << "=====================================\n" << "이름: " << player->name << "\n직업: " << player->job;
	
	if (player->hp <= 0)
	{
		cout << "\nHP: " << 0;
	}
	else
	{
		cout << "\nHP: " << player->hp;
	}

	cout << "\nATK: " << player->atk << "\nDEF: " << player->def << "\nGold: " << player->gold << "\n=====================================\n\n";
}

bool InRange(int x, int y)
{
	return 0 <= x && x < MAX_SIZE && y >= 0 && y < MAX_SIZE;
}

void CheckInventory(string(*inventory))
{
	for (int i = 0; i < 3; i++)
	{
		cout << i + 1 << ". " << inventory[i] << "\n";
	}
}

bool ExistItem(string (*inventory), string item)
{
	for (int i = 0; i < 3; i++)
	{
		if (inventory[i] == item)
		{
			return true;
		}
	}

	return false;
}

void MeetItem(string(*inventory))
{
	int emptyIdx = -1;
	int randomNum = rand() % 3;

	for (int i = 0; i < 3; i++)
	{
		if (inventory[i] == "Empty")
		{
			emptyIdx = i;
			break;
		}
	}

	if (emptyIdx == -1)
	{
		cout << "비어있는 인벤토리가 없습니다.\n\n";
	}
	else
	{
		if (randomNum == 0)
		{
			cout << "죽기싫어물약을 얻었습니다!\n\n";

			if (!ExistItem(inventory, "죽기싫어물약"))
			{
				inventory[emptyIdx] = "죽기싫어물약";
			}
			else
			{
				cout << "이미 획득한 아이템입니다.\n\n";
			}
		}
		else if (randomNum == 1)
		{
			cout << "한큐에끝포션을 얻었습니다!\n\n";

			if (!ExistItem(inventory, "한큐에끝포션"))
			{
				inventory[emptyIdx] = "한큐에끝포션";
			}
			else
			{
				cout << "이미 획득한 아이템입니다.\n\n";
			}
		}
		else if (randomNum == 2)
		{
			cout << "안아파연고을 얻었습니다!\n\n";

			if (!ExistItem(inventory, "안아파연고"))
			{
				inventory[emptyIdx] = "안아파연고";
			}
			else
			{
				cout << "이미 획득한 아이템입니다.\n\n";
			}
		}
	}
}

void UseItem(string (*inventory), int index, Character *player)
{
	string itemName = inventory[index];

	if (itemName == "Empty")
	{
		cout << "비어있는 인벤토리입니다.\n";
	}
	else
	{
		cout << itemName << "을(를) 사용합니다.\n";

		if (itemName == "죽기싫어물약")
		{
			player->hp += 10;
		}
		else if (itemName == "한큐에끝포션")
		{
			player->atk += 10;
		}
		else if (itemName == "안아파연고")
		{
			player->def += 10;
		}

		inventory[index] = "Empty";

		PrintPlayer(player);
	}
}

void Fight(Character *player, string (*inventory))
{
	Type type;

	int randomNum = rand() % 4;

	switch (randomNum)
	{
	case 0:
		type = Fire;
		break;

	case 1:
		type = Earth;
		break;

	case 2:
		type = Water;
		break;

	case 3:
		type = Air;
		break;
	}

	Monster* monster = new Monster(type);

	while (player->hp > 0 && monster->hp > 0)
	{
		cout << "=====================================\n" << "무엇을 할까요?\n" << "1. 공격하기\n2. 아이템 사용하기\n" << "=====================================\n";

		int userInput;
		cin >> userInput;

		if (userInput == 1)
		{
			player->Attack(monster);
			monster->Damage(player, monster);

			if (player->hp <= 0 || monster->hp <= 0)
			{
				break;
			}

			monster->Attack(player);
			player->Damage(monster, player);
		}
		else if (userInput == 2)
		{
			CheckInventory(inventory);
			cout << "4. 되돌아가기\n\n";

			cout << "무슨 아이템을 사용할까요?\n";
			cin >> userInput;

			if (userInput >= 1 && userInput <= 3)
			{
				UseItem(inventory, userInput - 1, player);
			}
			else if (userInput == 4)
			{
				continue;
			}
			else
			{
				cout << "잘못된 입력입니다.\n";
			}
		}
	}

	delete monster;

	cout << "전투가 종료되었습니다.\n";
	cout << "계속하려면 아무 키나 입력하세요...\n";

	cin.ignore();
	cin.get();
}

void MeetMonster(Character* player, string (*inventory))
{
	int randomNum = rand() % 3;

	if (randomNum == 1)
	{
		cout << "=====================================\n" << "숨어있던 몬스터와 마주쳤습니다!\n\n";

		while (true)
		{
			cout << "1. 도망가기\n2. 싸우기\n" << "=====================================\n";
			
			int input;
			cin >> input;

			if (input == 1)
			{
				randomNum = rand() % 2;

				if (randomNum == 1)
				{
					cout << "이런!! 들켰습니다! 전투를 준비하세요!\n\n";

					Fight(player, inventory);
				}
				else
				{
					cout << "다행히 잘 도망쳤습니다!!\n";

					cout << "계속하려면 아무 키나 입력하세요...\n";

					cin.ignore();
					cin.get();
				}

				break;
			}
			else if (input == 2)
			{
				Fight(player, inventory);

				break;
			}
			else
			{
				cout << "잘못된 입력입니다. 다시 입력해주세요.\n";
			}
		}
	}
}

void Battle(string (*map)[MAX_SIZE], string(*inventory), Character* player, int currentX, int currentY)
{
	if (map[currentX][currentY] == "■")
	{
		MeetItem(inventory);
		CheckInventory(inventory);

		cout << "\n계속하려면 아무 키나 입력하세요...\n";

		cin.ignore();
		cin.get();
	}
	else if (map[currentX][currentY] == "※")
	{
		cout << "몬스터가 등장했습니다!\n전투를 시작합니다!\n\n";

		Fight(player, inventory);
	}
	else if (map[currentX][currentY] == "□")
	{
		MeetMonster(player, inventory);
	}
}

void Move(string (*map)[MAX_SIZE], string (*inventory), Character *player)
{
	int currentX = 0;
	int currentY = 0;

	while (true)
	{
		int nx = currentX;
		int ny = currentY;

		char userInput;

		system("cls");
		PrintMap(map);

		cout << "\n\n모험을 시작합니다.\n" << "WASD 키로 움직여주세요.\n\n";
		cin >> userInput;

		if (userInput == 'W' || userInput == 'w')
		{
			nx--;
		}
		else if (userInput == 'S' || userInput == 's')
		{
			nx++;
		}
		else if (userInput == 'A' || userInput == 'a')
		{
			ny--;
		}
		else if (userInput == 'D' || userInput == 'd')
		{
			ny++;
		}
		else
		{
			cout << "잘못된 입력입니다.\n다시 입력해주세요.\n";
			Sleep(500);

			continue;
		}

		if (InRange(nx, ny))
		{
			map[currentX][currentY] = "●";
			currentX = nx;
			currentY = ny;

			Battle(map, inventory, player, currentX, currentY);

			if (!player->isAlive)
			{
				break;
			}

			map[currentX][currentY] = "★";
		}
		else
		{
			cout << "더이상 나아갈 수 없습니다.\n다시 이동해주세요.\n";
			Sleep(500);
		}

		if (currentX == MAX_SIZE - 1 && currentY == MAX_SIZE - 1)
		{
			system("cls");
			cout << "축하드립니다!! 무사히 도착했습니다!\n";

			player->gold += 100;

			break;
		}
	}
}

int main()
{
	srand(time(0));

	// 오프닝
	int userInput = Title();

	if (userInput == 1)
	{
		system("cls");

		Intro();
	}
	else if (userInput == 2)
	{
		Rule();
	}

	// 캐릭터 생성
	string playerName;

	cout << "당신의 이름은 무엇인가요?\n이름: ";
	cin >> playerName;

	Character* player = PlayerFrom(playerName);
	string inventory[3] = {};
	fill(inventory, inventory + 3, "Empty");

	system("cls");
	PrintPlayer(player);

	// 맵 생성
	string map[MAX_SIZE][MAX_SIZE] = {};
	fill(map[0], map[0] + (MAX_SIZE * MAX_SIZE), "□");
	ResetMap(map);

	cout << "계속하려면 아무 키나 입력하세요...\n";

	cin.ignore();
	cin.get();

	system("cls");

	Move(map, inventory, player);

	if (!player->isAlive)
	{
		cout << "Lose...\n\n";
		PrintPlayer(player);

		return 0;
	}

	cout << "Win!!\n\n";
	PrintPlayer(player);

	delete player;

	return 0;
}