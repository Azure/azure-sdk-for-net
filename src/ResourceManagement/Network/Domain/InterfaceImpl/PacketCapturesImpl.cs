// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.PacketCapture.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;

    internal partial class PacketCapturesImpl 
    {
        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">The name of the resource to delete.</param>
        /// <return>A representation of the deferred computation of this call.</return>
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
        /// process in Azure is  Creatable.create().
        /// Note that the  Creatable.create() method is
        /// only available at the stage of the resource definition that has the minimum set of input
        /// parameters specified. If you do not see  Creatable.create() among the available methods, it
        /// means you have not yet specified all the required input settings. Input settings generally begin
        /// with the word "with", for example: <code>.withNewResourceGroup()</code> and return the next stage
        /// of the resource definition, as an interface in the "fluent interface" style.
        /// </summary>
        /// <param name="name">The name of the new resource.</param>
        /// <return>The first stage of the new resource definition.</return>
        PacketCapture.Definition.IWithTarget Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<PacketCapture.Definition.IWithTarget>.Define(string name)
        {
            return this.Define(name) as PacketCapture.Definition.IWithTarget;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IPacketCapture> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IPacketCapture>.List()
        {
            return this.List() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.Network.Fluent.IPacketCapture>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IPacketCapture>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IPacketCapture>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IPacketCapture>;
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name within the current resource group.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <return>An immutable representation of the resource.</return>
        Microsoft.Azure.Management.Network.Fluent.IPacketCapture Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByName<Microsoft.Azure.Management.Network.Fluent.IPacketCapture>.GetByName(string name)
        {
            return this.GetByName(name) as Microsoft.Azure.Management.Network.Fluent.IPacketCapture;
        }

        /// <summary>
        /// Gets the information about a resource based on the resource name.
        /// </summary>
        /// <param name="name">The name of the resource. (Note, this is not the resource ID.).</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Network.Fluent.IPacketCapture> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByNameAsync<Microsoft.Azure.Management.Network.Fluent.IPacketCapture>.GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await this.GetByNameAsync(name, cancellationToken) as Microsoft.Azure.Management.Network.Fluent.IPacketCapture;
        }
    }
}