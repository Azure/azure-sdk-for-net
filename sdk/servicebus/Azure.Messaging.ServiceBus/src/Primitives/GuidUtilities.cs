// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Azure.Messaging.ServiceBus.Primitives;

internal static class GuidUtilities
{
    /// <summary>
    /// The size, in bytes, to use for extracting the delivery tag bytes into <see cref="Guid"/>.
    /// </summary>
    private const int GuidSizeInBytes = 16;

    public static Guid ParseGuidBytes(ReadOnlyMemory<byte> bytes)
    {
        if (bytes.Length == GuidSizeInBytes)
        {
            // Use TryRead to avoid allocating an array if we are on a little endian machine.
            if (!BitConverter.IsLittleEndian || !MemoryMarshal.TryRead<Guid>(bytes.Span, out var lockTokenGuid))
            {
                // Either we are on a big endian machine or the bytes were not a valid GUID.
                // Even if the bytes were not valid, use the Guid constructor to leverage the Guid validation rather than throwing ourselves.
                lockTokenGuid = new Guid(bytes.ToArray());
            }
            return lockTokenGuid;
        }

        return default;
    }

    public static void WriteGuidBytes(Guid guid, byte[] buffer)
    {
        Debug.Assert(buffer is { Length: 16 });
        if (!BitConverter.IsLittleEndian || !MemoryMarshal.TryWrite(buffer, ref guid))
        {
            guid.ToByteArray().AsSpan().CopyTo(buffer);
        }
    }
}