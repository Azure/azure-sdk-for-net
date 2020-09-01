// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Azure.ResourceManager.CosmosDB.Tests
{
    [TestFixture]
    public class OperationsTest : CosmosDBManagementClientBase
    {
        private string resourceGroupName;
        public OperationsTest()
            : base(true)
        {
        }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeClients();
                this.resourceGroupName = Recording.GenerateAssetName(CosmosDBTestUtilities.resourceGroupPrefix);
                TestContext.Progress.WriteLine("//////////////////OperationsTests/////////////////////////////");
                TestContext.Progress.WriteLine(this.resourceGroupName);
                await CosmosDBTestUtilities.TryRegisterResourceGroupAsync(ResourceGroupsOperations,
                    CosmosDBTestUtilities.location,
                    this.resourceGroupName);
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [TestCase]
        public async Task ListOperationsTest()
        {
            CosmosDBManagementClient cosmosDBMgmtClient = GetCosmosDBManagementClient();
            var operations = cosmosDBMgmtClient.Operations.ListAsync();
            Assert.NotNull(operations);
            Assert.IsNotEmpty(await operations.ToEnumerableAsync());
        }
    }
}
