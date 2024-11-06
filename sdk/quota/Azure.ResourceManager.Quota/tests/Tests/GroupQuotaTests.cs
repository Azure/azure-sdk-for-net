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

        private const string ppeEndpointBaseUri = "https://centraluseuap.management.azure.com";

        [TestCase]
        public async Task SetGroupQuota()
        {
            var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEndpointBaseUri), "https://management.azure.com/");
            //var rType = Resources.ResourceProviderResource.Get("Microsoft.Quota");
            options.SetApiVersion(new ResourceType("Microsoft.Quota/groupQuotas"), "2024-10-15-preview");

            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client

            ArmClient client = new ArmClient(cred, defaultSubscriptionId, options);

            string managementGroupId = "testMgIdRoot";
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
    }
}
