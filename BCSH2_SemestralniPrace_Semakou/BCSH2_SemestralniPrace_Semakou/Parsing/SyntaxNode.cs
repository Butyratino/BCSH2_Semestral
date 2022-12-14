using BCSH2_SemestralniPrace_Semakou.Lexing;

namespace BCSH2_SemestralniPrace_Semakou.Parsing
{
    abstract class SyntaxNode
    {
        public abstract SyntaxKind Kind { get; }
    }
}
