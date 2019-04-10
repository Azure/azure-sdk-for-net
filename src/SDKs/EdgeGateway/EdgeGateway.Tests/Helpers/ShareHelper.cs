using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;

namespace EdgeGateway.Tests
{
    public static partial class TestUtilities
    {
        /// <summary>
        /// Gets an smb share object
        /// </summary>
        /// <param name="sacId"></param>
        /// <param name="userId"></param>
        /// <returns>Share</returns>
        public static Share GetSMBShareObject(string sacId, string userId)
        {
            Share share = new Share("Online", "Enabled", "SMB", dataPolicy: "Cloud");
            share.AzureContainerInfo = new AzureContainerInfo(sacId, "testContainersmb", "BlockBlob");
            share.UserAccessRights = new List<UserAccessRight>();
            share.UserAccessRights.Add(new UserAccessRight(userId, "Change"));
            return share;
        }

        /// <summary>
        /// Gets an nfs share object
        /// </summary>
        /// <param name="sacId"></param>
        /// <param name="clientId"></param>
        /// <returns>Share</returns>
        public static Share GetNFSShareObject(string sacId, string clientId)
        {
            Share share = new Share("Online", "Enabled", "NFS", dataPolicy: "Cloud");
            share.AzureContainerInfo = new AzureContainerInfo(sacId, "testContainernfs", "BlockBlob");
            share.ClientAccessRights = new List<ClientAccessRight>();
            share.ClientAccessRights.Add(new ClientAccessRight(clientId, "ReadWrite"));

            return share;
        }

        /// <summary>
        /// Gets shares in the device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns>List of shares</returns>
        public static IEnumerable<Share> ListShares(
            DataBoxEdgeManagementClient client,
             string deviceName,
            string resourceGroupName,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<Share> shares = client.Shares.ListByDataBoxEdgeDevice(deviceName, resourceGroupName);
            continuationToken = shares.NextPageLink;
            return shares;
        }

        /// <summary>
        /// Gets next page of shares
        /// </summary>
        /// <param name="client"></param>
        /// <param name="nextLink"></param>
        /// <param name="continuationToken"></param>
        /// <returns>List of shares</returns>
        public static IEnumerable<Share> ListSharesNext(
            DataBoxEdgeManagementClient client,
            string nextLink,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<Share> shares = client.Shares.ListByDataBoxEdgeDeviceNext(nextLink);
            continuationToken = shares.NextPageLink;
            return shares;
        }
    }
}