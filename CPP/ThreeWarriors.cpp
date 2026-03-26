#include <iostream>

using namespace std;

enum Type
{
	Deal,
	Tank,
	Heal
};

class Character
{
public:
	string name;
	Type type;
	int hp;
	int atk;
	int def;

	Character(string name, Type type, int hp, int atk, int def)
	{
		this->name = name;
		this->type = type;
		this->hp = hp;
		this->atk = atk;
		this->def = def;
	}

	~Character(){}

	virtual void Attack(){}

	void TakeDamage(Character* target)
	{
		cout << target->name << "이(가) 공격을 받았습니다.\n";

		int random = rand() % 150;

		// 제미나이의 수정: 나누기 사용할 때 조심하기!!
		// 0으로 나눌 경우 바로 런타임 에러 발생 (+1 해주거나 max() 함수 사용하기)
		int damage = (this->atk / (target->def / 10 + 1)) + random;
		target->hp -= damage;

		cout << target->name << "이(가) -" << damage << "데미지를 받았습니다.\n\n";
	}

	void Dead()
	{
		cout << name << "이(가) 사망했습니다.\n\n";
	}
};

// 상속에도 접근 제어자가 있다...?
// C++에서 클래스는 기본적으로 private으로 상속
// 구조체가 public으로 상속
class Archer : public Character
{
public:
	Archer() : Character("궁수", Deal, 150, 200, 150) {}

	~Archer(){}

	void Attack() override
	{
		cout << name << "가 열심히 활을 이용해 공격합니다.\n";
	}
};

class Guardian : public Character
{
public:
	Guardian() : Character("가디언", Tank, 150, 150, 200){}

	~Guardian(){}

	void Attack() override
	{
		cout << name << "이 열심히 몸으로 공격합니다.\n";
	}
};

class Priest : public Character
{
public:
	Priest() : Character("프리스트", Heal, 100, 200, 200){}

	~Priest(){}

	void Attack() override
	{
		int random = rand() % 30;

		cout << name << "가 열심히 마법으로 공격합니다.\n" << "동시에 치료를 시작합니다.\n";

		this->hp += random;

		cout << name << "의 HP가 " << random << "증가했습니다.\n";
	}
};

int main()
{
	cout << "----------------------    " << "세 낭만 용사" << "    ----------------------\n";

	srand(time(0));

	Priest* priest = new Priest();
	Archer* archer = new Archer();
	Guardian* guardian = new Guardian();

	int userInput;

	while (true)
	{
		cout << "----------------------\n" << "당신의 캐릭터를 선택해주세요.\n" << "1. 궁수   2. 가디언   3. 프리스트\n" << "----------------------\n";
		cin >> userInput;

		if (userInput < 1 || userInput > 3)
		{
			cout << "잘못된 번호입니다. 다시 선택해주세요.\n";
			continue;
		}
		else
		{
			break;
		}
	}

	Character* warriors[3] = { priest, archer, guardian };

	Character* player = nullptr;

	if (userInput == 1)
	{
		player = archer;
	}
	else if (userInput == 2)
	{
		player = guardian;
	}
	else
	{
		player = priest;
	}

	int dead = 0;

	while (dead < 2)
	{

		for (int i = 0; i < 3; i++)
		{
			if (warriors[i]->hp <= 0)
			{
				continue;
			}

			for (int j = 0; j < 3; j++)
			{
				if (i == j || warriors[j]->hp <= 0)
				{
					continue;
				}

				warriors[i]->Attack();
				warriors[i]->TakeDamage(warriors[j]);

				if (warriors[j]->hp <= 0)
				{
					warriors[j]->Dead();

					dead++;
				}

				if (dead >= 2)
				{
					break;
				}
			}

			cout << "----------------------------\n";

			for (int j = 0; j < 3; j++)
			{
				cout << warriors[j]->name << ": ";

				if (warriors[j]->hp <= 0)
				{
					cout << "사망\n";
				}
				else
				{
					cout << warriors[j]->hp << "\n";
				}
			}

			cout << "----------------------------\n";

			if (dead >= 2)
			{
				break;
			}
		}
	}

	Character* winner = nullptr;

	for (int i = 0; i < 3; i++)
	{
		if (warriors[i]->hp > 0)
		{
			winner = warriors[i];
		}
	}

	cout << "승자는 " << winner->name << "입니다.\n";

	if (winner == player)
	{
		cout << "당신이 승리했습니다. 축하합니다.\n";
	}
	else
	{
		cout << "당신은 승리하지 못했습니다. Game Over!!\n";
	}

	// 까먹고 안한 부분...
	// new 키워드로 생성한 메모리는 힙 영역에 저장
	// 힙 영역에서는 스택 영역과 반대로 자동으로 메모리 해제가 안된다.
	// 따라서 delete로 메모리 해제를 꼭 해줘야 한다.
	// delete 키워드 사용 시 자동으로 소멸자가 실행된다.
	delete priest;
	delete archer;
	delete guardian;

	return 0;
}