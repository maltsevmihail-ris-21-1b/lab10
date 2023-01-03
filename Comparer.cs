using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP__lab10
{
    public class SortByWeight : IComparer
    {
        public int Compare(Object? obj1, Object? obj2)
        {
            if (obj1 is Engine other1 && obj2 is Engine other2)
                return other1.Weight.CompareTo(other2.Weight);
            else
                throw new ArgumentException("Object is not an Engine");
        }
    }
}
