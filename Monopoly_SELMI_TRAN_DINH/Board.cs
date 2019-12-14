using System;
using Monopoly_SELMI_TRAN_DINH.Cards;

namespace Monopoly_SELMI_TRAN_DINH.Board_Monopoly
{
    public class Board
    {
        public Case[] board;
        public Chance chance_cards;
        public Community community_cards;
        private static Board instance;//Singleton
        private static readonly object locker = new object();

        public static Board Instance()
        {
            if (instance == null)
            {
                lock(locker)
                {
                    if(instance == null)
                    {
                        instance = new Board();
                    }
                }
            }
            return instance;
        }

        public Board()
        {
            this.board = new Case[40];
            this.board[0] = new Start();
            this.board[10] = new Jail();
            this.board[20] = new Free_Park();
            this.board[30] = new To_Jail();
            set_chance_and_community();
            set_company_cases();
            set_land_and_station_cases();
            set_taxes_cases();
            chance_cards = new Chance();
            community_cards = new Community();
        }

        public void set_chance_and_community()
        {
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader("/Users/huan/Projects/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Chance&Community.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                board[int.Parse(words[0])] = new Card_draw(int.Parse(words[0]), words[1]);
            }
            file.Close();
        }

        public void set_company_cases()
        {
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader("/Users/huan/Projects/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Company.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                board[int.Parse(words[0])] = new Company(int.Parse(words[0]), words[1], int.Parse(words[2]));
            }
            file.Close();
        }

        public void set_taxes_cases()
        {
            //Case case_taxe = new TaxeFactory().CreateCase(); 
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader("/Users/huan/Projects/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Tax.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                board[int.Parse(words[0])] = new Taxes(int.Parse(words[0]), words[1], int.Parse(words[2]));
            }
            file.Close();
        }

        public void set_land_and_station_cases()
        {
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader("/Users/huan/Projects/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Land&Station.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                board[int.Parse(words[0])] = new Land(int.Parse(words[0]), words[1], int.Parse(words[2]), words[3]);
            }
            file.Close();
        }
    }
}
