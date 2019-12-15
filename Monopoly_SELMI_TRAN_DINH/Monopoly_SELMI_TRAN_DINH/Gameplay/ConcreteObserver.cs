using Monopoly_SELMI_TRAN_DINH.Gameplay;
using Monopoly_SELMI_TRAN_DINH.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_SELMI_TRAN_DINH
{
    class ConcreteObserver : Observer
    {
        Player p_name;
        private ConcreteObserver _Stock;

        // Constructor

        public ConcreteObserver(Player name)
        {
            this.p_name = name;
        }

        public void Update(Bank stock)
        {
            Console.WriteLine("New bank value:" + stock._Stock);
        }

        // Gets or sets the stock

        public Bank Stock { get; set; }
    }
}
