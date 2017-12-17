#include <iostream>
using namespace std;

int main( )
{

    int input;

    //cout << "Input n: ";
    cin >> input;

    if (input <= 0)
        cout << "Input n:";
    else
        if (input % 2 == 0)
            cout << "Input n: " << input << " is even" <<endl;
        else
            cout << "Input n: " << input << " is odd" <<endl;
    input = input - 1;

    while (input > 0)
    {
        if (input % 2 == 0)
            cout << input << " is even" <<endl;
        else
            cout << input << " is odd" <<endl;
        input = input - 1;
    }
    return 0;
}
