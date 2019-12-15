using Monopoly_SELMI_TRAN_DINH.Board_Monopoly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_SELMI_TRAN_DINH
{
    class ToJailFactory : CasesFactory
    {
        int position = 30;
        string name = "Go to jail !";

        public override Case GetCase()
        {
            Case case_to_jail = new To_Jail(position, name);
            return case_to_jail;
        }
    }
}
