#include <iostream>
#include <ctime>
#include <cstdlib>

using namespace std;

bool CheckInput(int userInput)
{
	if (userInput >= 10 || userInput < 0)
	{
		cout << "잘못된 입력입니다. 다시 입력해주세요.\n";

		return false;
	}

	return true;
}

// 사용자 입력 함수
void UserInput(int& userX, int& userY)
{
	while (true)
	{
		cout << "X 좌표를 입력해주세요. (0 <= X <= 9)\n";
		cin >> userX;

		if (CheckInput(userX))
		{
			break;
		}
	}

	while (true)
	{
		cout << "Y 좌표를 입력해주세요. (0 <= Y <= 9)\n";
		cin >> userY;

		if (CheckInput(userY))
		{
			break;
		}
	}
}

int main()
{
	srand(time(NULL));
	int arr[10][10] = { 0 };

	// 배열에 빈칸, 아이템, 몬스터 채워넣기
	// 아이템 구역이 초반에 몰려 있음
	/*
	int itemCount = 0;
	
	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			int treasure = rand() % 3;

			if (treasure == 1)
			{
				itemCount++;

				if (itemCount > 3)
				{
					arr[i][j] = 2;
				}
				else
				{
					arr[i][j] = 1;
				}
			}
			else
			{
				arr[i][j] = treasure;
			}
		}
	}*/

	// 몬스터 추가
	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			int monster = rand() % 4;

			if (monster == 1)
			{
				arr[i][j] = 2;
			}
		}
	}

	// 아이템 추가
	for (int i = 0; i < 3; i++)
	{
		int randomX = rand() % 10;
		int randomY = rand() % 10;

		arr[randomX][randomY] = 1;
	}

	// 결과에 따른 루프
	while (true)
	{
		int userX, userY;
		UserInput(userX, userY);

		if (arr[userX][userY] == 0)
		{
			cout << "아무것도 없는 지역입니다. 다시 입력해주세요.\n";
		}
		else if (arr[userX][userY] == 1)
		{
			cout << "아이템을 획득했습니다. 성공입니다!\n";
			break;
		}
		else
		{
			cout << "몬스터가 들끓고 있는 지역입니다. Game Over!\n";
			break;
		}
	}

	cout << "\n맵을 출력합니다.\n\n";

	// 배열 출력
	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j < 10; j++)
		{
			cout << arr[i][j] << " ";
		}

		cout << "\n";
	}

	return 0;
}