// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Billing.Models
{
    public partial class BillingRoleAssignmentProperties
    {
        /// <summary> The tenant Id of the user who created the role assignment. </summary>
        [Obsolete("This property is now deprecated. Please use the new property `CreatedByPrincipalTenantIdString` moving forward.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? CreatedByPrincipalTenantId { get => string.IsNullOrEmpty(CreatedByPrincipalTenantIdString) ? null : new Guid(CreatedByPrincipalTenantIdString); }
    }
}
