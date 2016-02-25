using System;

namespace Functional
{
    public static class MaybeExtensions
    {
        public static TRet If<T, TRet>(this Maybe<T> maybe, Func<T, TRet> then, Func<TRet> elsedo)
        {
            return maybe.Value.Match(then,(x)=> elsedo());
        }
    }
}