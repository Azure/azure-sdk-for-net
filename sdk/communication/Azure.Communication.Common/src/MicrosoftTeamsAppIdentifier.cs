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
                    _rawId = $"{TeamsAppDodCloud}{AppId}";
                }
                else if (Cloud == CommunicationCloudEnvironment.Gcch)
                {
                    _rawId = $"{TeamsAppGcchCloud}{AppId}";
                }
                else
                {
                    _rawId = $"{TeamsAppPublicCloud}{AppId}";
                }

                return _rawId;
            }
        }

        /// <summary>The id of the Microsoft Teams Application.</summary>
        public string AppId { get; }

        /// <summary> The cloud that the application belongs to. </summary>
        public CommunicationCloudEnvironment Cloud { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MicrosoftTeamsAppIdentifier"/>.
        /// </summary>
        /// <param name="appId">The unique ID of the Microsoft Teams Application.</param>
        /// <param name="cloud">The cloud that the Microsoft Teams Application belongs to. A null value translates to the Public cloud.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="appId"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="appId"/> is empty.
        /// </exception>
        public MicrosoftTeamsAppIdentifier(string appId, CommunicationCloudEnvironment? cloud = null)
        {
            Argument.AssertNotNullOrEmpty(appId, nameof(appId));
            AppId = appId;
            Cloud = cloud ?? CommunicationCloudEnvironment.Public;
        }

        /// <inheritdoc />
        public override string ToString() => AppId;

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is MicrosoftTeamsAppIdentifier appIdentifier
            && appIdentifier.RawId == RawId;
    }
}
