// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a Microsoft Teams user.</summary>
    public class MicrosoftTeamsUserIdentifier : CommunicationIdentifier
    {
        /// <summary>The optional raw id of the Microsoft Teams User identifier.</summary>
        public string RawId { get; }

        /// <summary>The id of the Microsoft Teams user. If the user isn't anonymous, the id is the AAD object id of the user.</summary>
        public string UserId { get; }

        /// <summary>True if the user is anonymous, for example when joining a meeting with a share link.</summary>
        public bool IsAnonymous { get; }

        /// <summary> The cloud that the identifier belongs to. </summary>
        public CommunicationCloudEnvironment Cloud { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MicrosoftTeamsUserIdentifier"/>.
        /// </summary>
        /// <param name="userId">Id of the Microsoft Teams user. If the user isn't anonymous, the id is the AAD object id of the user.</param>
        /// <param name="isAnonymous">Set this to true if the user is anonymous, for example when joining a meeting with a share link.</param>
        /// <param name="cloud">The cloud that the Microsoft Team user belongs to. A null value translates to the Public cloud.</param>
        /// <param name="rawId">Raw id of the Microsoft Teams user, optional.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="userId"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="userId"/> is empty.
        /// </exception>
        public MicrosoftTeamsUserIdentifier(string userId, bool isAnonymous = false, CommunicationCloudEnvironment? cloud = null, string rawId = null)
        {
            Argument.AssertNotNullOrEmpty(userId, nameof(userId));
            UserId = userId;
            IsAnonymous = isAnonymous;
            Cloud = cloud ?? CommunicationCloudEnvironment.Public;
            RawId = rawId;
        }

        /// <inheritdoc />
        public override string ToString() => UserId;

        /// <inheritdoc />
        public override int GetHashCode() => UserId.GetHashCode();

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is MicrosoftTeamsUserIdentifier otherId
            && otherId.UserId == UserId
            && otherId.IsAnonymous == IsAnonymous
            && otherId.Cloud == Cloud
            && (RawId is null || otherId.RawId is null || RawId == otherId.RawId);
    }
}
