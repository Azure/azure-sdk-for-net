// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a calling application.</summary>
    public class CallingApplication : CommunicationIdentifier
    {
        /// <summary>The id of the application.</summary>
        public string Id { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="CallingApplication"/>.
        /// </summary>
        /// <param name="id">Id of the calling application.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="id"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="id"/> is empty.
        /// </exception>
        public CallingApplication(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Id = id;
        }
    }
}
