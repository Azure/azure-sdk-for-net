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
    using System.Net;
    using Microsoft.Azure.Test;
    using SmapiModels;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void TenantAccessGitInformationGetUpdate()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "TenantAccessGitInformationGetUpdate");

            try
            {
                // get settings
                var getResponse = ApiManagementClient.TenantAccessGit.Get(ResourceGroupName, ApiManagementServiceName);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.False(getResponse.Value.Enabled);

                // add more settings
                var parameters = new AccessInformationUpdateParameters
                {
                    Enabled = true
                };
                var response = ApiManagementClient.TenantAccessGit.Update(ResourceGroupName, ApiManagementServiceName, parameters, getResponse.ETag);

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);

                getResponse = ApiManagementClient.TenantAccessGit.Get(ResourceGroupName, ApiManagementServiceName);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.True(getResponse.Value.Enabled);

                ApiManagementClient.TenantAccessGit.RegeneratePrimaryKey(ResourceGroupName, ApiManagementServiceName);
                
                var getResponse2 = ApiManagementClient.TenantAccessGit.Get(ResourceGroupName, ApiManagementServiceName);

                Assert.NotNull(getResponse2);
                Assert.NotNull(getResponse2.Value);
                Assert.Equal(getResponse.Value.SecondaryKey, getResponse2.Value.SecondaryKey);
                Assert.NotEqual(getResponse.Value.PrimaryKey, getResponse2.Value.PrimaryKey);

                ApiManagementClient.TenantAccessGit.RegenerateSecondaryKey(ResourceGroupName, ApiManagementServiceName);

                getResponse2 = ApiManagementClient.TenantAccessGit.Get(ResourceGroupName, ApiManagementServiceName);

                Assert.NotNull(getResponse2);
                Assert.NotNull(getResponse2.Value);
                Assert.NotEqual(getResponse.Value.SecondaryKey, getResponse2.Value.SecondaryKey);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}