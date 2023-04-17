// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

public interface ISerializable
{
    bool TrySerialize(MemoryStream buffer, out int bytesWritten, SerializableOptions options = default);
    bool TryDeserialize(ReadOnlyMemory<byte> data, out int bytesConsumed, SerializableOptions options = default);
}
