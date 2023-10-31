// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a Microsoft Teams Application.</summary>
    public class MicrosoftTeamsAppIdentifier : CommunicationIdentifier
    {
        private string _rawId;

        /// <summary>
        /// Returns the canonical string representation of the <see cref="MicrosoftTeamsAppIdentifier"/>.
        /// You can use the <see cref="RawId"/> for encoding the identifier and then use it as a key in a database.
        /// </summary>
        public override string RawId
        {
            get
            {
                if (_rawId != null)
                    return _rawId;

                if (Cloud == CommunicationCloudEnvironment.Dod)
                {
                    _rawId = $"{TeamsAppDodCloud}{TeamsAppId}";
                }
                else if (Cloud == CommunicationCloudEnvironment.Gcch)
                {
                    _rawId = $"{TeamsAppGcchCloud}{TeamsAppId}";
                }
                else
                {
                    _rawId = $"{TeamsAppPublicCloud}{TeamsAppId}";
                }

                return _rawId;
            }
        }

        /// <summary>The id of the Microsoft Teams Application.</summary>
        public string TeamsAppId { get; }

        /// <summary> The cloud that the application belongs to. </summary>
        public CommunicationCloudEnvironment Cloud { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MicrosoftTeamsAppIdentifier"/>.
        /// </summary>
        /// <param name="teamsAppId">The unique ID of the Microsoft Teams Application.</param>
        /// <param name="cloud">The cloud that the Microsoft Teams Application belongs to. A null value translates to the Public cloud.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="teamsAppId"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="teamsAppId"/> is empty.
        /// </exception>
        public MicrosoftTeamsAppIdentifier(string teamsAppId, CommunicationCloudEnvironment? cloud = null)
        {
            Argument.AssertNotNullOrEmpty(teamsAppId, nameof(teamsAppId));
            TeamsAppId = teamsAppId;
            Cloud = cloud ?? CommunicationCloudEnvironment.Public;
        }

        /// <inheritdoc />
        public override string ToString() => TeamsAppId;

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is MicrosoftTeamsAppIdentifier appIdentifier
            && appIdentifier.RawId == RawId;
    }
}
