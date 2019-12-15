using Monopoly_SELMI_TRAN_DINH.Board_Monopoly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_SELMI_TRAN_DINH
{
    class StartFactory : CasesFactory
    {
        int position = 0;
        string name = "Start";

        public override Case GetCase()
        {
            Case case_start = new Start(position, name);
            return case_start;
        }
    }
}
