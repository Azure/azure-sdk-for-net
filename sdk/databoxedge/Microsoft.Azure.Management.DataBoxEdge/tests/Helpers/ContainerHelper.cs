using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;

namespace DataBoxEdge.Tests
{
    public static partial class TestUtilities
    {

        /// <summary>
        /// Gets containers in the storage account
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns>List of shares</returns>
        public static IEnumerable<Container> ListContainers(
            DataBoxEdgeManagementClient client,
             string deviceName,
            string storageAccountName,
            string resourceGroupName,
            out string continuationToken)
        {
            IPage<Container> containers = client.Containers.ListByStorageAccount(deviceName, storageAccountName, resourceGroupName);
            continuationToken = containers.NextPageLink;
            return containers;
        }
    }
}
