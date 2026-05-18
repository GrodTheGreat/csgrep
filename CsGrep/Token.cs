namespace CsGrep;

public abstract record Token;

public sealed record EofToken : Token;

public sealed record CharacterToken(string lexeme) : Token;

public static class Tokens
{
    public static EofToken Eof() => new();

    public static CharacterToken Character(string lexeme) => new(lexeme);
}
