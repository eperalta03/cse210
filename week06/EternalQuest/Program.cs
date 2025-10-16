// I added I added a level system, every 100 more points you reach a new level and get a prize.
// The current level is displayed with the total points

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}