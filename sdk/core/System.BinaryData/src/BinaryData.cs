// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace System
{
    /// <summary>
    /// A lightweight abstraction for a payload of bytes that supports converting between string, stream, Json, and bytes.
    /// </summary>
    public class BinaryData
    {
        private const int CopyToBufferSize = 81920;

        private static readonly UTF8Encoding s_encoding = new UTF8Encoding(false);

        /// <summary>
        /// The backing store for the <see cref="BinaryData"/> instance.
        /// </summary>
        internal ReadOnlyMemory<byte> Bytes { get; }

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
        /// using <see cref="JsonSerializer"/>.
        /// </summary>
        ///
        /// <param name="jsonSerializable">The object that will be serialized to Json using
        /// <see cref="JsonSerializer"/>.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> to use when serializing to Json.</param>
        /// <param name="type">The type of the data. If not specified, <see cref="object.GetType"/> will
        /// be used to determine the type.</param>
        ///
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public BinaryData(object jsonSerializable, JsonSerializerOptions? options = default, Type? type = default)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            Bytes = JsonSerializer.SerializeToUtf8Bytes(jsonSerializable, type, options);
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
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (stream.CanSeek && stream.Length > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(stream),
                    "Stream length must be less than Int32.MaxValue");
            }
            using var memoryStream = new MemoryStream();
            if (async)
            {
                await stream.CopyToAsync(memoryStream, CopyToBufferSize, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                stream.CopyTo(memoryStream);
            }
            return new BinaryData(memoryStream.GetBuffer().AsMemory(0, (int) memoryStream.Position));
        }


        /// <summary>
        /// Creates a <see cref="BinaryData"/> instance by serializing the passed in object using
        /// the <see cref="JsonSerializer"/>.
        /// </summary>
        ///
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="jsonSerializable">The data to use.</param>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> to use when serializing to Json.</param>
        ///
        /// <returns>A <see cref="BinaryData"/> instance.</returns>
        [Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0014:Avoid using banned types in public API", Justification = "<Pending>")]
        public static BinaryData FromObjectAsJson<T>(
            T jsonSerializable,
            JsonSerializerOptions? options = default)
        {
            using var memoryStream = new MemoryStream();
            var buffer = JsonSerializer.SerializeToUtf8Bytes(jsonSerializable, typeof(T), options);
            memoryStream.Write(buffer, 0, buffer.Length);
            return new BinaryData(memoryStream.GetBuffer().AsMemory(0, (int) memoryStream.Position));
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
        /// <see cref="JsonSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="options">The <see cref="JsonSerializerOptions"/> to use when serializing to Json.</param>
        /// <returns>The data converted to the specified type.</returns>
#pragma warning disable AZC0014 // Avoid using banned types in public API
        public T ToObjectFromJson<T>(JsonSerializerOptions? options = default)
#pragma warning restore AZC0014 // Avoid using banned types in public API
        {
            using var memoryStream = new MemoryStream();
            ToStream().CopyTo(memoryStream);
            return (T) JsonSerializer.Deserialize(memoryStream.ToArray(), typeof(T), options);

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
