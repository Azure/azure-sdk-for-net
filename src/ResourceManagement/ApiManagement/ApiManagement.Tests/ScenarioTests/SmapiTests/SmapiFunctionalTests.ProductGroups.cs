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
        public void ProductGroupsListAddRemove()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ProductGroupsListAddRemove");

            try
            {
                // there should be 'Administrators', 'Developers' and 'Guests' groups which is created by default for every new instance of API Management and
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

                // list product groups: there sould be all three
                var listGroupsResponse = ApiManagementClient.ProductGroups.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    null);

                Assert.NotNull(listGroupsResponse);
                Assert.NotNull(listGroupsResponse.Result);
                Assert.Equal(3, listGroupsResponse.Result.TotalCount);
                Assert.Equal(3, listGroupsResponse.Result.Values.Count);

                // get group
                var getResponse = ApiManagementClient.Groups.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    listGroupsResponse.Result.Values.Single(g => g.Name.Equals("Guests")).Id);

                Assert.NotNull(getResponse);

                // remove group from product
                var removeResponse = ApiManagementClient.ProductGroups.Remove(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    getResponse.Value.Id);

                Assert.NotNull(removeResponse);

                // list to check it was removed
                listGroupsResponse = ApiManagementClient.ProductGroups.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    null);

                Assert.NotNull(listGroupsResponse);
                Assert.NotNull(listGroupsResponse.Result);
                Assert.Equal(2, listGroupsResponse.Result.TotalCount);
                Assert.Equal(2, listGroupsResponse.Result.Values.Count);

                // assign the group to the product

                var addResponse = ApiManagementClient.ProductGroups.Add(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    getResponse.Value.Id);

                Assert.NotNull(addResponse);

                // list to check it was added
                listGroupsResponse = ApiManagementClient.ProductGroups.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    null);

                Assert.NotNull(listGroupsResponse);
                Assert.NotNull(listGroupsResponse.Result);
                Assert.Equal(3, listGroupsResponse.Result.TotalCount);
                Assert.Equal(3, listGroupsResponse.Result.Values.Count);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}