// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Quota.Models;
using NUnit.Framework;
using Azure.ResourceManager.ManagementGroups;
using Azure.Identity;
using System.Collections.Generic;
using Microsoft.Extensions.Azure;

namespace Azure.ResourceManager.Quota.Tests.Tests
{
    [TestFixture]
    public class GroupQuotaTests : QuotaManagementTestBase
    {
        private const string defaultSubscriptionId = "d55af59d-eac7-4b02-884f-70dfe2906197";

        private const string managementGroupId = "yuxzhatest";

        public ArmClient _armclient;

        public GroupQuotaTests() : base(true)
        {
        }

        [SetUp]
        public void Init()
        {
            CreateCommonClient();
            var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEndpointBaseUri), "https://management.azure.com/");
            //var rType = Resources.ResourceProviderResource.Get("Microsoft.Quota");
            options.SetApiVersion(new ResourceType("Microsoft.Quota/groupQuotas"), "2024-10-15-preview");

            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client

            _armclient = new ArmClient(cred, defaultSubscriptionId, options);
        }

            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);
            ManagementGroupResource managementGroupResource = client.GetManagementGroupResource(managementGroupResourceId);

            // get the collection of this GroupQuotasEntityResource
            GroupQuotaEntityCollection collection = managementGroupResource.GetGroupQuotaEntities();

            // invoke the operation
            string groupQuotaName = "sdk-test-group-quota-v3-create";

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
            var createResponse = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupQuotaName, data);
            Assert.IsNotNull(createResponse);

            // Delete the created Group Quota for cleanup
            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            GroupQuotaEntityResource groupQuotasEntity = client.GetGroupQuotaEntityResource(groupQuotasEntityResourceId);
            await groupQuotasEntity.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        public async Task GetGroupQuotaLimit()
        {
            var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEndpointBaseUri), "https://management.azure.com/");
            //var rType = Resources.ResourceProviderResource.Get("Microsoft.Quota");
            options.SetApiVersion(new ResourceType("Microsoft.Quota/groupQuotas"), "2024-10-15-preview");

            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client

            ArmClient client = new ArmClient(cred, defaultSubscriptionId, options);

            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);
            ManagementGroupResource managementGroupResource = _armclient.GetManagementGroupResource(managementGroupResourceId);

            // get the collection of this GroupQuotasEntityResource
            GroupQuotaEntityCollection collection = managementGroupResource.GetGroupQuotaEntities();

            // invoke the operation
            string groupQuotaName = "sdk-test-group-quota-v3-create";

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
            var createResponse = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupQuotaName, data);
            Assert.IsNotNull(createResponse);

            // GroupQuotaLimit Test
            string resourceProviderName = "Microsoft.Compute";
            AzureLocation location = new AzureLocation("westus");
            ResourceIdentifier groupQuotaLimitListResourceId = GroupQuotaLimitListResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, resourceProviderName, location);
            GroupQuotaLimitListResource groupQuotaLimitList = client.GetGroupQuotaLimitListResource(groupQuotaLimitListResourceId);

            // Create the Group Quota Limit Request Body
            List<GroupQuotaLimit> valList = new()
            {
                new GroupQuotaLimit()
                {
                    Properties = new GroupQuotaDetails()
                    {
                        Limit = 110,
                        ResourceName = "standardddv4family",
                        Comment = "comments"
                    }
                }
            };

            // Builds the Group Quota Request Body
            GroupQuotaLimitListData requestBody = new()
            {
                Properties = new GroupQuotaLimitListProperties(null, valList, "", null)
            };

            // Perform the QuotaLimit Request call
            var response = await groupQuotaLimitList.UpdateAsync(WaitUntil.Started, requestBody);
            Assert.IsNotNull(response);

            // Perform the QuotaLimit Get call
            GroupQuotaLimitListResource getResponse = await groupQuotaLimitList.GetAsync();
            Assert.IsNotNull(getResponse.Data);
            Assert.AreEqual(getResponse.Data.Properties.ProvisioningState, QuotaRequestStatus.Succeeded);

            // Delete the created Group Quota for cleanup
            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            GroupQuotaEntityResource groupQuotasEntity = _armclient.GetGroupQuotaEntityResource(groupQuotasEntityResourceId);
            await groupQuotasEntity.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        public async Task GetGroupQuota()
        {
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            ManagementGroupResource managementGroupResource = _armclient.GetManagementGroupResource(managementGroupResourceId);

            // get the collection of this GroupQuotasEntityResource
            var collection = managementGroupResource.GetGroupQuotaEntities();

            // Performs the GET operation on a Group Quota resource
            string groupQuotaName = "sdk-test-group-quota";
            var result = await collection.GetAsync(groupQuotaName);
            Assert.IsNotNull(result);
        }

        [TestCase]
        public async Task SetSubscription()
        {
            string groupQuotaName = "sdk-test-group-quota";

            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            GroupQuotaEntityResource groupQuotasEntity = _armclient.GetGroupQuotaEntityResource(groupQuotasEntityResourceId);

            // get the collection of this GroupQuotaSubscriptionIdResource
            GroupQuotaSubscriptionCollection collection = groupQuotasEntity.GetGroupQuotaSubscriptions();

            // Add a Subscription to the Group Quota Object
            var response = await collection.CreateOrUpdateAsync(WaitUntil.Completed, defaultSubscriptionId);

            //Clean up Sub
            ResourceIdentifier groupQuotaSubscriptionIdResourceId = GroupQuotaSubscriptionResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, defaultSubscriptionId);

            GroupQuotaSubscriptionResource groupQuotaSubscriptionId = _armclient.GetGroupQuotaSubscriptionResource(groupQuotaSubscriptionIdResourceId);

            await groupQuotaSubscriptionId.DeleteAsync(WaitUntil.Started);
        }

        [TestCase]
        public async Task SetSubscriptionAllocationRequest()
        {
            // invoke the operation
            string groupQuotaName = "sdk-test-group-quota";
            string resourceProviderName = "Microsoft.Compute";
            //string resourceName = "standarddv2family";

            AzureLocation location = new AzureLocation("westus");

            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            GroupQuotaEntityResource groupQuotasEntity = _armclient.GetGroupQuotaEntityResource(groupQuotasEntityResourceId);

            // get the collection of this GroupQuotaSubscriptionIdResource
            GroupQuotaSubscriptionCollection collection = groupQuotasEntity.GetGroupQuotaSubscriptions();

            // Add a Subscription to the Group Quota Object
            var response = await collection.CreateOrUpdateAsync(WaitUntil.Completed, defaultSubscriptionId);

            ResourceIdentifier subscriptionQuotaAllocationsListResourceId = SubscriptionQuotaAllocationsListResource.CreateResourceIdentifier(managementGroupId, defaultSubscriptionId, groupQuotaName, resourceProviderName, location);

            SubscriptionQuotaAllocationsListResource subscriptionQuotaAllocationsList = _armclient.GetSubscriptionQuotaAllocationsListResource(subscriptionQuotaAllocationsListResourceId);

            //// Builds the Quota Allocation Request Body
            SubscriptionQuotaAllocationsListData data = new SubscriptionQuotaAllocationsListData()
            {
                Properties = new SubscriptionQuotaAllocationsListProperties()
                {
                    Value =
                    {
                            new SubscriptionQuotaAllocations()
                            {
                                Properties = new SubscriptionQuotaDetails()
                                {
                                    ResourceName = "standardddv4family",
                                    Limit = 15,
                                },
                            }
                    }
                },
            };

            ArmOperation<SubscriptionQuotaAllocationsListResource> lro = await subscriptionQuotaAllocationsList.UpdateAsync(WaitUntil.Completed, data);
            SubscriptionQuotaAllocationsListResource result = lro.Value;

            // Delete the Subscription as part of test cleanup
            //Clean up Sub
            ResourceIdentifier groupQuotaSubscriptionIdResourceId = GroupQuotaSubscriptionResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, defaultSubscriptionId);

            GroupQuotaSubscriptionResource groupQuotaSubscriptionId = _armclient.GetGroupQuotaSubscriptionResource(groupQuotaSubscriptionIdResourceId);
            await groupQuotaSubscriptionId.DeleteAsync(WaitUntil.Started);
        }

        [TestCase]
        public async Task GetSubscriptionAllocationList()
        {
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);

            // invoke the operation
            string groupQuotaName = "sdk-test-group-quota";
            //string resourceName = "standardddv4family";
            string resourceProviderName = "Microsoft.Compute";
            AzureLocation location = new AzureLocation("westus");
            ResourceIdentifier subscriptionQuotaAllocationsListResourceId = SubscriptionQuotaAllocationsListResource.CreateResourceIdentifier(managementGroupId, defaultSubscriptionId, groupQuotaName, resourceProviderName, location);
            SubscriptionQuotaAllocationsListResource subscriptionQuotaAllocationsList = _armclient.GetSubscriptionQuotaAllocationsListResource(subscriptionQuotaAllocationsListResourceId);

            SubscriptionQuotaAllocationsListResource result = await subscriptionQuotaAllocationsList.GetAsync();

            Assert.IsNotNull(result.Data);
        }

        [TestCase]
        public async Task GetSubscriptionAllocationSingleResource()
        {
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);

            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);

            // invoke the operation
            string groupQuotaName = "sdk-test-group-quota";
            //string resourceName = "standardddv4family";
            string resourceProviderName = "Microsoft.Compute";
            AzureLocation location = new AzureLocation("westus");
            ResourceIdentifier subscriptionQuotaAllocationsListResourceId = SubscriptionQuotaAllocationsListResource.CreateResourceIdentifier(managementGroupId, defaultSubscriptionId, groupQuotaName, resourceProviderName, location);

            // get the collection of this SubscriptionQuotaAllocationsListResource
            SubscriptionQuotaAllocationsListCollection collection = managementGroupResource.GetSubscriptionQuotaAllocationsLists();

            SubscriptionQuotaAllocationsListResource result = await collection.GetAsync(defaultSubscriptionId, groupQuotaName, resourceProviderName, location);

            Assert.IsNotNull(result.Data);
            var data = result.Get();
            Assert.IsNotNull(data);
        }
    }
}
