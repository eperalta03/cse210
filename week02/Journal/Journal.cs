using System.IO;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            Entry e = new Entry();
            e._date = parts[0];
            e._promptText = parts[1];
            e._entryText = parts[2];

            _entries.Add(e);
        }
    }
}