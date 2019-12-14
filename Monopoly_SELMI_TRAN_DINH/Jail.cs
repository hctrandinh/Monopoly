using System;
namespace Monopoly_SELMI_TRAN_DINH.Board_Monopoly
{
    public class Jail : Case
    {
        //Position on the board.
        //Name of the land case.
        //Property of x player.
        //Count the number of turn left in jail
        private int count;

        public Jail()
        {
            base.position = 10;
            base.name = "Jail";
            base.property_of = "";
            this.count = 0;
        }

        public void go_to_jail(string nm)
        {
            base.name = nm;
            this.count = 3;
        }

        public void road_to_freedom()
        {
            this.count--;
            if (count == 0)
            {
                base.name = ""; //Ingame, this equals to freedom, you can move again.
            }
        }
    }
}
