using LanguageExt;

namespace kata_word_wrap;

public static class WordWrapper
{
    public static Either<Error, WrappedText> Wrap(Text text, ColumnWith columnWith) =>
        new WrappedText(text.WrapInLines(columnWith));
}