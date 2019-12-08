using System;
using Monopoly_SELMI_TRAN_DINH.Players;
using Monopoly_SELMI_TRAN_DINH.Dices;
using Monopoly_SELMI_TRAN_DINH.Board_Monopoly;
using Monopoly_SELMI_TRAN_DINH.Cards;
namespace Monopoly_SELMI_TRAN_DINH.Gameplay
{
    public class Gaming
    {
        private Player[] list;
        Board monopoly = new Board();
        Rolling two_dices = new Rolling();
        Chance chance_cards = new Chance();
        Community community_cards = new Community();
        private int[] buyable_cases = new int[26];
        private int[] tax_cases = new int[2];
        private int[] cc_cases = new int[6];
        private int[] company_cases = new int[2];

        public Gaming()
        {
            create_players();
            set_cases();
        }

        public void set_cases()
        {
            string line;
            int pos = 0;
            System.IO.StreamReader file = new System.IO.StreamReader("/Users/huan/Projects/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Land&Station.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                buyable_cases[pos] = int.Parse(words[0]);
                pos++;
            }
            file.Close();

            pos = 0;
            file = new System.IO.StreamReader("/Users/huan/Projects/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Tax.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                tax_cases[pos] = int.Parse(words[0]);
                pos++;
            }
            file.Close();

            pos = 0;
            file = new System.IO.StreamReader("/Users/huan/Projects/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Chance&Community.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                cc_cases[pos] = int.Parse(words[0]);
                pos++;
            }
            file.Close();

            pos = 0;
            file = new System.IO.StreamReader("/Users/huan/Projects/Monopoly_SELMI_TRAN_DINH/Monopoly_SELMI_TRAN_DINH/bin/Debug/Company.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                company_cases[pos] = int.Parse(words[0]);
                pos++;
            }
            file.Close();
        }

        public int check_case_type(int val)
        {
            foreach(int element in buyable_cases)
            {
                if(val == element)
                {
                    return 1;
                }
            }
            foreach (int element in tax_cases)
            {
                if (val == element)
                {
                    return 2;
                }
            }
            foreach (int element in cc_cases)
            {
                if (val == element)
                {
                    return 3;
                }
            }
            foreach (int element in company_cases)
            {
                if (val == element)
                {
                    return 4;
                }
            }
            return -1;
        }

        public void create_players()
        {
            Tokens_list tokens = new Tokens_list();
            Console.WriteLine("Welcome to the Monopoly Game!\n");
            Console.WriteLine("How many players?");
            int nb = int.Parse(Console.ReadLine());
            while(nb < 1 || nb > 5)
            {
                Console.WriteLine("Please choose between 1 and 5 players.");
                nb = int.Parse(Console.ReadLine());
            }
            list = new Player[nb];
            for(int index = 0; index < nb; index++)
            {
                list[index] = new Player(tokens);
            }
        }

        public int get_player_id(string name)
        {
            int count = 0;
            foreach(Player element in list)
            {
                if(element.name == name)
                {
                    return count;
                }
                count++;
            }
            return -1;
        }

        //
        public int color_count(int player_id, int position)
        {
            string color = monopoly.board[position].get_col();
            int count = 0;
            foreach(Case element in monopoly.board)
            {
                if(element.get_p_o() == list[player_id].name && element.get_col() == color)
                {
                    count++;
                }
            }
            return count;
        }

        public void pay_rent(int player_id, int position)
        {
            //Case 1: You are on a station.
            if (list[player_id].position_number == 5 || list[player_id].position_number == 15 || list[player_id].position_number == 25
                        || list[player_id].position_number == 35)
            {
                Console.WriteLine("You got to someone's station, you pay: " + (25 * list[get_player_id(list[player_id].name)].station_possession));
                Console.WriteLine("Your money before paying: " + list[player_id].starting_money);
                list[player_id].starting_money -= 25 * list[get_player_id(list[player_id].name)].station_possession;
                Console.WriteLine("Your money after paying: " + list[player_id].starting_money);
                list[get_player_id(monopoly.board[position].get_p_o())].starting_money += 25 * list[get_player_id(list[player_id].name)].station_possession;

            }

            //Case 2: You are on a company.
            else if (list[player_id].position_number == 12 || list[player_id].position_number == 28)
            {
                Console.WriteLine("Press enter to roll dices: ");
                Console.ReadLine();
                Dice[] res = two_dices.roll_dices();
                Console.WriteLine("Dice res: " + (res[0].value + res[1].value));
                if(monopoly.board[12].get_p_o() == list[player_id].name && monopoly.board[28].get_p_o() == list[player_id].name)
                {
                    Console.WriteLine("You got to someone's company, he possesses both, " +
                        "you pay 10 times the dices results: " + ((res[0].value + res[1].value) * 10));

                    Console.WriteLine("Your money before paying: " + list[player_id].starting_money);
                    list[player_id].starting_money -= ((res[0].value + res[1].value) * 10);
                    Console.WriteLine("Your money after paying: " + list[player_id].starting_money);
                    list[get_player_id(monopoly.board[position].get_p_o())].starting_money += ((res[0].value + res[1].value) * 10);

                }
                else
                {
                    Console.WriteLine("You got to someone's company, he possesses one, " +
                        "you pay 4 times the dices results: " + ((res[0].value + res[1].value) * 4));

                    Console.WriteLine("Your money before paying: " + list[player_id].starting_money);
                    list[player_id].starting_money -= ((res[0].value + res[1].value) * 4);
                    Console.WriteLine("Your money after paying: " + list[player_id].starting_money);
                    list[get_player_id(monopoly.board[position].get_p_o())].starting_money += ((res[0].value + res[1].value) * 4);

                }
            }

            //Case 3: Normal land.
            else
            {
                int multiplier = 1;
                Console.WriteLine("Number of land with this color possessed by player: " + color_count(player_id, position));
                if(color_count(player_id, position) == 3)
                {
                    multiplier = 2;
                }
                Console.WriteLine("You got to someone's land, you pay: " + (monopoly.board[position].get_pr() * multiplier));
                Console.WriteLine("Your money before paying: " + list[player_id].starting_money);
                list[player_id].starting_money -= (monopoly.board[position].get_pr() * multiplier);
                Console.WriteLine("Your money after paying: " + list[player_id].starting_money);
                list[get_player_id(monopoly.board[position].get_p_o())].starting_money += (monopoly.board[position].get_pr() * multiplier);
            }
        }

        public void select_action(int player_id, int position)
        {
            int type = check_case_type(position);
            Console.WriteLine("Type: " + type);
            if(type == 1)
            {
                Console.WriteLine("Lands&Stations action...");
                if(monopoly.board[position].get_p_o() != "" && monopoly.board[position].get_p_o() != list[player_id].name)
                {
                    pay_rent(player_id, position);
                }
                else
                {
                    buy(player_id, position);
                }
            }
            else if (type == 2)
            {
                Console.WriteLine("Tax action...");
                list[player_id].starting_money -= monopoly.board[position].get_pr();
            }
            else if (type == 3)
            {
                Console.WriteLine("Cards action...");
                if(monopoly.board[position].get_nm() == "Chance")
                {
                    chance_cards.draw_and_play_card(list[player_id], list);
                    Console.WriteLine("// " + list[player_id].position_number + " " + monopoly.board[list[player_id].position_number].get_nm());
                }
                else
                {
                    community_cards.draw_and_play_card(list[player_id], list);
                    Console.WriteLine("// " + list[player_id].position_number + " " + monopoly.board[list[player_id].position_number].get_nm());
                }
            }
            else if (type == 4)
            {
                Console.WriteLine("Company action...");
                if (monopoly.board[position].get_p_o() == "")
                {
                    buy(player_id, position);
                }
            }
            else
            {
                //Deux if, c'est important ici.
                if (monopoly.board[position].get_pos() == 30)
                {
                    list[player_id].position_number = 10;
                    position = 10;
                }
                if (monopoly.board[position].get_pos() == 10)
                {
                    list[player_id].jailed = true;
                    list[player_id].time_in_jail_left = 3;
                }
            }
        }

        public bool jailed(Player player)
        {
            if(player.time_in_jail_left == 0)
            {
                player.jailed = false;
            }
            if(!player.jailed)
            {
                return false;
            }
            return true;
        }

        public void jail_actions(Player player)
        {
            Console.WriteLine("You're in jail, here are your options:\n1: Pay 50$\n2: Roll dices and try getting 3 doubles\n3:Use free card\n");
            int choice = int.Parse(Console.ReadLine());
            while(choice != 1 && choice != 2 && choice != 3)
            {
                Console.WriteLine("You're in jail, here are your options:\n1: Pay 50$\n2: Roll dices and try getting 3 doubles\n3:Use free card\n");
                choice = int.Parse(Console.ReadLine());
            }
            if(choice == 1)
            {
                player.time_in_jail_left = 0;
                player.jailed = false;
                player.starting_money -= 50;
            }
            if (choice == 2)
            {
                Dice[] res = two_dices.roll_dices();
                Dice[] res1 = two_dices.roll_dices();
                Dice[] res2 = two_dices.roll_dices();
                if(res[0].value == res[1].value && res1[0].value == res1[1].value && res2[0].value == res2[1].value)
                {
                    player.time_in_jail_left = 0;
                    player.jailed = false;
                }
            }
            if (choice == 3)
            {
                if(player.freedom)
                {
                    player.time_in_jail_left = 0;
                    player.jailed = false;
                }
                else
                {
                    Console.WriteLine("You can't cheat bitch !");
                    jail_actions(player);
                }
            }
        }

        public void buy(int player_id, int position)
        {
            Console.WriteLine("Your money: " + list[player_id].starting_money);
            Console.WriteLine("Do you want to buy: " + monopoly.board[position].get_nm() + "? y/n");
            string choice = Console.ReadLine();
            while(choice != "y" && choice != "n")
            {
                Console.WriteLine("Do you want to buy: " + monopoly.board[position].get_nm() + "? y/n");
                choice = Console.ReadLine();
            }
            if(choice == "y")
            {
                if(list[player_id].starting_money > monopoly.board[position].get_pr())
                {
                    if (list[player_id].position_number == 5 || list[player_id].position_number == 15 || list[player_id].position_number == 25
                        || list[player_id].position_number == 35)
                    {
                        list[player_id].station_possession++;
                    }
                    Console.WriteLine("Your money before paying: " + list[player_id].starting_money);
                    list[player_id].starting_money -= monopoly.board[position].get_pr();
                    Console.WriteLine("Your money after paying: " + list[player_id].starting_money);
                    monopoly.board[position].set_p_o(list[player_id].name);
                    list[player_id].possession++;
                }
                else
                {
                    Console.WriteLine("You can't buy this, not enough money...");
                }
            }
        }

        public void launch()
        {
            bool playing = true; //To continue playing while there is no winner.
            int nb_players = list.Length; //Total number of players.
            int players_left = list.Length; //Total number of players left in the game.
            int player_id = 0; //Player id initialization.
            int temp = 0; //Will be used to check if we pass the start again.

            while(playing)
            {
                //Check if player has lost.
                player_id = eliminated(player_id, nb_players);

                //Check if ther is a winner.
                if (players_left == 1)
                {
                    Console.WriteLine(list[player_id].name + " is the winner.");
                    break;
                }

                //Check if the player is jailed, if true, propose action for this turn.
                if(list[player_id].jailed)
                {
                    jail_actions(list[player_id]);
                }

                //If not jailed, play as normal.
                else
                {
                    temp = list[player_id].position_number;

                    //Launching the dices.
                    Dice[] res = two_dices.roll_dices();
                    Console.WriteLine("Dice res: " + (res[0].value + res[1].value));

                    //Calculating new position.
                    list[player_id].position_number = (list[player_id].position_number + (res[0].value + res[1].value)) % 40; //When reaching position 40, goes back to 0.

                    //Printing position information.
                    Console.WriteLine(list[player_id].name + " -> " +
                        "Position: " + list[player_id].position_number + " Location: " +
                        monopoly.board[list[player_id].position_number].get_nm());

                    select_action(player_id, list[player_id].position_number);

                    //Check if we passed position 0 again and gives to player 200$ if true.
                    if (temp > list[player_id].position_number)
                    {
                        list[player_id].starting_money += 200;
                        Console.WriteLine("You got 200$");
                    }
                }

                //End of turn, reduce the time left in jail if jailed, unlock player if time has passed and make him pay 50$.
                if (list[player_id].jailed)
                {
                    if (list[player_id].time_in_jail_left > 0)
                    {
                        list[player_id].time_in_jail_left--;
                    }
                    else if(list[player_id].time_in_jail_left <= 0)
                    {
                        list[player_id].time_in_jail_left = 0;
                        list[player_id].jailed = false;
                        list[player_id].starting_money -= 50;
                        Console.WriteLine("Your money after paying your freedom: " + list[player_id].starting_money);
                    }
                }

                //Press enter to end turn.
                Console.WriteLine("Press enter to end your turn.");

                //If no more money, player has lost.
                if(list[player_id].starting_money <= 0)
                {
                    if(is_eliminated(player_id))
                    {
                        players_left--;
                        list[player_id].lost = true;
                    }
                    Console.WriteLine("You lost.");
                }

                Console.WriteLine("\n");
                Console.ReadLine();

                //Switching to next player.
                player_id = (player_id + 1) % nb_players;
            }
        }

        public int eliminated(int player_id, int nb_players)
        {
            if (list[player_id].starting_money <= 0)
            {
                return (player_id + 1) % nb_players;
            }
            return player_id;
        }

        public bool is_eliminated(int player_id)
        {
            if (list[player_id].starting_money <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
