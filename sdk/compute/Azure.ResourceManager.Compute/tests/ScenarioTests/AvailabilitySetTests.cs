// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    public class AvailabilitySetTests : ComputeClientMockBase
    {
        private string _name = "mockAvailabilitySet";
        private string _resourceGroupName = "mockResourceGroup";

        public AvailabilitySetTests(bool isAsync) : base(isAsync, RecordedTestMode.Playback)
        {
        }

        [RecordedTest]
        public async Task TestCRUD()
        {
            var resourceGroupContainer = await GetResourceGroupContainer();

            var resourceGroup = await CreateResourceGroupAsync(resourceGroupContainer);
            Assert.NotNull(resourceGroup);

            var container = resourceGroup.GetAvailabilitySets();

            var availabilitySet = await CreateAvailabilitySetAsync(container);
            Assert.NotNull(availabilitySet);

            availabilitySet = await TagAvailabilitySetAsync(availabilitySet);
            Assert.NotNull(availabilitySet);

            availabilitySet = await GetAvailabilitySetAsync(container);
            Assert.NotNull(availabilitySet);

            await DeleteAvailabilitySetAsync(availabilitySet);

            await GetAvailabilitySetFailAsync(container);
        }

        private async Task<ResourceGroup> CreateResourceGroupAsync(ResourceGroupContainer container)
        {
            var data = new ResourceGroupData(Location);
            var response = await container.CreateOrUpdateAsync(_resourceGroupName, data);

            Assert.NotNull(response.Value);

            return response.Value;
        }

        private async Task<AvailabilitySet> CreateAvailabilitySetAsync(AvailabilitySetContainer container)
        {
            var data = new AvailabilitySetData(Location);
            var response = await container.CreateOrUpdateAsync(_name, data);

            Assert.NotNull(response.Value);

            return response.Value;
        }

        private async Task<AvailabilitySet> GetAvailabilitySetAsync(AvailabilitySetContainer container)
        {
            var response = await container.GetAsync(_name);

            Assert.NotNull(response.Value);

            return response.Value;
        }

        private async Task GetAvailabilitySetFailAsync(AvailabilitySetContainer container)
        {
            try
            {
                var response = await container.GetAsync(_name);
            }
            catch (Exception e)
            {
                Assert.NotNull(e);
                return;
            }

            throw new Exception($"We should not get the Availability Set {_name} anymore");
        }

        private async Task<AvailabilitySet> TagAvailabilitySetAsync(AvailabilitySet availabilitySet)
        {
            var tags = new Dictionary<string, string>()
            {
                { "key", "value" }
            };
            var response = await availabilitySet.SetTagsAsync(tags);

            Assert.NotNull(response.Value);

            return response.Value;
        }

        private async Task<Response> DeleteAvailabilitySetAsync(AvailabilitySet availabilitySet)
        {
            var response = await availabilitySet.DeleteAsync();

            Assert.NotNull(response);

            return response;
        }
    }
}
