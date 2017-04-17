// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Batch.Fluent
{
    using Microsoft.Azure.Management.Batch.Fluent.BatchAccount.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// An immutable client-side representation of an Azure Batch account.
    /// </summary>
    public interface IBatchAccount  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<IBatchManager, BatchAccountInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.Batch.Fluent.IBatchAccount>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IUpdatable<BatchAccount.Update.IUpdate>
    {
        /// <summary>
        /// Gets Batch account endpoint.
        /// </summary>
        string AccountEndpoint { get; }

        /// <summary>
        /// Regenerates the access keys for the Batch account.
        /// </summary>
        /// <param name="keyType">The type if key to regenerate.</param>
        /// <return>Regenerated access keys for this Batch account.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccountKeys RegenerateKeys(AccountKeyType keyType);

        /// <summary>
        /// Gets the active job and job schedule quota for this Batch account.
        /// </summary>
        int ActiveJobAndJobScheduleQuota { get; }

        /// <return>The access keys for this Batch account.</return>
        Microsoft.Azure.Management.Batch.Fluent.BatchAccountKeys GetKeys();

        /// <summary>
        /// Gets the pool quota for this Batch account.
        /// </summary>
        int PoolQuota { get; }

        /// <summary>
        /// Gets applications in this Batch account, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Batch.Fluent.IApplication> Applications { get; }

        /// <summary>
        /// Gets the properties and status of any auto storage account associated with the Batch account.
        /// </summary>
        AutoStorageProperties AutoStorage { get; }

        /// <summary>
        /// Gets the core quota for this Batch account.
        /// </summary>
        int CoreQuota { get; }

        /// <summary>
        /// Gets the provisioned state of the resource.
        /// </summary>
        ProvisioningState ProvisioningState { get; }

        /// <summary>
        /// Synchronizes the storage account keys for this Batch account.
        /// </summary>
        void SynchronizeAutoStorageKeys();
    }
}