using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;

namespace DataBoxEdge.Tests
{
    public static partial class TestUtilities
    {
        /// <summary>
        /// Gets an smb share object
        /// </summary>
        /// <param name="sacId"></param>
        /// <param name="userId"></param>
        /// <returns>Share</returns>
        public static Share GetSMBShareObject(string sacId, string userId, string dataPolicy = DataPolicy.Cloud)
        {
            Share share = new Share(ShareStatus.OK, MonitoringStatus.Enabled, ShareAccessProtocol.SMB, dataPolicy: DataPolicy.Cloud);
            if (dataPolicy != DataPolicy.Local)
                share.AzureContainerInfo = new AzureContainerInfo(sacId, "testContainersmb", AzureContainerDataFormat.BlockBlob);
            share.UserAccessRights = new List<UserAccessRight>();
            share.UserAccessRights.Add(new UserAccessRight(userId, ShareAccessType.Change));
            return share;
        }

        /// <summary>
        /// Gets an nfs share object
        /// </summary>
        /// <param name="sacId"></param>
        /// <param name="clientId"></param>
        /// <returns>Share</returns>
        public static Share GetNFSShareObject(string sacId, string clientId, string dataPolicy = DataPolicy.Cloud)
        {
            Share share = new Share(ShareStatus.OK, MonitoringStatus.Enabled, ShareAccessProtocol.NFS, dataPolicy: dataPolicy);
            if (dataPolicy != DataPolicy.Local)
                share.AzureContainerInfo = new AzureContainerInfo(sacId, "testContainernfs", AzureContainerDataFormat.BlockBlob);
            share.ClientAccessRights = new List<ClientAccessRight>();
            share.ClientAccessRights.Add(new ClientAccessRight(clientId, ClientPermissionType.ReadWrite));

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
            IPage<Share> shares = client.Shares.ListByDataBoxEdgeDeviceNext(nextLink);
            continuationToken = shares.NextPageLink;
            return shares;
        }
    }
}