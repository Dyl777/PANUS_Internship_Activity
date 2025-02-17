using System;
using System.Collections.Generic;
using System.Linq;
using Google.OrTools.LinearSolver;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

class Location
{
    public string Name { get; set; }
    public double Cost { get; set; }
    public double ProbabilityOfHigherCost { get; set; }
    public double ExpectedDays { get; set; }
    public int RequiredTeammates { get; set; }
    public int Routers { get; set; }
    public int PCs { get; set; }
    public int Laptops { get; set; }
    public double DealProbability { get; set; }
    public Dictionary<string, double> Distances { get; set; } = new();
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}

class Program
{
    static List<Location> GreedyHeuristic(List<Location> locations, double budget, int maxTeammates)
    {
        var sortedLocations = locations.OrderByDescending(l => l.DealProbability / (l.Cost * (1 + l.ProbabilityOfHigherCost))).ToList();
        List<Location> selectedLocations = new();
        double remainingBudget = budget;
        int remainingTeammates = maxTeammates;
        
        foreach (var loc in sortedLocations)
        {
            double adjustedCost = loc.Cost * (1 + loc.ProbabilityOfHigherCost);
            if (remainingBudget >= adjustedCost && remainingTeammates >= loc.RequiredTeammates)
            {
                selectedLocations.Add(loc);
                remainingBudget -= adjustedCost;
                remainingTeammates -= loc.RequiredTeammates;
            }
        }
        return selectedLocations;
    }
    
    static List<Location> SolveMIP(List<Location> locations, double budget, int maxTeammates)
    {
        var solver = Solver.CreateSolver("SCIP");
        Dictionary<Location, Variable> locationVars = new();
        
        foreach (var loc in locations)
            locationVars[loc] = solver.MakeIntVar(0, 1, loc.Name);
        
        var budgetConstraint = solver.MakeConstraint(0, budget);
        foreach (var loc in locations)
            budgetConstraint.SetCoefficient(locationVars[loc], loc.Cost * (1 + loc.ProbabilityOfHigherCost));
        
        var teamConstraint = solver.MakeConstraint(0, maxTeammates);
        foreach (var loc in locations)
            teamConstraint.SetCoefficient(locationVars[loc], loc.RequiredTeammates);
        
        Objective objective = solver.Objective();
        foreach (var loc in locations)
            objective.SetCoefficient(locationVars[loc], loc.DealProbability);
        
        objective.SetMaximization();
        solver.Solve();
        
        List<Location> selectedLocations = new();
        foreach (var loc in locations)
        {
            if (locationVars[loc].SolutionValue() == 1)
                selectedLocations.Add(loc);
        }
        return selectedLocations;
    }
    
    static void Main()
    {
        List<Location> locations = new List<Location>
        {
            new Location { Name = "A", Cost = 1000, ProbabilityOfHigherCost = 0.2, ExpectedDays = 3, RequiredTeammates = 2, Routers = 1, PCs = 2, Laptops = 1, DealProbability = 0.9, Latitude = 40.7128, Longitude = -74.0060 },
            new Location { Name = "B", Cost = 1500, ProbabilityOfHigherCost = 0.1, ExpectedDays = 2, RequiredTeammates = 1, Routers = 2, PCs = 1, Laptops = 2, DealProbability = 0.8, Latitude = 34.0522, Longitude = -118.2437 },
            new Location { Name = "C", Cost = 1200, ProbabilityOfHigherCost = 0.3, ExpectedDays = 4, RequiredTeammates = 3, Routers = 1, PCs = 3, Laptops = 1, DealProbability = 0.7, Latitude = 51.5074, Longitude = -0.1278 }
        };
        
        double totalBudget = 5000;
        int maxTeammates = 5;
        
        Console.WriteLine("Using MIP Optimization:");
        var mipSolution = SolveMIP(locations, totalBudget, maxTeammates);
        mipSolution.ForEach(loc => Console.WriteLine(loc.Name));
        
        Console.WriteLine("\nUsing Greedy Heuristic:");
        var greedySolution = GreedyHeuristic(locations, totalBudget, maxTeammates);
        greedySolution.ForEach(loc => Console.WriteLine(loc.Name));
        
        Console.WriteLine("\nEnter a location that failed: ");
        string failedLocation = Console.ReadLine();
        
        locations.RemoveAll(l => l.Name == failedLocation);
        Console.WriteLine("\nRe-optimized Order After Failure:");
        var newSolution = GreedyHeuristic(locations, totalBudget, maxTeammates);
        newSolution.ForEach(loc => Console.WriteLine(loc.Name));
        
        // OpenMap API visualization trigger
        Console.WriteLine("\nGenerating Map View...");
        string mapData = string.Join("|", newSolution.Select(loc => $"{loc.Latitude},{loc.Longitude}"));
        Console.WriteLine("Map Data: " + mapData);
        
        Console.WriteLine("\nView on OpenMap: https://www.openstreetmap.org/?mlat=" + newSolution.First().Latitude + "&mlon=" + newSolution.First().Longitude);
    }
}
