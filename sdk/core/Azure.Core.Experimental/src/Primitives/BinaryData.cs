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
    /// A lightweight abstraction for a payload of bytes. This type integrates with <see cref="ObjectSerializer"/>
    /// to allow for serializing and deserializing payloads.
    ///
    /// The ownership model of the underlying bytes varies depending on how the instance is constructed:
    ///
    /// If created using the static factory method, <see cref="FromMemory(ReadOnlyMemory{byte})"/>,
    /// the passed in bytes will be wrapped, rather than copied. This is useful in scenarios where performance
    /// is critical and/or ownership of the bytes is controlled completely by the consumer, thereby allowing the
    /// enforcement of whatever ownership model is needed.
    ///
    /// If created using the <see cref="BinaryData(ReadOnlySpan{byte})"/> constructor, <see cref="BinaryData"/> will
    /// maintain its own copy of the underlying bytes. This usage is geared more towards scenarios where the ownership
    /// of the bytes might be ambiguous to users of the consuming code. By making a copy of the bytes, the payload is
    /// guaranteed to be immutable.
    ///
    /// For all other constructors and static factory methods, BinaryData will assume ownership of the underlying bytes.
    /// </summary>
    public readonly struct BinaryData
    {
        private const int CopyToBufferSize = 81920;

        private static readonly UTF8Encoding s_encoding = new UTF8Encoding(false);

        private readonly Stream? _originalStream;

        private readonly Lazy<ReadOnlyMemory<byte>> _bytes;

        /// <summary>
        /// Creates a binary data instance by making a copy
        /// of the passed in bytes.
        /// </summary>
        /// <param name="data">Byte data.</param>
        public BinaryData(ReadOnlySpan<byte> data)
        {
            var bytes = data.ToArray();
            _bytes = new Lazy<ReadOnlyMemory<byte>>(
                () => bytes);
            _originalStream = default;
        }

        /// <summary>
        /// Creates a binary data instance by wrapping the
        /// passed in bytes.
        /// </summary>
        /// <param name="data">Byte data.</param>
        private BinaryData(ReadOnlyMemory<byte> data)
        {
            _bytes = new Lazy<ReadOnlyMemory<byte>>(
                () => data);
            _originalStream = default;
        }

        /// <summary>
        /// Creates a binary data instance from a string by converting
        /// the string to bytes using UTF-8 encoding.
        /// </summary>
        /// <param name="data">The string data.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        /// <remarks>The byte order mark is not included as part of the encoding process.</remarks>
        public BinaryData(string data)
        {
            _bytes = new Lazy<ReadOnlyMemory<byte>>(
                () => s_encoding.GetBytes(data));
            _originalStream = default;
        }

        /// <summary>
        /// Creates a binary data instance by wrapping the passed in stream.
        /// This will allow lazy access to the underlying bytes.
        /// </summary>
        /// <param name="stream">The stream to wrap.</param>
        public BinaryData(Stream stream)
        {
            Argument.AssertNotNull(stream, nameof(stream));
            _originalStream = stream;
            _bytes = new Lazy<ReadOnlyMemory<byte>>(
                () => FromStream(stream).ToBytes());
        }

        /// <summary>
        /// Creates a binary data instance by wrapping the passed in
        /// <see cref="ReadOnlyMemory{Byte}"/>.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData FromMemory(ReadOnlyMemory<byte> data) =>
            new BinaryData(data);

        /// <summary>
        /// Creates a binary data instance from the specified stream.
        /// </summary>
        /// <param name="stream">Stream containing the data.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData FromStream(Stream stream) =>
            FromStreamAsync(stream, false).EnsureCompleted();

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
            await FromStreamAsync(stream, true, cancellationToken).ConfigureAwait(false);

        private static async Task<BinaryData> FromStreamAsync(
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
                return new BinaryData((ReadOnlyMemory<byte>)memoryStream.ToArray());
            }
        }

        /// <summary>
        /// Creates a BinaryData instance from the specified data using
        /// the <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="data">The data to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData Serialize<T>(
            T data,
            CancellationToken cancellationToken = default) =>
            Serialize<T>(data, new JsonObjectSerializer(), cancellationToken);

        /// <summary>
        /// Creates a BinaryData instance from the specified data
        /// using the <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="data">The data to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static async Task<BinaryData> SerializeAsync<T>(
            T data,
            CancellationToken cancellationToken = default) =>
            await SerializeInternalAsync<T>(data, new JsonObjectSerializer(), true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a BinaryData instance from the specified data using
        /// the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="data">The data to use.</param>
        /// <param name="serializer">The serializer to serialize
        /// the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData Serialize<T>(
            T data,
            ObjectSerializer serializer,
            CancellationToken cancellationToken = default) =>
            SerializeInternalAsync<T>(data, serializer, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Creates a BinaryData instance from the specified data using
        /// the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="data">The data to use.</param>
        /// <param name="serializer">The serializer to serialize
        /// the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static async Task<BinaryData> SerializeAsync<T>(
            T data,
            ObjectSerializer serializer,
            CancellationToken cancellationToken = default) =>
            await SerializeInternalAsync<T>(data, serializer, true, cancellationToken).ConfigureAwait(false);

        private static async Task<BinaryData> SerializeInternalAsync<T>(
            T data,
            ObjectSerializer serializer,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(serializer, nameof(serializer));
            using var memoryStream = new MemoryStream();
            if (async)
            {
                await serializer.SerializeAsync(memoryStream, data, typeof(T), cancellationToken).ConfigureAwait(false);
            }
            else
            {
                serializer.Serialize(memoryStream, data, typeof(T), cancellationToken);
            }
            return new BinaryData((ReadOnlyMemory<byte>)memoryStream.ToArray());
        }

        /// <summary>
        /// Converts the BinaryData to a string using UTF-8.
        /// </summary>
        /// <returns>The string representation of the data.</returns>
        public override string ToString()
        {
            if (MemoryMarshal.TryGetArray(
                _bytes.Value,
                out ArraySegment<byte> data))
            {
                return s_encoding.GetString(data.Array, data.Offset, data.Count);
            }
            return s_encoding.GetString(_bytes.Value.ToArray());
        }

        /// <summary>
        /// Converts the BinaryData to a stream.
        /// </summary>
        /// <returns>A stream representing the data.</returns>
        public Stream ToStream()
        {
            if (_originalStream != null)
            {
                return _originalStream;
            }
            if (MemoryMarshal.TryGetArray(
                _bytes!.Value,
                out ArraySegment<byte> data))
            {
                return new MemoryStream(data.Array, data.Offset, data.Count);
            }
            return new MemoryStream(_bytes.Value.ToArray());
        }

        /// <summary>
        /// Gets the underlying bytes for the instance of BinaryData.
        /// </summary>
        /// <returns>The underlying bytes.</returns>
        public ReadOnlyMemory<byte> ToBytes() => _bytes.Value;

        /// <summary>
        /// Converts the BinaryData to the specified type using
        /// the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data converted to the specified type.</returns>
        public T Deserialize<T>(ObjectSerializer serializer, CancellationToken cancellationToken = default) =>
            DeserializeInternalAsync<T>(serializer, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Converts the BinaryData to the specified type using the
        /// <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data cast to the specified type. If the cast cannot
        ///be performed, an <see cref="InvalidCastException"/> will be
        ///thrown.</returns>
        public async ValueTask<T> DeserializeAsync<T>(CancellationToken cancellationToken = default) =>
            await DeserializeInternalAsync<T>(new JsonObjectSerializer(), true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Converts the BinaryData to the specified type using the
        /// <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data converted to the specified type.</returns>
        public T Deserialize<T>(CancellationToken cancellationToken = default) =>
            DeserializeInternalAsync<T>(new JsonObjectSerializer(), false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Converts the BinaryData to the specified type using the
        /// provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data cast to the specified type. If the cast cannot
        ///be performed, an <see cref="InvalidCastException"/> will be
        ///thrown.</returns>
        public async ValueTask<T> DeserializeAsync<T>(ObjectSerializer serializer, CancellationToken cancellationToken = default) =>
            await DeserializeInternalAsync<T>(serializer, true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<T> DeserializeInternalAsync<T>(
            ObjectSerializer serializer,
            bool async,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(serializer, nameof(serializer));
            if (async)
            {
                return (T)await serializer.DeserializeAsync(
                    ToStream(),
                    typeof(T),
                    cancellationToken)
                    .ConfigureAwait(false);
            }
            else
            {
                return (T)serializer.Deserialize(ToStream(), typeof(T), cancellationToken);
            }
        }

        /// <summary>
        /// Two BinaryData objects are equal if the memory regions point to the same array and have the same length.
        /// The method does not check to see if the contents are equal.
        /// </summary>
        /// <param name="obj">The BinaryData to compare.</param>
        /// <returns>true if the current instance and other are equal; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj)
        {
            if (obj is BinaryData data)
            {
                return data._bytes.Value.Equals(_bytes.Value);
            }
            return false;
        }
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            _bytes.Value.GetHashCode();
    }
}
