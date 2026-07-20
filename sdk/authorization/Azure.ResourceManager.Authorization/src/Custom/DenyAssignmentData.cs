// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Authorization.Models;

namespace Azure.ResourceManager.Authorization
{
    public partial class DenyAssignmentData
    {
        // The input/output model retains generated mutable IList<T> collections under new descriptive names.
        // Hidden obsolete IReadOnlyList<T> wrappers preserve the shipped output-only API using the same backing collections without changing serialization.

        /// <summary> An array of permissions that are denied by the deny assignment. </summary>
        [WirePath("properties.permissions")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use DeniedPermissions instead.")]
        public IReadOnlyList<DenyAssignmentPermission> Permissions
        {
            get => (IReadOnlyList<DenyAssignmentPermission>)DeniedPermissions;
        }

        /// <summary> Array of principals to which the deny assignment applies. </summary>
        [WirePath("properties.principals")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use DeniedPrincipals instead.")]
        public IReadOnlyList<RoleManagementPrincipal> Principals
        {
            get => (IReadOnlyList<RoleManagementPrincipal>)DeniedPrincipals;
        }

        /// <summary> Array of principals to which the deny assignment does not apply. </summary>
        [WirePath("properties.excludePrincipals")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ExcludedPrincipals instead.")]
        public IReadOnlyList<RoleManagementPrincipal> ExcludePrincipals
        {
            get => (IReadOnlyList<RoleManagementPrincipal>)ExcludedPrincipals;
        }
    }
}
