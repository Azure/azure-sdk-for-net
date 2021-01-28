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
        public async Task CreateAndGetDetectionConfigurationWithHardCondition()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");
            var description = "This hook was created to test the .NET client.";

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = new (AnomalyDetectorDirection.Up, new (1, 2.0))
                {
                    UpperBound = 10.0
                }
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions)
            {
                // This is the only test that validates description during creation. Please don't remove it!
                Description = description
            };

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            AnomalyDetectionConfiguration createdConfig = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.MetricId, Is.EqualTo(MetricId));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.EqualTo(description));
            Assert.That(createdConfig.SeriesGroupDetectionConditions, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.SeriesDetectionConditions, Is.Not.Null.And.Empty);

            MetricWholeSeriesDetectionCondition createdWholeConditions = createdConfig.WholeSeriesDetectionConditions;

            Assert.That(createdWholeConditions, Is.Not.Null);
            Assert.That(createdWholeConditions.CrossConditionsOperator, Is.Null);
            Assert.That(createdWholeConditions.ChangeThresholdCondition, Is.Null);
            Assert.That(createdWholeConditions.SmartDetectionCondition, Is.Null);

            ValidateHardThresholdCondition(createdWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Up, 10.0, null, 1, 2.0);
        }

        [RecordedTest]
        public async Task CreateAndGetDetectionConfigurationWithChangeAndSmartConditions()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                CrossConditionsOperator = DetectionConditionsOperator.And,
                ChangeThresholdCondition = new (90.0, 5, true, AnomalyDetectorDirection.Both, new (1, 2.0)),
                SmartDetectionCondition = new (23.0, AnomalyDetectorDirection.Down, new (3, 4.0))
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            AnomalyDetectionConfiguration createdConfig = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.MetricId, Is.EqualTo(MetricId));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.SeriesGroupDetectionConditions, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.SeriesDetectionConditions, Is.Not.Null.And.Empty);

            MetricWholeSeriesDetectionCondition createdWholeConditions = createdConfig.WholeSeriesDetectionConditions;

            Assert.That(createdWholeConditions, Is.Not.Null);
            Assert.That(createdWholeConditions.CrossConditionsOperator, Is.EqualTo(DetectionConditionsOperator.And));
            Assert.That(createdWholeConditions.HardThresholdCondition, Is.Null);

            ValidateChangeThresholdCondition(createdWholeConditions.ChangeThresholdCondition, 90.0, 5, true, AnomalyDetectorDirection.Both, 1, 2.0);
            ValidateSmartDetectionCondition(createdWholeConditions.SmartDetectionCondition, 23.0, AnomalyDetectorDirection.Down, 3, 4.0);
        }

        [RecordedTest]
        public async Task CreateAndGetDetectionConfigurationWithSeriesGroupConditions()
        {
            // Set required parameters of the configuration to be created.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = new (AnomalyDetectorDirection.Down, new (1, 2.0))
                {
                    LowerBound = 10.0
                }
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions);

            // Set the series group conditions and create the configuration.

            var groupKey1 = new DimensionKey();
            var groupKey2 = new DimensionKey();

            groupKey1.AddDimensionColumn("city", "Delhi");
            groupKey2.AddDimensionColumn("city", "Koltaka");

            var groupConditions0 = new MetricSeriesGroupDetectionCondition(groupKey1)
            {
                SmartDetectionCondition = new (30.0, AnomalyDetectorDirection.Both, new (3, 4.0))
            };

            var groupConditions1 = new MetricSeriesGroupDetectionCondition(groupKey2)
            {
                ChangeThresholdCondition = new (40.0, 12, false, AnomalyDetectorDirection.Up, new (5, 6.0))
            };

            configToCreate.SeriesGroupDetectionConditions.Add(groupConditions0);
            configToCreate.SeriesGroupDetectionConditions.Add(groupConditions1);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            // Get the created configuration and validate top-level members.

            AnomalyDetectionConfiguration createdConfig = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.MetricId, Is.EqualTo(MetricId));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.SeriesDetectionConditions, Is.Not.Null.And.Empty);

            // Validate whole series detection conditions.

            MetricWholeSeriesDetectionCondition createdWholeConditions = createdConfig.WholeSeriesDetectionConditions;

            Assert.That(createdWholeConditions, Is.Not.Null);
            Assert.That(createdWholeConditions.CrossConditionsOperator, Is.Null);
            Assert.That(createdWholeConditions.ChangeThresholdCondition, Is.Null);
            Assert.That(createdWholeConditions.SmartDetectionCondition, Is.Null);

            ValidateHardThresholdCondition(createdWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Down, null, 10.0, 1, 2.0);

            // Start series group conditions validation.

            Assert.That(createdConfig.SeriesGroupDetectionConditions, Is.Not.Null);
            Assert.That(createdConfig.SeriesGroupDetectionConditions.Count, Is.EqualTo(2));

            // Validate first series group conditions.

            var createdGroupConditions0 = createdConfig.SeriesGroupDetectionConditions[0];

            Assert.That(createdGroupConditions0, Is.Not.Null);

            ValidateGroupKey(createdGroupConditions0.SeriesGroupKey);

            Dictionary<string, string> dimensionColumns = createdGroupConditions0.SeriesGroupKey.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(1));
            Assert.That(dimensionColumns["city"], Is.EqualTo("Delhi"));

            Assert.That(createdGroupConditions0.CrossConditionsOperator, Is.Null);
            Assert.That(createdGroupConditions0.HardThresholdCondition, Is.Null);
            Assert.That(createdGroupConditions0.ChangeThresholdCondition, Is.Null);

            ValidateSmartDetectionCondition(createdGroupConditions0.SmartDetectionCondition, 30.0, AnomalyDetectorDirection.Both, 3, 4.0);

            // Validate last series group conditions.

            var createdGroupConditions1 = createdConfig.SeriesGroupDetectionConditions[1];

            Assert.That(createdGroupConditions1, Is.Not.Null);

            ValidateGroupKey(createdGroupConditions1.SeriesGroupKey);

            dimensionColumns = createdGroupConditions1.SeriesGroupKey.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(1));
            Assert.That(dimensionColumns["city"], Is.EqualTo("Koltaka"));

            Assert.That(createdGroupConditions1.CrossConditionsOperator, Is.Null);
            Assert.That(createdGroupConditions1.HardThresholdCondition, Is.Null);
            Assert.That(createdGroupConditions1.SmartDetectionCondition, Is.Null);

            ValidateChangeThresholdCondition(createdGroupConditions1.ChangeThresholdCondition, 40.0, 12, false, AnomalyDetectorDirection.Up, 5, 6.0);
        }

        [RecordedTest]
        public async Task CreateAndGetDetectionConfigurationWithSeriesConditions()
        {
            // Set required parameters of the configuration to be created.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = new (AnomalyDetectorDirection.Both, new (1, 2.0))
                {
                    UpperBound = 20.0,
                    LowerBound = 10.0
                }
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions);

            // Set the series conditions and create the configuration.

            var seriesKey1 = new DimensionKey();
            var seriesKey2 = new DimensionKey();

            seriesKey1.AddDimensionColumn("city", "Delhi");
            seriesKey1.AddDimensionColumn("category", "Handmade");

            seriesKey2.AddDimensionColumn("city", "Koltaka");
            seriesKey2.AddDimensionColumn("category", "Grocery & Gourmet Food");

            var seriesConditions0 = new MetricSingleSeriesDetectionCondition(seriesKey1)
            {
                SmartDetectionCondition = new (30.0, AnomalyDetectorDirection.Both, new (3, 4.0))
            };

            var seriesConditions1 = new MetricSingleSeriesDetectionCondition(seriesKey2)
            {
                ChangeThresholdCondition = new (40.0, 12, false, AnomalyDetectorDirection.Up, new (5, 6.0))
            };

            configToCreate.SeriesDetectionConditions.Add(seriesConditions0);
            configToCreate.SeriesDetectionConditions.Add(seriesConditions1);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            // Get the created configuration and validate top-level members.

            AnomalyDetectionConfiguration createdConfig = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.MetricId, Is.EqualTo(MetricId));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.SeriesGroupDetectionConditions, Is.Not.Null.And.Empty);

            // Validate whole series detection conditions.

            MetricWholeSeriesDetectionCondition createdWholeConditions = createdConfig.WholeSeriesDetectionConditions;

            Assert.That(createdWholeConditions, Is.Not.Null);
            Assert.That(createdWholeConditions.CrossConditionsOperator, Is.Null);
            Assert.That(createdWholeConditions.ChangeThresholdCondition, Is.Null);
            Assert.That(createdWholeConditions.SmartDetectionCondition, Is.Null);

            ValidateHardThresholdCondition(createdWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Both, 20.0, 10.0, 1, 2.0);

            // Start series conditions validation.

            Assert.That(createdConfig.SeriesDetectionConditions, Is.Not.Null);
            Assert.That(createdConfig.SeriesDetectionConditions.Count, Is.EqualTo(2));

            // Validate first series conditions.

            var createdSeriesConditions0 = createdConfig.SeriesDetectionConditions[0];

            Assert.That(createdSeriesConditions0, Is.Not.Null);

            ValidateSeriesKey(createdSeriesConditions0.SeriesKey);

            Dictionary<string, string> dimensionColumns = createdSeriesConditions0.SeriesKey.AsDictionary();

            Assert.That(dimensionColumns["city"], Is.EqualTo("Delhi"));
            Assert.That(dimensionColumns["category"], Is.EqualTo("Handmade"));

            Assert.That(createdSeriesConditions0.CrossConditionsOperator, Is.Null);
            Assert.That(createdSeriesConditions0.HardThresholdCondition, Is.Null);
            Assert.That(createdSeriesConditions0.ChangeThresholdCondition, Is.Null);

            ValidateSmartDetectionCondition(createdSeriesConditions0.SmartDetectionCondition, 30.0, AnomalyDetectorDirection.Both, 3, 4.0);

            // Validate last series conditions.

            var createdSeriesConditions1 = createdConfig.SeriesDetectionConditions[1];

            Assert.That(createdSeriesConditions1, Is.Not.Null);

            ValidateSeriesKey(createdSeriesConditions1.SeriesKey);

            dimensionColumns = createdSeriesConditions1.SeriesKey.AsDictionary();

            Assert.That(dimensionColumns["city"], Is.EqualTo("Koltaka"));
            Assert.That(dimensionColumns["category"], Is.EqualTo("Grocery & Gourmet Food"));

            Assert.That(createdSeriesConditions1.CrossConditionsOperator, Is.Null);
            Assert.That(createdSeriesConditions1.HardThresholdCondition, Is.Null);
            Assert.That(createdSeriesConditions1.SmartDetectionCondition, Is.Null);

            ValidateChangeThresholdCondition(createdSeriesConditions1.ChangeThresholdCondition, 40.0, 12, false, AnomalyDetectorDirection.Up, 5, 6.0);
        }

        [RecordedTest]
        public async Task UpdateDetectionConfigurationWithMinimumSetupAndGetInstance()
        {
            // Set required parameters of the configuration to be created.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                CrossConditionsOperator = DetectionConditionsOperator.Or,
                HardThresholdCondition = new (AnomalyDetectorDirection.Down, new (1, 2.0))
                {
                    LowerBound = 10.0
                },
                SmartDetectionCondition = new (60.0, AnomalyDetectorDirection.Up, new (5, 6.0))
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions);

            // Set the series group conditions.

            var groupKey = new DimensionKey();

            groupKey.AddDimensionColumn("city", "Koltaka");

            var groupConditions = new MetricSeriesGroupDetectionCondition(groupKey)
            {
                ChangeThresholdCondition = new (40.0, 12, false, AnomalyDetectorDirection.Up, new (5, 6.0))
            };

            configToCreate.SeriesGroupDetectionConditions.Add(groupConditions);

            // Set the series conditions and create the configuration.

            var seriesKey = new DimensionKey();

            seriesKey.AddDimensionColumn("city", "Delhi");
            seriesKey.AddDimensionColumn("category", "Handmade");

            var seriesConditions = new MetricSingleSeriesDetectionCondition(seriesKey)
            {
                SmartDetectionCondition = new (30.0, AnomalyDetectorDirection.Both, new (3, 4.0))
            };

            configToCreate.SeriesDetectionConditions.Add(seriesConditions);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            // Update the created configuration.

            AnomalyDetectionConfiguration configToUpdate = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            configToUpdate.WholeSeriesDetectionConditions.HardThresholdCondition.LowerBound = 12.0;

            await adminClient.UpdateDetectionConfigurationAsync(disposableConfig.Id, configToUpdate);

            // Get the updated configuration and validate top-level members.

            AnomalyDetectionConfiguration updatedConfig = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            Assert.That(updatedConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(updatedConfig.MetricId, Is.EqualTo(MetricId));
            Assert.That(updatedConfig.Name, Is.EqualTo(configName));
            Assert.That(updatedConfig.Description, Is.Empty);

            // Validate whole series detection conditions.

            MetricWholeSeriesDetectionCondition updatedWholeConditions = updatedConfig.WholeSeriesDetectionConditions;

            Assert.That(updatedWholeConditions, Is.Not.Null);
            Assert.That(updatedWholeConditions.CrossConditionsOperator, Is.EqualTo(DetectionConditionsOperator.Or));
            Assert.That(updatedWholeConditions.ChangeThresholdCondition, Is.Null);

            ValidateHardThresholdCondition(updatedWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Down, null, 12.0, 1, 2.0);
            ValidateSmartDetectionCondition(updatedWholeConditions.SmartDetectionCondition, 60.0, AnomalyDetectorDirection.Up, 5, 6.0);

            // Validate series group conditions.

            Assert.That(updatedConfig.SeriesGroupDetectionConditions, Is.Not.Null);

            var updatedGroupConditions = updatedConfig.SeriesGroupDetectionConditions.Single();

            Assert.That(updatedGroupConditions, Is.Not.Null);

            ValidateGroupKey(updatedGroupConditions.SeriesGroupKey);

            Dictionary<string, string> dimensionColumns = updatedGroupConditions.SeriesGroupKey.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(1));
            Assert.That(dimensionColumns["city"], Is.EqualTo("Koltaka"));

            Assert.That(updatedGroupConditions.CrossConditionsOperator, Is.Null);
            Assert.That(updatedGroupConditions.HardThresholdCondition, Is.Null);
            Assert.That(updatedGroupConditions.SmartDetectionCondition, Is.Null);

            ValidateChangeThresholdCondition(updatedGroupConditions.ChangeThresholdCondition, 40.0, 12, false, AnomalyDetectorDirection.Up, 5, 6.0);

            // Validates series conditions.

            Assert.That(updatedConfig.SeriesDetectionConditions, Is.Not.Null);

            var updatedSeriesConditions = updatedConfig.SeriesDetectionConditions.Single();

            ValidateSeriesKey(updatedSeriesConditions.SeriesKey);

            dimensionColumns = updatedSeriesConditions.SeriesKey.AsDictionary();

            Assert.That(dimensionColumns["city"], Is.EqualTo("Delhi"));
            Assert.That(dimensionColumns["category"], Is.EqualTo("Handmade"));

            Assert.That(updatedSeriesConditions, Is.Not.Null);
            Assert.That(updatedSeriesConditions.CrossConditionsOperator, Is.Null);
            Assert.That(updatedSeriesConditions.HardThresholdCondition, Is.Null);
            Assert.That(updatedSeriesConditions.ChangeThresholdCondition, Is.Null);

            ValidateSmartDetectionCondition(updatedSeriesConditions.SmartDetectionCondition, 30.0, AnomalyDetectorDirection.Both, 3, 4.0);
        }

        [RecordedTest]
        public async Task UpdateDetectionConfigurationWithMinimumSetupAndNewInstance()
        {
            // Set required parameters of the configuration to be created.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                CrossConditionsOperator = DetectionConditionsOperator.Or,
                HardThresholdCondition = new (AnomalyDetectorDirection.Down, new (1, 2.0))
                {
                    LowerBound = 10.0
                },
                SmartDetectionCondition = new (60.0, AnomalyDetectorDirection.Up, new (5, 6.0))
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions);

            // Set the series group conditions.

            var groupKey = new DimensionKey();

            groupKey.AddDimensionColumn("city", "Koltaka");

            var groupConditions = new MetricSeriesGroupDetectionCondition(groupKey)
            {
                ChangeThresholdCondition = new (40.0, 12, false, AnomalyDetectorDirection.Up, new (5, 6.0))
            };

            configToCreate.SeriesGroupDetectionConditions.Add(groupConditions);

            // Set the series conditions and create the configuration.

            var seriesKey = new DimensionKey();

            seriesKey.AddDimensionColumn("city", "Delhi");
            seriesKey.AddDimensionColumn("category", "Handmade");

            var seriesConditions = new MetricSingleSeriesDetectionCondition(seriesKey)
            {
                SmartDetectionCondition = new (30.0, AnomalyDetectorDirection.Both, new (3, 4.0))
            };

            configToCreate.SeriesDetectionConditions.Add(seriesConditions);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            // Update the created configuration.

            var configToUpdate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions);

            configToUpdate.WholeSeriesDetectionConditions.HardThresholdCondition.LowerBound = 12.0;

            await adminClient.UpdateDetectionConfigurationAsync(disposableConfig.Id, configToUpdate);

            // Get the updated configuration and validate top-level members.

            AnomalyDetectionConfiguration updatedConfig = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            Assert.That(updatedConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(updatedConfig.MetricId, Is.EqualTo(MetricId));
            Assert.That(updatedConfig.Name, Is.EqualTo(configName));
            Assert.That(updatedConfig.Description, Is.Empty);

            // Validate whole series detection conditions.

            MetricWholeSeriesDetectionCondition updatedWholeConditions = updatedConfig.WholeSeriesDetectionConditions;

            Assert.That(updatedWholeConditions, Is.Not.Null);
            Assert.That(updatedWholeConditions.CrossConditionsOperator, Is.EqualTo(DetectionConditionsOperator.Or));
            Assert.That(updatedWholeConditions.ChangeThresholdCondition, Is.Null);

            ValidateHardThresholdCondition(updatedWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Down, null, 12.0, 1, 2.0);
            ValidateSmartDetectionCondition(updatedWholeConditions.SmartDetectionCondition, 60.0, AnomalyDetectorDirection.Up, 5, 6.0);

            // Validate series group conditions.

            Assert.That(updatedConfig.SeriesGroupDetectionConditions, Is.Not.Null);

            var updatedGroupConditions = updatedConfig.SeriesGroupDetectionConditions.Single();

            Assert.That(updatedGroupConditions, Is.Not.Null);

            ValidateGroupKey(updatedGroupConditions.SeriesGroupKey);

            Dictionary<string, string> dimensionColumns = updatedGroupConditions.SeriesGroupKey.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(1));
            Assert.That(dimensionColumns["city"], Is.EqualTo("Koltaka"));

            Assert.That(updatedGroupConditions.CrossConditionsOperator, Is.Null);
            Assert.That(updatedGroupConditions.HardThresholdCondition, Is.Null);
            Assert.That(updatedGroupConditions.SmartDetectionCondition, Is.Null);

            ValidateChangeThresholdCondition(updatedGroupConditions.ChangeThresholdCondition, 40.0, 12, false, AnomalyDetectorDirection.Up, 5, 6.0);

            // Validates series conditions.

            Assert.That(updatedConfig.SeriesDetectionConditions, Is.Not.Null);

            var updatedSeriesConditions = updatedConfig.SeriesDetectionConditions.Single();

            ValidateSeriesKey(updatedSeriesConditions.SeriesKey);

            dimensionColumns = updatedSeriesConditions.SeriesKey.AsDictionary();

            Assert.That(dimensionColumns["city"], Is.EqualTo("Delhi"));
            Assert.That(dimensionColumns["category"], Is.EqualTo("Handmade"));

            Assert.That(updatedSeriesConditions, Is.Not.Null);
            Assert.That(updatedSeriesConditions.CrossConditionsOperator, Is.Null);
            Assert.That(updatedSeriesConditions.HardThresholdCondition, Is.Null);
            Assert.That(updatedSeriesConditions.ChangeThresholdCondition, Is.Null);

            ValidateSmartDetectionCondition(updatedSeriesConditions.SmartDetectionCondition, 30.0, AnomalyDetectorDirection.Both, 3, 4.0);
        }

        [RecordedTest]
        public async Task UpdateDetectionConfigurationWithEveryMemberAndGetInstance()
        {
            // Set parameters of the configuration to be created.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");
            var description = "This hook was created to test the .NET client.";

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                CrossConditionsOperator = DetectionConditionsOperator.Or,
                HardThresholdCondition = new (AnomalyDetectorDirection.Down, new (1, 2.0))
                {
                    LowerBound = 10.0
                },
                ChangeThresholdCondition = new (50.0, 15, true, AnomalyDetectorDirection.Both, new (7, 8.0)),
                SmartDetectionCondition = new (60.0, AnomalyDetectorDirection.Up, new (5, 6.0))
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions);

            // Set the series group conditions.

            var groupKey = new DimensionKey();

            groupKey.AddDimensionColumn("city", "Koltaka");

            var groupConditions = new MetricSeriesGroupDetectionCondition(groupKey)
            {
                ChangeThresholdCondition = new (40.0, 12, false, AnomalyDetectorDirection.Up, new (5, 6.0))
            };

            configToCreate.SeriesGroupDetectionConditions.Add(groupConditions);

            // Set the series conditions and create the configuration.

            var seriesKey = new DimensionKey();

            seriesKey.AddDimensionColumn("city", "Delhi");
            seriesKey.AddDimensionColumn("category", "Handmade");

            var seriesConditions = new MetricSingleSeriesDetectionCondition(seriesKey)
            {
                SmartDetectionCondition = new (30.0, AnomalyDetectorDirection.Both, new (3, 4.0))
            };

            configToCreate.SeriesDetectionConditions.Add(seriesConditions);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            // Update the created configuration.

            AnomalyDetectionConfiguration configToUpdate = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            configToUpdate.Description = description;

            configToUpdate.WholeSeriesDetectionConditions.CrossConditionsOperator = DetectionConditionsOperator.And;
            configToUpdate.WholeSeriesDetectionConditions.HardThresholdCondition = new (AnomalyDetectorDirection.Up, new (11, 12.0)) { UpperBound = 9.0 };
            configToUpdate.WholeSeriesDetectionConditions.ChangeThresholdCondition = null;
            configToUpdate.WholeSeriesDetectionConditions.SmartDetectionCondition = new (75.0, AnomalyDetectorDirection.Both, new (15, 16.0));

            var newGroupKey = new DimensionKey();

            newGroupKey.AddDimensionColumn("city", "Delhi");

            var newGroupConditions = new MetricSeriesGroupDetectionCondition(newGroupKey)
            {
                SmartDetectionCondition = new (95.0, AnomalyDetectorDirection.Both, new (25, 26.0))
            };

            configToUpdate.SeriesGroupDetectionConditions.Add(newGroupConditions);

            configToUpdate.SeriesDetectionConditions.Clear();

            await adminClient.UpdateDetectionConfigurationAsync(disposableConfig.Id, configToUpdate);

            // Get the updated configuration and validate top-level members.

            AnomalyDetectionConfiguration updatedConfig = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            Assert.That(updatedConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(updatedConfig.MetricId, Is.EqualTo(MetricId));
            Assert.That(updatedConfig.Name, Is.EqualTo(configName));
            Assert.That(updatedConfig.Description, Is.EqualTo(description));
            Assert.That(updatedConfig.SeriesDetectionConditions, Is.Not.Null.And.Empty);

            // Validate whole series detection conditions.

            MetricWholeSeriesDetectionCondition updatedWholeConditions = updatedConfig.WholeSeriesDetectionConditions;

            Assert.That(updatedWholeConditions, Is.Not.Null);
            Assert.That(updatedWholeConditions.CrossConditionsOperator, Is.EqualTo(DetectionConditionsOperator.And));
            Assert.That(updatedWholeConditions.ChangeThresholdCondition, Is.Null);

            ValidateHardThresholdCondition(updatedWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Up, 9.0, null, 11, 12.0);
            ValidateSmartDetectionCondition(updatedWholeConditions.SmartDetectionCondition, 75.0, AnomalyDetectorDirection.Both, 15, 16.0);

            // Start series group conditions validation.

            Assert.That(updatedConfig.SeriesGroupDetectionConditions, Is.Not.Null);
            Assert.That(updatedConfig.SeriesGroupDetectionConditions.Count, Is.EqualTo(2));

            // Validate first series group conditions.

            var updatedGroupConditions0 = updatedConfig.SeriesGroupDetectionConditions[0];

            Assert.That(updatedGroupConditions0, Is.Not.Null);

            ValidateGroupKey(updatedGroupConditions0.SeriesGroupKey);

            Dictionary<string, string> dimensionColumns = updatedGroupConditions0.SeriesGroupKey.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(1));
            Assert.That(dimensionColumns["city"], Is.EqualTo("Koltaka"));

            Assert.That(updatedGroupConditions0.CrossConditionsOperator, Is.Null);
            Assert.That(updatedGroupConditions0.HardThresholdCondition, Is.Null);
            Assert.That(updatedGroupConditions0.SmartDetectionCondition, Is.Null);

            ValidateChangeThresholdCondition(updatedGroupConditions0.ChangeThresholdCondition, 40.0, 12, false, AnomalyDetectorDirection.Up, 5, 6.0);

            // Validate last series group conditions.

            var updatedGroupConditions1 = updatedConfig.SeriesGroupDetectionConditions[1];

            Assert.That(updatedGroupConditions1, Is.Not.Null);

            ValidateGroupKey(updatedGroupConditions1.SeriesGroupKey);

            dimensionColumns = updatedGroupConditions1.SeriesGroupKey.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(1));
            Assert.That(dimensionColumns["city"], Is.EqualTo("Delhi"));

            Assert.That(updatedGroupConditions1.CrossConditionsOperator, Is.Null);
            Assert.That(updatedGroupConditions1.HardThresholdCondition, Is.Null);
            Assert.That(updatedGroupConditions1.ChangeThresholdCondition, Is.Null);

            ValidateSmartDetectionCondition(updatedGroupConditions1.SmartDetectionCondition, 95.0, AnomalyDetectorDirection.Both, 25, 26.0);
        }

        [RecordedTest]
        public async Task UpdateDetectionConfigurationWithEveryMemberAndNewInstance()
        {
            // Set parameters of the configuration to be created.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");
            var description = "This hook was created to test the .NET client.";

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                CrossConditionsOperator = DetectionConditionsOperator.Or,
                HardThresholdCondition = new (AnomalyDetectorDirection.Down, new (1, 2.0))
                {
                    LowerBound = 10.0
                },
                ChangeThresholdCondition = new (50.0, 15, true, AnomalyDetectorDirection.Both, new (7, 8.0)),
                SmartDetectionCondition = new (60.0, AnomalyDetectorDirection.Up, new (5, 6.0))
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions);

            // Set the series group conditions.

            var groupKey = new DimensionKey();

            groupKey.AddDimensionColumn("city", "Koltaka");

            var groupConditions = new MetricSeriesGroupDetectionCondition(groupKey)
            {
                ChangeThresholdCondition = new (40.0, 12, false, AnomalyDetectorDirection.Up, new (5, 6.0))
            };

            configToCreate.SeriesGroupDetectionConditions.Add(groupConditions);

            // Set the series conditions and create the configuration.

            var seriesKey = new DimensionKey();

            seriesKey.AddDimensionColumn("city", "Delhi");
            seriesKey.AddDimensionColumn("category", "Handmade");

            var seriesConditions = new MetricSingleSeriesDetectionCondition(seriesKey)
            {
                SmartDetectionCondition = new (30.0, AnomalyDetectorDirection.Both, new (3, 4.0))
            };

            configToCreate.SeriesDetectionConditions.Add(seriesConditions);

            await using var disposableConfig = await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, configToCreate);

            // Update the created configuration.

            var configToUpdate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions);

            configToUpdate.Description = description;

            configToUpdate.WholeSeriesDetectionConditions.CrossConditionsOperator = DetectionConditionsOperator.And;
            configToUpdate.WholeSeriesDetectionConditions.HardThresholdCondition = new (AnomalyDetectorDirection.Up, new (11, 12.0)) { UpperBound = 9.0 };
            configToUpdate.WholeSeriesDetectionConditions.ChangeThresholdCondition = null;
            configToUpdate.WholeSeriesDetectionConditions.SmartDetectionCondition = new (75.0, AnomalyDetectorDirection.Both, new (15, 16.0));

            var newGroupKey = new DimensionKey();

            newGroupKey.AddDimensionColumn("city", "Delhi");

            var newGroupConditions = new MetricSeriesGroupDetectionCondition(newGroupKey)
            {
                SmartDetectionCondition = new (95.0, AnomalyDetectorDirection.Both, new (25, 26.0))
            };

            configToUpdate.SeriesGroupDetectionConditions.Add(groupConditions);
            configToUpdate.SeriesGroupDetectionConditions.Add(newGroupConditions);

            configToUpdate.SeriesDetectionConditions.Clear();

            await adminClient.UpdateDetectionConfigurationAsync(disposableConfig.Id, configToUpdate);

            // Get the updated configuration and validate top-level members.

            AnomalyDetectionConfiguration updatedConfig = await adminClient.GetDetectionConfigurationAsync(disposableConfig.Id);

            Assert.That(updatedConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(updatedConfig.MetricId, Is.EqualTo(MetricId));
            Assert.That(updatedConfig.Name, Is.EqualTo(configName));
            Assert.That(updatedConfig.Description, Is.EqualTo(description));
            Assert.That(updatedConfig.SeriesDetectionConditions, Is.Not.Null.And.Empty);

            // Validate whole series detection conditions.

            MetricWholeSeriesDetectionCondition updatedWholeConditions = updatedConfig.WholeSeriesDetectionConditions;

            Assert.That(updatedWholeConditions, Is.Not.Null);
            Assert.That(updatedWholeConditions.CrossConditionsOperator, Is.EqualTo(DetectionConditionsOperator.And));
            Assert.That(updatedWholeConditions.ChangeThresholdCondition, Is.Null);

            ValidateHardThresholdCondition(updatedWholeConditions.HardThresholdCondition, AnomalyDetectorDirection.Up, 9.0, null, 11, 12.0);
            ValidateSmartDetectionCondition(updatedWholeConditions.SmartDetectionCondition, 75.0, AnomalyDetectorDirection.Both, 15, 16.0);

            // Start series group conditions validation.

            Assert.That(updatedConfig.SeriesGroupDetectionConditions, Is.Not.Null);
            Assert.That(updatedConfig.SeriesGroupDetectionConditions.Count, Is.EqualTo(2));

            // Validate first series group conditions.

            var updatedGroupConditions0 = updatedConfig.SeriesGroupDetectionConditions[0];

            Assert.That(updatedGroupConditions0, Is.Not.Null);

            ValidateGroupKey(updatedGroupConditions0.SeriesGroupKey);

            Dictionary<string, string> dimensionColumns = updatedGroupConditions0.SeriesGroupKey.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(1));
            Assert.That(dimensionColumns["city"], Is.EqualTo("Koltaka"));

            Assert.That(updatedGroupConditions0.CrossConditionsOperator, Is.Null);
            Assert.That(updatedGroupConditions0.HardThresholdCondition, Is.Null);
            Assert.That(updatedGroupConditions0.SmartDetectionCondition, Is.Null);

            ValidateChangeThresholdCondition(updatedGroupConditions0.ChangeThresholdCondition, 40.0, 12, false, AnomalyDetectorDirection.Up, 5, 6.0);

            // Validate last series group conditions.

            var updatedGroupConditions1 = updatedConfig.SeriesGroupDetectionConditions[1];

            Assert.That(updatedGroupConditions1, Is.Not.Null);

            ValidateGroupKey(updatedGroupConditions1.SeriesGroupKey);

            dimensionColumns = updatedGroupConditions1.SeriesGroupKey.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(1));
            Assert.That(dimensionColumns["city"], Is.EqualTo("Delhi"));

            Assert.That(updatedGroupConditions1.CrossConditionsOperator, Is.Null);
            Assert.That(updatedGroupConditions1.HardThresholdCondition, Is.Null);
            Assert.That(updatedGroupConditions1.ChangeThresholdCondition, Is.Null);

            ValidateSmartDetectionCondition(updatedGroupConditions1.SmartDetectionCondition, 95.0, AnomalyDetectorDirection.Both, 25, 26.0);
        }

        [RecordedTest]
        public async Task GetDetectonConfigurations()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

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
        public async Task DeleteDetectionConfiguration()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string configName = Recording.GenerateAlphaNumericId("config");

            var wholeConditions = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = new (AnomalyDetectorDirection.Up, new (1, 2.0))
                {
                    UpperBound = 10.0
                }
            };

            var configToCreate = new AnomalyDetectionConfiguration(MetricId, configName, wholeConditions);

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

        private void ValidateChangeThresholdCondition(ChangeThresholdCondition condition, double changePercentage, int shiftPoint, bool isWithinRange, AnomalyDetectorDirection direction, int minimumNumber, double minimumRatio)
        {
            Assert.That(condition, Is.Not.Null);
            Assert.That(condition.AnomalyDetectorDirection, Is.EqualTo(direction));
            Assert.That(condition.IsWithinRange, Is.EqualTo(isWithinRange));
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
                Assert.That(conditions.CrossConditionsOperator, Is.Not.Null);
            }
            else
            {
                Assert.That(conditions.CrossConditionsOperator, Is.Null);
            }
        }
    }
}
