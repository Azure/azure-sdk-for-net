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

        [TestCase]
        public async Task SetGroupQuota()
        {
            // this example assumes you already have this ManagementGroupResource created on azure
            // for more information of creating ManagementGroupResource, please refer to the document of ManagementGroupResource
            string managementGroupId = "testMgIdRoot";
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);
            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);

            // get the collection of this GroupQuotasEntityResource
            GroupQuotasEntityCollection collection = managementGroupResource.GetGroupQuotasEntities();

            // invoke the operation
            string groupQuotaName = "sdk-test-group-quota";
            GroupQuotasEntityData data = new GroupQuotasEntityData()
            {
                Properties = new GroupQuotasEntityBase()
                {
                    DisplayName = "sdk-test-group-quota",
                    AdditionalAttributes = new AdditionalAttributes(new GroupingId()
                    {
                        GroupingIdType = GroupingIdType.BillingId,
                        Value = "ad41a99f-9c42-4b3d-9770-e711a24d8542",
                    })
                },
            };
            ArmOperation<GroupQuotasEntityResource> lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupQuotaName, data);
            GroupQuotasEntityResource result = lro.Value;

            // the variable result is a resource, you could call other operations on this instance as well
            // but just for demo, we get its data from this resource instance
            GroupQuotasEntityData resourceData = result.Data;
            // for demo we just print out the id
            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
        }
    }
}
