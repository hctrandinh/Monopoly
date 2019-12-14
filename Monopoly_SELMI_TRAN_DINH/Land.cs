using System;
namespace Monopoly_SELMI_TRAN_DINH.Board_Monopoly
{
    public class Land : Case
    {
        //Position on the board.
        //Name of the land case.
        //Initial price of the land case.
        //Property of x player.
        //Color of the case. Color = "Station" if Station case.

        public Land(int pos, string nm, int pr, string col)
        {
            base.position = pos;
            base.name = nm;
            base.price = pr;
            base.color = col;
            base.property_of = "";
        }
    }
}
