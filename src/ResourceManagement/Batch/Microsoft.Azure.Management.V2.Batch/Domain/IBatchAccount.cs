/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Batch
{

    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Batch.BatchAccount.Update;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Management.Batch.Models;

    /// <summary>
    /// An immutable client-side representation of an Azure batch account.
    /// </summary>
    public interface IBatchAccount  :
        IGroupableResource,
        IRefreshable<IBatchAccount>,
        IUpdatable<IUpdate>,
        IWrapper<AccountResourceInner>
    {
        /// <returns>the provisioned state of the resource. Possible values include:</returns>
        /// <returns>'Invalid', 'Creating', 'Deleting', 'Succeeded', 'Failed', 'Cancelled'</returns>
        AccountProvisioningState? ProvisioningState { get; }

        /// <returns>Get the accountEndpoint value.</returns>
        string AccountEndpoint { get; }

        /// <returns>the properties and status of any auto storage account associated with</returns>
        /// <returns>the account</returns>
        AutoStorageProperties AutoStorage { get; }

        /// <returns>the core quota for this BatchAccount account</returns>
        int? CoreQuota { get; }

        /// <returns>the pool quota for this BatchAccount account</returns>
        int? PoolQuota { get; }

        /// <returns>the active job and job schedule quota for this BatchAccount account</returns>
        int? ActiveJobAndJobScheduleQuota { get; }

        /// <returns>the access keys for this batch account</returns>
        BatchAccountKeys Keys ();

        /// <returns>the access keys for this batch account</returns>
        BatchAccountKeys RefreshKeys ();

        /// <summary>
        /// Regenerates the access keys for batch account.
        /// </summary>
        /// <param name="keyType">keyType either primary or secondary key to be regenerated</param>
        /// <returns>the access keys for this batch account</returns>
        BatchAccountKeys RegenerateKeys (AccountKeyType keyType);

        /// <summary>
        /// Synchronize the storage account keys for batch account.
        /// </summary>
        void SynchronizeAutoStorageKeys ();

    }
}