// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models ;
    /// <summary>
    /// An immutable client-side representation of an Azure AD service principal.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IServicePrincipal  :
        IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.Models .ServicePrincipalInner>
    {
        /// <returns>object Id.</returns>
        string ObjectId { get; }

        /// <returns>object type.</returns>
        string ObjectType { get; }

        /// <returns>service principal display name.</returns>
        string DisplayName { get; }

        /// <returns>app id.</returns>
        string AppId { get; }

        /// <returns>the list of names.</returns>
        System.Collections.Generic.IList<string> ServicePrincipalNames { get; }

    }
}