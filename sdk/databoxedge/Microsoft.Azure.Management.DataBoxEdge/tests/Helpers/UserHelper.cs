using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;

namespace DataBoxEdge.Tests
{
    public static partial class TestUtilities
    {

        /// <summary>
        /// Gets users in the device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<User> ListUsers(
            DataBoxEdgeManagementClient client,
             string deviceName,
            string resourceGroupName,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<User> userList = client.Users.ListByDataBoxEdgeDevice(deviceName, resourceGroupName);
            continuationToken = userList.NextPageLink;
            return userList;
        }

        /// <summary>
        /// Gets next page of users
        /// </summary>
        /// <param name="client"></param>
        /// <param name="nextLink"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<User> ListUsersNext(
            DataBoxEdgeManagementClient client,
            string nextLink,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<User> userList = client.Users.ListByDataBoxEdgeDeviceNext(nextLink);
            continuationToken = userList.NextPageLink;
            return userList;
        }
    }
}
