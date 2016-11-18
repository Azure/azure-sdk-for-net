// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class VaultsImpl 
    {
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
        Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IBlank Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsCreating<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IBlank>.Define (string name) {
            return this.Define( name) as Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IBlank;
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">id the resource ID of the resource to delete</param>
        void Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsDeletingById.DeleteById(string id) {
            this.DeleteById( id);
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the name of the resource group to list the resources from</param>
        /// <returns>the list of resources</returns>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.KeyVault.Fluent.IVault> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListingByGroup<Microsoft.Azure.Management.KeyVault.Fluent.IVault>.ListByGroup (string resourceGroupName) {
            return this.ListByGroup( resourceGroupName) as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.KeyVault.Fluent.IVault>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the name of the resource group the resource is in</param>
        /// <param name="name">name the name of the resource. (Note, this is not the ID)</param>
        /// <returns>an immutable representation of the resource</returns>
        Microsoft.Azure.Management.KeyVault.Fluent.IVault Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsGettingByGroup<Microsoft.Azure.Management.KeyVault.Fluent.IVault>.GetByGroup (string resourceGroupName, string name) {
            return this.GetByGroup( resourceGroupName,  name) as Microsoft.Azure.Management.KeyVault.Fluent.IVault;
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="groupName">groupName The group the resource is part of</param>
        /// <param name="name">name The name of the resource</param>
        Task Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsDeletingByGroup.DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken) {
            return this.DeleteByGroupAsync( groupName,  name, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <returns>list of resources</returns>
        Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.KeyVault.Fluent.IVault> Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.KeyVault.Fluent.IVault>.List () {
            return this.List() as Microsoft.Azure.Management.Resource.Fluent.Core.PagedList<Microsoft.Azure.Management.KeyVault.Fluent.IVault>;
        }

    }
}