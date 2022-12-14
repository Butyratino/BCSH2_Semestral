using BCSH2_SemestralniPrace_Semakou.Lexing;
using System.Collections.Generic;
using System.Linq;

namespace BCSH2_SemestralniPrace_Semakou.Parsing
{
    class SyntaxTree
    {
        public SyntaxTree(IEnumerable<string> diagnostics, ExpressionSyntax root, SyntaxToken endOfFileToken)
        {
            Reports = diagnostics.ToArray();
            Root = root;
            EndOfFileToken = endOfFileToken;
        }

        public IReadOnlyList<string> Reports { get; }
        public ExpressionSyntax Root { get; }
        public SyntaxToken EndOfFileToken { get; }

        public static SyntaxTree Parse(string text)
        {
            var parser = new Parser(text);
            return parser.Parse();
        }
    }
}
