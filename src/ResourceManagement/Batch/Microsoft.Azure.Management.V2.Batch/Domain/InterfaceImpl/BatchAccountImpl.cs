// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.V2.Batch
{

    using System.Threading;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.V2.Storage;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition;
    using Microsoft.Azure.Management.V2.Batch.BatchAccount.Update;
    using Management.Batch.Models;

    public partial class BatchAccountImpl 
    {
        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccount">storageAccount existing storage account to be used</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IUpdate Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IWithStorageAccount.WithStorageAccount (IStorageAccount storageAccount) {
            return this.WithStorageAccount( storageAccount) as Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that a storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">storageAccountCreatable storage account to be created along with and used in batch</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IUpdate Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IWithStorageAccount.WithNewStorageAccount (ICreatable<IStorageAccount> storageAccountCreatable) {
            return this.WithNewStorageAccount( storageAccountCreatable) as Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName name of new storage account to be created and used in batch account</param>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IUpdate Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IWithStorageAccount.WithNewStorageAccount (string storageAccountName) {
            return this.WithNewStorageAccount( storageAccountName) as Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that storage account should be removed from the batch account.
        /// </summary>
        /// <returns>the stage representing updatable batch account definition</returns>
        Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IUpdate Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IWithStorageAccount.WithoutStorageAccount () {
            return this.WithoutStorageAccount() as Microsoft.Azure.Management.V2.Batch.BatchAccount.Update.IUpdate;
        }

        /// <returns>the pool quota for this BatchAccount account</returns>
        int? Microsoft.Azure.Management.V2.Batch.IBatchAccount.PoolQuota
        {
            get
            {
                return this.PoolQuota;
            }
        }
        /// <returns>the core quota for this BatchAccount account</returns>
        int? Microsoft.Azure.Management.V2.Batch.IBatchAccount.CoreQuota
        {
            get
            {
                return this.CoreQuota;
            }
        }
        /// <returns>the properties and status of any auto storage account associated with</returns>
        /// <returns>the account</returns>
        AutoStorageProperties Microsoft.Azure.Management.V2.Batch.IBatchAccount.AutoStorage
        {
            get
            {
                return this.AutoStorage as AutoStorageProperties;
            }
        }
        /// <returns>Get the accountEndpoint value.</returns>
        string Microsoft.Azure.Management.V2.Batch.IBatchAccount.AccountEndpoint
        {
            get
            {
                return this.AccountEndpoint as string;
            }
        }
        /// <returns>the provisioned state of the resource. Possible values include:</returns>
        /// <returns>'Invalid', 'Creating', 'Deleting', 'Succeeded', 'Failed', 'Cancelled'</returns>
        AccountProvisioningState? Microsoft.Azure.Management.V2.Batch.IBatchAccount.ProvisioningState
        {
            get
            {
                return this.ProvisioningState;
            }
        }
        /// <returns>the active job and job schedule quota for this BatchAccount account</returns>
        int? Microsoft.Azure.Management.V2.Batch.IBatchAccount.ActiveJobAndJobScheduleQuota
        {
            get
            {
                return this.ActiveJobAndJobScheduleQuota;
            }
        }
        /// <returns>the access keys for this batch account</returns>
        Microsoft.Azure.Management.V2.Batch.BatchAccountKeys Microsoft.Azure.Management.V2.Batch.IBatchAccount.Keys () {
            return this.Keys() as Microsoft.Azure.Management.V2.Batch.BatchAccountKeys;
        }

        /// <returns>the access keys for this batch account</returns>
        Microsoft.Azure.Management.V2.Batch.BatchAccountKeys Microsoft.Azure.Management.V2.Batch.IBatchAccount.RefreshKeys () {
            return this.RefreshKeys() as Microsoft.Azure.Management.V2.Batch.BatchAccountKeys;
        }

        /// <summary>
        /// Synchronize the storage account keys for batch account.
        /// </summary>
        void Microsoft.Azure.Management.V2.Batch.IBatchAccount.SynchronizeAutoStorageKeys () {
            this.SynchronizeAutoStorageKeys();
        }

        /// <summary>
        /// Regenerates the access keys for batch account.
        /// </summary>
        /// <param name="keyType">keyType either primary or secondary key to be regenerated</param>
        /// <returns>the access keys for this batch account</returns>
        Microsoft.Azure.Management.V2.Batch.BatchAccountKeys Microsoft.Azure.Management.V2.Batch.IBatchAccount.RegenerateKeys (AccountKeyType keyType) {
            return this.RegenerateKeys( keyType) as Microsoft.Azure.Management.V2.Batch.BatchAccountKeys;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <returns>the refreshed resource</returns>
        Microsoft.Azure.Management.V2.Batch.IBatchAccount Microsoft.Azure.Management.V2.Resource.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.V2.Batch.IBatchAccount>.Refresh () {
            return this.Refresh() as Microsoft.Azure.Management.V2.Batch.IBatchAccount;
        }

        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccount">storageAccount existing storage account to be used</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithCreate Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithCreate.WithStorageAccount (IStorageAccount storageAccount) {
            return this.WithStorageAccount( storageAccount) as Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that a storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountCreatable">storageAccountCreatable storage account to be created along with and used in batch</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithCreate Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithCreate.WithNewStorageAccount (ICreatable<IStorageAccount> storageAccountCreatable) {
            return this.WithNewStorageAccount( storageAccountCreatable) as Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies that an existing storage account to be attached with the batch account.
        /// </summary>
        /// <param name="storageAccountName">storageAccountName name of new storage account to be created and used in batch account</param>
        /// <returns>the stage representing creatable batch account definition</returns>
        Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithCreate Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithCreate.WithNewStorageAccount (string storageAccountName) {
            return this.WithNewStorageAccount( storageAccountName) as Microsoft.Azure.Management.V2.Batch.BatchAccount.Definition.IWithCreate;
        }

    }
}