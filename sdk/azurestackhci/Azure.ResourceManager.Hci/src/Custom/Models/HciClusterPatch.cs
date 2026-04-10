// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Hci.Models
{
    // TODO: https://github.com/Azure/azure-sdk-for-net/issues/58058 @@Legacy.flattenProperty does not work for system/framework types (e.g., ManagedServiceIdentity)
    [CodeGenSuppress("Identity")]
    public partial class HciClusterPatch
    {
        /// <summary> The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. </summary>
        [WirePath("identity.principalId")]
        public Guid? PrincipalId { get; }
        /// <summary> The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. </summary>
        [WirePath("identity.tenantId")]
        public Guid? TenantId { get; }
        /// <summary> Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed). </summary>
        [WirePath("identity.type")]
        public HciManagedServiceIdentityType? ManagedServiceIdentityType { get; set; }
        /// <summary> The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests. </summary>
        [WirePath("identity.userAssignedIdentities")]
        public IDictionary<string, UserAssignedIdentity> UserAssignedIdentities { get; }
    }
}
