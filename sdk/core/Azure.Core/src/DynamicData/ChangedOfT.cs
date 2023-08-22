// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Serialization
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable AZC0012 // Avoid single word type names
#pragma warning disable SA1649 // File name should match first type name
    public struct Changed<T>
    {
        private bool _changed;
        private T _value;

        public Changed(T value)
        {
            _value = value;
        }

        //public static implicit operator Changed<T>(T value)
        //{
        //    return new(value);
        //}

        public static implicit operator T(Changed<T> value)
        {
            return value.Value;
        }

        public T Value
        {
            get => _value;
            set
            {
                _changed = true;
                _value = value;
            }
        }

        public bool HasChanged => _changed;
    }
#pragma warning restore SA1649 // File name should match first type name
#pragma warning restore AZC0012 // Avoid single word type names
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
