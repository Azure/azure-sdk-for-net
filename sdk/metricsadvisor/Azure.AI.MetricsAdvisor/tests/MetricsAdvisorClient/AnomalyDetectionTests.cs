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
    public class AnomalyDetectionTests : ClientTestBase
    {
        public AnomalyDetectionTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void GetAnomaliesForDetectionConfigurationValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAnomaliesForDetectionConfigurationOptions(default, default);

            Assert.That(() => client.GetAnomaliesForDetectionConfigurationAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesForDetectionConfigurationAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomaliesForDetectionConfigurationAsync("configId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAnomaliesForDetectionConfigurationAsync(FakeGuid, options: null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetAnomaliesForDetectionConfiguration(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesForDetectionConfiguration("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomaliesForDetectionConfiguration("configId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAnomaliesForDetectionConfiguration(FakeGuid, options: null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetAnomaliesForDetectionConfigurationRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAnomaliesForDetectionConfigurationOptions(default, default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<DataPointAnomaly> asyncEnumerator = client.GetAnomaliesForDetectionConfigurationAsync(FakeGuid, options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<DataPointAnomaly> enumerator = client.GetAnomaliesForDetectionConfiguration(FakeGuid, options, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetIncidentsForDetectionConfigurationValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetIncidentsForDetectionConfigurationOptions(default, default);

            Assert.That(() => client.GetIncidentsForDetectionConfigurationAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsForDetectionConfigurationAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentsForDetectionConfigurationAsync("configId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetIncidentsForDetectionConfigurationAsync(FakeGuid, options: null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetIncidentsForDetectionConfiguration(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsForDetectionConfiguration("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentsForDetectionConfiguration("configId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetIncidentsForDetectionConfiguration(FakeGuid, options: null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetIncidentsForDetectionConfigurationRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetIncidentsForDetectionConfigurationOptions(default, default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<AnomalyIncident> asyncEnumerator = client.GetIncidentsForDetectionConfigurationAsync(FakeGuid, options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<AnomalyIncident> enumerator = client.GetIncidentsForDetectionConfiguration(FakeGuid, options, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetIncidentRootCausesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetIncidentRootCausesAsync(null, "incidentId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentRootCausesAsync("", "incidentId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentRootCausesAsync("configId", "incidentId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetIncidentRootCausesAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentRootCausesAsync(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetIncidentRootCauses(null, "incidentId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentRootCauses("", "incidentId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentRootCauses("configId", "incidentId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetIncidentRootCauses(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentRootCauses(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetIncidentRootCausesRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetIncidentsForDetectionConfigurationOptions(default, default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<IncidentRootCause> asyncEnumerator = client.GetIncidentRootCausesAsync(FakeGuid, "incidentId", cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<IncidentRootCause> enumerator = client.GetIncidentRootCauses(FakeGuid, "incidentId", cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetIncidentRootCausesForIncidentValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetIncidentRootCausesAsync(null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetIncidentRootCauses(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetIncidentRootCausesForIncidentRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            // TODO: create AnomalyIncident using model factory instead. We're currently using an internal constructor.
            var seriesIdentity = new SeriesIdentity(new Dictionary<string, string>());
            var incidentProperty = new IncidentProperty(default, default, default);
            var incident = new AnomalyIncident(default, default, FakeGuid, "incidentId", default, default, seriesIdentity, incidentProperty);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<IncidentRootCause> asyncEnumerator = client.GetIncidentRootCausesAsync(incident, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<IncidentRootCause> enumerator = client.GetIncidentRootCauses(incident, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetAnomalyDimensionValuesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAnomalyDimensionValuesOptions(default, default);

            Assert.That(() => client.GetAnomalyDimensionValuesAsync(null, "dimensionName", options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomalyDimensionValuesAsync("", "dimensionName", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomalyDimensionValuesAsync("configId", "dimensionName", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAnomalyDimensionValuesAsync(FakeGuid, null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomalyDimensionValuesAsync(FakeGuid, "", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomalyDimensionValuesAsync(FakeGuid, "dimensionName", null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetAnomalyDimensionValues(null, "dimensionName", options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomalyDimensionValues("", "dimensionName", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomalyDimensionValues("configId", "dimensionName", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAnomalyDimensionValues(FakeGuid, null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomalyDimensionValues(FakeGuid, "", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomalyDimensionValues(FakeGuid, "dimensionName", null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetAnomalyDimensionValuesRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAnomalyDimensionValuesOptions(default, default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<string> asyncEnumerator = client.GetAnomalyDimensionValuesAsync(FakeGuid, "dimensionName", options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<string> enumerator = client.GetAnomalyDimensionValues(FakeGuid, "dimensionName", options, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetMetricEnrichedSeriesDataValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var emptyList = new List<DimensionKey>();
            var seriesKeys = new List<DimensionKey>() { new DimensionKey() };

            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(FakeGuid, null, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(FakeGuid, emptyList, default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(null, seriesKeys, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync("", seriesKeys, default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync("configId", seriesKeys, default, default), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => client.GetMetricEnrichedSeriesData(FakeGuid, null, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData(FakeGuid, emptyList, default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData(null, seriesKeys, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData("", seriesKeys, default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData("configId", seriesKeys, default, default), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetMetricEnrichedSeriesDataRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var emptyList = new List<DimensionKey>();
            var seriesKeys = new List<DimensionKey>() { new DimensionKey() };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<MetricEnrichedSeriesData> asyncEnumerator = client.GetMetricEnrichedSeriesDataAsync(FakeGuid, seriesKeys, default, default, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<MetricEnrichedSeriesData> enumerator = client.GetMetricEnrichedSeriesData(FakeGuid, seriesKeys, default, default, cancellationSource.Token).GetEnumerator();
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
