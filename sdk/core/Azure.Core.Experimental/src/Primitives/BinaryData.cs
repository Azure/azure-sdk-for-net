﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

namespace Azure
{
    /// <summary>
    /// A lightweight abstraction for a payload of bytes. This type integrates with <see cref="ObjectSerializer"/>
    /// to allow for serializing and deserializing payloads.
    ///
    /// The ownership model of the underlying bytes varies depending on how the instance is constructed:
    ///
    /// If created using the static factory method, <see cref="FromBytes(ReadOnlyMemory{byte})"/>,
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

        private static readonly JsonObjectSerializer s_jsonSerializer = new JsonObjectSerializer();

        /// <summary>
        /// The backing store for the <see cref="BinaryData"/> instance.
        /// </summary>
        internal ReadOnlyMemory<byte> Bytes { get; }

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by making a copy
        /// of the passed in bytes.
        /// </summary>
        /// <param name="data">Byte data.</param>
        public BinaryData(ReadOnlySpan<byte> data)
        {
            Bytes = data.ToArray();
        }

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by wrapping the
        /// passed in array of bytes.
        /// </summary>
        /// <param name="data">Byte data.</param>
        public BinaryData(byte[] data)
        {
            Bytes = data;
        }

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by serializing the passed in object to Json
        /// using <see cref="JsonObjectSerializer"/>.
        /// </summary>
        ///
        /// <param name="jsonSerializable">The object that will be serialized to Json using
        /// <see cref="JsonObjectSerializer"/>.</param>
        /// <param name="type">The type of the data. If not specified, <see cref="object.GetType"/> will
        /// be used to determine the type.</param>
        ///
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public BinaryData(object jsonSerializable, Type? type = default)
            : this(jsonSerializable, s_jsonSerializer, type)
        {
        }

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by serializing the passed in object
        /// using the provided <see cref="ObjectSerializer"/>. If no <see cref="ObjectSerializer"/>
        /// is specified, <see cref="JsonObjectSerializer"/> will be used.
        /// </summary>
        ///
        /// <param name="serializable">The data that will be serialized.</param>
        /// <param name="serializer">The serializer to serialize the data.</param>
        /// <param name="type">The type of the data. If not specified, <see cref="object.GetType"/> will
        /// be used to determine the type.</param>
        ///
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public BinaryData(object serializable, ObjectSerializer serializer, Type? type = default)
        {
            using var memoryStream = new MemoryStream();
            serializer ??= s_jsonSerializer;
            serializer.Serialize(memoryStream, serializable, type ?? serializable?.GetType() ?? typeof(object), CancellationToken.None);
            Bytes = memoryStream.ToArray();
        }

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by wrapping the
        /// passed in bytes.
        /// </summary>
        /// <param name="data">Byte data.</param>
        public BinaryData(ReadOnlyMemory<byte> data)
        {
            Bytes = data;
        }

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance from a string by converting
        /// the string to bytes using UTF-8 encoding.
        /// </summary>
        /// <param name="data">The string data.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        /// <remarks>The byte order mark is not included as part of the encoding process.</remarks>
        public BinaryData(string data)
        {
            Bytes = s_encoding.GetBytes(data);
        }

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by wrapping the passed in
        /// <see cref="ReadOnlyMemory{Byte}"/>.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData FromBytes(ReadOnlyMemory<byte> data) =>
            new BinaryData(data);

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by copying the passed in
        /// <see cref="ReadOnlySpan{Byte}"/>.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData FromBytes(ReadOnlySpan<byte> data) =>
            new BinaryData(data);

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by wrapping the passed in
        /// byte array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData FromBytes(byte[] data) =>
            new BinaryData(data);

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance using the passed in string.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData FromString(string data) =>
            new BinaryData(data);

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance from the specified stream.
        /// The passed in stream is not disposed by this method.
        /// </summary>
        /// <param name="stream">Stream containing the data.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData FromStream(Stream stream) =>
            FromStreamAsync(stream, false).EnsureCompleted();

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance from the specified stream.
        /// The passed in stream is not disposed by this method.
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
        /// Creates a <see cref="BinaryData"/> instance by serializing the passed in object using
        /// the <see cref="JsonObjectSerializer"/>.
        /// </summary>
        ///
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="jsonSerializable">The data to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        ///
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData FromObject<T>(
            T jsonSerializable,
            CancellationToken cancellationToken = default) =>
            FromObject<T>(jsonSerializable, s_jsonSerializer, cancellationToken);

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by serializing the passed in object using
        /// the <see cref="JsonObjectSerializer"/>.
        /// </summary>
        ///
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="jsonSerializable">The data to use.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        ///
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static async ValueTask<BinaryData> FromObjectAsync<T>(
            T jsonSerializable,
            CancellationToken cancellationToken = default) =>
            await FromObjectInternalAsync<T>(jsonSerializable, s_jsonSerializer, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by serializing the passed in object using
        /// the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        ///
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="serializable">The data to use.</param>
        /// <param name="serializer">The serializer to serialize
        /// the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        ///
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static BinaryData FromObject<T>(
            T serializable,
            ObjectSerializer serializer,
            CancellationToken cancellationToken = default) =>
            FromObjectInternalAsync<T>(serializable, serializer, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by serializing the passed in object using
        /// the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        ///
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="serializable">The data to use.</param>
        /// <param name="serializer">The serializer to serialize
        /// the data.</param>
        ///
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        public static async ValueTask<BinaryData> FromObjectAsync<T>(
            T serializable,
            ObjectSerializer serializer,
            CancellationToken cancellationToken = default) =>
            await FromObjectInternalAsync<T>(serializable, serializer, true, cancellationToken).ConfigureAwait(false);

        private static async ValueTask<BinaryData> FromObjectInternalAsync<T>(
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
        /// Converts the <see cref="BinaryData"/> to a string using UTF-8.
        /// </summary>
        /// <returns>The string representation of the <see cref="BinaryData"/> using UTF-8
        /// to decode the bytes.</returns>
        public override string ToString()
        {
            if (MemoryMarshal.TryGetArray(
                Bytes,
                out ArraySegment<byte> data))
            {
                return s_encoding.GetString(data.Array, data.Offset, data.Count);
            }
            return s_encoding.GetString(Bytes.ToArray());
        }

        /// <summary>
        /// Converts the <see cref="BinaryData"/> to a read-only stream.
        /// </summary>
        /// <returns>A stream representing the data.</returns>
        public Stream ToStream() =>
            new ReadOnlyMemoryStream(Bytes);

        /// <summary>
        /// Gets the <see cref="BinaryData"/> as <see cref="ReadOnlyMemory{Byte}"/>.
        /// </summary>
        /// <returns><see cref="BinaryData"/> as bytes.</returns>
        public ReadOnlyMemory<byte> ToBytes() =>
            Bytes;

        /// <summary>
        /// Converts the <see cref="BinaryData"/> to the specified type using
        /// the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data converted to the specified type.</returns>
        public T ToObject<T>(ObjectSerializer serializer, CancellationToken cancellationToken = default) =>
            ToObjectInternalAsync<T>(serializer, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Converts the <see cref="BinaryData"/> to the specified type using the
        /// <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data cast to the specified type. If the cast cannot
        ///be performed, an <see cref="InvalidCastException"/> will be
        ///thrown.</returns>
        public async ValueTask<T> ToObjectAsync<T>(CancellationToken cancellationToken = default) =>
            await ToObjectInternalAsync<T>(s_jsonSerializer, true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Converts the <see cref="BinaryData"/> to the specified type using the
        /// <see cref="JsonObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data converted to the specified type.</returns>
        public T ToObject<T>(CancellationToken cancellationToken = default) =>
            ToObjectInternalAsync<T>(s_jsonSerializer, false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Converts the <see cref="BinaryData"/> to the specified type using the
        /// provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        /// <returns>
        /// The data cast to the specified type. If the cast cannot
        /// be performed, an <see cref="InvalidCastException"/> will be
        /// thrown.
        /// </returns>
        public async ValueTask<T> ToObjectAsync<T>(ObjectSerializer serializer, CancellationToken cancellationToken = default) =>
            await ToObjectInternalAsync<T>(serializer, true, cancellationToken).ConfigureAwait(false);

        private async ValueTask<T> ToObjectInternalAsync<T>(
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
        /// Implicit conversion to bytes.
        /// </summary>
        /// <param name="data"></param>
        public static implicit operator ReadOnlyMemory<byte>(
            BinaryData data) =>
            data.Bytes;

        /// <summary>
        /// Two <see cref="BinaryData"/> objects are equal if the memory regions point to the same array and have the
        /// same length. The method does not check to see if the contents are equal.
        /// </summary>
        /// <param name="obj">The <see cref="BinaryData"/> to compare.</param>
        /// <returns>true if the current instance and other are equal; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object? obj)
        {
            if (obj is BinaryData data)
            {
                return data.Bytes.Equals(Bytes);
            }
            return false;
        }
        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() =>
            Bytes.GetHashCode();
    }
}
