using Monopoly_SELMI_TRAN_DINH.Gameplay;
using Monopoly_SELMI_TRAN_DINH.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_SELMI_TRAN_DINH
{
    interface Observer
    {
        void Update(Bank stock);
    }
}
