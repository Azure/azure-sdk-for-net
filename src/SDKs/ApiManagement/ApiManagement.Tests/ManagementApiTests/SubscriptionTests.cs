﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// using ApiManagement.Management.Tests;

using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Xunit;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Net;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class SubscriptionTests : TestBase
    {
        [Fact]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list subscriptions: there should be two by default
                var listResponse = testBase.client.Subscription.List(
                testBase.rgName,
                testBase.serviceName,
                null);

                Assert.NotNull(listResponse);
                Assert.True(listResponse.Count() >= 2);
                Assert.Null(listResponse.NextPageLink);

                // list paged
                listResponse = testBase.client.Subscription.List(
                    testBase.rgName,
                    testBase.serviceName,
                    new Microsoft.Rest.Azure.OData.ODataQuery<SubscriptionContract> { Top = 1 });

                Assert.NotNull(listResponse);
                Assert.Single(listResponse);
                Assert.NotNull(listResponse.NextPageLink);

                // get first subscription
                var firstSubscription = listResponse.First();

                var getResponse = testBase.client.Subscription.Get(
                    testBase.rgName,
                    testBase.serviceName,
                    firstSubscription.Name);

                Assert.NotNull(getResponse);
                Assert.Equal(firstSubscription.Name, getResponse.Name);
                Assert.Equal(firstSubscription.NotificationDate, getResponse.NotificationDate);
                Assert.Equal(firstSubscription.PrimaryKey, getResponse.PrimaryKey);
                Assert.Equal(firstSubscription.ProductId, getResponse.ProductId);
                Assert.Equal(firstSubscription.SecondaryKey, getResponse.SecondaryKey);
                Assert.Equal(firstSubscription.StartDate, getResponse.StartDate);
                Assert.Equal(firstSubscription.State, getResponse.State);
                Assert.Equal(firstSubscription.StateComment, getResponse.StateComment);
                Assert.Equal(firstSubscription.UserId, getResponse.UserId);
                Assert.Equal(firstSubscription.CreatedDate, getResponse.CreatedDate);
                Assert.Equal(firstSubscription.EndDate, getResponse.EndDate);
                Assert.Equal(firstSubscription.ExpirationDate, getResponse.ExpirationDate);

                // update product to accept unlimited number or subscriptions
                testBase.client.Product.Update(
                    testBase.rgName,
                    testBase.serviceName,
                    firstSubscription.ProductIdentifier,
                    new ProductUpdateParameters
                    {
                        SubscriptionsLimit = int.MaxValue
                    },
                    "*");

                // add new subscription
                string newSubscriptionId = TestUtilities.GenerateName("newSubscriptionId");

                try
                {
                    string newSubscriptionName = TestUtilities.GenerateName("newSubscriptionName");
                    string newSubscriptionPk = TestUtilities.GenerateName("newSubscriptionPK");
                    string newSubscriptionSk = TestUtilities.GenerateName("newSubscriptionSK");
                    var newSubscriptionState = SubscriptionState.Active;

                    var newSubscriptionCreate = new SubscriptionCreateParameters(
                        firstSubscription.UserId,
                        firstSubscription.ProductId,
                        newSubscriptionName)
                    {
                        PrimaryKey = newSubscriptionPk,
                        SecondaryKey = newSubscriptionSk,
                        State = newSubscriptionState,
                    };

                    var subscriptionContract = testBase.client.Subscription.CreateOrUpdate(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId,
                        newSubscriptionCreate);

                    Assert.NotNull(subscriptionContract);
                    Assert.Equal(firstSubscription.ProductId, subscriptionContract.ProductId);
                    Assert.Equal(firstSubscription.UserId, subscriptionContract.UserId);
                    Assert.Equal(newSubscriptionState, subscriptionContract.State);
                    Assert.Equal(newSubscriptionSk, subscriptionContract.SecondaryKey);
                    Assert.Equal(newSubscriptionPk, subscriptionContract.PrimaryKey);
                    Assert.Equal(newSubscriptionName, subscriptionContract.DisplayName);

                    var subscriptionResponse = await testBase.client.Subscription.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    Assert.NotNull(subscriptionResponse);
                    Assert.NotNull(subscriptionResponse.Headers.ETag);

                    // patch the subscription
                    string patchedName = TestUtilities.GenerateName("patchedName");
                    string patchedPk = TestUtilities.GenerateName("patchedPk");
                    string patchedSk = TestUtilities.GenerateName("patchedSk");
                    var patchedExpirationDate = new DateTime(2025, 5 + 2, 20);

                    testBase.client.Subscription.Update(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId,
                        new SubscriptionUpdateParameters
                        {
                            DisplayName = patchedName,
                            PrimaryKey = patchedPk,
                            SecondaryKey = patchedSk,
                            ExpirationDate = patchedExpirationDate
                        },
                        subscriptionResponse.Headers.ETag);

                    // get patched subscription to check it was actually patched
                    getResponse = testBase.client.Subscription.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    Assert.NotNull(getResponse);
                    Assert.Equal(newSubscriptionId, getResponse.Name);
                    Assert.Equal(patchedName, getResponse.DisplayName);
                    Assert.Equal(patchedPk, getResponse.PrimaryKey);
                    Assert.Equal(patchedSk, getResponse.SecondaryKey);
                    Assert.Equal(newSubscriptionState, getResponse.State);
                    Assert.Equal(patchedExpirationDate, getResponse.ExpirationDate);

                    // regenerate primary key
                    testBase.client.Subscription.RegeneratePrimaryKey(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    // get the subscription to check the key
                    getResponse = testBase.client.Subscription.Get(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    Assert.NotNull(getResponse);
                    Assert.NotEqual(patchedPk, getResponse.PrimaryKey);
                    Assert.Equal(patchedSk, getResponse.SecondaryKey);

                    // regenerate secondary key
                    testBase.client.Subscription.RegenerateSecondaryKey(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    // get the subscription to check the key
                    subscriptionResponse = await testBase.client.Subscription.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    Assert.NotNull(subscriptionResponse);
                    Assert.NotNull(subscriptionResponse.Headers.ETag);
                    Assert.NotEqual(patchedPk, subscriptionResponse.Body.PrimaryKey);
                    Assert.NotEqual(patchedSk, subscriptionResponse.Body.SecondaryKey);
                    
                    // delete the subscription
                    testBase.client.Subscription.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId,
                        subscriptionResponse.Headers.ETag);

                    // get the deleted subscription to make sure it was deleted
                    try
                    {
                        testBase.client.Subscription.Get(testBase.rgName, testBase.serviceName, newSubscriptionId);
                        throw new Exception("This code should not have been executed.");
                    }
                    catch (ErrorResponseException ex)
                    {
                        Assert.Equal((int)HttpStatusCode.NotFound, (int)ex.Response.StatusCode);
                    }
                }
                finally
                {
                    testBase.client.Subscription.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId,
                        "*");
                }
            }
        }
    }
}
