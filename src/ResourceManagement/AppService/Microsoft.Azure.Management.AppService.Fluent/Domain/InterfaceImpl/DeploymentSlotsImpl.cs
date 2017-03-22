// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Rest;

    internal partial class DeploymentSlotsImpl 
    {
        IWebApp IHasParent<IWebApp>.Parent
        {
            get
            {
                return this.Parent();
            }
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">The name of the resource to delete.</param>
        /// <return>An observable of the request.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName.DeleteByNameAsync(string name, CancellationToken cancellationToken)
        {
 
            await this.DeleteByNameAsync(name, cancellationToken);
        }

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">The name of the resource to delete.</param>
        void Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByName.DeleteByName(string name)
        {
 
            this.DeleteByName(name);
        }

        /// <summary>
        /// Begins a definition for a new resource.
        /// This is the beginning of the builder pattern used to create top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is Creatable.create().
        /// Note that the Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        DeploymentSlot.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<DeploymentSlot.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as DeploymentSlot.Definition.IBlank;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.PagedList<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.List()
        {
            return this.List() as Microsoft.Azure.Management.ResourceManager.Fluent.Core.PagedList<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name within the current resource group.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.GetByName(string name)
        {
            return this.GetByName(name) as Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot;
        }
    }
}