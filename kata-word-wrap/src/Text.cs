using LanguageExt;

namespace kata_word_wrap;

public record Text
{
    private readonly Words _words;

    private Text(string text) =>
        _words = new Words(text.Split(" ").Select(w => new Word(w)).ToList());

    public static Either<Error, Text> From(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return new MissingTextError("Text cannot be empty.");
        }

        return new Text(text);
    }

    public Lines WrapInLines(ColumnWith columnWith)
    {
        var lines = new Lines();
        var currentLine = new Line();
        foreach (var word in _words.ToList())
        {
            if (columnWith.ThereIsSpaceLeft(currentLine, word))
            {
                currentLine.Append(word);
                continue;
            }

            lines.Append(currentLine);
            currentLine = new Line(word);
        }

        lines.Append(currentLine);
        return lines;
    }
}