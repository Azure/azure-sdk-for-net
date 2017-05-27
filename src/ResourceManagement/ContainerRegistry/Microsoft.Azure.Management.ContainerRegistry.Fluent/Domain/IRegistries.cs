// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Entry point to the registry management API.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IRegistries  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<Registry.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistriesOperations>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>
    {
        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="passwordName">The password name to regenerate login credentials for.</param>
        /// <return>The list of credentials.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner RegenerateCredential(string groupName, string registryName, Models.PasswordName passwordName);

        /// <summary>
        /// Lists the login credentials for the specified container registry.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>The list of credentials.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner> ListCredentialsAsync(string groupName, string registryName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Lists the login credentials for the specified container registry.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <return>The list of credentials.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner ListCredentials(string groupName, string registryName);

        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="groupName">The group name.</param>
        /// <param name="registryName">The registry name.</param>
        /// <param name="passwordName">The password name to regenerate login credentials for.</param>
        /// <return>The list of credentials.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentialsResultInner> RegenerateCredentialAsync(string groupName, string registryName, Models.PasswordName passwordName, CancellationToken cancellationToken = default(CancellationToken));
    }
}