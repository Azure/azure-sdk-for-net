using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace DataBoxEdge.Tests
{
    /// <summary>
    /// Contains the tests for storage account APIs
    /// </summary>
    public class ContainerTests : DataBoxEdgeTestBase
    {
        #region Constructor
        /// <summary>
        /// Creates an instance to test storage account APIs
        /// </summary>
        public ContainerTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper) { }

        #endregion Constructor

        #region Test Methods

        /// <summary>
        /// Tests storage APIs
        /// </summary>
        [Fact]
        public void Test_ContainerOperations()
        {
            string storageAccountName = TestConstants.TestStorageAccountName;
            string containerName = "containertest1";

            // Get storage account details
            string storageAccountId = null;
            var storageAccount = Client.StorageAccounts.Get(TestConstants.EdgeResourceName, storageAccountName, TestConstants.DefaultResourceGroupName);
            if (storageAccount != null)
            {
                storageAccountId = storageAccount.Id;
            }

            var container = new Container(AzureContainerDataFormat.BlockBlob);
            // Create container
            Client.Containers.CreateOrUpdate(TestConstants.EdgeResourceName, storageAccountName, containerName, container, TestConstants.DefaultResourceGroupName);

            // Get container
            container = Client.Containers.Get(TestConstants.EdgeResourceName, storageAccountName, containerName, TestConstants.DefaultResourceGroupName);

            //  // List containers in the storage account
            string continuationToken = null;
            IEnumerable<Container> containers = TestUtilities.ListContainers(Client, TestConstants.EdgeResourceName, storageAccountName, TestConstants.DefaultResourceGroupName, out continuationToken);

            //  // Delete container
            Client.Containers.Delete(TestConstants.EdgeResourceName, storageAccountName, containerName, TestConstants.DefaultResourceGroupName);

        }

        #endregion Test Methods
    }
}
