// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IoTOperations.Models;
using Azure.ResourceManager.IoTOperations.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.IoTOperations.Tests
{
    public class DataflowEndpointsTests : IoTOperationsManagementClientBase
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
            DataflowEndpointResourceCollection dataflowEndpointsResourceCollection =
                await GetDataflowEndpointResourceCollectionAsync(
                    IoTOperationsManagementTestUtilities.DefaultResourceGroupName
                );

            DataflowEndpointResource dataflowEndpointsResource =
                await dataflowEndpointsResourceCollection.GetAsync("default");

            Assert.IsNotNull(dataflowEndpointsResource);
            Assert.IsNotNull(dataflowEndpointsResource.Data);
            Assert.AreEqual(dataflowEndpointsResource.Data.Name, "default");

            // Create new DataflowEndpoint
            string utcTime = DateTime.UtcNow.ToString("yyyyMMddTHHmmss");

            DataflowEndpointResourceData dataflowEndpointsResourceData =
                CreateDataflowEndpointResourceData(dataflowEndpointsResource);

            ArmOperation<DataflowEndpointResource> resp =
                await dataflowEndpointsResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-" + utcTime.Substring(utcTime.Length - 4),
                    dataflowEndpointsResourceData
                );
            DataflowEndpointResource createdDataflowEndpoint = resp.Value;

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

        private DataflowEndpointResourceData CreateDataflowEndpointResourceData(
            DataflowEndpointResource dataflowEndpointsResource
        )
        {
            return new DataflowEndpointResourceData(dataflowEndpointsResource.Data.ExtendedLocation)
            {
                Properties = dataflowEndpointsResource.Data.Properties
            };
        }
    }
}
