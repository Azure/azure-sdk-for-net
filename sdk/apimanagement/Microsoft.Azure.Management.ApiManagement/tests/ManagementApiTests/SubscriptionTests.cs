// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Microsoft.Azure.Test.HttpRecorder;

namespace ApiManagement.Tests.ManagementApiTests
{
    public class SubscriptionTests : TestBase
    {
        [Fact]
        [Trait("owner", "jikang")]
        public async Task CreateListUpdateDelete()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);
                testBase.TryCreateApiManagementService();

                // list subscriptions: there should be two by default
                var listResponse = testBase.client.Subscription.List(
                    testBase.rgName,
                    testBase.serviceName,
                    null);

                Assert.NotNull(listResponse);
                Assert.True(listResponse.Count() >= 3);
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
                Assert.Equal(firstSubscription.Scope, getResponse.Scope);
                Assert.Equal(firstSubscription.SecondaryKey, getResponse.SecondaryKey);
                Assert.Equal(firstSubscription.StartDate, getResponse.StartDate);
                Assert.Equal(firstSubscription.State, getResponse.State);
                Assert.Equal(firstSubscription.StateComment, getResponse.StateComment);
                Assert.Equal(firstSubscription.OwnerId, getResponse.OwnerId);
                Assert.Equal(firstSubscription.CreatedDate, getResponse.CreatedDate);
                Assert.Equal(firstSubscription.EndDate, getResponse.EndDate);
                Assert.Equal(firstSubscription.ExpirationDate, getResponse.ExpirationDate);

                // update product to accept unlimited number or subscriptions
                testBase.client.Product.Update(
                    testBase.rgName,
                    testBase.serviceName,
                    firstSubscription.ScopeIdentifier,
                    new ProductUpdateParameters
                    {
                        SubscriptionsLimit = int.MaxValue
                    },
                    "*");

                // add new subscription
                string newSubscriptionId = TestUtilities.GenerateName("subscription");
                string globalSubscriptionId = TestUtilities.GenerateName("globalSubscription");

                try
                {
                    string newSubscriptionName = TestUtilities.GenerateName("newSubscription1");
                    string newSubscriptionPk = TestUtilities.GenerateName("newSubscription2");
                    string newSubscriptionSk = TestUtilities.GenerateName("newSubscription3");
                    var newSubscriptionState = SubscriptionState.Active;

                    var newSubscriptionCreate = new SubscriptionCreateParameters(
                        firstSubscription.Scope,
                        newSubscriptionName,
                        firstSubscription.OwnerId)
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
                    Assert.Equal(firstSubscription.ScopeIdentifier, subscriptionContract.ScopeIdentifier);
                    Assert.Equal(firstSubscription.OwnerId, subscriptionContract.OwnerId);
                    Assert.Equal(newSubscriptionState, subscriptionContract.State);
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.Equal(newSubscriptionSk, subscriptionContract.SecondaryKey);
                        Assert.Equal(newSubscriptionPk, subscriptionContract.PrimaryKey);
                    }
                    Assert.Equal(newSubscriptionName, subscriptionContract.DisplayName);

                    var subscriptionResponse = await testBase.client.Subscription.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    Assert.NotNull(subscriptionResponse);
                    Assert.NotNull(subscriptionResponse.Headers.ETag);

                    // list product subscriptions 
                    var productSubscriptions = await testBase.client.ProductSubscriptions.ListAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        firstSubscription.ScopeIdentifier);
                    Assert.NotNull(productSubscriptions);
                    Assert.Equal(2, productSubscriptions.Count());

                    // patch the subscription
                    string patchedName = TestUtilities.GenerateName("patched1");
                    string patchedPk = TestUtilities.GenerateName("patched2");
                    string patchedSk = TestUtilities.GenerateName("patched3");
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
                    Assert.Null(getResponse.PrimaryKey);
                    Assert.Null(getResponse.SecondaryKey);
                    Assert.Equal(newSubscriptionState, getResponse.State);
                    Assert.Equal(patchedExpirationDate, getResponse.ExpirationDate);

                    var secretsResponse = testBase.client.Subscription.ListSecrets(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.Equal(patchedPk, secretsResponse.PrimaryKey);
                        Assert.Equal(patchedSk, secretsResponse.SecondaryKey);
                    }

                    // regenerate primary key
                    testBase.client.Subscription.RegeneratePrimaryKey(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    // get the subscription to check the key
                    var keysResponse = testBase.client.Subscription.ListSecrets(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    Assert.NotNull(keysResponse);
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.NotEqual(patchedPk, keysResponse.PrimaryKey);
                        Assert.Equal(patchedSk, keysResponse.SecondaryKey);
                    }

                    // regenerate secondary key
                    testBase.client.Subscription.RegenerateSecondaryKey(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    // get the subscription to check the key
                    var keysHttpResponse = await testBase.client.Subscription.ListSecretsWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    Assert.NotNull(keysHttpResponse);
                    if (HttpMockServer.Mode != HttpRecorderMode.Playback)
                    {
                        Assert.NotEqual(patchedPk, keysHttpResponse.Body.PrimaryKey);
                        Assert.NotEqual(patchedSk, keysHttpResponse.Body.SecondaryKey);
                    }

                    // get the subscription to check the key
                    subscriptionResponse = await testBase.client.Subscription.GetWithHttpMessagesAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        newSubscriptionId);

                    Assert.NotNull(subscriptionResponse);
                    Assert.NotNull(subscriptionResponse.Headers.ETag);
                    Assert.Null(subscriptionResponse.Body.PrimaryKey);
                    Assert.Null(subscriptionResponse.Body.SecondaryKey);

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

                    // create a subscription with global scope on all apis
                    var globalSubscriptionDisplayName = TestUtilities.GenerateName("global");
                    var globalSubscriptionCreateResponse = await testBase.client.Subscription.CreateOrUpdateAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        globalSubscriptionId,
                        new SubscriptionCreateParameters("/apis", globalSubscriptionDisplayName));
                    Assert.NotNull(globalSubscriptionCreateResponse);
                    Assert.Equal("apis", globalSubscriptionCreateResponse.ScopeIdentifier);
                    Assert.Null(globalSubscriptionCreateResponse.OwnerId);
                    Assert.Equal(SubscriptionState.Active, globalSubscriptionCreateResponse.State);
                    Assert.NotNull(globalSubscriptionCreateResponse.SecondaryKey);
                    Assert.NotNull(globalSubscriptionCreateResponse.PrimaryKey);
                    Assert.Equal(globalSubscriptionDisplayName, globalSubscriptionCreateResponse.DisplayName);

                    // delete the global subscription
                    await testBase.client.Subscription.DeleteAsync(
                        testBase.rgName,
                        testBase.serviceName,
                        globalSubscriptionId,
                        "*");

                    // get the deleted subscription to make sure it was deleted
                    try
                    {
                        testBase.client.Subscription.Get(testBase.rgName, testBase.serviceName, globalSubscriptionId);
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

                    testBase.client.Subscription.Delete(
                        testBase.rgName,
                        testBase.serviceName,
                        globalSubscriptionId,
                        "*");
                }
            }
        }
    }
}
