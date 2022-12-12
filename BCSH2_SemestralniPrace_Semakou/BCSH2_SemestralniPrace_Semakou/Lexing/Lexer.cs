using System;
using System.Collections.Generic;
using System.Text;

namespace BCSH2_SemestralniPrace_Semakou.Lexing
{
    class Lexer
    {
        private readonly string _code;
        private int _position;
        private List<string> _diagnostics = new List<string>();

        private char Current => _position >= _code.Length ? '\0' : _code[_position];

        public IEnumerable<string> Diagnostics => _diagnostics;

        public Lexer(string code)
        {
            _code = code;
        }

        public SyntaxToken NextToken()
        {
            if (_position >= _code.Length)
            {
                return new SyntaxToken(SyntaxKind.EOFToken, _position, "\0", null);
            }
            if (char.IsDigit(Current))
            {
                var start = _position;

                while (char.IsDigit(Current))
                    Next();

                var length = _position - start;
                var text = _code.Substring(start, length);
                if (!int.TryParse(text, out int value))
                    _diagnostics.Add($"The number {text} can not be represented by Int32.");
                return new SyntaxToken(SyntaxKind.NumberToken, start, text, value);
            }
            if (char.IsWhiteSpace(Current))
            {
                var start = _position;
                while (char.IsWhiteSpace(Current))
                    Next();

                var length = _position - start;
                var text = _code.Substring(start, length);
                return new SyntaxToken(SyntaxKind.WhitespaceToken, start, text, null);
            }

            if (char.IsLetter(Current))
            {
                var start = _position;
                while (char.IsLetterOrDigit(Current))
                    Next();
                var length = _position - start;
                var text = _code.Substring(start, length);
                switch (text)
                {
                    case "if":
                        return new SyntaxToken(SyntaxKind.IfToken, start, text, null);
                    case "else":
                        if (char.IsWhiteSpace(Current) && Peek(1) == 'i' && Peek(2) == 'f' && !char.IsLetterOrDigit(Peek(3)))
                        {
                            Next(3);
                            return new SyntaxToken(SyntaxKind.ElseIfToken, start, "else if", null);
                        }
                        else return new SyntaxToken(SyntaxKind.ElseToken, start, text, null);
                    case "while":
                        return new SyntaxToken(SyntaxKind.WhileToken, start, text, null);
                    case "do":
                        return new SyntaxToken(SyntaxKind.DoToken, start, text, null);
                    case "const":
                        return new SyntaxToken(SyntaxKind.ConstToken, start, text, null);
                    case "Double":
                        return new SyntaxToken(SyntaxKind.DoubleToken, start, text, null);
                    case "String":
                        return new SyntaxToken(SyntaxKind.StringToken, start, text, null);
                    case "true":
                        return new SyntaxToken(SyntaxKind.TrueToken, start, text, null);
                    case "false":
                        return new SyntaxToken(SyntaxKind.FalseToken, start, text, null);
                    default:
                        return new SyntaxToken(SyntaxKind.IdentifierToken, start, text, null);
                }
            }


            switch (Current)
            {
                case '+':
                    return new SyntaxToken(SyntaxKind.PlusToken, _position++, "+", null);
                case '-':
                    return new SyntaxToken(SyntaxKind.MinusToken, _position++, "-", null);
                case '*':
                    return new SyntaxToken(SyntaxKind.StarToken, _position++, "*", null);
                case '/':
                    return new SyntaxToken(SyntaxKind.SlashToken, _position++, "/", null);
                case '(':
                    return new SyntaxToken(SyntaxKind.OpenParenthesisToken, _position++, "(", null);
                case ')':
                    return new SyntaxToken(SyntaxKind.CloseParenthesisToken, _position++, ")", null);
                case '{':
                    return new SyntaxToken(SyntaxKind.OpenFigureBracketsToken, _position++, "{", null);
                case '}':
                    return new SyntaxToken(SyntaxKind.CloseFigureBracketsToken, _position++, "}", null);
                case '.':
                    return new SyntaxToken(SyntaxKind.DotToken, _position++, ".", null);
                case '"':
                    return new SyntaxToken(SyntaxKind.DoubleQuoteToken, _position++, "\"", null);
                case '&':
                    if (Peek(1) == '&')
                    {
                        Next();
                        return new SyntaxToken(SyntaxKind.AmpersandToken, _position++, "&&", null);
                    }
                    return new SyntaxToken(SyntaxKind.AmpersandToken, _position++, "&", null);
                case '|':
                    if (Peek(1) == '|')
                    {
                        Next();
                        return new SyntaxToken(SyntaxKind.PipeToken, _position++, "||", null);
                    }
                    return new SyntaxToken(SyntaxKind.PipeToken, _position++, "|", null);
                case '<':
                    if (Peek(1) == '=')
                    {
                        Next();
                        return new SyntaxToken(SyntaxKind.LessEqualsToken, _position++, "<=", null);
                    }
                    else return new SyntaxToken(SyntaxKind.LessToken, _position++, "<", null);
                case '>':
                    if (Peek(1) == '=')
                    {
                        Next();
                        return new SyntaxToken(SyntaxKind.GreaterEqualsToken, _position++, ">=", null);
                    }
                    else return new SyntaxToken(SyntaxKind.GreaterToken, _position++, ">", null);
                case '=':
                    if (Peek(1) == '=')
                    {
                        Next();
                        return new SyntaxToken(SyntaxKind.EqualsEqualsToken, _position++, "==", null);
                    }
                    return new SyntaxToken(SyntaxKind.EqualsToken, _position++, "=", null);
                case '!':
                    if (Peek(1) == '=')
                    {
                        Next();
                        return new SyntaxToken(SyntaxKind.NotEqualsToken, _position++, "!=", null);
                    }
                    else return new SyntaxToken(SyntaxKind.ExclamationToken, _position++, "!", null);

            }
            _diagnostics.Add($"Error : bad character in input: '{Current}");
            return new SyntaxToken(SyntaxKind.WrongToken, _position++, _code[_position - 1].ToString(), null);
        }

        private void Next()
        {
            _position++;
        }

        private void Next(int offset)
        {
            _position += offset;
        }

        private char Peek(int offset)
        {
            if (_position + offset < _code.Length)
            {
                return _code[_position + offset];
            }
            else return _code[_code.Length];
        }
    }
}
