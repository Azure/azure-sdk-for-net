// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.Shared
{
    /// <summary>
    /// Exposes a predetermined slice of a larger stream using the same Stream interface.
    /// </summary>
    internal class WindowStream : Stream
    {
        private Stream InnerStream { get; }
        private long WindowLength { get; }

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => throw new NotSupportedException();

        private long _position = 0;
        public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

        /// <summary>
        /// Constructs a window of an underlying stream. While we can construct windows of unseekable
        /// streams (no access to Length or Position), we must know the stream length to create a valid window.
        /// </summary>
        /// <param name="stream">
        /// Potentialy unseekable stream to expose a window of.
        /// </param>
        /// <param name="windowLength">
        /// Maximum size of this window.
        /// </param>
        public WindowStream(Stream stream, long windowLength)
        {
            InnerStream = stream;
            WindowLength = windowLength;
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int ReadByte()
        {
            if (WindowLength - _position == 0)
            {
                return -1;
            }

            int val = InnerStream.ReadByte();
            if (val != -1)
            {
                _position++;
            }

            return val;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            count = (int)Math.Min(count, WindowLength - _position);
            if (count == 0)
            {
                return 0;
            }
            int result = InnerStream.Read(buffer, offset, count);
            _position += result;
            return result;
        }

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            count = (int)Math.Min(count, WindowLength - _position);
            if (count == 0)
            {
                return 0;
            }
            int result = await InnerStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false);
            _position += result;
            return result;
        }

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        public override void SetLength(long value) => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        public override void WriteByte(byte value) => throw new NotSupportedException();
    }
}
