using System;
/* To exceed core requirements, I created a new goal type called "NegativeGoal" that allows users to track goals they want to avoid, 
such as "Stop procrastinating" or "Avoid junk food". This adds a new dimension to goal management, encouraging users to focus 
on positive habits while also being aware of negative ones. */

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}