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
    using System.Linq;
    using System.Net;
    using Hyak.Common;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class SmapiFunctionalTests
    {
        [Fact]
        public void SubscriptionsCreateListUpdateDelete()
        {
            TestUtilities.StartTest("SmapiFunctionalTests", "SubscriptionsCreateListUpdateDelete");

            try
            {
                // list subscriptions: there should be two by default
                var listResponse = ApiManagementClient.Subscriptions.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.True(listResponse.Result.TotalCount >= 2);
                Assert.True(listResponse.Result.Values.Count >= 2);
                Assert.Null(listResponse.Result.NextLink);

                // list paged
                listResponse = ApiManagementClient.Subscriptions.List(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new QueryParameters {Top = 1});

                Assert.NotNull(listResponse);
                Assert.NotNull(listResponse.Result.Values);
                Assert.True(listResponse.Result.TotalCount >= 2);
                Assert.Equal(1, listResponse.Result.Values.Count);
                Assert.NotNull(listResponse.Result.NextLink);

                // get first subscription
                var firstSubscription = listResponse.Result.Values.First();

                var getResponse = ApiManagementClient.Subscriptions.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    firstSubscription.Id);

                Assert.NotNull(getResponse);
                Assert.Equal(firstSubscription.Id, getResponse.Value.Id);
                Assert.Equal(firstSubscription.Name, getResponse.Value.Name);
                Assert.Equal(firstSubscription.NotificationDate, getResponse.Value.NotificationDate);
                Assert.Equal(firstSubscription.PrimaryKey, getResponse.Value.PrimaryKey);
                Assert.Equal(firstSubscription.ProductId, getResponse.Value.ProductId);
                Assert.Equal(firstSubscription.SecondaryKey, getResponse.Value.SecondaryKey);
                Assert.Equal(firstSubscription.StartDate, getResponse.Value.StartDate);
                Assert.Equal(firstSubscription.State, getResponse.Value.State);
                Assert.Equal(firstSubscription.StateComment, getResponse.Value.StateComment);
                Assert.Equal(firstSubscription.UserId, getResponse.Value.UserId);
                Assert.Equal(firstSubscription.CreatedDate, getResponse.Value.CreatedDate);
                Assert.Equal(firstSubscription.EndDate, getResponse.Value.EndDate);
                Assert.Equal(firstSubscription.ExpirationDate, getResponse.Value.ExpirationDate);

                // update product to accept unlimited number or subscriptions
                ApiManagementClient.Products.Update(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    firstSubscription.ProductId,
                    new ProductUpdateParameters
                    {
                        SubscriptionsLimit = int.MaxValue
                    },
                    "*");

                // add new subscription
                string newSubscriptionId = TestUtilities.GenerateName("newSubscriptionId");
                string newSubscriptionName = TestUtilities.GenerateName("newSubscriptionName");
                string newSubscriptionPk = TestUtilities.GenerateName("newSubscriptionPK");
                string newSubscriptionSk = TestUtilities.GenerateName("newSubscriptionSK");
                var newSubscriptionState = SubscriptionStateContract.Active;

                var newSubscriptionCreate = new SubscriptionCreateParameters(
                    firstSubscription.UserIdPath,
                    firstSubscription.ProductIdPath,
                    newSubscriptionName)
                {
                    PrimaryKey = newSubscriptionPk,
                    SecondaryKey = newSubscriptionSk,
                    State = newSubscriptionState,
                };

                var createResponse = ApiManagementClient.Subscriptions.Create(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newSubscriptionId,
                    newSubscriptionCreate);

                Assert.NotNull(createResponse);
                Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

                // get created subscription to check it was actually created
                getResponse = ApiManagementClient.Subscriptions.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newSubscriptionId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.Equal(newSubscriptionId, getResponse.Value.Id);
                Assert.Equal(newSubscriptionName, getResponse.Value.Name);
                Assert.Equal(newSubscriptionPk, getResponse.Value.PrimaryKey);
                Assert.Equal(newSubscriptionSk, getResponse.Value.SecondaryKey);
                Assert.Equal(newSubscriptionState, getResponse.Value.State);

                // patch the subscription
                string patchedName = TestUtilities.GenerateName("patchedName");
                string patchedPk = TestUtilities.GenerateName("patchedPk");
                string patchedSk = TestUtilities.GenerateName("patchedSk");
                var patchedExpirationDate = new DateTime(2025, 5 + 2, 20);

                var patchResponse = ApiManagementClient.Subscriptions.Update(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newSubscriptionId,
                    new SubscriptionUpdateParameters
                    {
                        Name = patchedName,
                        PrimaryKey = patchedPk,
                        SecondaryKey = patchedSk,
                        ExpiresOn = patchedExpirationDate
                    },
                    getResponse.ETag);

                Assert.NotNull(patchResponse);
                Assert.Equal(HttpStatusCode.NoContent, patchResponse.StatusCode);

                // get patched subscription to check it was actually patched
                getResponse = ApiManagementClient.Subscriptions.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newSubscriptionId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.Equal(newSubscriptionId, getResponse.Value.Id);
                Assert.Equal(patchedName, getResponse.Value.Name);
                Assert.Equal(patchedPk, getResponse.Value.PrimaryKey);
                Assert.Equal(patchedSk, getResponse.Value.SecondaryKey);
                Assert.Equal(newSubscriptionState, getResponse.Value.State);
                Assert.Equal(patchedExpirationDate, getResponse.Value.ExpirationDate);

                // regenerate primary key
                var regenerateResponse = ApiManagementClient.Subscriptions.RegeneratePrimaryKey(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newSubscriptionId);

                Assert.NotNull(regenerateResponse);
                Assert.Equal(HttpStatusCode.NoContent, regenerateResponse.StatusCode);

                // get the subscription to check the key
                getResponse = ApiManagementClient.Subscriptions.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newSubscriptionId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.NotEqual(patchedPk, getResponse.Value.PrimaryKey);
                Assert.Equal(patchedSk, getResponse.Value.SecondaryKey);

                // regenerate secondary key
                regenerateResponse = ApiManagementClient.Subscriptions.RegenerateSecondaryKey(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newSubscriptionId);

                Assert.NotNull(regenerateResponse);
                Assert.Equal(HttpStatusCode.NoContent, regenerateResponse.StatusCode);

                // get the subscription to check the key
                getResponse = ApiManagementClient.Subscriptions.Get(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newSubscriptionId);

                Assert.NotNull(getResponse);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.NotEqual(patchedPk, getResponse.Value.PrimaryKey);
                Assert.NotEqual(patchedSk, getResponse.Value.SecondaryKey);

                // delete the subscription
                var deleteResponse = ApiManagementClient.Subscriptions.Delete(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    newSubscriptionId,
                    getResponse.ETag);

                Assert.NotNull(deleteResponse);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

                // get the deleted subscription to make sure it was deleted
                try
                {
                    ApiManagementClient.Subscriptions.Get(ResourceGroupName, ApiManagementServiceName, newSubscriptionId);
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