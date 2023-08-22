// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Serialization
{
    internal struct MergePatchValue<T>
    {
        private bool _changed;
        private T _value;

        public MergePatchValue(T value)
        {
            _value = value;
        }

        public static implicit operator T(MergePatchValue<T> value)
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
}
