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
    using System.Linq;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void UserSubscriptionsList()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "UserSubscriptionsList");

            try
            {
                var usersResponse = ApiManagementClient.Users.List(ResourceGroupName, ApiManagementServiceName, null);
                var user = usersResponse.Result.Values.First();

                // list subscriptions of a user: there should be two by default
                var listResponse = ApiManagementClient.UserSubscriptions.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    user.Id,
                    null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.True(listResponse.Result.TotalCount >= 2);
                Assert.True(listResponse.Result.Values.Count >= 2);
                Assert.Null(listResponse.Result.NextLink);

                // list paged
                listResponse = ApiManagementClient.UserSubscriptions.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    user.Id,
                    new QueryParameters {Top = 1});

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.True(listResponse.Result.TotalCount >= 2);
                Assert.Equal(1, listResponse.Result.Values.Count);
                Assert.NotNull(listResponse.Result.NextLink);

                // list next page
                listResponse = ApiManagementClient.UserSubscriptions.ListNext(listResponse.Result.NextLink);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.True(listResponse.Result.TotalCount >= 2);
                Assert.Equal(1, listResponse.Result.Values.Count);
                Assert.Null(listResponse.Result.NextLink);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}