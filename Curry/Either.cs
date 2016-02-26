using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public struct Either<TL,TR> 
    {
        private readonly TR right;
        private readonly TL left;
        private readonly bool isRight;

        public Maybe<TR> Right => this.isRight?new Maybe<TR>(this.right): Has.Nothing;

        public Maybe<TL> Left => !this.isRight ? new Maybe<TL>(this.left) : Has.Nothing;


        public Either(TL left)
        {
            this.left = left;
            this.right = default(TR);
            isRight = false;
        }


        public Either(TR right)
        {
            this.right = right;
            this.left = default(TL);
            isRight = true;
        }


        public T Match<T>(Func<TL, T> left, Func<TR, T> right)
        {
            return isRight ? right(this.right): left(this.left) ;
        }

        

        public override bool Equals(object obj)
        {
            if (obj is TR)
                return isRight && this.right!=null? this.right.Equals(obj):false;
            return  !isRight && this.left != null ? this.left.Equals(obj) : false;
        }


        public static bool operator ==(Either<TL, TR> either, TL value)
        {
            return !either.isRight&& either.left == (dynamic)value; //Dynamic because we don't know if TL==TL...
        }
        public static bool operator !=(Either<TL, TR> either, TL value)
        {
            return !either.isRight && either.left != (dynamic)value; //Dynamic because we don't know if TL==TL...
        }
        public static bool operator ==(Either<TL, TR> either, TR value)
        {
            return either.isRight && either.right == (dynamic)value; //Dynamic because we don't know if TL==TL...
        }
        public static bool operator !=(Either<TL, TR> either, TR value)
        {
            return either.isRight && either.right != (dynamic)value; //Dynamic because we don't know if TL==TL...
        }
        public static implicit operator Either<TL, TR>(TL left)
        {
            return new Either<TL, TR>(left);
        }
        public static implicit operator Either<TL, TR>(TR right)
        {
            return new Either<TL, TR>(right);
        }
    }
}
