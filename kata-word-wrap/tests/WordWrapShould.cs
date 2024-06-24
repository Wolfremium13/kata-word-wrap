using FluentAssertions;
using Xunit;

namespace kata_word_wrap.tests;

public class WordWrapShould
{
    [Fact]
    public void NotAllowEmptyText()
    {
        var missingTextError =
            from text in Text.Create("")
            from columnWidth in ColumnWith.Create(10)
            from wrapped in WordWrapper.Wrap(text, columnWidth)
            select wrapped;

        missingTextError.Match(
            wrappedText => wrappedText.Should().BeNull(),
            error => error.Should().BeOfType<MissingTextError>()
                .Which.Message.Should().Be("Text cannot be empty.")
        );
    }

    [Fact]
    public void NotAllowInvalidColumnWidth()
    {
        var invalidColumnWidthError =
            from text in Text.Create("Hello")
            from columnWidth in ColumnWith.Create(0)
            from wrapped in WordWrapper.Wrap(text, columnWidth)
            select wrapped;

        invalidColumnWidthError.Match(
            wrappedText => wrappedText.Should().BeNull(),
            error => error.Should().BeOfType<InvalidColumnWidthError>()
                .Which.Message.Should().Be("Column width must be greater than 0.")
        );
    }

    [Fact]
    public void NotWrap()
    {
        const string shortText = "Hello";
        const int longColumnWidth = 10;

        var wrappedText =
            from text in Text.Create(shortText)
            from columnWidth in ColumnWith.Create(longColumnWidth)
            from wrapped in WordWrapper.Wrap(text, columnWidth)
            select wrapped;

        wrappedText.Match(
            text => text.ToString().Should().Be(shortText),
            error => error.Should().BeNull()
        );
    }

    [Fact]
    public void WrapWords()
    {
        const string longText = "Hello World! How are you?";
        const int shortColumnWidth = 5;

        var wrappedText =
            from text in Text.Create(longText)
            from columnWidth in ColumnWith.Create(shortColumnWidth)
            from wrapped in WordWrapper.Wrap(text, columnWidth)
            select wrapped;

        wrappedText.Match(
            text => text.ToString().Should().Be("Hello\nWorld!\nHow\nare\nyou?"),
            error => error.Should().BeNull()
        );
    }

    [Fact]
    public void WrapMultipleWords()
    {
        const string longText = "Hello World! How are you?";
        const int shortColumnWidth = 10;

        var wrappedText =
            from text in Text.Create(longText)
            from columnWidth in ColumnWith.Create(shortColumnWidth)
            from wrapped in WordWrapper.Wrap(text, columnWidth)
            select wrapped;

        wrappedText.Match(
            text => text.ToString().Should().Be("Hello\nWorld! How\nare you?"),
            error => error.Should().BeNull()
        );
    }
}