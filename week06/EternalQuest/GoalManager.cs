using System.IO;
using System.Runtime.InteropServices.Marshalling;
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private int _pointsToNextLevel;
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
        _pointsToNextLevel = 100;
    }

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("");
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Create New Goal");
            Console.WriteLine(" 2. List Goals");
            Console.WriteLine(" 3. Save Goals");
            Console.WriteLine(" 4. Load Goals");
            Console.WriteLine(" 5. Record Event");
            Console.WriteLine(" 6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            Console.Clear();
            if (choice == "1")
            {
                CreateGoal();
            }

            else if (choice == "2")
            {
                ListGoalDetails();
            }

            else if (choice == "3")
            {
                SaveGoals();
            }

            else if (choice == "4")
            {
                LoadGoals();
            }

            else if (choice == "5")
            {
                RecordEvent();
            }

            else if (choice == "6")
            {
                Console.WriteLine("Thanks for using the program! Goodbye!");
            }

            else
            {
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    private void CheckLevelUp()
    {
        while (_score >= _pointsToNextLevel)
        {
            _level++;
            _pointsToNextLevel += 100;
            Console.WriteLine("\n=====================================");
            Console.WriteLine($"Congratulations! You’ve reached Level {_level}!");
            Console.WriteLine("You’ve earned a new reward!");
            GiveReward();
            Console.WriteLine("=====================================\n");
        }
    }

    
    private void GiveReward()
    {
        string[] rewards = {
            "Bronze Medal of Motivation!",
            "Silver Badge of Persistence!",
            "Golden Crown of Discipline!",
            "Platinum Star of Excellence!"
        };

        int rewardIndex = (_level - 1) % rewards.Length;
        Console.WriteLine($"You received: {rewards[rewardIndex]}");
        Console.WriteLine("");
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Points: {_score}/{_pointsToNextLevel}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are: ");
        int i = 0;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i + 1}. {goal.GetName()}");
            i++;
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are: ");
        int i = 0;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i + 1}. {goal.GetDetailsString()}");
            i++;
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string anwser = Console.ReadLine();
        Console.Write("What is the name of the goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string pointsGoal = Console.ReadLine();
        int points = int.Parse(pointsGoal);

        if (anwser == "1")
        {
            SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
            _goals.Add(simpleGoal);
        }

        else if (anwser == "2")
        {
            EternalGoal eternalGoal = new EternalGoal(name, description, points);
            _goals.Add(eternalGoal);
        }

        else if (anwser == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            string targetGoal = Console.ReadLine();
            int target = int.Parse(targetGoal);
            Console.Write("What is the bonus for accomplishing in that many times? ");
            string bonusGoal = Console.ReadLine();
            int bonus = int.Parse(bonusGoal);
            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
            _goals.Add(checklistGoal);
        }
        else
        {
            Console.WriteLine("Invalid choice. Press Enter to try again.");
            Console.ReadLine();
            Console.Clear();
        }

        Console.WriteLine($"Goal {name} has been created!");
    }

    public void RecordEvent()
    {
        ListGoalNames();
        
        Console.Write("What goal did you accomplish? ");
        string response = Console.ReadLine();
        int index = int.Parse(response) - 1;
        Goal selectedGoal = _goals[index];
        bool wasCompleteBefore = selectedGoal.IsComplete();
        selectedGoal.RecordEvent();
        _score += selectedGoal.GetPoints();
        if (selectedGoal is ChecklistGoal checklist && checklist.IsComplete() && !wasCompleteBefore)
        {
            _score += checklist.GetBonus();
        }
        Console.WriteLine($"Congratulations you have earned {selectedGoal.GetPoints()}");
        Console.WriteLine($"You now have {_score} points");
        CheckLevelUp();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Path.Combine(Directory.GetCurrentDirectory(), Console.ReadLine());

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_level);
            outputFile.WriteLine(_score);
            outputFile.WriteLine(_pointsToNextLevel);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Saving {_goals.Count} goals...");
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Path.Combine(Directory.GetCurrentDirectory(), Console.ReadLine());

        string[] lines = File.ReadAllLines(fileName);

        _level = int.Parse(lines[0]);
        _score = int.Parse(lines[1]);
        _pointsToNextLevel = int.Parse(lines[2]);

        for (int i = 3; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split("|");

            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (parts[0] == "SimpleGoal")
            {
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                bool isComplete = bool.Parse(parts[4]);
                simpleGoal.SetIsComplete(isComplete);

                _goals.Add(simpleGoal);
            }

            else if (parts[0] == "EternalGoal")
            {
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
            }

            else if (parts[0] == "ChecklistGoal")
            {
                int amountComplete = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int bonus = int.Parse(parts[6]);

                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                checklistGoal.SetAmountComplete(amountComplete);
                _goals.Add(checklistGoal);
            }
        }
        Console.WriteLine($"Loading {_goals.Count} goals...");
        Console.WriteLine("Goals loaded successfully!");
    }
}