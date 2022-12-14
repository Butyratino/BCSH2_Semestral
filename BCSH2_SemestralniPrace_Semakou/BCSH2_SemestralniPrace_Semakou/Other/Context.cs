using System;
using System.Collections.Generic;
using System.Text;

namespace BCSH2_SemestralniPrace_Semakou.Other
{
    class Context
    {

        public Context(string name, Context parent = null)
        {
            Name = name;
            Parent = parent;
            //SymbolTable = new SymbolTable(parent?.SymbolTable);
        }

        public string Name { get; }
        public Context Parent { get; }
        //public SymbolTable SymbolTable { get; set; }
    }
}
