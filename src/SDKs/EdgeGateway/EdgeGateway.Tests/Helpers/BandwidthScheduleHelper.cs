using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EdgeGateway.Tests
{
    public static partial class TestUtilities
    {

        /// <summary>
        /// Gets a bandwidth schedule object
        /// </summary>
        /// <returns>BandwidthSchedule</returns>
        public static BandwidthSchedule GetBWSObject()
        {

            string start = string.Format("{0}:{1}:{2}", 0, 0, 0);
            string stopTime = string.Format("{0}:{1}:{2}", 13, 59, 0);
            List<string> days = new List<string> { "Sunday", "Monday" };

            BandwidthSchedule bws = new BandwidthSchedule(start, stopTime, 100, days);
            return bws;
        }

        /// <summary>
        /// Gets the bandwidth schedules in device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<BandwidthSchedule> ListBandwidthSchedules(
            DataBoxEdgeManagementClient client,
             string deviceName,
            string resourceGroupName,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<BandwidthSchedule> scheduleList = client.BandwidthSchedules.ListByDataBoxEdgeDevice(deviceName, resourceGroupName);
            continuationToken = scheduleList.NextPageLink;
            return scheduleList;
        }

        /// <summary>
        /// Gets next page of bandwidth schedules in device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="nextLink"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<BandwidthSchedule> ListBandwidthSchedulesNext(
            DataBoxEdgeManagementClient client,
            string nextLink,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<BandwidthSchedule> scheduleList = client.BandwidthSchedules.ListByDataBoxEdgeDeviceNext(nextLink);
            continuationToken = scheduleList.NextPageLink;
            return scheduleList;
        }
    }
}

