// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace Microsoft.HDInsight.Net.Http.Formatting.Internal
{
    using System;
    using System.Diagnostics.Contracts;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This implements a read-only, forward-only stream around another readable stream, to ensure
    /// that there is an appropriate encoding preamble in the stream.
    /// </summary>
    internal class ReadOnlyStreamWithEncodingPreamble : Stream
    {
        private static Task<int> _cancelledTask = GetCancelledTask();
        private Stream _innerStream;
        private ArraySegment<byte> _remainingBytes;

        public ReadOnlyStreamWithEncodingPreamble(Stream innerStream, Encoding encoding)
        {
            Contract.Assert(innerStream != null);
            Contract.Assert(innerStream.CanRead);
            Contract.Assert(encoding != null);

            this._innerStream = innerStream;

            // Determine whether we even have a preamble to be concerned about
            byte[] preamble = encoding.GetPreamble();
            int preambleLength = preamble.Length;
            if (preambleLength <= 0)
            {
                return;
            }

            // Create a double sized buffer, and read enough bytes from the stream to know
            // whether we have a preamble present already or not.
            int finalBufferLength = preambleLength * 2;
            byte[] finalBuffer = new byte[finalBufferLength];
            int finalCount = preambleLength;
            preamble.CopyTo(finalBuffer, 0);

            // Read the first bytes of the stream and see if they already contain a preamble
            for (; finalCount < finalBufferLength; finalCount++)
            {
                int b = innerStream.ReadByte();
                if (b == -1)
                {
                    break;
                }
                finalBuffer[finalCount] = (byte)b;
            }

            // Did we read enough bytes to do the comparison?
            if (finalCount == finalBufferLength)
            {
                bool foundPreamble = true;
                for (int idx = 0; idx < preambleLength; idx++)
                {
                    if (finalBuffer[idx] != finalBuffer[idx + preambleLength])
                    {
                        foundPreamble = false;
                        break;
                    }
                }

                // If we found the preamble, then just exclude it from the data that we return
                if (foundPreamble)
                {
                    finalCount = preambleLength;
                }
            }

            this._remainingBytes = new ArraySegment<byte>(finalBuffer, 0, finalCount);
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override long Length
        {
            get { throw new NotImplementedException(); }
        }

        public override long Position
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        private static Task<int> GetCancelledTask()
        {
            var tcs = new TaskCompletionSource<int>();
            tcs.SetCanceled();
            return tcs.Task;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            byte[] remainingArray = this._remainingBytes.Array;
            if (remainingArray == null)
            {
                return this._innerStream.Read(buffer, offset, count);
            }

            int remainingCount = this._remainingBytes.Count;
            int remainingOffset = this._remainingBytes.Offset;
            int result = Math.Min(count, remainingCount);

            for (int idx = 0; idx < result; ++idx)
            {
                buffer[offset + idx] = remainingArray[remainingOffset + idx];
            }

            if (result == remainingCount)
            {
                this._remainingBytes = default(ArraySegment<byte>);
            }
            else
            {
                this._remainingBytes = new ArraySegment<byte>(remainingArray, remainingOffset + result, remainingCount - result);
            }

            return result;
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            if (this._remainingBytes.Array == null)
            {
                return this._innerStream.ReadAsync(buffer, offset, count, cancellationToken);
            }
            if (cancellationToken.IsCancellationRequested)
            {
                return _cancelledTask;
            }

            return Task.FromResult(this.Read(buffer, offset, count));
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
