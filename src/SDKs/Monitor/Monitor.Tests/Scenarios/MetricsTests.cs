// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Globalization;

namespace Monitor.Tests.Scenarios
{
    public class MetricsTests : TestBase
    {
        private const string ResourceGroupName = "Rac46PostSwapRG";
        private const string ResourceUriLegacy = "/subscriptions/{0}/resourceGroups/" + ResourceGroupName + "/providers/Microsoft.Web/sites/alertruleTest";
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

                // ***** read definitions for single-dim metrics here

                // var filterString = new Microsoft.Rest.Azure.OData.ODataQuery<MetricDefinition>("name.value eq 'Requests'");
                var actualMetricDefinitions = insightsClient.MetricDefinitions.ListAsync(
                    resourceUri: string.Format(provider: CultureInfo.InvariantCulture, format: ResourceUriLegacy, args: insightsClient.SubscriptionId),
                    cancellationToken: new CancellationToken()).Result;

                if (!this.IsRecording)
                {
                    Check(actualMetricDefinitions.ToList());
                }

                // ***** read definitions for multi-dim metrics here
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetMetricsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var insightsClient = GetMonitorClient(context, handler);

                // **** First reading metrics from the old API

                // TODO: run one with a filter and other parameters
                // var filterString = new Microsoft.Rest.Azure.OData.ODataQuery<MetadataValue>("(name.value eq 'Requests') and timeGrain eq duration'PT1M' and startTime eq 2017-08-01T06:00:00Z and endTime eq 2017-08-02T23:00:00Z");
                var actualMetrics = insightsClient.Metrics.List(
                    resourceUri: string.Format(provider: CultureInfo.InvariantCulture, format: ResourceUriLegacy, args: insightsClient.SubscriptionId));

                if (!this.IsRecording)
                {
                    Check(actualMetrics);
                }

                // Get metadata only
                // TODO: fails with BadRequest saying that at least one dimension should be set
                actualMetrics = null;
                Assert.Throws<ErrorResponseException>(
                    () => actualMetrics = insightsClient.Metrics.List(
                        resourceUri: string.Format(provider: CultureInfo.InvariantCulture, format: ResourceUriLegacy, args: insightsClient.SubscriptionId),
                        resultType: ResultType.Metadata));

                if (!this.IsRecording && actualMetrics != null)
                {
                    Check(actualMetrics);
                }

                // TODO: read multi-dim metrics here
            }
        }

        private void Check(Response act)
        {
            if (act != null)
            {
                Assert.NotNull(act.Timespan);
                Assert.NotNull(act.Value);

                if (act.Value.Count > 0)
                {
                    var metric = act.Value[0];
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
