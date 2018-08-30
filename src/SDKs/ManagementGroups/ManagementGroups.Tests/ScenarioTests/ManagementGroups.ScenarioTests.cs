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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "TestGroup1Child1";

                var managementGroup = managementGroupsClient.ManagementGroups.Get(groupId);

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1", managementGroup.Id);
                Assert.Equal("TestGroup1Child1", managementGroup.Name);
                Assert.Equal("TestGroup1->Child1", managementGroup.DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Type);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1", managementGroup.Details.Parent.Id);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.Name);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.DisplayName);
            }
        }

        [Fact]
        public void GetGroupExpand()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "TestGroup1Child1";

                var managementGroup = managementGroupsClient.ManagementGroups.Get(groupId, "children");

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1", managementGroup.Id);
                Assert.Equal("TestGroup1Child1", managementGroup.Name);
                Assert.Equal("TestGroup1->Child1", managementGroup.DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Type);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1", managementGroup.Details.Parent.Id);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.Name);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.DisplayName);

                Assert.NotNull(managementGroup.Children);
                Assert.Null(managementGroup.Children.First().Children);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1Child1", managementGroup.Children.First().Id);
                Assert.Equal("TestGroup1Child1Child1", managementGroup.Children.First().Name);
                Assert.Equal("TestGroup1->Child1->Child1", managementGroup.Children.First().DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Children.First().Type);
            }
        }

        [Fact]
        public void GetGroupExpandRecurse()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "TestGroup1";

                var managementGroup = managementGroupsClient.ManagementGroups.Get(groupId, "children", true);

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1", managementGroup.Id);
                Assert.Equal("TestGroup1", managementGroup.Name);
                Assert.Equal("TestGroup1", managementGroup.DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Type);

                Assert.NotNull(managementGroup.Children);
                Assert.NotNull(managementGroup.Children.First().Children);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1", managementGroup.Children.First().Id);
                Assert.Equal("TestGroup1Child1", managementGroup.Children.First().Name);
                Assert.Equal("TestGroup1->Child1", managementGroup.Children.First().DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Children.First().Type);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1Child1", managementGroup.Children.First().Children.First().Id);
                Assert.Equal("TestGroup1Child1Child1", managementGroup.Children.First().Children.First().Name);
                Assert.Equal("TestGroup1->Child1->Child1", managementGroup.Children.First().Children.First().DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Children.First().Children.First().Type);
            }
        }

        [Fact(Skip="Skipping for now. Investigating why it is failing.")]
        public void GetEntities()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                var groupId = "TestGroup1";

                var entities = managementGroupsClient.Entities.List(groupId);

                Assert.NotNull(entities);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1", entities.ElementAt(1).Id);
                Assert.Equal("TestGroup1", entities.ElementAt(1).Name);
                Assert.Equal("TestGroup1", entities.ElementAt(1).DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", entities.ElementAt(1).Type);

                Assert.NotNull(entities.ElementAt(2));
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child1", entities.ElementAt(2).Id);
                Assert.Equal("TestGroup1Child1", entities.ElementAt(2).Name);
                Assert.Equal("TestGroup1->Child1", entities.ElementAt(2).DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", entities.ElementAt(2).Type);
            }
        }

        [Fact]
        public void CreateGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "TestGroup1Child2";

                var managementGroup = ((JObject) managementGroupsClient.ManagementGroups.CreateOrUpdate(groupId,
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
                        }), cacheControl: "no-cache")).ToObject<ManagementGroup>(JsonSerializer.Create(managementGroupsClient.DeserializationSettings));

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1Child2", managementGroup.Id);
                Assert.Equal("TestGroup1Child2", managementGroup.Name);
                Assert.Equal("TestGroup1->Child2", managementGroup.DisplayName);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Type);

                Assert.Equal("/providers/Microsoft.Management/managementGroups/TestGroup1", managementGroup.Details.Parent.Id);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.Name);
                Assert.Equal("TestGroup1", managementGroup.Details.Parent.DisplayName);
            }
        }

        [Fact]
        public void CreateGroupSubscription()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.NoContent });

                var groupId = "TestGroup1Child1Child1";
                var subscriptionId = "7635efed-eeec-4c03-885d-fa004067132a";

                managementGroupsClient.ManagementGroupSubscriptions.Create(groupId, subscriptionId, cacheControl: "no-cache");
            }
        }

        [Fact]
        public void DeleteGroupSubscription()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.NoContent });

                var groupId = "TestGroup1Child1Child1";
                var subscriptionId = "394ae65d-9e71-4462-930f-3332dedf845c";

                managementGroupsClient.ManagementGroupSubscriptions.Create(groupId, subscriptionId, cacheControl: "no-cache");
                managementGroupsClient.ManagementGroupSubscriptions.Delete(groupId, subscriptionId, cacheControl: "no-cache");
            }
        }

        [Fact]
        public void DeleteGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupName = "TestGroup2";

                var response =
                    managementGroupsClient.CheckNameAvailability(new CheckNameAvailabilityRequest(groupName, Type.HyphenMinusprovidersHyphenMinusMicrosoftFullStopManagementHyphenMinusmanagementGroups));

                Assert.True(response.NameAvailable);
            }
        }

        [Fact]
        public void CheckNameAvailibilityFalse()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupName = "TestGroup1";

                var response =
                    managementGroupsClient.CheckNameAvailability(new CheckNameAvailabilityRequest(groupName, Type.HyphenMinusprovidersHyphenMinusMicrosoftFullStopManagementHyphenMinusmanagementGroups));

                Assert.False(response.NameAvailable);
            }
        }

        [Fact]
        public void StartTenantBackfill()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var response =
                    managementGroupsClient.TenantBackfillStatus();

                Assert.Equal(Status.Completed, response.Status);
            }
        }
    }
}