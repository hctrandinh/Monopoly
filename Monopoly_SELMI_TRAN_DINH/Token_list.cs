using System;
namespace Monopoly_SELMI_TRAN_DINH.Players
{
    public class Tokens_list
    {
        //Going from 1 to 8, given a name for further board implementation, easier to recognize having names already given to tokens.
        enum tokens_list { Scottish_Terrier = 1, Battleship_1935, Race_Car_Mid_1935, Top_Hat_1935, Penguin_2017, T_Rex_2017, Cat, Rubber_Ducky_2017 };
        //Going from 1 to 8, changes to -1 when token has been chosen, disabling capacity to take the specific token.
        private int[] list { get; set; }
        //Going from 1 to 8, changes to -1 when token has been chosen, disabling capacity to take the specific token.
        private int[] list_copy { get; set; }
        //Stores the names of all tokens.
        private string[] tokens_name { get; set; }
        public Tokens_list()
        {
            this.list = new int[] { (int) tokens_list.Scottish_Terrier,
                (int) tokens_list.Battleship_1935,
                (int) tokens_list.Race_Car_Mid_1935,
                (int) tokens_list.Top_Hat_1935,
                (int) tokens_list.Penguin_2017,
                (int) tokens_list.T_Rex_2017,
                (int) tokens_list.Cat,
                (int) tokens_list.Rubber_Ducky_2017 };

            //No list_copy = list because they will get the same reference.
            this.list_copy = new int[8];
            foreach (int element in list)
            {
                list_copy[element - 1] = element;
            }

            this.tokens_name = new string[] { "Scottish_Terrier", "Battleship_1935", "Race_Car_Mid_1935",
            "Top_Hat_1935", "Penguin_2017", "T_Rex_2017", "Cat", "Rubber_Ducky_2017"};
        }

        /// <summary>
        /// Check the disponibility of a token.
        /// </summary>
        /// <param name="choice"></param>
        /// <returns>True if disponible, false if not.</returns>
        public bool check_disponibility(int choice)
        {
            if (list[choice - 1] == choice)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Allows user to choose a token.
        /// </summary>
        /// <returns>string of the name of the token.</returns>
        public string choose_token()
        {
            Console.WriteLine("Choose one disponible token:");
            foreach (int element in list_copy)
            {
                if (check_disponibility(element))
                {
                    Console.WriteLine(element + ": " + tokens_name[element - 1]);
                }
            }
            Console.Write("Choice: ");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            while (choice < 1 || choice > 8 || !check_disponibility(choice))
            {
                Console.WriteLine("Not disponible. Please choose again.");
                Console.Write("Choice: ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");
            }
            list[choice - 1] = -1;
            return tokens_name[choice - 1];
        }
    }
}
