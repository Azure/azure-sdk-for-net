// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FileShares.Mocking;
using Azure.ResourceManager.FileShares.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.FileShares.Tests
{
    /// <summary>
    /// Covers the hand-written members that keep 1.0.0 callers and mocks working.
    /// </summary>
    public class FileShareCompatibilityTests
    {
        private static readonly AzureLocation Location = new AzureLocation("eastus2euap");

        [Test]
        public void LegacyRecommendationConstructorSerializesStorage()
        {
            var content = new FileShareProvisioningRecommendationContent(1024);

            Assert.AreEqual(1024, content.FileShareProvisioningRecommendationInputProvisionedStorageInGiB);
            Assert.AreEqual(1024, content.Properties.ProvisionedStorageInGiB);

            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(content, ModelReaderWriterOptions.Json).ToString());
            Assert.AreEqual(1024, json.RootElement.GetProperty("properties").GetProperty("provisionedStorageGiB").GetInt32());
        }

        [Test]
        public void LegacyRecommendationGetterReturnsZeroWithoutProperties()
        {
            var content = ArmFileSharesModelFactory.FileShareProvisioningRecommendationContent();

            Assert.IsNull(content.Properties);
            Assert.AreEqual(0, content.FileShareProvisioningRecommendationInputProvisionedStorageInGiB);
        }

        [Test]
        public async Task GetLimitsWithoutContentDispatchesToLegacyMock()
        {
            var mock = new LegacyGetLimitsMock();
            var subscription = new TestSubscriptionResource(mock);

            await subscription.GetLimitsAsync(Location);
            subscription.GetLimits(Location);

            Assert.AreEqual(1, mock.LegacyAsyncCalls);
            Assert.AreEqual(1, mock.LegacySyncCalls);
        }

        [Test]
        public async Task GetLimitsReachesCurrentMockWithOrWithoutContent()
        {
            var mock = new CurrentGetLimitsMock();
            var subscription = new TestSubscriptionResource(mock);
            var content = new FileShareLimitsContent(new FileShareOfferInput { MediaTier = FileShareMediaTier.Hdd });

            await subscription.GetLimitsAsync(Location);
            await subscription.GetLimitsAsync(Location, content);
            subscription.GetLimits(Location);
            subscription.GetLimits(Location, content);

            CollectionAssert.AreEqual(new[] { null, content }, mock.AsyncContents);
            CollectionAssert.AreEqual(new[] { null, content }, mock.SyncContents);
        }

        private static Response<FileShareLimitsResult> LimitsResponse()
            => Response.FromValue(ArmFileSharesModelFactory.FileShareLimitsResult(), new MockResponse(200));

        private class LegacyGetLimitsMock : MockableFileSharesSubscriptionResource
        {
            public int LegacyAsyncCalls { get; private set; }
            public int LegacySyncCalls { get; private set; }

            public override Task<Response<FileShareLimitsResult>> GetLimitsAsync(AzureLocation location, CancellationToken cancellationToken)
            {
                LegacyAsyncCalls++;
                return Task.FromResult(LimitsResponse());
            }

            public override Response<FileShareLimitsResult> GetLimits(AzureLocation location, CancellationToken cancellationToken)
            {
                LegacySyncCalls++;
                return LimitsResponse();
            }
        }

        private class CurrentGetLimitsMock : MockableFileSharesSubscriptionResource
        {
            public System.Collections.Generic.List<FileShareLimitsContent> AsyncContents { get; } = new();
            public System.Collections.Generic.List<FileShareLimitsContent> SyncContents { get; } = new();

            public override Task<Response<FileShareLimitsResult>> GetLimitsAsync(AzureLocation location, FileShareLimitsContent content = default, CancellationToken cancellationToken = default)
            {
                AsyncContents.Add(content);
                return Task.FromResult(LimitsResponse());
            }

            public override Response<FileShareLimitsResult> GetLimits(AzureLocation location, FileShareLimitsContent content = default, CancellationToken cancellationToken = default)
            {
                SyncContents.Add(content);
                return LimitsResponse();
            }
        }

        private class TestSubscriptionResource : SubscriptionResource
        {
            private readonly MockableFileSharesSubscriptionResource _mockable;

            public TestSubscriptionResource(MockableFileSharesSubscriptionResource mockable)
            {
                _mockable = mockable;
            }

            public override T GetCachedClient<T>(Func<ArmClient, T> clientFactory) => (T)(object)_mockable;
        }
    }
}
