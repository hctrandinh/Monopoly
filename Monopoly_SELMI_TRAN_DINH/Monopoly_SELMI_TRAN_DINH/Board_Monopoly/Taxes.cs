using System;
namespace Monopoly_SELMI_TRAN_DINH.Board_Monopoly
{
    public class Taxes : Case
    {
        //Position on the board.
        //Name of the land case.
        //Price you have to pay.

        public Taxes(int pos, string nm, int pr)
        {
            base.position = pos;
            base.name = nm;
            base.price = pr;
        }
    }
}
