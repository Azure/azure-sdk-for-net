// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Quota.Tests.Tests
{
    public class GroupQuotaSubscriptionCompatibilityTests
    {
        [Test]
        public async Task LegacyAccessorsForwardToGeneratedAccessors()
        {
            var parent = new MockGroupQuotaEntityResource();
            using var cancellation = new CancellationTokenSource();

            Assert.AreSame(parent.Collection, parent.GetGroupQuotaSubscriptions());
            Assert.AreSame(parent.Resource, parent.GetGroupQuotaSubscription("sync", cancellation.Token).Value);
            Assert.AreEqual("sync", parent.SubscriptionId);
            Assert.AreEqual(cancellation.Token, parent.CancellationToken);

            Assert.AreSame(parent.Resource, (await parent.GetGroupQuotaSubscriptionAsync("async", cancellation.Token)).Value);
            Assert.AreEqual("async", parent.SubscriptionId);
            Assert.AreEqual(cancellation.Token, parent.CancellationToken);
        }

        private class MockGroupQuotaEntityResource : GroupQuotaEntityResource
        {
            public GroupQuotaSubscriptionCollection Collection { get; } = new MockGroupQuotaSubscriptionCollection();
            public GroupQuotaSubscriptionResource Resource { get; } = new MockGroupQuotaSubscriptionResource();
            public string SubscriptionId { get; private set; }
            public CancellationToken CancellationToken { get; private set; }

            public override GroupQuotaSubscriptionCollection GetManagementGroupGroupQuotaSubscriptionIds() => Collection;

            public override Response<GroupQuotaSubscriptionResource> GetManagementGroupGroupQuotaSubscriptionId(string subscriptionId, CancellationToken cancellationToken = default)
            {
                SubscriptionId = subscriptionId;
                CancellationToken = cancellationToken;
                return Response.FromValue(Resource, new MockResponse(200));
            }

            public override Task<Response<GroupQuotaSubscriptionResource>> GetManagementGroupGroupQuotaSubscriptionIdAsync(string subscriptionId, CancellationToken cancellationToken = default)
                => Task.FromResult(GetManagementGroupGroupQuotaSubscriptionId(subscriptionId, cancellationToken));
        }

        private class MockGroupQuotaSubscriptionCollection : GroupQuotaSubscriptionCollection { }
        private class MockGroupQuotaSubscriptionResource : GroupQuotaSubscriptionResource { }
    }
}
