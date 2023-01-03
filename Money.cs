using System;
using System.Collections;
using System.Diagnostics.Metrics;

namespace OOP__lab10
{
    public class Money : IRandomInit, ICloneable
    {
        private int rub;
        public int Rubles
        {
            get { return rub; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Рублей не может быть меньше нуля!");
                    rub = 0;
                }
                else
                {
                    rub = value;
                }
            }
        }

        public object Clone()
        {
            return new Money(this.Rubles);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{GetType().Name} \t\t\t\t{Rubles} руб.");
        }

        public void RandomInit()
        {
            this.Rubles = IRandomInit.rnd.Next(500);
        }

        public Money(Money money)
        {
            Rubles = money.rub;
        }
        public Money(int iRubles)
        {
            Rubles = iRubles;
        }
        public Money()
        {

        }
    }
}
