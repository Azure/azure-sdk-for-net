// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: The pre-migration SDK generated MockableManagedServiceIdentitiesArmResource
// via the autorest generate-arm-resource-extensions directive. This provides GetSystemAssignedIdentity
// on any ArmResource scope (e.g., a VM, subscription, or resource group).

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ManagedServiceIdentities.Mocking
{
    /// <summary> A class to add extension methods to <see cref="ArmResource"/>. </summary>
    public partial class MockableManagedServiceIdentitiesArmResource : ArmResource
    {
        /// <summary> Initializes a new instance of MockableManagedServiceIdentitiesArmResource for mocking. </summary>
        protected MockableManagedServiceIdentitiesArmResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MockableManagedServiceIdentitiesArmResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockableManagedServiceIdentitiesArmResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary>
        /// Gets an object representing a <see cref="SystemAssignedIdentityResource"/> along with the instance operations
        /// that can be performed on it in the ArmResource scope.
        /// </summary>
        /// <returns> Returns a <see cref="SystemAssignedIdentityResource"/> object. </returns>
        public virtual SystemAssignedIdentityResource GetSystemAssignedIdentity()
        {
            return new SystemAssignedIdentityResource(Client, Id.AppendProviderResource("Microsoft.ManagedIdentity", "identities", "default"));
        }
    }
}
