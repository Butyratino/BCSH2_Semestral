using BCSH2_SemestralniPrace_Semakou.Lexing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCSH2_SemestralniPrace_Semakou.Other
{
    internal abstract class TypedValue
    {
        public Context Context { get; set; } = null;
        public SyntaxKind Type { get; set; }
    }
}