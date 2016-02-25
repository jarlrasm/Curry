using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class Tools
    {
        public static Func<T, Func<T2, TRet>> Curry<T, T2, TRet>(this Func<T, T2, TRet> func)
        {
            return x => y => func(x, y);
        }


        public static Func<T, Func<T2, Func<T3, TRet>>> Curry<T, T2, T3, TRet>(this Func<T, T2, T3, TRet> func)
        {
            return x => y => z => func(x, y, z);
        }


        public static Func<T, Func<T2, Func<T3, Func<T4, TRet>>>> Curry<T, T2, T3, T4, TRet>(this Func<T, T2, T3, T4, TRet> func)
        {
            return x1 => x2 => x3 => x4 => func(x1, x2, x3, x4);
        }


        public static Func<T, Func<T2, Func<T3, Func<T4, Func<T5, TRet>>>>> Curry<T, T2, T3, T4, T5, TRet>(
            this Func<T, T2, T3, T4, T5, TRet> func)
        {
            return x1 => x2 => x3 => x4 => x5 => func(x1, x2, x3, x4, x5);
        }


        public static Func<T2, TRet> Partial<T, T2, TRet>(this Func<T, T2, TRet> func, T arg)
        {
            return x => func(arg, x);
        }


        public static Func<T2, T3, TRet> Partial<T, T2, T3, TRet>(this Func<T, T2, T3, TRet> func, T arg)
        {
            return (x, y) => func(arg, x, y);
        }


        public static Func<T2, T3, T4, TRet> Partial<T, T2, T3, T4, TRet>(this Func<T, T2, T3, T4, TRet> func, T arg)
        {
            return (x1, x2, x3) => func(arg, x1, x2, x3);
        }


        public static Func<T2, T3, T4, T5, TRet> Partial<T, T2, T3, T4, T5, TRet>(this Func<T, T2, T3, T4, T5, TRet> func, T arg)
        {
            return (x1, x2, x3, x4) => func(arg, x1, x2, x3, x4);
        }
    }
}
