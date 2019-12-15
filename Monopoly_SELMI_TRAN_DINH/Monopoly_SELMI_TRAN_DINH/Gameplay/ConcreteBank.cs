using Monopoly_SELMI_TRAN_DINH.Gameplay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_SELMI_TRAN_DINH
{
    class ConcreteBank : Bank
    {
        private Bank bank;

        public ConcreteBank(double stock) : base(stock)
        {
        }
    }
}
