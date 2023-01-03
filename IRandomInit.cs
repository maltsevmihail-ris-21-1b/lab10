using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP__lab10
{
    public interface IRandomInit
    {
        static Random rnd = new Random();
        void RandomInit();
        void ShowInfo();
    }
}
