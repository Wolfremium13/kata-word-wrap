namespace kata_word_wrap;

public record Line
{
    private readonly Words _words = new();

    public Line() => _words = new Words([]);

    public Line(Word word)
    {
        _words = new Words([word]);
        Length = word.Length;
    }

    public int Length { get; private set; }

    public void Append(Word word)
    {
        _words.Append(word);
        Length += word.Length;
    }

    public override string ToString() => _words.ToString();
}