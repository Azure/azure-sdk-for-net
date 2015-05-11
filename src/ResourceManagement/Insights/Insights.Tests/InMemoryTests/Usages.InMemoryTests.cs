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
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Xunit;

namespace Insights.Tests.InMemoryTests
{
    public class UsagesInMemoryTests : TestBase
    {
        [Fact]
        public void ListUsageTest()
        {
            string resourceUri = "/subscriptions/123456789/resourceGroups/rg/providers/rp/rUri";
            string filterString = "name.value eq 'CPUTime' or name.value eq 'Requests'";

            UsageMetricCollection expectedUsageMetricCollection = GetUsageMetricCollection(resourceUri);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedUsageMetricCollection.ToJson())
            };

            RecordedDelegatingHandler handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsClient(handler);


            UsageMetricListResponse actualRespose = insightsClient.UsageMetricOperations.List(resourceUri: resourceUri, filterString: filterString, apiVersion: "2014-04-01");

            AreEqual(expectedUsageMetricCollection, actualRespose.UsageMetricCollection);
        }

        private static UsageMetricCollection GetUsageMetricCollection(string resourceUri)
        {
            return new UsageMetricCollection
            {
                Value = new List<UsageMetric>()
                {
                    new UsageMetric()
                    {
                        CurrentValue = 10.1,
                        Limit = 100.2,
                        Name = new LocalizableString() {LocalizedValue = "Cpu Percentage", Value = "CpuPercentage"},
                        NextResetTime = "tomorrow",
                        QuotaPeriod = TimeSpan.FromDays(1),
                        Unit = Unit.Percent.ToString()
                    }
                }
            };
        }

        private static void AreEqual(UsageMetricCollection exp, UsageMetricCollection act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Value.Count; i++)
                {
                    AreEqual(exp.Value[i], act.Value[i]);
                }
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
