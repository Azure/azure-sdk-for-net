// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;

namespace Azure.Core.Pipeline
{
    public partial class HttpClientTransport
    {
        private sealed partial class PipelineRequest : Request
        {
            private readonly struct IgnoreCaseString : IEquatable<IgnoreCaseString>
            {
                private readonly string _value;

                public IgnoreCaseString(string value)
                {
                    _value = value;
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public bool Equals(IgnoreCaseString other) => string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase);
                public override bool Equals(object? obj) => obj is IgnoreCaseString other && Equals(other);
                public override int GetHashCode() => _value.GetHashCode();

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static bool operator ==(IgnoreCaseString left, IgnoreCaseString right) => left.Equals(right);
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static bool operator !=(IgnoreCaseString left, IgnoreCaseString right) => !left.Equals(right);
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public static implicit operator string(IgnoreCaseString ics) => ics._value;
            }
        }
    }
}
