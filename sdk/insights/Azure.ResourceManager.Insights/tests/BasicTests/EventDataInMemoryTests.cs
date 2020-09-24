// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class EventDataInMemoryTests : InsightsManagementClientMockedBase
    {
        public EventDataInMemoryTests(bool isAsync)
            : base(isAsync)
        { }

        //[Test]
        //public async void ListEventsTest()
        //{
        //    List<EventData> expectedEventDataCollection = GetEventDataCollection();
        //    var mockResponse = new MockResponse((int)HttpStatusCode.OK);
        //    mockResponse.SetContent(string.Concat("{ \"value\":", expectedEventDataCollection.ToJson(), ", \"nextLink\":\"\"}"));
        //    var mockTransport = new MockTransport(mockResponse);
        //    var insightsClient = GetInsightsManagementClient(mockTransport);

        //    var startTime = DateTimeOffset.Parse("2014-03-11T01:00:00.00Z");
        //    var endTime = DateTimeOffset.Parse("2014-03-11T02:00:00.00Z");

        //    var filterString = new ODataQuery<EventData>(p => (p.EventTimestamp >= startTime) && (p.EventTimestamp < endTime));

        //    var actualEventDataCollection = await insightsClient.EventCategories.ListAsync(filterString);

        //    Assert.True(string.IsNullOrWhiteSpace(actualEventDataCollection.NextPageLink));
        //    Assert.AreEqual(expectedEventDataCollection, actualEventDataCollection.GetEnumerator());
        //}

        ///// <summary>
        ///// Test for the ListEventsNext method
        ///// </summary>
        //[Test]
        //public void ListEventsNextTest()
        //{
        //    List<EventData> expectedEventDataCollection = GetEventDataCollection();
        //    var response = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StringContent(string.Concat("{ \"value\":", expectedEventDataCollection.ToJson(), ", \"nextLink\":\"\"}"))
        //    };

        //    var handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
        //    var insightsClient = GetInsightsClient(handler);

        //    var actualEventDataCollection = insightsClient.Events.ListNext("http://www.microsoft.com");

        //    Assert.True(string.IsNullOrWhiteSpace(actualEventDataCollection.NextPageLink));
        //    Assert.AreEqual(expectedEventDataCollection, actualEventDataCollection.GetEnumerator());
        //}

        //private static List<EventData> GetEventDataCollection()
        //{
        //    return new List<EventData>()
        //    {
        //        new EventData(
        //            authorization: new SenderAuthorization(action: "action", role: "role" , scope: "scope"),
        //            claims: new Dictionary<string, string> { {"prop1", "val1"} },
        //            correlationId: Guid.NewGuid().ToString("N"),
        //            description: "description",
        //            channels: EventChannels.Operation,
        //            eventDataId: Guid.NewGuid().ToString("N"),
        //            eventName: new LocalizableString(
        //                localizedValue: "Event Name",
        //                value: "EventName"),
        //            category: new LocalizableString(
        //                localizedValue: "Administrative",
        //                value: "Administrative"),
        //            eventTimestamp: DateTime.UtcNow,
        //            httpRequest: new HttpRequestInfo(
        //                clientIpAddress: "1.1.1.1",
        //                clientRequestId: Guid.NewGuid().ToString("N"),
        //                method: "method",
        //                uri: "http://localhost"),
        //            level: EventLevel.Critical,
        //            operationId: Guid.NewGuid().ToString("N"),
        //            operationName: new LocalizableString(
        //                localizedValue: "Operation Name",
        //                value: "OperationName"),
        //            properties: new Dictionary<string, string>()
        //            {
        //                {"prop1", "val1"}
        //            },
        //            resourceGroupName: "rg1",
        //            resourceProviderName: new LocalizableString(
        //                localizedValue: "Resource provider name",
        //                value: "ResourceProviderName"),
        //            resourceId: "/subscriptions/sub1",
        //            status: new LocalizableString(
        //                localizedValue: "Is Ready",
        //                value: "IsReady"),
        //            subStatus: new LocalizableString(
        //                localizedValue: "sub 1",
        //                value: "sub1"),
        //            submissionTimestamp: DateTime.UtcNow,
        //            subscriptionId: Guid.NewGuid().ToString("N"))
        //    };
        //}
    }
}
