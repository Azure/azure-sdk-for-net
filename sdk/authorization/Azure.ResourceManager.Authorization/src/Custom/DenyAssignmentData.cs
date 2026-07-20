// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Authorization.Models;

namespace Azure.ResourceManager.Authorization
{
    public partial class DenyAssignmentData
    {
        // TypeSpec generation exposes these collections as mutable IList<T> properties.
        // These custom properties restore the shipped IReadOnlyList<T> API while returning the same generated backing collections used by serialization.

        /// <summary> An array of permissions that are denied by the deny assignment. </summary>
        [WirePath("properties.permissions")]
        public IReadOnlyList<DenyAssignmentPermission> Permissions
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new DenyAssignmentProperties();
                }
                return (IReadOnlyList<DenyAssignmentPermission>)Properties.Permissions;
            }
        }

        /// <summary> Array of principals to which the deny assignment applies. </summary>
        [WirePath("properties.principals")]
        public IReadOnlyList<RoleManagementPrincipal> Principals
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new DenyAssignmentProperties();
                }
                return (IReadOnlyList<RoleManagementPrincipal>)Properties.Principals;
            }
        }

        /// <summary> Array of principals to which the deny assignment does not apply. </summary>
        [WirePath("properties.excludePrincipals")]
        public IReadOnlyList<RoleManagementPrincipal> ExcludePrincipals
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new DenyAssignmentProperties();
                }
                return (IReadOnlyList<RoleManagementPrincipal>)Properties.ExcludePrincipals;
            }
        }
    }
}
