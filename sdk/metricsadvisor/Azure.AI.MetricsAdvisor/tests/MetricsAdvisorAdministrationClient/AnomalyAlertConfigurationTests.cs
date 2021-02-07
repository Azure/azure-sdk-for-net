// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class AnomalyAlertConfigurationTests : ClientTestBase
    {
        public AnomalyAlertConfigurationTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void CreateAlertConfigurationValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.CreateAlertConfigurationAsync(null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => adminClient.CreateAlertConfiguration(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CreateAlertConfigurationRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var metricConfigs = new List<MetricAnomalyAlertConfiguration>()
            {
                new MetricAnomalyAlertConfiguration(FakeGuid, MetricAnomalyAlertScope.GetScopeForWholeSeries())
            };
            var config = new AnomalyAlertConfiguration("configName", new List<string>(), metricConfigs);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.CreateAlertConfigurationAsync(config, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.CreateAlertConfiguration(config, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void UpdateAlertConfigurationValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var metricConfigs = new List<MetricAnomalyAlertConfiguration>()
            {
                new MetricAnomalyAlertConfiguration(FakeGuid, MetricAnomalyAlertScope.GetScopeForWholeSeries())
            };
            var config = new AnomalyAlertConfiguration("configName", new List<string>(), metricConfigs);

            Assert.That(() => adminClient.UpdateAlertConfigurationAsync(null, config), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateAlertConfigurationAsync("", config), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.UpdateAlertConfigurationAsync("configId", config), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => adminClient.UpdateAlertConfigurationAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => adminClient.UpdateAlertConfiguration(null, config), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateAlertConfiguration("", config), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.UpdateAlertConfiguration("configId", config), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => adminClient.UpdateAlertConfiguration(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void UpdateAlertConfigurationRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var metricConfigs = new List<MetricAnomalyAlertConfiguration>()
            {
                new MetricAnomalyAlertConfiguration(FakeGuid, MetricAnomalyAlertScope.GetScopeForWholeSeries())
            };
            var config = new AnomalyAlertConfiguration("configName", new List<string>(), metricConfigs);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.UpdateAlertConfigurationAsync(FakeGuid, config, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.UpdateAlertConfiguration(FakeGuid, config, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetAlertConfigurationValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.GetAlertConfigurationAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetAlertConfigurationAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetAlertConfigurationAsync("configId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.GetAlertConfiguration(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetAlertConfiguration(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetAlertConfiguration("configId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetAlertConfigurationRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.GetAlertConfigurationAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.GetAlertConfiguration(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetAlertConfigurationsValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.GetAlertConfigurationsAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetAlertConfigurationsAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetAlertConfigurationsAsync("metricId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.GetAlertConfigurations(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetAlertConfigurations(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetAlertConfigurations("metricId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetAlertConfigurationsRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<AnomalyAlertConfiguration> asyncEnumerator = adminClient.GetAlertConfigurationsAsync(FakeGuid, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<AnomalyAlertConfiguration> enumerator = adminClient.GetAlertConfigurations(FakeGuid, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void DeleteAlertConfigurationValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.DeleteAlertConfigurationAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteAlertConfigurationAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteAlertConfigurationAsync("configId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.DeleteAlertConfiguration(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteAlertConfiguration(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteAlertConfiguration("configId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void DeleteAlertConfigurationRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.DeleteAlertConfigurationAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.DeleteAlertConfiguration(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        private MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorAdministrationClient(fakeEndpoint, fakeCredential);
        }
    }
}
