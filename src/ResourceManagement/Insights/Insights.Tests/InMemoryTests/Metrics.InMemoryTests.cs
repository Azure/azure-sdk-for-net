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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Insights.Tests.Helpers;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Xunit;

namespace Insights.Tests.InMemoryTests
{
    public class MetricsInMemoryTests : TestBase
    {
        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";

        
        [Fact(Skip="TODO: invetigate with Inights team when owner is back to office")]
        public void GetMetricDefinitionsTest()
        {
            MetricDefinitionCollection expectedMetricDefinitionCollection = GetMetricDefinitionCollection(ResourceUri);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedMetricDefinitionCollection.ToJson())
            };

            RecordedDelegatingHandler handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsClient(handler);

            string filterString = "names eq 'CpuPercentage'";
            MetricDefinitionListResponse actualMetricDefinitions =
                (insightsClient.MetricDefinitionOperations as MetricDefinitionOperations)
                    .GetMetricDefinitionsAsync(
                        ResourceUri,
                        filterString,
                        new CancellationToken()).Result;

            AreEqual(expectedMetricDefinitionCollection, actualMetricDefinitions.MetricDefinitionCollection);
        }

        [Fact(Skip = "TODO: invetigate with Inights team when owner is back to office")]
        public void GetMetricsTest()
        {
            MetricCollection expectedMetricCollection = GetMetricCollection(ResourceUri);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedMetricCollection.ToJson())
            };

            RecordedDelegatingHandler handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsClient(handler);

            string filterString = "timeGrain eq duration'PT1M' and startTime eq 2014-01-01T06:00:00Z and endTime eq 2014-01-10T06:00:00Z";
            MetricListResponse actualMetrics = (insightsClient.MetricOperations as MetricOperations)
                .GetMetricsAsync(
                    ResourceUri,
                    filterString,
                    CancellationToken.None).Result;

            AreEqual(expectedMetricCollection, actualMetrics.MetricCollection);
        }

        private MetricCollection GetMetricCollection(string resourceId)
        {
            return new MetricCollection
            {
                Value = new List<Metric>
                {
                    new Metric
                    {
                        StartTime = DateTime.Parse("2014-08-20T12:15:23.00Z"),
                        EndTime = DateTime.Parse("2014-08-20T12:20:23.00Z"),
                        Name = new LocalizableString {LocalizedValue = "CPU Percentage", Value = "CpuPercentage"},
                        ResourceId = resourceId,
                        TimeGrain = TimeSpan.FromMinutes(10),
                        Unit = Unit.Percent,
                        Properties = new Dictionary<string, string>
                        {
                            {"prop1", "val1"}
                        },
                        MetricValues = new List<MetricValue>
                        {
                            new MetricValue
                            {
                                Average = 10.0,
                                Count = 1,
                                Last = 10.0,
                                Maximum = 10.0,
                                Minimum = 10.0,
                                Properties = new Dictionary<string, string>
                                {
                                    {"prop2", "val2"}
                                },
                                Timestamp = DateTime.Parse("2014-08-20T12:15:23.00Z"),
                                Total = 10.0
                            }
                        }
                    }
                }
            };
        }

        private void AreEqual(MetricCollection exp, MetricCollection act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Value.Count; i++)
                {
                    AreEqual(exp.Value[i], act.Value[i]);
                }
            }
        }

        private void AreEqual(Metric exp, Metric act)
        {
            if (exp != null)
            {
                AreEqual(exp.Name, act.Name);
                Assert.Equal(exp.EndTime.ToUniversalTime(), act.EndTime.ToUniversalTime());
                Assert.Equal(exp.ResourceId, act.ResourceId);
                Assert.Equal(exp.StartTime.ToUniversalTime(), act.StartTime.ToUniversalTime());
                Assert.Equal(exp.TimeGrain, act.TimeGrain);
                Assert.Equal(exp.Unit, act.Unit);
                AreEqual(exp.Properties, act.Properties);

                if (exp.MetricValues != null)
                {
                    for (int i = 0; i < exp.MetricValues.Count; i++)
                    {
                        AreEqual(exp.MetricValues[i], act.MetricValues[i]);
                    }
                }
            }
        }

        private void AreEqual(MetricValue exp, MetricValue act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Average, act.Average);
                Assert.Equal(exp.Count, act.Count);
                Assert.Equal(exp.Last, act.Last);
                Assert.Equal(exp.Maximum, act.Maximum);
                Assert.Equal(exp.Minimum, act.Minimum);
                Assert.Equal(exp.Timestamp.ToUniversalTime(), act.Timestamp.ToUniversalTime());
                Assert.Equal(exp.Total, act.Total);
                AreEqual(exp.Properties, act.Properties);
            }
        }
        
        #region MetricDefinition helpers

        private static void AreEqual(MetricDefinitionCollection exp, MetricDefinitionCollection act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Value.Count; i++)
                {
                    AreEqual(exp.Value[i], act.Value[i]);
                }
            }
        }

        private static void AreEqual(MetricDefinition exp, MetricDefinition act)
        {
            if (exp != null)
            {
                AreEqual(exp.Name, act.Name);
                Assert.Equal(exp.ResourceUri, act.ResourceUri);
                Assert.Equal(exp.Unit, act.Unit);
                AreEqual(exp.Properties, act.Properties);

                if (exp.MetricAvailabilities != null)
                {
                    for (int i = 0; i < exp.MetricAvailabilities.Count; i++)
                    {
                        AreEqual(exp.MetricAvailabilities[i], act.MetricAvailabilities[i]);
                    }
                }
            }
        }

        private static void AreEqual(MetricAvailability exp, MetricAvailability act)
        {
            if (exp != null)
            {
                AreEqual(exp.Location, act.Location);
                Assert.Equal(exp.Retention, act.Retention);
                Assert.Equal(exp.TimeGrain, act.TimeGrain);
            }
        }

        private static void AreEqual(MetricLocation exp, MetricLocation act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.PartitionKey, act.PartitionKey);
                Assert.Equal(exp.TableEndpoint, act.TableEndpoint);
                AreEqual(exp.TableInfo, act.TableInfo);
            }
        }

        private static void AreEqual(IList<MetricTableInfo> exp, IList<MetricTableInfo> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    Assert.Equal(exp[i].EndTime.ToUniversalTime(), act[i].EndTime.ToUniversalTime());
                    Assert.Equal(exp[i].SasToken, act[i].SasToken);
                    Assert.Equal(exp[i].SasTokenExpirationTime.ToUniversalTime(), act[i].SasTokenExpirationTime.ToUniversalTime());
                    Assert.Equal(exp[i].StartTime.ToUniversalTime(), act[i].StartTime.ToUniversalTime());
                    Assert.Equal(exp[i].TableName, act[i].TableName);
                }
            }
        }

        private MetricDefinitionCollection GetMetricDefinitionCollection(string resourceUri)
        {
            var metriAvailabilities = new List<MetricAvailability>()
            {
                new MetricAvailability
                {
                    Location = new MetricLocation
                    {
                        PartitionKey = "p1",
                        TableEndpoint = "http://sa.table.core.windows.net/",
                        TableInfo = new List<MetricTableInfo>
                        {
                            new MetricTableInfo
                            {
                                EndTime = DateTime.Parse("2014-08-20T12:00:10Z"),
                                StartTime = DateTime.Parse("2014-08-19T12:00:00Z"),
                                SasToken = Guid.NewGuid().ToString("N"),
                                SasTokenExpirationTime = DateTime.Parse("2014-08-20T12:00:10Z"),
                                TableName = "datatable"
                            }
                        }
                    },
                    Retention = TimeSpan.FromDays(30),
                    TimeGrain = TimeSpan.FromMinutes(10)
                }
            };

            MetricDefinition[] metricDefinitions = new MetricDefinition[1];
            metricDefinitions[0] = new MetricDefinition
            {
                MetricAvailabilities = metriAvailabilities,
                Name = new LocalizableString() { LocalizedValue = "CPU Percentage", Value = "CpuPercentage" },
                PrimaryAggregationType = AggregationType.Average,
                Properties = new Dictionary<string, string>()
                {
                    {"prop1", "val1" }
                },
                ResourceUri = resourceUri,
                Unit = Unit.Bytes
            };
            return new MetricDefinitionCollection
            {
                Value = metricDefinitions
            };
        }

        #endregion
    }
}
