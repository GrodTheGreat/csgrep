using CsGrep;

namespace CsGrep.Lexers;

public class ExtendedGrammarLexer : Lexer
{
    private readonly string _pattern;
    private List<Token> _tokens;
    private int _current;

    public ExtendedGrammarLexer(string pattern)
    {
        _pattern = pattern;
        _tokens = [];
        _current = 0;
    }

    public List<Token> Scan()
    {
        while (!IsAtEnd())
        {
            var lexeme = _pattern[_current].ToString();
            _tokens.Add(Tokens.Character(lexeme));
            _current++;
        }
        _tokens.Add(Tokens.Eof());
        return _tokens;
    }

    private bool IsAtEnd()
    {
        return _current >= _pattern.Length;
    }
}
