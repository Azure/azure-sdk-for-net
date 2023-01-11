// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Text.Json;

namespace Azure.ResourceManager
{
    /// <summary> An interface for serializing objects into a buffer. </summary>
    public interface ISerializable<T>
    {
        /// <summary> Serialize the object into a buffer. </summary>
        void Serialize(Span<byte> buffer);
#if NET7_0_OR_GREATER
        /// <summary> Deserialize the object from a buffer. </summary>
#pragma warning disable CA1000
        static abstract T Deserialize(ReadOnlyMemory<byte> data);

        /// <summary> Deserialize the object from a buffer. </summary>
        static abstract T Deserialize(Stream data);
#pragma warning restore CA1000
#endif
    }
}
