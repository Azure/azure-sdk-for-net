// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class AnomalyAlertConfigurationLiveTests : MetricsAdvisorLiveTestBase
    {
        public AnomalyAlertConfigurationLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateAndGetAlertConfiguration()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");

            var configToCreate = new AnomalyAlertConfiguration(configName, new List<string>(), new List<MetricAnomalyAlertConfiguration>());

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            AnomalyAlertConfiguration createdConfig = await adminClient.GetAlertConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.CrossMetricsOperator, Is.Null);
            Assert.That(createdConfig.IdsOfHooksToAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);

            var metricAlertConfig = createdConfig.MetricAlertConfigurations.Single();
        }
    }
}
