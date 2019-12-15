using Monopoly_SELMI_TRAN_DINH.Board_Monopoly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_SELMI_TRAN_DINH
{
    class FreeParkFactory : CasesFactory
    {
        int position = 20;
        string name = "Free Park";

        public override Case GetCase()
        {
            Case case_free_park = new Free_Park(position, name);
            return case_free_park;
        }
    }
}
