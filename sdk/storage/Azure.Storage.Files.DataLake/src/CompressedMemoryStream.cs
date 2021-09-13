// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.Files.DataLake
{
    internal class CompressedMemoryStream : MemoryStream
    {
        public int UncompressedLength { get; set; }

        public CompressedMemoryStream(byte[] buffer, int count, int uncompressedLength) : base(buffer, 0, count, false, true)
        {
            UncompressedLength = uncompressedLength;
        }
    }
}