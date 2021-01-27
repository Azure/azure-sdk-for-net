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
    public class AlertTriggeringTests : ClientTestBase
    {
        public AlertTriggeringTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void GetAlertsValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAlertsOptions(default, default, AlertQueryTimeMode.AnomalyTime);

            Assert.That(() => client.GetAlertsAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAlertsAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAlertsAsync("configId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAlertsAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetAlerts(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAlerts("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAlerts("configId", options), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAlerts(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetAlertsRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAlertsOptions(default, default, AlertQueryTimeMode.AnomalyTime);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<AnomalyAlert> asyncEnumerator = client.GetAlertsAsync(FakeGuid, options, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<AnomalyAlert> enumerator = client.GetAlerts(FakeGuid, options, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetAnomaliesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetAnomaliesAsync(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesAsync("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomaliesAsync("configId", "alertId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAnomaliesAsync(FakeGuid, alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesAsync(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetAnomalies(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomalies("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomalies("configId", "alertId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAnomalies(FakeGuid, alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomalies(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetAnomaliesRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<DataPointAnomaly> asyncEnumerator = client.GetAnomaliesAsync(FakeGuid, "alertId", cancellationToken: cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<DataPointAnomaly> enumerator = client.GetAnomalies(FakeGuid, "alertId", cancellationToken: cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetIncidentsValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetIncidentsAsync(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsAsync("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentsAsync("configId", "alertId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetIncidentsAsync(FakeGuid, alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsAsync(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetIncidents(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidents("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidents("configId", "alertId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetIncidents(FakeGuid, alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidents(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetIncidentsRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<AnomalyIncident> asyncEnumerator = client.GetIncidentsAsync(FakeGuid, "alertId", cancellationToken: cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<AnomalyIncident> enumerator = client.GetIncidents(FakeGuid, "alertId", cancellationToken: cancellationSource.Token).GetEnumerator();
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
