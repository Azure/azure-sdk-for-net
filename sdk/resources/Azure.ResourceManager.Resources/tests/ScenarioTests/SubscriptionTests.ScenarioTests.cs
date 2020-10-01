// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Tests;
using NUnit.Framework;

namespace ResourceGroups.Tests
{
    public class LiveSubscriptionTests : ResourceOperationsTestsBase
    {
        public LiveSubscriptionTests(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            // in record mode we reset the challenge cache before each test so that the challenge call
            // is always made.  This allows tests to be replayed independently and in any order
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                Initialize();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        public async Task ListSubscriptions()
        {
            var subscriptions = await SubscriptionsOperations.ListAsync().ToEnumerableAsync();

            Assert.NotNull(subscriptions);
            Assert.IsNotEmpty(subscriptions);
            Assert.NotNull(subscriptions.First().Id);
            Assert.NotNull(subscriptions.First().SubscriptionId);
            Assert.NotNull(subscriptions.First().DisplayName);
            Assert.NotNull(subscriptions.First().State);
        }

        [Test]
        public async Task GetSubscriptionDetails()
        {
            var subscriptionDetails = (await SubscriptionsOperations.GetAsync(TestEnvironment.SubscriptionId)).Value;

            Assert.NotNull(subscriptionDetails);
            Assert.NotNull(subscriptionDetails.Id);
            Assert.NotNull(subscriptionDetails.SubscriptionId);
            Assert.NotNull(subscriptionDetails.DisplayName);
            Assert.NotNull(subscriptionDetails.State);
            Assert.NotNull(subscriptionDetails.Tags);
        }
    }
}
