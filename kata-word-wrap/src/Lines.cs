namespace kata_word_wrap;

public class Lines
{
    private readonly List<Line> _lines = [];
    public void Append(Line line) => _lines.Add(line);
    public override string ToString() => string.Join("\n", _lines.Select(line => line.ToString()));
}