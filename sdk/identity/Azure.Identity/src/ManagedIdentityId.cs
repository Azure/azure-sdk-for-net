// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Identity
{
    /// <summary>
    /// Defines the configuration for a managed identity enabled on a resource.
    /// </summary>
    public class ManagedIdentityId
    {
        internal string _userAssignedId;
        internal ManagedIdentityIdType _idType;

        private ManagedIdentityId(ManagedIdentityIdType idType, string userAssignedId = null)
        {
            _idType = idType;
            _userAssignedId = userAssignedId;
        }

        /// <summary>
        /// Create an instance of <see cref="ManagedIdentityId"/> for a system-assigned managed identity.
        /// </summary>
        public static ManagedIdentityId SystemAssigned =>
            new ManagedIdentityId(ManagedIdentityIdType.SystemAssigned);

        /// <summary>
        /// Create an instance of <see cref="ManagedIdentityId"/> for a user-assigned managed identity.
        /// </summary>
        /// <param name="clientId">The client ID of the user-assigned managed identity.</param>
        public static ManagedIdentityId FromUserAssignedClientId(string clientId) =>
            new ManagedIdentityId(ManagedIdentityIdType.ClientId, clientId);

        /// <summary>
        /// Create an instance of <see cref="ManagedIdentityId"/> for a user-assigned managed identity.
        /// </summary>
        /// <param name="resourceIdentifier">The resource identifier of the user-assigned managed identity.</param>
        public static ManagedIdentityId FromUserAssignedResourceId(ResourceIdentifier resourceIdentifier) =>
            new ManagedIdentityId(ManagedIdentityIdType.ResourceId, resourceIdentifier.ToString());

        /// <summary>
        /// Create an instance of <see cref="ManagedIdentityId"/> for a user-assigned managed identity.
        /// </summary>
        /// <param name="objectId">The object ID of the user-assigned managed identity.</param>
        public static ManagedIdentityId FromUserAssignedObjectId(string objectId) =>
            new ManagedIdentityId(ManagedIdentityIdType.ObjectId, objectId);
    }

    internal enum ManagedIdentityIdType
    {
        SystemAssigned,
        ClientId,
        ResourceId,
        ObjectId
    }
}
