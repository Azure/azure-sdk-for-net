using System;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
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
                    new RecordedDelegatingHandler {StatusCodeToReturn = HttpStatusCode.OK});

                var managementGroups = managementGroupsClient.ManagementGroups.List();

                Assert.NotNull(managementGroups);
                Assert.NotEqual(0, managementGroups.Count());
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

                var groupId = "e16c61d4-c2c9-444d-9ee0-2f89561e6ef9";

                managementGroupsClient.GroupId = new Guid(groupId);

                var managementGroup = managementGroupsClient.ManagementGroups.Get();

                Assert.NotNull(managementGroup);
                Assert.NotNull(managementGroup.Id);
                Assert.NotNull(managementGroup.Name);
                Assert.NotNull(managementGroup.Type);
            }

        }

        [Fact]
        public void GetGroupExpand()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var managementGroupsClient = ManagementGroupsTestUtilities.GetManagementGroupsApiClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                var groupId = "e16c61d4-c2c9-444d-9ee0-2f89561e6ef9";

                managementGroupsClient.GroupId = new Guid(groupId);

                var managementGroup = managementGroupsClient.ManagementGroups.Get("children");

                Assert.NotNull(managementGroup);
                Assert.NotNull(managementGroup.Id);
                Assert.NotNull(managementGroup.Name);
                Assert.NotNull(managementGroup.Type);
                Assert.Equal(managementGroup.Details.ManagementGroupType, "Enrollment");

                Assert.NotNull(managementGroup.Children);
                Assert.Equal("Department", managementGroup.Children.First().ChildType);
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

                var groupId = "e16c61d4-c2c9-444d-9ee0-2f89561e6ef9";

                managementGroupsClient.GroupId = new Guid(groupId);

                var managementGroup = managementGroupsClient.ManagementGroups.Get("children", true);

                Assert.NotNull(managementGroup);
                Assert.NotNull(managementGroup.Id);
                Assert.NotNull(managementGroup.Name);
                Assert.NotNull(managementGroup.Type);
                Assert.Equal(managementGroup.Details.ManagementGroupType, "Enrollment");

                Assert.NotNull(managementGroup.Children);
                Assert.Equal("Department", managementGroup.Children.First().ChildType);

                Assert.NotNull(managementGroup.Children.First().Children);
                Assert.Equal("Account", managementGroup.Children.First().Children.First().ChildType);

                Assert.NotNull(managementGroup.Children.First().Children.First().Children);
                Assert.Equal("Subscription", managementGroup.Children.First().Children.First().Children.First().ChildType);

            }

        }

    }
}
