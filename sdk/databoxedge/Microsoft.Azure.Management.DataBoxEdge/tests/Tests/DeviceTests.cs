namespace DataBoxEdge.Tests
{
    using Azure.Identity;
    using Azure.Security.KeyVault.Secrets;
    using Microsoft.Azure.Management.DataBoxEdge;
    using Microsoft.Azure.Management.DataBoxEdge.Models;
    using RestSharp;
    using System;
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
            // Step 1. Create MSI Enabled Edge Resource
            DataBoxEdgeDevice device = new DataBoxEdgeDevice();
            device.PopulateEdgeDeviceProperties();
            device.Identity = new ResourceIdentity(type: "SystemAssigned");
            var name = TestConstants.EdgeResourceName;
            device.CreateOrUpdate(name, Client, TestConstants.DefaultResourceGroupName);
            
            // Step 2. GenerateCIK
            var generatedCIK = Client.Devices.GenerateCIK();

            /*
             * Note:
             * 1. UnComment following Code from Step:3 to Step 6
             * 2. Follow the Doc to create the KeyVault: https://docs.microsoft.com/en-us/azure/key-vault/keys/quick-create-template?tabs=CLI
             * 3. KeyVault must be in the same subscription and resource group as the ASE Resource
             * 4. Set KeyVault Access policies for the MSI, which gets created at step 1 and has the same name as resource
             *    Doc to set the AccessPolicies: https://docs.microsoft.com/en-us/azure/key-vault/general/assign-access-policy?tabs=azure-portal
             *    Note: Only Get and Set Permissions need to be set
             */

            /*
            // Step 3: Create KeyVault
            // Please follow KeyVault documentation to create keyvualt:
            // https://docs.microsoft.com/en-us/azure/key-vault/keys/quick-create-template?tabs=CLI
            var keyVaultUri = "https://test-sdk-keyvault-123.vault.azure.net";
            var keyVaultClient = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

            // Step 4: Save the CIK in KeyVault
            keyVaultClient.SetSecret(CIKName, generatedCIK);

            // Step 5: Update KeyVault ClientSecretStoreId and ClientSecretStoreUrl
            string ClientSecretStoreId = "/subscriptions/706c087b-4c6c-46bf-8adf-766ae266d5bf/resourceGroups/demo-resources/providers/Microsoft.KeyVault/vaults/test-sdk-keyvault-123";
            string ClientSecretStoreUrl = "https://test-sdk-keyvault-123.vault.azure.net";
            string ChannelIntegrityKeyName = CIKName;
            string ChannelIntergrityKeyVersion = keyVaultClient.GetSecret(CIKName).Value.Id.Segments[3];
            var patch = new DataBoxEdgeDeviceExtendedInfoPatch(ClientSecretStoreId, ClientSecretStoreUrl, ChannelIntegrityKeyName, ChannelIntergrityKeyVersion);
            var updatedExtendedInfo = Client.Devices.UpdateExtendedInformation(name, patch, TestConstants.DefaultResourceGroupName);

            // Step 6: GenerateActivationKey
            var activationKey = Client.Devices.GenerateActivationKey(TestConstants.DefaultResourceGroupName, name, generatedCIK);

            // Delete the CIK on the KeyVault (Note: Required step only for the test case)
            TestUtilities.DeleteSecretFromKeyVault(TestConstants.EdgeDeviceKeyVault, CIKName);*/
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
            device.Identity = new ResourceIdentity(type: "SystemAssigned");

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

