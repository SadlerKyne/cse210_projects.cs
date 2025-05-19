using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is empty. Nothing to display.");
            return;
        }
        Console.WriteLine("\nJournal Entries:");
        Console.WriteLine("----------------");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
        Console.WriteLine("----------------\n");
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Journal saved to {filename} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal to file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"Error: File '{filename}' not found.");
            return;
        }

        List<Entry> loadedEntries = new List<Entry>();
        try
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2]);
                    loadedEntries.Add(entry);
                }
                else
                {
                    Console.WriteLine($"Warning: Skipped malformed line in file: {line}");
                }
            }
            _entries = loadedEntries;
            Console.WriteLine($"Journal loaded from {filename} successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal from file: {ex.Message}");
        }
    }
}