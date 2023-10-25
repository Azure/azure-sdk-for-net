// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public readonly partial struct Variant
    {
        private sealed class PackedDateTimeOffsetFlag : TypeFlag<DateTimeOffset>
        {
            public static PackedDateTimeOffsetFlag Instance { get; } = new();

            public override DateTimeOffset To(in Variant value)
                => value._union.PackedDateTimeOffset.Extract();
        }
    }
}
