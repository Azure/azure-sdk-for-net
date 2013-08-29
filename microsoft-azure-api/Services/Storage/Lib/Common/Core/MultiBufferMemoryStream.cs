// -----------------------------------------------------------------------------------------
// <copyright file="MultiBufferMemoryStream.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core
{
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;

#if WINDOWS_RT
    using System.Threading;
    using System.Threading.Tasks;
#endif

    /// <summary>
    /// This class provides MemoryStream-like behavior but uses a list of buffers rather than a single buffer.
    /// </summary>
    internal class MultiBufferMemoryStream : Stream
    {
        private class CopyState
        {
            public Stream Destination { get; set; }

            public DateTime? ExpiryTime { get; set; }
        }

        /// <summary>
        /// The default small buffer size.
        /// </summary>
        private const int DefaultSmallBufferSize = (int)(64 * Constants.KB);

        /// <summary>
        /// The size of each buffer.
        /// </summary>
        private readonly int bufferSize;

        /// <summary>
        /// The underlying buffer blocks for the stream.
        /// </summary>
        private List<byte[]> bufferBlocks = new List<byte[]>();

        /// <summary>
        /// The currently used length.
        /// </summary>
        private long length;

        /// <summary>
        /// The total capacity of the stream.
        /// </summary>
        private long capacity;

        /// <summary>
        /// The current position.
        /// </summary>
        private long position;

        /// <summary>
        /// A reference to the IBufferManager for the stream to use to acquire and return buffers.
        /// </summary>
        private IBufferManager bufferManager;

        /// <summary>
        ///  Initializes a new instance of the MultiBufferMemoryStream class with provided IBufferManager.
        /// </summary>
        /// <param name="bufferManager">A reference to the IBufferManager for the stream to use to acquire and return buffers. May be null.</param>
        /// <param name="bufferSize">The Buffer size to use for each block, default is 64 KB. Note this parameter is disregarded when a IBufferManager is specified.</param>
        public MultiBufferMemoryStream(IBufferManager bufferManager, int bufferSize = MultiBufferMemoryStream.DefaultSmallBufferSize)
        {
            this.bufferManager = bufferManager;

            this.bufferSize = this.bufferManager == null ? bufferSize : this.bufferManager.GetDefaultBufferSize();

            if (bufferSize <= 0)
            {
                throw new ArgumentOutOfRangeException("bufferSize", "Buffer size must be a positive, non-zero value");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        /// <value>Is <c>true</c> if the stream supports reading; otherwise, <c>false</c>.</value>
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        /// <value>Is true if the stream supports seeking; otherwise, false.</value>
        public override bool CanSeek
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// </summary>
        /// <value>Is true if the stream supports writing; otherwise, false.</value>
        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the currently written length.
        /// </summary>
        public override long Length
        {
            get
            {
                return this.length;
            }
        }

        /// <summary>
        /// Represents the current position in the stream.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if position is outside the stream size</exception>
        public override long Position
        {
            get
            {
                return this.position;
            }

            set
            {
                this.Seek(value, SeekOrigin.Begin);
            }
        }

        /// <summary>
        /// Reads a block of bytes from the current stream and writes the data to a buffer.
        /// </summary>
        /// <param name="buffer">When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero if the end of the stream has been reached.</returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            CommonUtility.AssertNotNull("buffer", buffer);
            CommonUtility.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtility.AssertInBounds("count", count, 0, buffer.Length - offset);

            return this.ReadInternal(buffer, offset, count);
        }

#if WINDOWS_DESKTOP
        /// <summary>
        /// Begins an asynchronous read operation.
        /// </summary>
        /// <param name="buffer">When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the read is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous read request from other requests.</param>
        /// <returns>An IAsyncResult that represents the asynchronous read, which could still be pending.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("buffer", buffer);
            CommonUtility.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtility.AssertInBounds("count", count, 0, buffer.Length - offset);

            StorageAsyncResult<int> result = new StorageAsyncResult<int>(callback, state);

            try
            {
                result.Result = this.Read(buffer, offset, count);
                result.OnComplete();
            }
            catch (Exception e)
            {
                result.OnComplete(e);
            }

            return result;
        }

        /// <summary>
        /// Waits for the pending asynchronous read to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        /// <returns>The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero if the end of the stream has been reached.</returns>
        public override int EndRead(IAsyncResult asyncResult)
        {
            StorageAsyncResult<int> result = (StorageAsyncResult<int>)asyncResult;
            result.End();
            return result.Result;
        }
#endif

#if WINDOWS_RT
        /// <summary>
        /// Asynchronously reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">The buffer to write the data into.</param>
        /// <param name="offset">The byte offset in buffer at which to begin writing data from the stream.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous read operation.</returns>
        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return Task.FromResult(this.Read(buffer, offset, count));
        }
#endif

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A value of type System.IO.SeekOrigin indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="offset"/> is invalid for SeekOrigin.</exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            long newPosition;
            switch (origin)
            {
                case SeekOrigin.Begin:
                    newPosition = offset;
                    break;

                case SeekOrigin.Current:
                    newPosition = this.position + offset;
                    break;

                case SeekOrigin.End:
                    newPosition = this.Length + offset;
                    break;

                default:
                    CommonUtility.ArgumentOutOfRange("origin", origin);
                    throw new ArgumentOutOfRangeException("origin");
            }

            CommonUtility.AssertInBounds("offset", newPosition, 0, this.Length);

            this.position = newPosition;
            return this.position;
        }

        /// <summary>
        /// Sets the length of the current stream to the specified value. (pre-allocating the bufferBlocks).
        /// </summary>
        /// <param name="value">The desired length of the current stream in bytes.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the <paramref name="value"/> is negative.</exception>
        public override void SetLength(long value)
        {
            this.Reserve(value);
            this.length = value;
        }

        /// <summary>
        /// Writes a block of bytes to the current stream using data read from a buffer.
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to write. </param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            CommonUtility.AssertNotNull("buffer", buffer);
            CommonUtility.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtility.AssertInBounds("count", count, 0, buffer.Length - offset);

            // Grow the buffer if more space is needed
            if (this.position + count > this.capacity)
            {
                this.Reserve(this.position + count);
            }

            this.WriteInternal(buffer, offset, count);

            // Adjust the length to be the max of currently written data.
            this.length = Math.Max(this.length, this.position);
        }

#if WINDOWS_DESKTOP
        /// <summary>
        /// Begins an asynchronous write operation.
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to write.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the write is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous write request from other requests.</param>
        /// <returns>An IAsyncResult that represents the asynchronous write, which could still be pending.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads")]
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("buffer", buffer);
            CommonUtility.AssertInBounds("offset", offset, 0, buffer.Length);
            CommonUtility.AssertInBounds("count", count, 0, buffer.Length - offset);

            StorageAsyncResult<NullType> result = new StorageAsyncResult<NullType>(callback, state);

            try
            {
                this.Write(buffer, offset, count);
                result.OnComplete();
            }
            catch (Exception e)
            {
                result.OnComplete(e);
            }

            return result;
        }

        /// <summary>
        /// Ends an asynchronous write operation.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        public override void EndWrite(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> result = (StorageAsyncResult<NullType>)asyncResult;
            result.End();
        }
#endif

#if WINDOWS_RT
        /// <summary>
        /// Asynchronously writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">The buffer to write data from.</param>
        /// <param name="offset">The zero-based byte offset in buffer from which to begin copying bytes to the stream.</param>
        /// <param name="count">The maximum number of bytes to write.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            this.Write(buffer, offset, count);
            return Task.FromResult(true);
        }
#endif
        /// <summary>
        /// Does not perform any operation as it's an in-memory stream.
        /// </summary>
        public override void Flush()
        {
        }

#if WINDOWS_RT
        /// <summary>
        /// Does not perform any operation as it's an in-memory stream.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous flush operation.</returns>
        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
#endif

#if WINDOWS_DESKTOP
        /// <summary>
        /// Reads the bytes from the current stream and writes them to another stream. However, this method eliminates copying the data into a temporary buffer by directly writing to the destination stream.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="expiryTime">DateTime indicating the expiry time.</param>
        public void FastCopyTo(Stream destination, DateTime? expiryTime)
        {
            CommonUtility.AssertNotNull("destination", destination);

            // Maximum amount you can read is from current spot to the end.
            long leftToRead = this.Length - this.Position;

            try
            {
                while (leftToRead != 0)
                {
                    if (expiryTime.HasValue && DateTime.Now.CompareTo(expiryTime.Value) > 0)
                    {
                        throw new TimeoutException();
                    }

                    ArraySegment<byte> currentBlock = this.GetCurrentBlock();

                    // Copy the block
                    int blockReadLength = (int)Math.Min(leftToRead, currentBlock.Count);
                    destination.Write(currentBlock.Array, currentBlock.Offset, blockReadLength);

                    this.AdvancePosition(ref leftToRead, blockReadLength);
                }
            }
            catch (Exception)
            {
                if (expiryTime.HasValue && DateTime.Now.CompareTo(expiryTime.Value) > 0)
                {
                    throw new TimeoutException();
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Begins an asynchronous fast-copy operation.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="expiryTime">DateTime indicating the expiry time.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the copy is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous copy request from other requests.</param>
        /// <returns>An IAsyncResult that represents the asynchronous copy, which could still be pending.</returns>
        public IAsyncResult BeginFastCopyTo(Stream destination, DateTime? expiryTime, AsyncCallback callback, object state)
        {
            CommonUtility.AssertNotNull("destination", destination);

            StorageAsyncResult<NullType> result = new StorageAsyncResult<NullType>(callback, state);
            result.OperationState = new CopyState()
            {
                Destination = destination,
                ExpiryTime = expiryTime,
            };

            this.FastCopyToInternal(result);
            return result;
        }

        /// <summary>
        /// Initiates a write operation for the next buffer in line.
        /// </summary>
        /// <param name="result">Internal StorageAsyncResult that represents the asynchronous copy.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void FastCopyToInternal(StorageAsyncResult<NullType> result)
        {
            CopyState copyState = (CopyState)result.OperationState;

            // Maximum amount you can read is from current spot to the end.
            long leftToRead = this.Length - this.Position;

            try
            {
                while (leftToRead != 0)
                {
                    if (copyState.ExpiryTime.HasValue && DateTime.Now.CompareTo(copyState.ExpiryTime.Value) > 0)
                    {
                        throw new TimeoutException();
                    }

                    ArraySegment<byte> currentBlock = this.GetCurrentBlock();

                    int blockReadLength = (int)Math.Min(leftToRead, currentBlock.Count);
                    this.AdvancePosition(ref leftToRead, blockReadLength);

                    IAsyncResult asyncResult = copyState.Destination.BeginWrite(currentBlock.Array, currentBlock.Offset, blockReadLength, this.FastCopyToCallback, result);

                    if (!asyncResult.CompletedSynchronously)
                    {
                        return;
                    }

                    copyState.Destination.EndWrite(asyncResult);
                }

                result.OnComplete();
            }
            catch (Exception e)
            {
                if (copyState.ExpiryTime.HasValue && DateTime.Now.CompareTo(copyState.ExpiryTime.Value) > 0)
                {
                    result.OnComplete(new TimeoutException());
                }
                else
                {
                    result.OnComplete(e);
                }
            }
        }

        /// <summary>
        /// Callback method to be called when the corresponding write operation completes.
        /// </summary>
        /// <param name="asyncResult">The result of the asynchronous operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Needed to ensure exceptions are not thrown on threadpool threads.")]
        private void FastCopyToCallback(IAsyncResult asyncResult)
        {
            if (asyncResult.CompletedSynchronously)
            {
                return;
            }

            StorageAsyncResult<NullType> result = (StorageAsyncResult<NullType>)asyncResult.AsyncState;
            result.UpdateCompletedSynchronously(asyncResult.CompletedSynchronously);

            CopyState copyState = (CopyState)result.OperationState;

            try
            {
                copyState.Destination.EndWrite(asyncResult);
                this.FastCopyToInternal(result);
            }
            catch (Exception e)
            {
                if (copyState.ExpiryTime.HasValue && DateTime.Now.CompareTo(copyState.ExpiryTime.Value) > 0)
                {
                    result.OnComplete(new TimeoutException());
                }
                else
                {
                    result.OnComplete(e);
                }
            }
        }

        /// <summary>
        /// Ends an asynchronous copy operation.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        public void EndFastCopyTo(IAsyncResult asyncResult)
        {
            StorageAsyncResult<NullType> result = (StorageAsyncResult<NullType>)asyncResult;
            result.End();
        }
#endif

#if WINDOWS_RT
        /// <summary>
        /// Asynchronously reads the bytes from the current stream and writes them to another stream. However, this method eliminates copying the data into a temporary buffer by directly writing to the destination stream.
        /// </summary>
        /// <param name="destination">The stream to which the contents of the current stream will be copied.</param>
        /// <param name="expiryTime">DateTime indicating the expiry time.</param>
        /// <returns>A task that represents the asynchronous copy operation.</returns>
        public async Task FastCopyToAsync(Stream destination, DateTime? expiryTime)
        {
            CommonUtility.AssertNotNull("destination", destination);

            // Maximum amount you can read is from current spot to the end.
            long leftToRead = this.Length - this.Position;

            try
            {
                while (leftToRead != 0)
                {
                    if (expiryTime.HasValue && DateTime.Now.CompareTo(expiryTime.Value) > 0)
                    {
                        throw new TimeoutException();
                    }

                    ArraySegment<byte> currentBlock = this.GetCurrentBlock();

                    // Copy the block
                    int blockReadLength = (int)Math.Min(leftToRead, currentBlock.Count);
                    await destination.WriteAsync(currentBlock.Array, currentBlock.Offset, blockReadLength);

                    this.AdvancePosition(ref leftToRead, blockReadLength);
                }
            }
            catch (Exception)
            {
                if (expiryTime.HasValue && DateTime.Now.CompareTo(expiryTime.Value) > 0)
                {
                    throw new TimeoutException();
                }
                else
                {
                    throw;
                }
            }
        }
#endif

#if !WINDOWS_PHONE
        /// <summary>
        /// Computes the hash value for this stream.
        /// </summary>
        /// <returns>String representation of the computed hash value.</returns>
        public string ComputeMD5Hash()
        {
            using (MD5Wrapper md5 = new MD5Wrapper())
            {
                // Maximum amount you can read is from current spot to the end.
                long leftToRead = this.Length - this.Position;

                while (leftToRead != 0)
                {
                    ArraySegment<byte> currentBlock = this.GetCurrentBlock();

                    // Update hash with the block
                    int blockReadLength = (int)Math.Min(leftToRead, currentBlock.Count);
                    md5.UpdateHash(currentBlock.Array, currentBlock.Offset, blockReadLength);

                    this.AdvancePosition(ref leftToRead, blockReadLength);
                }

                return md5.ComputeHash();
            }
        }
#endif

        /// <summary>
        /// Ensures that the amount of bufferBlocks is greater than or equal to the required size. 
        /// Does not trim the size.
        /// </summary>
        /// <param name="requiredSize">The required size.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the <paramref name="requiredSize"/> is negative.</exception>
        private void Reserve(long requiredSize)
        {
            if (requiredSize < 0)
            {
                throw new ArgumentOutOfRangeException("requiredSize", "The size must be positive");
            }

            while (requiredSize > this.capacity)
            {
                this.AddBlock();
            }
        }

        /// <summary>
        /// Adds another block to the underlying bufferBlocks.
        /// </summary>
        private void AddBlock()
        {
            byte[] newBuff = this.bufferManager == null ? new byte[this.bufferSize] : this.bufferManager.TakeBuffer(this.bufferSize);
            if (newBuff.Length != this.bufferSize)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, SR.BufferManagerProvidedIncorrectLengthBuffer, this.bufferSize, newBuff.Length));
            }

            this.bufferBlocks.Add(newBuff);
            this.capacity += this.bufferSize;
        }

        /// <summary>
        /// Copies the specified amount of data from internal buffers to the buffer and advances the position.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values 
        ///                     between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns> The total number of bytes read into the buffer. This can be less than the number of bytes requested 
        /// if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
        /// </returns>
        private int ReadInternal(byte[] buffer, int offset, int count)
        {
            // Maximum amount you can read is from current spot to the end.
            int readLength = (int)Math.Min(this.Length - this.Position, count);
            int leftToRead = readLength;

            while (leftToRead != 0)
            {
                ArraySegment<byte> currentBlock = this.GetCurrentBlock();

                // Copy the block
                int blockReadLength = (int)Math.Min(leftToRead, currentBlock.Count);
                Buffer.BlockCopy(currentBlock.Array, currentBlock.Offset, buffer, offset, blockReadLength);

                this.AdvancePosition(ref offset, ref leftToRead, blockReadLength);
            }

            return readLength;
        }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// (Requires the stream to be of sufficient size for writing).
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        private void WriteInternal(byte[] buffer, int offset, int count)
        {
            while (count != 0)
            {
                ArraySegment<byte> currentBlock = this.GetCurrentBlock();

                // Copy the block
                int blockWriteLength = (int)Math.Min(count, currentBlock.Count);
                Buffer.BlockCopy(buffer, offset, currentBlock.Array, currentBlock.Offset, blockWriteLength);

                this.AdvancePosition(ref offset, ref count, blockWriteLength);
            }
        }

        /// <summary>
        /// Advances the current position of the stream and adjust the offset and remainder based on the amount completed.
        /// </summary>
        /// <param name="offset">The current offset in the external buffer.</param>
        /// <param name="leftToProcess">The amount of data left to process.</param>
        /// <param name="amountProcessed">The amount of data processed.</param>
        private void AdvancePosition(ref int offset, ref int leftToProcess, int amountProcessed)
        {
            // Advance the position in the stream and in the destination buffer
            this.position += amountProcessed;
            offset += amountProcessed;
            leftToProcess -= amountProcessed;
        }

        /// <summary>
        /// Advances the current position of the stream and adjust the remainder based on the amount completed.
        /// </summary>
        /// <param name="leftToProcess">The amount of data left to process.</param>
        /// <param name="amountProcessed">The amount of data processed.</param>
        private void AdvancePosition(ref long leftToProcess, int amountProcessed)
        {
            // Advance the position in the stream and in the destination buffer
            this.position += amountProcessed;
            leftToProcess -= amountProcessed;
        }

        /// <summary>
        /// Calculate the block for the current position.
        /// </summary>
        private ArraySegment<byte> GetCurrentBlock()
        {
            // Calculate the block and position in a block
            int blockID = (int)(this.position / this.bufferSize);
            int blockPosition = (int)(this.position % this.bufferSize);
            byte[] currentBlock = this.bufferBlocks[blockID];

            return new ArraySegment<byte>(currentBlock, blockPosition, currentBlock.Length - blockPosition);
        }

        private volatile bool disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                this.disposed = true;
                if (disposing)
                {
                    if (this.bufferManager != null)
                    {
                        foreach (byte[] buff in this.bufferBlocks)
                        {
                            this.bufferManager.ReturnBuffer(buff);
                        }
                    }

                    this.bufferBlocks.Clear();
                }
            }

            base.Dispose(disposing);
        }
    }
}
