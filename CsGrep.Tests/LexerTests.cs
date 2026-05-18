using CsGrep.Lexers;

namespace CsGrep.Tests;

public class TokenTests
{
    [Fact]
    public void Eof_ReturnsEofToken()
    {
        Assert.Equal(new EofToken(), Tokens.Eof());
    }

    [Fact]
    public void Character_ReturnsCharacterTokenWithLexeme()
    {
        Assert.Equal(new CharacterToken("a"), Tokens.Character("a"));
    }
}

public class BasicLexerTests
{
    [Fact]
    public void Scan_EmptyPattern_ReturnsOnlyEof()
    {
        var lexer = new BasicGrammarLexer("");
        var tokens = lexer.Scan();

        Assert.Equal([Tokens.Eof()], tokens);
    }

    [Fact]
    public void Scan_SingleCharacterPattern()
    {
        var lexer = new BasicGrammarLexer("a");
        Assert.Equal([Tokens.Character("a"), Tokens.Eof()], lexer.Scan());
    }

    [Theory]
    [InlineData("abc", new[] { "a", "b", "c" })]
    [InlineData("123", new[] { "1", "2", "3" })]
    public void Scan_LiteralCharacters_ReturnsCharacterTokensWithEof(
        string pattern,
        string[] expectedLexemes
    )
    {
        var lexer = new BasicGrammarLexer(pattern);
        var tokens = lexer.Scan();

        var expected = expectedLexemes
            .Select(Tokens.Character)
            .Append<Token>(Tokens.Eof())
            .ToList();

        Assert.Equal(expected, tokens);
    }
}

public class ExtendedLexerTests
{
    [Fact]
    public void Scan_EmptyPattern_ReturnsOnlyEof()
    {
        var lexer = new ExtendedGrammarLexer("");
        Assert.Equal([Tokens.Eof()], lexer.Scan());
    }

    [Fact]
    public void Scan_SingleCharacterPattern()
    {
        var lexer = new ExtendedGrammarLexer("a");
        Assert.Equal([Tokens.Character("a"), Tokens.Eof()], lexer.Scan());
    }

    [Theory]
    [InlineData("abc", new[] { "a", "b", "c" })]
    [InlineData("123", new[] { "1", "2", "3" })]
    public void Scan_LiteralCharacters_ReturnsCharacterTokensWithEof(
        string pattern,
        string[] expectedLexemes
    )
    {
        var lexer = new ExtendedGrammarLexer(pattern);
        var tokens = lexer.Scan();

        var expected = expectedLexemes
            .Select(Tokens.Character)
            .Append<Token>(Tokens.Eof())
            .ToList();

        Assert.Equal(expected, tokens);
    }
}
