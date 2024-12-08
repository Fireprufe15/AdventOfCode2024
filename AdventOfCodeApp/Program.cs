﻿// See https://aka.ms/new-console-template for more information
using AdventOfCodeApp.Day1;
using AdventOfCodeApp.Day2;
using AdventOfCodeApp.Day3;
using AdventOfCodeApp.Day4;
using AdventOfCodeApp.Day5;
using AdventOfCodeApp.Day6;
using AdventOfCodeApp.Day7;

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
    Console.WriteLine("DAY 4 TOOLS:");
    Console.WriteLine("7. Deranged Word Search Solver");
    Console.WriteLine("8. Even more deranged X-MAS Solver");
    Console.WriteLine();
    Console.WriteLine("DAY 5 TOOLS:");
    Console.WriteLine("9. Print request correct order solver");
    Console.WriteLine("10. Print request incorrect order solver");
    Console.WriteLine();
    Console.WriteLine("DAY 6 TOOLS:");
    Console.WriteLine("11. Guard Route Map Parser");
    Console.WriteLine("12. Guard Route Path Solver");
    Console.WriteLine();
    Console.WriteLine("DAY 7 TOOLS:");
    Console.WriteLine("13. Operator checker");
    Console.WriteLine("14. Operator checker with concat");
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
            case "7":
                var wordSearchXmasCount = DerangedWordSearchSolver.Solve(text);
                Console.WriteLine($"The number of XMAS words found is: {wordSearchXmasCount}");
                break;
            case "8":
                var xmasCount = XSolver.Solve(text);
                Console.WriteLine($"The number of XMAS crosses found is: {xmasCount}");
                break;
            case "9":
                var correctOrder = CorrectOrderPrintRequestCalculator.Solve(text);
                Console.WriteLine($"The sum of middle numbers of the correct order print requests is: {correctOrder}");
                break;                  
            case "10":
                var incorrectOrder = CorrectOrderPrintRequestCalculator.Solve(text, true);
                Console.WriteLine($"The sum of middle numbers of the incorrect order print requests after correction is: {incorrectOrder}");
                break;
            case "11":
                var guardPositions = GuardRoutePathSolver.SolveForPositions(text);
                Console.WriteLine($"The number of guard positions is: {guardPositions}");
                break;
            case "12":
                var guardPaths = GuardRoutePathSolver.SolveForPositions(text, true);
                Console.WriteLine($"The number of loopable obstacle positions is: {guardPaths}");
                break;
            case "13":
                var operatorCount = OperatorSolver.Solve(text);
                Console.WriteLine($"The calibration result is: {operatorCount}");
                break;
            case "14":
                var operatorCountWithconcat = OperatorSolver.Solve(text, true);
                Console.WriteLine($"The calibration result is: {operatorCountWithconcat}");
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
