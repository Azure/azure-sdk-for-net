// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Microsoft.Rest.Azure.OData;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Monitor.Tests.Scenarios
{
    /// <summary>
    /// <para>Class to unit test the Monitor API methods.</para>
    /// <para>The goal of these tests is to find out if the serialization/deserialization is working properly. Testing other features is out of scope.</para>
    /// </summary>
    public class EventDataTests : TestBase
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

        private RecordedDelegatingHandler handler;

        public EventDataTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        /// <summary>
        /// Test for the ListEvents API method
        /// </summary>
        [Fact(Skip = "Failing due to $filter value not valid")]
        [Trait("Category", "Scenario")]
        public void ListEventsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                List<EventData> expectedEventDataCollection = GetEventDataCollection();

                var insightsClient = GetMonitorManagementClient(context, handler);

                var startTime = DateTimeOffset.Parse("2017-08-01T00:00:00.00Z");
                var endTime = DateTimeOffset.Parse("2017-08-01T23:59:00.00Z");
                var filterString = new ODataQuery<EventData>(p => ((p.EventTimestamp >= startTime) && (p.EventTimestamp < endTime)));

                var actualEventDataCollection = insightsClient.ActivityLogs.List(filterString);

                Assert.True(string.IsNullOrWhiteSpace(actualEventDataCollection.NextPageLink));

                if (!this.IsRecording)
                {
                    AreEqual(expectedEventDataCollection, actualEventDataCollection.GetEnumerator());
                }
            }
        }

        /// <summary>
        /// Test for the ListEventsNext method
        /// </summary>
        [Fact(Skip = "First call fails due to $filter value not valid")]
        [Trait("Category", "Scenario")]
        public void ListEventsNextTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                List<EventData> expectedEventDataCollection = GetEventDataCollection();

                var insightsClient = GetMonitorManagementClient(context, handler);

                var actualEventDataCollection = insightsClient.ActivityLogs.ListNext("http://www.microsoft.com");

                if (!this.IsRecording)
                {
                    Assert.True(string.IsNullOrWhiteSpace(actualEventDataCollection.NextPageLink));
                    AreEqual(expectedEventDataCollection, actualEventDataCollection.GetEnumerator());
                }
            }
        }

        #region private methods

        private static void AreEqual(IEnumerable<EventData> exp, IEnumerator<EventData> act)
        {
            if (exp != null)
            {
                List<EventData> expList = exp.ToList();
                List<EventData> actList = new List<EventData>();
                while (act.MoveNext())
                {
                    actList.Add(act.Current);
                }

                Assert.Equal(expList.Count, actList.Count);

                for (int i=0;i<expList.Count;i++)
                {
                    AreEqual(expList[i], actList[i]);
                }
            }
            else
            {
                Assert.Null(act);
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
                Assert.Equal(exp.EventTimestamp?.ToUniversalTime(), act.EventTimestamp?.ToUniversalTime());
                AreEqual(exp.HttpRequest, act.HttpRequest);
                Assert.Equal(exp.Level, act.Level);
                Assert.Equal(exp.OperationId, act.OperationId);
                AreEqual(exp.OperationName, act.OperationName);
                AreEqual(exp.Properties, act.Properties);
                Assert.Equal(exp.ResourceGroupName, act.ResourceGroupName);
                AreEqual(exp.ResourceProviderName, act.ResourceProviderName);
                AreEqual(exp.Status, act.Status);
                AreEqual(exp.SubStatus, act.SubStatus);
                Assert.Equal(exp.SubmissionTimestamp?.ToUniversalTime(), act.SubmissionTimestamp?.ToUniversalTime());
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
                Assert.Equal(exp.Role, act.Role);
                Assert.Equal(exp.Scope, act.Scope);
            }
        }

        private static List<EventData> GetEventDataCollection()
        {
            return new List<EventData>()
            {
                new EventData(
                    authorization: new SenderAuthorization(action: "action", role: "role" , scope: "scope"),
                    claims: new Dictionary<string, string> { {"prop1", "val1"} },
                    correlationId: Guid.NewGuid().ToString("N"),
                    description: "description",
                    eventDataId: Guid.NewGuid().ToString("N"),
                    eventName: new LocalizableString(
                        localizedValue: "Event Name",
                        value: "EventName"),
                    category: new LocalizableString(
                        localizedValue: "Administrative",
                        value: "Administrative"),
                    eventTimestamp: DateTime.UtcNow,
                    httpRequest: new HttpRequestInfo(
                        clientIpAddress: "1.1.1.1",
                        clientRequestId: Guid.NewGuid().ToString("N"),
                        method: "method",
                        uri: "http://localhost"),
                    level: EventLevel.Critical,
                    operationId: Guid.NewGuid().ToString("N"),
                    operationName: new LocalizableString(
                        localizedValue: "Operation Name",
                        value: "OperationName"),
                    properties: new Dictionary<string, string>()
                    {
                        {"prop1", "val1"}
                    },
                    resourceGroupName: "rg1",
                    resourceProviderName: new LocalizableString(
                        localizedValue: "Resource provider name",
                        value: "ResourceProviderName"),
                    resourceId: "/subscriptions/sub1",
                    status: new LocalizableString(
                        localizedValue: "Is Ready", 
                        value: "IsReady"),
                    subStatus: new LocalizableString(
                        localizedValue: "sub 1",
                        value: "sub1"),
                    submissionTimestamp: DateTime.UtcNow,
                    subscriptionId: Guid.NewGuid().ToString("N"))
            };
        }

        #endregion
    }
}
