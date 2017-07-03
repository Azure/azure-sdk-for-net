// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Definition;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Registry.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System;
    using Models;

    public partial class RegistryImpl 
    {
        /// <summary>
        /// The parameters of a storage account for the container registry.
        /// If specified, the storage account must be in the same physical location as the container registry.
        /// </summary>
        /// <param name="storageAccount">The storage account.</param>
        /// <return>The next stage.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithStorageAccount.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount) as Registry.Definition.IWithCreate;
        }

        /// <summary>
        /// The parameters for a storage account for the container registry.
        /// If specified, the storage account must be in the same physical location as the container registry.
        /// </summary>
        /// <param name="storageAccountName">The name of the storage account.</param>
        /// <return>The next stage.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithStorageAccount.WithNewStorageAccount(string storageAccountName)
        {
            return this.WithNewStorageAccount(storageAccountName) as Registry.Definition.IWithCreate;
        }

        /// <summary>
        /// The parameters for a storage account for the container registry.
        /// If specified, the storage account must be in the same physical location as the container registry.
        /// </summary>
        /// <param name="creatable">The storage account to create.</param>
        /// <return>The next stage.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithStorageAccount.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            return this.WithNewStorageAccount(creatable) as Registry.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins an update for a new resource.
        /// This is the beginning of the builder pattern used to update top level resources
        /// in Azure. The final method completing the definition and starting the actual resource creation
        /// process in Azure is  Appliable.apply().
        /// </summary>
        /// <return>The stage of new resource update.</return>
        Registry.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<Registry.Update.IUpdate>.Update()
        {
            return this.Update() as Registry.Update.IUpdate;
        }

        /// <summary>
        /// Enable admin user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Definition.IWithCreate Registry.Definition.IWithAdminUserEnabled.WithRegistryNameAsAdminUser()
        {
            return this.WithRegistryNameAsAdminUser() as Registry.Definition.IWithCreate;
        }

        /// <summary>
        /// Enable admin user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Update.IUpdate Registry.Update.IWithAdminUserEnabled.WithRegistryNameAsAdminUser()
        {
            return this.WithRegistryNameAsAdminUser() as Registry.Update.IUpdate;
        }

        /// <summary>
        /// Disable admin user.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Registry.Update.IUpdate Registry.Update.IWithAdminUserEnabled.WithoutRegistryNameAsAdminUser()
        {
            return this.WithoutRegistryNameAsAdminUser() as Registry.Update.IUpdate;
        }

        /// <summary>
        /// Gets the creation date of the container registry in ISO8601 format.
        /// </summary>
        System.DateTime Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.CreationDate
        {
            get
            {
                return this.CreationDate();
            }
        }

        /// <summary>
        /// Gets the name of the storage account for the container registry.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.StorageAccountName
        {
            get
            {
                return this.StorageAccountName();
            }
        }

        /// <summary>
        /// Gets the value that indicates whether the admin user is enabled. This value is false by default.
        /// </summary>
        bool Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.AdminUserEnabled
        {
            get
            {
                return this.AdminUserEnabled();
            }
        }

        /// <return>The login credentials for the specified container registry.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.ListCredentials()
        {
            return this.ListCredentials() as Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials;
        }

        /// <summary>
        /// Gets the SKU of the container registry.
        /// </summary>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.Sku Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.Sku
        {
            get
            {
                return this.Sku() as Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.Sku;
            }
        }

        /// <summary>
        /// Gets the URL that can be used to log into the container registry.
        /// </summary>
        string Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.LoginServerUrl
        {
            get
            {
                return this.LoginServerUrl();
            }
        }

        /// <return>The login credentials for the specified container registry.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.ListCredentialsAsync(CancellationToken cancellationToken)
        {
            return await this.ListCredentialsAsync(cancellationToken) as Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials;
        }

        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="passwordName">The password name.</param>
        /// <return>The result of the regeneration.</return>
        async Task<Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials> Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.RegenerateCredentialAsync(PasswordName passwordName, CancellationToken cancellationToken)
        {
            return await this.RegenerateCredentialAsync(passwordName, cancellationToken) as Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials;
        }

        /// <summary>
        /// Regenerates one of the login credentials for the specified container registry.
        /// </summary>
        /// <param name="passwordName">The password name.</param>
        /// <return>The result of the regeneration.</return>
        Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistry.RegenerateCredential(PasswordName passwordName)
        {
            return this.RegenerateCredential(passwordName) as Microsoft.Azure.Management.ContainerRegistry.Fluent.Models.RegistryListCredentials;
        }
    }
}