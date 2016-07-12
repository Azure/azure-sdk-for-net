using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using System;

namespace Microsoft.Azure.Management.V2.Storage
{
    public interface IStorageAccount :
        IRefreshable<IStorageAccount>,
        IUpdatable<StorageAccount.Update.IUpdate>,
        IWrapper<Management.Storage.Models.StorageAccount>
    {
        AccountStatuses AccountStatuses { get; }

        Sku Sku { get; }

        Kind? Kind { get; }

        DateTime? CreationTime { get; }

        CustomDomain CustomDomain { get; }

        DateTime? LastGeoFailoverTime { get; }

        ProvisioningState? ProvisioningState { get; }

        PublicEndpoints EndPoints { get; }

        Encryption Encryption { get; }

        AccessTier? AccessTier { get; }
    }
}
