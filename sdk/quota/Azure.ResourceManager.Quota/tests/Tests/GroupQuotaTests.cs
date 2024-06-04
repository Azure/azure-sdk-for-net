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
            string groupQuotaName = "sdk-test-group-quota-create";
            GroupQuotasEntityData data = new GroupQuotasEntityData()
            {
                Properties = new GroupQuotasEntityBase()
                {
                    DisplayName = "sdk-test-group-quota-create",
                    AdditionalAttributes = new AdditionalAttributes(new GroupingId()
                    {
                        GroupingIdType = GroupingIdType.BillingId,
                        Value = "ad41a99f-9c42-4b3d-9770-e711a24d8542",
                    })
                },
            };
            var createResponse  = await collection.CreateOrUpdateAsync(WaitUntil.Started, groupQuotaName, data);
            Assert.IsNotNull(createResponse);

            //Delete the createGroupQuota
            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotasEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            GroupQuotasEntityResource groupQuotasEntity = client.GetGroupQuotasEntityResource(groupQuotasEntityResourceId);
            await groupQuotasEntity.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        public async Task PatchGroupQuota()
        {
            var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEnvironmentEndpoint), "https://management.azure.com/");
            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client

            ArmClient client = new ArmClient(cred, defaultSubscriptionId, options);

            string managementGroupId = "testMgIdRoot";
            string groupQuotaName = "sdk-test-group-quota";

            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotasEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);

            // create body
            GroupQuotasEntityPatch patch = new GroupQuotasEntityPatch()
            {
                Properties = new GroupQuotasEntityBasePatch()
                {
                    DisplayName = "sdk-test-group-quota",
                    AdditionalAttributes = new AdditionalAttributesPatch()
                    {
                        GroupId = new GroupingId()
                        {
                            GroupingIdType = GroupingIdType.BillingId,
                            Value = "ad41a99f-9c42-4b3d-9770-e711a24d8542",
                        },
                    },
                },
            };

            //Patch the GroupQuota
            GroupQuotasEntityResource groupQuotasEntity = client.GetGroupQuotasEntityResource(groupQuotasEntityResourceId);
            var response = await groupQuotasEntity.UpdateAsync(WaitUntil.Started, patch);
            Assert.NotNull(response);
        }

        [TestCase]
        public async Task GetGroupQuotaList()
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
            var collection =  managementGroupResource.GetGroupQuotasEntities();
            await foreach (GroupQuotasEntityResource item in collection.GetAllAsync())
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                GroupQuotasEntityData resourceData = item.Data;
                // for demo we just print out the id
                Assert.NotNull(resourceData);
            }
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

            string managementGroupId = "testMgIdRoot";
            string groupQuotaName = "sdk-test-group-quota";

            ResourceIdentifier groupQuotasEntityResourceId = GroupQuotasEntityResource.CreateResourceIdentifier(managementGroupId, groupQuotaName);
            GroupQuotasEntityResource groupQuotasEntity = client.GetGroupQuotasEntityResource(groupQuotasEntityResourceId);
            //"Microsoft.Compute", "standardDv4family", data= patch

            var response = await groupQuotasEntity.CreateOrUpdateGroupQuotaLimitsRequestAsync(WaitUntil.Started, "Microsoft.Compute", "standarddv4family", requestBody);
            Assert.IsNotNull(response);
        }

        [TestCase]
        public async Task SetSubscription()
        {
            // Generated from example definition: specification/quota/resource-manager/Microsoft.Quota/preview/2023-06-01-preview/examples/GroupQuotasSubscriptions/PatchGroupQuotasSubscription.json
            // this example is just showing the usage of "GroupQuotaSubscriptions_Update" operation, for the dependent resources, they will have to be created separately.
            var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEnvironmentEndpoint), "https://management.azure.com/");

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred, defaultSubscriptionId, options);

            // this example assumes you already have this GroupQuotaSubscriptionIdResource created on azure
            // for more information of creating GroupQuotaSubscriptionIdResource, please refer to the document of GroupQuotaSubscriptionIdResource
            string managementGroupId = "testMgIdRoot";
            string groupQuotaName = "sdk-test-group-quota";
            string subscriptionId = "65a85478-2333-4bbd-981b-1a818c944faf";
            ResourceIdentifier groupQuotaSubscriptionIdResourceId = GroupQuotaSubscriptionIdResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, subscriptionId);
            GroupQuotaSubscriptionIdResource groupQuotaSubscriptionId = client.GetGroupQuotaSubscriptionIdResource(groupQuotaSubscriptionIdResourceId);

            // invoke the operation
            var response = await groupQuotaSubscriptionId.UpdateAsync(WaitUntil.Started);
            Assert.IsNotNull(response);

            await groupQuotaSubscriptionId.DeleteAsync(WaitUntil.Started);
        }

        [TestCase]
        public async Task SetSubscriptionAllocationRequest()
        {
            // Generated from example definition: specification/quota/resource-manager/Microsoft.Quota/preview/2023-06-01-preview/examples/GroupQuotasSubscriptions/PatchGroupQuotasSubscription.json
            // this example is just showing the usage of "GroupQuotaSubscriptions_Update" operation, for the dependent resources, they will have to be created separately.
            var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEnvironmentEndpoint), "https://management.azure.com/");

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred, defaultSubscriptionId, options);

            // invoke the operation
            string subscriptionId = "65a85478-2333-4bbd-981b-1a818c944faf";
            string groupQuotaName = "sdk-test-group-quota";
            string resourceProviderName = "Microsoft.Compute";
            string resourceName = "standarddv2family";

            // this example assumes you already have this ManagementGroupResource created on azure
            // for more information of creating ManagementGroupResource, please refer to the document of ManagementGroupResource
            string managementGroupId = "testMgIdRoot";
            ResourceIdentifier groupQuotaSubscriptionIdResourceId = GroupQuotaSubscriptionIdResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, subscriptionId);
            GroupQuotaSubscriptionIdResource groupQuotaSubscriptionId = client.GetGroupQuotaSubscriptionIdResource(groupQuotaSubscriptionIdResourceId);

            // invoke the operation
            var subscriptionAddResponse = await groupQuotaSubscriptionId.UpdateAsync(WaitUntil.Started);
            Assert.IsNotNull(subscriptionAddResponse);

            QuotaAllocationRequestStatusData data = new QuotaAllocationRequestStatusData()
            {
                RequestedResource = new QuotaAllocationRequestBase()
                {
                    Limit = 20,
                    Region = "westus2",
                },
            };
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);
            ManagementGroupResource managementGroupResource = client.GetManagementGroupResource(managementGroupResourceId);

            var allocationResponse = await managementGroupResource.CreateOrUpdateGroupQuotaSubscriptionAllocationRequestAsync(WaitUntil.Started, subscriptionId, groupQuotaName, resourceProviderName, resourceName, data);
            Assert.IsNotNull(allocationResponse);
        }

        [TestCase]
        public async Task GetSubscriptionAllocation()
        {
            // Generated from example definition: specification/quota/resource-manager/Microsoft.Quota/preview/2023-06-01-preview/examples/GroupQuotasSubscriptions/PatchGroupQuotasSubscription.json
            // this example is just showing the usage of "GroupQuotaSubscriptions_Update" operation, for the dependent resources, they will have to be created separately.
            var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEnvironmentEndpoint), "https://management.azure.com/");

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred, defaultSubscriptionId, options);

            // this example assumes you already have this ManagementGroupResource created on azure
            // for more information of creating ManagementGroupResource, please refer to the document of ManagementGroupResource
            string managementGroupId = "testMgIdRoot";
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);
            ManagementGroupResource managementGroupResource = client.GetManagementGroupResource(managementGroupResourceId);

            // invoke the operation
            string subscriptionId = "65a85478-2333-4bbd-981b-1a818c944faf";
            string groupQuotaName = "sdk-test-group-quota";
            string resourceName = "standarddv2family";
            ResourceIdentifier subscriptionQuotaAllocationResourceId = SubscriptionQuotaAllocationResource.CreateResourceIdentifier(managementGroupId, subscriptionId, groupQuotaName, resourceName);
            SubscriptionQuotaAllocationResource subscriptionQuotaAllocation = client.GetSubscriptionQuotaAllocationResource(subscriptionQuotaAllocationResourceId);

            // invoke the operation
            string filter = "provider eq Microsoft.Compute & location eq westus2";
            var result = await subscriptionQuotaAllocation.GetAsync(filter);
            Assert.IsNotNull(result);
        }

        [TestCase]
        public async Task GetSubscriptionAllocationList()
        {
            // Generated from example definition: specification/quota/resource-manager/Microsoft.Quota/preview/2023-06-01-preview/examples/GroupQuotasSubscriptions/PatchGroupQuotasSubscription.json
            // this example is just showing the usage of "GroupQuotaSubscriptions_Update" operation, for the dependent resources, they will have to be created separately.
            var options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri(ppeEnvironmentEndpoint), "https://management.azure.com/");

            // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
            TokenCredential cred = new DefaultAzureCredential();
            // authenticate your client
            ArmClient client = new ArmClient(cred, defaultSubscriptionId, options);

            // this example assumes you already have this ManagementGroupResource created on azure
            // for more information of creating ManagementGroupResource, please refer to the document of ManagementGroupResource
            string managementGroupId = "testMgIdRoot";
            ResourceIdentifier managementGroupResourceId = ManagementGroupResource.CreateResourceIdentifier(managementGroupId);
            ManagementGroupResource managementGroupResource = client.GetManagementGroupResource(managementGroupResourceId);

            // get the collection of this SubscriptionQuotaAllocationResource
            string subscriptionId = "65a85478-2333-4bbd-981b-1a818c944faf";
            string groupQuotaName = "sdk-test-group-quota";
            SubscriptionQuotaAllocationCollection collection = managementGroupResource.GetSubscriptionQuotaAllocations(subscriptionId, groupQuotaName);

            // invoke the operation and iterate over the result
            string filter = "provider eq Microsoft.Compute & location eq westus2";
            await foreach (SubscriptionQuotaAllocationResource item in collection.GetAllAsync(filter))
            {
                // the variable item is a resource, you could call other operations on this instance as well
                // but just for demo, we get its data from this resource instance
                var resourceData = item.Data;

                Assert.IsNotNull(resourceData);
            }
        }
    }
}
