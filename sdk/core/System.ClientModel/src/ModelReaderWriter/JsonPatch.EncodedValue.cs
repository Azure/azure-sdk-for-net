// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public partial struct JsonPatch
{
    /// <summary>
    /// .
    /// </summary>
    public struct EncodedValue
    {
        /// <summary>
        /// .
        /// </summary>
        internal static EncodedValue Empty => new(ValueKind.None, ReadOnlyMemory<byte>.Empty);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="value"></param>
        internal EncodedValue(ValueKind kind, ReadOnlyMemory<byte> value)
        {
            Kind = kind;
            Value = value;
        }

        /// <summary>
        /// .
        /// </summary>
        internal ValueKind Kind { get; set; }

        /// <summary>
        /// .
        /// </summary>
        internal ReadOnlyMemory<byte> Value { get; }
    }
}
