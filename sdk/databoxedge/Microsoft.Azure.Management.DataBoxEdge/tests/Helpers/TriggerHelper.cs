using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;

namespace DataBoxEdge.Tests
{
    public static partial class TestUtilities
    {
        /// <summary>
        /// Gets a file event trigger object
        /// </summary>

        /// <returns>FileEventTrigger</returns>
        public static FileEventTrigger GetFileTriggerObject(string localShareId, string roleId)
        {
            FileEventTrigger fileEventTrigger = new FileEventTrigger(new FileSourceInfo(localShareId), new RoleSinkInfo(roleId), customContextTag: "fileEventTrigger");
            return fileEventTrigger;
        }

        /// <summary>
        /// Gets a periodic event trigger object
        /// </summary>

        /// <returns>PeriodicTimerEventTrigger</returns>
        public static PeriodicTimerEventTrigger GetPeriodicTriggerObject(string roleId)
        {
            PeriodicTimerSourceInfo sourceInfo = new PeriodicTimerSourceInfo(DateTime.UtcNow.Date.AddDays(1), "0.1:0:0", "trigger-periodicTrigger");
            PeriodicTimerEventTrigger periodicTimerEventTrigger = new PeriodicTimerEventTrigger(sourceInfo, new RoleSinkInfo(roleId), customContextTag: "periodicTrigger");
            return periodicTimerEventTrigger;
        }

        /// <summary>
        /// Gets triggers in the device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns>List of roles</returns>
        public static IEnumerable<Trigger> ListTriggers(
            DataBoxEdgeManagementClient client,
             string deviceName,
            string resourceGroupName,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<Trigger> triggers = client.Triggers.ListByDataBoxEdgeDevice(deviceName, resourceGroupName);
            continuationToken = triggers.NextPageLink;
            return triggers;
        }
    }
}
