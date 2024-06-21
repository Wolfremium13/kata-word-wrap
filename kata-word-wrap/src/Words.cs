namespace kata_word_wrap;

public class Words
{
    private readonly List<Word> _words;
    public readonly int Length;

    public Words()
    {
        _words = new();
        Length = 0;
    }


    public Words(List<Word> words)
    {
        _words = words;
        Length = ToString().Length;
    }

    public List<Word> ToList() => _words;
    public void Append(Word word) => _words.Add(word);
    public sealed override string ToString() => string.Join(" ", _words.Select(word => word.Value));
}