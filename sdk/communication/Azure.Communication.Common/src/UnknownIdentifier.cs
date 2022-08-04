// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents an identifier of an unknown type. It will be encountered in communications with endpoints that are not identifiable by this version of the SDK.</summary>
    public class UnknownIdentifier : CommunicationIdentifier
    {
        /// <summary>The id of the endpoint.</summary>
        public string Id { get; }

        /// <inheritdoc />
        public override string RawId => Id;

        /// <summary>
        /// Initializes a new instance of <see cref="UnknownIdentifier"/>.
        /// </summary>
        /// <param name="id">Id of the endpoint.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="id"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="id"/> is empty.
        /// </exception>
        public UnknownIdentifier(string id)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Id = id;
        }

        /// <inheritdoc />
        public override string ToString() => Id;

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is UnknownIdentifier otherId && otherId.RawId == RawId;
    }
}
