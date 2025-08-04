// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public partial struct AdditionalProperties
{
    private struct EncodedValue
    {
        public static EncodedValue Empty => new(ValueKind.None, ReadOnlyMemory<byte>.Empty);

        public EncodedValue(ValueKind kind, ReadOnlyMemory<byte> value)
        {
            Kind = kind;
            Value = value;
        }

        public ValueKind Kind { get; set; }
        public ReadOnlyMemory<byte> Value { get; }
    }
}
