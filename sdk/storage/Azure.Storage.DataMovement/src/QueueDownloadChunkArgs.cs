// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.DataMovement
{
    internal class QueueDownloadChunkArgs
    {
        public long Offset { get; }
        public long Length { get; }
        public Stream Content { get; }

        public QueueDownloadChunkArgs(
            long offset,
            long length,
            Stream content)
        {
            Offset = offset;
            Length = length;
            Content = content;
        }
    }
}
