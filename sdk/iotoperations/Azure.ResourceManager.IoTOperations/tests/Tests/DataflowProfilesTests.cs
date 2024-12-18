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
    public class DataflowProfilesTests : IoTOperationsManagementClientBase
    {
        public DataflowProfilesTests(bool isAsync)
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
        public async Task TestDataflowProfiles()
        {
            // Get DataflowProfiles
            DataflowProfileResourceCollection dataflowProfileResourceCollection =
                await GetDataflowProfileResourceCollectionAsync(
                    IoTOperationsManagementTestUtilities.DefaultResourceGroupName
                );

            DataflowProfileResource dataflowProfileResource =
                await dataflowProfileResourceCollection.GetAsync("default");

            Assert.IsNotNull(dataflowProfileResource);
            Assert.IsNotNull(dataflowProfileResource.Data);
            Assert.AreEqual(dataflowProfileResource.Data.Name, "default");

            // Update DataflowProfile
            ProfileDiagnostics Diagnostics = new ProfileDiagnostics { LogsLevel = "warn" };

            DataflowProfileResourceData dataflowProfileResourceData =
                CreateDataflowProfileResourceData(dataflowProfileResource, Diagnostics);

            ArmOperation<DataflowProfileResource> resp =
                await dataflowProfileResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "default",
                    dataflowProfileResourceData
                );
            DataflowProfileResource updatedDataflowProfile = resp.Value;

            Assert.IsNotNull(updatedDataflowProfile);
            Assert.IsNotNull(updatedDataflowProfile.Data);
            Assert.IsNotNull(updatedDataflowProfile.Data.Properties);

            Diagnostics = new ProfileDiagnostics { LogsLevel = "info" };
            dataflowProfileResourceData = CreateDataflowProfileResourceData(
                dataflowProfileResource,
                Diagnostics
            );

            resp = await dataflowProfileResourceCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "default",
                dataflowProfileResourceData
            );
            updatedDataflowProfile = resp.Value;

            Assert.IsNotNull(updatedDataflowProfile);
            Assert.IsNotNull(updatedDataflowProfile.Data);
            Assert.IsNotNull(updatedDataflowProfile.Data.Properties);
        }

        private DataflowProfileResourceData CreateDataflowProfileResourceData(
            DataflowProfileResource dataflowProfileResource,
            ProfileDiagnostics diagnostics
        )
        {
            return new DataflowProfileResourceData(
                new ExtendedLocation(
                    "/subscriptions/d4ccd08b-0809-446d-a8b7-7af8a90109cd/resourceGroups/sdk-test-cluster-110596935/providers/Microsoft.ExtendedLocation/customLocations/location-o5fjq",
                    ExtendedLocationType.CustomLocation
                )
            )
            {
                Properties = new DataflowProfileProperties
                {
                    Diagnostics = diagnostics,
                    InstanceCount = dataflowProfileResource.Data.Properties.InstanceCount,
                }
            };
        }
    }
}
