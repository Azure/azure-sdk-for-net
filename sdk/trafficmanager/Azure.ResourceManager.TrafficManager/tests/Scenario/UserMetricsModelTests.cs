// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TrafficManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.TrafficManager.Tests.Scenario
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

            UserMetricsModelResource userMetricsModelResource = _subscription.GetUserMetricsModel();
            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            Assert.IsNotEmpty(userMetricsModelResource.Data.Key);

            await Delete();

            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            Assert.IsEmpty(userMetricsModelResource.Data.Key);
        }

        [RecordedTest]
        public async Task CreateTest()
        {
            await Delete();

            UserMetricsModelResource userMetricsModelResource = _subscription.GetUserMetricsModel();
            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            Assert.IsEmpty(userMetricsModelResource.Data.Key);

            await Create();

            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            Assert.IsNotEmpty(userMetricsModelResource.Data.Key);
        }

        private async Task Delete()
        {
            UserMetricsModelResource userMetricsModelResource = _subscription.GetUserMetricsModel();

            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            ArmOperation<DeleteOperationResult> armOperation = await userMetricsModelResource.DeleteAsync(WaitUntil.Completed);

            Assert.IsTrue(armOperation.HasCompleted);
            Assert.IsTrue(armOperation.HasValue);
        }

        private async Task Create()
        {
            UserMetricsModelResource userMetricsModelResource = _subscription.GetUserMetricsModel();
            userMetricsModelResource = await userMetricsModelResource.GetAsync();

            ArmOperation<UserMetricsModelResource> userMetricsModelResourceOperation = await userMetricsModelResource.CreateOrUpdateAsync(WaitUntil.Completed);

            Assert.IsTrue(userMetricsModelResourceOperation.HasCompleted);
            Assert.IsTrue(userMetricsModelResourceOperation.HasValue);
        }
    }
}
