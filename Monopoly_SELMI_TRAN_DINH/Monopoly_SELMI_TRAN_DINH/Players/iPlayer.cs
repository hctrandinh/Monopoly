using System;
namespace Monopoly_SELMI_TRAN_DINH.Players
{
    public interface iPlayer
    {
        public abstract int starting_money { get; set; }
        public abstract string token { get; set; }
        public abstract string name { get; set; }
        public int position_number { get; set; }
        public int possession { get; set; }
        public bool freedom { get; set; }
        public bool lost { get; set; }
        public bool jailed { get; set; }
        public int time_in_jail_left { get; set; }

    }
}
