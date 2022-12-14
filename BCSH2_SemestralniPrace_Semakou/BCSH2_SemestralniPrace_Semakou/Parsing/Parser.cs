using BCSH2_SemestralniPrace_Semakou.Lexing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCSH2_SemestralniPrace_Semakou.Parsing
{
    class Parser
    {
        public IEnumerable<string> Diagnostics => diagnostics;

        private int position;
        private readonly SyntaxToken[] tokens;
        private List<string> diagnostics = new List<string>();
        private SyntaxToken Current => Peek(0);

        public Parser(string text)
        {
            var tokens = new List<SyntaxToken>();
            var lexer = new Lexer(text);
            SyntaxToken token;
            do
            {
                token = lexer.NextToken();
                if (token.Kind != SyntaxKind.WrongToken && token.Kind != SyntaxKind.WhitespaceToken)
                {
                    tokens.Add(token);
                }
            } while (token.Kind != SyntaxKind.EOFToken);
            this.tokens = tokens.ToArray();
            diagnostics.AddRange(lexer.Diagnostics);
        }

        private SyntaxToken Match(SyntaxKind type)
        {
            if (Current.Kind == type)
                return NextToken();
            diagnostics.Add($"Error : unexpected token <{Current.Kind}>, expected <{type}>");
            return new SyntaxToken(type, Current.Position, null, null);
        }

        private SyntaxToken Peek(int offset)
        {
            var index = position + offset;
            if (index >= tokens.Length)
                return tokens[tokens.Length - 1];
            return tokens[index];
        }

        private SyntaxToken NextToken()
        {
            var current = Current;
            position++;
            return current;
        }

        public SyntaxTree Parse()
        {
            //var block = ParseBlock();
            var EOFToken = Match(SyntaxKind.EOFToken);
            return new SyntaxTree(diagnostics, block, EOFToken);
        }

        private ExpressionSyntax ParseTerm()
        {
            var left = ParseFactor();
            while (Current.Kind == SyntaxKind.StarToken || Current.Kind == SyntaxKind.SlashToken)
            {
                var operatorToken = NextToken();
                var right = ParseFactor();
                left = new BinaryExpressionSyntax(left, operatorToken, right);
            }
            return left;
        }

        private ExpressionSyntax ParseFactor()
        {
            throw new NotSupportedException();
        }
    }
}
