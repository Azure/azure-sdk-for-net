// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class UsagesTests : InsightsManagementClientMockedBase
    {
        public UsagesTests(bool isAsync)
            : base(isAsync)
        { }

        //[Test]
        //public void ListUsageTest()
        //{
        //    string resourceUri = "/subscriptions/123456789/resourceGroups/rg/providers/rp/rUri";
        //    List<UsageMetric> expectedUsageMetricCollection = GetUsageMetricCollection(resourceUri);

        //    var handler = new RecordedDelegatingHandler();
        //    var insightsClient = GetInsightsClient(handler);
        //    var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedUsageMetricCollection, insightsClient.SerializationSettings);

        //    var response = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
        //    };

        //    handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
        //    insightsClient = GetInsightsClient(handler);

        //    string filterString = "name.value eq 'CPUTime' or name.value eq 'Requests'";
        //    IEnumerable<UsageMetric> actualRespose = insightsClient.UsageMetrics.List(resourceUri: resourceUri, apiVersion: "2014-04-01", odataQuery: filterString);

        //    AreEqual(expectedUsageMetricCollection, actualRespose.GetEnumerator());
        //}

        //private static List<UsageMetric> GetUsageMetricCollection(string resourceUri)
        //{
        //    return new List<UsageMetric>()
        //    {
        //        new UsageMetric(
        //            id: "The id",
        //            currentValue: 10.1,
        //            limit: 100.2,
        //            name: new LocalizableString(
        //                localizedValue: "Cpu Percentage",
        //                value: "CpuPercentage"),
        //            nextResetTime: DateTime.UtcNow.AddDays(1),
        //            quotaPeriod: TimeSpan.FromDays(1),
        //            unit: Unit.Percent.ToString()
        //        )
        //    };
        //}
    }
}
