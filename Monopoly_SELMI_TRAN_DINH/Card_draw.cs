using System;
namespace Monopoly_SELMI_TRAN_DINH.Board_Monopoly
{
    public class Card_draw : Case
    {
        //Position on the board.
        //Name of the land case.

        public Card_draw(int pos, string nm)
        {
            base.position = pos; //Chances positions: 7, 22, 36 / Communities positions: 2, 17, 33
            base.name = nm;
        }
    }
}
