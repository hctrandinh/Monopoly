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
    } }

