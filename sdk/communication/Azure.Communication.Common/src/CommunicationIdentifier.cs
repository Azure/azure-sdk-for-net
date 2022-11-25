// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents an identifier in Azure Communication Services.</summary>
    public abstract class CommunicationIdentifier : IEquatable<CommunicationIdentifier>
    {
        internal const string TEAMS_USER_VISITOR_PREFIX = "8:teamsvisitor:";
        internal const string TEAMS_USER_ORGID_PREFIX = "8:orgid:";
        internal const string TEAMS_USER_DOD_PREFIX = "8:dod:";
        internal const string TEAMS_USER_GCCH_PREFIX = "8:gcch:";
        internal const string ACS_USER_ACS_PREFIX = "8:acs:";
        internal const string ACS_USER_SPOOL_PREFIX = "8:spool:";
        internal const string ACS_USER_GCCH_PREFIX = "8:gcch-acs:";
        internal const string ACS_USER_DOD_PREFIX = "8:dod-acs:";

        /// <summary>
        /// Returns the canonical string representation of the <see cref="CommunicationIdentifier"/>.
        /// You can use the <see cref="RawId"/> for encoding the identifier and then use it as a key in a database.
        /// </summary>
        public virtual string RawId { get; }

        /// <inheritdoc />
        public override int GetHashCode() => RawId.GetHashCode();

        /// <inheritdoc />
        public abstract bool Equals(CommunicationIdentifier other);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
            => obj is CommunicationIdentifier other && Equals(other);

        /// <summary>
        /// Overrides the equality operator.
        /// </summary>
        /// <param name="left">The first identifier to compare.</param>
        /// <param name="right">The second identifier to compare.</param>
        /// <returns>True if the types and <see cref="RawId"/> match.</returns>
        public static bool operator ==(CommunicationIdentifier left, CommunicationIdentifier right)
            => ReferenceEquals(left, right) || left is not null && right is not null && Equals(left, right);

        /// <summary>
        /// Overrides the non-equality operator.
        /// </summary>
        /// <param name="left">The first identifier to compare.</param>
        /// <param name="right">The second identifier to compare.</param>
        /// <returns>True if the types or <see cref="RawId"/> values are different.</returns>
        public static bool operator !=(CommunicationIdentifier left, CommunicationIdentifier right) => !(left == right);

        /// <summary>
        /// Creates a <see cref="CommunicationIdentifier"/> from a given rawId.
        /// When storing rawIds, use this function to restore the identifier that was encoded in the rawId.
        /// </summary>
        /// <param name="rawId">The rawId to be translated to its identifier representation.</param>
        /// <returns>Returns <see cref="CommunicationUserIdentifier"/>, <see cref="PhoneNumberIdentifier"/>, <see cref="MicrosoftTeamsUserIdentifier"/>, or <see cref="UnknownIdentifier"/> based on the identifier type.</returns>
        public static CommunicationIdentifier FromRawId(string rawId)
        {
            Argument.AssertNotNullOrEmpty(rawId, nameof(rawId));

            if (rawId.StartsWith("4:", StringComparison.OrdinalIgnoreCase))
            {
                return new PhoneNumberIdentifier(rawId.Substring("4:".Length));
            }

            var segments = rawId.Split(':');
            if (segments.Length < 3)
                return new UnknownIdentifier(rawId);

            var prefix = $"{segments[0]}:{segments[1]}:";
            var suffix = rawId.Substring(prefix.Length);

            return prefix switch
            {
                TEAMS_USER_VISITOR_PREFIX => new MicrosoftTeamsUserIdentifier(suffix, true),
                TEAMS_USER_ORGID_PREFIX => new MicrosoftTeamsUserIdentifier(suffix, false, CommunicationCloudEnvironment.Public),
                TEAMS_USER_DOD_PREFIX => new MicrosoftTeamsUserIdentifier(suffix, false, CommunicationCloudEnvironment.Dod),
                TEAMS_USER_GCCH_PREFIX => new MicrosoftTeamsUserIdentifier(suffix, false, CommunicationCloudEnvironment.Gcch),

                ACS_USER_ACS_PREFIX or
                ACS_USER_SPOOL_PREFIX or
                ACS_USER_GCCH_PREFIX or
                ACS_USER_DOD_PREFIX => new CommunicationUserIdentifier(rawId),

                _ => new UnknownIdentifier(rawId),
            };
        }
    }
}
