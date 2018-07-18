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
        public void ProductSubscriptionsList()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ProductSubscriptionsList");

            try
            {
                // get product
                var listProductsResponse = ApiManagementClient.Products.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new QueryParameters
                    {
                        Filter = "name eq 'Starter'"
                    });

                var product = listProductsResponse.Result.Values.Single();

                // list product's subscriptions
                var listSubscriptionsResponse = ApiManagementClient.ProductSubscriptions.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    product.Id,
                    null);

                Assert.NotNull(listSubscriptionsResponse);
                Assert.NotNull(listSubscriptionsResponse.Result);
                Assert.NotNull(listSubscriptionsResponse.Result.Values);
                Assert.Equal(1, listSubscriptionsResponse.Result.TotalCount);
                Assert.Equal(1, listSubscriptionsResponse.Result.Values.Count);
            }
            finally
            {
                TestUtilities.EndTest();
            }
        }
    }
}
