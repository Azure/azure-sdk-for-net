// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class TimeSeriesTests : ClientTestBase
    {
        public TimeSeriesTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void GetDimensionValuesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetDimensionValuesAsync(null, "dimensionName"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetDimensionValuesAsync("", "dimensionName"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetDimensionValuesAsync("metricId", "dimensionName"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetDimensionValuesAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetDimensionValuesAsync(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetDimensionValues(null, "dimensionName"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetDimensionValues("", "dimensionName"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetDimensionValues("metricId", "dimensionName"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetDimensionValues(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetDimensionValues(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetDimensionValuesRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<string> asyncEnumerator = client.GetDimensionValuesAsync(FakeGuid, "dimensionName", cancellationToken: cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<string> enumerator = client.GetDimensionValues(FakeGuid, "dimensionName", cancellationToken: cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetMetricSeriesDefinitionsValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetMetricSeriesDefinitionsOptions(default);

            Assert.That(() => client.GetMetricSeriesDefinitionsAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricSeriesDefinitionsAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricSeriesDefinitionsAsync("metricId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetMetricSeriesDefinitionsAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetMetricSeriesDefinitions(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricSeriesDefinitions("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricSeriesDefinitions("metricId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetMetricSeriesDefinitions(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetMetricSeriesDefinitionsRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetMetricSeriesDefinitionsOptions(default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<MetricSeriesDefinition> asyncEnumerator = client.GetMetricSeriesDefinitionsAsync(FakeGuid, options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<MetricSeriesDefinition> enumerator = client.GetMetricSeriesDefinitions(FakeGuid, options, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetMetricSeriesDataValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var seriesToFilter = new List<DimensionKey>();
            var options = new GetMetricSeriesDataOptions(seriesToFilter, default, default);

            Assert.That(() => client.GetMetricSeriesDataAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricSeriesDataAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricSeriesDataAsync("metricId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetMetricSeriesDataAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetMetricSeriesData(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricSeriesData("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricSeriesData("metricId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetMetricSeriesData(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetMetricSeriesDataRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var seriesToFilter = new List<DimensionKey>();
            var options = new GetMetricSeriesDataOptions(seriesToFilter, default, default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<MetricSeriesData> asyncEnumerator = client.GetMetricSeriesDataAsync(FakeGuid, options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<MetricSeriesData> enumerator = client.GetMetricSeriesData(FakeGuid, options, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetMetricEnrichmentStatusesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetMetricEnrichmentStatusesOptions(default, default);

            Assert.That(() => client.GetMetricEnrichmentStatusesAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichmentStatusesAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichmentStatusesAsync("metricId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetMetricEnrichmentStatusesAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetMetricEnrichmentStatuses(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichmentStatuses("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichmentStatuses("metricId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetMetricEnrichmentStatuses(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetMetricEnrichmentStatusesRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetMetricEnrichmentStatusesOptions(default, default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<EnrichmentStatus> asyncEnumerator = client.GetMetricEnrichmentStatusesAsync(FakeGuid, options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<EnrichmentStatus> enumerator = client.GetMetricEnrichmentStatuses(FakeGuid, options, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        private MetricsAdvisorClient GetMetricsAdvisorClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorClient(fakeEndpoint, fakeCredential);
        }
    }
}
