namespace Functional
{
    public class Maybe<T>
    {
        private readonly Either<T,Has> value;


        public Maybe()
        {
            this.value = Has.Nothing;
        }
        public Maybe(T value)
        {
            this.value = value;
        }


        public Either<T, Has> Value
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
            return new Maybe<T>();
        }
    }
}