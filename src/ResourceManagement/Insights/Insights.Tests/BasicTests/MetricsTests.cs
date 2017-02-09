// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using Insights.Tests.Helpers;
using Microsoft.Azure.Insights;
using Microsoft.Azure.Insights.Models;
using Xunit;

namespace Insights.Tests.BasicTests
{
    public class MetricsTests : TestBase
    {
        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";
        
        [Fact]
        public void GetMetricDefinitionsTest()
        {
            IList<MetricDefinition> expectedMetricDefinitionCollection = GetMetricDefinitionCollection(ResourceUri);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", expectedMetricDefinitionCollection.ToJson(), "}"))
            };

            RecordedDelegatingHandler handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsClient(handler);

            var filterString = new Microsoft.Rest.Azure.OData.ODataQuery<MetricDefinition>("names eq 'CpuPercentage'");
            var actualMetricDefinitions = insightsClient.MetricDefinitions.ListAsync(resourceUri: ResourceUri, odataQuery: filterString, cancellationToken: new CancellationToken()).Result;

            AreEqual(expectedMetricDefinitionCollection, actualMetricDefinitions.ToList<MetricDefinition>());
        }

        [Fact]
        public void GetMetricsTest()
        {
            IList<Metric> expectedMetricCollection = GetMetricCollection(ResourceUri);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", expectedMetricCollection.ToJson(), "}"))
            };

            RecordedDelegatingHandler handler = new RecordedDelegatingHandler(response);
            var insightsClient = GetInsightsClient(handler);

            var filterString = new Microsoft.Rest.Azure.OData.ODataQuery<Metric>("timeGrain eq duration'PT1M' and startTime eq 2014-01-01T06:00:00Z and endTime eq 2014-01-10T06:00:00Z");
            var actualMetrics = insightsClient.Metrics.ListAsync(resourceUri: ResourceUri, odataQuery: filterString, cancellationToken: CancellationToken.None).Result;

            AreEqual(expectedMetricCollection, actualMetrics.ToList<Metric>());
        }

        private IList<Metric> GetMetricCollection(string resourceId)
        {
            return new List<Metric>
            {
                new Metric
                {
                    Name = new LocalizableString {LocalizedValue = "CPU Percentage", Value = "CpuPercentage"},
                    Unit = Unit.Percent,
                    Data = new List<MetricValue>
                    {
                        new MetricValue
                        {
                            Average = 10.0,
                            Count = 1,
                            Maximum = 10.0,
                            Minimum = 10.0,
                            TimeStamp = DateTime.Parse("2014-08-20T12:15:23.00Z"),
                            Total = 10.0
                        }
                    }
                }
            };
        }

        private void AreEqual(IList<Metric> exp, IList<Metric> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private void AreEqual(Metric exp, Metric act)
        {
            if (exp != null)
            {
                AreEqual(exp.Name, act.Name);
                Assert.Equal(exp.Unit, act.Unit);

                if (exp.Data != null)
                {
                    for (int i = 0; i < exp.Data.Count; i++)
                    {
                        AreEqual(exp.Data[i], act.Data[i]);
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
                Assert.Equal(exp.Maximum, act.Maximum);
                Assert.Equal(exp.Minimum, act.Minimum);
                Assert.Equal(exp.TimeStamp.ToUniversalTime(), act.TimeStamp.ToUniversalTime());
                Assert.Equal(exp.Total, act.Total);
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
                AreEqual(exp.Name, act.Name);
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
                Unit = Unit.Bytes
            };
            return metricDefinitions;
        }

        #endregion
    }
}
