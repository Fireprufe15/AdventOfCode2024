// See https://aka.ms/new-console-template for more information
using AdventOfCodeApp.Day1;

Console.WriteLine("THIS IS CRITICAL, WE NEED TO FIND THE CHIEF HISTORIAN");
Console.WriteLine("Without him, Christmas will be ruined!");
Console.WriteLine("We need to find him before it's too late!");
Console.WriteLine("==========================================================");
Console.WriteLine("Here is the set of tools to aid in finding him!");
Console.WriteLine("Please select the required tool:");
Console.WriteLine("1. Historian's Office Search List Distance");

var input = Console.ReadLine();
Console.WriteLine("Please insert the path of the text file containing your input for this tool");
var path = Console.ReadLine();
var text = File.ReadAllText(path);

switch (input)
{
    case "1":
        var solver = new ListDistanceSolver();
        var result = solver.Solve(text);
        Console.WriteLine($"The result is: {result}");
        break;
    default:
        Console.WriteLine("Invalid input");
        break;
}
