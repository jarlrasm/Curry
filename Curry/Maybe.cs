namespace Functional
{
    public struct Maybe<T>
    {
        private readonly Either<Has, T> value;


        public Maybe(Has nothing)
        {
            this.value = nothing;
        }
        public Maybe(T value)
        {
            if (value == null)
                this.value = Has.Nothing;
            else
                this.value = value;
        }


        public Either<Has, T> Value
        {
            get { return this.value; }
        }

        public override bool Equals(object obj)
        {
            return Value.Equals(obj);
        }
        public static bool operator ==(Maybe<T> maybe, T value)
        {
            return maybe.Value == value;
        }
        public static bool operator !=(Maybe<T> maybe, T value)
        {
            return maybe.Value != value;
        }

        public static bool operator ==(Maybe<T> maybe, Has value)
        {
            return maybe.Value == value;
        }
        public static bool operator !=(Maybe<T> maybe, Has value)
        {
            return maybe.Value != value;
        }

        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }
        public static implicit operator Maybe<T>(Has nothing)
        {
            return new Maybe<T>(nothing);
        }
    }
}