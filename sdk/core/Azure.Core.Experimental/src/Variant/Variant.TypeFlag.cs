// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;

namespace Azure
{
    public readonly partial struct Variant
    {
        private abstract class TypeFlag
        {
            public abstract Type Type
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get;
            }

            public abstract object ToObject(in Variant value);
        }

        private abstract class TypeFlag<T> : TypeFlag
        {
            public sealed override Type Type
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get => typeof(T);
            }

            public override object ToObject(in Variant value) => To(value)!;
            public abstract T To(in Variant value);
        }
    }
}
