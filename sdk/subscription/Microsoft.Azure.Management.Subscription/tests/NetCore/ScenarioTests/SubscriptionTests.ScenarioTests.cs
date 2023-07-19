// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Rest.TransientFaultHandling;
using Xunit;
using Microsoft.Azure.Management.Subscription.Models;
using System.Collections.Generic;
using System;
using System.Threading;

namespace ResourceGroups.Tests
{
    [TestCaseOrderer("Orderer.Helper.PriorityOrderer", "ResourceGroups.Tests")]
    public class LiveSubscriptionTests : TestBase
    {
        private const string subscriptionId = "d17ad3ae-320e-42ff-b5a1-705389c6063a";

        public SubscriptionClient GetSubscriptionClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = this.GetSubscriptionClientWithHandler(context, handler);
            return client;
        }

        [Fact]
        public void Rename()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);

                var result = client.Subscription.Rename(subscriptionId, new Microsoft.Azure.Management.Subscription.Models.SubscriptionName()
                {
                    SubscriptionNameProperty = "renamed-sub-" + Guid.NewGuid().ToString().Substring(0, 5)
                });

                Assert.Equal(HttpMethod.Post, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
                Assert.Equal(subscriptionId, result.SubscriptionId);
            }
        }

        [Fact]
        public void Cancel()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);
                //Responds 400 since there are existing resources associated with subscription. Need to delete them before cancelling the subscription
                Assert.Throws<ErrorResponseBodyException>(() => _ = client.Subscription.Cancel(subscriptionId));
            }
        }
        
        [Fact]
        public void Enable()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);
                //Responds 400 since the subscription is not deactivated
                Assert.Throws<ErrorResponseBodyException>(() => _ = client.Subscription.Enable(subscriptionId));
            }
        }

        [Fact]
        public void Operations()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);

                var result = client.Operations.List();

                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            }
        }

        [Fact]
        public void PutAlias()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);

                var aliasName = "test-alias";
                var putAliasRequestBody = new PutAliasRequest(new PutAliasRequestProperties()
                {
                    DisplayName = null,
                    Workload = "Production",
                    BillingScope = null,
                    SubscriptionId = subscriptionId,
                    AdditionalProperties = new PutAliasRequestAdditionalProperties()
                    {
                        ManagementGroupId = null,
                        Tags = new Dictionary<string, string>() { { "tag1", "Messi" }, { "tag2", "Ronaldo" }, { "tag3", "Lebron" } }
                    },

                });
                var result = client.Alias.Create(aliasName, putAliasRequestBody);

                Assert.Equal(HttpMethod.Put, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            }
        }

        [Fact]
        public void GetAlias()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);

                var aliasName = "test-alias2";
                var result = client.Alias.Get(aliasName);

                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            }
        }

        [Fact]
        public void DeleteAlias()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);

                var aliasName = "test-alias";
                var putAliasRequestBody = new PutAliasRequest();
                client.Alias.Delete(aliasName);

                Assert.Equal(HttpMethod.Delete, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            }
        }

        [Fact]
        public void AcceptOwnership()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);
                Assert.Throws<ErrorResponseBodyException>(() => _ = client.Subscription.AcceptOwnership(subscriptionId, new AcceptOwnershipRequest()));
            }
        }

        [Fact]
        public void GetAcceptSubscriptionOwnershipStatus()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);
                Assert.Throws<ErrorResponseBodyException>(() => client.Subscription.AcceptOwnershipStatus(subscriptionId));
            }
        }

        [Fact]
        public void PutTenantPolicy()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);

                var result = client.SubscriptionPolicy.AddUpdatePolicyForTenant(new PutTenantPolicyRequestProperties()
                {
                    BlockSubscriptionsIntoTenant = true,
                    BlockSubscriptionsLeavingTenant = true,
                    ExemptedPrincipals = new List<Guid?>()
                {
                    Guid.Parse("e879cf0f-2b4d-5431-109a-f72fc9868693"),
                    Guid.Parse("9792da87-c97b-410d-a97d-27021ba09ce6")
                }
                });

                Assert.Equal(HttpMethod.Put, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            }
        }

        [Fact]
        public void GetTenantDefaultPolicies()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);

                var result = client.SubscriptionPolicy.GetPolicyForTenant();

                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            }
        }

        [Fact]
        public void GetPolicies()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);

                var result = client.SubscriptionPolicy.ListPolicyForTenant();

                Assert.Equal(HttpMethod.Get, handler.Method);
                Assert.NotNull(handler.RequestHeaders.GetValues("Authorization"));
            }
        }

        [Fact]
        public void GetBillingAccountPolicy()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);

                var billingAccountId = "561a5998-da58-5f3d-bd54-d13025c679f5:bb50dbaa-b975-4445-8740-35be408bac21_2019-05-31";
                Assert.Throws<ErrorResponseBodyException>(() => _ = client.BillingAccount.GetPolicy(billingAccountId));
            }
        }

        [Fact]
        public void ListSubscriptions()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var subscriptions = client.Subscriptions.List();

                Assert.NotNull(subscriptions);
                Assert.NotEmpty(subscriptions);
                Assert.NotNull(subscriptions.First().Id);
                Assert.NotNull(subscriptions.First().SubscriptionId);
                Assert.NotNull(subscriptions.First().DisplayName);
                Assert.NotNull(subscriptions.First().State);
            }
        }

        [Fact]
        public void GetSubscriptionDetails()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var client = GetSubscriptionClient(context, handler);
                client.SetRetryPolicy(new RetryPolicy<HttpStatusCodeErrorDetectionStrategy>(1));

                var subscriptionDetails = client.Subscriptions.Get(subscriptionId);

                Assert.NotNull(subscriptionDetails);
                Assert.NotNull(subscriptionDetails.Id);
                Assert.NotNull(subscriptionDetails.SubscriptionId);
                Assert.NotNull(subscriptionDetails.DisplayName);
                Assert.NotNull(subscriptionDetails.State);
            }
        }
    }
}
