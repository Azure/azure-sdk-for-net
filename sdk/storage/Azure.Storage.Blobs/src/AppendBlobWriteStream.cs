// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Specialized;

namespace Azure.Storage.Blobs
{
    internal class AppendBlobWriteStream : Stream
    {
        private readonly AppendBlobClient _appendBlobClient;
        private readonly byte[] _buffer;
        private int _bufferCount;

        public AppendBlobWriteStream(
            AppendBlobClient appendBlobClient,
            int bufferSize)
        {
            ValidateBufferSize(bufferSize);
            _appendBlobClient = appendBlobClient;
            _buffer = new byte[bufferSize];
            _bufferCount = 0;
        }

        public override bool CanRead => false;

        public override bool CanSeek => false;

        public override bool CanWrite => true;

        //TODO
        public override long Length => throw new NotImplementedException();

        //TODO
        public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

        //TODO
        public override void Flush()
        {
            throw new NotImplementedException();
        }


        public override int Read(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
            => WriteInternal(
                async: false,
                buffer,
                offset,
                count,
                cancellationToken: default)
            .EnsureCompleted();

        private async Task<int> WriteInternal(
            bool async,
            byte[] buffer,
            int offset,
            int count,
            CancellationToken cancellationToken)
        {

        }

        private void ValidateBufferSize(int bufferSize)
        {
            if (bufferSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must be >= 1");
            }

            if (bufferSize > 4 * Constants.MB)
            {
                throw new ArgumentOutOfRangeException(nameof(bufferSize), "Must <= 4 MB");
            }
        }
    }
}
