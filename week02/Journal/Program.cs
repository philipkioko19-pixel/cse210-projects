using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string userChoice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (userChoice != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                string prompt = journal.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.Write("How are you feeling today (Mood)? ");
                string mood = Console.ReadLine();

                DateTime currentDate = DateTime.Now;
                string dateText = currentDate.ToShortDateString();

                Entry newEntry = new Entry(dateText, prompt, response, mood);
                journal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {
                journal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                journal.LoadFromFile(fileName);
            }
            else if (userChoice == "4")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();
                journal.SaveToFile(fileName);
            }
            else if (userChoice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option, please try again.");
            }

            Console.WriteLine();
        }
    }
}

public class Entry
{
    public string _date { get; set; }
    public string _promptText { get; set; }
    public string _entryText { get; set; }
    public string _mood { get; set; }

    // Empty constructor for JSON loading
    public Entry()
    {
    }

    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine("----------------------------------------");
    }
}

public class Journal
{
    public List<Entry> _entries { get; set; } = new List<Entry>();

    public List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was something cool that happened today?",
        "What is one thing I am grateful for right now?"
    };

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries in the journal.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        // For exceeding requirements, I used System.Text.Json to save the journal.
        // This avoids bugs if the user types commas or other symbols in their entry.
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(_entries, options);
        File.WriteAllText(file, json);
        Console.WriteLine("Saved successfully!");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            _entries = JsonSerializer.Deserialize<List<Entry>>(json);
            Console.WriteLine("Loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}