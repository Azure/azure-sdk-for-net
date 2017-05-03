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
    /// Entry point to AD user management API.
    /// </summary>
    public interface IUsers  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Graph.RBAC.Fluent.IGraphRbacManager>
    {
        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="objectId">The unique object id.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser GetByObjectId(string objectId);

        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="upn">The user principal name.</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser GetByUserPrincipalName(string upn);

        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="upn">The user principal name.</param>
        /// <return>An Future based service call.</return>
        Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser> GetByUserPrincipalNameAsync(string upn, CancellationToken cancellationToken = default(CancellationToken));
    }
}