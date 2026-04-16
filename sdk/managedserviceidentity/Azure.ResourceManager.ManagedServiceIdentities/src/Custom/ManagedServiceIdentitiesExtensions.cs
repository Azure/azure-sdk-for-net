// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: The pre-migration SDK generated GetSystemAssignedIdentity(this ArmResource)
// via the autorest generate-arm-resource-extensions directive. This extension method is retained
// so callers can get the system-assigned identity for any resource scope.

using Azure.ResourceManager;
using Azure.ResourceManager.ManagedServiceIdentities.Mocking;

namespace Azure.ResourceManager.ManagedServiceIdentities
{
    public static partial class ManagedServiceIdentitiesExtensions
    {
        private static MockableManagedServiceIdentitiesArmResource GetMockableManagedServiceIdentitiesArmResource(ArmResource resource)
        {
            return resource.GetCachedClient(client => new MockableManagedServiceIdentitiesArmResource(client, resource.Id));
        }

        /// <summary>
        /// Gets an object representing a <see cref="SystemAssignedIdentityResource"/> along with the instance operations
        /// that can be performed on it in the ArmResource scope.
        /// </summary>
        /// <param name="armResource"> The <see cref="ArmResource"/> instance the method will execute against. </param>
        /// <returns> Returns a <see cref="SystemAssignedIdentityResource"/> object. </returns>
        public static SystemAssignedIdentityResource GetSystemAssignedIdentity(this ArmResource armResource)
        {
            return GetMockableManagedServiceIdentitiesArmResource(armResource).GetSystemAssignedIdentity();
        }
    }
}
