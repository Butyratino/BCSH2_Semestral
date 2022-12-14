using BCSH2_SemestralniPrace_Semakou.Lexing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCSH2_SemestralniPrace_Semakou.Parsing
{
    class LiteralExpressionSyntax : ExpressionSyntax
    {
        public LiteralExpressionSyntax(SyntaxToken literalToken)
            : this(literalToken, literalToken.Value) { }

        public LiteralExpressionSyntax(SyntaxToken literalToken, object value)
        {
            LiteralToken = literalToken;
            Value = value;
        }

        public SyntaxToken LiteralToken { get; }
        public object Value { get; }

        public override SyntaxKind Kind => SyntaxKind.NumberExpression;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return LiteralToken;
        }
    }

}
