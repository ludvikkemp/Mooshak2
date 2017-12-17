#include <iostream>
using namespace std;

int main()
{

int beers;

cout << "How many bottles of beer on the wall? ";
cin >> beers;

while (beers >=2)
{
    cout << beers << " bottles of beer on the wall, " << beers << " bottles of beer." << endl;
    cout << "Take one down and pass it around, " << --beers << " bottles of beer on the wall." << endl;
}

cout << 1 << " bottle of beer on the wall, " << 1 << " bottle of beer." << endl;
cout << "Take one down and pass it around, no more bottles of beer on the wall." << endl;

return 0;
}
