// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Management.Subscription;
using Microsoft.Azure.Management.Subscription.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.Azure.OData;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ResourceGroups.Tests
{
    public class InMemorySubscriptionDefinitionTests
    {
        private const string TestSubscriptionDefinitionName = "MyNewSubscription";
        private readonly Guid _testGroupId = new Guid("d7bd0f12-2920-450e-a54a-4c35d851a3fc");

        private const string NextLink =
            "/providers/Microsoft.SubscriptionDefinitions/subscriptionDefinitions?nextPage=aiasdfjlkfi3212asadfdf";
        private const string SubscriptionDefinition01 = @"{
                'id': '/providers/Microsoft.SubscriptionDefinitions/subscriptionDefinitions/MySubscriptionDefinitionName',
                'type': 'Microsoft.Subscription.subscriptionDefinitions',
                'name': 'MySubscriptionDefinitionName',
                'properties': {
                    'subscriptionId': '0ebc0024-9459-448b-aef4-6617b6f8d217',
                    'subscriptionDisplayName': 'My Azure Subscription Name',
                    'offerType': 'MS-AZR-0017P',
                    'etag': 'somestring'
                }
              }";

        public ISubscriptionDefinitionsClient GetSubscriptionDefinitionClient(RecordedDelegatingHandler handler, Guid? subscriptionId = null)
        {
            TokenCredentials token = subscriptionId.HasValue
                ? new TokenCredentials(subscriptionId.Value.ToString(), "abc123")
                : new TokenCredentials("abc123");
            handler.IsPassThrough = false;
            var client = new SubscriptionDefinitionsClient(token, handler);
            HttpMockServer.Mode = HttpRecorderMode.Playback;
            return client;
        }

        private void ValidateSubscriptionDefinition01Values(SubscriptionDefinition subscriptionDefinitionResult)
        {
            Assert.NotNull(subscriptionDefinitionResult);
            Assert.Equal("/providers/Microsoft.SubscriptionDefinitions/subscriptionDefinitions/MySubscriptionDefinitionName", subscriptionDefinitionResult.Id);
            Assert.Equal("Microsoft.Subscription.subscriptionDefinitions", subscriptionDefinitionResult.Type);
            Assert.Equal("MySubscriptionDefinitionName", subscriptionDefinitionResult.Name);
            Assert.Equal("0ebc0024-9459-448b-aef4-6617b6f8d217", subscriptionDefinitionResult.SubscriptionId);
            Assert.Equal("My Azure Subscription Name", subscriptionDefinitionResult.SubscriptionDisplayName);
            Assert.Equal("MS-AZR-0017P", subscriptionDefinitionResult.OfferType);
        }

        private void ValidateSubscriptionDefinition01InArray(IEnumerable<SubscriptionDefinition> items)
        {
            foreach (var subDef in items)
            {
                ValidateSubscriptionDefinition01Values(subDef);
            }
        }

        [Fact]
        public void SubscriptionDefition_ValidateGet()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(SubscriptionDefinition01)
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var subscriptionDefinitionResult = GetSubscriptionDefinitionClient(handler)
                .SubscriptionDefinitions.Get(TestSubscriptionDefinitionName);
            ValidateSubscriptionDefinition01Values(subscriptionDefinitionResult);
        }

        [Fact]
        public void SubscriptionDefition_ValidateCreate()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(SubscriptionDefinition01)
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var body = new SubscriptionDefinition()
            {
                OfferType = "MS-AZR-0017P",
                SubscriptionDisplayName = "My Azure Subscription Name"
            };
            var subscriptionDefinitionResult = GetSubscriptionDefinitionClient(handler)
                .SubscriptionDefinitions.Create(TestSubscriptionDefinitionName, body);
            ValidateSubscriptionDefinition01Values(subscriptionDefinitionResult);
        }

        [Fact]
        public void SubscriptionDefition_ValidateList()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ 'value' :  [ " + SubscriptionDefinition01 + " ] }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var subscriptionDefinitionResult = GetSubscriptionDefinitionClient(handler)
                .SubscriptionDefinitions.List();
            Assert.NotNull(subscriptionDefinitionResult.FirstOrDefault());
            ValidateSubscriptionDefinition01InArray(subscriptionDefinitionResult);
        }

        [Fact]
        public void SubscriptionDefition_ValidateListWithNextLink()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{ 'value' :  [ " + SubscriptionDefinition01 + " ], 'nextLink': '" + NextLink + "' }")
            };
            response.Headers.Add("x-ms-request-id", "1");
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var subscriptionDefinitionResult = GetSubscriptionDefinitionClient(handler)
                .SubscriptionDefinitions.List();
            Assert.NotNull(subscriptionDefinitionResult.FirstOrDefault());
            Assert.Equal(NextLink, subscriptionDefinitionResult.NextPageLink);
            ValidateSubscriptionDefinition01InArray(subscriptionDefinitionResult);
        }
    }
}
