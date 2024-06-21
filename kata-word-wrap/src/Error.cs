namespace kata_word_wrap;

public record Error(string Message);
public record MissingTextError(string Message) : Error(Message);
public record InvalidColumnWidthError(string Message) : Error(Message);