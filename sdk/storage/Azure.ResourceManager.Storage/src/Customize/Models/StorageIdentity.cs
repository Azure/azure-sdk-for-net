// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageIdentity
    {
        /// <summary>
        /// Converts an ARM <see cref="ManagedServiceIdentity"/> to a <see cref="StorageIdentity"/>.
        /// Used by backward-compat factory methods that accept the ARM common type.
        /// </summary>
        public static implicit operator StorageIdentity(ManagedServiceIdentity source)
        {
            if (source == null)
                return null;

            var userAssigned = new Dictionary<string, StorageUserAssignedIdentity>();
            if (source.UserAssignedIdentities != null)
            {
                foreach (var kvp in source.UserAssignedIdentities)
                {
                    userAssigned[kvp.Key.ToString()] = new StorageUserAssignedIdentity(
                        kvp.Value?.PrincipalId?.ToString(),
                        kvp.Value?.ClientId?.ToString(),
                        null);
                }
            }

            return new StorageIdentity(
                source.PrincipalId?.ToString(),
                source.TenantId?.ToString(),
                new StorageIdentityType(source.ManagedServiceIdentityType.ToString()),
                userAssigned,
                null);
        }
    }
}
