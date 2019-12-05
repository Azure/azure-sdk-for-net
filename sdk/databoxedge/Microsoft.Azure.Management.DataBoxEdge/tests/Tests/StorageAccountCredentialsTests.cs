using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Xunit;
using Xunit.Abstractions;

namespace DataBoxEdge.Tests
{
    /// <summary>
    /// Contains the tests for storage account credential APIs
    /// </summary>
    public class StorageAccountCredentialsTests : DataBoxEdgeTestBase
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
            // There is a restriction that storage account name and SAC name has to be same. So the names are used interchanteable
            string storageAccountName = "databoxedgeutdst";
            //Create storage account credential
            AsymmetricEncryptedSecret encryptedSecret = Client.Devices.GetAsymmetricEncryptedSecret(TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, "EyIbt0QelBmm4ggkWsvQGaGaijYv/JBXIRl5ZR7pwgCJCkLYQmKY+H5RV4COGhbi01dBRIC1dNSF1sbJoeAL1Q==", TestConstants.EdgeDeviceCIK);
            StorageAccountCredential sac1 = TestUtilities.GetSACObject(encryptedSecret, storageAccountName);
            Client.StorageAccountCredentials.CreateOrUpdate(TestConstants.EdgeResourceName, storageAccountName, sac1, TestConstants.DefaultResourceGroupName);

            //Get storage account credential by name.
            Client.StorageAccountCredentials.Get(TestConstants.EdgeResourceName, storageAccountName, TestConstants.DefaultResourceGroupName);

            //List storage account credentials in the device
            string continuationToken = null;
            var storageCredentials = TestUtilities.ListStorageAccountCredentials(Client, TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName,out continuationToken);

            //List storage account credentials in the device
            Client.StorageAccountCredentials.Delete(TestConstants.EdgeResourceName, storageAccountName, TestConstants.DefaultResourceGroupName);

            //Create again as we want to keep the SAC object inresource
             sac1 = TestUtilities.GetSACObject(encryptedSecret, storageAccountName);
            Client.StorageAccountCredentials.CreateOrUpdate(TestConstants.EdgeResourceName, storageAccountName, sac1, TestConstants.DefaultResourceGroupName);

        }

        #endregion  Test Methods



    }
}

