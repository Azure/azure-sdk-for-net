// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    /// <summary>
    /// An immutable client-side representation of an Azure AD service principal.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IServicePrincipal  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IIndexable,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.Models.ServicePrincipalInner>
    {
        /// <summary>
        /// Gets app id.
        /// </summary>
        string AppId { get; }

        /// <summary>
        /// Gets the list of names.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> ServicePrincipalNames { get; }

        /// <summary>
        /// Gets object Id.
        /// </summary>
        string ObjectId { get; }

        /// <summary>
        /// Gets service principal display name.
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Gets object type.
        /// </summary>
        string ObjectType { get; }
    }
}