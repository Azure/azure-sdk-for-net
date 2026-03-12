// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Linq;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageIdentity
    {
        /// <summary> Converts a <see cref="ManagedServiceIdentity"/> to <see cref="StorageIdentity"/>. </summary>
        public static implicit operator StorageIdentity(ManagedServiceIdentity identity)
        {
            if (identity == null)
                return null;

            StorageIdentityType storageIdentityType;
            if (identity.ManagedServiceIdentityType == ManagedServiceIdentityType.SystemAssigned)
                storageIdentityType = StorageIdentityType.SystemAssigned;
            else if (identity.ManagedServiceIdentityType == ManagedServiceIdentityType.UserAssigned)
                storageIdentityType = StorageIdentityType.UserAssigned;
            else if (identity.ManagedServiceIdentityType == ManagedServiceIdentityType.SystemAssignedUserAssigned)
                storageIdentityType = StorageIdentityType.SystemAssignedUserAssigned;
            else
                storageIdentityType = StorageIdentityType.None;

            var result = new StorageIdentity(storageIdentityType);
            if (identity.UserAssignedIdentities != null)
            {
                foreach (var kvp in identity.UserAssignedIdentities)
                {
                    result.UserAssignedIdentities[kvp.Key] = new StorageUserAssignedIdentity();
                }
            }
            return result;
        }
    }
}
