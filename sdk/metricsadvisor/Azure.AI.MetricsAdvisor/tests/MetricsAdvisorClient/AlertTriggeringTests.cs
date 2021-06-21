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
        public void GetAnomaliesForAlertValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetAnomaliesForAlertAsync(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesForAlertAsync("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomaliesForAlertAsync("configId", "alertId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAnomaliesForAlertAsync(FakeGuid, alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesForAlertAsync(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetAnomaliesForAlert(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesForAlert("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomaliesForAlert("configId", "alertId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetAnomaliesForAlert(FakeGuid, alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesForAlert(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetAnomaliesForAlertRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<DataPointAnomaly> asyncEnumerator = client.GetAnomaliesForAlertAsync(FakeGuid, "alertId", cancellationToken: cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<DataPointAnomaly> enumerator = client.GetAnomaliesForAlert(FakeGuid, "alertId", cancellationToken: cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetIncidentsForAlertValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetIncidentsForAlertAsync(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsForAlertAsync("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentsForAlertAsync("configId", "alertId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetIncidentsForAlertAsync(FakeGuid, alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsForAlertAsync(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetIncidentsForAlert(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsForAlert("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentsForAlert("configId", "alertId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => client.GetIncidentsForAlert(FakeGuid, alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsForAlert(FakeGuid, ""), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetIncidentsForAlertRespectsTheCancellationToken()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<AnomalyIncident> asyncEnumerator = client.GetIncidentsForAlertAsync(FakeGuid, "alertId", cancellationToken: cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<AnomalyIncident> enumerator = client.GetIncidentsForAlert(FakeGuid, "alertId", cancellationToken: cancellationSource.Token).GetEnumerator();
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
