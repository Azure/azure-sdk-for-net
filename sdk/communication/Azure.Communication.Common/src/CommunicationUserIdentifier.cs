// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication
{
    /// <summary>Represents a user in Azure Communication Services.</summary>
    public class CommunicationUserIdentifier : CommunicationIdentifier
    {
        /// <summary>The id of the communication user.</summary>
        public string Id { get; }

        /// <summary>
        /// Returns the canonical string representation of the <see cref="CommunicationUserIdentifier"/>.
        /// You can use the <see cref="RawId"/> for encoding the identifier and then use it as a key in a database.
        /// </summary>
        public override string RawId => Id;

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
            if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}
			if (id.Length == 0)
			{
				throw new ArgumentException("Value cannot be an empty string.", nameof(id));
			}
            Id = id;
        }

        /// <inheritdoc />
        public override string ToString() => Id;

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is CommunicationUserIdentifier otherId && otherId.RawId == RawId;
    }
}
