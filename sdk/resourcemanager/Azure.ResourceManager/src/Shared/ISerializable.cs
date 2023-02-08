// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Buffers;
using System.IO;
using System.Text.Json;

namespace Azure.ResourceManager
{
    /// <summary> An interface for serializing objects into a buffer. </summary>
    public interface ISerializable<T>
    {
        /// <summary> Try to serialize the object into a buffer. </summary>
        bool TrySerialize(Span<byte> buffer, out int bytesWritten, StandardFormat format = default);

        /// <summary> Try to deserialize the object from a buffer. </summary>
        T TryDeserialize(ReadOnlySpan<byte> data, out int bytesConsumed, StandardFormat format = default);
    }
}
