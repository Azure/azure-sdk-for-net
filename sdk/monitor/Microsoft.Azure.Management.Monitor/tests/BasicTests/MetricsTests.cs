// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;

namespace Monitor.Tests.BasicTests
{
    public class MetricsTests : TestBase
    {
        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";
        
        [Fact]
        [Trait("Category", "Mock")]
        public void GetMetricDefinitionsTest()
        {
            IList<MetricDefinition> expectedMetricDefinitionCollection = GetMetricDefinitionCollection(ResourceUri);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", expectedMetricDefinitionCollection.ToJson(), "}"))
            };

            RecordedDelegatingHandler handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetMonitorManagementClient(handler);

            var actualMetricDefinitions = insightsClient.MetricDefinitions.ListAsync(resourceUri: ResourceUri, cancellationToken: new CancellationToken()).Result;

            AreEqual(expectedMetricDefinitionCollection, actualMetricDefinitions.ToList<MetricDefinition>());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetMetricsTest()
        {
            Response expectedMetricCollection = GetMetricCollection(ResourceUri);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedMetricCollection.ToJson())
            };

            RecordedDelegatingHandler handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetMonitorManagementClient(handler);

            var actualMetrics = insightsClient.Metrics.ListAsync(
                resourceUri: ResourceUri,
                timespan: "2017-08-10T22:19:35Z/2017-08-10T23:19:35Z",
                resultType: ResultType.Data,
                cancellationToken: CancellationToken.None).Result;

            // TODO: check the other values too
            AreEqual(expectedMetricCollection, actualMetrics);
        }

        private Response GetMetricCollection(string resourceId)
        {
            return new Response
            {
                Timespan = "2017-08-10T22:19:35Z/2017-08-10T23:19:35Z",
                Cost = 0,
                Interval = TimeSpan.FromMinutes(1),
                Value = new List<Metric>
                {
                    new Metric
                    {
                        Id = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/Microsoft.Web/sites/alertruleTest/providers/Microsoft.Insights/metrics/CpuTime",
                        Type = "Microsoft.Insights/metrics",
                        Name = new LocalizableString {LocalizedValue = "CPU Time", Value = "CpuTime"},
                        Unit = "Seconds",
                        Timeseries = new List<TimeSeriesElement>
                        {
                            new TimeSeriesElement
                            {
                                Data = new List<MetricValue>
                                {
                                    new MetricValue
                                    {
                                        TimeStamp = DateTime.Parse("2017-08-10T22:19:00Z"),
                                        Total = 0.0
                                    },
                                    new MetricValue
                                    {
                                        TimeStamp = DateTime.Parse("2017-08-10T22:20:00Z"),
                                        Total = 0.0
                                    },
                                    new MetricValue
                                    {
                                        TimeStamp = DateTime.Parse("2017-08-10T22:21:00Z"),
                                        Total = 0.0
                                    }
                                },
                                Metadatavalues = new List<MetadataValue>()
                            }
                        }
                    }
                } 
            };
        }

        private void AreEqual(Response exp, Response act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Timespan, act.Timespan);
                Assert.Equal(exp.Interval, act.Interval);
                Assert.Equal(exp.Cost, act.Cost);
                AreEqual(exp.Value, act.Value);
            }
        }

        private void AreEqual(IList<Metric> exp, IList<Metric> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);

                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private void AreEqual(Metric exp, Metric act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Type, act.Type);
                Utilities.AreEqual(exp.Name, act.Name);
                Assert.Equal(exp.Unit, act.Unit);
                AreEqual(exp.Timeseries, act.Timeseries);
            }
        }

        private void AreEqual(IList<TimeSeriesElement> exp, IList<TimeSeriesElement> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);

                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private void AreEqual(TimeSeriesElement exp, TimeSeriesElement act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);

                AreEqual(exp.Data, act.Data);
                AreEqual(exp.Metadatavalues, act.Metadatavalues);
            }
            else
            {
                Assert.Null(act);
            }
        }

        private void AreEqual(IList<MetricValue> exp, IList<MetricValue> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);

                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private void AreEqual(MetricValue exp, MetricValue act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Average, act.Average);
                Assert.Equal(exp.Count, act.Count);
                Assert.Equal(exp.Maximum, act.Maximum);
                Assert.Equal(exp.Minimum, act.Minimum);
                Assert.Equal(exp.TimeStamp.ToUniversalTime(), act.TimeStamp.ToUniversalTime());
                Assert.Equal(exp.Total, act.Total);
            }
        }

        private void AreEqual(IList<MetadataValue> exp, IList<MetadataValue> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);

                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private void AreEqual(MetadataValue exp, MetadataValue act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);

                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Value, act.Value);
            }
            else
            {
                Assert.Null(act);
            }
        }

        #region MetricDefinition helpers

        private static void AreEqual(IList<MetricDefinition> exp, IList<MetricDefinition> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(MetricDefinition exp, MetricDefinition act)
        {
            if (exp != null)
            {
                Utilities.AreEqual(exp.Name, act.Name);
                Assert.Equal(exp.ResourceId, act.ResourceId);
                Assert.Equal(exp.Unit, act.Unit);
                Assert.Equal(exp.PrimaryAggregationType, act.PrimaryAggregationType);

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
                Assert.Equal(exp.Retention, act.Retention);
                Assert.Equal(exp.TimeGrain, act.TimeGrain);
            }
        }

        private IList<MetricDefinition> GetMetricDefinitionCollection(string resourceUri)
        {
            var metriAvailabilities = new List<MetricAvailability>()
            {
                new MetricAvailability(timeGrain: TimeSpan.FromMinutes(10), retention: TimeSpan.FromDays(30))
            };

            MetricDefinition[] metricDefinitions = new MetricDefinition[1];
            metricDefinitions[0] = new MetricDefinition
            {
                MetricAvailabilities = metriAvailabilities,
                Name = new LocalizableString() { LocalizedValue = "CPU Percentage", Value = "CpuPercentage" },
                PrimaryAggregationType = AggregationType.Average,
                ResourceId = resourceUri,
                Unit = "Bytes"
            };
            return metricDefinitions;
        }

        #endregion
    }
}
