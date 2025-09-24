public class Scripture
{
    private Reference _reference;

    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordsArray = text.Split(' ');
        foreach (string word in wordsArray) {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        if (visibleWords.Count == 0)
        {
            return;
        }

        Random rand = new Random();
        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count); 
            visibleWords[index].Hide();                
            visibleWords.RemoveAt(index);              
        }
    }

    public string GetDisplayText()
    {
        string displayText = "";
        foreach (Word word in _words) {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
         foreach (Word word in _words)
        {
            if (!word.IsHidden()) 
            {
                return false; 
            }
        }
        return true;
    }
}
