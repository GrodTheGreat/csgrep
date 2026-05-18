namespace CsGrep.Lexers;

public interface Lexer
{
    List<Token> Scan();
}
