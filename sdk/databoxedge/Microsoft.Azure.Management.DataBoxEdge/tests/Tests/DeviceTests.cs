namespace DataBoxEdge.Tests
{
    using Microsoft.Azure.Management.DataBoxEdge;
    using Microsoft.Azure.Management.DataBoxEdge.Models;
    using RestSharp;
    using System.Linq;
    using Xunit;
    using Xunit.Abstractions;

    /// <summary>
    /// Contains the tests for device operations
    /// </summary>
    public class DeviceTests : DataBoxEdgeTestBase
    {
        #region Constants
        private const int StandardSizeOfCIK = 128;

        private const string CIKName = "ase-cik";
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes an instance to test device operations
        /// </summary>
        public DeviceTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Steps to Register an ASE Resource
        /// 1. Create MSI enabled resource
        /// 2. Generate CIK
        /// 3. Save CIK in the keyVault
        /// 4. Generate Activation Key and give CIK as input, generated at step 3 
        /// </summary>
        [Fact]
        public void Test_DeviceRegistrationOperation()
        {
            // Step 1. Create Edge Resource Object
            DataBoxEdgeDevice device = new DataBoxEdgeDevice();
            device.PopulateEdgeDeviceProperties();

            // Step 2. Enabel System Assigned MSI and Create Resource
            device.Identity = new ResourceIdentity(type: "SystemAssigned");
            device.CreateOrUpdate(TestConstants.EdgeResourceName, Client, TestConstants.DefaultResourceGroupName);

            // Step 3. GenerateCIK
            var cik = Client.Devices.GenerateCIK();
            TestUtilities.SetSecretToKeyVault(TestConstants.EdgeDeviceKeyVault, CIKName, cik);

            var secret = TestUtilities.GetSecretFromKeyVault(TestConstants.EdgeDeviceKeyVault, CIKName);

            TestUtilities.DeleteSecretFromKeyVault(TestConstants.EdgeDeviceKeyVault, CIKName);

            // Step 4: GenerateActivationKey
            var activationKey = Client.Devices.GenerateActivationKey(TestConstants.DefaultResourceGroupName, TestConstants.EdgeResourceName,
            TestConstants.DefaultResourceLocation, TestConstants.SubscriptionId, cik);
        }

        private void GenerateAndSaveCIKIn()
        {
            // GenerateAndSaveCIK()
            // CreateKeyvault()
            // SetKeyVault()
            // SaveSecretToKeyVault()
            // DeleteSecret()
        }

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
            Client.Devices.Update(TestConstants.GatewayResourceName, new DataBoxEdgeDevicePatch() { Tags = tags }, TestConstants.DefaultResourceGroupName);

            // Delete a gateway resource
            Client.Devices.Delete(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName);

            // Create an edge device
            DataBoxEdgeDevice edgeDevice = new DataBoxEdgeDevice();

            // Populate device properties as a Gateway resource
            edgeDevice.PopulateEdgeDeviceProperties();

            // Create an edge resource
            edgeDevice.CreateOrUpdate(TestConstants.EdgeResourceName, Client, TestConstants.DefaultResourceGroupName);

        }

        /// <summary>
        /// Tests device admin password change
        /// </summary>
        [Fact]
        public void Test_DevicePasswordUpdate()
        {
            var asymmetricEncryptedSecret = Client.Devices.GetAsymmetricEncryptedSecret(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, "Password3", TestConstants.EdgeDeviceCIK);
            // Update the device admin password
            Client.Devices.CreateOrUpdateSecuritySettings(TestConstants.EdgeResourceName, new SecuritySettings(asymmetricEncryptedSecret), TestConstants.DefaultResourceGroupName);
        }

        #endregion
    }
}

