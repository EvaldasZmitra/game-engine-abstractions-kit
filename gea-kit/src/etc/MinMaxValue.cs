using System;

namespace GeaKit.Etc {
    public class MinMaxValue<T> where T : IComparable {
        public T Value {
            get {
                return _value;
            }
            set {
                var minLimit = (value.CompareTo(_min) < 0) ? _min : value;
                _value = (minLimit.CompareTo(_max) > 0) ? _max : minLimit;
            }
        }

        private T _value;
        private readonly T _min;
        private readonly T _max;

        public MinMaxValue(T value, T min, T max) {
            _max = max;
            _min = min;
            Value = value;
        }
    }
}