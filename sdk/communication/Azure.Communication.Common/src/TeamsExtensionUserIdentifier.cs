// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary> A Microsoft Teams Phone user who is using a Communication Services resource to extend their Teams Phone set up. </summary>
    public class TeamsExtensionUserIdentifier : CommunicationIdentifier
    {
        private string _rawId;

        /// <summary>
        /// Returns the canonical string representation of the <see cref="TeamsExtensionUserIdentifier"/>.
        /// You can use the <see cref="RawId"/> for encoding the identifier and then use it as a key in a database.
        /// </summary>
        public override string RawId
        {
            get
            {
                if (_rawId == null)
                {
                    if (Cloud == CommunicationCloudEnvironment.Dod)
                    {
                        _rawId = $"{AcsUserDodCloud}{ResourceId}_{TenantId}_{UserId}";
                    }
                    else if (Cloud == CommunicationCloudEnvironment.Gcch)
                    {
                        _rawId = $"{AcsUserGcchCloud}{ResourceId}_{TenantId}_{UserId}";
                    }
                    else
                    {
                        _rawId = $"{AcsUser}{ResourceId}_{TenantId}_{UserId}";
                    }
                }
                return _rawId;
            }
        }

        /// <summary> The Id of the Microsoft Teams Extension user, i.e. the Entra ID object Id of the user. </summary>
        public string UserId { get; }

        /// <summary> The tenant Id of the Microsoft Teams Extension user. </summary>
        public string TenantId { get; }

        /// <summary> The Communication Services resource Id. </summary>
        public string ResourceId { get; }

        /// <summary> The cloud that the identifier belongs to. </summary>
        public CommunicationCloudEnvironment Cloud { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="TeamsExtensionUserIdentifier"/>.
        /// </summary>
        /// <param name="userId"> The Id of the Microsoft Teams Extension user, i.e. the Entra ID object Id of the user. </param>
        /// <param name="tenantId"> The tenant Id of the Microsoft Teams Extension user. </param>
        /// <param name="resourceId"> The Communication Services resource Id. </param>
        /// <param name="cloud"> The cloud that the Microsoft Teams Extension user belongs to. By default 'public' if missing. </param>
        /// <param name="rawId"> Raw id of the Microsoft Teams user, optional. </param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when any of <paramref name="userId"/>, <paramref name="tenantId"/>, <paramref name="resourceId"/> are null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when any of <paramref name="userId"/>, <paramref name="tenantId"/>, <paramref name="resourceId"/> are empty.
        /// </exception>
        /// /// <exception cref="System.FormatException">
        /// Thrown when any of <paramref name="userId"/>, <paramref name="tenantId"/>, <paramref name="resourceId"/> are not in valid Guid format D.
        /// </exception>
        public TeamsExtensionUserIdentifier(string userId, string tenantId, string resourceId, CommunicationCloudEnvironment? cloud = null, string rawId = null)
        {
            Argument.AssertNotNullOrEmpty(userId, nameof(userId));
            Argument.AssertNotNullOrEmpty(tenantId, nameof(tenantId));
            Argument.AssertNotNullOrEmpty(resourceId, nameof(resourceId));

            // think whether making them GUIDs is a good idea
            UserId = userId;
            TenantId = tenantId;
            ResourceId = resourceId;
            Cloud = cloud ?? CommunicationCloudEnvironment.Public;
            _rawId = rawId;
        }

        /// <inheritdoc />
        public override string ToString() => RawId;

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is TeamsExtensionUserIdentifier otherId
            && otherId.RawId == RawId;
    }
}
