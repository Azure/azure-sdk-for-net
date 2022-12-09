// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary> The server call locator. </summary>
    public class ServerCallLocator : CallLocator
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ServerCallLocator"/>.
        /// </summary>
        /// <param name="id">The server call id.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="id"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="id"/> is empty.
        /// </exception>
        public ServerCallLocator(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Id = id;
        }

        /// <inheritdoc />
        public override string ToString() => Id;

        /// <inheritdoc />
        public override int GetHashCode() => Id.GetHashCode();

        /// <inheritdoc />
        public override bool Equals(CallLocator other)
            => other is ServerCallLocator otherId && otherId.Id == Id;
    }
}
