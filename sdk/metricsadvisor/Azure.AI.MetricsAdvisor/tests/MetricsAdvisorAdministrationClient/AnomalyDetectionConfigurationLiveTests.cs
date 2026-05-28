// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task CreateAndGetDetectionConfigurationWithHardCondition(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            var description = "This configuration was created to test the .NET client.";

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = new(AnomalyDetectorDirection.Up, new(1, 2.0))
                {
                    UpperBound = 10.0
                }
            };

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = wholeConditions,
                // This is the only test that validates description during creation. Please don't remove it!
                Description = description
            };

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            AnomalyDetectionConfiguration createdConfig = disposableConfig.Configuration;

            Assert.That(createdConfig.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdConfig.MetricId, Is.EqualTo(metricId));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.EqualTo(description));
            Assert.That(createdConfig.SeriesGroupDetectionConditions, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.SeriesDetectionConditions, Is.Not.Null.And.Empty);

            MetricWholeSeriesDetectionCondition createdWholeConditions = createdConfig.WholeSeriesDetectionConditions;

            Assert.That(createdWholeConditions, Is.Not.Null);
            Assert.That(createdWholeConditions.ConditionOperator, Is.Null);
            Assert.That(createdWholeConditions.ChangeThresholdCondition, Is.Null);
            Assert.That(createdWholeConditions.SmartDetectionCondition, Is.Null);

            ValidateHardThresholdCondition(createdWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Up, 10.0, null, 1, 2.0);
        }

        [RecordedTest]
        public async Task CreateAndGetDetectionConfigurationWithChangeAndSmartConditions()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                ConditionOperator = DetectionConditionOperator.And,
                ChangeThresholdCondition = new(90.0, 5, true, AnomalyDetectorDirection.Both, new(1, 2.0)),
                SmartDetectionCondition = new(23.0, AnomalyDetectorDirection.Down, new(3, 4.0))
            };

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = wholeConditions
            };

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            AnomalyDetectionConfiguration createdConfig = disposableConfig.Configuration;

            Assert.That(createdConfig.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdConfig.MetricId, Is.EqualTo(metricId));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.SeriesGroupDetectionConditions, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.SeriesDetectionConditions, Is.Not.Null.And.Empty);

            MetricWholeSeriesDetectionCondition createdWholeConditions = createdConfig.WholeSeriesDetectionConditions;

            Assert.That(createdWholeConditions, Is.Not.Null);
            Assert.That(createdWholeConditions.ConditionOperator, Is.EqualTo(DetectionConditionOperator.And));
            Assert.That(createdWholeConditions.HardThresholdCondition, Is.Null);

            ValidateChangeThresholdCondition(createdWholeConditions.ChangeThresholdCondition, 90.0, 5, true, AnomalyDetectorDirection.Both, 1, 2.0);
            ValidateSmartDetectionCondition(createdWholeConditions.SmartDetectionCondition, 23.0, AnomalyDetectorDirection.Down, 3, 4.0);
        }

        [RecordedTest]
        public async Task CreateAndGetDetectionConfigurationWithSeriesGroupConditions()
        {
            // Set required parameters of the configuration to be created.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = new(AnomalyDetectorDirection.Down, new(1, 2.0))
                {
                    LowerBound = 10.0
                }
            };

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = wholeConditions
            };

            // Set the series group conditions and create the configuration.

            var dimensions = new Dictionary<string, string>() { { TempDataFeedDimensionNameA, "Delhi" } };
            var groupConditions0 = new MetricSeriesGroupDetectionCondition(new DimensionKey(dimensions))
            {
                SmartDetectionCondition = new(30.0, AnomalyDetectorDirection.Both, new(3, 4.0))
            };

            dimensions = new Dictionary<string, string>() { { TempDataFeedDimensionNameA, "Kolkata" } };
            var groupConditions1 = new MetricSeriesGroupDetectionCondition(new DimensionKey(dimensions))
            {
                ChangeThresholdCondition = new(40.0, 12, false, AnomalyDetectorDirection.Up, new(5, 6.0))
            };

            configToCreate.SeriesGroupDetectionConditions.Add(groupConditions0);
            configToCreate.SeriesGroupDetectionConditions.Add(groupConditions1);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            // Get the created configuration and validate top-level members.

            AnomalyDetectionConfiguration createdConfig = disposableConfig.Configuration;

            Assert.That(createdConfig.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdConfig.MetricId, Is.EqualTo(metricId));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.SeriesDetectionConditions, Is.Not.Null.And.Empty);

            // Validate whole series detection conditions.

            MetricWholeSeriesDetectionCondition createdWholeConditions = createdConfig.WholeSeriesDetectionConditions;

            Assert.That(createdWholeConditions, Is.Not.Null);
            Assert.That(createdWholeConditions.ConditionOperator, Is.Null);
            Assert.That(createdWholeConditions.ChangeThresholdCondition, Is.Null);
            Assert.That(createdWholeConditions.SmartDetectionCondition, Is.Null);

            ValidateHardThresholdCondition(createdWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Down, null, 10.0, 1, 2.0);

            // Start series group conditions validation.

            Assert.That(createdConfig.SeriesGroupDetectionConditions, Is.Not.Null);
            Assert.That(createdConfig.SeriesGroupDetectionConditions.Count, Is.EqualTo(2));

            // Validate first series group conditions.

            var createdGroupConditions0 = createdConfig.SeriesGroupDetectionConditions[0];

            Assert.That(createdGroupConditions0, Is.Not.Null);

            ValidateTempDataFeedDimensionKey(createdGroupConditions0.SeriesGroupKey, "Delhi");

            Assert.That(createdGroupConditions0.ConditionOperator, Is.Null);
            Assert.That(createdGroupConditions0.HardThresholdCondition, Is.Null);
            Assert.That(createdGroupConditions0.ChangeThresholdCondition, Is.Null);

            ValidateSmartDetectionCondition(createdGroupConditions0.SmartDetectionCondition, 30.0, AnomalyDetectorDirection.Both, 3, 4.0);

            // Validate last series group conditions.

            var createdGroupConditions1 = createdConfig.SeriesGroupDetectionConditions[1];

            Assert.That(createdGroupConditions1, Is.Not.Null);

            ValidateTempDataFeedDimensionKey(createdGroupConditions1.SeriesGroupKey, "Kolkata");

            Assert.That(createdGroupConditions1.ConditionOperator, Is.Null);
            Assert.That(createdGroupConditions1.HardThresholdCondition, Is.Null);
            Assert.That(createdGroupConditions1.SmartDetectionCondition, Is.Null);

            ValidateChangeThresholdCondition(createdGroupConditions1.ChangeThresholdCondition, 40.0, 12, false, AnomalyDetectorDirection.Up, 5, 6.0);
        }

        [RecordedTest]
        public async Task CreateAndGetDetectionConfigurationWithSeriesConditions()
        {
            // Set required parameters of the configuration to be created.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = new(AnomalyDetectorDirection.Both, new(1, 2.0))
                {
                    UpperBound = 20.0,
                    LowerBound = 10.0
                }
            };

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = wholeConditions
            };

            // Set the series conditions and create the configuration.

            var dimensions = new Dictionary<string, string>() { { TempDataFeedDimensionNameA, "Delhi" }, { TempDataFeedDimensionNameB, "Handmade" } };
            var seriesConditions0 = new MetricSingleSeriesDetectionCondition(new DimensionKey(dimensions))
            {
                SmartDetectionCondition = new(30.0, AnomalyDetectorDirection.Both, new(3, 4.0))
            };

            dimensions = new Dictionary<string, string>() { { TempDataFeedDimensionNameA, "Kolkata" }, { TempDataFeedDimensionNameB, "Grocery & Gourmet Food" } };
            var seriesConditions1 = new MetricSingleSeriesDetectionCondition(new DimensionKey(dimensions))
            {
                ChangeThresholdCondition = new(40.0, 12, false, AnomalyDetectorDirection.Up, new(5, 6.0))
            };

            configToCreate.SeriesDetectionConditions.Add(seriesConditions0);
            configToCreate.SeriesDetectionConditions.Add(seriesConditions1);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            // Get the created configuration and validate top-level members.

            AnomalyDetectionConfiguration createdConfig = disposableConfig.Configuration;

            Assert.That(createdConfig.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdConfig.MetricId, Is.EqualTo(metricId));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.SeriesGroupDetectionConditions, Is.Not.Null.And.Empty);

            // Validate whole series detection conditions.

            MetricWholeSeriesDetectionCondition createdWholeConditions = createdConfig.WholeSeriesDetectionConditions;

            Assert.That(createdWholeConditions, Is.Not.Null);
            Assert.That(createdWholeConditions.ConditionOperator, Is.Null);
            Assert.That(createdWholeConditions.ChangeThresholdCondition, Is.Null);
            Assert.That(createdWholeConditions.SmartDetectionCondition, Is.Null);

            ValidateHardThresholdCondition(createdWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Both, 20.0, 10.0, 1, 2.0);

            // Start series conditions validation.

            Assert.That(createdConfig.SeriesDetectionConditions, Is.Not.Null);
            Assert.That(createdConfig.SeriesDetectionConditions.Count, Is.EqualTo(2));

            // Validate first series conditions.

            var createdSeriesConditions0 = createdConfig.SeriesDetectionConditions[0];

            Assert.That(createdSeriesConditions0, Is.Not.Null);

            ValidateTempDataFeedDimensionKey(createdSeriesConditions0.SeriesKey, "Delhi", "Handmade");

            Assert.That(createdSeriesConditions0.ConditionOperator, Is.Null);
            Assert.That(createdSeriesConditions0.HardThresholdCondition, Is.Null);
            Assert.That(createdSeriesConditions0.ChangeThresholdCondition, Is.Null);

            ValidateSmartDetectionCondition(createdSeriesConditions0.SmartDetectionCondition, 30.0, AnomalyDetectorDirection.Both, 3, 4.0);

            // Validate last series conditions.

            var createdSeriesConditions1 = createdConfig.SeriesDetectionConditions[1];

            Assert.That(createdSeriesConditions1, Is.Not.Null);

            ValidateTempDataFeedDimensionKey(createdSeriesConditions1.SeriesKey, "Kolkata", "Grocery & Gourmet Food");

            Assert.That(createdSeriesConditions1.ConditionOperator, Is.Null);
            Assert.That(createdSeriesConditions1.HardThresholdCondition, Is.Null);
            Assert.That(createdSeriesConditions1.SmartDetectionCondition, Is.Null);

            ValidateChangeThresholdCondition(createdSeriesConditions1.ChangeThresholdCondition, 40.0, 12, false, AnomalyDetectorDirection.Up, 5, 6.0);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateDetectionConfigurationWithMinimumSetup(bool useTokenCredential)
        {
            // Set required parameters of the configuration to be created.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                ConditionOperator = DetectionConditionOperator.Or,
                HardThresholdCondition = new(AnomalyDetectorDirection.Down, new(1, 2.0))
                {
                    LowerBound = 10.0
                },
                SmartDetectionCondition = new(60.0, AnomalyDetectorDirection.Up, new(5, 6.0))
            };

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = wholeConditions
            };

            // Set the series group conditions.

            var dimensions = new Dictionary<string, string>() { { TempDataFeedDimensionNameA, "Kolkata" } };
            var groupConditions = new MetricSeriesGroupDetectionCondition(new DimensionKey(dimensions))
            {
                ChangeThresholdCondition = new(40.0, 12, false, AnomalyDetectorDirection.Up, new(5, 6.0))
            };

            configToCreate.SeriesGroupDetectionConditions.Add(groupConditions);

            // Set the series conditions and create the configuration.

            dimensions = new Dictionary<string, string>() { { TempDataFeedDimensionNameA, "Delhi" }, { TempDataFeedDimensionNameB, "Handmade" } };
            var seriesConditions = new MetricSingleSeriesDetectionCondition(new DimensionKey(dimensions))
            {
                SmartDetectionCondition = new(30.0, AnomalyDetectorDirection.Both, new(3, 4.0))
            };

            configToCreate.SeriesDetectionConditions.Add(seriesConditions);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            // Update the created configuration.

            AnomalyDetectionConfiguration configToUpdate = disposableConfig.Configuration;

            configToUpdate.WholeSeriesDetectionConditions.HardThresholdCondition.LowerBound = 12.0;

            AnomalyDetectionConfiguration updatedConfig = await adminClient.UpdateDetectionConfigurationAsync(configToUpdate);

            // Validate top-level members.

            Assert.That(updatedConfig.Id, Is.EqualTo(configToUpdate.Id));
            Assert.That(updatedConfig.MetricId, Is.EqualTo(metricId));
            Assert.That(updatedConfig.Name, Is.EqualTo(configName));
            Assert.That(updatedConfig.Description, Is.Empty);

            // Validate whole series detection conditions.

            MetricWholeSeriesDetectionCondition updatedWholeConditions = updatedConfig.WholeSeriesDetectionConditions;

            Assert.That(updatedWholeConditions, Is.Not.Null);
            Assert.That(updatedWholeConditions.ConditionOperator, Is.EqualTo(DetectionConditionOperator.Or));
            Assert.That(updatedWholeConditions.ChangeThresholdCondition, Is.Null);

            ValidateHardThresholdCondition(updatedWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Down, null, 12.0, 1, 2.0);
            ValidateSmartDetectionCondition(updatedWholeConditions.SmartDetectionCondition, 60.0, AnomalyDetectorDirection.Up, 5, 6.0);

            // Validate series group conditions.

            Assert.That(updatedConfig.SeriesGroupDetectionConditions, Is.Not.Null);

            var updatedGroupConditions = updatedConfig.SeriesGroupDetectionConditions.Single();

            Assert.That(updatedGroupConditions, Is.Not.Null);

            ValidateTempDataFeedDimensionKey(updatedGroupConditions.SeriesGroupKey, "Kolkata");

            Assert.That(updatedGroupConditions.ConditionOperator, Is.Null);
            Assert.That(updatedGroupConditions.HardThresholdCondition, Is.Null);
            Assert.That(updatedGroupConditions.SmartDetectionCondition, Is.Null);

            ValidateChangeThresholdCondition(updatedGroupConditions.ChangeThresholdCondition, 40.0, 12, false, AnomalyDetectorDirection.Up, 5, 6.0);

            // Validates series conditions.

            Assert.That(updatedConfig.SeriesDetectionConditions, Is.Not.Null);

            var updatedSeriesConditions = updatedConfig.SeriesDetectionConditions.Single();

            ValidateTempDataFeedDimensionKey(updatedSeriesConditions.SeriesKey, "Delhi", "Handmade");

            Assert.That(updatedSeriesConditions, Is.Not.Null);
            Assert.That(updatedSeriesConditions.ConditionOperator, Is.Null);
            Assert.That(updatedSeriesConditions.HardThresholdCondition, Is.Null);
            Assert.That(updatedSeriesConditions.ChangeThresholdCondition, Is.Null);

            ValidateSmartDetectionCondition(updatedSeriesConditions.SmartDetectionCondition, 30.0, AnomalyDetectorDirection.Both, 3, 4.0);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21509")]
        public async Task UpdateDetectionConfigurationWithEveryMember()
        {
            // Set parameters of the configuration to be created.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            var description = "This configuration was created to test the .NET client.";

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                ConditionOperator = DetectionConditionOperator.Or,
                HardThresholdCondition = new(AnomalyDetectorDirection.Down, new(1, 2.0))
                {
                    LowerBound = 10.0
                },
                ChangeThresholdCondition = new(50.0, 15, true, AnomalyDetectorDirection.Both, new(7, 8.0)),
                SmartDetectionCondition = new(60.0, AnomalyDetectorDirection.Up, new(5, 6.0))
            };

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = wholeConditions
            };

            // Set the series group conditions.

            var dimensions = new Dictionary<string, string>() { { TempDataFeedDimensionNameA, "Kolkata" } };
            var groupConditions = new MetricSeriesGroupDetectionCondition(new DimensionKey(dimensions))
            {
                ChangeThresholdCondition = new(40.0, 12, false, AnomalyDetectorDirection.Up, new(5, 6.0))
            };

            configToCreate.SeriesGroupDetectionConditions.Add(groupConditions);

            // Set the series conditions and create the configuration.

            dimensions = new Dictionary<string, string>() { { TempDataFeedDimensionNameA, "Delhi" }, { TempDataFeedDimensionNameB, "Handmade" } };
            var seriesConditions = new MetricSingleSeriesDetectionCondition(new DimensionKey(dimensions))
            {
                SmartDetectionCondition = new(30.0, AnomalyDetectorDirection.Both, new(3, 4.0))
            };

            configToCreate.SeriesDetectionConditions.Add(seriesConditions);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            // Update the created configuration.

            AnomalyDetectionConfiguration configToUpdate = disposableConfig.Configuration;

            configToUpdate.Description = description;

            configToUpdate.WholeSeriesDetectionConditions.ConditionOperator = DetectionConditionOperator.And;
            configToUpdate.WholeSeriesDetectionConditions.HardThresholdCondition = new(AnomalyDetectorDirection.Up, new(11, 12.0)) { UpperBound = 9.0 };
            configToUpdate.WholeSeriesDetectionConditions.ChangeThresholdCondition = null;
            configToUpdate.WholeSeriesDetectionConditions.SmartDetectionCondition = new(75.0, AnomalyDetectorDirection.Both, new(15, 16.0));

            dimensions = new Dictionary<string, string>() { { TempDataFeedDimensionNameA, "Delhi" } };
            var newGroupConditions = new MetricSeriesGroupDetectionCondition(new DimensionKey(dimensions))
            {
                SmartDetectionCondition = new(95.0, AnomalyDetectorDirection.Both, new(25, 26.0))
            };

            configToUpdate.SeriesGroupDetectionConditions.Add(newGroupConditions);

            configToUpdate.SeriesDetectionConditions.Clear();

            AnomalyDetectionConfiguration updatedConfig = await adminClient.UpdateDetectionConfigurationAsync(configToUpdate);

            // Validate top-level members.

            Assert.That(updatedConfig.Id, Is.EqualTo(configToUpdate.Id));
            Assert.That(updatedConfig.MetricId, Is.EqualTo(metricId));
            Assert.That(updatedConfig.Name, Is.EqualTo(configName));
            Assert.That(updatedConfig.Description, Is.EqualTo(description));
            Assert.That(updatedConfig.SeriesDetectionConditions, Is.Not.Null.And.Empty);

            // Validate whole series detection conditions.

            MetricWholeSeriesDetectionCondition updatedWholeConditions = updatedConfig.WholeSeriesDetectionConditions;

            Assert.That(updatedWholeConditions, Is.Not.Null);
            Assert.That(updatedWholeConditions.ConditionOperator, Is.EqualTo(DetectionConditionOperator.And));
            Assert.That(updatedWholeConditions.ChangeThresholdCondition, Is.Null);

            ValidateHardThresholdCondition(updatedWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Up, 9.0, null, 11, 12.0);
            ValidateSmartDetectionCondition(updatedWholeConditions.SmartDetectionCondition, 75.0, AnomalyDetectorDirection.Both, 15, 16.0);

            // Start series group conditions validation.

            Assert.That(updatedConfig.SeriesGroupDetectionConditions, Is.Not.Null);
            Assert.That(updatedConfig.SeriesGroupDetectionConditions.Count, Is.EqualTo(2));

            // Validate first series group conditions.

            var updatedGroupConditions0 = updatedConfig.SeriesGroupDetectionConditions[0];

            Assert.That(updatedGroupConditions0, Is.Not.Null);

            ValidateTempDataFeedDimensionKey(updatedGroupConditions0.SeriesGroupKey, "Kolkata");

            Assert.That(updatedGroupConditions0.ConditionOperator, Is.Null);
            Assert.That(updatedGroupConditions0.HardThresholdCondition, Is.Null);
            Assert.That(updatedGroupConditions0.SmartDetectionCondition, Is.Null);

            ValidateChangeThresholdCondition(updatedGroupConditions0.ChangeThresholdCondition, 40.0, 12, false, AnomalyDetectorDirection.Up, 5, 6.0);

            // Validate last series group conditions.

            var updatedGroupConditions1 = updatedConfig.SeriesGroupDetectionConditions[1];

            Assert.That(updatedGroupConditions1, Is.Not.Null);

            ValidateTempDataFeedDimensionKey(updatedGroupConditions1.SeriesGroupKey, "Delhi");

            Assert.That(updatedGroupConditions1.ConditionOperator, Is.Null);
            Assert.That(updatedGroupConditions1.HardThresholdCondition, Is.Null);
            Assert.That(updatedGroupConditions1.ChangeThresholdCondition, Is.Null);

            ValidateSmartDetectionCondition(updatedGroupConditions1.SmartDetectionCondition, 95.0, AnomalyDetectorDirection.Both, 25, 26.0);
        }

        [RecordedTest]
        public async Task UpdateRootLevelMembersWithNullSetsToDefault()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = new MetricWholeSeriesDetectionCondition()
                {
                    SmartDetectionCondition = new SmartDetectionCondition(1.0, AnomalyDetectorDirection.Down,
                        new SuppressCondition(1, 1.0))
                },
                Description = "description"
            };

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            AnomalyDetectionConfiguration configToUpdate = disposableConfig.Configuration;

            configToUpdate.Description = null;

            AnomalyDetectionConfiguration updatedConfig = await adminClient.UpdateDetectionConfigurationAsync(configToUpdate);

            Assert.That(updatedConfig.Description, Is.Empty);
        }

        [RecordedTest]
        public async Task UpdateSmartDetectionConditionWithNullSetsToDefault()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = new MetricWholeSeriesDetectionCondition()
                {
                    SmartDetectionCondition = new SmartDetectionCondition(1.0, AnomalyDetectorDirection.Down,
                        new SuppressCondition(1, 1.0)),
                    HardThresholdCondition = new HardThresholdCondition(AnomalyDetectorDirection.Down,
                        new SuppressCondition(1, 1.0))
                    {
                        LowerBound = 1.0
                    },
                    ConditionOperator = DetectionConditionOperator.And
                }
            };

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            AnomalyDetectionConfiguration configToUpdate = disposableConfig.Configuration;

            configToUpdate.WholeSeriesDetectionConditions.SmartDetectionCondition = null;

            AnomalyDetectionConfiguration updatedConfig = await adminClient.UpdateDetectionConfigurationAsync(configToUpdate);

            Assert.That(updatedConfig.WholeSeriesDetectionConditions.SmartDetectionCondition, Is.Null);
        }

        [RecordedTest]
        public async Task UpdateHardThresholdConditionWithNullSetsToDefault()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = new MetricWholeSeriesDetectionCondition()
                {
                    SmartDetectionCondition = new SmartDetectionCondition(1.0, AnomalyDetectorDirection.Down,
                        new SuppressCondition(1, 1.0)),
                    HardThresholdCondition = new HardThresholdCondition(AnomalyDetectorDirection.Down,
                        new SuppressCondition(1, 1.0))
                    {
                        LowerBound = 1.0
                    },
                    ConditionOperator = DetectionConditionOperator.And
                }
            };

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            AnomalyDetectionConfiguration configToUpdate = disposableConfig.Configuration;

            configToUpdate.WholeSeriesDetectionConditions.HardThresholdCondition = null;

            AnomalyDetectionConfiguration updatedConfig = await adminClient.UpdateDetectionConfigurationAsync(configToUpdate);

            Assert.That(updatedConfig.WholeSeriesDetectionConditions.HardThresholdCondition, Is.Null);
        }

        [RecordedTest]
        public async Task UpdateChangeThresholdConditionWithNullSetsToDefault()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = new MetricWholeSeriesDetectionCondition()
                {
                    SmartDetectionCondition = new SmartDetectionCondition(1.0, AnomalyDetectorDirection.Down,
                        new SuppressCondition(1, 1.0)),
                    ChangeThresholdCondition = new ChangeThresholdCondition(1.0, 1, false, AnomalyDetectorDirection.Down,
                        new SuppressCondition(1, 1.0)),
                    ConditionOperator = DetectionConditionOperator.And
                }
            };

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            AnomalyDetectionConfiguration configToUpdate = disposableConfig.Configuration;

            configToUpdate.WholeSeriesDetectionConditions.ChangeThresholdCondition = null;

            AnomalyDetectionConfiguration updatedConfig = await adminClient.UpdateDetectionConfigurationAsync(configToUpdate);

            Assert.That(updatedConfig.WholeSeriesDetectionConditions.ChangeThresholdCondition, Is.Null);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetDetectionConfigurations(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            var configCount = 0;

            await foreach (AnomalyDetectionConfiguration config in adminClient.GetDetectionConfigurationsAsync(MetricId))
            {
                Assert.That(config.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(config.MetricId, Is.EqualTo(MetricId));
                Assert.That(config.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(config.Description, Is.Not.Null);
                Assert.That(config.SeriesGroupDetectionConditions, Is.Not.Null);
                Assert.That(config.SeriesDetectionConditions, Is.Not.Null);

                ValidateGenericDetectionConditions(config.WholeSeriesDetectionConditions);

                foreach (MetricSeriesGroupDetectionCondition groupConditions in config.SeriesGroupDetectionConditions)
                {
                    ValidateGroupKey(groupConditions.SeriesGroupKey);
                    ValidateGenericDetectionConditions(groupConditions);
                }

                foreach (MetricSingleSeriesDetectionCondition seriesConditions in config.SeriesDetectionConditions)
                {
                    ValidateSeriesKey(seriesConditions.SeriesKey);
                    ValidateGenericDetectionConditions(seriesConditions);
                }

                if (++configCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(configCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public void GetDetectionConfigurationsWithOptionalSkip()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var options = new GetDetectionConfigurationsOptions()
            {
                Skip = SkipSamples
            };

            AsyncPageable<AnomalyDetectionConfiguration> configs = adminClient.GetDetectionConfigurationsAsync(MetricId);
            AsyncPageable<AnomalyDetectionConfiguration> configsWithSkip = adminClient.GetDetectionConfigurationsAsync(MetricId, options);
            var getConfigsCount = configs.ToEnumerableAsync().Result.Count;
            var getConfigsWithSkipCount = configsWithSkip.ToEnumerableAsync().Result.Count;

            Assert.That(getConfigsCount, Is.EqualTo(getConfigsWithSkipCount + SkipSamples));
        }

        [RecordedTest]
        public async Task GetDetectionConfigurationsWithOptionalMaxPageSize()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var options = new GetDetectionConfigurationsOptions()
            {
                MaxPageSize = MaxPageSizeSamples
            };

            AsyncPageable<AnomalyDetectionConfiguration> configsWithMaxPageSize = adminClient.GetDetectionConfigurationsAsync(MetricId, options);

            var configCount = 0;

            await foreach (Page<AnomalyDetectionConfiguration> page in configsWithMaxPageSize.AsPages())
            {
                Assert.That(page.Values.Count, Is.LessThanOrEqualTo(MaxPageSizeSamples));

                if (++configCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(configCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeleteDetectionConfiguration(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);

            string configName = Recording.GenerateAlphaNumericId("config");
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = new(AnomalyDetectorDirection.Up, new(1, 2.0))
                {
                    UpperBound = 10.0
                }
            };

            var configToCreate = new AnomalyDetectionConfiguration()
            {
                MetricId = metricId,
                Name = configName,
                WholeSeriesDetectionConditions = wholeConditions
            };

            string configId = null;

            try
            {
                AnomalyDetectionConfiguration createdConfig = await adminClient.CreateDetectionConfigurationAsync(configToCreate);
                configId = createdConfig.Id;

                Assert.That(configId, Is.Not.Null.And.Not.Empty);
            }
            finally
            {
                if (configId != null)
                {
                    await adminClient.DeleteDetectionConfigurationAsync(configId);

                    var errorCause = "Not Found";
                    Assert.That(async () => await adminClient.GetDetectionConfigurationAsync(configId), Throws.InstanceOf<RequestFailedException>().With.Message.Contains(errorCause));
                }
            }
        }

        private void ValidateHardThresholdCondition(HardThresholdCondition condition, AnomalyDetectorDirection direction, double? upperBound, double? lowerBound, int minimumNumber, double minimumRatio)
        {
            Assert.That(condition, Is.Not.Null);
            Assert.That(condition.AnomalyDetectorDirection, Is.EqualTo(direction));
            Assert.That(condition.UpperBound, Is.EqualTo(upperBound));
            Assert.That(condition.LowerBound, Is.EqualTo(lowerBound));
            Assert.That(condition.SuppressCondition, Is.Not.Null);
            Assert.That(condition.SuppressCondition.MinimumNumber, Is.EqualTo(minimumNumber));
            Assert.That(condition.SuppressCondition.MinimumRatio, Is.EqualTo(minimumRatio));
        }

        private void ValidateChangeThresholdCondition(ChangeThresholdCondition condition, double changePercentage, int shiftPoint, bool withinRange, AnomalyDetectorDirection direction, int minimumNumber, double minimumRatio)
        {
            Assert.That(condition, Is.Not.Null);
            Assert.That(condition.AnomalyDetectorDirection, Is.EqualTo(direction));
            Assert.That(condition.WithinRange, Is.EqualTo(withinRange));
            Assert.That(condition.ChangePercentage, Is.EqualTo(changePercentage));
            Assert.That(condition.ShiftPoint, Is.EqualTo(shiftPoint));
            Assert.That(condition.SuppressCondition, Is.Not.Null);
            Assert.That(condition.SuppressCondition.MinimumNumber, Is.EqualTo(minimumNumber));
            Assert.That(condition.SuppressCondition.MinimumRatio, Is.EqualTo(minimumRatio));
        }

        private void ValidateSmartDetectionCondition(SmartDetectionCondition condition, double sensitivity, AnomalyDetectorDirection direction, int minimumNumber, double minimumRatio)
        {
            Assert.That(condition, Is.Not.Null);
            Assert.That(condition.AnomalyDetectorDirection, Is.EqualTo(direction));
            Assert.That(condition.Sensitivity, Is.EqualTo(sensitivity));
            Assert.That(condition.SuppressCondition.MinimumNumber, Is.EqualTo(minimumNumber));
            Assert.That(condition.SuppressCondition.MinimumRatio, Is.EqualTo(minimumRatio));
        }

        private void ValidateGenericDetectionConditions(MetricWholeSeriesDetectionCondition conditions)
        {
            Assert.That(conditions, Is.Not.Null);

            var hardCondition = conditions.HardThresholdCondition;
            var changeCondition = conditions.ChangeThresholdCondition;
            var smartCondition = conditions.SmartDetectionCondition;

            int conditionsCount = 0;

            if (hardCondition != null)
            {
                conditionsCount++;

                if (hardCondition.AnomalyDetectorDirection == AnomalyDetectorDirection.Up)
                {
                    Assert.That(hardCondition.UpperBound, Is.Not.Null);
                    Assert.That(hardCondition.LowerBound, Is.Null);
                }
                else if (hardCondition.AnomalyDetectorDirection == AnomalyDetectorDirection.Down)
                {
                    Assert.That(hardCondition.UpperBound, Is.Null);
                    Assert.That(hardCondition.LowerBound, Is.Not.Null);
                }
                else if (hardCondition.AnomalyDetectorDirection == AnomalyDetectorDirection.Both)
                {
                    Assert.That(hardCondition.UpperBound, Is.Not.Null);
                    Assert.That(hardCondition.LowerBound, Is.Not.Null);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid AnomalyDetectorDirection value!");
                }

                Assert.That(hardCondition.SuppressCondition, Is.Not.Null);
            }

            if (changeCondition != null)
            {
                conditionsCount++;

                Assert.That(changeCondition.AnomalyDetectorDirection, Is.Not.EqualTo(default(AnomalyDetectorDirection)));
                Assert.That(changeCondition.SuppressCondition, Is.Not.Null);
            }

            if (smartCondition != null)
            {
                conditionsCount++;

                Assert.That(smartCondition.AnomalyDetectorDirection, Is.Not.EqualTo(default(AnomalyDetectorDirection)));
                Assert.That(smartCondition.SuppressCondition, Is.Not.Null);
            }

            Assert.That(conditionsCount, Is.GreaterThan(0));

            if (conditionsCount > 1)
            {
                Assert.That(conditions.ConditionOperator, Is.Not.Null);
            }
            else
            {
                Assert.That(conditions.ConditionOperator, Is.Null);
            }
        }
    }
}
