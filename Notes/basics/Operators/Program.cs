// See https://aka.ms/new-console-template for more information
int myInt = 5;
int mySecondInt = 10;

Console.WriteLine(myInt.Equals(mySecondInt));
Console.WriteLine(myInt.Equals(mySecondInt / 2));
Console.WriteLine(myInt == mySecondInt);

myInt++;
Console.WriteLine(myInt);

myInt+=7;
Console.WriteLine(myInt);

myInt-=8;
Console.WriteLine(myInt * mySecondInt);
Console.WriteLine(mySecondInt / myInt);

Console.WriteLine(Math.Pow(5,4));
Console.WriteLine(Math.Sqrt(25));

string myString = "test";
myString += ". \"\"second part.";
Console.WriteLine(myString);

string[] myStringArr = myString.Split(".");
Console.WriteLine(myStringArr[0]);