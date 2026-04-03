// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Hci.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Hci
{
    // Backward compat: the old SDK exposed identity fields as flattened top-level properties
    // (e.g. cluster.PrincipalId) instead of nested under cluster.Identity.PrincipalId.
    // The generator uses the standard ARM ManagedServiceIdentity model which nests them.
    public partial class HciClusterData
    {
        /// <summary> Flattened identity type. </summary>
        [WirePath("identity.type")]
        public HciManagedServiceIdentityType? TypeIdentityType
        {
            get => Identity?.ManagedServiceIdentityType == null ? null : new HciManagedServiceIdentityType(Identity.ManagedServiceIdentityType.ToString());
            set
            {
                if (Identity == null)
                { Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.None); }
                if (value != null)
                { Identity = new ManagedServiceIdentity(new ManagedServiceIdentityType(value.ToString())); }
            }
        }

        /// <summary> Flattened principal id. </summary>
        [WirePath("identity.principalId")]
        public Guid? PrincipalId => Identity?.PrincipalId;

        /// <summary> Flattened tenant id. </summary>
        [WirePath("identity.tenantId")]
        public Guid? TenantId => Identity?.TenantId;

        /// <summary> Flattened user assigned identities. </summary>
        [WirePath("identity.userAssignedIdentities")]
        public IDictionary<string, UserAssignedIdentity> UserAssignedIdentities =>
            Identity?.UserAssignedIdentities?.ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value);
    }
}
