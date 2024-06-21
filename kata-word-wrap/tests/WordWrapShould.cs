using FluentAssertions;
using Xunit;

namespace kata_word_wrap.tests;

public class WordWrapShould
{
    [Fact]
    public void NotAllowEmptyText()
    {
        var missingTextError = Text.From("").Bind(text =>
        {
            return ColumnWith.From(10).Bind(columnWith => WordWrap.Wrap(text, columnWith));
        });

        missingTextError.Match(
            wrappedText => wrappedText.Should().BeNull(),
            error => error.Should().BeOfType<MissingTextError>()
                .Which.Message.Should().Be("Text cannot be empty.")
        );
    }

    [Fact]
    public void NotAllowInvalidColumnWidth()
    {
        var negativeColumnWidthError = Text.From("Hello").Bind(text =>
        {
            return ColumnWith.From(-1).Bind(columnWith => WordWrap.Wrap(text, columnWith));
        });

        negativeColumnWidthError.Match(
            wrappedText => wrappedText.Should().BeNull(),
            error => error.Should().BeOfType<InvalidColumnWidthError>().Which.Message.Should()
                .Be("Column width must be greater than 0.")
        );
    }

    [Fact]
    public void NotWrap()
    {
        const string shortText = "Hello";
        var wrappedText = Text.From(shortText).Bind(text =>
        {
            const int longColumnWidth = 10;
            return ColumnWith.From(longColumnWidth).Bind(columnWith => WordWrap.Wrap(text, columnWith));
        });

        wrappedText.Match(
            text => text.ToString().Should().Be(shortText),
            error => error.Should().BeNull()
        );
    }

    [Fact]
    public void WrapWords()
    {
        const string longText = "Hello World! How are you?";
        var wrappedText = Text.From(longText).Bind(text =>
        {
            const int shortColumnWidth = 5;
            return ColumnWith.From(shortColumnWidth).Bind(columnWith => WordWrap.Wrap(text, columnWith));
        });

        wrappedText.Match(
            text => text.ToString().Should().Be("Hello\nWorld!\nHow\nare\nyou?"),
            error => error.Should().BeNull()
        );
    }

    [Fact]
    public void WrapMultipleWords()
    {
        const string longText = "Hello World! How are you?";
        var wrappedText = Text.From(longText).Bind(text =>
        {
            const int shortColumnWidth = 10;
            return ColumnWith.From(shortColumnWidth).Bind(columnWith => WordWrap.Wrap(text, columnWith));
        });

        wrappedText.Match(
            text => text.ToString().Should().Be("Hello\nWorld! How\nare you?"),
            error => error.Should().BeNull()
        );
    }
}