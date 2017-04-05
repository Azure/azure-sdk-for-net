// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Models;
    using Disk.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using System.Collections.Generic;

    internal partial class DisksImpl 
    {
        /// <summary>
        /// Grants access to a disk.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        /// <param name="accessLevel">Access level.</param>
        /// <param name="accessDuration">Access duration.</param>
        /// <return>The readonly SAS uri to the disk.</return>
        string Microsoft.Azure.Management.Compute.Fluent.IDisks.GrantAccess(string resourceGroupName, string diskName, AccessLevel accessLevel, int accessDuration)
        {
            return this.GrantAccess(resourceGroupName, diskName, accessLevel, accessDuration);
        }

        /// <summary>
        /// Revoke access granted to a disk.
        /// </summary>
        /// <param name="resourceGroupName">The resource group name.</param>
        /// <param name="diskName">The disk name.</param>
        void Microsoft.Azure.Management.Compute.Fluent.IDisks.RevokeAccess(string resourceGroupName, string diskName)
        {
             this.RevokeAccess(resourceGroupName, diskName);
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
        Disk.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Disk.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as Disk.Definition.IBlank;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IDisk> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IDisk>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName);
        }

        /// <summary>
        /// Gets the information about a resource from Azure based on the resource name and the name of its resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group the resource is in.</param>
        /// <param name="name">The name of the resource. (Note, this is not the ID).</param>
        /// <return>An immutable representation of the resource.</return>
        async Task<Microsoft.Azure.Management.Compute.Fluent.IDisk> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Compute.Fluent.IDisk>.GetByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken)
        {
            return await this.GetByResourceGroupAsync(resourceGroupName, name, cancellationToken) as Microsoft.Azure.Management.Compute.Fluent.IDisk;
        }

        /// <summary>
        /// Asynchronously delete a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="groupName">The group the resource is part of.</param>
        /// <param name="name">The name of the resource.</param>
        /// <return>A completable indicates completion or exception of the request.</return>
        async Task Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup.DeleteByResourceGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await this.DeleteByResourceGroupAsync(groupName, name, cancellationToken);
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IDisk> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Compute.Fluent.IDisk>.List()
        {
            return this.List();
        }
    }
}