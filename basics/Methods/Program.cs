// See https://aka.ms/new-console-template for more information
class Program
{
    static private int GetSum(int[] intsToCompress) {
        int totalValue = 0;
        foreach(int intForCompression in intsToCompress)
        {
            totalValue += intForCompression;
        }
        return totalValue;
    }
    static void Main(string[] args)
    {
        int[] intsToCompress = new int[] {23, 23, 53, 56, 83, 92};
        int sum = GetSum(intsToCompress);
        Console.WriteLine($"The sum is {sum}");
    }
}
