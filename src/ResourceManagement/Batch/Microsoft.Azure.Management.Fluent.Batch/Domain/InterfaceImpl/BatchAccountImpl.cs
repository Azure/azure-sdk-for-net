// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{

    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update;
    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Storage;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Models;
    using System.Threading;
    internal partial class BatchAccountImpl 
    {
        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccount">storageAccount existing storage account to be used</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IWithStorageAccount.WithExistingStorageAccount (IStorageAccount storageAccount) {
            return this.WithExistingStorageAccount( storageAccount) as Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that storage account should be removed from the batch account.
        /// </summary>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IWithStorageAccount.WithoutStorageAccount () {
            return this.WithoutStorageAccount() as Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">storageAccountCreatable storage account to be created along with and used in batch</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IWithStorageAccount.WithNewStorageAccount (ICreatable<Microsoft.Azure.Management.V2.Storage.IStorageAccount> storageAccountCreatable) {
            return this.WithNewStorageAccount( storageAccountCreatable) as Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName name of new storage account to be created and used in batch account</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IWithStorageAccount.WithNewStorageAccount (string storageAccountName) {
            return this.WithNewStorageAccount( storageAccountName) as Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate;
        }

        /// <returns>the pool quota for this BatchAccount account</returns>
        int? Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.PoolQuota
        {
            get
            {
                return this.PoolQuota;
            }
        }
        /// <returns>the core quota for this BatchAccount account</returns>
        int? Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.CoreQuota
        {
            get
            {
                return this.CoreQuota;
            }
        }
        /// <returns>the properties and status of any auto storage account associated with</returns>
        /// <returns>the account</returns>
        Microsoft.Azure.Management.Batch.Models.AutoStorageProperties Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.AutoStorage
        {
            get
            {
                return this.AutoStorage as Microsoft.Azure.Management.Batch.Models.AutoStorageProperties;
            }
        }
        /// <returns>Get the accountEndpoint value.</returns>
        string Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.AccountEndpoint
        {
            get
            {
                return this.AccountEndpoint as string;
            }
        }
        /// <returns>the provisioned state of the resource. Possible values include:</returns>
        /// <returns>'Invalid', 'Creating', 'Deleting', 'Succeeded', 'Failed', 'Cancelled'</returns>
        Microsoft.Azure.Management.Batch.Models.ProvisioningState? Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.ProvisioningState
        {
            get
            {
                return this.ProvisioningState;
            }
        }
        /// <returns>the active job and job schedule quota for this BatchAccount account</returns>
        int? Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.ActiveJobAndJobScheduleQuota
        {
            get
            {
                return this.ActiveJobAndJobScheduleQuota;
            }
        }
        /// <returns>the access keys for this batch account</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccountKeys Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.Keys () {
            return this.Keys() as Microsoft.Azure.Management.Fluent.Batch.BatchAccountKeys;
        }

        /// <returns>the access keys for this batch account</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccountKeys Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.RefreshKeys () {
            return this.RefreshKeys() as Microsoft.Azure.Management.Fluent.Batch.BatchAccountKeys;
        }

        /// <summary>
        /// Synchronize the storage account keys for batch account.
        /// </summary>
        void Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.SynchronizeAutoStorageKeys () {
            this.SynchronizeAutoStorageKeys();
        }

        /// <summary>
        /// Regenerates the access keys for batch account.
        /// </summary>
        /// <param name="keyType">keyType either primary or secondary key to be regenerated</param>
        /// <returns>the access keys for this batch account</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccountKeys Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.RegenerateKeys (AccountKeyType keyType) {
            return this.RegenerateKeys( keyType) as Microsoft.Azure.Management.Fluent.Batch.BatchAccountKeys;
        }

        /// <returns>the application in this batch account.</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Batch.IApplication> Microsoft.Azure.Management.Fluent.Batch.IBatchAccount.Applications () {
            return this.Applications() as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Batch.IApplication>;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.Fluent.Batch.IBatchAccount Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Fluent.Batch.IBatchAccount>.Refresh () {
            return this.Refresh() as Microsoft.Azure.Management.Fluent.Batch.IBatchAccount;
        }

        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccount">storageAccount existing storage account to be used</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithStorage.WithExistingStorageAccount (IStorageAccount storageAccount) {
            return this.WithExistingStorageAccount( storageAccount) as Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that a storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">storageAccountCreatable storage account to be created along with and used in batch</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithStorage.WithNewStorageAccount (ICreatable<Microsoft.Azure.Management.V2.Storage.IStorageAccount> storageAccountCreatable) {
            return this.WithNewStorageAccount( storageAccountCreatable) as Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName name of new storage account to be created and used in batch account</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithCreate Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithStorage.WithNewStorageAccount (string storageAccountName) {
            return this.WithNewStorageAccount( storageAccountName) as Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Begins the description of an update of an existing application of this batch account.
        /// </summary>
        /// <param name="applicationId">applicationId the reference name for the application to be updated</param>
        /// <returns>the stage representing updatable application.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IWithApplication.UpdateApplication (string applicationId) {
            return this.UpdateApplication( applicationId) as Microsoft.Azure.Management.Fluent.Batch.Application.Update.IUpdate;
        }

        /// <summary>
        /// Deletes specified application from the batch account.
        /// </summary>
        /// <param name="applicationId">applicationId the reference name for the application to be removed</param>
        /// <returns>the stage representing updatable batch account definition.</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IWithApplication.WithoutApplication (string applicationId) {
            return this.WithoutApplication( applicationId) as Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies definition of an application to be created in a batch account.
        /// </summary>
        /// <param name="applicationId">applicationId the reference name for application</param>
        /// <returns>the stage representing configuration for the extension</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate> Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IWithApplication.DefineNewApplication (string applicationId) {
            return this.DefineNewApplication( applicationId) as Microsoft.Azure.Management.Fluent.Batch.Application.UpdateDefinition.IBlank<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>;
        }

        /// <summary>
        /// First stage to create new application in Batch account.
        /// </summary>
        /// <param name="applicationId">applicationId id of the application to create</param>
        /// <returns>next stage to create the Batch account.</returns>
        Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IBlank<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage> Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplication.DefineNewApplication (string applicationId) {
            return this.DefineNewApplication( applicationId) as Microsoft.Azure.Management.Fluent.Batch.Application.Definition.IBlank<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Definition.IWithApplicationAndStorage>;
        }

    }
}