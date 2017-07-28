// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Batch.Fluent.Application.Definition;
    using Microsoft.Azure.Management.Batch.Fluent.Application.Update;
    using Microsoft.Azure.Management.Batch.Fluent.Application.UpdateDefinition;
    using Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Definition;
    using Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System.Collections.Generic;
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class BatchAccountImpl 
    {
        /// <summary>
        /// Specifies an existing storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithStorageAccount.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount) as BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Removes the associated storage account.
        /// </summary>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithStorageAccount.WithoutStorageAccount()
        {
            return this.WithoutStorageAccount() as BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a new storage account to create and associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">The definition of the storage account.</param>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithStorageAccount.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable)
        {
            return this.WithNewStorageAccount(storageAccountCreatable) as BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies a new storage account to create and associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountName">The name of a new storage account.</param>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithStorageAccount.WithNewStorageAccount(string storageAccountName)
        {
            return this.WithNewStorageAccount(storageAccountName) as BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Gets the pool quota for this Batch account.
        /// </summary>
        int Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.PoolQuota
        {
            get
            {
                return this.PoolQuota();
            }
        }

        /// <return>The access keys for this Batch account.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccountKeys Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.GetKeys()
        {
            return Extensions.Synchronize(() => this.GetKeysAsync());
        }

        /// <summary>
        /// Gets the core quota for this Batch account.
        /// </summary>
        int Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.CoreQuota
        {
            get
            {
                return this.CoreQuota();
            }
        }

        /// <summary>
        /// Gets the properties and status of any auto storage account associated with the Batch account.
        /// </summary>
        AutoStorageProperties Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.AutoStorage
        {
            get
            {
                return this.AutoStorage() as AutoStorageProperties;
            }
        }

        /// <summary>
        /// Gets Batch account endpoint.
        /// </summary>
        string Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.AccountEndpoint
        {
            get
            {
                return this.AccountEndpoint();
            }
        }

        /// <summary>
        /// Gets the provisioned state of the resource.
        /// </summary>
        ProvisioningState Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the active job and job schedule quota for this Batch account.
        /// </summary>
        int Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.ActiveJobAndJobScheduleQuota
        {
            get
            {
                return this.ActiveJobAndJobScheduleQuota();
            }
        }

        /// <summary>
        /// Synchronizes the storage account keys for this Batch account.
        /// </summary>
        void Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.SynchronizeAutoStorageKeys()
        {
            Extensions.Synchronize(() => this.SynchronizeAutoStorageKeysAsync()); ;
        }

        /// <summary>
        /// Regenerates the access keys for the Batch account.
        /// </summary>
        /// <param name="keyType">The type if key to regenerate.</param>
        /// <return>Regenerated access keys for this Batch account.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccountKeys Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.RegenerateKeys(AccountKeyType keyType)
        {
            return Extensions.Synchronize(() => this.RegenerateKeysAsync(keyType));
        }

        /// <summary>
        /// Gets applications in this Batch account, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Batch.Fluent.IApplication> Microsoft.Azure.Management.Batch.Fluent.IBatchAccount.Applications
        {
            get
            {
                return this.Applications() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Batch.Fluent.IApplication>;
            }
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.Batch.Fluent.IBatchAccount;
        }

        /// <summary>
        /// Specifies an existing storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccount">An existing storage account.</param>
        /// <return>The next stage of the definition.</return>
        BatchAccount.Definition.IWithCreate BatchAccount.Definition.IWithStorage.WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            return this.WithExistingStorageAccount(storageAccount) as BatchAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies a new storage account to associate with the Batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">A storage account to be created along with and used in the Batch account.</param>
        /// <return>The next stage of the definition.</return>
        BatchAccount.Definition.IWithCreate BatchAccount.Definition.IWithStorage.WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable)
        {
            return this.WithNewStorageAccount(storageAccountCreatable) as BatchAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the name of a new storage account to be created and associated with this Batch account.
        /// </summary>
        /// <param name="storageAccountName">The name of a new storage account.</param>
        /// <return>The next stage of the definition.</return>
        BatchAccount.Definition.IWithCreate BatchAccount.Definition.IWithStorage.WithNewStorageAccount(string storageAccountName)
        {
            return this.WithNewStorageAccount(storageAccountName) as BatchAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the description of an update of an existing Batch application in this Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name of the application to be updated.</param>
        /// <return>The first stage of a Batch application update.</return>
        Application.Update.IUpdate BatchAccount.Update.IWithApplication.UpdateApplication(string applicationId)
        {
            return this.UpdateApplication(applicationId) as Application.Update.IUpdate;
        }

        /// <summary>
        /// Removes the specified application from the Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name for the application to be removed.</param>
        /// <return>The next stage of the update.</return>
        BatchAccount.Update.IUpdate BatchAccount.Update.IWithApplication.WithoutApplication(string applicationId)
        {
            return this.WithoutApplication(applicationId) as BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Starts a definition of an application to be created in the Batch account.
        /// </summary>
        /// <param name="applicationId">The reference name for the application.</param>
        /// <return>The first stage of a Batch application definition.</return>
        Application.UpdateDefinition.IBlank<BatchAccount.Update.IUpdate> BatchAccount.Update.IWithApplication.DefineNewApplication(string applicationId)
        {
            return this.DefineNewApplication(applicationId) as Application.UpdateDefinition.IBlank<BatchAccount.Update.IUpdate>;
        }

        /// <summary>
        /// The stage of a Batch account definition allowing to add a Batch application.
        /// </summary>
        /// <param name="applicationId">The id of the application to create.</param>
        /// <return>The next stage of the definition.</return>
        Application.Definition.IBlank<BatchAccount.Definition.IWithApplicationAndStorage> BatchAccount.Definition.IWithApplication.DefineNewApplication(string applicationId)
        {
            return this.DefineNewApplication(applicationId) as Application.Definition.IBlank<BatchAccount.Definition.IWithApplicationAndStorage>;
        }
    }
}