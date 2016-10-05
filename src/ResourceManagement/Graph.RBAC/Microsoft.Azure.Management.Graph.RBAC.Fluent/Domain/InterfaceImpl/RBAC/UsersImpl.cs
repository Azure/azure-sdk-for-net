// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models ;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using System.Threading;
    using System.Threading.Tasks;
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
            return await this.GetByUserPrincipalNameAsync( upn) as Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser;
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
        /// Begins a definition for a new resource.
        /// <p>
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is {@link Creatable#create()}.
        /// <p>
        /// Note that the {@link Creatable#create()} method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see {@link Creatable#create()} among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">name the name of the new resource</param>
        /// <returns>the first stage of the new resource definition</returns>
        Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IBlank Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsCreating<Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IBlank>.Define(string name) { 
            return this.Define( name) as Microsoft.Azure.Management.Graph.RBAC.Fluent.User.Definition.IBlank;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <returns>list of resources</returns>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser>.List() { 
            return this.List() as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.Graph.RBAC.Fluent.IUser>;
        }

    }
}