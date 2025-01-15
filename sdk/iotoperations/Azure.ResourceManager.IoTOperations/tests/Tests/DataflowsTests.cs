// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IoTOperations.Models;
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
                await GetDataflowResourceCollectionAsync(ResourceGroup);

            // None are created in a fresh AIO deployment
            // Create Dataflow
            string utcTime = DateTime.UtcNow.ToString("yyyyMMddTHHmmss");
            DataflowResourceData dataflowResourceData = CreateDataflowResourceData();

            ArmOperation<DataflowResource> resp =
                await dataflowResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-" + utcTime.Substring(utcTime.Length - 4),
                    dataflowResourceData
                );
            DataflowResource createdDataflow = resp.Value;

            Assert.IsNotNull(createdDataflow);
            Assert.IsNotNull(createdDataflow.Data);
            Assert.IsNotNull(createdDataflow.Data.Properties);

            // Delete Dataflow
            await createdDataflow.DeleteAsync(WaitUntil.Completed);

            // Verify Dataflow is deleted
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await createdDataflow.GetAsync()
            );
        }

        private DataflowResourceData CreateDataflowResourceData()
        {
            return new DataflowResourceData(
                // Can normally use the CL from already deployed resource in other RTs but since we are creating new ones in this test we need to construct the CL.
                new ExtendedLocation(ExtendedLocation, ExtendedLocationType.CustomLocation)
            )
            {
                Properties = new DataflowProperties(
                    [
                        new DataflowAction(OperationType.Source)
                        {
                            Name = "source1",
                            SourceSettings = new DataflowSourceOperationSettings(
                                "aio-builtin-broker-endpoint",
                                ["thermostats/+/telemetry/temperature/#"]
                            ),
                        },
                        new DataflowAction(OperationType.Destination)
                        {
                            Name = "destination1",
                            DestinationSettings = new DataflowDestinationOperationSettings(
                                "event-grid-endpoint",
                                "factory/telemetry"
                            ),
                        }
                    ]
                )
                {
                    Mode = OperationalMode.Enabled,
                },
            };
        }
    }
}
