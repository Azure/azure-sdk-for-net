using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;

namespace DataBoxEdge.Tests
{
    public static partial class TestUtilities
    {

        /// <summary>
        /// Gets storage accounts in the device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns>List of shares</returns>
        public static IEnumerable<StorageAccount> ListStorageAccounts(
            DataBoxEdgeManagementClient client,
             string deviceName,
            string resourceGroupName,
            out string continuationToken)
        {
            IPage<StorageAccount> storageAccounts = client.StorageAccounts.ListByDataBoxEdgeDevice(deviceName, resourceGroupName);
            continuationToken = storageAccounts.NextPageLink;
            return storageAccounts;
        }
    }
}
