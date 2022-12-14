using BCSH2_SemestralniPrace_Semakou.Lexing;
using BCSH2_SemestralniPrace_Semakou.Parsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCSH2_SemestralniPrace_Semakou.Other
{
    class Evaluator
    {
        private readonly ExpressionSyntax _root;
        public IEnumerable<string> Diagnostics => diagnostics;
        private List<string> diagnostics = new List<string>();

        public Evaluator(ExpressionSyntax root)
        {
            this._root = root;

        }

        public RTResult Evaluate(ExpressionSyntax node, Context context)
        {
            switch (node.Kind)
            {
                case SyntaxKind.Block:
                    return EvaluateBlock((BlockSyntax)node, context);
                case SyntaxKind.DefinitionSyntax:
                    return EvaluateDefinitionSyntax((DefinitionSyntax)node, context);
                case SyntaxKind.AssignmentSyntax:
                    return EvaluateAssignmentSyntax((AssignmentSyntax)node, context);
                case SyntaxKind.AccessVariableSyntax:
                    return EvaluateAccessVariableSyntax((AccessVariableSyntax)node, context);
                case SyntaxKind.FunctionCallSyntax:
                    return EvaluateFunctionCall((FunctionCallSyntax)node, context);
                case SyntaxKind.BinaryExpression:
                    return EvaluateBinaryExpression((BinaryExpressionSyntax)node, context);
                case SyntaxKind.UnaryExpression:
                    return EvaluateUnaryExpression((UnaryExpressionSyntax)node, context);
                case SyntaxKind.ParenthesizedExpression:
                    return Evaluate(((ParenthesizedExpressionSyntax)node).Expression, context);
                case SyntaxKind.IfStatement:
                    return EvaluateIfStatement((IfStatementSyntax)node, new Context("<IfStatementContext>", context));
                case SyntaxKind.WhileStatement:
                    return EvaluateWhileStatement((WhileStatementSyntax)node, new Context("<WhileStatementContext>", context));
                case SyntaxKind.DoWhileStatement:
                    return EvaluateDoWhileStatement((DoWhileStatementSyntax)node, new Context("<DoWhileStatementContext>", context));
                case SyntaxKind.NumberExpression:
                    return EvaluateNumber((LiteralExpressionSyntax)node, context);
                case SyntaxKind.StringExpression:
                    return EvaluateString((StringExpressionSyntax)node, context);
            }
            diagnostics.Add($"Unexpected syntax node of kind <{node.Kind}>");
            return new RTResult(null);
        }

        private RTResult EvaluateString(StringExpressionSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateNumber(LiteralExpressionSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateDoWhileStatement(DoWhileStatementSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateWhileStatement(WhileStatementSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateIfStatement(IfStatementSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateUnaryExpression(UnaryExpressionSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateBinaryExpression(BinaryExpressionSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateAccessVariableSyntax(AccessVariableSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateFunctionCall(FunctionCallSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateAssignmentSyntax(AssignmentSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateDefinitionSyntax(DefinitionSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private RTResult EvaluateBlock(BlockSyntax node, Context context)
        {
            throw new NotImplementedException();
        }

        private int EvaluateExpression(ExpressionSyntax root)
        {
            if (root is LiteralExpressionSyntax l)
            {
                return (int) l.LiteralToken.Value;
            }
            if (root is BinaryExpressionSyntax b)
            {
                var left = EvaluateExpression(b.Left);
                var right = EvaluateExpression(b.Right);
                if (b.OperatorToken.Kind == SyntaxKind.PlusToken) return left + right;
                else if (b.OperatorToken.Kind == SyntaxKind.MinusToken) return left - right;
                else if (b.OperatorToken.Kind == SyntaxKind.StarToken) return left * right;
                else if (b.OperatorToken.Kind == SyntaxKind.SlashToken) return left / right;
                else throw new Exception($"Unexpected binary operator {b.OperatorToken.Kind}");

            }
            throw new Exception($"Unexpected node {root.Kind}");
        }
    }
}
