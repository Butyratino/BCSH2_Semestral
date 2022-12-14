using BCSH2_SemestralniPrace_Semakou.Lexing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCSH2_SemestralniPrace_Semakou.Parsing
{
    class BinaryExpressionSyntax : ExpressionSyntax
    {
        public BinaryExpressionSyntax(ExpressionSyntax left, SyntaxToken operatorToken, ExpressionSyntax right)
        {
            Left = left;
            OperatorToken = operatorToken;
            Right = right;
        }

        public override SyntaxKind Kind => SyntaxKind.BinaryExpression;
        public ExpressionSyntax Left { get; }
        public SyntaxNode OperatorToken { get; }
        public ExpressionSyntax Right { get; }


        public override IEnumerable<SyntaxNode> GetChildren()
        {
            return Left.GetChildren();
        }
    }

}