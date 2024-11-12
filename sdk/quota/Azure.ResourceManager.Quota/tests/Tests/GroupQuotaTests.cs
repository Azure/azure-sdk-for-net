// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Quota.Models;
using NUnit.Framework;
using Azure.ResourceManager.ManagementGroups;
using Azure.Identity;

namespace Azure.ResourceManager.Quota.Tests.Tests
{
    [TestFixture]
    public class GroupQuotaTests : QuotaManagementTestBase
    {
        private const string defaultSubscriptionId = "65a85478-2333-4bbd-981b-1a818c944faf";

        private const string managementGroupId = "testMgIdRoot";

        public GroupQuotaTests() : base(true)
        {
        }

        [SetUp]
        public void Init()
        {
            CreateCommonClient();
        }

        [TestCase]
        public async Task SetGroupQuota()
        {
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);

            // get the collection of this GroupQuotasEntityResource
            GroupQuotaEntityCollection collection = managementGroupResource.GetGroupQuotaEntities();

            // invoke the operation
            string groupQuotaName = "sdk-test-group-quota-create";

            // Builds the Group Quota Request Body
            GroupQuotaEntityData data = new GroupQuotaEntityData()
            {
                Properties = new GroupQuotaEntityBase()
                {
                    DisplayName = "sdk-test-group-quota-create",
                    AdditionalAttributes = new GroupQuotaAdditionalAttributes(new GroupQuotaGroupingId()
                    {
                        GroupingIdType = GroupQuotaGroupingIdType.BillingId,
                        Value = "ad41a99f-9c42-4b3d-9770-e711a24d8542",
                    })
                },
            };

            //Performs the GroupQuota PUT operation
            var createResponse  = await collection.CreateOrUpdateAsync(WaitUntil.Started, groupQuotaName, data);
            Assert.IsNotNull(createResponse);

            // Delete the created Group Quota for cleanup
            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            GroupQuotaEntityResource groupQuotasEntity = Client.GetGroupQuotaEntityResource(groupQuotasEntityResourceId);
            await groupQuotasEntity.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        public async Task GetGroupQuota()
        {
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);

            // get the collection of this GroupQuotasEntityResource
            var collection = managementGroupResource.GetGroupQuotaEntities();

            // Performs the GET operation on a Group Quota resource
            string groupQuotaName = "sdk-test-group-quota";
            var result = await collection.GetAsync(groupQuotaName);
            Assert.IsNotNull(result);
        }

        [TestCase]
        public async Task GetGroupQuotaList()
        {
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);
            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);

            // get the collection of this GroupQuotasEntityResource
            var collection =  managementGroupResource.GetGroupQuotaEntities();

            // Get all the Group Quota Entities
            await foreach (GroupQuotaEntityResource item in collection.GetAllAsync())
            {
                // Ensure that the Group Quota Objects are non empty
                GroupQuotaEntityData resourceData = item.Data;
                Assert.NotNull(resourceData);
            }
        }

        [TestCase]
        public async Task SetGroupQuotaLimit()
        {
            // Create the Group Quota Limit Request Body
            GroupQuotaRequestStatusData requestBody = new GroupQuotaRequestStatusData()
            {
                Properties = new GroupQuotaRequestStatusProperties()
                {
                    RequestedResource = new GroupQuotaRequestBase()
                    {
                        Limit = 225,
                        Region = "westus",
                        Comments = "ticketComments"
                    }
                },
            };

            string groupQuotaName = "sdk-test-group-quota";

            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            // Get the Group Quota Resource
            GroupQuotaEntityResource groupQuotasEntity = Client.GetGroupQuotaEntityResource(groupQuotasEntityResourceId);

            // Perform the QuotaLimit Request call
            var response = await groupQuotasEntity.CreateOrUpdateGroupQuotaLimitsRequestAsync(WaitUntil.Started, "Microsoft.Compute", "standarddv4family", requestBody);
            Assert.IsNotNull(response);
        }

        [TestCase]
        public async Task GetGroupQuotaLimit()
        {
            string groupQuotaName = "sdk-test-group-quota";

            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            GroupQuotaEntityResource groupQuotasEntity = Client.GetGroupQuotaEntityResource(groupQuotasEntityResourceId);

            // get the collection of this GroupQuotaLimitResource
            string resourceProviderName = "Microsoft.Compute";
            GroupQuotaLimitCollection collection = groupQuotasEntity.GetGroupQuotaLimits(resourceProviderName);

            // Perform the GET operation with the proper location filter
            string resourceName = "standarddv4family";
            string filter = "location eq westus";
            var result = await collection.GetAsync(resourceName, filter);
            Assert.IsNotNull(result);
        }

        [TestCase]
        public async Task SetSubscription()
        {
            string groupQuotaName = "sdk-test-group-quota";

            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            GroupQuotaEntityResource groupQuotasEntity = Client.GetGroupQuotaEntityResource(groupQuotasEntityResourceId);

            // get the collection of this GroupQuotaSubscriptionIdResource
            GroupQuotaSubscriptionCollection collection = groupQuotasEntity.GetGroupQuotaSubscriptions();

            // Add a Subscription to the Group Quota Object
            var response = await collection.CreateOrUpdateAsync(WaitUntil.Started, defaultSubscriptionId);

            //Clean up Sub
            ResourceIdentifier groupQuotaSubscriptionIdResourceId = GroupQuotaSubscriptionResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, defaultSubscriptionId);

            GroupQuotaSubscriptionResource groupQuotaSubscriptionId = Client.GetGroupQuotaSubscriptionResource(groupQuotaSubscriptionIdResourceId);

            await groupQuotaSubscriptionId.DeleteAsync(WaitUntil.Started);
        }

        [TestCase]
        public async Task SetSubscriptionAllocationRequest()
        {
            // invoke the operation
            string groupQuotaName = "sdk-test-group-quota";
            string resourceProviderName = "Microsoft.Compute";
            string resourceName = "standarddv2family";

            ResourceIdentifier groupQuotaSubscriptionIdResourceId = GroupQuotaSubscriptionResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, defaultSubscriptionId);

            GroupQuotaSubscriptionResource groupQuotaSubscriptionId = Client.GetGroupQuotaSubscriptionResource(groupQuotaSubscriptionIdResourceId);

            // invoke the operation
            var subscriptionAddResponse = await groupQuotaSubscriptionId.UpdateAsync(WaitUntil.Started);
            Assert.IsNotNull(subscriptionAddResponse);

            // Builds the Quota Allocation Request Body
            QuotaAllocationRequestStatusData data = new QuotaAllocationRequestStatusData()
            {
                RequestedResource = new QuotaAllocationRequestBase()
                {
                    Limit = 20,
                    Region = "westus2",
                },
            };
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);

            var allocationResponse = await managementGroupResource.CreateOrUpdateGroupQuotaSubscriptionAllocationRequestAsync(WaitUntil.Started, defaultSubscriptionId, groupQuotaName, resourceProviderName, resourceName, data);

            Assert.IsNotNull(allocationResponse);

            // Delete the Subscription as part of test cleanup
            await groupQuotaSubscriptionId.DeleteAsync(WaitUntil.Started);
        }

        [TestCase]
        public async Task GetSubscriptionAllocation()
        {
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);

            // invoke the operation
            string groupQuotaName = "sdk-test-group-quota";
            string resourceName = "standarddv2family";
            ResourceIdentifier subscriptionQuotaAllocationResourceId = SubscriptionQuotaAllocationResource.CreateResourceIdentifier(managementGroupId, defaultSubscriptionId, groupQuotaName, resourceName);

            SubscriptionQuotaAllocationResource subscriptionQuotaAllocation = Client.GetSubscriptionQuotaAllocationResource(subscriptionQuotaAllocationResourceId);

            // Get the Subscription Allocation Object with the given location filter
            string filter = "location eq westus2";
            var result = await subscriptionQuotaAllocation.GetAsync(filter);
            Assert.IsNotNull(result);
        }

        [TestCase]
        public async Task GetSubscriptionAllocationList()
        {
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);

            // get the collection of this SubscriptionQuotaAllocationResource
            string groupQuotaName = "sdk-test-group-quota";
            SubscriptionQuotaAllocationCollection collection = managementGroupResource.GetSubscriptionQuotaAllocations(defaultSubscriptionId, groupQuotaName);

            string filter = "location eq westus2";

            //Get all the SubAllocation Resources
            await foreach (SubscriptionQuotaAllocationResource item in collection.GetAllAsync(filter))
            {
                //Ensure that all sub resources aren't null
                var resourceData = item.Data;

                Assert.IsNotNull(resourceData);
            }
        }
    }
}
