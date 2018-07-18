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
        public void UserIdentitiesList()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "UserIdentitiesList");

            try
            {
                var listUsersResponse = ApiManagementClient.Users.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new QueryParameters {Filter = "firstName eq 'Administrator'"});

                Assert.NotNull(listUsersResponse);
                Assert.NotNull(listUsersResponse.Result);
                Assert.NotNull(listUsersResponse.Result.Values);

                var user = listUsersResponse.Result.Values.Single();

                // list user identities
                var listResponse = ApiManagementClient.UserIdentities.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    user.Id);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Values);

                // there should be Azure identification
                Assert.Equal(1, listResponse.Values.Count);
                Assert.Equal(user.Email, listResponse.Values.Single().Id);
                Assert.Equal("Azure", listResponse.Values.Single().Provider);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}