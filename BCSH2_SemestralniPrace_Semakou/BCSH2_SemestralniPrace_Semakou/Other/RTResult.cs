using BCSH2_SemestralniPrace_Semakou.Lexing;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCSH2_SemestralniPrace_Semakou.Other
{
    class RTResult
    {
        public TypedValue Value { get; private set; }
        public string Error { get; private set; } = "";
        public SyntaxKind Type { get; private set; }

        public RTResult(TypedValue value)
        {
            Value = value;
        }

        public RTResult(TypedValue value, SyntaxKind type)
        {
            Value = value;
            Type = type;
        }



        public RTResult(TypedValue value, string error) : this(value)
        {
            Error = error;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}