// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.ServicePrincipal.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure AD service principal.
    /// </summary>
    public interface IServicePrincipal  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IActiveDirectoryObject,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.ServicePrincipalInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<ServicePrincipal.Update.IUpdate>
    {
        /// <summary>
        /// Gets the list of names.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> ServicePrincipalNames { get; }

        /// <summary>
        /// Gets the mapping from scopes to role assignments.
        /// </summary>
        System.Collections.Generic.ISet<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> RoleAssignments { get; }

        /// <summary>
        /// Gets app id.
        /// </summary>
        string ApplicationId { get; }

        /// <summary>
        /// Gets the mapping of certificate credentials from their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.ICertificateCredential> CertificateCredentials { get; }

        /// <summary>
        /// Gets the mapping of password credentials from their names.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Graph.RBAC.Fluent.IPasswordCredential> PasswordCredentials { get; }
    }
}