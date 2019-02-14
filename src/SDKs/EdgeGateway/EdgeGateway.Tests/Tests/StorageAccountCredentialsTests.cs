using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Management.EdgeGateway;
using Microsoft.Azure.Management.EdgeGateway.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;

namespace EdgeGateway.Tests
{
    public class StorageAccountCredentialsTests : EdgeGatewayTestBase
    {
        #region Constructor
        public StorageAccountCredentialsTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        [Fact]
        public void Test_SACManagement()
        {
            //Create storage account credential
            AsymmetricEncryptedSecret encryptedSecret = Client.Devices.GetAsymmetricEncryptedSecret(TestConstants.GatewayResourceName, TestConstants.DefaultResourceGroupName, "Password1", TestConstants.ActivationKey);
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
            Client.StorageAccountCredentials.Delete(TestConstants.GatewayResourceName, "sac1", TestConstants.DefaultResourceGroupName);

        }

        #endregion  Test Methods



    }
}
