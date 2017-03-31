// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public partial class UsersImpl 
    {
        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="upn">upn the user principal name</param>
        /// <returns>an immutable representation of the resource</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser Microsoft.Azure.Management.Graph.RBAC.Fluent.IUsers.GetByUserPrincipalName(string upn) { 
            return this.GetByUserPrincipalName( upn) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser;
        }

        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="upn">upn the user principal name</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <returns>an Future based service call</returns>
        async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser> Microsoft.Azure.Management.Graph.RBAC.Fluent.IUsers.GetByUserPrincipalNameAsync(string upn, CancellationToken cancellationToken = default(CancellationToken)) { 
            return await this.GetByUserPrincipalNameAsync(upn, cancellationToken) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser;
        }

        /// <summary>
        /// Gets the information about a user.
        /// </summary>
        /// <param name="objectId">objectId the unique object id</param>
        /// <returns>an immutable representation of the resource</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser Microsoft.Azure.Management.Graph.RBAC.Fluent.IUsers.GetByObjectId(string objectId) { 
            return this.GetByObjectId( objectId) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <returns>list of resources</returns>
        IEnumerable<IUser> ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser>.List()
        { 
            return this.List();
        }

    }
}