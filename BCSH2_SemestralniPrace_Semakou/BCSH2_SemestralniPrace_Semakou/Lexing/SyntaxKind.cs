

namespace BCSH2_SemestralniPrace_Semakou.Lexing
{
    public enum SyntaxKind
    {
        //Tokens
        WrongToken,
        EOFToken,

        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        EqualsToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        OpenFigureBracketsToken,
        CloseFigureBracketsToken,
        DotToken,
        DoubleQuoteToken,
        ExclamationToken,
        NotEqualsToken,
        LessToken,
        LessEqualsToken,
        GreaterToken,
        GreaterEqualsToken,
        AmpersandToken,
        PipeToken,
        EqualsEqualsToken,
        IdentifierToken,
        NumberToken,
        WhitespaceToken,

        //keywords 
        IfToken,
        ElseToken,
        ElseIfToken,
        DoToken,
        WhileToken,
        ConstToken,
        DoubleToken,
        StringToken,
        FalseToken,
        TrueToken,

      

    }
}