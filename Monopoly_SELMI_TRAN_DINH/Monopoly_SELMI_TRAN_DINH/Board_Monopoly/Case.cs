using System;
namespace Monopoly_SELMI_TRAN_DINH.Board_Monopoly
{
    public abstract class Case
    {
        protected int position { get; set; }
        protected string name { get; set; }
        protected int price { get; set; }
        protected string property_of { get; set; }
        protected string color { get; set; }
        public Case GetCase()
        {
            return this;
        }

        public Case()
        {
        }

        public int get_pos()
        {
            return this.position;
        }

        public string get_nm()
        {
            return this.name;
        }

        public int get_pr()
        {
            return this.price;
        }

        public string get_p_o()
        {
            return this.property_of;
        }

        public void set_p_o(string p_o)
        {
            this.property_of = p_o;
        }

        public string get_col()
        {
            return this.color;
        }
    }
}
