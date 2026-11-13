// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Hci
{
    // Backward compat: the old SDK flattened identity properties to top level.
    // Users should use the Identity property directly instead.
    public partial class HciClusterData
    {
        /// <summary> The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. </summary>
        [Obsolete("This property is now deprecated. Please use the `Identity` property moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("identity.principalId")]
        public Guid? PrincipalId { get; }
        /// <summary> The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. </summary>
        [Obsolete("This property is now deprecated. Please use the `Identity` property moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("identity.tenantId")]
        public Guid? TenantId { get; }
        /// <summary> Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed). </summary>
        [Obsolete("This property is now deprecated. Please use the `Identity` property moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("identity.type")]
        public HciManagedServiceIdentityType? TypeIdentityType { get; set; }
        /// <summary> The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests. </summary>
        [Obsolete("This property is now deprecated. Please use the `Identity` property moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("identity.userAssignedIdentities")]
        public IDictionary<string, UserAssignedIdentity> UserAssignedIdentities { get; }
    }
}
