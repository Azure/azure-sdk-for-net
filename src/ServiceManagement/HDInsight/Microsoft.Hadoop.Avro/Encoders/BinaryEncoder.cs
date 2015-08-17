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
    using System.Text;

    /// <summary>
    ///     Represents a non-buffered binary encoder of Avro basic types.
    /// </summary>
    public sealed class BinaryEncoder : IEncoder
    {
        private readonly bool leaveOpen;
        private Stream stream;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BinaryEncoder" /> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="stream"/> is null.</exception>
        /// <remarks>By default, the stream is not disposed.</remarks>
        public BinaryEncoder(Stream stream) : this(stream, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryEncoder"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="leaveOpen">If set to <c>true</c>, leaves the stream open.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="stream"/> is null.</exception>
        public BinaryEncoder(Stream stream, bool leaveOpen)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            this.stream = stream;
            this.leaveOpen = leaveOpen;
        }

        /// <summary>
        /// Encodes a boolean value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        public void Encode(bool value)
        {
            this.stream.WriteByte(value ? (byte)1 : (byte)0);
        }

        /// <summary>
        /// Encodes an integer value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        public void Encode(int value)
        {
            var zigZagEncoded = unchecked((uint)((value << 1) ^ (value >> 31)));
            while ((zigZagEncoded & ~0x7F) != 0)
            {
                this.stream.WriteByte((byte)((zigZagEncoded | 0x80) & 0xFF));
                zigZagEncoded >>= 7;
            }
            this.stream.WriteByte((byte)zigZagEncoded);
        }

        /// <summary>
        /// Encodes a long value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        public void Encode(long value)
        {
            var zigZagEncoded = unchecked((ulong)((value << 1) ^ (value >> 63)));
            while ((zigZagEncoded & ~0x7FUL) != 0)
            {
                this.stream.WriteByte((byte)((zigZagEncoded | 0x80) & 0xFF));
                zigZagEncoded >>= 7;
            }
            this.stream.WriteByte((byte)zigZagEncoded);
        }

        /// <summary>
        /// Encodes a float value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        public void Encode(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }
            this.stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Encodes a double value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        public void Encode(double value)
        {
            long encodedValue = BitConverter.DoubleToInt64Bits(value);
            this.stream.WriteByte((byte)(encodedValue & 0xFF));
            this.stream.WriteByte((byte)((encodedValue >> 0x8) & 0xFF));
            this.stream.WriteByte((byte)((encodedValue >> 0x10) & 0xFF));
            this.stream.WriteByte((byte)((encodedValue >> 0x18) & 0xFF));
            this.stream.WriteByte((byte)((encodedValue >> 0x20) & 0xFF));
            this.stream.WriteByte((byte)((encodedValue >> 0x28) & 0xFF));
            this.stream.WriteByte((byte)((encodedValue >> 0x30) & 0xFF));
            this.stream.WriteByte((byte)((encodedValue >> 0x38) & 0xFF));
        }

        /// <summary>
        /// Encodes a byte array as <i>bytes</i> Avro type.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        /// <exception cref="System.ArgumentNullException">Thrown, if the <paramref name="value"/> is null.</exception>
        public void Encode(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.Encode(value.Length);
            this.stream.Write(value, 0, value.Length);
        }

        /// <summary>
        /// Encodes a string value.
        /// </summary>
        /// <param name="value">Value to encode.</param>
        /// <exception cref="System.ArgumentNullException">Thrown, if the <paramref name="value"/> is null.</exception>
        public void Encode(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.Encode(Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// Clears all buffers for this encoder and causes any buffered data to be written to
        /// the underlying stream/device.
        /// </summary>
        public void Flush()
        {
        }

        /// <summary>
        /// Encodes an array chunk of <paramref name="size" />.
        /// </summary>
        /// <param name="size">The chunk size.</param>
        public void EncodeArrayChunk(int size)
        {
            this.Encode(size);
        }

        /// <summary>
        /// Encodes a map chunk of <paramref name="size" />.
        /// </summary>
        /// <param name="size">Chunk size.</param>
        public void EncodeMapChunk(int size)
        {
            this.Encode(size);
        }

        /// <summary>
        /// Encodes a byte array as <i>fixed</i> Avro type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException">Thrown, if the <paramref name="value"/> is null.</exception>
        public void EncodeFixed(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.stream.Write(value, 0, value.Length);
        }

        /// <summary>
        /// Encodes a stream as <i>bytes</i> Avro type.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <exception cref="System.ArgumentNullException">Thrown, if the <paramref name="stream"/> is null.</exception>
        public void Encode(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            this.Encode(stream.Length);
            stream.CopyTo(this.stream);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!this.leaveOpen && this.stream != null)
            {
                this.stream.Dispose();
                this.stream = null;
            }
        }
    }
}
