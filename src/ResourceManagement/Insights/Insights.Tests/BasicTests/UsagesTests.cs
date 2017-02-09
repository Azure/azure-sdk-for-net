// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Insights.Tests.Helpers;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Xunit;
using Newtonsoft.Json;

namespace Insights.Tests.BasicTests
{
    public class UsagesTests : TestBase
    {
        [Fact]
        public void ListUsageTest()
        {
            string resourceUri = "/subscriptions/123456789/resourceGroups/rg/providers/rp/rUri";
            List<UsageMetric> expectedUsageMetricCollection = GetUsageMetricCollection(resourceUri);

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedUsageMetricCollection, insightsClient.SerializationSettings);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(response) { StatusCodeToReturn = HttpStatusCode.OK };
            insightsClient = GetInsightsClient(handler);

            string filterString = "name.value eq 'CPUTime' or name.value eq 'Requests'";
            IEnumerable<UsageMetric> actualRespose = insightsClient.UsageMetrics.List(resourceUri: resourceUri, apiVersion: "2014-04-01", odataQuery: filterString);

            AreEqual(expectedUsageMetricCollection, actualRespose.GetEnumerator());
        }

        private static List<UsageMetric> GetUsageMetricCollection(string resourceUri)
        {
            return new List<UsageMetric>()
            {
                new UsageMetric(
                    id: "The id", 
                    currentValue: 10.1, 
                    limit: 100.2, 
                    name: new LocalizableString(
                        localizedValue: "Cpu Percentage",
                        value: "CpuPercentage"),
                    nextResetTime: DateTime.UtcNow.AddDays(1),
                    quotaPeriod: TimeSpan.FromDays(1),
                    unit: Unit.Percent.ToString()
                )
            };
        }

        private static void AreEqual(List<UsageMetric> exp, IEnumerator<UsageMetric> act)
        {
            if (exp != null)
            {
                List<UsageMetric> actList = new List<UsageMetric>();
                while (act.MoveNext())
                {
                    actList.Add(act.Current);
                }

                Assert.Equal(exp.Count, actList.Count);

                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], actList[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private static void AreEqual(UsageMetric exp, UsageMetric act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.CurrentValue, act.CurrentValue);
                Assert.Equal(exp.Limit, act.Limit);
                Assert.Equal(exp.NextResetTime, act.NextResetTime);
                Assert.Equal(exp.QuotaPeriod, act.QuotaPeriod);
                Assert.Equal(exp.Unit, act.Unit);
                AreEqual(exp.Name, act.Name);
            }
        }
    }
}
