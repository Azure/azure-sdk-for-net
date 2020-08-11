using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;

namespace DataBoxEdge.Tests
{
    public static partial class TestUtilities
    {
        /// <summary>
        /// Gets a sac object
        /// </summary>
        /// <param name="secret"></param>
        /// <param name="sacName"></param>
        /// <returns>StorageAccountCredential</returns>
        public static StorageAccountCredential GetSACObject(AsymmetricEncryptedSecret secret,string sacName)
        {
            StorageAccountCredential sac = new StorageAccountCredential(sacName, "Disabled", "BlobStorage", userName: sacName, accountKey: secret);

            return sac;
        }

        /// <summary>
        /// Gets storage account credentials in the device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns>List of SACs</returns>
        public static IEnumerable<StorageAccountCredential> ListStorageAccountCredentials(
            DataBoxEdgeManagementClient client,
             string deviceName,
            string resourceGroupName,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<StorageAccountCredential> sacList = client.StorageAccountCredentials.ListByDataBoxEdgeDevice(deviceName, resourceGroupName);
            continuationToken = sacList.NextPageLink;
            return sacList;
        }

        /// <summary>
        /// Gets next page of storage account credentials
        /// </summary>
        /// <param name="client"></param>
        /// <param name="nextLink"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<StorageAccountCredential> ListStorageAccountCredentialsNext(
            DataBoxEdgeManagementClient client,
            string nextLink,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<StorageAccountCredential> sacList = client.StorageAccountCredentials.ListByDataBoxEdgeDeviceNext(nextLink);
            continuationToken = sacList.NextPageLink;
            return sacList;
        }
    }
}
