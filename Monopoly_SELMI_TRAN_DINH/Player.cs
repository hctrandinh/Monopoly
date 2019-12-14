using System;
namespace Monopoly_SELMI_TRAN_DINH.Players
{
    public class Player : iPlayer
    {
        public int starting_money { get; set; }
        public string token { get; set; } //Will get the token name from Token_list.
        public string name { get; set; } //Player name.
        public int position_number { get; set; }
        public int possession { get; set; }
        public int station_possession { get; set; }
        public bool freedom { get; set; }
        public bool lost { get; set; }
        public bool jailed { get; set; }
        public int time_in_jail_left { get; set; }

        public Player(Tokens_list tokens)
        {
            this.starting_money = 1500;
            this.position_number = 0;
            this.name = enter_name();
            this.token = tokens.choose_token();
            this.possession = 0;
            this.station_possession = 0;
            this.freedom = false;
            this.lost = false;
            this.jailed = false;
            this.time_in_jail_left = 0;

        }

        public string enter_name()
        {
            Console.WriteLine("Please enter your name: ");
            string res = "";
            while (res == "")
            {
                res = Console.ReadLine();
            }
            return res;
        }

    }
}
