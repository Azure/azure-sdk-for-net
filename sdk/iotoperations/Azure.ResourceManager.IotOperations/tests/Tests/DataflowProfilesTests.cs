// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class DataflowProfilesTests : IotOperationsManagementClientBase
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
            IotOperationsDataflowProfileCollection dataflowProfileResourceCollection =
                await GetDataflowProfileCollectionAsync(ResourceGroup);

            IotOperationsDataflowProfileResource dataflowProfileResource =
                await dataflowProfileResourceCollection.GetAsync(DataflowEndpointsName);

            Assert.IsNotNull(dataflowProfileResource);
            Assert.IsNotNull(dataflowProfileResource.Data);
            Assert.AreEqual(dataflowProfileResource.Data.Name, DataflowEndpointsName);

            // Create new DataflowProfile
            IotOperationsDataflowProfileData dataflowProfileResourceData =
                CreateDataflowProfileData(dataflowProfileResource);

            ArmOperation<IotOperationsDataflowProfileResource> resp =
                await dataflowProfileResourceCollection.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    "sdk-test-dataflowprofile",
                    dataflowProfileResourceData
                );
            IotOperationsDataflowProfileResource createdDataflowProfile = resp.Value;

            Assert.IsNotNull(createdDataflowProfile);
            Assert.IsNotNull(createdDataflowProfile.Data);
            Assert.IsNotNull(createdDataflowProfile.Data.Properties);

            // delete dataflow profile
            await createdDataflowProfile.DeleteAsync(WaitUntil.Completed);

            // Verify DataflowProfile is deleted
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await createdDataflowProfile.GetAsync()
            );
        }

        private IotOperationsDataflowProfileData CreateDataflowProfileData(
            IotOperationsDataflowProfileResource dataflowProfileResource
        )
        {
            return new IotOperationsDataflowProfileData(dataflowProfileResource.Data.ExtendedLocation)
            {
                Properties = dataflowProfileResource.Data.Properties
            };
        }
    }
}
