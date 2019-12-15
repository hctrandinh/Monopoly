using Monopoly_SELMI_TRAN_DINH.Board_Monopoly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_SELMI_TRAN_DINH
{
    class JailFactory : CasesFactory
    {
        int position = 10;
        string name = "Jail";

        public override Case GetCase()
        {
            Case case_jail = new Jail(position, name);
            return case_jail;
        }
    }
}
