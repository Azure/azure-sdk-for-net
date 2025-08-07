// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class DataflowEndpointsTests : IotOperationsManagementClientBase
    {
        public DataflowEndpointsTests(bool isAsync)
            : base(isAsync) { }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                await InitializeClients();
            }
        }

        [TestCase]
        [RecordedTest]
        public async Task TestDataflowEndpoints()
        {
            // Get DataflowEndpoints
            IotOperationsDataflowEndpointCollection dataflowEndpointsResourceCollection =
                await GetDataflowEndpointCollectionAsync(ResourceGroup);

            IotOperationsDataflowEndpointResource dataflowEndpointsResource =
                await dataflowEndpointsResourceCollection.GetAsync(DataflowEndpointsName);

            Assert.IsNotNull(dataflowEndpointsResource);
            Assert.IsNotNull(dataflowEndpointsResource.Data);
            Assert.AreEqual(dataflowEndpointsResource.Data.Name, DataflowEndpointsName);

            // Create new DataflowEndpoint

            IotOperationsDataflowEndpointData dataflowEndpointsResourceData =
                CreateDataflowEndpointData(dataflowEndpointsResource);

            ArmOperation<IotOperationsDataflowEndpointResource> resp =
                await dataflowEndpointsResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-dataflowendpoints",
                    dataflowEndpointsResourceData
                );
            IotOperationsDataflowEndpointResource createdDataflowEndpoint = resp.Value;

            Assert.IsNotNull(createdDataflowEndpoint);
            Assert.IsNotNull(createdDataflowEndpoint.Data);
            Assert.IsNotNull(createdDataflowEndpoint.Data.Properties);

            // Delete DataflowEndpoint
            await createdDataflowEndpoint.DeleteAsync(WaitUntil.Completed);

            // Verify DataflowEndpoint is deleted
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await createdDataflowEndpoint.GetAsync()
            );
        }

        private IotOperationsDataflowEndpointData CreateDataflowEndpointData(
            IotOperationsDataflowEndpointResource dataflowEndpointsResource
        )
        {
            return new IotOperationsDataflowEndpointData(dataflowEndpointsResource.Data.ExtendedLocation)
            {
                Properties = dataflowEndpointsResource.Data.Properties
            };
        }
    }
}
