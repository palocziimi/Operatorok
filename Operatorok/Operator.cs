using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatorok
{
    class Operator
    {
        private int szam1;
        private string oper;
        private int szam2;

        public Operator(int szam1, string oper, int szam2)
        {
            this.szam1 = szam1;
            this.oper = oper;
            this.szam2 = szam2;
        }

        public int Szam1 { get => szam1; }
        public string Oper { get => oper; }
        public int Szam2 { get => szam2; }
    }
}
