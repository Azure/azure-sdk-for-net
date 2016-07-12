using Microsoft.Azure.Management.Storage.Models;
using System;

namespace Microsoft.Azure.Management.V2.Storage
{
    public interface IStorageAccount
    {
        AccountStatus accountStatuses();

        Sku sku();

        Kind kind();

        DateTime creationTime();

        CustomDomain customDomain();

        DateTime lastGeoFailoverTime();

        ProvisioningState provisioningState();

        PublicEndpoints endPoints();

        Encryption encryption();

        AccessTier accessTier();
    }
}
