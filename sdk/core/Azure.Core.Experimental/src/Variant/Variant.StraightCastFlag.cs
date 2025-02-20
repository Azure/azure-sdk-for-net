// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;

namespace Azure
{
    public readonly partial struct Variant
    {
        private sealed class StraightCastFlag<T> : TypeFlag<T>
        {
            public static StraightCastFlag<T> Instance { get; } = new();

            public override T To(in Variant value)
                => Unsafe.As<Union, T>(ref Unsafe.AsRef(in value._union));
        }
    }
}
