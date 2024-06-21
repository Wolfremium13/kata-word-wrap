using LanguageExt;

namespace kata_word_wrap;

public record ColumnWith
{
    private readonly int _width;
    private ColumnWith(int width) => _width = width;

    public static Either<Error, ColumnWith> From(int width)
    {
        if (width <= 0)
        {
            return new InvalidColumnWidthError("Column width must be greater than 0.");
        }

        return new ColumnWith(width);
    }

    public bool ThereIsSpaceLeft(Line line, Word word)
    {
        return line.Length + word.Length <= _width;
    }
}