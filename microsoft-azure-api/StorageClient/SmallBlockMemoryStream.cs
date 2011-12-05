//-----------------------------------------------------------------------
// <copyright file="SmallBlockMemoryStream.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the SmallBlockMemoryStream class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// This class provides MemoryStream-like behavior but uses a list of blocks rather than a single piece of bufferBlocks.
    /// </summary>
    internal class SmallBlockMemoryStream : Stream
    {
        /// <summary>
        /// The default block size.
        /// </summary>
        private const long DefaultBlockSize = 1024 * 1024; // 1MB

        /// <summary>
        /// The size of the block.
        /// </summary>
        private readonly long blockSize;

        /// <summary>
        /// The underlying bufferBlocks for the stream.
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
        /// Initializes a new instance of the SmallBlockMemoryStream class with default 64KB block size and no reserved space.
        /// </summary>
        public SmallBlockMemoryStream()
            : this(DefaultBlockSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SmallBlockMemoryStream class with provided block size and no reserved space.
        /// </summary>
        /// <param name="blockSize">The size of blocks to use.</param>
        public SmallBlockMemoryStream(long blockSize)
            : this(blockSize, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SmallBlockMemoryStream class.
        /// </summary>
        /// <param name="blockSize">The size of blocks to use.</param>
        /// <param name="reservedSize">The amount of memory to reserve.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="blockSize"/> is zero or negative.</exception>
        public SmallBlockMemoryStream(long blockSize, long reservedSize)
        {
            if (blockSize <= 0)
            {
                throw new ArgumentOutOfRangeException("blockSize", "BlockSize must be a positive, non-zero value");
            }

            this.blockSize = blockSize;
            this.Reserve(reservedSize);
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        /// <value>Is <c>true</c> if the stream supports reading; otherwise, <c>false</c>.</value>
        public override bool CanRead
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        /// <value>Is true if the stream supports seeking; otherwise, false.</value>
        public override bool CanSeek
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// </summary>
        /// <value>Is true if the stream supports writing; otherwise, false.</value>
        public override bool CanWrite
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the currently written length.
        /// </summary>
        public override long Length
        {
            get { return this.length; }
        }

        /// <summary>
        /// Represents the current position in the stream.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if position is outside the stream size</exception>
        public override long Position
        {
            get { return this.position; }
            set { this.Seek(value, SeekOrigin.Begin); }
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
        /// <exception cref="System.ArgumentException">The offset subtracted from the buffer length is less than count.</exception>
        /// <exception cref="System.ArgumentNullException">The buffer is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">The offset or count is negative.</exception>
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "Offset must be positive");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Count must be positive");
            }

            if ((buffer.Length - offset) < count)
            {
                throw new ArgumentException("Offset and count are beyond the buffer size", "count");
            }

            return this.ReadInternal(buffer, offset, count);
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">A value of type System.IO.SeekOrigin indicating the reference point used to obtain the new position.</param>
        /// <returns>The new position within the current stream.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="offset"/> is invalid for SeekOrigin.</exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    if (offset < 0)
                    {
                        throw new ArgumentException("Attempting to seek before the start of the stream", "origin");
                    }

                    if (offset > this.length)
                    {
                        throw new ArgumentException("Attempting to seek past the end of the stream", "origin");
                    }

                    this.position = offset;
                    break;
                case SeekOrigin.Current:
                    if (this.position + offset < 0)
                    {
                        throw new ArgumentException("Attempting to seek before the start of the stream", "origin");
                    }

                    if (this.position + offset > this.length)
                    {
                        throw new ArgumentException("Attempting to seek past the end of the stream", "origin");
                    }

                    this.position += offset;
                    break;
                case SeekOrigin.End:
                    if (this.length + offset < 0)
                    {
                        throw new ArgumentException("Attempting to seek before the start of the stream", "origin");
                    }

                    if (offset > 0)
                    {
                        throw new ArgumentException("Attempting to seek past the end of the stream", "origin");
                    }

                    this.position = this.length + offset;
                    break;
            }

            return this.position;
        }

        /// <summary>
        /// Sets the length of the current stream. (preallocating the bufferBlocks).
        /// </summary>
        /// <param name="value">The desired length of the current stream in bytes.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the <paramref name="value"/> is negative.</exception>
        public override void SetLength(long value)
        {
            this.Reserve(value);
            this.length = value;
        }

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        /// <exception cref="System.ArgumentException">Offset subtracted from the buffer length is less than count. </exception>
        /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="buffer"/> is null</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if <paramref name="offset"/> or <paramref name="count"/> is negative</exception>
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset", "Offset must be positive");
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Count must be positive");
            }

            if ((buffer.Length - offset) < count)
            {
                throw new ArgumentException("Offset subtracted from the buffer length is less than count", "offset");
            }

            // Grow the buffer if more space is needed
            if (this.position + count > this.capacity)
            {
                this.Reserve(this.position + count);
            }

            this.WriteInternal(buffer, offset, count);

            // Adjust the length to be the max of currently written data.
            this.length = Math.Max(this.length, this.position);
        }

        /// <summary>
        /// Does not perform any operation as it's an in-memory stream.
        /// </summary>
        public override void Flush()
        {
        }
        
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
            this.bufferBlocks.Add(new byte[this.blockSize]);
            this.capacity += this.blockSize;
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
                int blockPosition;
                byte[] currentBlock;
                this.GetCurrentBlock(out blockPosition, out currentBlock);

                // Copy the block
                int blockReadLength = Math.Min(leftToRead, currentBlock.Length - blockPosition);
                Buffer.BlockCopy(currentBlock, blockPosition, buffer, offset, blockReadLength);

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
                int blockPosition;
                byte[] currentBlock;
                this.GetCurrentBlock(out blockPosition, out currentBlock);

                // Copy the block
                int blockWriteLength = Math.Min(count, currentBlock.Length - blockPosition);
                Buffer.BlockCopy(buffer, offset, currentBlock, blockPosition, blockWriteLength);

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
        /// Calculate the block for the current position.
        /// </summary>
        /// <param name="blockPosition">The position within a block.</param>
        /// <param name="currentBlock">The block reference itself.</param>
        private void GetCurrentBlock(out int blockPosition, out byte[] currentBlock)
        {
            // Calculate the block and position in a block
            int blockID = (int)(this.position / this.blockSize);
            blockPosition = (int)(this.position % this.blockSize);
            currentBlock = this.bufferBlocks[blockID];
        }
    }
}
