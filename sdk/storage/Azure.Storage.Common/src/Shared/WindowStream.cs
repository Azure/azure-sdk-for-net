// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

#pragma warning disable SA1402  // File may only contain a single type
// branching logic on wrapping seekable vs unseekable streams has been handled via inheritance

namespace Azure.Storage.Shared
{
    /// <summary>
    /// Exposes a predetermined slice of a larger stream using the same Stream interface.
    /// There should not be access to the base stream while this facade is in use.
    /// </summary>
    internal abstract class WindowStream : SlicedStream
    {
        private Stream InnerStream { get; }

        public override long AbsolutePosition { get; }

        public override bool CanRead => true;

        public override bool CanWrite => false;

        /// <summary>
        /// Constructs a window of an underlying stream.
        /// </summary>
        /// <param name="stream">
        /// Potentialy unseekable stream to expose a window of.
        /// </param>
        /// <param name="absolutePosition">
        /// The offset of this stream from the start of the wrapped stream.
        /// </param>
        private WindowStream(Stream stream, long absolutePosition)
        {
            InnerStream = stream;
            AbsolutePosition = absolutePosition;
        }

        public static WindowStream GetWindow(Stream stream, long maxWindowLength, long absolutePosition = default)
        {
            if (stream.CanSeek)
            {
                return new SeekableWindowStream(stream, maxWindowLength);
            }
            else
            {
                return new UnseekableWindowStream(stream, maxWindowLength, absolutePosition);
            }
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException();

        public override void WriteByte(byte value) => throw new NotSupportedException();

        /// <inheritdoc/>
        /// <remarks>
        /// Implementing this method takes advantage of any optimizations in the wrapped stream's implementation.
        /// </remarks>
        public override int ReadByte()
        {
            if (AdjustCount(1) <= 0)
            {
                return -1;
            }

            int val = InnerStream.ReadByte();
            if (val != -1)
            {
                ReportInnerStreamRead(1);
            }

            return val;
        }

        public override int Read(byte[] buffer, int offset, int count)
                => ReadInternal(buffer, offset, count, async: false, cancellationToken: default).EnsureCompleted();

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
            => await ReadInternal(buffer, offset, count, async: true, cancellationToken).ConfigureAwait(false);

        private async Task<int> ReadInternal(byte[] buffer, int offset, int count, bool async, CancellationToken cancellationToken)
        {
            count = AdjustCount(count);
            if (count <= 0)
            {
                return 0;
            }

            int result = async
                ? await InnerStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(false)
                : InnerStream.Read(buffer, offset, count);

            ReportInnerStreamRead(result);
            return result;
        }

        protected abstract int AdjustCount(int count);

        protected abstract void ReportInnerStreamRead(int resultRead);

        /// <summary>
        /// Exposes a predetermined slice of a larger, unseekable stream using the same Stream
        /// interface. There should not be access to the base stream while this facade is in use.
        /// This stream wrapper is unseekable. To wrap a partition of an unseekable stream where
        /// the partition is seekable, see <see cref="PooledMemoryStream"/>.
        /// </summary>
        private class UnseekableWindowStream : WindowStream
        {
            private long _position;

            private long MaxLength { get; }

            public UnseekableWindowStream(Stream stream, long maxWindowLength, long absolutePosition) : base(stream, absolutePosition)
            {
                MaxLength = maxWindowLength;
            }

            public override bool CanSeek => false;

            public override long Length => throw new NotSupportedException();

            public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

            public override void SetLength(long value) => throw new NotSupportedException();

            protected override int AdjustCount(int count)
                => (int)Math.Min(count, MaxLength - _position);

            protected override void ReportInnerStreamRead(int resultRead)
                => _position += resultRead;
        }

        /// <summary>
        /// Exposes a predetermined slice of a larger, seekable stream using the same Stream
        /// interface. There should not be access to the base stream while this facade is in use.
        /// This stream wrapper is sseekable. To wrap a partition of an unseekable stream where
        /// the partition is seekable, see <see cref="PooledMemoryStream"/>.
        /// </summary>
        private class SeekableWindowStream : WindowStream
        {
            public SeekableWindowStream(Stream stream, long maxWindowLength) : base(stream, stream.Position)
            {
                // accessing the stream's Position in the constructor acts as our validator that we're wrapping a seekable stream
                Length = Math.Min(
                    stream.Length - stream.Position,
                    maxWindowLength);
            }

            public override bool CanSeek => true;

            public override long Length { get; }

            public override long Position
            {
                get => InnerStream.Position - AbsolutePosition;
                set => InnerStream.Position = AbsolutePosition + value;
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                switch (origin)
                {
                    case SeekOrigin.Begin:
                        InnerStream.Seek(AbsolutePosition + offset, SeekOrigin.Begin);
                        break;
                    case SeekOrigin.Current:
                        InnerStream.Seek(InnerStream.Position + offset, SeekOrigin.Current);
                        break;
                    case SeekOrigin.End:
                        InnerStream.Seek((AbsolutePosition + this.Length) - InnerStream.Length + offset, SeekOrigin.End);
                        break;
                }
                return Position;
            }

            public override void SetLength(long value) => throw new NotSupportedException();

            protected override int AdjustCount(int count)
                => (int)Math.Min(count, Length - Position);

            protected override void ReportInnerStreamRead(int resultRead)
            {
                // no-op, inner stream took care of position adjustment
            }
        }
    }

    internal static partial class StreamExtensions
    {
        /// <summary>
        /// Some streams will throw if you try to access their length so we wrap
        /// the check in a TryGet helper.
        /// </summary>
        public static long? GetPositionOrDefault(this Stream content)
        {
            if (content == null)
            {
                /* Returning 0 instead of default puts us on the quick and clean one-shot upload,
                 * which produces more consistent fail state with how a 1-1 method on the convenience
                 * layer would fail.
                 */
                return 0;
            }
            try
            {
                if (content.CanSeek)
                {
                    return content.Position;
                }
            }
            catch (NotSupportedException)
            {
            }
            return default;
        }
    }
}
