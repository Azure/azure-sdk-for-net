namespace EdgeGateway.Tests
{
    using Microsoft.Azure.Management.EdgeGateway.Models;
    using Xunit;
    using Xunit.Abstractions;
    using Microsoft.Azure.Management.EdgeGateway;
    using System.Linq;

    public class DeviceTests : EdgeGatewayTestBase
    {
        #region Constructor
        public DeviceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        [Fact]
        public void Test_GatewayDeviceOperations()
        {

            DataBoxEdgeDevice device = new DataBoxEdgeDevice();

            // Populate device properties as a Gateway resource
            device.PopulateGatewayDeviceProperties();

            // Create a gateway resource
            device.CreateOrUpdate(TestConstants.GatewayResourceName, Client, TestConstants.DefaultResourceGroupName);

            // Get a device by name
            var gatewayDevice = Client.Devices.Get(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            string contiuationToken = null;
            // Get devices in the resource group
            var devicesInResourceGroup = TestUtilities.GetResourcesByResourceGroup(Client, TestConstants.DefaultResourceGroupName, out contiuationToken);

            if (contiuationToken != null)
            {
                // Get the remaining devices in the resource group
                devicesInResourceGroup.ToList().AddRange(TestUtilities.GetResourcesByResourceGroupNext(Client, contiuationToken, out contiuationToken));
            }

            contiuationToken = null;
            
            // Get all devices in subscription
            var devicesInSubscription = TestUtilities.GetResourcesBySubscription(Client, out contiuationToken);

            if (contiuationToken != null)
            {
                // Get the remaining devices in the subscription
                devicesInSubscription.ToList().AddRange(TestUtilities.GetResourcesBySubscriptionNext(Client, contiuationToken, out contiuationToken));
            }

            // Get the tags to be updated to resource
            var tags = device.GetTags();

            // Update tags in the resource
            DataBoxEdgeDevicePatch dataBoxEdgeDevicePatch = new DataBoxEdgeDevicePatch(tags);
            Client.Devices.Update(TestConstants.GatewayResourceName, dataBoxEdgeDevicePatch, TestConstants.DefaultResourceGroupName);

            // Delete a gateway resource
            Client.Devices.Delete("test-gateway-resource-123", "anponnet-rg");

        }

        #endregion Test Methods

    }
}
