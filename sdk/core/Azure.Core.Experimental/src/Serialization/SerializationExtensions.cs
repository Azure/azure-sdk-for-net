// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

namespace Azure
{
    /// <summary>
    /// Extensions that can be used for serialization.
    /// </summary>
    public static class SerializationExtensions
    {
        /// <summary>
        /// Converts the <see cref="BinaryData"/> to the specified type using
        /// the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="data">The <see cref="BinaryData"/> instance to convert.</param>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data converted to the specified type.</returns>
        public static T? ToObject<T>(this BinaryData data, ObjectSerializer serializer, CancellationToken cancellationToken = default) =>
            (T?)serializer.Deserialize(data.ToStream(), typeof(T), cancellationToken);

        /// <summary>
        /// Converts the <see cref="BinaryData"/> to the specified type using
        /// the provided <see cref="ObjectSerializer"/>.
        /// </summary>
        /// <typeparam name="T">The type that the data should be
        /// converted to.</typeparam>
        /// <param name="data">The <see cref="BinaryData"/> instance to convert.</param>
        /// <param name="serializer">The serializer to use
        /// when deserializing the data.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        ///<returns>The data converted to the specified type.</returns>
        public static async ValueTask<T?> ToObjectAsync<T>(this BinaryData data, ObjectSerializer serializer, CancellationToken cancellationToken = default) =>
            (T?)await serializer.DeserializeAsync(data.ToStream(), typeof(T), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Convert the provided value to it's binary representation and return it as a <see cref="BinaryData"/> instance.
        /// </summary>
        /// <param name="serializer">The serializer to use when creating the <see cref="BinaryData"/> instance.</param>
        /// <param name="value">The value to convert.</param>
        /// <param name="inputType">The type to use when serializing <paramref name="value"/>. If omitted, the type will be determined using <see cref="object.GetType"/>().</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        /// <returns>The object's binary representation as <see cref="BinaryData"/>.</returns>
        public static BinaryData SerializeToBinaryData(this ObjectSerializer serializer, object? value, Type? inputType = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(serializer, nameof(serializer));
            return SerializeToBinaryDataInternalAsync(serializer, value, inputType, false, cancellationToken).EnsureCompleted();
        }

        /// <summary>
        /// Convert the provided value to it's binary representation and return it as a <see cref="BinaryData"/> instance.
        /// </summary>
        /// <param name="serializer">The serializer to use when creating the <see cref="BinaryData"/> instance.</param>
        /// <param name="value">The value to convert.</param>
        /// <param name="inputType">The type to use when serializing <paramref name="value"/>. If omitted, the type will be determined using <see cref="object.GetType"/>().</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        /// <returns>The object's binary representation as <see cref="BinaryData"/>.</returns>
        public static async ValueTask<BinaryData> SerializeToBinaryDataAsync(this ObjectSerializer serializer, object? value, Type? inputType = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(serializer, nameof(serializer));
            return await SerializeToBinaryDataInternalAsync(serializer, value, inputType, true, cancellationToken).ConfigureAwait(false);
        }

        private static async ValueTask<BinaryData> SerializeToBinaryDataInternalAsync(ObjectSerializer serializer, object? value, Type? inputType, bool async, CancellationToken cancellationToken)
        {
            using var stream = new MemoryStream();
            inputType ??= value?.GetType() ?? typeof(object);
            if (async)
            {
                await serializer.SerializeAsync(stream, value, inputType, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                serializer.Serialize(stream, value, inputType, cancellationToken);
            }
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int) stream.Position));
        }
    }
}
