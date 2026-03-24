#include <iostream>
#include <string>

using namespace std;

int score = 0;

int CalculateScore(string magic)
{
	int extraScore = magic.length();

	return extraScore;
}

bool TextMagicAbility(string correct)
{
	cout << correct << " 주문을 입력하세요.\n";

	string userInput;
	// cin >> userInput;	"cin >> "은 공백 직전까지 입력 받음
	getline(cin, userInput);	// #include <string>

	if (correct == userInput)
	{
		score += CalculateScore(correct);

		return true;
	}

	return false;
}

string AssignDorm(int total)
{
	string dormitory = "";

	if (total >= 60)
	{
		dormitory = "레번클로";
	}
	else if (total >= 45)
	{
		dormitory = "슬리데린";
	}
	else if (total >= 30)
	{
		dormitory = "그리핀도르";
	}
	else
	{
		dormitory = "후플푸프";
	}

	return dormitory;
}

int main()
{
	string magicArr[6] = { "Avada Kedavra", "Wingardium Leviosa", "Lumos", "Aquamenti", "Expelliarmus", "Stupefy" };

	for (int i = 0; i < 6; i++)
	{
		if (!TextMagicAbility(magicArr[i]))
		{
			cout << "점수를 얻지 못했습니다.\n";
		}
		else
		{
			cout << "주문에 성공했습니다.\n";
		}

		cout << "\n";
	}

	cout << "당신은 " << AssignDorm(score) << "에 배정되었습니다.\n";

	return 0;
}