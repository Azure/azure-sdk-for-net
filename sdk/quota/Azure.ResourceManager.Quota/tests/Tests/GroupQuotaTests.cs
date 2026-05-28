// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.Quota.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Quota.Tests.Tests
{
    [TestFixture]
    public class GroupQuotaTests : QuotaManagementTestBase
    {
        private const string defaultSubscriptionId = "f9f44809-a71d-4ea0-9635-77ac7bbfd319";

        private const string managementGroupId = "testmg";

        public GroupQuotaTests() : base(true)
        {
        }

        [SetUp]
        public void Init()
        {
            //ArmClientOptions options = new ArmClientOptions();
            //options.Environment = new(new Uri("https://centraluseuap.management.azure.com"), "https://management.azure.com/");
            //options.SetApiVersion(new ResourceType("Microsoft.Quota/groupQuotas"), "2025-09-01");
            //DefaultAzureCredential cred = new DefaultAzureCredential();
            // var client = new ArmClient(cred, defaultSubscriptionId, options);

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
            string groupQuotaName = "sdk-test-set-group-quota-v3-create";

            // Builds the Group Quota Request Body
            GroupQuotaEntityData data = new GroupQuotaEntityData()
            {
                Properties = new GroupQuotasEntityProperties()
                {
                    DisplayName = "sdk-test-group-quota-create-v3-create"
                },
            };

            //Performs the GroupQuota PUT operation
            var createResponse = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupQuotaName, data);
            Assert.IsNotNull(createResponse);
            Assert.IsNotNull(createResponse.Value.Data.Properties);
            Assert.IsTrue(createResponse.Value.Data.Name.Equals(groupQuotaName));
            Assert.IsTrue(createResponse.Value.Data.Properties.DisplayName.Equals(data.Properties.DisplayName));

            // Delete the created Group Quota for cleanup
            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            GroupQuotaEntityResource groupQuotasEntity = Client.GetGroupQuotaEntityResource(groupQuotasEntityResourceId);
            await groupQuotasEntity.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        public async Task GetGroupQuotaLimitForAllocationGroup()
        {
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);
            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);

            // get the collection of this GroupQuotasEntityResource
            GroupQuotaEntityCollection groupQuotaEntityCollection = managementGroupResource.GetGroupQuotaEntities();

            // invoke the operation
            string groupQuotaName = "sdk-test-set-group-quota-v3-limit-test";

            // Builds the Group Quota Request Body
            GroupQuotaEntityData data = new GroupQuotaEntityData()
            {
                Properties = new GroupQuotasEntityProperties()
                {
                    DisplayName = "sdk-test-set-group-quota-v3-limit-test"
                },
            };

            //Performs the GroupQuota PUT operation
            var createGroupQuotaResponse = await groupQuotaEntityCollection.CreateOrUpdateAsync(WaitUntil.Completed, groupQuotaName, data);
            Assert.IsNotNull(createGroupQuotaResponse);

            // Set a subscription in the group. This is required to set a group limit.
            ResourceIdentifier groupQuotaEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);
            GroupQuotaEntityResource groupQuotaEntity = Client.GetGroupQuotaEntityResource(groupQuotaEntityResourceId);

            // get the collection of this GroupQuotaSubscriptionIdResource
            GroupQuotaSubscriptionCollection groupQuotaSubscriptionsCollection = groupQuotaEntity.GetGroupQuotaSubscriptions();

            // Add a Subscription to the Group Quota Object
            var addSubscriptionResponse = await groupQuotaSubscriptionsCollection.CreateOrUpdateAsync(WaitUntil.Completed, defaultSubscriptionId);
            Assert.IsNotNull(addSubscriptionResponse);

            // GroupQuotaLimit Test
            string resourceProviderName = "Microsoft.Compute";
            AzureLocation location = new AzureLocation("westus");
            ResourceIdentifier groupQuotaLimitListResourceId = GroupQuotaLimitListResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, resourceProviderName, location);
            GroupQuotaLimitListResource groupQuotaLimitList = Client.GetGroupQuotaLimitListResource(groupQuotaLimitListResourceId);

            // Create the Group Quota Limit Request Body
            List<GroupQuotaLimit> valList = new()
            {
                new GroupQuotaLimit()
                {
                    Properties = new GroupQuotaLimitProperties()
                    {
                        Limit = 50,
                        ResourceName = "cores",
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
            var setGroupQuotaLimitResponse = await groupQuotaLimitList.UpdateAsync(WaitUntil.Completed, requestBody);
            Assert.IsNotNull(setGroupQuotaLimitResponse);

            // Perform the QuotaLimit Get call
            GroupQuotaLimitListResource getResponse = await groupQuotaLimitList.GetAsync();
            Assert.IsNotNull(getResponse.Data);
            Assert.IsNotNull(getResponse.Data.Properties);
            Assert.IsTrue(getResponse.Data.Properties.Value.Count.Equals(1));
            Assert.AreEqual(valList[0].Properties.Limit, getResponse.Data.Properties.Value.First().Properties.Limit);

            // Delete the created Group Quota for cleanup. The subscription needs to be deleted first.
            ResourceIdentifier groupQuotaSubscriptionIdResourceId = GroupQuotaSubscriptionResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, defaultSubscriptionId);
            GroupQuotaSubscriptionResource groupQuotaSubscriptionResource = Client.GetGroupQuotaSubscriptionResource(groupQuotaSubscriptionIdResourceId);
            await groupQuotaSubscriptionResource.DeleteAsync(WaitUntil.Completed);
            await groupQuotaEntity.DeleteAsync(WaitUntil.Completed);
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
            Assert.IsNotNull(result.Value.Data.Properties);
            Assert.AreEqual(groupQuotaName, result.Value.Data.Name);
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
            var response = await collection.CreateOrUpdateAsync(WaitUntil.Completed, defaultSubscriptionId);

            // Clean up Sub
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
            //string resourceName = "standarddv2family";

            AzureLocation location = new AzureLocation("westus");

            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            GroupQuotaEntityResource groupQuotasEntity = Client.GetGroupQuotaEntityResource(groupQuotasEntityResourceId);

            // get the collection of this GroupQuotaSubscriptionIdResource
            GroupQuotaSubscriptionCollection collection = groupQuotasEntity.GetGroupQuotaSubscriptions();

            // Add a Subscription to the Group Quota Object
            var response = await collection.CreateOrUpdateAsync(WaitUntil.Completed, defaultSubscriptionId);

            ResourceIdentifier subscriptionQuotaAllocationsListResourceId = SubscriptionQuotaAllocationsListResource.CreateResourceIdentifier(managementGroupId, defaultSubscriptionId, groupQuotaName, resourceProviderName, location);

            SubscriptionQuotaAllocationsListResource subscriptionQuotaAllocationsList = Client.GetSubscriptionQuotaAllocationsListResource(subscriptionQuotaAllocationsListResourceId);

            //// Builds the Quota Allocation Request Body
            SubscriptionQuotaAllocationsListData data = new SubscriptionQuotaAllocationsListData()
            {
                Properties = new SubscriptionQuotaAllocationsListProperties()
                {
                    Value =
                    {
                            new SubscriptionQuotaAllocations()
                            {
                                Properties = new SubscriptionQuotaAllocationsProperties()
                                {
                                    ResourceName = "cores",
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

            GroupQuotaSubscriptionResource groupQuotaSubscriptionId = Client.GetGroupQuotaSubscriptionResource(groupQuotaSubscriptionIdResourceId);
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
            SubscriptionQuotaAllocationsListResource subscriptionQuotaAllocationsList = Client.GetSubscriptionQuotaAllocationsListResource(subscriptionQuotaAllocationsListResourceId);

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
            var data = result.Data;
            Assert.IsNotNull(data);
        }

        [TestCase]
        public async Task SetGroupQuotaLocationSettings()
        {
            // Create an allocation group.
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);
            ManagementGroupResource managementGroupResource = Client.GetManagementGroupResource(managementGroupResourceId);
            GroupQuotaEntityCollection groupQuotaEntityCollection = managementGroupResource.GetGroupQuotaEntities();

            string groupQuotaName = "sdk-enforcement-test-group";
            GroupQuotaEntityData createGroupQuotaRequest = new GroupQuotaEntityData()
            {
                Properties = new GroupQuotasEntityProperties()
                {
                    DisplayName = "sdk-enforcement-test-group"
                },
            };

            await groupQuotaEntityCollection.CreateOrUpdateAsync(WaitUntil.Completed, groupQuotaName, createGroupQuotaRequest);

            ResourceIdentifier groupQuotaEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);
            GroupQuotaEntityResource groupQuotaEntity = Client.GetGroupQuotaEntityResource(groupQuotaEntityResourceId);

            // Add a subscription to the allocation group
            GroupQuotaSubscriptionCollection collection = groupQuotaEntity.GetGroupQuotaSubscriptions();
            await collection.CreateOrUpdateAsync(WaitUntil.Completed, defaultSubscriptionId);

            // invoke the enable enforcement operation in a specified location
            string resourceProviderName = "Microsoft.Compute";
            AzureLocation location = new AzureLocation("westus");

            // get the collection of this GroupQuotasEnforcementStatusResource
            GroupQuotasEnforcementStatusCollection groupQuotaEnforcementStatusCollection = groupQuotaEntity.GetGroupQuotasEnforcementStatuses();

            GroupQuotasEnforcementStatusData data = new GroupQuotasEnforcementStatusData
            {
                Properties = new GroupQuotasEnforcementStatusProperties
                {
                    EnforcementEnabled = EnforcementState.Enabled,
                },
            };
            ArmOperation<GroupQuotasEnforcementStatusResource> lro = await groupQuotaEnforcementStatusCollection.CreateOrUpdateAsync(WaitUntil.Completed, resourceProviderName, location, data);
            GroupQuotasEnforcementStatusResource result = lro.Value;

            Assert.IsTrue(result.Data.Properties.ProvisioningState.Equals(QuotaRequestStatus.Succeeded));
            Assert.IsTrue(result.Data.Properties.EnforcementEnabled.Equals(EnforcementState.Enabled));
            Assert.IsTrue(result.Data.Name.Equals(location));

            // The enforced group name is always of the form: <groupquotaname>-<location>.
            string enforcedGroupName = $"{groupQuotaName}-{location.Name}";

            // Delete the subscription from the enforced group first.
            ResourceIdentifier enforcedGroupQuotaSubscriptionResourceId = GroupQuotaSubscriptionResource.CreateResourceIdentifier(managementGroupId, enforcedGroupName, defaultSubscriptionId);
            GroupQuotaSubscriptionResource enforceGroupQuotaSubscriptionResource = Client.GetGroupQuotaSubscriptionResource(enforcedGroupQuotaSubscriptionResourceId);
            await enforceGroupQuotaSubscriptionResource.DeleteAsync(WaitUntil.Completed);

            // Delete the subscription from the allocation group as well.
            ResourceIdentifier allocationGroupQuotaSubscriptionResourceId = GroupQuotaSubscriptionResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, defaultSubscriptionId);
            GroupQuotaSubscriptionResource allocationGroupQuotaSubscriptionResource = Client.GetGroupQuotaSubscriptionResource(allocationGroupQuotaSubscriptionResourceId);
            await allocationGroupQuotaSubscriptionResource.DeleteAsync(WaitUntil.Completed);

            // Delete the enforced group.
            ResourceIdentifier enforcedGroupQuotaEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, enforcedGroupName);
            GroupQuotaEntityResource enforcedGroupQuotaEntity = Client.GetGroupQuotaEntityResource(enforcedGroupQuotaEntityResourceId);
            await enforcedGroupQuotaEntity.DeleteAsync(WaitUntil.Completed);

            // Delete the allocation group.
            await groupQuotaEntity.DeleteAsync(WaitUntil.Started);
        }

        [TestCase]
        public async Task GetGroupQuotaLocationSettings()
        {
            // Use an existing allocation group that has enforcement enabled in westus and has at least one subscription.
            string groupQuotaName = "sdk-enforcement-test-group";
            ResourceIdentifier groupQuotaEntityResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);
            GroupQuotaEntityResource groupQuotaEntity = Client.GetGroupQuotaEntityResource(groupQuotaEntityResourceId);

            // get the collection of this GroupQuotasEnforcementStatusResource
            string resourceProviderName = "Microsoft.Compute";
            AzureLocation location = new AzureLocation("westus");
            GroupQuotasEnforcementStatusCollection collection = groupQuotaEntity.GetGroupQuotasEnforcementStatuses();

            // invoke the get location settings operation to retrieve a the enforcement status resource for a specified location
            GroupQuotasEnforcementStatusResource result = await collection.GetAsync(resourceProviderName, location);

            Assert.IsNotNull(result.Data);
            Assert.IsTrue(result.Data.Properties.ProvisioningState.Equals(QuotaRequestStatus.Succeeded));
            Assert.IsTrue(result.Data.Properties.EnforcementEnabled.Equals(EnforcementState.Enabled));
            Assert.IsTrue(result.Data.Name.Equals(location.Name));
        }

        [TestCase]
        public async Task GetGroupQuotaLimitForEnforcedGroup()
        {
            // Use an existing enforced group that has at least one subscription
            string enforcedGroupQuotaName = "sdk-enforcement-test-group-westus";

            string resourceProviderName = "Microsoft.Compute";
            AzureLocation location = new AzureLocation("westus");

            // Set the GroupQuota Limit for the enforced group
            ResourceIdentifier groupQuotaLimitListResourceId = GroupQuotaLimitListResource.CreateResourceIdentifier(managementGroupId, enforcedGroupQuotaName, resourceProviderName, location);
            GroupQuotaLimitListResource groupQuotaLimitList = Client.GetGroupQuotaLimitListResource(groupQuotaLimitListResourceId);

            // Create the Group Quota Limit Request Body
            List<GroupQuotaLimit> valList = new()
            {
                new GroupQuotaLimit()
                {
                    Properties = new GroupQuotaLimitProperties()
                    {
                        Limit = 15,
                        ResourceName = "cores",
                        Comment = "comments"
                    }
                }
            };

            // Builds the Group Quota Request Body
            GroupQuotaLimitListData quotaRequestBody = new()
            {
                Properties = new GroupQuotaLimitListProperties(null, valList, "", null)
            };

            // Perform the QuotaLimit Request call
            var setGroupQuotaLimitResponse = await groupQuotaLimitList.UpdateAsync(WaitUntil.Completed, quotaRequestBody);
            Assert.IsNotNull(setGroupQuotaLimitResponse);

            // Perform the QuotaLimit Get call
            GroupQuotaLimitListResource getResponse = await groupQuotaLimitList.GetAsync();
            Assert.IsNotNull(getResponse.Data);
            Assert.IsNotNull(getResponse.Data.Properties);
            Assert.IsTrue(getResponse.Data.Properties.Value.Any());
            Assert.AreEqual(valList[0].Properties.Limit, getResponse.Data.Properties.Value.Single(limit => limit.Properties.ResourceName == valList[0].Properties.ResourceName).Properties.Limit);
        }

        [TestCase]
        public async Task GetGroupQuotaUsagesForEnforcedGroup()
        {
            // Get an Enforced Group Quota Entity.
            string enforcedGroupQuotaName = "sdk-enforcement-test-group-westus";
            ResourceIdentifier enforcedGroupQuotaResourceId = GroupQuotaEntityResource.CreateResourceIdentifier(managementGroupId, enforcedGroupQuotaName);
            GroupQuotaEntityResource enforcedGroupQuotaEntity = Client.GetGroupQuotaEntityResource(enforcedGroupQuotaResourceId);

            // Get the GroupQuotaResourceUsages
            string resourceProviderName = "Microsoft.Compute";
            AzureLocation location = new AzureLocation("westus");

            await foreach (GroupQuotaResourceUsages item in enforcedGroupQuotaEntity.ListAsync(resourceProviderName, location))
            {
                Assert.IsNotNull(item);
                Assert.IsNotNull(item.Properties);
            }
        }
    }
}
