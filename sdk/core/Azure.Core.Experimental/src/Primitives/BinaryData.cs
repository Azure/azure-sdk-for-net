// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Abstraction for a payload of binary data.
    /// </summary>
    public struct BinaryData
    {
        /// <summary>
        /// The backing store for the <see cref="BinaryData"/> instance.
        /// </summary>
        internal ReadOnlyMemory<byte> Data { get; }

        /// <summary>
        /// Creates a binary data instance from bytes.
        /// </summary>
        /// <param name="data">Byte data.</param>
        public BinaryData(ReadOnlyMemory<byte> data)
        {
            Data = data;
        }

        /// <summary>
        /// Creates a binary data instance from a string
        /// using UTF-8 encoding.
        /// </summary>
        /// <param name="data">The string data.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData Create(string data) =>
            Create(data, Encoding.UTF8);

        /// <summary>
        /// Creates a binary data instance from a string
        /// using the specified encoding.
        /// </summary>
        /// <param name="data">The string data.</param>
        /// <param name="encoding">The encoding to use when converting
        /// the data to bytes.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData Create(string data, Encoding encoding)
        {
            Argument.AssertNotNull(encoding, nameof(encoding));
            return new BinaryData(encoding.GetBytes(data));
        }

        /// <summary>
        /// Creates a binary data instance from the specified stream.
        /// </summary>
        /// <param name="stream">Stream containing the data.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData Create(Stream stream) =>
            CreateAsync(stream, false).EnsureCompleted();

        /// <summary>
        /// Creates a binary data instance from the specified stream.
        /// </summary>
        /// <param name="stream">Stream containing the data.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static async Task<BinaryData> CreateAsync(Stream stream) =>
            await CreateAsync(stream, true).ConfigureAwait(false);

        private static async Task<BinaryData> CreateAsync(Stream stream, bool async)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            using (var memoryStream = new MemoryStream())
            {
                if (async)
                {
                    await stream.CopyToAsync(memoryStream).ConfigureAwait(false);
                }
                else
                {
                    stream.CopyTo(memoryStream);
                }
                return new BinaryData(memoryStream.ToArray());
            }
        }

        /// <summary>
        /// Creates a BinaryData instance from the specified data using
        /// the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="data">The data to use.</param>
        /// <param name="serializer">The serializer to serialize
        /// the data.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData Create<T>(
            T data,
            ObjectSerializer serializer)
        {
            Argument.AssertNotNull(serializer, nameof(serializer));
            using var memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, data, typeof(T));
            return new BinaryData(memoryStream.ToArray());
        }

        /// <summary>
        /// Implicit conversion to string.
        /// </summary>
        /// <param name="data"></param>
        public static implicit operator string(BinaryData data) =>
            data.AsString();

        /// <summary>
        /// Implicit conversion to bytes.
        /// </summary>
        /// <param name="data"></param>
        public static implicit operator ReadOnlyMemory<byte>(
            BinaryData data) =>
            data.AsBytes();

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj)
        {
            if (obj is BinaryData data)
            {
                return data.Data.Equals(Data);
            }

            return false;
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            Data.GetHashCode();
    }
}
