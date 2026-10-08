using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine($"\nYou have {score} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine("  1. Simple Goal");
                Console.WriteLine("  2. Eternal Goal");
                Console.WriteLine("  3. Checklist Goal");
                Console.Write("Which type of goal would you like to create? ");
                string type = Console.ReadLine();

                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string desc = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                string points = Console.ReadLine();

                if (type == "1")
                {
                    goals.Add(new SimpleGoal(name, desc, points));
                }
                else if (type == "2")
                {
                    goals.Add(new EternalGoal(name, desc, points));
                }
                else if (type == "3")
                {
                    Console.Write("How many times does this goal need to be accomplished? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    int bonus = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nThe goals are:");
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {goals[i].GetDetailsString()}");
                }
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename for the goal file? ");
                string filename = Console.ReadLine();

                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(score);
                    foreach (Goal g in goals)
                    {
                        writer.WriteLine(g.GetStringRepresentation());
                    }
                }
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename for the goal file? ");
                string filename = Console.ReadLine();

                if (File.Exists(filename))
                {
                    string[] lines = File.ReadAllLines(filename);
                    score = int.Parse(lines[0]);
                    goals.Clear();

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] parts = lines[i].Split(":");
                        string type = parts[0];
                        string[] data = parts[1].Split(",");

                        if (type == "SimpleGoal")
                        {
                            goals.Add(new SimpleGoal(data[0], data[1], data[2], bool.Parse(data[3])));
                        }
                        else if (type == "EternalGoal")
                        {
                            goals.Add(new EternalGoal(data[0], data[1], data[2]));
                        }
                        else if (type == "ChecklistGoal")
                        {
                            goals.Add(new ChecklistGoal(data[0], data[1], data[2], int.Parse(data[4]), int.Parse(data[3]), int.Parse(data[5])));
                        }
                    }
                }
            }
            else if (choice == "5")
            {
                Console.WriteLine("\nThe goals are:");
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {goals[i].GetShortName()}");
                }
                Console.Write("Which goal did you accomplish? ");
                int index = int.Parse(Console.ReadLine()) - 1;

                if (index >= 0 && index < goals.Count)
                {
                    score += goals[index].RecordEvent();
                    Console.WriteLine($"\nYou now have {score} points.");
                }
            }
        }
    }
}

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName() => _shortName;
    public string GetDescription() => _description;
    public string GetPoints() => _points;

    public abstract int RecordEvent();
    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();
}

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, string points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return int.Parse(GetPoints());
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation() => $"SimpleGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_isComplete}";
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, string points) : base(name, description, points) { }

    public override int RecordEvent() => int.Parse(GetPoints());

    public override bool IsComplete() => false;

    public override string GetStringRepresentation() => $"EternalGoal:{GetShortName()},{GetDescription()},{GetPoints()}";
}

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string description, string points, int target, int bonus, int completed) : base(name, description, points)
    {
        _amountCompleted = completed;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            int earned = int.Parse(GetPoints());
            if (_amountCompleted == _target)
            {
                earned += _bonus;
            }
            return earned;
        }
        return 0;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetShortName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation() => $"ChecklistGoal:{GetShortName()},{GetDescription()},{GetPoints()},{_bonus},{_target},{_amountCompleted}";
}