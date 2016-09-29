// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Fluent.Batch
{

    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    /// <summary>
    /// An immutable client-side representation of an Azure batch account.
    /// </summary>
    public interface IBatchAccount  :
        IGroupableResource,
        IRefreshable<Microsoft.Azure.Management.Fluent.Batch.IBatchAccount>,
        IUpdatable<Microsoft.Azure.Management.Fluent.Batch.BatchAccount.Update.IUpdate>,
        IWrapper<Microsoft.Azure.Management.Batch.Models.BatchAccountInner>
    {
        /// <returns>the provisioned state of the resource. Possible values include:</returns>
        /// <returns>'Invalid', 'Creating', 'Deleting', 'Succeeded', 'Failed', 'Cancelled'</returns>
        Microsoft.Azure.Management.Batch.Models.ProvisioningState ProvisioningState { get; }

        /// <returns>Get the accountEndpoint value.</returns>
        string AccountEndpoint { get; }

        /// <returns>the properties and status of any auto storage account associated with</returns>
        /// <returns>the account</returns>
        Microsoft.Azure.Management.Batch.Models.AutoStorageProperties AutoStorage { get; }

        /// <returns>the core quota for this BatchAccount account</returns>
        int CoreQuota { get; }

        /// <returns>the pool quota for this BatchAccount account</returns>
        int PoolQuota { get; }

        /// <returns>the active job and job schedule quota for this BatchAccount account</returns>
        int ActiveJobAndJobScheduleQuota { get; }

        /// <returns>the access keys for this batch account</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccountKeys GetKeys ();

        /// <summary>
        /// Regenerates the access keys for batch account.
        /// </summary>
        /// <param name="keyType">keyType either primary or secondary key to be regenerated</param>
        /// <returns>the access keys for this batch account</returns>
        Microsoft.Azure.Management.Fluent.Batch.BatchAccountKeys RegenerateKeys (AccountKeyType keyType);

        /// <summary>
        /// Synchronize the storage account keys for batch account.
        /// </summary>
        void SynchronizeAutoStorageKeys ();

        /// <returns>the application in this batch account.</returns>
        System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.Fluent.Batch.IApplication> Applications { get; }

    }
}