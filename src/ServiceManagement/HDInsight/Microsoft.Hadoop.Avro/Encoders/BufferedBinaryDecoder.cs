// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro
{
    using System;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    ///     Represents a buffered binary decoder of Avro basic types.
    /// </summary>
    public sealed class BufferedBinaryDecoder : IDecoder
    {
        private readonly Stream stream;
        private byte[] buffer;
        private int available;
        private int currentBufferPosition;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BufferedBinaryDecoder"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="stream"/> is null.</exception>
        public BufferedBinaryDecoder(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            this.buffer = new byte[1024];
            this.stream = stream;
            this.TryReadAhead(this.buffer.Length);
        }

        /// <summary>
        ///     Decodes boolean.
        /// </summary>
        /// <returns>Decoded value.</returns>
        public bool DecodeBool()
        {
            if (this.TryReadAhead(1) < 1)
            {
                throw new SerializationException("Unexpected end of the input stream");
            }

            return this.buffer[this.currentBufferPosition++] != 0;
        }

        /// <summary>
        ///     Decodes integer.
        /// </summary>
        /// <returns>Decoded value.</returns>
        public int DecodeInt()
        {
            int stillAvailable = this.TryReadAhead(5);
            if (stillAvailable == 0)
            {
                throw new SerializationException("Invalid integer value in the input stream.");
            }

            uint currentByte = this.buffer[this.currentBufferPosition++];
            uint result = currentByte & 0x7F;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 1)
            {
                throw new SerializationException("Invalid integer value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7F) << 7;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 2)
            {
                throw new SerializationException("Invalid integer value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7F) << 14;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 3)
            {
                throw new SerializationException("Invalid integer value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7F) << 21;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 4)
            {
                throw new SerializationException("Invalid integer value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7F) << 28;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }

            throw new SerializationException("Invalid integer value in the input stream.");
        }

        /// <summary>
        ///     Decodes long.
        /// </summary>
        /// <returns>Decoded value.</returns>
        public long DecodeLong()
        {
            int stillAvailable = this.TryReadAhead(10);
            if (stillAvailable == 0)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            uint currentByte = this.buffer[this.currentBufferPosition++];
            ulong result = currentByte & 0x7F;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 1)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7FUL) << 7;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 2)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7FUL) << 14;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 3)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7FUL) << 21;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 4)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7FUL) << 28;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 5)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7FUL) << 35;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 6)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7FUL) << 42;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 7)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7FUL) << 49;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 8)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7FUL) << 56;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }
            if (stillAvailable == 9)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            result |= (currentByte & 0x7FUL) << 63;
            if ((currentByte & 0x80) == 0)
            {
                return FromZigZag(result);
            }

            throw new SerializationException("Invalid long value in the input stream.");
        }

        /// <summary>
        /// Converts the value from ZIG-ZAG to C# representation.
        /// </summary>
        /// <param name="value">ZIG-ZAG value.</param>
        /// <returns>C# value.</returns>
        private static long FromZigZag(ulong value)
        {
            return unchecked((-((long)value & 0x1L)) ^ (((long)value >> 1) & 0x7FFFFFFFFFFFFFFFL));
        }

        /// <summary>
        /// Converts the value from ZIG-ZAG to C# representation.
        /// </summary>
        /// <param name="value">ZIG-ZAG value.</param>
        /// <returns>C# value.</returns>
        private static int FromZigZag(uint value)
        {
            return unchecked((int)((-(value & 1)) ^ ((value >> 1) & 0x7FFFFFFFU)));
        }

        /// <summary>
        ///     Decodes float.
        /// </summary>
        /// <returns>Decoded value.</returns>
        public float DecodeFloat()
        {
            int stillAvailable = this.TryReadAhead(4);
            if (stillAvailable < 4)
            {
                throw new SerializationException("Unexpected end of the input stream.");
            }

            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(this.buffer, this.currentBufferPosition, 4);
            }
            float result = BitConverter.ToSingle(this.buffer, this.currentBufferPosition);
            this.currentBufferPosition += 4;
            return result;
        }

        /// <summary>
        ///     Decodes double.
        /// </summary>
        /// <returns>Decoded value.</returns>
        public double DecodeDouble()
        {
            int stillAvailable = this.TryReadAhead(8);
            if (stillAvailable < 8)
            {
                throw new SerializationException("Unexpected end of the input stream.");
            }

            long longValue = this.buffer[this.currentBufferPosition++]
                | (long)this.buffer[this.currentBufferPosition++] << 0x8
                | (long)this.buffer[this.currentBufferPosition++] << 0x10
                | (long)this.buffer[this.currentBufferPosition++] << 0x18
                | (long)this.buffer[this.currentBufferPosition++] << 0x20
                | (long)this.buffer[this.currentBufferPosition++] << 0x28
                | (long)this.buffer[this.currentBufferPosition++] << 0x30
                | (long)this.buffer[this.currentBufferPosition++] << 0x38;
            return BitConverter.Int64BitsToDouble(longValue);
        }

        /// <summary>
        ///     Decodes byte array.
        /// </summary>
        /// <returns>Decoded value.</returns>
        public byte[] DecodeByteArray()
        {
            int arraySize = this.DecodeInt();
            int stillAvailable = this.TryReadAhead(arraySize);
            if (stillAvailable < arraySize)
            {
                throw new SerializationException("Unexpected end of the input stream.");
            }

            var array = new byte[arraySize];
            Array.Copy(this.buffer, this.currentBufferPosition, array, 0, arraySize);
            this.currentBufferPosition += arraySize;
            return array;
        }

        /// <summary>
        ///     Decodes string value.
        /// </summary>
        /// <returns>Decoded value.</returns>
        public string DecodeString()
        {
            int arraySize = this.DecodeInt();
            int stillAvailable = this.TryReadAhead(arraySize);
            if (stillAvailable < arraySize)
            {
                throw new SerializationException("Unexpected end of the input stream.");
            }

            string result = Encoding.UTF8.GetString(this.buffer, this.currentBufferPosition, arraySize);
            this.currentBufferPosition += arraySize;
            return result;
        }

        /// <summary>
        ///     Flushes this instance.
        /// </summary>
        public void Flush()
        {
            if (this.available - this.currentBufferPosition > 0)
            {
                this.stream.Seek(this.currentBufferPosition - this.available, SeekOrigin.Current);
            }
        }

        /// <summary>
        /// Skips one byte from the stream.
        /// </summary>
        public void SkipBool()
        {
            if (this.TryReadAhead(1) < 1)
            {
                throw new SerializationException("Unexpected end of the input stream.");
            }

            this.currentBufferPosition++;
        }

        /// <summary>
        ///     Decodes the array chunk.
        /// </summary>
        /// <returns>Chunk size.</returns>
        public int DecodeArrayChunk()
        {
            return this.DecodeChunk();
        }

        /// <summary>
        ///     Decodes the map chunk.
        /// </summary>
        /// <returns>Chunk size.</returns>
        public int DecodeMapChunk()
        {
            return this.DecodeChunk();
        }

        /// <summary>
        ///     Decodes the fixed.
        /// </summary>
        /// <param name="size">The size.</param>
        /// <returns>Fixed array of bytes.</returns>
        public byte[] DecodeFixed(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("size");
            }

            int stillAvailable = this.TryReadAhead(size);
            if (stillAvailable < size)
            {
                throw new SerializationException("Unexpected end of the input stream.");
            }

            var array = new byte[size];
            Array.Copy(this.buffer, this.currentBufferPosition, array, 0, size);
            this.currentBufferPosition += size;
            return array;
        }

        private int TryReadAhead(int size)
        {
            int buffered = this.available - this.currentBufferPosition;

            if (size < buffered)
            {
                return size;
            }

            if (this.buffer.Length < size)
            {
                var tmp = new byte[Math.Max(this.buffer.Length * 2, size)];
                Array.Copy(this.buffer, this.currentBufferPosition, tmp, 0, buffered);
                this.available -= this.currentBufferPosition;
                this.currentBufferPosition = 0;
                this.buffer = tmp;
            }

            size -= buffered;

            if (size + this.available > this.buffer.Length)
            {
                Array.Copy(this.buffer, this.currentBufferPosition, this.buffer, 0, buffered);
                this.available -= this.currentBufferPosition;
                this.currentBufferPosition = 0;
            }

            this.available += this.stream.ReadAllRequiredBytes(this.buffer, this.available, size);
            return this.available - this.currentBufferPosition;
        }

        private int DecodeChunk()
        {
            int result = this.DecodeInt();
            if (result < 0)
            {
                this.DecodeInt();
                result = -result;
            }
            return result;
        }

        /// <summary>
        ///     Skips a double (8 bytes) from the stream.
        /// </summary>
        public void SkipDouble()
        {
            if (this.TryReadAhead(8) < 8)
            {
                throw new SerializationException("Unexpected end of the input stream.");
            }

            this.currentBufferPosition += 8;
        }

        /// <summary>
        ///     Skips a float (4 bytes) from the stream.
        /// </summary>
        public void SkipFloat()
        {
            if (this.TryReadAhead(4) < 4)
            {
                throw new SerializationException("Unexpected end of the input stream.");
            }

            this.currentBufferPosition += 4;
        }

        /// <summary>
        /// Skips a integer.
        /// </summary>
        public void SkipInt()
        {
            int stillAvailable = this.TryReadAhead(5);
            if (stillAvailable == 0)
            {
                throw new SerializationException("Invalid int value in the input stream.");
            }

            uint currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 1)
            {
                throw new SerializationException("Invalid int value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 2)
            {
                throw new SerializationException("Invalid int value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 3)
            {
                throw new SerializationException("Invalid int value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 4)
            {
                throw new SerializationException("Invalid int value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }

            throw new SerializationException("Invalid int value in the input stream.");
        }

        /// <summary>
        ///     Skips a long.
        /// </summary>
        public void SkipLong()
        {
            int stillAvailable = this.TryReadAhead(10);
            if (stillAvailable == 0)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            uint currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 1)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 2)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 3)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 4)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 5)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 6)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 7)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 8)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }
            if (stillAvailable == 9)
            {
                throw new SerializationException("Invalid long value in the input stream.");
            }

            currentByte = this.buffer[this.currentBufferPosition++];
            if ((currentByte & 0x80) == 0)
            {
                return;
            }

            throw new SerializationException("Invalid long value in the input stream.");
        }

        /// <summary>
        /// Skips a byte array.
        /// </summary>
        public void SkipByteArray()
        {
            int arraySize = this.DecodeInt();
            int stillAvailable = this.TryReadAhead(arraySize);
            if (stillAvailable < arraySize)
            {
                throw new SerializationException("Unexpected number of bytes.");
            }
            this.currentBufferPosition += arraySize;
        }

        /// <summary>
        ///     Skips a string.
        /// </summary>
        public void SkipString()
        {
            this.SkipByteArray();
        }

        /// <summary>
        /// Skips fixed array.
        /// </summary>
        /// <param name="size">The size.</param>
        public void SkipFixed(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("size");
            }

            int stillAvailable = this.TryReadAhead(size);
            if (stillAvailable < size)
            {
                throw new SerializationException("Unexpected number of bytes.");
            }
            this.currentBufferPosition += size;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Flush();
        }
    }
}
