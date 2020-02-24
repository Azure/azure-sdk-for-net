using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DataBoxEdge.Tests
{
    /// <summary>
    /// Contains the tests for storage account APIs
    /// </summary>
    public class StorageAccountTests : DataBoxEdgeTestBase
    {
        #region Constructor
        /// <summary>
        /// Creates an instance to test storage account APIs
        /// </summary>
        public StorageAccountTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests storage APIs
        /// </summary>
        [Fact]
        public void Test_StorageOperations()
        {
            string sacName = "databoxedgeutdst";
            // Get SAC details
            string sacId = null;
            var sac = Client.StorageAccountCredentials.Get(TestConstants.EdgeResourceName, sacName, TestConstants.DefaultResourceGroupName);
            if (sac != null)
            {
                sacId = sac.Id;
            }
            var storageAccount = new StorageAccount(storageAccountStatus: StorageAccountStatus.OK, dataPolicy: DataPolicy.Cloud, storageAccountCredentialId: sacId, description: "It is a simple storage account");

            // Create storage account
            Client.StorageAccounts.CreateOrUpdate(TestConstants.EdgeResourceName, "storageaccount1", storageAccount, TestConstants.DefaultResourceGroupName);

            // Get storage account
            storageAccount = Client.StorageAccounts.Get(TestConstants.EdgeResourceName, "storageaccount1", TestConstants.DefaultResourceGroupName);

            //  // List storage account in the device
            string continuationToken = null;
            IEnumerable<StorageAccount> storageAccounts = TestUtilities.ListStorageAccounts(Client, TestConstants.EdgeResourceName, TestConstants.DefaultResourceGroupName, out continuationToken);

            //  // Delete storage account
            Client.StorageAccounts.Delete(TestConstants.EdgeResourceName, "storageaccount1", TestConstants.DefaultResourceGroupName);

            var storageAccount2 = new StorageAccount(storageAccountStatus: StorageAccountStatus.OK, dataPolicy: DataPolicy.Cloud, storageAccountCredentialId: sacId, description: "It is a simple storage account");

            // Create storage account
            Client.StorageAccounts.CreateOrUpdate(TestConstants.EdgeResourceName, "storageaccount2", storageAccount2, TestConstants.DefaultResourceGroupName);

        }

        #endregion Test Methods
    }
}
