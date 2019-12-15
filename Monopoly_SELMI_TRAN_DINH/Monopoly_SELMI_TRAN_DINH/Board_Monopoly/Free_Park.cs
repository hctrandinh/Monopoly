using System;
namespace Monopoly_SELMI_TRAN_DINH.Board_Monopoly
{
    public class Free_Park : Case
    {
        //Position on the board.
        //Name of the land case.

        public Free_Park(int position, string name)
        {
            base.position = 20;
            base.name = "Free Park";
        }
    }
}
