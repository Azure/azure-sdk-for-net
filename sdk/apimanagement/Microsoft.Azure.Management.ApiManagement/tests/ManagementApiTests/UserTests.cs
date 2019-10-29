// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Net;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class UserTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list users
                var listUsersResponse = testBase.client.User.ListByService(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(listUsersResponse);
                Assert.Single(listUsersResponse);

                // create user
                string userId = TestUtilities.GenerateName("userId");

                try
                {
                    string userEmail = "contoso@microsoft.com";
                    string userFirstName = TestUtilities.GenerateName("userFirstName");
                    string userLastName = TestUtilities.GenerateName("userLastName");
                    string userPassword = TestUtilities.GenerateName("userPassword");
                    string userNote = TestUtilities.GenerateName("userNote");
                    string userSate = UserState.Active;

                    var userCreateParameters = new UserCreateParameters
                    {
                        Email = userEmail,
                        FirstName = userFirstName,
                        LastName = userLastName,
                        Password = userPassword,
                        Note = userNote,
                        State = userSate
                    };

                    var createUserResponse = testBase.client.User.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        userId,
                        userCreateParameters);

                    Assert.NotNull(createUserResponse);

                    // get the user to check it was added
                    var getUserResponse = await testBase.client.User.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        userId);

                    Assert.NotNull(getUserResponse);
                    Assert.NotNull(getUserResponse.Headers.ETag);
                    Assert.Equal(userId, getUserResponse.Body.Name);
                    Assert.Equal(userEmail, getUserResponse.Body.Email);
                    Assert.Equal(userFirstName, getUserResponse.Body.FirstName);
                    Assert.Equal(userLastName, getUserResponse.Body.LastName);
                    Assert.Equal(userNote, getUserResponse.Body.Note);
                    Assert.Equal(userSate, getUserResponse.Body.State);

                    // list users
                    listUsersResponse = testBase.client.User.ListByService(
                        testBase.rgName,
                        testBase.serviceName,
                        new Microsoft.Rest.Azure.OData.ODataQuery<UserContract> { Top = 1 });

                    Assert.NotNull(listUsersResponse);
                    Assert.NotNull(listUsersResponse.NextPageLink);
                    Assert.Single(listUsersResponse);

                    // generate SSO token URL
                    var genrateSsoResponse = testBase.client.User.GenerateSsoUrl(
                        testBase.rgName,
                        testBase.serviceName,
                        userId);

                    Assert.NotNull(genrateSsoResponse);
                    Assert.NotNull(genrateSsoResponse.Value);
                    Uri uri;
                    Assert.True(Uri.TryCreate(genrateSsoResponse.Value, UriKind.Absolute, out uri));

                    // generate token for user
                    var userTokenParameters = new UserTokenParameters(KeyType.Primary, DateTime.UtcNow.AddDays(10));
                    var generateTokenResponse = testBase.client.User.GetSharedAccessToken(
                        testBase.rgName,
                        testBase.serviceName,
                        userId,
                        userTokenParameters);

                    Assert.NotNull(generateTokenResponse);
                    Assert.NotNull(generateTokenResponse.Value);

                    // remove the user
                    testBase.client.User.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        userId,
                        getUserResponse.Headers.ETag,
                        deleteSubscriptions: true);

                    // get the deleted user to make sure it was deleted
                    try
                    {
                        testBase.client.User.Get(testBase.rgName, testBase.serviceName, userId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    testBase.client.User.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        userId,
                        "*",
                        deleteSubscriptions: true);
                }
            }
        }

        [Fact]
        public void UserIdentities()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // there should be 'Echo API' which is created by default for every new instance of API Management and
                // 'Starter' product

                var listUsersResponse = testBase.client.User.ListByService(
                     testBase.rgName,
                     testBase.serviceName,
                     new Microsoft.Rest.Azure.OData.ODataQuery<UserContract> { Filter = "firstName eq 'Administrator'" });

                Assert.NotNull(listUsersResponse);
                Assert.Single(listUsersResponse);

                var user = listUsersResponse.Single();

                // list user identities
                var listResponse = testBase.client.UserIdentities.List(
                    testBase.rgName,
                    testBase.serviceName,
                    user.Name);

                Assert.NotNull(listResponse);

                // there should be Azure identification
                Assert.Single(listResponse);
                Assert.Equal(user.Email, listResponse.Single().Id);
                Assert.Equal("Azure", listResponse.Single().Provider);
            }
        }

        [Fact]
        public void GroupsListAddRemove()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // create new group
                string gid = TestUtilities.GenerateName("groupId");

                try
                {
                    var createGroupParams = new GroupCreateParameters
                    {
                        DisplayName = TestUtilities.GenerateName("groupName"),
                        Type = GroupType.Custom,
                    };

                    testBase.client.Group.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        gid,
                        createGroupParams);

                    // get the group
                    var getGroupResponse = testBase.client.Group.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        gid);

                    // create new user and add it to the group
                    string userId = TestUtilities.GenerateName("userId");
                    try
                    {
                        var creteUserParameters = new UserCreateParameters
                        {
                            FirstName = TestUtilities.GenerateName("Ivan"),
                            LastName = TestUtilities.GenerateName("Ivanov"),
                            Email = TestUtilities.GenerateName("ivan.ivanov") + "@contoso.com",
                            Password = TestUtilities.GenerateName("pwd"),
                            State = UserState.Active,
                            Note = TestUtilities.GenerateName("note")
                        };

                        testBase.client.User.CreateOrUpdate(
                            testBase.rgName,
                            testBase.serviceName,
                            userId,
                            creteUserParameters);

                        // list user groups
                        var listUserGroupsResponse = testBase.client.UserGroup.List(
                            testBase.rgName,
                            testBase.serviceName,
                            userId,
                            null);

                        Assert.NotNull(listUserGroupsResponse);

                        // there should be 'Developers' group by default
                        Assert.Single(listUserGroupsResponse);
                        var group = listUserGroupsResponse.First();

                        // add the user to the group
                        var addResponse = testBase.client.GroupUser.Create(
                            testBase.rgName,
                            testBase.serviceName,
                            gid,
                            userId);

                        Assert.NotNull(addResponse);

                        // list user groups
                        listUserGroupsResponse = testBase.client.UserGroup.List(
                            testBase.rgName,
                            testBase.serviceName,
                            userId,
                            null);

                        Assert.NotNull(listUserGroupsResponse);
                        // there should be two groups now
                        Assert.Equal(2, listUserGroupsResponse.Count());

                        var userGroup = listUserGroupsResponse.Single(g => g.Name == group.Name);
                        Assert.Equal(group.Id, userGroup.Id);
                        Assert.Equal(group.Name, userGroup.Name);
                        Assert.Equal(group.Description, userGroup.Description);
                        Assert.Equal(group.ExternalId, userGroup.ExternalId);
                        Assert.Equal(group.GroupContractType, userGroup.GroupContractType);

                        // remove the user from the group
                        testBase.client.GroupUser.Delete(
                            testBase.rgName,
                            testBase.serviceName,
                            gid,
                            userId);

                        // list to make sure it was removed
                        listUserGroupsResponse = testBase.client.UserGroup.List(
                            testBase.rgName,
                            testBase.serviceName,
                            userId,
                            null);

                        Assert.NotNull(listUserGroupsResponse);

                        // there should be default 'Developers' group
                        Assert.Single(listUserGroupsResponse);
                        Assert.Equal("developers", listUserGroupsResponse.Single().Name);
                    }
                    finally
                    {
                        // delete the user
                        testBase.client.User.Delete(testBase.rgName, testBase.serviceName, userId, "*", true);
                    }
                }
                finally
                {
                    testBase.client.Group.Delete(testBase.rgName, testBase.serviceName, gid, "*");
                }
            }
        }

        [Fact]
        public void SubscriptionsList()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                var usersResponse = testBase.client.User.ListByService(testBase.rgName, testBase.serviceName, null);
                var user = usersResponse.First();

                // list subscriptions of a user: there should be two by default
                var listResponse = testBase.client.UserSubscription.List(
                    testBase.rgName,
                    testBase.serviceName,
                    user.Name,
                    null);

                Assert.NotNull(listResponse);
                Assert.True(listResponse.Count() >= 2);
                Assert.Null(listResponse.NextPageLink);

                // list paged
                listResponse = testBase.client.UserSubscription.List(
                    testBase.rgName,
                    testBase.serviceName,
                    user.Name,
                    new Microsoft.Rest.Azure.OData.ODataQuery<SubscriptionContract> { Top = 1 });

                Assert.NotNull(listResponse);
                Assert.Single(listResponse);
                Assert.NotNull(listResponse.NextPageLink);

                // list next page
                listResponse = testBase.client.UserSubscription.ListNext(listResponse.NextPageLink);

                Assert.NotNull(listResponse);
                Assert.Single(listResponse);
                Assert.Null(listResponse.NextPageLink);
            }
        }
    }
}
