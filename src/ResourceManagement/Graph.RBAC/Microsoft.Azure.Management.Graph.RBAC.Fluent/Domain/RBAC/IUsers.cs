// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition;
    using Resource.Fluent.Core;

    /// <summary>
    /// Entry point to AD user management API.
    /// </summary>
    public interface IUsers  :
        // ISupportsCreating<Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser>,
        IHasManager<IGraphRbacManager>
    {
        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="objectId">objectId the unique object id</param>
        /// <returns>an immutable representation of the resource</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser GetByObjectId(string objectId);

        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="upn">upn the user principal name</param>
        /// <returns>an immutable representation of the resource</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser GetByUserPrincipalName(string upn);

        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="upn">upn the user principal name</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>an Future based service call</returns>
        Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser> GetByUserPrincipalNameAsync(string upn, CancellationToken cancellationToken = default(CancellationToken));

    }
}