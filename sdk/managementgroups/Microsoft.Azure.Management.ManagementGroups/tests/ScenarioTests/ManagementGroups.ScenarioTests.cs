using System.Linq;
using System.Linq.Expressions;
using System.Net;
using Microsoft.Azure.Management.ManagementGroups;
using Microsoft.Azure.Management.ManagementGroups.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Resource.Tests.Helpers;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveManagementGroupsTests : TestBase
    {
        [Fact]
        public void ListGroups()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                //var managementGroupsClient = context.GetServiceClient<ManagementGroupsAPIClient>();

                var managementGroups = managementGroupsClient.ManagementGroups.List();

                Assert.NotNull(managementGroups);
                Assert.NotEmpty(managementGroups);

                Assert.NotNull(managementGroups.First().Id);
                Assert.NotNull(managementGroups.First().Type);
                Assert.NotNull(managementGroups.First().Name);
                Assert.NotNull(managementGroups.First().DisplayName);
                Assert.NotNull(managementGroups.First().TenantId);
            }
        }

        [Fact]
        public void GetGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "TestGroup1Child1";

                var managementGroup = managementGroupsClient.ManagementGroups.Get(groupId);

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1", managementGroup.Id);
                Assert.Equal("TestGroup1Child1", managementGroup.Name);
                Assert.Equal("TestGroup1->Child1", managementGroup.DisplayName);
                Assert.Equal("Microsoft.Management/managementGroups", managementGroup.Type);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1", managementGroup.Details.Parent.Id);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.Name);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.DisplayName);
            }
        }

        [Fact]
        public void GetGroupExpand()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "TestGroup1Child1";

                var managementGroup = managementGroupsClient.ManagementGroups.Get(groupId, "children");

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1", managementGroup.Id);
                Assert.Equal("TestGroup1Child1", managementGroup.Name);
                Assert.Equal("TestGroup1->Child1", managementGroup.DisplayName);
                Assert.Equal("Microsoft.Management/managementGroups", managementGroup.Type);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1", managementGroup.Details.Parent.Id);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.Name);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.DisplayName);

                Assert.NotNull(managementGroup.Children);
                Assert.Null(managementGroup.Children.First().Children);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1Child1", managementGroup.Children.First().Id);
                Assert.Equal("TestGroup1Child1Child1", managementGroup.Children.First().Name);
                Assert.Equal("TestGroup1->Child1->Child1", managementGroup.Children.First().DisplayName);
                Assert.Equal("Microsoft.Management/managementGroups", managementGroup.Children.First().Type);
            }
        }

        [Fact]
        public void GetGroupExpandRecurse()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "TestGroup1";

                var managementGroup = managementGroupsClient.ManagementGroups.Get(groupId, "children", true);

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1", managementGroup.Id);
                Assert.Equal("TestGroup1", managementGroup.Name);
                Assert.Equal("TestGroup1", managementGroup.DisplayName);
                Assert.Equal("Microsoft.Management/managementGroups", managementGroup.Type);

                Assert.NotNull(managementGroup.Children);
                Assert.NotNull(managementGroup.Children.First().Children);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1", managementGroup.Children.First().Id);
                Assert.Equal("TestGroup1Child1", managementGroup.Children.First().Name);
                Assert.Equal("TestGroup1->Child1", managementGroup.Children.First().DisplayName);
                Assert.Equal("Microsoft.Management/managementGroups", managementGroup.Children.First().Type);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1Child1", managementGroup.Children.First().Children.First().Id);
                Assert.Equal("TestGroup1Child1Child1", managementGroup.Children.First().Children.First().Name);
                Assert.Equal("TestGroup1->Child1->Child1", managementGroup.Children.First().Children.First().DisplayName);
                Assert.Equal("Microsoft.Management/managementGroups", managementGroup.Children.First().Children.First().Type);
            }
        }

        //[Fact(Skip="Skipping for now. Investigating why it is failing.")]
        [Fact]
        public void GetEntities()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                //GetEntities lists all entities under the tenant, providing a groupId would give a bad request error
                var entities = managementGroupsClient.Entities.List();

                Assert.NotNull(entities);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1", entities.ElementAt(1).Id);
                Assert.Equal("TestGroup1", entities.ElementAt(1).Name);
                Assert.Equal("TestGroup1", entities.ElementAt(1).DisplayName);
                Assert.Equal("Microsoft.Management/managementGroups", entities.ElementAt(1).Type);

                Assert.NotNull(entities.ElementAt(5));
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1", entities.ElementAt(5).Id);
                Assert.Equal("TestGroup1Child1", entities.ElementAt(5).Name);
                Assert.Equal("TestGroup1->Child1", entities.ElementAt(5).DisplayName);
                Assert.Equal("Microsoft.Management/managementGroups", entities.ElementAt(5).Type);
            }
        }

        [Fact]
        public void CreateGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "TestGroup1Child2";
                //var groupId = "TestGroup1Child1Child1";

                var managementGroup = ((ManagementGroup)managementGroupsClient.ManagementGroups.CreateOrUpdate(groupId,
                    new CreateManagementGroupRequest(
                        id: "/providers/Microsoft.Management/managementGroups/TestGroup1Child2",
                        type: "/providers/Microsoft.Management/managementGroups",
                        name: "TestGroup1Child2", 
                        displayName: "TestGroup1->Child2", 
                        details: new CreateManagementGroupDetails()
                        {
                            Parent = new CreateParentGroupInfo()
                            {
                                Id = "/providers/Microsoft.Management/managementGroups/TestGroup1"
                            }
                        }), cacheControl: "no-cache"));

                //managementGroupsClient.ManagementGroups.Delete(groupId, cacheControl: "no-cache");

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child2", managementGroup.Id);
                Assert.Equal("TestGroup1Child2", managementGroup.Name);
                Assert.Equal("TestGroup1->Child2", managementGroup.DisplayName);
                Assert.Equal("Microsoft.Management/managementGroups", managementGroup.Type);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1", managementGroup.Details.Parent.Id);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.Name);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.DisplayName);
            }
        }

        [Fact]
        public void UpdateGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "TestGroup1Child1";
                var newDisplayName = "TestGroup1->Child1";
                var newParent = "/providers/Microsoft.Management/managementGroups/TestGroup1"; //c7a87cda-9a66-4920-b0f8-869baa04efe0

                var updateGroup = managementGroupsClient.ManagementGroups.Update(groupId,
                    new PatchManagementGroupRequest()
                    {
                        DisplayName = newDisplayName,
                        ParentGroupId = newParent
                    }, cacheControl: "no-cache");

                Assert.NotNull(updateGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/" + groupId, updateGroup.Id);
                Assert.Equal("Microsoft.Management/managementGroups", updateGroup.Type);
                Assert.Equal("TestGroup1Child1", updateGroup.Name);
                Assert.Equal(newDisplayName, updateGroup.DisplayName);
                Assert.Equal(newParent, updateGroup.Details.Parent.Id);
            }
        }

        [Fact]
        public void CreateGroupSubscription()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.NoContent });

                var groupId = "TestGroup1Child1Child1";
                var subscriptionId = "5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de";

                managementGroupsClient.ManagementGroupSubscriptions.Create(groupId, subscriptionId, cacheControl: "no-cache");
            }
        }

        [Fact]
        public void GetGroupSubscription()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.NoContent });

                var groupId = "TestGroup1Child1Child1";
                var subscriptionId = "5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de";

                var getSubscription = managementGroupsClient.ManagementGroupSubscriptions.GetSubscription(groupId, subscriptionId, cacheControl: "no-cache");

                Assert.NotNull(getSubscription);

                Assert.Equal(subscriptionId, getSubscription.Name);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1Child1/subscriptions/" + subscriptionId,
                    getSubscription.Id);
                Assert.Equal("Microsoft.Management/managementGroups/subscriptions", getSubscription.Type);
                Assert.Equal("Visual Studio Enterprise Subscription", getSubscription.DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/" + groupId, getSubscription.Parent.Id);
            }
        }
        [Fact]
        public void GetSubscriptionUnderGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.NoContent });

                var groupId = "TestGroup1Child1Child1";
                var subscriptionId = "5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de";

                var getSubscriptionUnderGroup = managementGroupsClient.ManagementGroupSubscriptions.GetSubscriptionsUnderManagementGroup(groupId).ToArray();

                Assert.NotNull(getSubscriptionUnderGroup);
                Assert.Equal(subscriptionId, getSubscriptionUnderGroup[0].Name);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1Child1/subscriptions/" + subscriptionId,
                    getSubscriptionUnderGroup[0].Id);
                Assert.Equal("Microsoft.Management/managementGroups/subscriptions", getSubscriptionUnderGroup[0].Type);
                Assert.Equal("Visual Studio Enterprise Subscription", getSubscriptionUnderGroup[0].DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/" + groupId, getSubscriptionUnderGroup[0].Parent.Id);
            }
        }

        [Fact]
        public void DeleteGroupSubscription()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.NoContent });

                var groupId = "TestGroup1Child1Child1";
                var subscriptionId = "5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de";

                managementGroupsClient.ManagementGroupSubscriptions.Create(groupId, subscriptionId, cacheControl: "no-cache");
                managementGroupsClient.ManagementGroupSubscriptions.Delete(groupId, subscriptionId, cacheControl: "no-cache");
            }
        }

        [Fact]
        public void DeleteGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "TestGroup1Child2";

                managementGroupsClient.ManagementGroups.Delete(groupId, cacheControl: "no-cache");
            }
        }

        [Fact]
        public void CheckNameAvailibilityTrue()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupName = "TestGroup2";

                var response =
                    managementGroupsClient.CheckNameAvailability(new CheckNameAvailabilityRequest(groupName, Type.MicrosoftManagementManagementGroups)); //HyphenMinusprovidersHyphenMinusMicrosoftFullStopManagementHyphenMinusmanagementGroups

                Assert.True(response.NameAvailable);
            }
        }

        [Fact]
        public void CheckNameAvailibilityFalse()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupName = "TestGroup1";

                var response =
                    managementGroupsClient.CheckNameAvailability(new CheckNameAvailabilityRequest(groupName, Type.MicrosoftManagementManagementGroups));

                Assert.False(response.NameAvailable);
            }
        }

        [Fact]
        public void StartTenantBackfill()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var response =
                    managementGroupsClient.StartTenantBackfill();

                Assert.Equal(Status.Completed, response.Status);
            }
        }

        [Fact]
        public void TenantBackfillStatus()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var response =
                    managementGroupsClient.TenantBackfillStatus();

                Assert.Equal(Status.Completed, response.Status);
            }
        }

        [Fact]
        public void CreateSetting()
        {
            using (MockContext context= MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                string groupId = "c7a87cda-9a66-4920-b0f8-869baa04efe0";

                var hierarchySetting = managementGroupsClient.HierarchySettings.CreateOrUpdate(groupId, new CreateOrUpdateSettingsRequest()
                {
                    RequireAuthorizationForGroupCreation = true,
                    DefaultManagementGroup = "/providers/Microsoft.Management/managementGroups/TestGroup1"
                });

                Assert.NotNull(hierarchySetting);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default", hierarchySetting.Id);
                Assert.Equal("Microsoft.Management/managementGroups/settings", hierarchySetting.Type);
                Assert.Equal("default", hierarchySetting.Name);
                Assert.Equal(groupId, hierarchySetting.TenantId);
                Assert.True(hierarchySetting.RequireAuthorizationForGroupCreation);
                Assert.Equal("TestGroup1", hierarchySetting.DefaultManagementGroup);
            }
        }

        [Fact]
        public void GetSetting()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                string groupId = "c7a87cda-9a66-4920-b0f8-869baa04efe0";

                var hierarchySetting = managementGroupsClient.HierarchySettings.Get(groupId);

                Assert.NotNull(hierarchySetting);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default", hierarchySetting.Id);
                Assert.Equal("Microsoft.Management/managementGroups/settings", hierarchySetting.Type);
                Assert.Equal("default", hierarchySetting.Name);
                Assert.Equal(groupId, hierarchySetting.TenantId);
                Assert.True(hierarchySetting.RequireAuthorizationForGroupCreation);
                Assert.Equal("TestGroup1", hierarchySetting.DefaultManagementGroup);
            }
        }

        [Fact]public void DeleteSetting()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                string groupId = "c7a87cda-9a66-4920-b0f8-869baa04efe0";

                managementGroupsClient.HierarchySettings.Delete(groupId);
            }
        }
    }
}
