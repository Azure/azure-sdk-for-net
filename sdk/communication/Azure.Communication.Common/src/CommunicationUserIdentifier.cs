﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a user in Azure Communication Services.</summary>
    public class CommunicationUserIdentifier : CommunicationIdentifier
    {
        /// <summary>The id of the communication user.</summary>
        public string Id { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="CommunicationUserIdentifier"/>.
        /// </summary>
        /// <param name="id">Id of the communication user.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="id"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="id"/> is empty.
        /// </exception>
        public CommunicationUserIdentifier(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Id = id;
        }

        /// <inheritdoc />
        public override string ToString() => Id;

        /// <inheritdoc />
        public override int GetHashCode() => Id.GetHashCode();

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is CommunicationUserIdentifier otherId && otherId.Id == Id;
    }
}
