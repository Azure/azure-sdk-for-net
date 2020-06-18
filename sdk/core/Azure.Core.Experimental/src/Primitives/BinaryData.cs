// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Abstraction for a payload of binary data.
    /// </summary>
    public readonly struct BinaryData
    {
        private const int CopyToBufferSize = 81920;

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
        public BinaryData(string data)
            : this(data, Encoding.UTF8)
        {
        }

        /// <summary>
        /// Creates a binary data instance from a string
        /// using the specified encoding.
        /// </summary>
        /// <param name="data">The string data.</param>
        /// <param name="encoding">The encoding to use when converting
        /// the data to bytes.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public BinaryData(string data, Encoding encoding)
        {
            Argument.AssertNotNull(encoding, nameof(encoding));
            Data = encoding.GetBytes(data);
        }

        /// <summary>
        /// Creates a binary data instance from the specified stream.
        /// </summary>
        /// <param name="stream">Stream containing the data.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData FromStream(Stream stream) =>
            CreateAsync(stream, false).EnsureCompleted();

        /// <summary>
        /// Creates a binary data instance from the specified stream.
        /// </summary>
        /// <param name="stream">Stream containing the data.</param>
        /// <param name="cancellationToken">An optional<see cref="CancellationToken"/> instance to signal
        /// the request to cancel the operation.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static async Task<BinaryData> FromStreamAsync(
            Stream stream,
            CancellationToken cancellationToken = default) =>
            await CreateAsync(stream, true, cancellationToken).ConfigureAwait(false);

        private static async Task<BinaryData> CreateAsync(
            Stream stream,
            bool async,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            if (stream.CanSeek && stream.Length > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(stream),
                    "Stream length must be less than Int32.MaxValue");
            }
            using (var memoryStream = new MemoryStream())
            {
                if (async)
                {
                    await stream.CopyToAsync(memoryStream, CopyToBufferSize, cancellationToken).ConfigureAwait(false);
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
        public static BinaryData FromSerializable<T>(
            T data,
            ObjectSerializer serializer) =>
            FromSerializableAsync<T>(data, serializer, false).EnsureCompleted();

        /// <summary>
        /// Creates a BinaryData instance from the specified data using
        /// the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="data">The data to use.</param>
        /// <param name="serializer">The serializer to serialize
        /// the data.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        /// TODO - add cancellation token support
        /// once ObjectSerializer.SerializeAsync adds it.
        public static async Task<BinaryData> FromSerializableAsync<T>(
            T data,
            ObjectSerializer serializer) =>
            await FromSerializableAsync<T>(data, serializer, true).ConfigureAwait(false);

        private static async Task<BinaryData> FromSerializableAsync<T>(
            T data,
            ObjectSerializer serializer,
            bool async)
        {
            Argument.AssertNotNull(serializer, nameof(serializer));
            using var memoryStream = new MemoryStream();
            if (async)
            {
                await serializer.SerializeAsync(memoryStream, data, typeof(T)).ConfigureAwait(false);
            }
            else
            {
                serializer.Serialize(memoryStream, data, typeof(T));
            }
            return new BinaryData(memoryStream.ToArray());
        }

        /// <summary>
        /// Converts the BinaryData to a string using UTF-8.
        /// </summary>
        /// <returns>The string representation of the data.</returns>
        public override string ToString() =>
           ToString(Encoding.UTF8);

        /// <summary>
        /// Converts the BinaryData to a string using the specified
        /// encoding.
        /// </summary>
        /// <param name="encoding">The encoding to use when decoding
        /// the bytes.</param>
        /// <returns>The string representation of the data.</returns>
        public string ToString(
            Encoding encoding)
        {
            Argument.AssertNotNull(encoding, nameof(encoding));
            if (MemoryMarshal.TryGetArray(
                Data,
                out ArraySegment<byte> data))
            {
                return encoding.GetString(data.Array, data.Offset, data.Count);
            }
            return encoding.GetString(Data.ToArray());
        }

        /// <summary>
        /// Converts the BinaryData to bytes.
        /// </summary>
        /// <returns>The data as bytes.</returns>
        public ReadOnlyMemory<byte> AsBytes() =>
            Data;

        /// <summary>
        /// Converts the BinaryData to a stream.
        /// </summary>
        /// <returns>A stream representing the data.</returns>
        public Stream ToStream()
        {
            if (MemoryMarshal.TryGetArray(
                Data,
                out ArraySegment<byte> data))
            {
                return new MemoryStream(data.Array, data.Offset, data.Count);
            }
            return new MemoryStream(Data.ToArray());
        }

        /// <summary>
        /// Converts the BinaryData to the specified type.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        ///<returns>The data converted to the specified type.</returns>
        public T Deserialize<T>(ObjectSerializer serializer) =>
            DeserializeAsync<T>(serializer, false).EnsureCompleted();

        /// <summary>
        /// Converts the BinaryData to the specified type.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        ///<returns>The data cast to the specified type. If the cast cannot
        ///be performed, an <see cref="InvalidCastException"/> will be
        ///thrown.</returns>
        /// TODO - add cancellation token support
        /// once ObjectSerializer.DeserializeAsync adds it.
        public async ValueTask<T> DeserializeAsync<T>(
            ObjectSerializer serializer) =>
            await DeserializeAsync<T>(serializer, true).ConfigureAwait(false);

        private async ValueTask<T> DeserializeAsync<T>(
            ObjectSerializer serializer,
            bool async)
        {
            Argument.AssertNotNull(serializer, nameof(serializer));
            if (async)
            {
                return (T)await serializer.DeserializeAsync(
                    ToStream(),
                    typeof(T))
                    .ConfigureAwait(false);
            }
            else
            {
                return (T)serializer.Deserialize(ToStream(), typeof(T));
            }
        }

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
