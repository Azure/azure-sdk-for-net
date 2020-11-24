// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// An abstraction for reading typed objects.
    /// </summary>
    public abstract class ObjectSerializer
    {
        /// <summary>
        /// Convert the provided value to it's binary representation and write it to <see cref="System.IO.Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="System.IO.Stream"/> to write to.</param>
        /// <param name="value">The value to convert.</param>
        /// <param name="inputType">The type of the <paramref name="value"/> to convert.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        public abstract void Serialize(Stream stream, object? value, Type inputType, CancellationToken cancellationToken);

        /// <summary>
        /// Convert the provided value to it's binary representation and write it to <see cref="System.IO.Stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="System.IO.Stream"/> to write to.</param>
        /// <param name="value">The value to convert.</param>
        /// <param name="inputType">The type of the <paramref name="value"/> to convert.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during serialization.</param>
        public abstract ValueTask SerializeAsync(Stream stream, object? value, Type inputType, CancellationToken cancellationToken);

        /// <summary>
        /// Read the binary representation into a <paramref name="returnType"/>.
        /// The Stream will be read to completion.
        /// </summary>
        /// <param name="stream">The <see cref="System.IO.Stream"/> to read from.</param>
        /// <param name="returnType">The type of the object to convert to and return.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        public abstract object? Deserialize(Stream stream, Type returnType, CancellationToken cancellationToken);

        /// <summary>
        /// Read the binary representation into a <paramref name="returnType"/>.
        /// The Stream will be read to completion.
        /// </summary>
        /// <param name="stream">The <see cref="System.IO.Stream"/> to read from.</param>
        /// <param name="returnType">The type of the object to convert to and return.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> to use during deserialization.</param>
        public abstract ValueTask<object?> DeserializeAsync(Stream stream, Type returnType, CancellationToken cancellationToken);
    }
}
