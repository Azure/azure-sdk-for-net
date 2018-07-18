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
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void PolicySnippetsList()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "PolicySnippetsList");

            try
            {
                var allListResponse = ApiManagementClient.PolicySnippents.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    PolicyScopeContract.All);

                Assert.NotNull(allListResponse);
                Assert.NotNull(allListResponse.Values);
                Assert.True(allListResponse.Values.Count > 0);

                foreach (var snippet in allListResponse.Values)
                {
                    Assert.NotNull(snippet.Content);
                    Assert.NotNull(snippet.Name);
                    Assert.NotNull(snippet.ToolTip);
                }

                var apiListResponse = ApiManagementClient.PolicySnippents.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    PolicyScopeContract.Api);

                Assert.NotNull(apiListResponse);
                Assert.True(apiListResponse.Values.Count > 0);

                foreach (var snippet in apiListResponse.Values)
                {
                    Assert.Equal(PolicyScopeContract.Api, PolicyScopeContract.Api & snippet.Scope);
                }
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}