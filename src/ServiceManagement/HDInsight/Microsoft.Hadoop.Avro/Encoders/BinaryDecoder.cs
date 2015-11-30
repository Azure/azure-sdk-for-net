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
    using System.Globalization;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    ///     Represents a non-buffered binary decoder of Avro basic types.
    /// </summary>
    public sealed class BinaryDecoder : IDecoder
    {
        private readonly bool leaveOpen;
        private Stream stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryDecoder"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        public BinaryDecoder(Stream stream) : this(stream, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryDecoder"/> class.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="leaveOpen">If set to <c>true</c>, leaves the stream open.</param>
        public BinaryDecoder(Stream stream, bool leaveOpen)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            this.stream = stream;
            this.leaveOpen = leaveOpen;
        }

        /// <summary>
        /// Decodes a boolean value.
        /// </summary>
        /// <returns>
        /// Decoded value.
        /// </returns>
        public bool DecodeBool()
        {
            return this.stream.ReadByte() != 0;
        }

        /// <summary>
        /// Decodes an integer value.
        /// </summary>
        /// <returns>
        /// Decoded value.
        /// </returns>
        public int DecodeInt()
        {
            var currentByte = (uint)this.stream.ReadByte();
            byte read = 1;
            uint result = currentByte & 0x7FU;
            int shift = 7;
            while ((currentByte & 0x80) != 0)
            {
                currentByte = (uint)this.stream.ReadByte();
                read++;
                result |= (currentByte & 0x7FU) << shift;
                shift += 7;
                if (read > 5)
                {
                    throw new SerializationException("Invalid integer value in the input stream.");
                }
            }
            return (int)((-(result & 1)) ^ ((result >> 1) & 0x7FFFFFFFU));
        }

        /// <summary>
        /// Decodes a long value.
        /// </summary>
        /// <returns>
        /// Decoded value.
        /// </returns>
        public long DecodeLong()
        {
            var value = (uint)this.stream.ReadByte();
            byte read = 1;
            ulong result = value & 0x7FUL;
            int shift = 7;
            while ((value & 0x80) != 0)
            {
                value = (uint)this.stream.ReadByte();
                read++;
                result |= (value & 0x7FUL) << shift;
                shift += 7;
                if (read > 10)
                {
                    throw new SerializationException("Invalid integer long in the input stream.");
                }
            }
            var tmp = unchecked((long)result);
            return (-(tmp & 0x1L)) ^ ((tmp >> 1) & 0x7FFFFFFFFFFFFFFFL);
        }

        /// <summary>
        /// Decodes a float value.
        /// </summary>
        /// <returns>
        /// Decoded value.
        /// </returns>
        public float DecodeFloat()
        {
            var value = new byte[4];
            this.ReadAllRequiredBytes(value);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(value);
            }
            return BitConverter.ToSingle(value, 0);
        }

        /// <summary>
        /// Decodes a double value.
        /// </summary>
        /// <returns>
        /// Decoded value.
        /// </returns>
        public double DecodeDouble()
        {
            var value = new byte[8];
            this.ReadAllRequiredBytes(value);
            long longValue = value[0]
                | (long)value[1] << 0x8
                | (long)value[2] << 0x10
                | (long)value[3] << 0x18
                | (long)value[4] << 0x20
                | (long)value[5] << 0x28
                | (long)value[6] << 0x30
                | (long)value[7] << 0x38;
            return BitConverter.Int64BitsToDouble(longValue);
        }

        /// <summary>
        /// Decodes a byte array.
        /// </summary>
        /// <returns>
        /// Decoded value.
        /// </returns>
        public byte[] DecodeByteArray()
        {
            int arraySize = this.DecodeInt();
            var array = new byte[arraySize];
            this.ReadAllRequiredBytes(array);
            return array;
        }

        /// <summary>
        /// Decodes a string value.
        /// </summary>
        /// <returns>
        /// Decoded value.
        /// </returns>
        public string DecodeString()
        {
            return Encoding.UTF8.GetString(this.DecodeByteArray());
        }

        /// <summary>
        /// Decodes an array chunk.
        /// </summary>
        /// <returns>
        /// The size of the current chunk.
        /// </returns>
        public int DecodeArrayChunk()
        {
            return this.DecodeChunk();
        }

        /// <summary>
        /// Decodes a map chunk.
        /// </summary>
        /// <returns>
        /// The size of the current chunk.
        /// </returns>
        public int DecodeMapChunk()
        {
            return this.DecodeChunk();
        }

        /// <summary>
        /// Decodes a fixed byte array.
        /// </summary>
        /// <param name="size">The size of the array.</param>
        /// <returns>
        /// Decoded array.
        /// </returns>
        public byte[] DecodeFixed(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("size");
            }

            var array = new byte[size];
            this.ReadAllRequiredBytes(array);
            return array;
        }

        /// <summary>
        /// Skips a boolean value from the underlying stream.
        /// </summary>
        public void SkipBool()
        {
            this.stream.Seek(1, SeekOrigin.Current);
        }

        /// <summary>
        /// Decodes the chunk.
        /// </summary>
        /// <returns>A chunk size.</returns>
        private int DecodeChunk()
        {
            int result = this.DecodeInt();
            if (result < 0)
            {
                this.DecodeLong();
                result = -result;
            }
            return result;
        }

        /// <summary>
        /// Skips a double value from the underlying stream.
        /// </summary>
        public void SkipDouble()
        {
            this.stream.Seek(8, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a float value from the underlying stream.
        /// </summary>
        public void SkipFloat()
        {
            this.stream.Seek(4, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips an integer value from the underlying stream.
        /// </summary>
        public void SkipInt()
        {
            var currentByte = (uint)this.stream.ReadByte();
            while ((currentByte & 0x80) != 0)
            {
                currentByte = (uint)this.stream.ReadByte();
            }
        }

        /// <summary>
        /// Skips a long value from the underlying stream.
        /// </summary>
        public void SkipLong()
        {
            this.SkipInt();
        }

        /// <summary>
        /// Skips a byte array from the underlying stream.
        /// </summary>
        public void SkipByteArray()
        {
            int arraySize = this.DecodeInt();
            this.stream.Seek(arraySize, SeekOrigin.Current);
        }

        /// <summary>
        /// Skips a string value from the underlying stream.
        /// </summary>
        public void SkipString()
        {
            this.SkipByteArray();
        }

        /// <summary>
        /// Skips a fixed value from the underlying stream.
        /// </summary>
        /// <param name="size">The size.</param>
        public void SkipFixed(int size)
        {
            this.stream.Seek(size, SeekOrigin.Current);
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

        private void ReadAllRequiredBytes(byte[] array)
        {
            int read = this.stream.ReadAllRequiredBytes(array, 0, array.Length);
            if (read != array.Length)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Unexpected end of stream: '{0}' bytes missing.", array.Length - read));
            }
        }
    }
}
