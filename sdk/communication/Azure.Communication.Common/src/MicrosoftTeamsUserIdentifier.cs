// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a Microsoft Teams user.</summary>
    public class MicrosoftTeamsUserIdentifier : CommunicationIdentifier
    {
        /// <summary>The id of the Microsoft Teams user. If the user isn't anonymous, the id is the AAD object id of the user.</summary>
        public string Id { get; }

        /// <summary>True if the user is anonymous, for example when joining a meeting with a share link.</summary>
        public bool IsAnonymous { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MicrosoftTeamsUserIdentifier"/>.
        /// </summary>
        /// <param name="userId">Id of the Microsoft Teams user. If the user isn't anonymous, the id is the AAD object id of the user.</param>
        /// <param name="isAnonymous">Set this to true if the user is anonymous, for example when joining a meeting with a share link.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="userId"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="userId"/> is empty.
        /// </exception>
        public MicrosoftTeamsUserIdentifier(string userId, bool isAnonymous = false)
        {
            Argument.AssertNotNullOrEmpty(userId, nameof(userId));
            Id = userId;
            IsAnonymous = isAnonymous;
        }
    }
}
