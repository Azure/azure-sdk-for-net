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
    public class AnomalyDetectionConfigurationTests : ClientTestBase
    {
        public AnomalyDetectionConfigurationTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void CreateDetectionConfigurationValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.CreateDetectionConfigurationAsync(null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => adminClient.CreateDetectionConfiguration(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CreateDetectionConfigurationRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var config = new AnomalyDetectionConfiguration(FakeGuid, "configName", new ());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.CreateDetectionConfigurationAsync(config, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.CreateDetectionConfiguration(config, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void UpdateDetectionConfigurationValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var config = new AnomalyDetectionConfiguration(FakeGuid, "configName", new ());

            Assert.That(() => adminClient.UpdateDetectionConfigurationAsync(null, config), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateDetectionConfigurationAsync("", config), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.UpdateDetectionConfigurationAsync("configId", config), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => adminClient.UpdateDetectionConfigurationAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => adminClient.UpdateDetectionConfiguration(null, config), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateDetectionConfiguration("", config), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.UpdateDetectionConfiguration("configId", config), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => adminClient.UpdateDetectionConfiguration(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void UpdateDetectionConfigurationRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var config = new AnomalyDetectionConfiguration(FakeGuid, "configName", new ());

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.UpdateDetectionConfigurationAsync(FakeGuid, config, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.UpdateDetectionConfiguration(FakeGuid, config, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetDetectionConfigurationValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.GetDetectionConfigurationAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDetectionConfigurationAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDetectionConfigurationAsync("configId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.GetDetectionConfiguration(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDetectionConfiguration(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDetectionConfiguration("configId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetDetectionConfigurationRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.GetDetectionConfigurationAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.GetDetectionConfiguration(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetDetectionConfigurationsValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.GetDetectionConfigurationsAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDetectionConfigurationsAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDetectionConfigurationsAsync("metricId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.GetDetectionConfigurations(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDetectionConfigurations(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDetectionConfigurations("metricId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetDetectionConfigurationsRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<AnomalyDetectionConfiguration> asyncEnumerator = adminClient.GetDetectionConfigurationsAsync(FakeGuid, cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<AnomalyDetectionConfiguration> enumerator = adminClient.GetDetectionConfigurations(FakeGuid, cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void DeleteDetectionConfigurationValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.DeleteDetectionConfigurationAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteDetectionConfigurationAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteDetectionConfigurationAsync("configId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.DeleteDetectionConfiguration(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteDetectionConfiguration(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteDetectionConfiguration("configId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void DeleteDetectionConfigurationRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.DeleteDetectionConfigurationAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.DeleteDetectionConfiguration(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        private MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorAdministrationClient(fakeEndpoint, fakeCredential);
        }
    }
}
