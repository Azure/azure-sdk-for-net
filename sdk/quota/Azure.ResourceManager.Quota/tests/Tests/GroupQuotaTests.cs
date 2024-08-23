// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Quota.Models;
using NUnit.Framework;
using Azure.ResourceManager.ManagementGroups;
using Azure.Identity;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.Quota.Tests.Tests
{
    [TestFixture]
    public class GroupQuotaTests : QuotaManagementTestBase
    {
        // Change this to your own subscription
        private const string defaultSubscriptionId = "65a85478-2333-4bbd-981b-1a818c944faf";

        //Change this to your own MG
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
            var createResponse = await collection.CreateOrUpdateAsync(WaitUntil.Completed, groupQuotaName, data);
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
            var collection = managementGroupResource.GetGroupQuotaEntities();

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
                        Limit = 10000,
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

            // Get the QuotaLimit Response
            var check = response.GetRawResponse();

            string locationUri = "";
            check.Headers.TryGetValue("Location", out locationUri);

            // Get the requestId from the operationStatus URI
            Regex regex = new Regex(@"groupQuotaOperationsStatus/([^?]+)");
            Match match = regex.Match(locationUri);
            string requestId = "";
            if (match.Success)
            {
                requestId = match.Groups[1].Value;
                Console.WriteLine(requestId);
            }
            else
            {
                Console.WriteLine("requestId not found");
            }

            ResourceIdentifier groupQuotaRequestStatusResourceId = GroupQuotaRequestStatusResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, requestId);

            GroupQuotaRequestStatusResource groupQuotaRequestStatusResource = Client.GetGroupQuotaRequestStatusResource(groupQuotaRequestStatusResourceId);

            // invoke the operation
            DateTime startTime = DateTime.Now;
            string finalStatus = "";
            // Poll the operation Staus with request ID for 5 minutes
            while ((DateTime.Now - startTime) < TimeSpan.FromMinutes(5))
            {
                // invoke the operation
                GroupQuotaRequestStatusResource result = await groupQuotaRequestStatusResource.GetAsync();

                var provisioningState = result.Data.Properties.ProvisioningState.ToString();

                if (provisioningState != "Accepted" && provisioningState != "InProgress")
                {
                    if (provisioningState == "Escalated")
                    {
                        Console.WriteLine("Request has been escalated.Please reach out to your capacity manager for more information on this request");
                        finalStatus = provisioningState;
                        Assert.Inconclusive();
                        break;
                    }
                    else if (provisioningState == "Failed")
                    {
                        // Display a Fault code and let them know to reach out to capacity manager
                        Console.WriteLine($"Group Quota Limit Request Failed. FaultCode :{result?.Data?.Properties?.FaultCode}");
                        finalStatus = provisioningState;
                        break;
                    }
                    else
                    {
                        //Remove asserts and change to logging
                        Assert.AreEqual("Succeeded", provisioningState);
                        finalStatus = provisioningState;
                        break;
                    }
                }

                // Sleep for 30 seconds
                System.Threading.Thread.Sleep(30000);
            }

            //If past 5 mins write message to display operationStatus URI;
            if (finalStatus == "" || finalStatus == "Escalated")
            {
                Console.WriteLine($"Request has not reached a terminal state. Please continue to poll using this uri :{locationUri}");
            }
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
            var response = await collection.CreateOrUpdateAsync(WaitUntil.Completed, defaultSubscriptionId);

            //Clean up Sub
            ResourceIdentifier groupQuotaSubscriptionIdResourceId = GroupQuotaSubscriptionResource.CreateResourceIdentifier(managementGroupId, groupQuotaName, defaultSubscriptionId);

            GroupQuotaSubscriptionResource groupQuotaSubscriptionId = Client.GetGroupQuotaSubscriptionResource(groupQuotaSubscriptionIdResourceId);

            await groupQuotaSubscriptionId.DeleteAsync(WaitUntil.Completed);
        }

        [TestCase]
        public async Task SetSubscriptionAllocationRequest()
        {
            ArmClientOptions options = new ArmClientOptions();
            options.Environment = new ArmEnvironment(new Uri("https://eastus2euap.management.azure.com"), "https://management.azure.com/");
            var Client = new ArmClient(TestEnvironment.Credential, defaultSubscriptionId, options);
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

            // Get the QuotaLimit Response
            var check = allocationResponse.GetRawResponse();

            string locationUri = "";
            check.Headers.TryGetValue("Location", out locationUri);

            // Get the requestId from the operationStatus URI
            Regex regex = new Regex(@"quotaAllocationOperationsStatus/([^?]+)");
            Match match = regex.Match(locationUri);
            string requestId = "";
            if (match.Success)
            {
                requestId = match.Groups[1].Value;
                Console.WriteLine(requestId);
            }
            else
            {
                Console.WriteLine("requestId not found");
            }

            ResourceIdentifier quotaAllocationRequestId = QuotaAllocationRequestStatusResource.CreateResourceIdentifier(managementGroupId, defaultSubscriptionId, groupQuotaName, requestId);

            QuotaAllocationRequestStatusResource quotaAllocationStatusResource = Client.GetQuotaAllocationRequestStatusResource(quotaAllocationRequestId);

            // invoke the operation
            DateTime startTime = DateTime.Now;
            string finalStatus = "";
            // Poll the operation Staus with request ID for 3 minutes
            while ((DateTime.Now - startTime) < TimeSpan.FromMinutes(3))
            {
                // invoke the operation to get based on requestId
                QuotaAllocationRequestStatusResource result = await quotaAllocationStatusResource.GetAsync();

                var provisioningState = result.Data.ProvisioningState.ToString();
                Console.WriteLine(provisioningState);
                if (provisioningState != "Accepted" && provisioningState != "InProgress")
                {
                    if (provisioningState == "Escalated")
                    {
                        Console.WriteLine("Request has been escalated.Please reach out to your capacity manager for more information on this request");
                        Assert.Inconclusive();
                        finalStatus = provisioningState;
                        break;
                    }
                    else if (provisioningState == "Failed")
                    {
                        // Display a Fault code and let them know to reach out to capacity manager
                        Console.WriteLine($"Subscription Quota Allocation Request Failed. FaultCode :{result?.Data?.FaultCode}");
                        finalStatus = provisioningState;
                    }
                    else
                    {
                        Assert.AreEqual("Succeeded", provisioningState);
                        finalStatus = provisioningState;
                        break;
                    }
                }

                // Sleep for 30 seconds
                System.Threading.Thread.Sleep(30000);
            }

            if (finalStatus == "" || finalStatus == "Escalated")
            {
                Console.WriteLine($"Request has not reached a terminal state. Please continue to poll using this uri :{locationUri}");
            }

            // Delete the Subscription as part of test cleanup
            await groupQuotaSubscriptionId.DeleteAsync(WaitUntil.Completed);
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
