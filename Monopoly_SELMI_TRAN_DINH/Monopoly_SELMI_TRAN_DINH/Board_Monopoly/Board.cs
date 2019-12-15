using System;
using Monopoly_SELMI_TRAN_DINH.Cards;
using System.IO;

namespace Monopoly_SELMI_TRAN_DINH.Board_Monopoly
{
    public class Board
    {
        Case case_start = new StartFactory().GetCase();
        Case case_jail = new CompanyFactory().GetCase();
        Case case_free_park = new CompanyFactory().GetCase();
        Case case_to_jail = new CompanyFactory().GetCase();
        public Case[] board;
        public Chance chance_cards;
        public Community community_cards;
        private static Board instance;//Singleton
        private static readonly object locker = new object();
        string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

        public static Board Instance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)
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
            this.board[0] = case_start.GetCase();
            this.board[10] = case_jail.GetCase();
            this.board[20] = case_free_park.GetCase();
            this.board[30] = case_to_jail.GetCase();
            set_chance_and_community();
            set_company_cases();
            set_land_and_station_cases();
            set_taxes_cases();
            chance_cards = new Chance();
            community_cards = new Community();
        }

        public void set_chance_and_community() //Factory Done
        {
            Case case_draw = new CardDrawFactory().GetCase();
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(dir + "/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Chance&Community.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                board[int.Parse(words[0])] = case_draw.GetCase();
            }
            file.Close();
        }

        public void set_company_cases() //Factory Done
        {
            Case case_comp = new CompanyFactory().GetCase();
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(dir + "/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Company.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                board[int.Parse(words[0])] = case_comp.GetCase();
            }
            file.Close();
        }

        public void set_taxes_cases() //Factory Done 
        {
            Case case_taxe = new TaxeFactory().GetCase();
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(dir + "/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Tax.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                board[int.Parse(words[0])] = case_taxe.GetCase();
            }
            file.Close();
        }

        public void set_land_and_station_cases() //Factory Done
        {
            Case case_land = new LandFactory().GetCase();
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(dir + "/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Land&Station.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                board[int.Parse(words[0])] = case_land.GetCase();
            }
            file.Close();
        }
    }
}
