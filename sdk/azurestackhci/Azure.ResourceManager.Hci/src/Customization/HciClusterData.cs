// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Hci.Models;

namespace Azure.ResourceManager.Hci
{
    /// <summary>
    /// A class representing the HciCluster data model.
    /// Cluster details.
    /// </summary>
    public partial class HciClusterData : TrackedResourceData
    {
        /// <summary> The service principal ID of the system assigned identity. This property will only be provided for a system assigned identity. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? PrincipalId { get; }
        /// <summary> The tenant ID of the system assigned identity. This property will only be provided for a system assigned identity. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? TenantId { get; }
        /// <summary> Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HciManagedServiceIdentityType? TypeIdentityType { get; set; }
        /// <summary> The set of user assigned identities associated with the resource. The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}. The dictionary values can be empty objects ({}) in requests. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get; }
    }
}
