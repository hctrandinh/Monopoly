using Monopoly_SELMI_TRAN_DINH.Board_Monopoly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_SELMI_TRAN_DINH
{
    class LandFactory : CasesFactory
    {
        private string name;
        private int position;
        private int price;
        private string col;

        public override Case GetCase()
        {
            Case case_land = new Land(position, name, price, col);

            string line;
            // Read the file and display it line by line.  
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            System.IO.StreamReader file = new System.IO.StreamReader(dir + "/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Land&Station.txt");
            line = file.ReadLine();
            string[] words = line.Split(',');
            case_land = new Land(int.Parse(words[0]), words[1], int.Parse(words[2]), words[3]);
            file.Close();
            return case_land;
        }
    }
}
