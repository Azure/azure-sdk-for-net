//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.SmapiTests
{
    using System;
    using System.Net;
    using Hyak.Common;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void UsersCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "UsersCreateListUpdateDelete");

            try
            {
                // list users
                var listUsersResponse = ApiManagementClient.Users.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    null);

                Assert.NotNull(listUsersResponse);
                Assert.NotNull(listUsersResponse.Result);
                Assert.Equal(1, listUsersResponse.Result.TotalCount);
                Assert.Equal(1, listUsersResponse.Result.Values.Count);

                // create user
                string userId = TestUtilities.GenerateName("userId");
                string userEmail = "contoso@microsoft.com";
                string userFirstName = TestUtilities.GenerateName("userFirstName");
                string userLastName = TestUtilities.GenerateName("userLastName");
                string userPassword = TestUtilities.GenerateName("userPassword");
                string userNote = TestUtilities.GenerateName("userNote");
                UserStateContract? userSate = UserStateContract.Active;

                var userCreateParameters = new UserCreateParameters
                {
                    Email = userEmail,
                    FirstName = userFirstName,
                    LastName = userLastName,
                    Password = userPassword,
                    Note = userNote,
                    State = userSate
                };

                var createUserResponse = ApiManagementClient.Users.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    userId,
                    userCreateParameters);

                Assert.NotNull(createUserResponse);
                Assert.Equal(HttpStatusCode.Created, createUserResponse.StatusCode);

                // get the user to check it was added
                var getUserResponse = ApiManagementClient.Users.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    userId);

                Assert.NotNull(getUserResponse);

                Assert.Equal(userId, getUserResponse.Value.Id);
                Assert.Equal(userEmail, getUserResponse.Value.Email);
                Assert.Equal(userFirstName, getUserResponse.Value.FirstName);
                Assert.Equal(userLastName, getUserResponse.Value.LastName);
                Assert.Equal(userNote, getUserResponse.Value.Note);
                Assert.Equal(userSate, getUserResponse.Value.State);

                // list users
                listUsersResponse = ApiManagementClient.Users.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new QueryParameters {Top = 1});

                Assert.NotNull(listUsersResponse);
                Assert.NotNull(listUsersResponse.Result);
                Assert.NotNull(listUsersResponse.Result.NextLink);
                Assert.Equal(2, listUsersResponse.Result.TotalCount);
                Assert.Equal(1, listUsersResponse.Result.Values.Count);

                // generate SSO token URL

                var genrateSsoResponse = ApiManagementClient.Users.GenerateSsoUrl(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    userId);

                Assert.NotNull(genrateSsoResponse);
                Assert.NotNull(genrateSsoResponse.Value);
                Uri uri;
                Assert.True(Uri.TryCreate(genrateSsoResponse.Value, UriKind.Absolute, out uri));

                // remove the user
                var deleteUserResponse = ApiManagementClient.Users.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    userId,
                    getUserResponse.ETag,
                    deleteSubscriptions: true);

                Assert.NotNull(deleteUserResponse);

                // get the deleted user to make sure it was deleted
                try
                {
                    ApiManagementClient.Users.Get(ResourceGroupName, ApiManagementServiceName, userId);
                    throw new Exception("This code should not have been executed.");
                }
                catch (CloudException ex)
                {
                    Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}