// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Models;

    public partial class RegistriesImpl 
    {
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
        Registry.Definition.IBlank Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Registry.Definition.IBlank>.Define(string name)
        {
            return this.Define(name) as Registry.Definition.IBlank;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        async Task<IPagedCollection<IRegistry>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>.ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListByResourceGroupAsync(resourceGroupName, loadAllPages, cancellationToken) as IPagedCollection<IRegistry>;
        }

        /// <summary>
        /// Lists resources of the specified type in the specified resource group.
        /// </summary>
        /// <param name="resourceGroupName">The name of the resource group to list the resources from.</param>
        /// <return>The list of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>.ListByResourceGroup(string resourceGroupName)
        {
            return this.ListByResourceGroup(resourceGroupName) as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        async Task<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IRegistry>> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>.ListAsync(bool loadAllPages, CancellationToken cancellationToken)
        {
            return await this.ListAsync(loadAllPages, cancellationToken) as Microsoft.Azure.Management.ResourceManager.Fluent.Core.IPagedCollection<IRegistry>;
        }

        /// <summary>
        /// Lists all the resources of the specified type in the currently selected subscription.
        /// </summary>
        /// <return>List of resources.</return>
        System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry> Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>.List()
        {
            return this.List() as System.Collections.Generic.IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>;
        }

        /// <summary>
        /// Lists the login credentials for the specified container registry.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>The list of credentials.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.ListCredentials(string groupName, string registryName)
        {
            return this.ListCredentials(groupName, registryName) as Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner;
        }

        /// <summary>
        /// Lists the login credentials for the specified container registry.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>The list of credentials.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.ListCredentialsAsync(string groupName, string registryName, CancellationToken cancellationToken)
        {
            return await this.ListCredentialsAsync(groupName, registryName, cancellationToken) as Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner;
        }

        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="passwordName">The password name to regenerate login credentials for.</param>
        /// <return>The list of credentials.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.RegenerateCredentialAsync(string groupName, string registryName, PasswordName passwordName, CancellationToken cancellationToken)
        {
            return await this.RegenerateCredentialAsync(groupName, registryName, passwordName, cancellationToken) as Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner;
        }

        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="passwordName">The password name to regenerate login credentials for.</param>
        /// <return>The list of credentials.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistries.RegenerateCredential(string groupName, string registryName, PasswordName passwordName)
        {
            return this.RegenerateCredential(groupName, registryName, passwordName) as Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner;
        }
    }
}