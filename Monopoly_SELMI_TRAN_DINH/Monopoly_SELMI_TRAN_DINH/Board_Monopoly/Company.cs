using System;
namespace Monopoly_SELMI_TRAN_DINH.Board_Monopoly
{
    public class Company:Case
    {
        //Position on the board.
        //Name of the land case.
        //Price to buy the company.
        //Property of x player.

        public Company(int pos, string nm, int pr)
        {
            base.position = pos;
            base.name = nm;
            base.price = pr;
            base.property_of = "";
        }
    }
}
