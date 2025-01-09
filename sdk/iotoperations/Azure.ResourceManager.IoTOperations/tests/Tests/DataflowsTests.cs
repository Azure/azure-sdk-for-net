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

            // DataflowResource dataflowResource = await dataflowResourceCollection.GetAsync(
            //     "default"
            // );

            // Assert.IsNotNull(dataflowResource);
            // Assert.IsNotNull(dataflowResource.Data);
            // Assert.AreEqual(dataflowResource.Data.Name, "default");

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
                new ExtendedLocation(
                    "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/sdk-test-cluster-110596935/providers/Microsoft.ExtendedLocation/customLocations/location-o5fjq",
                    ExtendedLocationType.CustomLocation
                )
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
