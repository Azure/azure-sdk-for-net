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
        public void ProductsCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "ProductsCreateListUpdateDelete");

            try
            {
                // list all products: there should be two products: Starter and Unlimited
                var listResponse = ApiManagementClient.Products.List(ResourceGroupName, ApiManagementServiceName, null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);
                Assert.Equal(2, listResponse.Result.TotalCount);
                Assert.Equal(2, listResponse.Result.Values.Count);

                // list paged
                listResponse = ApiManagementClient.Products.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new QueryParameters {Top = 1});

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result);
                Assert.Equal(2, listResponse.Result.TotalCount);
                Assert.Equal(1, listResponse.Result.Values.Count);

                // create new product
                string productId = TestUtilities.GenerateName("productId");
                string productName = TestUtilities.GenerateName("productName");
                bool? productApprovalRequired = true;
                string productDescription = TestUtilities.GenerateName("productDescription");
                PeriodContract productNotificationPeriod = new PeriodContract
                {
                    Interval = PeriodIntervalContract.Month,
                    Value = 2
                };
                ProductStateContract productState = ProductStateContract.NotPublished;
                PeriodContract productSubscriptionPeriod = new PeriodContract
                {
                    Interval = PeriodIntervalContract.Year,
                    Value = 1
                };
                bool? productSubscriptionRequired = true;
                int? productSubscriptionsLimit = 10;
                string productTerms = TestUtilities.GenerateName("productTerms");

                ProductContract productContract = new ProductContract(productName)
                {
                    ApprovalRequired = productApprovalRequired,
                    Description = productDescription,
                    //Groups = 
                    NotificationPeriod = productNotificationPeriod,
                    State = productState,
                    SubscriptionPeriod = productSubscriptionPeriod,
                    SubscriptionRequired = productSubscriptionRequired,
                    SubscriptionsLimit = productSubscriptionsLimit,
                    Terms = productTerms
                };

                var createResponse = ApiManagementClient.Products.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    productId,
                    new ProductCreateParameters(productContract));

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get to check it was created
                var getResponse = ApiManagementClient.Products.Get(ResourceGroupName, ApiManagementServiceName, productId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);

                Assert.Equal(productId, getResponse.Value.Id);
                Assert.Equal(productName, getResponse.Value.Name);
                Assert.Equal(productApprovalRequired, getResponse.Value.ApprovalRequired);
                Assert.Equal(productDescription, getResponse.Value.Description);
                Assert.Equal(productNotificationPeriod.Interval, getResponse.Value.NotificationPeriod.Interval);
                Assert.Equal(productNotificationPeriod.Value, getResponse.Value.NotificationPeriod.Value);
                Assert.Equal(productState, getResponse.Value.State);
                Assert.Equal(productSubscriptionPeriod.Interval, getResponse.Value.SubscriptionPeriod.Interval);
                Assert.Equal(productSubscriptionPeriod.Value, getResponse.Value.SubscriptionPeriod.Value);
                Assert.Equal(productSubscriptionRequired, getResponse.Value.SubscriptionRequired);
                Assert.Equal(productSubscriptionsLimit, getResponse.Value.SubscriptionsLimit);
                Assert.Equal(productTerms, getResponse.Value.Terms);

                // update product
                string patchedName = TestUtilities.GenerateName("productName");
                string patchedDescription = TestUtilities.GenerateName("productDescription");
                string patchedTerms = TestUtilities.GenerateName("productTerms");
                var updateParameters = new ProductUpdateParameters
                {
                    Name = patchedName,
                    Description = patchedDescription,
                    Terms = patchedTerms
                };
                ApiManagementClient.Products.Update(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    productId,
                    updateParameters,
                    getResponse.ETag);

                // get to check it was updated
                getResponse = ApiManagementClient.Products.Get(ResourceGroupName, ApiManagementServiceName, productId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);

                Assert.Equal(productId, getResponse.Value.Id);
                Assert.Equal(patchedName, getResponse.Value.Name);
                Assert.Equal(productApprovalRequired, getResponse.Value.ApprovalRequired);
                Assert.Equal(patchedDescription, getResponse.Value.Description);
                Assert.Equal(productNotificationPeriod.Interval, getResponse.Value.NotificationPeriod.Interval);
                Assert.Equal(productNotificationPeriod.Value, getResponse.Value.NotificationPeriod.Value);
                Assert.Equal(productState, getResponse.Value.State);
                Assert.Equal(productSubscriptionPeriod.Interval, getResponse.Value.SubscriptionPeriod.Interval);
                Assert.Equal(productSubscriptionPeriod.Value, getResponse.Value.SubscriptionPeriod.Value);
                Assert.Equal(productSubscriptionRequired, getResponse.Value.SubscriptionRequired);
                Assert.Equal(productSubscriptionsLimit, getResponse.Value.SubscriptionsLimit);
                Assert.Equal(patchedTerms, getResponse.Value.Terms);

                // delete the product 
                var deleteResponse = ApiManagementClient.Products.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    productId,
                    getResponse.ETag,
                    true);

                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted api to make sure it was deleted
                try
                {
                    ApiManagementClient.Products.Get(ResourceGroupName, ApiManagementServiceName, productId);
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