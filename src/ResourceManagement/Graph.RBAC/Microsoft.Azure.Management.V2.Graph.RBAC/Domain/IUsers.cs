/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Rest;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Fluent.Graph.RBAC.User.Definition;
    using System.Threading;
    /// <summary>
    /// Entry point to AD user management API.
    /// </summary>
    public interface IUsers  :
        ISupportsCreating<IBlank>,
        ISupportsListing<IUser>,
        ISupportsDeleting
    {
        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="objectId">objectId the unique object id</param>
        /// <returns>an immutable representation of the resource</returns>
        IUser GetByObjectId (string objectId);

        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="upn">upn the user principal name</param>
        /// <returns>an immutable representation of the resource</returns>
        IUser GetByUserPrincipalName (string upn);

        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="upn">upn the user principal name</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>an Future based service call</returns>
        Task<IUser> GetByUserPrincipalNameAsync(string upn, CancellationToken cancellationToken = default(CancellationToken));
    }
}