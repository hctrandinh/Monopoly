using Monopoly_SELMI_TRAN_DINH.Board_Monopoly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_SELMI_TRAN_DINH
{
    class CardDrawFactory : CasesFactory
    {
        private string name;
        private int position;

        public override Case GetCase()
        {
            Case case_draw = new Card_draw(position, name);

            string line;
            // Read the file and display it line by line.  
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            System.IO.StreamReader file = new System.IO.StreamReader(dir + "/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Chance&Community.txt");
            line = file.ReadLine();
            string[] words = line.Split(',');
            case_draw = new Card_draw(int.Parse(words[0]), words[1]);
            file.Close();
            return case_draw;
        }
    }
}
