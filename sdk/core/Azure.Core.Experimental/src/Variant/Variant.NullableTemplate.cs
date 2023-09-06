// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.InteropServices;

namespace Azure
{
    public readonly partial struct Variant
    {
        [StructLayout(LayoutKind.Sequential)]
        private readonly struct NullableTemplate<T> where T : unmanaged
        {
            public readonly bool _hasValue;
            public readonly T _value;

            public NullableTemplate(T value)
            {
                _value = value;
                _hasValue = true;
            }
        }
    }
}
