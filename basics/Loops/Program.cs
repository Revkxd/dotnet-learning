// See https://aka.ms/new-console-template for more information
int[] intsToCompress = new int[] {10, 15, 20, 25, 30, 12, 34};

DateTime start = DateTime.Now;
int totalValue = intsToCompress[0] + intsToCompress[1] + intsToCompress[2] + intsToCompress[3] + intsToCompress[4] + intsToCompress[5] + intsToCompress[6];
Console.WriteLine(DateTime.Now - start);
// Console.WriteLine(totalValue);
// Total is 146

totalValue = 0;
start = DateTime.Now;
for(int i=0; i < intsToCompress.Length; i++)
{
    totalValue += intsToCompress[i];
}
Console.WriteLine(DateTime.Now - start);
// Console.WriteLine(totalValue);
// Total is 146

totalValue = 0;
start = DateTime.Now;
foreach(int intForCompression in intsToCompress)
{
    totalValue += intForCompression;
}
Console.WriteLine(DateTime.Now - start);

totalValue = 0;
int index = 0;
start = DateTime.Now;
while(index < intsToCompress.Length)
{
    totalValue += intsToCompress[index];
    index++;
}
Console.WriteLine(DateTime.Now - start);

totalValue = 0;
index = 0;
start = DateTime.Now;
do
{
    totalValue += intsToCompress[index];
    index++;
} while(index < intsToCompress.Length);
Console.WriteLine(DateTime.Now - start);

totalValue = 0;
start = DateTime.Now;
Console.WriteLine(intsToCompress.Sum());
Console.WriteLine(DateTime.Now - start);

totalValue = 0;
foreach(int intForCompression in intsToCompress)
{
    totalValue += intForCompression > 20 ? intForCompression : 0;
}
Console.WriteLine(totalValue);