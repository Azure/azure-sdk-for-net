// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a user in Azure Communication Services.</summary>
    public class CommunicationUserIdentifier : CommunicationIdentifier
    {
        /// <summary>The id of the communication user.</summary>
        public string Id { get; }

        /// <summary>The cloud environment that the identifier belongs to.</summary>
        public CommunicationCloudEnvironment Cloud { get; }

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
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Id = id;
            Cloud = GetAcsCloudEnvironmentFromRawId(id);
        }

        /// <inheritdoc />
        public override string ToString() => Id;

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is CommunicationUserIdentifier otherId && otherId.RawId == RawId;

        private static CommunicationCloudEnvironment GetAcsCloudEnvironmentFromRawId(string rawId)
        {
            var segments = rawId.Split(':');

            if (segments.Length < 2)
            {
                return CommunicationCloudEnvironment.Public;
            }

            var cloudEnvironment = segments[1];

            return cloudEnvironment switch
            {
                "acs" or "spool" => CommunicationCloudEnvironment.Public,
                "gcch-acs" => CommunicationCloudEnvironment.Gcch,
                _ => CommunicationCloudEnvironment.Public,
            };
        }
    }
}
