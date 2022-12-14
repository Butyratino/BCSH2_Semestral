

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

        //Keywords 
        IfToken,
        ElseToken,
        ElseIfToken,
        DoToken,
        WhileToken,
        SemicolonToken,
        DoubleToken,
        DoubleKeywordToken,
        StringKeywordToken,
        StringToken,
        VarToken,
        ConstToken,
        TrueToken,
        FalseToken,



        //Expressions
        NumberExpression,
        BinaryExpression,
        ParenthesizedExpression,
        Block,
        DefinitionSyntax,
        AssignmentSyntax,
        AccessVariableSyntax,
        FunctionCallSyntax
    }
}