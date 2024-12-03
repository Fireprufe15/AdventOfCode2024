// See https://aka.ms/new-console-template for more information
using AdventOfCodeApp.Day1;
using AdventOfCodeApp.Day2;
using AdventOfCodeApp.Day3;

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
    Console.WriteLine("DAY 2 TOOLS:");
    Console.WriteLine("3. Red-Nose Reactor Report Safety Analyser");
    Console.WriteLine("4. Red-Nose Reactor Report Safety Analyser with Problem Dampener");
    Console.WriteLine();
    Console.WriteLine("DAY 3 TOOLS:");
    Console.WriteLine("5. Toboggan Shop Decorruptor Tool");
    Console.WriteLine("6. Toboggan Shop Decorruptor Tool with Conditionals");
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
                var distanceResult = ListDistanceSolver.Solve(text);
                Console.WriteLine($"The distance score of the lists is: {distanceResult}");
                break;
            case "2":
                var similarityResult = ListSimilaritySolver.Solve(text);
                Console.WriteLine($"The similarity score of the lists is: {similarityResult}");
                break;
            case "3": 
                var safetyResult = ReportSafetySolver.Solve(text);
                Console.WriteLine($"The number of safe reports is: {safetyResult}");
                break;
            case "4":
                var safetyResultWithDampener = ReportSafetySolver.Solve(text, true);
                Console.WriteLine($"The number of safe reports when using the problem dampener is: {safetyResultWithDampener}");
                break;
            case "5":
                var decorruptedResult = TobogganComputerMemoryUncorruptCalculator.Solve(text);
                Console.WriteLine($"The sum of decorrupted multiplications is: {decorruptedResult}");
                break;
            case "6":
                var decorruptedResultWithConditionals = TobogganComputerMemoryUncorruptCalculator.Solve(text, true);
                Console.WriteLine($"The sum of decorrupted multiplications is: {decorruptedResultWithConditionals}");
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("We have had an issue! All Elves to issue solving stations! Please retry...");
        Console.WriteLine("The magnificent jolly elf supercomputer has identified the following as the issue:");
        Console.WriteLine(ex.Message);
    }

    Console.WriteLine("Press any key to return to the main menu...");
    Console.ReadKey();
    Console.Clear();
}
