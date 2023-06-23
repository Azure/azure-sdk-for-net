// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.OpenAI
{
    public struct Either<T, U>
    {
        public Either(T value)
        {
            Value = value;
        }

        public Either(U value)
        {
            Value = value;
        }

        private object _value;
        public object Value {
            get
            {
                return _value;
            }
            set
            {
                if (value is T || value is U)
                {
                    _value = value;
                }
                else
                {
                    throw new ArgumentException($"Value must be of type {nameof(T)} or {nameof(U)}");
                }
            }
        }

        public static implicit operator Either<T, U>(T value) => new Either<T, U>(value);
        public static implicit operator Either<T, U>(U value) => new Either<T, U>(value);
    }
}
