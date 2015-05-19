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
        public void ProductApisListAddRemove()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ProductApisListAddRemove");

            try
            {
                // there should be 'Echo API' which is created by default for every new instance of API Management and
                // 'Starter' product

                var getProductsResponse = ApiManagementClient.Products.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new QueryParameters
                    {
                        Filter = "name eq 'Starter'"
                    });

                Assert.NotNull(getProductsResponse);
                Assert.NotNull(getProductsResponse.Result);
                Assert.Equal(1, getProductsResponse.Result.Values.Count);

                var product = getProductsResponse.Result.Values.Single();

                // list product apis: there sould be 1
                var listApisResponse = ApiManagementClient.ProductApis.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    null);

                Assert.NotNull(listApisResponse);
                Assert.NotNull(listApisResponse.Result);
                Assert.Equal(1, listApisResponse.Result.TotalCount);
                Assert.Equal(1, listApisResponse.Result.Values.Count);

                // get api
                var getResponse = ApiManagementClient.Apis.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    listApisResponse.Result.Values.Single().Id);

                Assert.NotNull(getResponse);

                // remove api from product
                var removeResponse = ApiManagementClient.ProductApis.Remove(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    listApisResponse.Result.Values.Single().Id);

                Assert.NotNull(removeResponse);

                // list to check it was removed
                listApisResponse = ApiManagementClient.ProductApis.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    null);

                Assert.NotNull(listApisResponse);
                Assert.NotNull(listApisResponse.Result);
                Assert.Equal(0, listApisResponse.Result.TotalCount);
                Assert.Equal(0, listApisResponse.Result.Values.Count);

                // add the api to product

                var addResponse = ApiManagementClient.ProductApis.Add(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    getResponse.Value.Id);

                Assert.NotNull(addResponse);

                // list to check it was added
                listApisResponse = ApiManagementClient.ProductApis.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    null);

                Assert.NotNull(listApisResponse);
                Assert.NotNull(listApisResponse.Result);
                Assert.Equal(1, listApisResponse.Result.TotalCount);
                Assert.Equal(1, listApisResponse.Result.Values.Count);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}