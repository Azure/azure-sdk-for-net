// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models ;
    /// <summary>
    /// An immutable client-side representation of an Azure AD service principal.
    /// </summary>
    public interface IServicePrincipal  :
        IWrapper<Microsoft.Azure.Management.Graph.RBAC.Fluent.Models .ServicePrincipalInner>
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