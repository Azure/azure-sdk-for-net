using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;

namespace EdgeGateway.Tests
{
    public static partial class TestUtilities
    {

        /// <summary>
        /// Creates or updates given edge resource
        /// </summary>
        /// <param name="device"></param>
        /// <param name="deviceName"></param>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <returns></returns>
        public static DataBoxEdgeDevice CreateOrUpdate(
            this DataBoxEdgeDevice device,
            string deviceName,
            DataBoxEdgeManagementClient client,
            string resourceGroupName)
        {
            //Create a databox edge/gateway device
            client.Devices.CreateOrUpdate(deviceName,
                device,
                resourceGroupName
                );

            //Returns a databox edge/gateway device
            return client.Devices.Get(deviceName, resourceGroupName);
        }

        /// <summary>
        /// Populates the values of a gateway device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static void PopulateGatewayDeviceProperties(this DataBoxEdgeDevice device)
        {
            device.Location = TestConstants.DefaultResourceLocation;
            device.Sku = new Sku("Gateway", "standard");
            device.Tags = new Dictionary<string, string>();
            device.Tags.Add("tag1", "value1");
            device.Tags.Add("tag2", "value2");
        }

        /// <summary>
        /// Populates the values of a edge device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static void PopulateEdgeDeviceProperties(this DataBoxEdgeDevice device)
        {
            device.Location = TestConstants.DefaultResourceLocation;
            device.Sku = new Sku("Edge", "standard");
            device.Tags = new Dictionary<string, string>();
            device.Tags.Add("tag1", "value1");
            device.Tags.Add("tag2", "value2");
        }


        /// <summary>
        /// Gets resources by resource group
        /// </summary>
        /// <param name="client"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<DataBoxEdgeDevice> GetResourcesByResourceGroup(
            DataBoxEdgeManagementClient client,
            string resourceGroupName, 
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<DataBoxEdgeDevice> resourceList = client.Devices.ListByResourceGroup(resourceGroupName);
            continuationToken = resourceList.NextPageLink;
            return resourceList;
        }

        /// <summary>
        /// Gets next page in resource group
        /// </summary>
        /// <param name="client"></param>
        /// <param name="nextLink"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<DataBoxEdgeDevice> GetResourcesByResourceGroupNext(
            DataBoxEdgeManagementClient client,
            string nextLink,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<DataBoxEdgeDevice> resourceList = client.Devices.ListByResourceGroupNext(nextLink);
            continuationToken = resourceList.NextPageLink;
            return resourceList;
        }

        /// <summary>
        /// Gets resources by subscription
        /// </summary>
        /// <param name="client"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<DataBoxEdgeDevice> GetResourcesBySubscription(
            DataBoxEdgeManagementClient client,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<DataBoxEdgeDevice> resourceList = client.Devices.ListBySubscription();
            continuationToken = resourceList.NextPageLink;
            return resourceList;
        }

        /// <summary>
        /// Gets next page of resources in subscription
        /// </summary>
        /// <param name="client"></param>
        /// <param name="nextLink"></param>
        /// <param name="continuationToken"></param>
        /// <returns></returns>
        public static IEnumerable<DataBoxEdgeDevice> GetResourcesBySubscriptionNext(
            DataBoxEdgeManagementClient client,
            string nextLink,
            out string continuationToken)
        {
            //Create a databox edge/gateway device
            IPage<DataBoxEdgeDevice> resourceList = client.Devices.ListBySubscriptionNext(nextLink);
            continuationToken = resourceList.NextPageLink;
            return resourceList;
        }
    }
}
