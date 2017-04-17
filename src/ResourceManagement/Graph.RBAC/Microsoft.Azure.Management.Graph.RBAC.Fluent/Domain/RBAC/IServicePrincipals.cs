// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Rest;

    /// <summary>
    /// Entry point to service principal management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IServicePrincipals  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.IGraphRbacManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipalsOperations>
    {
        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="objectId">The unique object id.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal GetByObjectId(string objectId);

        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="spn">The service principal name.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal GetByServicePrincipalName(string spn);

        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="appId">The application id (or the client id).</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal GetByAppId(string appId);

        /// <summary>
        /// Gets the information about a service principal.
        /// </summary>
        /// <param name="spn">The service principal name.</param>
        /// <return>The Observable to the request.</return>
        Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IServicePrincipal> GetByServicePrincipalNameAsync(string spn, CancellationToken cancellationToken = default(CancellationToken));
    }
}