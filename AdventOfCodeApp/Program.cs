// See https://aka.ms/new-console-template for more information
using AdventOfCodeApp.Day1;

Console.WriteLine("THIS IS CRITICAL, WE NEED TO FIND THE CHIEF HISTORIAN");
Console.WriteLine("Without him, Christmas will be ruined!");
Console.WriteLine("We need to find him before it's too late!");
Console.WriteLine("==========================================================");

while (true)
{
    Console.WriteLine("Here is the set of tools to aid in finding him!");
    Console.WriteLine("Please select the required tool:");
    Console.WriteLine();
    Console.WriteLine("DAY 1 TOOLS:");
    Console.WriteLine("1. Historian's Office Search List Distance");
    Console.WriteLine("2. Historian's Office Search List Similarity");
    Console.WriteLine();

    var input = Console.ReadLine();
    Console.WriteLine("Please insert the path of the text file containing your input for this tool");
    var path = Console.ReadLine();
    try
    {
        var text = File.ReadAllText(path);

        switch (input)
        {
            case "1":
                var distanceSolver = new ListDistanceSolver();
                var distanceResult = distanceSolver.Solve(text);
                Console.WriteLine($"The distance score of the lists is: {distanceResult}");
                break;
            case "2":
                var similaritySolver = new ListSimilaritySolver();
                var similarityResult = similaritySolver.Solve(text);
                Console.WriteLine($"The similarity score of the lists is: {similarityResult}");
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("We have had an issue! All Elves to issue solving stations! Please retry...");
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("Press any key to return to the main menu...");
    Console.ReadKey();
    Console.Clear();
}
