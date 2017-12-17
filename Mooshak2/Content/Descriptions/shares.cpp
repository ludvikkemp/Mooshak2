#include <iostream>
#include <iomanip>

using namespace std;

void readShares(int& sha);
void readPrice(int& dol, int& num, int& den);
double calcPrice(int sha, int dol, int num, int den);
void writeOutput(int sha, int dol, int num, int den, double price);

int main()
{
int sha, dol, num, den;
char letterY = 'y';
char x = 'y';
while (x == letterY)
{
    readShares(sha);
    readPrice(dol, num, den);
    double price = calcPrice(sha, dol, num, den);
    writeOutput(sha, dol, num, den, price);
    cout << "Continue: ";
    cin >> x;
}
return 0;
}


void readShares(int& sha)
{
    cout << "Enter number of shares: ";
    cin >> sha;
return;
}

void readPrice(int& dol, int& num, int& den)
{
    cout << "Enter price (dollars, numerator, denominator) : ";
    cin >> dol, cin >> num, cin >> den;
return;
}

double calcPrice(int sha, int dol, int num, int den)
{
    double price = sha*(dol + (num/(double)den));

return price;
}

void writeOutput(int sha, int dol, int num, int den, double price)
{
    cout << sha << " shares with market price " << dol << " " << num << "/" << den << " have value $" << showpoint << fixed << setprecision(2)<< price << endl;
return;
}
