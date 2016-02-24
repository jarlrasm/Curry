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
        public static Func<T,Func<T2,TRet>> Curry<T, T2,TRet>(this Func<T, T2,TRet> func)
        {
            return x => y=> func(x, y);
        }
        public static Func<T, Func<T2, Func<T3, TRet>>> Curry<T, T2,T3, TRet>(this Func<T, T2,T3, TRet> func)
        {
            return x => y => z=>func(x, y,z );
        }
        public static Func<T2, TRet> Partial<T, T2, TRet>(this Func<T, T2, TRet> func,T arg)
        {
            return x => func(arg, x);
        }
    }
}
