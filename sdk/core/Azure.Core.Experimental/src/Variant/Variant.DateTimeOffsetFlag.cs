// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure
{
    public readonly partial struct Variant
    {
        private sealed class DateTimeOffsetFlag : TypeFlag<DateTimeOffset>
        {
            public static DateTimeOffsetFlag Instance { get; } = new();

            public override DateTimeOffset To(in Variant value)
                => new(new DateTime(value._union.Ticks, DateTimeKind.Utc));
        }
    }
}
