using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public static class Extensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list, Random rng)
        {
            var listCopy = list.ToArray().Clone() as T[];
            int n = listCopy.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = listCopy[k];
                listCopy[k] = listCopy[n];
                listCopy[n] = value;
            }
            return listCopy;
        }

        public static T GetRandom<T>(this IList<T> list, Random rng)
        {
            var len = list.Count;
            var rndm = rng.Next(0, len);
            return list[rndm];
        }
    }
}
