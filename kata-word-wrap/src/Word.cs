namespace kata_word_wrap;

public record Word(string Value)
{
    public int Length => Value.Length;
}