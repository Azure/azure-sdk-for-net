// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: retain old Guid? PrincipalId shim where the generated API
// now exposes DatabasePrincipalId as string.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Kusto
{
    public partial class KustoDatabasePrincipalAssignmentData
    {
        /// <summary> The principal ID assigned to the database principal. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use DatabasePrincipalId instead.", false)]
        [WirePath("properties.principalId")]
        public Guid? PrincipalId
        {
            get => Guid.TryParse(DatabasePrincipalId, out var g) ? g : null;
            set => DatabasePrincipalId = value?.ToString();
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
