// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.TrafficManager.Tests
{
    public sealed class UserMetricsModelTests : TrafficManagerManagementTestBase
    {
        private SubscriptionResource _subscription;

        public UserMetricsModelTests(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        { }

        /// <summary>
        /// The method creates a traffic manager profile, so it covers the creation use-case.
        /// </summary>
        /// <returns>A task to wait for.</returns>
        [SetUp]
        public async Task Setup()
        {
            _subscription = await Client.GetDefaultSubscriptionAsync();
        }

        [RecordedTest]
        public async Task DeleteTest()
        {
            await Create();

            TrafficManagerUserMetricsResource userMetricsModelResource = _subscription.GetTrafficManagerUserMetrics();
            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            Assert.IsNotEmpty(userMetricsModelResource.Data.Key);

            await Delete();

            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            Assert.IsEmpty(userMetricsModelResource.Data.Key);
        }

        [RecordedTest]
        public async Task DeleteFailureTest()
        {
            const string FalseySubId = "5941c11c-485a-4a27-a87f-db38d642b886";
            ResourceIdentifier resourceIdentifier = TrafficManagerUserMetricsResource.CreateResourceIdentifier(FalseySubId);
            var badResource = Client.GetTrafficManagerUserMetricsResource(resourceIdentifier);
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await badResource.DeleteAsync(WaitUntil.Completed));
            Assert.AreEqual(404, exception.Status);

            await Task.CompletedTask;
        }

        [RecordedTest]
        public async Task CreateTest()
        {
            await Delete();

            TrafficManagerUserMetricsResource userMetricsModelResource = _subscription.GetTrafficManagerUserMetrics();
            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            Assert.IsEmpty(userMetricsModelResource.Data.Key);

            await Create();

            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            Assert.IsNotEmpty(userMetricsModelResource.Data.Key);
        }

        private async Task Delete()
        {
            TrafficManagerUserMetricsResource userMetricsModelResource = _subscription.GetTrafficManagerUserMetrics();

            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            await userMetricsModelResource.DeleteAsync(WaitUntil.Completed);
        }

        private async Task Create()
        {
            TrafficManagerUserMetricsResource userMetricsModelResource = _subscription.GetTrafficManagerUserMetrics();
            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            ArmOperation<TrafficManagerUserMetricsResource> userMetricsModelResourceOperation = await userMetricsModelResource.CreateOrUpdateAsync(WaitUntil.Completed);

            Assert.IsTrue(userMetricsModelResourceOperation.HasCompleted);
            Assert.IsTrue(userMetricsModelResourceOperation.HasValue);
        }
    }
}
