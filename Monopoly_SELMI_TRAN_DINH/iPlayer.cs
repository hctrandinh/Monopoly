using System;
namespace Monopoly_SELMI_TRAN_DINH.Players
{
    public interface iPlayer
    {
        int starting_money { get; set; }
        string token { get; set; }
        string name { get; set; }
        int position_number { get; set; }
        int possession { get; set; }
        bool freedom { get; set; }
        bool lost { get; set; }
        bool jailed { get; set; }
        int time_in_jail_left { get; set; }

    }
}
