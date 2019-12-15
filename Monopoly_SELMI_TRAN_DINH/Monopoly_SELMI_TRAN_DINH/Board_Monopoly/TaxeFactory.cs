using Monopoly_SELMI_TRAN_DINH;
using Monopoly_SELMI_TRAN_DINH.Board_Monopoly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_SELMI_TRAN_DINH
{
    class TaxeFactory : CasesFactory
    {
        private string name { get; set; }
        private int position { get; set; }
        private int price { get; set; }

        public override Case GetCase()
        {
            Case case_taxe = new Taxes(position, name, price);
            string line;
            // Read the file and display it line by line.  
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            System.IO.StreamReader file = new System.IO.StreamReader(dir + "/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Tax.txt");
            line = file.ReadLine();
            string[] words = line.Split(',');
            case_taxe = new Taxes(int.Parse(words[0]), words[1], int.Parse(words[2]));
            file.Close();
            return case_taxe;
        }
    }
}
