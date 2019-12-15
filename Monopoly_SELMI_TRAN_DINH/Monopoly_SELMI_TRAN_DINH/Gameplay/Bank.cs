using Monopoly_SELMI_TRAN_DINH.Players;
using System;
using System.Collections.Generic;

namespace Monopoly_SELMI_TRAN_DINH.Gameplay
{
    abstract class Bank
    {
        private double _stock;
        public Bank(double stock)
        {
            this._stock = stock;
        }
        public double _Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                double temp = _Stock;
                _stock = value;
                if (temp != _stock)
                {
                    Notify();
                }
            }
        }
        private List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer observer in _observers)
            {
                observer.Update(this);
            }
        }
        public double stock { get; set; }
    }
}

