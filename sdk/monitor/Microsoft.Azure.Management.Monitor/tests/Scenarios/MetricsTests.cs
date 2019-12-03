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
using Microsoft.Rest.Azure.OData;
using System;

namespace Monitor.Tests.Scenarios
{
    public class MetricsTests : TestBase
    {
        private const string ResourceGroupName = "Rac46PostSwapRG";
        private const string ResourceUriLegacy = "/subscriptions/{0}/resourceGroups/" + ResourceGroupName + "/providers/Microsoft.Web/sites/alertruleTest";

        // 56bb45c9-5c14-4914-885e-c6fd6f130f7c (Demo – Azure Monitoring) For multi-dim metrics
        private const string ResourceUri = "subscriptions/56bb45c9-5c14-4914-885e-c6fd6f130f7c/resourceGroups/contoso-data/providers/Microsoft.Storage/storageAccounts/contosodatadiag1";
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var insightsClient = GetMonitorManagementClient(context, handler);

                // ***** read definitions for single-dim metrics here

                // var filterString = new Microsoft.Rest.Azure.OData.ODataQuery<MetricDefinition>("name.value eq 'Requests'");
                var actualMetricDefinitions = insightsClient.MetricDefinitions.ListAsync(
                    resourceUri: string.Format(provider: CultureInfo.InvariantCulture, format: ResourceUriLegacy, args: insightsClient.SubscriptionId),
                    cancellationToken: new CancellationToken()).Result;

                if (!this.IsRecording)
                {
                    Check(actualMetricDefinitions.ToList());
                }

                // ***** read definitions for multi-dim metrics
                actualMetricDefinitions = insightsClient.MetricDefinitions.ListAsync(
                    resourceUri: ResourceUri,
                    cancellationToken: new CancellationToken()).Result;

                if (!this.IsRecording)
                {
                    Check(actualMetricDefinitions.ToList());
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetMetricsTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var insightsClient = GetMonitorManagementClient(context, handler);

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

                // Reading multi-dim metrics
                // https://management.azure.com/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/azmon-rest-api-walkthrough/providers/Microsoft.Storage/accounts/contosodiag1/providers/microsoft.insights/metrics?metric=Transactions&timespan=2017-09-19T02:00:00Z/2017-09-19T02:25:00Z&$filter=APIName eq 'GetBlobProperties'&interval=PT1M&aggregation=Count&api-version=2017-05-01-preview"
                string timeSpan = "2018-03-02T23:48:11Z/2018-03-03T00:18:11Z";
                ODataQuery<MetadataValue> filter = new ODataQuery<MetadataValue>("APIName eq 'GetBlobProperties'");

                // Read data
                actualMetrics = insightsClient.Metrics.List(
                    resourceUri: ResourceUri,
                    odataQuery: filter,
                    timespan: timeSpan,
                    interval: TimeSpan.FromMinutes(1),
                    metricnames: "Transactions",
                    aggregation: "Count",
                    resultType: ResultType.Data);

                if (!this.IsRecording)
                {
                    Check(actualMetrics, true);
                }

                // Read metadata
                // NOTICE the change in the filter. If '*' is not there the backend returns BadRequest
                filter = new ODataQuery<MetadataValue>("APIName eq '*'");
                actualMetrics = insightsClient.Metrics.List(
                    resourceUri: ResourceUri,
                    odataQuery: filter,
                    timespan: timeSpan,
                    interval: TimeSpan.FromMinutes(1),
                    metricnames: "Transactions",
                    aggregation: "Count",
                    resultType: ResultType.Metadata);

                if (!this.IsRecording)
                {
                    CheckMetadata(actualMetrics);
                }
            }
        }

        private void Check(Response act, bool multiDim = false)
        {
            if (act != null)
            {
                Assert.NotNull(act.Cost);
                Assert.NotNull(act.Timespan);
                Assert.NotNull(act.Interval);
                Assert.NotNull(act.Value);

                if (act.Value.Count > 0)
                {
                    var metric = act.Value[0];
                    Assert.False(string.IsNullOrWhiteSpace(metric.Id));
                    Assert.NotNull(metric.Name);
                    Assert.Equal("Microsoft.Insights/metrics", metric.Type);

                    Assert.NotNull(metric.Timeseries);
                    if (metric.Timeseries.Count > 0)
                    {
                        var timeSeries = metric.Timeseries[0];
                        Assert.NotNull(timeSeries.Metadatavalues);
                        Assert.True((multiDim && timeSeries.Metadatavalues.Count > 0) || (!multiDim && timeSeries.Metadatavalues.Count == 0));
                        Assert.NotNull(timeSeries.Data);
                    }
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private void CheckMetadata(Response act)
        {
            if (act != null)
            {
                Assert.Null(act.Cost);
                Assert.NotNull(act.Timespan);
                Assert.Null(act.Interval);
                Assert.NotNull(act.Value);

                if (act.Value.Count > 0)
                {
                    var metric = act.Value[0];
                    Assert.False(string.IsNullOrWhiteSpace(metric.Id));
                    Assert.NotNull(metric.Name);
                    Assert.Equal("Microsoft.Insights/metrics", metric.Type);

                    Assert.NotNull(metric.Timeseries);
                    if (metric.Timeseries.Count > 0)
                    {
                        var timeSeries = metric.Timeseries[0];
                        Assert.NotNull(timeSeries.Metadatavalues);
                        Assert.NotEmpty(timeSeries.Metadatavalues);
                        Assert.Null(timeSeries.Data);
                    }
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

                    Assert.NotNull(metricDef.PrimaryAggregationType);
                    Assert.NotNull(metricDef.Unit);
                    Assert.NotNull(metricDef.MetricAvailabilities);

                    // NOTE: Category is returned through the cable, but not deserialized!
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
