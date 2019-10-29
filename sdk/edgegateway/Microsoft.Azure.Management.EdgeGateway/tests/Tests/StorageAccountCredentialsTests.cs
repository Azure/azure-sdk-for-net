using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Xunit;
using Xunit.Abstractions;

namespace EdgeGateway.Tests
{
    /// <summary>
    /// Contains the tests for storage account credential APIs
    /// </summary>
    public class StorageAccountCredentialsTests : EdgeGatewayTestBase
    {
        #region Constructor

        /// <summary>
        /// Creates an instance to test storage account credential APIs
        /// </summary>
        public StorageAccountCredentialsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests storage account credential APIs
        /// </summary>
        [Fact]
        public void Test_SACManagement()
        {
            //Create storage account credential
            AsymmetricEncryptedSecret encryptedSecret = Client.Devices.GetAsymmetricEncryptedSecretUsingActivationKey(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, "EyIbt0QelBmm4ggkWsvQGaGaijYv/JBXIRl5ZR7pwgCJCkLYQmKY+H5RV4COGhbi01dBRIC1dNSF1sbJoeAL1Q==", TestConstants.GatewayActivationKey);
            StorageAccountCredential sac1 = TestUtilities.GetSACObject(encryptedSecret, "sac1");
            Client.StorageAccountCredentials.CreateOrUpdate(TestConstants.GatewayResourceName, "sac1", sac1, TestConstants.DefaultResourceGroupName);

            StorageAccountCredential sac2 = TestUtilities.GetSACObject(encryptedSecret, "sac2");
            Client.StorageAccountCredentials.CreateOrUpdate(TestConstants.GatewayResourceName, "sac2", sac2, TestConstants.DefaultResourceGroupName);

            //Get storage account credential by name.
            Client.StorageAccountCredentials.Get(TestConstants.GatewayResourceName, "sac1", TestConstants.DefaultResourceGroupName);

            //List storage account credentials in the device
            string continuationToken = null;
            var storageCredentials = TestUtilities.ListStorageAccountCredentials(Client, TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName,out continuationToken);

            //List storage account credentials in the device
            Client.StorageAccountCredentials.Delete(TestConstants.GatewayResourceName, "sac2", TestConstants.DefaultResourceGroupName);

        }

        #endregion  Test Methods



    }
}

