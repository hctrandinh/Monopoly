using System;
namespace Monopoly_SELMI_TRAN_DINH.Board_Monopoly
{
    public class To_Jail : Case
    {
        //Position on the board.
        //Name of the land case.

        public To_Jail()
        {
            base.position = 30;
            base.name = "Go to jail !";
        }

        public void send_to_jail()
        {
            //Pas forcément à placer là.
            //player.position = 10;
        }
    }
}
