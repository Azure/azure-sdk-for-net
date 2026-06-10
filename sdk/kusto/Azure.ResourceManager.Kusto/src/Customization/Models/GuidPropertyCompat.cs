// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: retain old Guid? PrincipalId shim where the generated API
// now exposes ClusterPrincipalId as string. TenantId/AadObjectId are renamed
// to TenantIdValue/AadObjectIdValue in generated code via @@clientName, so
// we can add the original Guid? properties here.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Kusto
{
    public partial class KustoClusterPrincipalAssignmentData
    {
        /// <summary> The principal ID assigned to the cluster principal. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use ClusterPrincipalId instead.", false)]
        [WirePath("properties.principalId")]
        public Guid? PrincipalId
        {
            get => Guid.TryParse(ClusterPrincipalId, out var g) ? g : null;
            set => ClusterPrincipalId = value?.ToString();
        }

        /// <summary> The tenant id of the principal. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use TenantIdValue instead.", false)]
        [WirePath("properties.tenantId")]
        public Guid? TenantId
        {
            get => Guid.TryParse(TenantIdValue, out var g) ? g : null;
            set => TenantIdValue = value?.ToString();
        }

        /// <summary> The AAD object id of the principal. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use AadObjectIdValue instead.", false)]
        [WirePath("properties.aadObjectId")]
        public Guid? AadObjectId
        {
            get => Guid.TryParse(AadObjectIdValue, out var g) ? g : null;
        }
    }
}
