using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP__lab10
{
    //15)	двигатель, двигатель внутреннего сгорания, дизель, турбореактивный двигатель;
    public class Engine : IRandomInit, IComparable, ICloneable
    {
        protected int weight;
        public Money money = new Money(IRandomInit.rnd.Next(10, 500));
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public Engine() { }
        public Engine(int weight)
        {
            this.weight = weight;
        }
        public Engine(Engine engine)
        {
            this.weight = engine.weight;
            this.money.Rubles = engine.money.Rubles;
        }
        public int CompareTo(Object? obj)
        {
            if (obj is Engine other)
                return this.Weight.CompareTo(other.Weight);
            else
                throw new ArgumentException("Object is not an Engine");
        }
        public void RandomInit() 
        {
            this.Weight = IRandomInit.rnd.Next(100, 10000);
        }
        public virtual void Show() 
        {
            Console.WriteLine("Двигатель запущен!");
        }
        public virtual void ShowInfo() 
        {
            Console.WriteLine($"{this.GetType().Name} \t\t\t\tweight: {Weight} kg");
        }
        public object Clone()
        {
            var temp = new Engine(this.Weight);
            temp.money = new Money(this.money.Rubles);
            return temp;
        }
        public object ShallowCopy()
        {
             return MemberwiseClone();
        }
    }

    public class InternalCombustionEngine : Engine
    {
        protected int cost;
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public InternalCombustionEngine(int _weight, int _cost) : base(_weight)
        {
            cost = _cost;
        }
        public InternalCombustionEngine() : base()
        {
            cost = 0;
        }

        public InternalCombustionEngine(InternalCombustionEngine _engine) : base(_engine)
        {
            cost = _engine.cost;
        }

        public static void Service()
        {
            InternalCombustionEngine[] toService = { new DiselEngine(), new TurbojetEngine() };
            
            Console.WriteLine($"\nКоличество различных типов ДВС, обслуживаемых автомастерской: {toService.Length}");

            foreach (InternalCombustionEngine p in toService)
            {
                if (p is DiselEngine)
                {
                    Console.WriteLine("Дизельные двигатели обслуживаются в автомастерской");
                }
                else if (p is TurbojetEngine)
                {
                    Console.WriteLine("Турбореактивные двигаетли обслуживаются в автомастерской");
                }
            }
        }
        public static int TotalCost(in int dEs, in int tEs)
        {
            int sum = 0;
            Console.WriteLine($"\nКоличество дизельных двигателей {dEs}");
            Console.WriteLine($"Количество турбореактиынх двигателей {tEs}");

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < dEs; ++i)
                engines.Add(new DiselEngine());
            for (int i = 0; i < tEs; ++i)
                engines.Add(new TurbojetEngine());

            foreach (var item in engines)
            {
                if (item is DiselEngine)
                {
                    sum += new DiselEngine().Cost;
                }
                else if (item is TurbojetEngine)
                {
                    sum += new TurbojetEngine().Cost;
                }

            }
            return sum;
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"{this.GetType().Name} \tweight: {Weight} kg");
        }
        public override void Show()
        {
            Console.WriteLine("Запущен двигатель внутреннего сгорания!");
        }
    }

    public class DiselEngine : InternalCombustionEngine
    {
        protected string fuel; //тип топлива
        public DiselEngine(int _weight, string _fuel, int _cost = 40000) : base(_weight, _cost)
        {
            fuel = _fuel;
        }
        public DiselEngine()
        {
            cost = 40000;
            fuel = "";
        }
        public DiselEngine(DiselEngine _engine): base(_engine)
        {
            fuel = _engine.fuel;
        }

        public override void Show()
        {
            Console.WriteLine("Запущен дизельный двигатель!");
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"{this.GetType().Name} \t\t\tweight: {Weight} kg");
        }
    }

    public class TurbojetEngine : InternalCombustionEngine
    {
        protected int combustionChamberVolume; //объем камеры сгорания
        public TurbojetEngine(int _weight, int _combustionChamberVolume, int _cost = 70000000) : base(_weight, _cost)
        {
            combustionChamberVolume = _combustionChamberVolume;
        }
        public TurbojetEngine() : base()
        {
            Cost = 7000000;
            combustionChamberVolume = 0;
        }
        public TurbojetEngine(TurbojetEngine _engine): base(_engine)
        {
            combustionChamberVolume = _engine.combustionChamberVolume;
        }

        public override void Show()
        {
            Console.WriteLine("Турбореактивный двигатель запущен!");
        }
        public override void ShowInfo()
        {
            Console.WriteLine($"{this.GetType().Name} \t\t\tweight: {Weight} kg");
        }
    }
}