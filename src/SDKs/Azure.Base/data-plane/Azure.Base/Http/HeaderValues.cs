// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;

namespace Azure.Base.Http
{
    public readonly struct HeaderValues : IList<string>, IReadOnlyList<string>, IEquatable<HeaderValues>, IEquatable<string>, IEquatable<string[]>
    {
        private static readonly string[] EmptyArray = new string[0];
        public static readonly HeaderValues Empty = new HeaderValues(EmptyArray);

        private readonly string _value;
        private readonly string[] _values;

        public HeaderValues(string value)
        {
            _value = value;
            _values = null;
        }

        public HeaderValues(string[] values)
        {
            _value = null;
            _values = values;
        }

        public static implicit operator HeaderValues(string value)
        {
            return new HeaderValues(value);
        }

        public static implicit operator HeaderValues(string[] values)
        {
            return new HeaderValues(values);
        }

        public static implicit operator string (HeaderValues values)
        {
            return values.GetStringValue();
        }

        public static implicit operator string[] (HeaderValues value)
        {
            return value.GetArrayValue();
        }

        public int Count => _value != null ? 1 : (_values?.Length ?? 0);

        bool ICollection<string>.IsReadOnly => true;

        string IList<string>.this[int index]
        {
            get => this[index];
            set => throw new NotSupportedException();
        }

        public string this[int index]
        {
            get
            {
                if (_values != null)
                {
                    return _values[index]; // may throw
                }
                if (index == 0 && _value != null)
                {
                    return _value;
                }
                return EmptyArray[0]; // throws
            }
        }

        public override string ToString()
        {
            return GetStringValue() ?? string.Empty;
        }

        private string GetStringValue()
        {
            if (_values == null)
            {
                return _value;
            }
            switch (_values.Length)
            {
                case 0: return null;
                case 1: return _values[0];
                default: return string.Join(",", _values);
            }
        }

        public string[] ToArray()
        {
            return GetArrayValue() ?? EmptyArray;
        }

        private string[] GetArrayValue()
        {
            if (_value != null)
            {
                return new[] { _value };
            }
            return _values;
        }

        int IList<string>.IndexOf(string item)
        {
            return IndexOf(item);
        }

        private int IndexOf(string item)
        {
            if (_values != null)
            {
                var values = _values;
                for (int i = 0; i < values.Length; i++)
                {
                    if (string.Equals(values[i], item, StringComparison.Ordinal))
                    {
                        return i;
                    }
                }
                return -1;
            }

            if (_value != null)
            {
                return string.Equals(_value, item, StringComparison.Ordinal) ? 0 : -1;
            }

            return -1;
        }

        bool ICollection<string>.Contains(string item)
        {
            return IndexOf(item) >= 0;
        }

        void ICollection<string>.CopyTo(string[] array, int arrayIndex)
        {
            CopyTo(array, arrayIndex);
        }

        private void CopyTo(string[] array, int arrayIndex)
        {
            if (_values != null)
            {
                Array.Copy(_values, 0, array, arrayIndex, _values.Length);
                return;
            }

            if (_value != null)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array));
                }
                if (arrayIndex < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(arrayIndex));
                }
                if (array.Length - arrayIndex < 1)
                {
                    throw new ArgumentException(
                        $"'{nameof(array)}' is not long enough to copy all the items in the collection. Check '{nameof(arrayIndex)}' and '{nameof(array)}' length.");
                }

                array[arrayIndex] = _value;
            }
        }

        void ICollection<string>.Add(string item)
        {
            throw new NotSupportedException();
        }

        void IList<string>.Insert(int index, string item)
        {
            throw new NotSupportedException();
        }

        bool ICollection<string>.Remove(string item)
        {
            throw new NotSupportedException();
        }

        void IList<string>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        void ICollection<string>.Clear()
        {
            throw new NotSupportedException();
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(_values, _value);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static bool IsNullOrEmpty(HeaderValues value)
        {
            if (value._values == null)
            {
                return string.IsNullOrEmpty(value._value);
            }
            switch (value._values.Length)
            {
                case 0: return true;
                case 1: return string.IsNullOrEmpty(value._values[0]);
                default: return false;
            }
        }

        public static HeaderValues Concat(HeaderValues values1, HeaderValues values2)
        {
            var count1 = values1.Count;
            var count2 = values2.Count;

            if (count1 == 0)
            {
                return values2;
            }

            if (count2 == 0)
            {
                return values1;
            }

            var combined = new string[count1 + count2];
            values1.CopyTo(combined, 0);
            values2.CopyTo(combined, count1);
            return new HeaderValues(combined);
        }

        public static HeaderValues Concat(in HeaderValues values, string value)
        {
            if (value == null)
            {
                return values;
            }

            var count = values.Count;
            if (count == 0)
            {
                return new HeaderValues(value);
            }

            var combined = new string[count + 1];
            values.CopyTo(combined, 0);
            combined[count] = value;
            return new HeaderValues(combined);
        }

        public static HeaderValues Concat(string value, in HeaderValues values)
        {
            if (value == null)
            {
                return values;
            }

            var count = values.Count;
            if (count == 0)
            {
                return new HeaderValues(value);
            }

            var combined = new string[count + 1];
            combined[0] = value;
            values.CopyTo(combined, 1);
            return new HeaderValues(combined);
        }

        public static bool Equals(HeaderValues left, HeaderValues right)
        {
            var count = left.Count;

            if (count != right.Count)
            {
                return false;
            }

            for (var i = 0; i < count; i++)
            {
                if (left[i] != right[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator ==(HeaderValues left, HeaderValues right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HeaderValues left, HeaderValues right)
        {
            return !Equals(left, right);
        }

        public bool Equals(HeaderValues other)
        {
            return Equals(this, other);
        }

        public static bool Equals(string left, HeaderValues right)
        {
            return Equals(new HeaderValues(left), right);
        }

        public static bool Equals(HeaderValues left, string right)
        {
            return Equals(left, new HeaderValues(right));
        }

        public bool Equals(string other)
        {
            return Equals(this, new HeaderValues(other));
        }

        public static bool Equals(string[] left, HeaderValues right)
        {
            return Equals(new HeaderValues(left), right);
        }

        public static bool Equals(HeaderValues left, string[] right)
        {
            return Equals(left, new HeaderValues(right));
        }

        public bool Equals(string[] other)
        {
            return Equals(this, new HeaderValues(other));
        }

        public static bool operator ==(HeaderValues left, string right)
        {
            return Equals(left, new HeaderValues(right));
        }

        public static bool operator !=(HeaderValues left, string right)
        {
            return !Equals(left, new HeaderValues(right));
        }

        public static bool operator ==(string left, HeaderValues right)
        {
            return Equals(new HeaderValues(left), right);
        }

        public static bool operator !=(string left, HeaderValues right)
        {
            return !Equals(new HeaderValues(left), right);
        }

        public static bool operator ==(HeaderValues left, string[] right)
        {
            return Equals(left, new HeaderValues(right));
        }

        public static bool operator !=(HeaderValues left, string[] right)
        {
            return !Equals(left, new HeaderValues(right));
        }

        public static bool operator ==(string[] left, HeaderValues right)
        {
            return Equals(new HeaderValues(left), right);
        }

        public static bool operator !=(string[] left, HeaderValues right)
        {
            return !Equals(new HeaderValues(left), right);
        }

        public static bool operator ==(HeaderValues left, object right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(HeaderValues left, object right)
        {
            return !left.Equals(right);
        }
        public static bool operator ==(object left, HeaderValues right)
        {
            return right.Equals(left);
        }

        public static bool operator !=(object left, HeaderValues right)
        {
            return !right.Equals(left);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return Equals(this, HeaderValues.Empty);
            }

            if (obj is string)
            {
                return Equals(this, (string)obj);
            }

            if (obj is string[])
            {
                return Equals(this, (string[])obj);
            }

            if (obj is HeaderValues)
            {
                return Equals(this, (HeaderValues)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (_value != null)
            {
                return _value.GetHashCode();
            }

            if (_values == null)
            {
                return 0;
            }

            var hashcode = new HashCode();

            foreach (var value in _values)
            {
                hashcode.Add(value);
            }

            return hashcode.ToHashCode();
        }

        public struct Enumerator : IEnumerator<string>
        {
            private readonly string[] _values;
            private string _current;
            private int _index;

            internal Enumerator(string[] values, string value)
            {
                _values = values;
                _current = value;
                _index = 0;
            }

            public Enumerator(ref HeaderValues values)
            {
                _values = values._values;
                _current = values._value;
                _index = 0;
            }

            public bool MoveNext()
            {
                if (_index < 0)
                {
                    return false;
                }

                if (_values != null)
                {
                    if (_index < _values.Length)
                    {
                        _current = _values[_index];
                        _index++;
                        return true;
                    }

                    _index = -1;
                    return false;
                }

                _index = -1; // sentinel value
                return _current != null;
            }

            public string Current => _current;

            object IEnumerator.Current => _current;

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            public void Dispose()
            {
            }
        }
    }
}