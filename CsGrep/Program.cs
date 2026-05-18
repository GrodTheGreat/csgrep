foreach (string arg in args)
{
    Console.WriteLine(arg);
}
var prompt = Console.ReadLine();
if (prompt == null)
{
    System.Environment.Exit(1);
}
Console.WriteLine(prompt);
