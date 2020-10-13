// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Azure.Management.Subscription.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.Azure.OData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ResourceGroups.Tests
{
    public class InMemorySubscriptionCreationTests
    {
        private const string SubscriptionLink = "/subscriptions/0ebc0024-9459-448b-aef4-6617b6f8d217";
        private const string SubscriptionCreationResult = @"{ 
               'SubscriptionLink': '" + SubscriptionLink + "'}";

        public ISubscriptionClient GetSubscriptionClient(RecordedDelegatingHandler handler, Guid? subscriptionId = null)
        {
            TokenCredentials token = subscriptionId.HasValue
                ? new TokenCredentials(subscriptionId.Value.ToString(), "abc123")
                : new TokenCredentials("abc123");
            handler.IsPassThrough = false;
            var client = new SubscriptionClient(token, handler);
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            return client;
        }

        [Fact]
        public async Task SubscriptionDefition_ValidateCreate()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(SubscriptionCreationResult)
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var testPrincipal = new AdPrincipal(Guid.NewGuid().ToString());
            var body = new SubscriptionCreationParameters()
            {
                OfferType = "MS-AZR-0017P",
                DisplayName = "My Azure Subscription Name",
                Owners = new List<AdPrincipal> () { testPrincipal }
            };
            var subscriptionResult = await GetSubscriptionClient(handler)
                .Subscription.CreateSubscriptionInEnrollmentAccountWithHttpMessagesAsync(Guid.NewGuid().ToString(), body);
            Assert.NotNull(subscriptionResult);
            Assert.NotNull(subscriptionResult.Response);
            Assert.True(subscriptionResult.Response.IsSuccessStatusCode);
            Assert.Equal(subscriptionResult.Body.SubscriptionLink, SubscriptionLink);
        }
    }
}
