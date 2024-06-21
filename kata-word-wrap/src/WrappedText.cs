namespace kata_word_wrap;

public record WrappedText
{
    private readonly Lines _lines;
    public WrappedText(Lines lines) => _lines = lines;
    public override string ToString() => _lines.ToString();
}