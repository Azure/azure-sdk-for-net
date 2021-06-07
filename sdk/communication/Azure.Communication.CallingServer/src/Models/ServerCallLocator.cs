// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The locator used for joining call using server call id provided by client.
    /// </summary>
    public class ServerCallLocator : CallLocator
    {
        /// <summary>The id of the server call locator.</summary>
        public string Id { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="ServerCallLocator"/>.
        /// </summary>
        /// <param name="id">Id of the server call locator.</param>
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
    }
}
