// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// A set of extension methods that can be used to access the payload
    /// of <see cref="BinaryData"/>.
    /// </summary>
    public static class BinaryDataExtensions
    {
        /// <summary>
        /// Converts the BinaryData to a string using UTF-8.
        /// </summary>
        /// <param name="data">The BinaryData instance.</param>
        /// <returns>The string representation of the data.</returns>
        public static string AsString(this BinaryData data) =>
           data.AsString(Encoding.UTF8);

        /// <summary>
        /// Converts the BinaryData to a string using the specified
        /// encoding.
        /// </summary>
        /// <param name="data">The BinaryData instance.</param>
        /// <param name="encoding">The encoding to use when decoding
        /// the bytes.</param>
        /// <returns>The string representation of the data.</returns>
        public static string AsString(
            this BinaryData data,
            Encoding encoding)
        {
            Argument.AssertNotNull(encoding, nameof(encoding));
            return encoding.GetString(data.Data.ToArray());
        }

        /// <summary>
        /// Converts the BinaryData to bytes.
        /// </summary>
        /// <param name="data">The BinaryData instance.</param>
        /// <returns>The data as bytes.</returns>
        public static ReadOnlyMemory<byte> AsBytes(
            this BinaryData data) =>
            data.Data;

        /// <summary>
        /// Converts the BinaryData to a stream.
        /// </summary>
        /// <param name="data">The BinaryData instance.</param>
        /// <returns>A stream representing the data.</returns>
        public static Stream AsStream(this BinaryData data) =>
            new MemoryStream(data.Data.ToArray());

        /// <summary>
        /// Converts the BinaryData to the specified type.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="data">The BinaryData instance.</param>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        ///<returns>The data converted to the specified type.</returns>
        public static T As<T>(
            this BinaryData data,
            ObjectSerializer serializer) =>
            data.AsAsync<T>(serializer, false).EnsureCompleted();

        /// <summary>
        /// Converts the BinaryData to the specified type.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="data">The BinaryData instance.</param>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        ///<returns>The data cast to the specified type. If the cast cannot
        ///be performed, an <see cref="InvalidCastException"/> will be
        ///thrown.</returns>
        public static async ValueTask<T> AsAsync<T>(
            this BinaryData data,
            ObjectSerializer serializer) =>
            await data.AsAsync<T>(serializer, true).ConfigureAwait(false);

        private static async ValueTask<T> AsAsync<T>(
            this BinaryData data,
            ObjectSerializer serializer,
            bool async)
        {
            Argument.AssertNotNull(serializer, nameof(serializer));
            if (async)
            {
                return (T)await serializer.DeserializeAsync(
                    data.AsStream(),
                    typeof(T))
                    .ConfigureAwait(false);
            }
            else
            {
                return (T)serializer.Deserialize(data.AsStream(), typeof(T));
            }
        }
    }
}
