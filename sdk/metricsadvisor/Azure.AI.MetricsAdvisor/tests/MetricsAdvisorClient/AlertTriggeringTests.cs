// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

        [Test]
        public void GetAlertsValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAlertsOptions(default, default, AlertQueryTimeMode.AnomalyTime);

            Assert.That(() => client.GetAlertsAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAlertsAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAlertsAsync("configId", null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetAlerts(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAlerts("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAlerts("configId", null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetAnomaliesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetAnomaliesAsync(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesAsync("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomaliesAsync("configId", alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesAsync("configId", ""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetAnomalies(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomalies("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomalies("configId", alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomalies("configId", ""), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetIncidentsValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetIncidentsAsync(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsAsync("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentsAsync("configId", alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsAsync("configId", ""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetIncidents(null, "alertId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidents("", "alertId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidents("configId", alertId: null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidents("configId", ""), Throws.InstanceOf<ArgumentException>());
        }

        private MetricsAdvisorClient GetMetricsAdvisorClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorClient(fakeEndpoint, fakeCredential);
        }
    }
}
