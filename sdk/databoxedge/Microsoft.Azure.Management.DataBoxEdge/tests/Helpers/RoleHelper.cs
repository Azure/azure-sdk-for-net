using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBoxEdge.Tests
{
    public static partial class TestUtilities
    {
        /// <summary>
        /// Gets an iot role object
        /// </summary>
        /// <param name="iotDeviceSecret"></param>
        /// <param name="iotEdgeDeviceSecret"></param>
        /// <returns>IoTRole</returns>
        public static IoTRole GetIoTRoleObject(AsymmetricEncryptedSecret iotDeviceSecret, AsymmetricEncryptedSecret iotEdgeDeviceSecret)
        {
            Authentication authentication = new Authentication() { SymmetricKey = new SymmetricKey(iotDeviceSecret) };
            IoTDeviceInfo ioTDeviceInfo = new IoTDeviceInfo("iotdevice", "iothub.azure-devices.net", authentication: authentication);

            Authentication edgeAuthentication = new Authentication() { SymmetricKey = new SymmetricKey(iotEdgeDeviceSecret) };
            IoTDeviceInfo ioTEdgeDeviceInfo = new IoTDeviceInfo("iotdevice", "iothub.azure-devices.net", authentication: edgeAuthentication);

            IoTRole ioTRole = new IoTRole("Linux", ioTDeviceInfo, ioTEdgeDeviceInfo, "Enabled");
            return ioTRole;

        }
        
        /// <summary>
        /// Gets roles in the device
        /// </summary>
        /// <param name="client"></param>
        /// <param name="deviceName"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns>List of roles</returns>
        public static IEnumerable<Role> ListRoles(
            DataBoxEdgeManagementClient client,
             string deviceName,
            string resourceGroupName,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<Role> roles = client.Roles.ListByDataBoxEdgeDevice(deviceName, resourceGroupName);
            continuationToken = roles.NextPageLink;
            return roles;
        }

    }
}
