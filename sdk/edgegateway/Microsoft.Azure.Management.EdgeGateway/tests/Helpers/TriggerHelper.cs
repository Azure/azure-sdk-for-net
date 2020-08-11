using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;

namespace EdgeGateway.Tests
{
    public static partial class TestUtilities
    {
        /// <summary>
        /// Gets a file event trigger object
        /// </summary>

        /// <returns>FileEventTrigger</returns>
        public static FileEventTrigger GetFileTriggerObject()
        {
            string sourceShareId = "/subscriptions/db4e2fdb-6d80-4e6e-b7cd-736098270664/resourcegroups/demo-resources/providers/microsoft.databoxedge/databoxedgedevices/edge-demo-device/shares/localshare";
            string roleId = "/subscriptions/db4e2fdb-6d80-4e6e-b7cd-736098270664/resourceGroups/demo-resources/providers/Microsoft.DataBoxEdge/DataBoxEdgeDevices/edge-demo-device/roles/IotRole";
            FileEventTrigger fileEventTrigger = new FileEventTrigger(new FileSourceInfo(sourceShareId), new RoleSinkInfo(roleId), customContextTag: "fileEventTrigger");
            return fileEventTrigger;
        }

        /// <summary>
        /// Gets a periodic event trigger object
        /// </summary>

        /// <returns>PeriodicTimerEventTrigger</returns>
        public static PeriodicTimerEventTrigger GetPeriodicTriggerObject()
        {
            string roleId = "/subscriptions/db4e2fdb-6d80-4e6e-b7cd-736098270664/resourceGroups/demo-resources/providers/Microsoft.DataBoxEdge/DataBoxEdgeDevices/edge-demo-device/roles/IotRole";

            PeriodicTimerSourceInfo sourceInfo = new PeriodicTimerSourceInfo(DateTime.UtcNow.Date, "0.1:0:0", "trigger-periodicTrigger");
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
