using BCSH2_SemestralniPrace_Semakou.Parsing;
using System.Collections.Generic;
using System.Linq;

namespace BCSH2_SemestralniPrace_Semakou.Lexing
{

    class SyntaxToken : SyntaxNode
    {
        public SyntaxToken(SyntaxKind type, int position, string text, object value)
        {
            Kind = type;
            Position = position;
            Text = text;
            Value = value;
        }

        public override SyntaxKind Kind { get; }

        public int Position { get; }
        public string Text { get; }
        public object Value { get; }

    }

}
