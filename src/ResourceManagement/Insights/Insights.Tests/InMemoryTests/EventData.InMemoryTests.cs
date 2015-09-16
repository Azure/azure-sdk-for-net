//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Insights.Tests.Helpers;
using Microsoft.Azure.Common.OData;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Xunit;

namespace Insights.Tests.InMemoryTests
{
    /// <summary>
    /// <para>Class to unit test the Insights API methods.</para>
    /// <para>The goal of these tests is to find out if the serialization/deserialization is working properly. Testing other features is out of scope.</para>
    /// </summary>
    public class EventDataInMemoryTests : TestBase
    {
        #region EventCountSummaryContent

//        private static string EventCountSummaryContent = 
//            @"{
//	            'eventPropertyName': 'ResourceUri',
//	            'eventPropertyValue': '/subscriptions/6b483e7e-f352-4d25-b49d-e0cc8b0b78f6/resourcegroups/Default-Web-SouthCentralUS/providers/Microsoft.Web/sites/si',
//	            'startTime': '2014-08-20T00:00:00Z',
//	            'endTime': '2014-08-21T00:00:00Z',
//	            'timeGrain': 'P1D',
//	            'id': '/subscriptions/6b483e7e-f352-4d25-b49d-e0cc8b0b78f6/resourcegroups/Default-Web-SouthCentralUS/providers/Microsoft.Web/sites/si/managementSummariesCount',
//	            'summaryItems': [{
//		            'eventTime': '2014-08-21T00:00:00Z',
//		            'totalEventsCount': 2,
//		            'failedEventsCount': 1
//	            },
//	            {
//		            'eventTime': '2014-08-20T00:00:00Z',
//		            'totalEventsCount': 0,
//		            'failedEventsCount': 0
//	            }]
//            }";

        #endregion

        /// <summary>
        /// Test for the ListEvents API method
        /// </summary>
        [Fact]
        public void ListEventsTest()
        {
            EventDataCollection expectedEventDataCollection = GetEventDataCollection();

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedEventDataCollection.ToJson())
            };
            
            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var startTime = DateTimeOffset.Parse("2014-03-11T01:00:00.00Z");
            var endTime = DateTimeOffset.Parse("2014-03-11T02:00:00.00Z");

            var insightsClient = GetInsightsClient(handler);

            var filterString = FilterString.Generate<ListEventsParameters>(
                    p => (p.EventTimestamp >= startTime) && (p.EventTimestamp < endTime));

            var actualEventDataCollection = insightsClient.EventOperations.ListEvents(filterString, selectedProperties: string.Empty);

            AreEqual(expectedEventDataCollection, actualEventDataCollection.EventDataCollection);       
        }

        /// <summary>
        /// Test for the ListEventsNext method
        /// </summary>
        [Fact]
        public void ListEventsNextTest()
        {
            EventDataCollection expectedEventDataCollection = GetEventDataCollection();

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedEventDataCollection.ToJson())
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var insightsClient = GetInsightsClient(handler);

            var actualEventDataCollection = insightsClient.EventOperations.ListEventsNext("http://www.microsoft.com");
            AreEqual(expectedEventDataCollection, actualEventDataCollection.EventDataCollection);       
        }

        /// <summary>
        /// Test for the ListDigestEvents method
        /// </summary>
        [Fact]
        public void ListDigestEventsTest()
        {
            EventDataCollection expectedEventDataCollection = GetEventDataCollection();

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedEventDataCollection.ToJson())
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };

            var startTime = DateTimeOffset.Parse("2014-03-11T01:00:00.00Z");
            var endTime = DateTimeOffset.Parse("2014-03-11T02:00:00.00Z");

            var insightsClient = GetInsightsClient(handler);

            var filterString = FilterString.Generate<ListEventsParameters>(
                    p => (p.EventTimestamp >= startTime) && (p.EventTimestamp < endTime));

            var actualEventDataCollection = insightsClient.EventOperations.ListDigestEventsAsync(filterString, selectedProperties: string.Empty).Result;

            AreEqual(expectedEventDataCollection, actualEventDataCollection.EventDataCollection);
        }

        /// <summary>
        /// Test for the ListDigestEventsNext method
        /// </summary>
        [Fact]
        public void ListDigestEventsNextTest()
        {
            EventDataCollection expectedEventDataCollection = GetEventDataCollection();

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedEventDataCollection.ToJson())
            };

            var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            var insightsClient = GetInsightsClient(handler);

            var actualEventDataCollection = insightsClient.EventOperations.ListDigestEventsNextAsync("http://www.microsoft.com").Result;
            AreEqual(expectedEventDataCollection, actualEventDataCollection.EventDataCollection);
        }

        #region private methods

        private static void AreEqual(EventDataCollection exp, EventDataCollection act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Value.Count; i++)
                {
                    AreEqual(exp.Value[i], act.Value[i]);
                }
            }
        }

        private static void AreEqual(EventData exp, EventData act)
        {
            if (exp != null)
            {
                AreEqual(exp.Authorization, act.Authorization);
                AreEqual(exp.Claims, act.Claims);
                Assert.Equal(exp.CorrelationId, act.CorrelationId);
                Assert.Equal(exp.Description, act.Description);
                Assert.Equal(exp.EventDataId, act.EventDataId);
                AreEqual(exp.EventName, act.EventName);
                Assert.Equal(exp.EventTimestamp.ToUniversalTime(), act.EventTimestamp.ToUniversalTime());
                AreEqual(exp.HttpRequest, act.HttpRequest);
                Assert.Equal(exp.Level, act.Level);
                Assert.Equal(exp.OperationId, act.OperationId);
                AreEqual(exp.OperationName, act.OperationName);
                AreEqual(exp.Properties, act.Properties);
                Assert.Equal(exp.ResourceGroupName, act.ResourceGroupName);
                AreEqual(exp.ResourceProviderName, act.ResourceProviderName);
                AreEqual(exp.Status, act.Status);
                AreEqual(exp.SubStatus, act.SubStatus);
                Assert.Equal(exp.SubmissionTimestamp.ToUniversalTime(), act.SubmissionTimestamp.ToUniversalTime());
                Assert.Equal(exp.SubscriptionId, act.SubscriptionId);

                // TODO: This cannot be verified for now. Should fix this in the next mmilestone.
                // Assert.Equal(exp.EventChannels, act.EventChannels);
            }
        }

        private static void AreEqual(HttpRequestInfo exp, HttpRequestInfo act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ClientIpAddress, act.ClientIpAddress);
                Assert.Equal(exp.ClientRequestId, act.ClientRequestId);
                Assert.Equal(exp.Method, act.Method);
                Assert.Equal(exp.Uri, act.Uri);
            }
        }

        private static void AreEqual(SenderAuthorization exp, SenderAuthorization act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Action, act.Action);
                Assert.Equal(exp.Condition, act.Condition);
                Assert.Equal(exp.Role, act.Role);
                Assert.Equal(exp.Scope, act.Scope);
            }
        }

        private static EventDataCollection GetEventDataCollection()
        {
            return new EventDataCollection
            {
                NextLink = "next link",
                Value = new List<EventData>()
                {
                    new EventData
                    {
                        Authorization = new SenderAuthorization()
                        {
                            Action = "action",
                            Condition = "condition",
                            Role = "role",
                            Scope = "scoope"
                        },
                        Claims = new Dictionary<string, string>()
                        {
                            {"prop1", "val1"}
                        },
                        CorrelationId = Guid.NewGuid().ToString("N"),
                        Description = "description",
                        EventChannels = EventChannels.Operation,
                        EventDataId = Guid.NewGuid().ToString("N"),
                        EventName = new LocalizableString() {LocalizedValue = "Event Name", Value = "EventName"},
                        Category = new LocalizableString() {LocalizedValue = "Administrative", Value = "Administrative"},
                        EventTimestamp = DateTime.UtcNow,
                        HttpRequest = new HttpRequestInfo()
                        {
                            ClientIpAddress = "1.1.1.1",
                            ClientRequestId = Guid.NewGuid().ToString("N"),
                            Method = "method",
                            Uri = "http://localhost"
                        },
                        Level = EventLevel.Critical,
                        OperationId = Guid.NewGuid().ToString("N"),
                        OperationName =
                            new LocalizableString() {LocalizedValue = "Operation Name", Value = "OperationName"},
                        Properties = new Dictionary<string, string>()
                        {
                            {"prop1", "val1"}
                        },
                        ResourceGroupName = "rg1",
                        ResourceProviderName =
                            new LocalizableString()
                            {
                                LocalizedValue = "Resource provider name",
                                Value = "ResourceProviderName"
                            },
                        ResourceId = "/subscriptions/sub1",
                        Status = new LocalizableString() {LocalizedValue = "Is Ready", Value = "IsReady"},
                        SubStatus = new LocalizableString() {LocalizedValue = "sub 1", Value = "sub1"},
                        SubmissionTimestamp = DateTime.UtcNow,
                        SubscriptionId = Guid.NewGuid().ToString("N")
                    }
                }
            };
        }

        #endregion
    }
}
