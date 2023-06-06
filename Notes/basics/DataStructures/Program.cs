// See https://aka.ms/new-console-template for more information
string[] myGroceryArray = new string[2];

myGroceryArray[0] = "Guacamole";
myGroceryArray[1] = "Chips";
Console.WriteLine(myGroceryArray[0]);
Console.WriteLine(myGroceryArray[1]);

string[] myGroceryArray2 = { "Apples", "Eggs" };
Console.WriteLine(myGroceryArray2[0]);
Console.WriteLine(myGroceryArray2[1]);

List<string> myGroceryList = new List<string>() { "Milk", "Cheese" };
foreach (string item in myGroceryList)
{
    Console.WriteLine(item);
}
myGroceryList.Add("Bread");
Console.WriteLine(myGroceryList[2]);

IEnumerable<string> myGroceryIEnumerable = myGroceryList;
Console.WriteLine(myGroceryIEnumerable.First());

string[,] myTwoDimensionalArray = new string[,] {
    { "Apples", "Eggs" },
    { "Milk", "Cheese" }
};
Console.WriteLine(myTwoDimensionalArray[0, 0]);
Console.WriteLine(myTwoDimensionalArray[0, 1]);
Console.WriteLine(myTwoDimensionalArray[1, 0]);
Console.WriteLine(myTwoDimensionalArray[1, 1]);

Dictionary<string, string[]> myGroceryDictionary = new Dictionary<string, string[]>() {
    { "Dairy", new string[] {"Cheese", "Milk"} },

};

Console.WriteLine(myGroceryDictionary["Dairy"][0]);