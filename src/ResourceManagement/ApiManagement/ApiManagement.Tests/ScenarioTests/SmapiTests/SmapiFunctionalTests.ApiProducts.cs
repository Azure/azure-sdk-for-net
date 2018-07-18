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
        public void ApiProductsCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ApiProductsCreateListUpdateDelete");

            try
            {
                // there should be 'Echo API' which is created by default for every new instance of API Management

                var apis = ApiManagementClient.Apis.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    null);

                var api = apis.Result.Values.Single();

                // list products

                var listResponse = ApiManagementClient.ApiProducts.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.Equal(2, listResponse.Result.TotalCount);
                Assert.Equal(2, listResponse.Result.Values.Count);
                Assert.Null(listResponse.Result.NextLink);

                // list paged 
                listResponse = ApiManagementClient.ApiProducts.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    new QueryParameters {Top = 1});

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.Equal(2, listResponse.Result.TotalCount);
                Assert.Equal(1, listResponse.Result.Values.Count);
                Assert.NotNull(listResponse.Result.NextLink);

                listResponse = ApiManagementClient.ApiProducts.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    api.Id,
                    new QueryParameters {Skip = 1});

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.Equal(2, listResponse.Result.TotalCount);
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