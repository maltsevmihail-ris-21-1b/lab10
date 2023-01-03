using System.Collections;

namespace OOP__lab10
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine[] engines =
            {
                new Engine(),
                new DiselEngine(),
                new InternalCombustionEngine(),
                new TurbojetEngine()
            };

            Console.WriteLine("Просмотр элементов с помощью виртуальных функций\n");
            foreach (Engine _engine in engines)
            {
                _engine.Show();
            }

            Console.WriteLine("\n-------------------------------------------------------------------------------");

            Console.WriteLine("Выполнение запросов");

            InternalCombustionEngine.Service();

            int dEs = IRandomInit.rnd.Next(1,5);
            int tEs = IRandomInit.rnd.Next(1,5);

            Console.WriteLine($"Общая сумма всех купленных ДВС: {InternalCombustionEngine.TotalCost(dEs, tEs)}");
            Console.WriteLine("-------------------------------------------------------------------------------");

            Console.WriteLine("Инициализация эелементов с помощью метода RandomInit и просмотр массива IRandomInit из элементов разных классов");
            IRandomInit[] array =
                {
                    new Money(),
                    new Money(),
                    new DiselEngine(),
                    new Engine(),
                    new TurbojetEngine()
                };
            foreach (IRandomInit init in array)
            {
                init.RandomInit();
                init.ShowInfo();
            }
            Console.WriteLine("-------------------------------------------------------------------------------");


            IRandomInit[] newEngines =
            {
                new Engine(),
                new DiselEngine(),
                new TurbojetEngine(),
                new TurbojetEngine(),
                new InternalCombustionEngine(),
                new DiselEngine()
            };
            Console.WriteLine("\nСортировка массива с помощью интерфейса ICompareable");
            foreach (IRandomInit item in newEngines)
            {
                item.RandomInit();
                item.ShowInfo();
            }

            Array.Sort(newEngines);
            
            Console.WriteLine("\n");
            Console.WriteLine("Отсортированный массив:");

            foreach (IRandomInit item in newEngines)
            {
                item.ShowInfo();
            }

            Console.WriteLine("\nСортировка массива с помощью интерфейса IComparer");
            foreach (IRandomInit item in newEngines)
            {
                item.RandomInit();
                item.ShowInfo();
            }

            Array.Sort(newEngines, new SortByWeight());

            Console.WriteLine("\n");
            Console.WriteLine("Отсортированный массив:");
            foreach (IRandomInit item in newEngines)
            {
                item.ShowInfo();
            }

            Console.WriteLine("\nБинарный поиск");
            Console.Write("Введите ключевое значение: ");

            string str;
            int _keyValue;
            try
            {
                str = Console.ReadLine();
                _keyValue = Int32.Parse(str);
                InternalCombustionEngine _toFindEngie = new InternalCombustionEngine();
                _toFindEngie.Weight = _keyValue;
                int index = Array.BinarySearch(newEngines, _toFindEngie);

                Console.WriteLine($"Индекс элемента с атрибутом weight = {_toFindEngie.Weight}:\t{index}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное занчение!");
            }
            Console.WriteLine("-------------------------------------------------------------------------------");

            Console.WriteLine("Клонирование");

            Engine engine = new Engine(1500);
            Console.WriteLine($"engine:\nMoney = {engine.money.Rubles}\nWeight = {engine.Weight}\n");

            Engine newEngine = (Engine)engine.Clone();
            Console.WriteLine($"newEngine:\nMoney = {newEngine.money.Rubles}\nWeight = {newEngine.Weight}");
            newEngine.money.Rubles += 400;
            newEngine.Weight = 345;

            Console.WriteLine("newEngine.Money += 400;\r\nnewEngine.Weight = 345;\n");
            Console.WriteLine($"engine:\nMoney = {engine.money.Rubles}\nWeight = {engine.Weight}\n");

            Console.WriteLine($"newEngine:\nMoney = {newEngine.money.Rubles}\nWeight = {newEngine.Weight}\n");


            Console.WriteLine("\n-------------------------------------------------------------------------------");
            Console.WriteLine("Поверностное клонирование");

            Engine __engine = new Engine(1500);
            Console.WriteLine($"engine:\nMoney = {__engine.money.Rubles}\nWeight = {__engine.Weight} \n");
          
            Engine __newEngine = (Engine)__engine.ShallowCopy();
            Console.WriteLine($"newEngine:\nMoney = {__newEngine.money.Rubles}\nWeight = {__newEngine.Weight}");
            __newEngine.money.Rubles += 400;
            __newEngine.Weight = 345;

            Console.WriteLine("newEngine.Money += 400;\r\nnewEngine.Weight = 345;\n");
            Console.WriteLine($"engine:\nMoney = {__engine.money.Rubles}\nWeight = {__engine.Weight} \n");

            Console.WriteLine($"newEngine:\nMoney = {__newEngine.money.Rubles}\nWeight = {__newEngine.Weight}");
        }
    }
}