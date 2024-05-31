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
using Azure.Identity;

namespace Azure.ResourceManager.Quota.Tests.Tests
{
    [TestFixture]
    public class GroupQuotaTests : QuotaManagementTestBase
    {
        private const string ppeEnvironmentEndpoint = "https://eastus2euap.management.azure.com";
        private const string defaultSubscriptionId = "65a85478-2333-4bbd-981b-1a818c944faf";

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
            var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEnvironmentEndpoint), "https://management.azure.com/");
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client

            ArmClient client = new ArmClient(cred, defaultSubscriptionId, options);

            string managementGroupId = "testMgIdRoot";
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);
            ManagementGroupResource managementGroupResource = client.GetManagementGroupResource(managementGroupResourceId);

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

            // resourceData serves as the ARM response
            GroupQuotasEntityData resourceData = result.Data;

            Console.WriteLine($"Succeeded on id: {resourceData.Id}");
            Assert.AreEqual(resourceData.Properties.DisplayName, "sdk-test-group-quota");
            Assert.AreEqual(resourceData.Name, "sdk-test-group-quota");
        }

        [TestCase]
        public async Task SetGroupQuotaLimit()
        {
            // invoke the operation
            SubmittedResourceRequestStatusData requestBody = new SubmittedResourceRequestStatusData()
            {
                Properties = new SubmittedResourceRequestStatusProperties()
                {
                    RequestedResource = new GroupQuotaRequestBase()
                    {
                        Limit = 225,
                        Region = "westus",
                        Comments = "ticketComments"
                    }
                },
            };

            var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEnvironmentEndpoint), "https://management.azure.com/");
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred, defaultSubscriptionId, options);
            try
            {
                string managementGroupId = "testMgIdRoot";
                string groupQuotaName = "sdk-test-group-quota";
                ResourceIdentifier groupQuotasEntityResourceId = GroupQuotasEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);
                GroupQuotasEntityResource groupQuotasEntity = client.GetGroupQuotasEntityResource(groupQuotasEntityResourceId);
                //"Microsoft.Compute", "standardDv4family", data= patch

                ArmOperation<SubmittedResourceRequestStatusResource> lro = await groupQuotasEntity.CreateOrUpdateGroupQuotaLimitsRequestAsync(WaitUntil.Completed, "Microsoft.Compute", "standarddv4family", requestBody);
                SubmittedResourceRequestStatusResource result = lro.Value;
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
