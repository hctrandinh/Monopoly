using System;
using Monopoly_SELMI_TRAN_DINH.Cards;
using Monopoly_SELMI_TRAN_DINH.Players;
namespace Monopoly_SELMI_TRAN_DINH.Cards
{
    public class Chance
    {
        Random rand = new Random();
        //Name of the land case.
        private string name { get; set; }
        //Cards description.
        private string[] card_desc { get; set; }
        //Card id will be used in game to refer to a specific action.
        private int[] card_id { get; set; }

        public Chance()
        {
            this.name = "Chance";
            this.card_desc = new string[16];
            this.card_id = new int[16];
            set_chance_cards();
        }

        public void set_chance_cards()
        {
            string line;
            int pos = 0;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader("/Users/huan/Projects/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Chance.txt");
            while ((line = file.ReadLine()) != null)
            {
                this.card_desc[pos] = line;
                this.card_id[pos] = pos;
                pos++;
            }

            file.Close();
        }

        public void draw_and_play_card(Player player, Player[] list)
        {
            int id = rand.Next(0, 16);
            Console.WriteLine("Card drawn:");
            Console.WriteLine(card_desc[id]);
            string line;
            int pos = 0;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader("/Users/huan/Projects/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Chance_actions.txt");
            while ((line = file.ReadLine()) != null && pos != id)
            {
                pos++;
            }
            file.Close();
            string[] words = line.Split(',');
            card_action(player, list, int.Parse(words[0]), int.Parse(words[1]));
        }

        public void card_action(Player player, Player[] list, int action, int value = -5)
        {
            if (action == 1) { move(player, value); }
            else if(action == 2) { move_one(player); }
            else if (action == 3) { nearest_railroad(player); }
            else if (action == 4) { change_money(player, value); }
            else if (action == 5) { get_free_card(player); }
            else if (action == 6) { repair(player); }
            else { pay_all(player, list); }
        }

        public void move(Player player, int position)
        {
            player.position_number = position;
            if(player.position_number == 10)
            {
                player.jailed = true;
                player.time_in_jail_left = 3;
            }
        }

        public void move_one(Player player)
        {
            player.position_number += 1;
        }

        public void nearest_railroad(Player player)
        {
            while(player.position_number != 5 && player.position_number != 15
                && player.position_number != 155 && player.position_number != 25)
            {
                player.position_number += 1;
            }
        }

        public void change_money(Player player, int value)
        {
            player.starting_money += value;
        }

        public void get_free_card(Player player)
        {
            player.freedom = true;
        }

        public void repair(Player player)
        {
            player.starting_money -= player.possession * 25;
        }

        public void pay_all(Player player, Player[] list)
        {
            foreach(Player element in list)
            {
                if(!element.lost && element.name != player.name)
                {
                    player.starting_money -= 50;
                    element.starting_money += 50;
                }
            }
        }

        public void read_all_card_desc()
        {
            foreach (string element in this.card_desc)
            {
                Console.WriteLine(element);
                Console.WriteLine();
            }
        }
    }
}
