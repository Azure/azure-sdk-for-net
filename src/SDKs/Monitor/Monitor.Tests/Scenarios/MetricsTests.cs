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
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Monitor.Tests.Scenarios
{
    public class MetricsTests : TestBase
    {
        private const string ResourceUri = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/Microsoft.Web/sites/alertruleTest";
        private RecordedDelegatingHandler handler;

        public MetricsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetMetricDefinitionsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var insightsClient = GetMonitorClient(context, handler);

                var filterString = new Microsoft.Rest.Azure.OData.ODataQuery<MetricDefinition>("name.value eq 'Requests'");
                var actualMetricDefinitions = insightsClient.MetricDefinitions.ListAsync(
                    resourceUri: ResourceUri,
                    odataQuery: filterString,
                    cancellationToken: new CancellationToken()).Result;

                if (!this.IsRecording)
                {
                    Check(actualMetricDefinitions.ToList<MetricDefinition>());
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetMetricsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var insightsClient = GetMonitorClient(context, handler);

                var filterString = new Microsoft.Rest.Azure.OData.ODataQuery<Metric>("(name.value eq 'Requests') and timeGrain eq duration'PT1M' and startTime eq 2017-08-01T06:00:00Z and endTime eq 2017-08-02T23:00:00Z");
                var actualMetrics = insightsClient.Metrics.ListAsync(
                    resourceUri: ResourceUri,
                    odataQuery: filterString,
                    cancellationToken: CancellationToken.None).Result;

                if (!this.IsRecording)
                {
                    Check(actualMetrics.ToList<Metric>());
                }
            }
        }

        private void Check(IList<Metric> act)
        {
            if (act != null)
            {
                if (act.Count > 0)
                {
                    var metric = act[0];
                    Assert.False(string.IsNullOrWhiteSpace(metric.Id));
                    Assert.NotNull(metric.Name);
                    Assert.False(string.IsNullOrWhiteSpace(metric.Type));
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        #region MetricDefinition helpers

        private static void Check(IList<MetricDefinition> act)
        {
            if (act != null)
            {
                if (act.Count > 0)
                {
                    var metricDef = act[0];
                    Assert.False(string.IsNullOrWhiteSpace(metricDef.Id));
                    Assert.NotNull(metricDef.Name);
                    Assert.False(string.IsNullOrWhiteSpace(metricDef.ResourceId));
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        #endregion
    }
}
