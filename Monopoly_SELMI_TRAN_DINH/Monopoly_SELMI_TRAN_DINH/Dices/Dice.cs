using System;
namespace Monopoly_SELMI_TRAN_DINH.Dices
{
    public class Dice
    {
        public int value { get; set; }

        public Dice()
        {
        }

        public bool check_value()
        {
            if(value >= 1 && value <= 6)
            {
                return true;
            }
            return false;
        }
    }
}
