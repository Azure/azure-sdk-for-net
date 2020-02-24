using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;

namespace DataBoxEdge.Tests
{
    /// <summary>
    /// Contains the test helper methods
    /// </summary>
    public static partial class TestUtilities
    {
        /// <summary>
        /// Gets alerts int the device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<Alert> ListAlerts(
            DataBoxEdgeManagementClient client,
            string deviceName,
            string resourceGroupName,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<Alert> alertList = client.Alerts.ListByDataBoxEdgeDevice(deviceName, resourceGroupName);
            continuationToken = alertList.NextPageLink;
            return alertList;
        }

        /// <summary>
        /// Gets next page of alerts in device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="nextLink"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<Alert> ListAlertsNext(
            DataBoxEdgeManagementClient client,
            string nextLink,
            out string continuationToken)
        {
            // Gets the alert list
            IPage<Alert> alertList = client.Alerts.ListByDataBoxEdgeDeviceNext(nextLink);
            continuationToken = alertList.NextPageLink;
            return alertList;
        }
    }
}
