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
        /// <param name="id">The client ID of the user-assigned managed identity.</param>
        public static ManagedIdentityId FromUserAssignedClientId(string id) =>
            new ManagedIdentityId(ManagedIdentityIdType.ClientId, id);

        /// <summary>
        /// Create an instance of <see cref="ManagedIdentityId"/> for a user-assigned managed identity.
        /// </summary>
        /// <param name="id">The resource ID of the user-assigned managed identity.</param>
        public static ManagedIdentityId FromUserAssignedResourceId(ResourceIdentifier id) =>
            new ManagedIdentityId(ManagedIdentityIdType.ResourceId, id.ToString());

        /// <summary>
        /// Create an instance of <see cref="ManagedIdentityId"/> for a user-assigned managed identity.
        /// </summary>
        /// <param name="id">The object ID of the user-assigned managed identity.</param>
        public static ManagedIdentityId FromUserAssignedObjectId(string id) =>
            new ManagedIdentityId(ManagedIdentityIdType.ObjectId, id);

        /// <summary>
        /// Returns the string representation of the <see cref="ManagedIdentityId"/>.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _idType switch
            {
                ManagedIdentityIdType.SystemAssigned => "SystemAssigned",
                _ => $"{_idType} {_userAssignedId}",
            };
        }
    }

    internal enum ManagedIdentityIdType
    {
        SystemAssigned,
        ClientId,
        ResourceId,
        ObjectId
    }
}
