// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public partial struct JsonPatch
{
    /// <summary>
    /// A patch value that has been encoded in UTF-8 bytes along with its value kind.
    /// </summary>
    public readonly struct EncodedValue
    {
        internal static EncodedValue Empty => new(ValueKind.None, ReadOnlyMemory<byte>.Empty);

        internal EncodedValue(ValueKind kind, ReadOnlyMemory<byte> value)
        {
            Kind = kind;
            Value = value;
        }

        internal ValueKind Kind { get; }

        internal ReadOnlyMemory<byte> Value { get; }
    }
}
