using System;
namespace Monopoly_SELMI_TRAN_DINH.Dices
{
    public class Rolling
    {
        private Dice[] dices { get; set; }
        private int result { get; set; }
        Random rand = new Random();

        public Rolling()
        {
            dices = new Dice[2];
            dices[0] = new Dice();
            dices[1] = new Dice();
        }

        public Dice[] roll_dices()
        {
            dices[0].value = rand.Next(1, 7);
            dices[1].value = rand.Next(1, 7);
            if(dices[0].check_value() && dices[1].check_value())
            {
                return dices;
            }
            return null;
        }
    }
}
