using BCSH2_SemestralniPrace_Semakou.Lexing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCSH2_SemestralniPrace_Semakou.Parsing
{
    class ParenthesizedExpressionSyntax : ExpressionSyntax
    {
        public ParenthesizedExpressionSyntax(SyntaxToken openParenthesisToken, ExpressionSyntax Expression, SyntaxToken closeParenthesisToken)
        {
            OpenParenthesisToken = openParenthesisToken;
            this.Expression = Expression;
            CloseParenthesisToken = closeParenthesisToken;
        }

        public SyntaxToken OpenParenthesisToken { get; }
        public ExpressionSyntax Expression { get; }
        public SyntaxToken CloseParenthesisToken { get; }

        public override SyntaxKind Kind => SyntaxKind.ParenthesizedExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return OpenParenthesisToken;
            yield return Expression;
            yield return CloseParenthesisToken;
        }
    }
}
