// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure registry.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IRegistry  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryManager,Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Registry.Update.IUpdate>
    {
        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="passwordName">The password name.</param>
        /// <return>The result of the regeneration.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials RegenerateCredential(Models.PasswordName passwordName);

        /// <summary>
        /// Gets the creation date of the container registry in ISO8601 format.
        /// </summary>
        System.DateTime CreationDate { get; }

        /// <summary>
        /// Gets the name of the storage account for the container registry.
        /// </summary>
        string StorageAccountName { get; }

        /// <return>The login credentials for the specified container registry.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials> ListCredentialsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The login credentials for the specified container registry.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials ListCredentials();

        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="passwordName">The password name.</param>
        /// <return>The result of the regeneration.</return>
        Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials> RegenerateCredentialAsync(Models.PasswordName passwordName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the SKU of the container registry.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.Sku Sku { get; }

        /// <summary>
        /// Gets the value that indicates whether the admin user is enabled. This value is false by default.
        /// </summary>
        bool AdminUserEnabled { get; }

        /// <summary>
        /// Gets the URL that can be used to log into the container registry.
        /// </summary>
        string LoginServerUrl { get; }
    }
}