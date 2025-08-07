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
        internal const string Phone = "4:";
        internal const string TeamsAppPublicCloud = "28:orgid:";
        internal const string TeamsAppDodCloud = "28:dod:";
        internal const string TeamsAppGcchCloud = "28:gcch:";
        internal const string TeamUserAnonymous = "8:teamsvisitor:";
        internal const string TeamUserPublicCloud = "8:orgid:";
        internal const string TeamUserDodCloud = "8:dod:";
        internal const string TeamUserGcchCloud = "8:gcch:";
        internal const string AcsUser = "8:acs:";
        internal const string AcsUserDodCloud = "8:dod-acs:";
        internal const string AcsUserGcchCloud = "8:gcch-acs:";
        internal const string SpoolUser = "8:spool:";

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
        /// <returns>Returns <see cref="CommunicationUserIdentifier"/>, <see cref="PhoneNumberIdentifier"/>, <see cref="MicrosoftTeamsUserIdentifier"/>, <see cref="MicrosoftTeamsAppIdentifier"/>, or <see cref="UnknownIdentifier"/> based on the identifier type.</returns>
        public static CommunicationIdentifier FromRawId(string rawId)
        {
            Argument.AssertNotNullOrEmpty(rawId, nameof(rawId));

            if (rawId.StartsWith(Phone, StringComparison.OrdinalIgnoreCase))
            {
                return new PhoneNumberIdentifier(rawId.Substring(Phone.Length));
            }

            var segments = rawId.Split(':');
            if (segments.Length != 3)
            {
                return new UnknownIdentifier(rawId);
            }

            var prefix = $"{segments[0]}:{segments[1]}:";
            var suffix = segments[2];

            return prefix switch
            {
                TeamUserAnonymous => new MicrosoftTeamsUserIdentifier(suffix, true),
                TeamUserPublicCloud => new MicrosoftTeamsUserIdentifier(suffix, false, CommunicationCloudEnvironment.Public),
                TeamUserDodCloud => new MicrosoftTeamsUserIdentifier(suffix, false, CommunicationCloudEnvironment.Dod),
                TeamUserGcchCloud => new MicrosoftTeamsUserIdentifier(suffix, false, CommunicationCloudEnvironment.Gcch),
                SpoolUser => new CommunicationUserIdentifier(rawId),
                AcsUser or AcsUserDodCloud or AcsUserGcchCloud => (CommunicationIdentifier)TryCreateTeamsExtensionUser(prefix, suffix) ?? new CommunicationUserIdentifier(rawId),
                TeamsAppPublicCloud => new MicrosoftTeamsAppIdentifier(suffix, CommunicationCloudEnvironment.Public),
                TeamsAppGcchCloud => new MicrosoftTeamsAppIdentifier(suffix, CommunicationCloudEnvironment.Gcch),
                TeamsAppDodCloud => new MicrosoftTeamsAppIdentifier(suffix, CommunicationCloudEnvironment.Dod),
                _ => new UnknownIdentifier(rawId),
            };
        }

        private static TeamsExtensionUserIdentifier TryCreateTeamsExtensionUser(string prefix, string suffix)
        {
            var segments = suffix.Split('_');
            if (segments.Length != 3)
            {
                return null;
            }
            var resourceId = segments[0];
            var tenantId = segments[1];
            var userId = segments[2];
            var cloud = prefix switch
            {
                AcsUser => CommunicationCloudEnvironment.Public,
                AcsUserDodCloud => CommunicationCloudEnvironment.Dod,
                AcsUserGcchCloud => CommunicationCloudEnvironment.Gcch,
                _ => throw new ArgumentException($"Invalid prefix {prefix} for TeamsExtensionUserIdentifier")
            };
            return new TeamsExtensionUserIdentifier(userId, tenantId, resourceId, cloud);
        }
    }
}
