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
        public void GetAnomaliesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAnomaliesForDetectionConfigurationOptions(default, default);

            Assert.That(() => client.GetAnomaliesAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomaliesAsync("configId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAnomaliesAsync(FakeGuid, options: null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetAnomalies(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomalies("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomalies("configId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAnomalies(FakeGuid, options: null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetAnomaliesRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAnomaliesForDetectionConfigurationOptions(default, default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<DataPointAnomaly> asyncEnumerator = client.GetAnomaliesAsync(FakeGuid, options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<DataPointAnomaly> enumerator = client.GetAnomalies(FakeGuid, options, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetIncidentsValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetIncidentsForDetectionConfigurationOptions(default, default);

            Assert.That(() => client.GetIncidentsAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentsAsync("configId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetIncidentsAsync(FakeGuid, options: null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetIncidents(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidents("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidents("configId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetIncidents(FakeGuid, options: null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetIncidentsRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetIncidentsForDetectionConfigurationOptions(default, default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<AnomalyIncident> asyncEnumerator = client.GetIncidentsAsync(FakeGuid, options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<AnomalyIncident> enumerator = client.GetIncidents(FakeGuid, options, cancellationSource.Token).GetEnumerator();
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
            var incidentProperty = new IncidentProperty(default, default);
            var incident = new AnomalyIncident(default, FakeGuid, "incidentId", default, default, seriesIdentity, incidentProperty);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<IncidentRootCause> asyncEnumerator = client.GetIncidentRootCausesAsync(incident, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<IncidentRootCause> enumerator = client.GetIncidentRootCauses(incident, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetValuesOfDimensionsWithAnomaliesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetValuesOfDimensionWithAnomaliesOptions(default, default);

            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync(null, "dimensionName", options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync("", "dimensionName", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync("configId", "dimensionName", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync(FakeGuid, null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync(FakeGuid, "", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync(FakeGuid, "dimensionName", null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetValuesOfDimensionWithAnomalies(null, "dimensionName", options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomalies("", "dimensionName", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomalies("configId", "dimensionName", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetValuesOfDimensionWithAnomalies(FakeGuid, null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomalies(FakeGuid, "", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomalies(FakeGuid, "dimensionName", null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetValuesOfDimensionWithAnomaliesRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetValuesOfDimensionWithAnomaliesOptions(default, default);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<string> asyncEnumerator = client.GetValuesOfDimensionWithAnomaliesAsync(FakeGuid, "dimensionName", options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<string> enumerator = client.GetValuesOfDimensionWithAnomalies(FakeGuid, "dimensionName", options, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetMetricEnrichedSeriesDataValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var emptyList = new List<DimensionKey>();
            var seriesKeys = new List<DimensionKey>() { new DimensionKey() };

            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(null, FakeGuid, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(emptyList, FakeGuid, default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(seriesKeys, null, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(seriesKeys, "", default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(seriesKeys, "configId", default, default), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => client.GetMetricEnrichedSeriesData(null, FakeGuid, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData(emptyList, FakeGuid, default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData(seriesKeys, null, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData(seriesKeys, "", default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData(seriesKeys, "configId", default, default), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetMetricEnrichedSeriesDataRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var emptyList = new List<DimensionKey>();
            var seriesKeys = new List<DimensionKey>() { new DimensionKey() };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<MetricEnrichedSeriesData> asyncEnumerator = client.GetMetricEnrichedSeriesDataAsync(seriesKeys, FakeGuid, default, default, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<MetricEnrichedSeriesData> enumerator = client.GetMetricEnrichedSeriesData(seriesKeys, FakeGuid, default, default, cancellationSource.Token).GetEnumerator();
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
