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
    public class DataflowsTests : IoTOperationsManagementClientBase
    {
        public DataflowsTests(bool isAsync)
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
        public async Task TestDataflows()
        {
            // Get Dataflows
            DataflowResourceCollection dataflowResourceCollection =
                await GetDataflowResourceCollectionAsync(
                    IoTOperationsManagementTestUtilities.DefaultResourceGroupName
                );

            DataflowResource dataflowResource = await dataflowResourceCollection.GetAsync(
                "default"
            );

            Assert.IsNotNull(dataflowResource);
            Assert.IsNotNull(dataflowResource.Data);
            Assert.AreEqual(dataflowResource.Data.Name, "default");

            // Update Dataflow
            DataflowResourceData dataflowResourceData = CreateDataflowResourceData();

            ArmOperation<DataflowResource> resp =
                await dataflowResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "default",
                    dataflowResourceData
                );
            DataflowResource updatedDataflow = resp.Value;

            Assert.IsNotNull(updatedDataflow);
            Assert.IsNotNull(updatedDataflow.Data);
            Assert.IsNotNull(updatedDataflow.Data.Properties);
        }

        private DataflowResourceData CreateDataflowResourceData()
        {
            return new DataflowResourceData
            {
                Properties = new DataflowProperties
                {
                    // Set properties as needed
                }
            };
        }
    }
}
