// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class AnomalyDetectionConfigurationLiveTests : MetricsAdvisorLiveTestBase
    {
        public AnomalyDetectionConfigurationLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateAndGetDetectionConfigurationWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");

            var suppressCondition = new SuppressCondition(1, 1.0);
            var wholeCondition = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = new HardThresholdCondition(AnomalyDetectorDirection.Up, suppressCondition)
                {
                    UpperBound = 10.0
                }
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeCondition);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            AnomalyDetectionConfiguration createdConfig = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.MetricId, Is.EqualTo(MetricId));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
        }

        [RecordedTest]
        public async Task DeleteDetectionConfiguration()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");

            var suppressCondition = new SuppressCondition(1, 1.0);
            var wholeCondition = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = new HardThresholdCondition(AnomalyDetectorDirection.Up, suppressCondition)
                {
                    UpperBound = 10.0
                }
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeCondition);

            string configId = null;

            try
            {
                configId = await adminClient.CreateDetectionConfigurationAsync(configToCreate);

                Assert.That(configId, Is.Not.Null.And.Not.Empty);
            }
            finally
            {
                if (configId != null)
                {
                    await adminClient.DeleteDetectionConfigurationAsync(configId);

                    Assert.That(async () => await adminClient.GetDetectionConfigurationAsync(configId), Throws.InstanceOf<RequestFailedException>());
                }
            }
        }
    }
}
