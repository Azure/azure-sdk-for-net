// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Quota.Models;
using NUnit.Framework;
//using Azure.Identity;
using Azure.ResourceManager.ManagementGroups;

namespace Azure.ResourceManager.Quota.Tests.Tests
{
    [TestFixture]
    public class QuotaTests : QuotaManagementTestBase
    {
        private const string Scope = "subscriptions/9f6cce51-6baf-4de5-a3c4-6f58b85315b9/providers/Microsoft.Network/locations/westus";
        private const string ResourceName = "PublicIPAddresses";

        public QuotaTests() : base(true)
        {
        }

        [SetUp]
        public void Init()
        {
            CreateCommonClient();
        }

        [TestCase]
        public async Task ListQuotaRequests()
        {
            var response = await this.Client.GetQuotaRequestDetails(new ResourceIdentifier(Scope)).GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(response.All(x => string.Equals(x.Data.ResourceType, "Microsoft.Quota/quotaRequests", StringComparison.OrdinalIgnoreCase)));
        }

        [TestCase]
        public async Task ListQuotaRequestsWithFilter()
        {
            int top = 5;
            var response = await this.Client.GetQuotaRequestDetails(new ResourceIdentifier(Scope))
                .GetAllAsync(filter: "provisioningState eq 'Failed'", top: top)
                .ToEnumerableAsync();

            Assert.IsTrue(response.All(x => string.Equals(x.Data.ProvisioningState.ToString(), "Failed", StringComparison.OrdinalIgnoreCase)));
            Assert.AreEqual(top, response.Count);
        }

        [TestCase]
        public async Task GetQuotaRequest()
        {
            string requestId = "2779d9c5-f58a-4163-8f5d-8de32a546c25";
            var response = await this.Client.GetQuotaRequestDetailAsync(new ResourceIdentifier(Scope), requestId);

            Assert.AreEqual(requestId, response.Value.Data.Name);
        }

        [TestCase]
        public async Task GetQuota()
        {
            var response = await this.Client.GetCurrentQuotaLimitBaseAsync(new ResourceIdentifier(Scope), ResourceName);

            Assert.AreEqual(ResourceName, response.Value.Data.Name);
        }

        [TestCase]
        public async Task ListQuotas()
        {
            var response = await this.Client.GetCurrentQuotaLimitBases(new ResourceIdentifier(Scope)).GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(response.All(x => string.Equals(x.Data.ResourceType, "Microsoft.Quota/quotas", StringComparison.OrdinalIgnoreCase)));
        }

        [TestCase]
        public async Task GetUsage()
        {
            var response = await this.Client.GetCurrentUsagesBaseAsync(new ResourceIdentifier(Scope), ResourceName);

            Assert.AreEqual(ResourceName, response.Value.Data.Name);
        }

        [TestCase]
        public async Task ListUsages()
        {
            var response = await this.Client.GetCurrentUsagesBases(new ResourceIdentifier(Scope)).GetAllAsync().ToEnumerableAsync();

            Assert.IsTrue(response.All(x => string.Equals(x.Data.ResourceType, "Microsoft.Quota/usages", StringComparison.OrdinalIgnoreCase)));
        }

        [TestCase]
        public async Task SetQuota()
        {
            CurrentQuotaLimitBaseData data = new CurrentQuotaLimitBaseData()
            {
                Properties = new QuotaProperties()
                {
                    Limit = new QuotaLimitObject(10),
                    Name = new QuotaRequestResourceName()
                    {
                        Value = ResourceName,
                    },
                    ResourceTypeName = ResourceName,
                },
            };

            var response = await Client.GetCurrentQuotaLimitBases(new ResourceIdentifier(Scope)).CreateOrUpdateAsync(WaitUntil.Started, ResourceName, data);

            Assert.IsNotNull(response);
        }

        [TestCase]
        public async Task SetQuota_InvalidResourceName()
        {
            CurrentQuotaLimitBaseData data = new CurrentQuotaLimitBaseData()
            {
                Properties = new QuotaProperties()
                {
                    Limit = new QuotaLimitObject(10),
                    Name = new QuotaRequestResourceName()
                    {
                        Value = "Invalid",
                    },
                    ResourceTypeName = "Invalid",
                },
            };

            try
            {
                var response = await Client.GetCurrentQuotaLimitBases(new ResourceIdentifier(Scope)).CreateOrUpdateAsync(WaitUntil.Started, "Invalid", data);
            }
            catch (RequestFailedException ex)
            {
                Assert.AreEqual(400, ex.Status);
                Assert.AreEqual("InvalidResourceName", ex.ErrorCode);
                return;
            }

            // fail if request doesn't fail
            Assert.Fail();
        }
    }
}
