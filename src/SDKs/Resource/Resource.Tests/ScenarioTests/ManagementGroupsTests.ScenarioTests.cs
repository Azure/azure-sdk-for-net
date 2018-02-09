using System;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Resource.Tests.Helpers;
using Xunit;
using Microsoft.Azure.Management.ResourceManager.Models;

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
                    new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                var managementGroups = managementGroupsClient.ManagementGroups.List();

                Assert.NotNull(managementGroups);
                Assert.NotEmpty(managementGroups);
                Assert.NotNull(managementGroups.First().Id);
                Assert.NotNull(managementGroups.First().Type);
                Assert.NotNull(managementGroups.First().Name);
                
            }

        }

        [Fact]
        public void GetGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "testGroup123";

                var managementGroup = managementGroupsClient.ManagementGroups.Get(groupId, cacheControl: "no-cache");

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/testGroup123", managementGroup.Id);
                Assert.Equal("testGroup123", managementGroup.Name);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Type);

            }

        }

        [Fact]
        public void GetGroupExpand()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "testGroup123";

                var managementGroup = managementGroupsClient.ManagementGroups.Get(groupId, "children", cacheControl: "no-cache");

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/testGroup123", managementGroup.Id);
                Assert.Equal("testGroup123", managementGroup.Name);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Type);

                Assert.NotNull(managementGroup.Children);
                Assert.Null(managementGroup.Children.First().Children);
                
            }

        }

        [Fact]
        public void GetGroupExpandRecurse()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "testGroup123";

                var managementGroup = managementGroupsClient.ManagementGroups.Get(groupId, "children", true, cacheControl: "no-cache");

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/testGroup123", managementGroup.Id);
                Assert.Equal("testGroup123", managementGroup.Name);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Type);

                Assert.NotNull(managementGroup.Children);
                Assert.NotNull(managementGroup.Children.First().Children);
            }
        }

        [Fact]
        public void CreateGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "testGroup123Child2";

                var managementGroup = managementGroupsClient.ManagementGroups.CreateOrUpdate(groupId, new CreateGroupRequest("TestGroup123->Child2", "/providers/Microsoft.Management/managementGroups/testGroup123"), cacheControl: "no-cache");

                Assert.NotNull(managementGroup);
                Assert.Equal("/providers/Microsoft.Management/managementGroups/testGroup123Child2", managementGroup.Id);
                Assert.Equal("testGroup123Child2", managementGroup.Name);
                Assert.Equal("/providers/Microsoft.Management/managementGroups", managementGroup.Type);
            }
        }

        [Fact]
        public void CreateGroupSubscription()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.NoContent });

                var groupId = "testGroup123Child2";
                var subscriptionId = "2a418b54-7643-4d8f-982c-d0802205d12c";

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

                var groupId = "testGroup123Child2";
                var subscriptionId = "2a418b54-7643-4d8f-982c-d0802205d12c";

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

                var groupId = "testGroup123Child2";

                managementGroupsClient.ManagementGroups.Delete(groupId, cacheControl: "no-cache");
            }
        }

    }
}
