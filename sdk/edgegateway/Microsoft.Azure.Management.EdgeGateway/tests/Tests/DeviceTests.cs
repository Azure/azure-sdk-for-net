namespace EdgeGateway.Tests
{
    using Microsoft.Azure.Management.EdgeGateway.Models;
    using Xunit;
    using Xunit.Abstractions;
    using Microsoft.Azure.Management.EdgeGateway;
    using System.Linq;

    /// <summary>
    /// Contains the tests for device operations
    /// </summary>
    public class DeviceTests : EdgeGatewayTestBase
    {
        #region Constructor
        /// <summary>
        /// Initializes an instance to test device operations
        /// </summary>
        public DeviceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests create, update, get, list and delete device APIs
        /// </summary>
        [Fact]
        public void Test_ManageDeviceOperations()
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
            Client.Devices.Update(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, tags);

            // Delete a gateway resource
            Client.Devices.Delete(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            // Create an edge device
            DataBoxEdgeDevice edgeDevice = new DataBoxEdgeDevice();

            // Populate device properties as a Gateway resource
            edgeDevice.PopulateEdgeDeviceProperties();

            // Create a gateway resource
            edgeDevice.CreateOrUpdate(TestConstants.EdgeResourceName, Client, TestConstants.DefaultResourceGroupName);

        }

        /// <summary>
        /// Tests device admin password change
        /// </summary>
        [Fact]
        public void Test_DevicePasswordUpdate()
        {
            var asymmetricEncryptedSecret = Client.Devices.GetAsymmetricEncryptedSecretUsingActivationKey(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, "Password3", TestConstants.GatewayActivationKey);
            // Update the device admin password
            Client.Devices.CreateOrUpdateSecuritySettings(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, asymmetricEncryptedSecret);
        }

        #endregion Test Methods

    }
}

