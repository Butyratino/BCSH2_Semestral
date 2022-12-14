using System;
using System.Collections.Generic;
using System.Text;

namespace BCSH2_SemestralniPrace_Semakou.Parsing
{
    abstract class ExpressionSyntax : SyntaxNode
    {
        public abstract IEnumerable<SyntaxNode> GetChildren();
    }
}