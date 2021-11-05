// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Serialization;

namespace Azure
{
    /// <summary>
    /// Extensions that can be used for serialization.
    /// </summary>
    public static class AzureCoreExtensions
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
    }
}
