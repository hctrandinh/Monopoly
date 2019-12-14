using System;
using Monopoly_SELMI_TRAN_DINH.Players;
using Monopoly_SELMI_TRAN_DINH.Dices;
using Monopoly_SELMI_TRAN_DINH.Board_Monopoly;
using Monopoly_SELMI_TRAN_DINH.Cards;
using Monopoly_SELMI_TRAN_DINH.Gameplay;

namespace Monopoly_SELMI_TRAN_DINH
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Rolling test = new Rolling();
            for(int i = 0; i < 11;  i++)
            {
                Dice[] dices = test.roll_dices();
                Console.WriteLine(dices[0].value + " " + dices[1].value);
            }
            
            Tokens_list test2 = new Tokens_list();
            test2.choose_token();
            test2.choose_token();
            test2.choose_token();
            

            Card_draw test3 = new Card_draw(2, "Chance");
            test3.read_all_card_desc();
            
            Board test4 = new Board();
            */
            Gaming theGame = new Gaming();
            theGame.launch();
        }
    }
}
