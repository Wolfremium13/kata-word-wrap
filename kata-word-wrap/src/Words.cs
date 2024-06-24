namespace kata_word_wrap;

public class Words(List<Word> words)
{
    public Words() : this([])
    {
    }

    public List<Word> ToList() => words;
    public void Append(Word word) => words.Add(word);
    public sealed override string ToString() => string.Join(" ", words.Select(word => word.Value));
}