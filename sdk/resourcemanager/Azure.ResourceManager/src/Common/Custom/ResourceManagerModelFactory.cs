// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Models
{
    /// <summary> Model factory for read-only models. </summary>
    public static partial class ResourceManagerModelFactory
    {
        /// <summary> Initializes a new instance of LocationExpanded. </summary>
        /// <param name="principalId"> The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. </param>
        /// <param name="tenantId"> The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. </param>
        /// <param name="managedServiceIdentityType"> Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed). </param>
        /// <param name="userAssignedIdentities"> The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: &apos;/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests. </param>
        /// <returns> A new <see cref="Models.ManagedServiceIdentity"/> instance for mocking. </returns>
        public static ManagedServiceIdentity ManagedServiceIdentity(Guid? principalId = null, Guid? tenantId = null, ManagedServiceIdentityType managedServiceIdentityType = default, IDictionary<ResourceIdentifier, UserAssignedIdentity> userAssignedIdentities = null)
        {
            return new ManagedServiceIdentity(principalId, tenantId, managedServiceIdentityType, userAssignedIdentities);
        }
    }
}
