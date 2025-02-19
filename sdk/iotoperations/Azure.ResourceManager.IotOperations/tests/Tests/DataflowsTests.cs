// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.IotOperations.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class DataflowsTests : IotOperationsManagementClientBase
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
            IotOperationsDataflowCollection dataflowResourceCollection =
                await GetDataflowCollectionAsync(ResourceGroup);

            // None are created in a fresh AIO deployment
            // Create Dataflow
            IotOperationsDataflowData dataflowResourceData = CreateDataflowData();

            ArmOperation<IotOperationsDataflowResource> resp =
                await dataflowResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-dataflows",
                    dataflowResourceData
                );
            IotOperationsDataflowResource createdDataflow = resp.Value;

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

        private IotOperationsDataflowData CreateDataflowData()
        {
            return new IotOperationsDataflowData(
                // Can normally use the CL from already deployed resource in other RTs but since we are creating new ones in this test we need to construct the CL.
                new IotOperationsExtendedLocation(ExtendedLocation, IotOperationsExtendedLocationType.CustomLocation)
            )
            {
                Properties = new IotOperationsDataflowProperties(
                    [
                        new DataflowOperationProperties(DataflowOperationType.Source)
                        {
                            Name = "source1",
                            SourceSettings = new DataflowSourceOperationSettings(
                                "aio-builtin-broker-endpoint",
                                ["thermostats/+/telemetry/temperature/#"]
                            ),
                        },
                        new DataflowOperationProperties(DataflowOperationType.Destination)
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
                    Mode = IotOperationsOperationalMode.Enabled,
                },
            };
        }
    }
}
