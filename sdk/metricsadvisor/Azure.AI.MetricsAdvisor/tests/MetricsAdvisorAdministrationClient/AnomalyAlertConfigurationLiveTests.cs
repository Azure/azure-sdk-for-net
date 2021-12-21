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
    public class AnomalyAlertConfigurationLiveTests : MetricsAdvisorLiveTestBase
    {
        public AnomalyAlertConfigurationLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CreateAndGetAlertConfigurationWithWholeSeriesScope(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            await using DisposableDetectionConfiguration disposableDetectionConfig = await CreateTempDetectionConfigurationAsync(adminClient, metricId);

            var detectionConfigId = disposableDetectionConfig.Configuration.Id;
            var scope = MetricAnomalyAlertScope.CreateScopeForWholeSeries();
            var metricAlertConfig = new MetricAlertConfiguration(detectionConfigId, scope);

            string configName = Recording.GenerateAlphaNumericId("config");

            var configToCreate = new AnomalyAlertConfiguration()
            {
                Name = configName,
                DimensionsToSplitAlert = { TempDataFeedDimensionNameA },
                MetricAlertConfigurations = { metricAlertConfig }
            };

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            AnomalyAlertConfiguration createdConfig = disposableConfig.Configuration;

            Assert.That(createdConfig.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.CrossMetricsOperator, Is.Null);
            Assert.That(createdConfig.IdsOfHooksToAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.DimensionsToSplitAlert.Single(), Is.EqualTo(TempDataFeedDimensionNameA));
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);

            MetricAlertConfiguration createdMetricAlertConfig = createdConfig.MetricAlertConfigurations.Single();

            Assert.That(createdMetricAlertConfig.DetectionConfigurationId, Is.EqualTo(detectionConfigId));

            Assert.That(createdMetricAlertConfig.AlertScope, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.WholeSeries));
            Assert.That(createdMetricAlertConfig.AlertScope.SeriesGroupInScope, Is.Null);
            Assert.That(createdMetricAlertConfig.AlertScope.TopNGroupInScope, Is.Null);

            Assert.That(createdMetricAlertConfig.AlertConditions, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition, Is.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.SeverityCondition, Is.Null);

            Assert.That(createdMetricAlertConfig.AlertSnoozeCondition, Is.Null);
            Assert.That(createdMetricAlertConfig.UseDetectionResultToFilterAnomalies, Is.False);
        }

        [RecordedTest]
        public async Task CreateAndGetAlertConfigurationWithSeriesGroupScope()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            await using DisposableDetectionConfiguration disposableDetectionConfig = await CreateTempDetectionConfigurationAsync(adminClient, metricId);

            var dimensions = new Dictionary<string, string>() { { TempDataFeedDimensionNameA, "Delhi" } };
            DimensionKey groupKey = new DimensionKey(dimensions);

            var detectionConfigId = disposableDetectionConfig.Configuration.Id;
            var scope = MetricAnomalyAlertScope.CreateScopeForSeriesGroup(groupKey);
            var metricAlertConfig = new MetricAlertConfiguration(detectionConfigId, scope);

            string configName = Recording.GenerateAlphaNumericId("config");

            var configToCreate = new AnomalyAlertConfiguration()
            {
                Name = configName,
                MetricAlertConfigurations = { metricAlertConfig }
            };

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            AnomalyAlertConfiguration createdConfig = disposableConfig.Configuration;

            Assert.That(createdConfig.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.CrossMetricsOperator, Is.Null);
            Assert.That(createdConfig.IdsOfHooksToAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.DimensionsToSplitAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);

            MetricAlertConfiguration createdMetricAlertConfig = createdConfig.MetricAlertConfigurations.Single();

            Assert.That(createdMetricAlertConfig.DetectionConfigurationId, Is.EqualTo(detectionConfigId));

            Assert.That(createdMetricAlertConfig.AlertScope, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.SeriesGroup));
            Assert.That(createdMetricAlertConfig.AlertScope.TopNGroupInScope, Is.Null);

            ValidateTempDataFeedDimensionKey(createdMetricAlertConfig.AlertScope.SeriesGroupInScope, "Delhi");

            Assert.That(createdMetricAlertConfig.AlertConditions, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition, Is.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.SeverityCondition, Is.Null);

            Assert.That(createdMetricAlertConfig.AlertSnoozeCondition, Is.Null);
            Assert.That(createdMetricAlertConfig.UseDetectionResultToFilterAnomalies, Is.False);
        }

        [RecordedTest]
        public async Task CreateAndGetAlertConfigurationWithTopNScope()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            await using DisposableDetectionConfiguration disposableDetectionConfig = await CreateTempDetectionConfigurationAsync(adminClient, metricId);

            var detectionConfigId = disposableDetectionConfig.Configuration.Id;
            var scope = MetricAnomalyAlertScope.CreateScopeForTopNGroup(30, 20, 10);
            var metricAlertConfig = new MetricAlertConfiguration(detectionConfigId, scope);

            string configName = Recording.GenerateAlphaNumericId("config");

            var configToCreate = new AnomalyAlertConfiguration()
            {
                Name = configName,
                MetricAlertConfigurations = { metricAlertConfig }
            };

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            AnomalyAlertConfiguration createdConfig = disposableConfig.Configuration;

            Assert.That(createdConfig.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.CrossMetricsOperator, Is.Null);
            Assert.That(createdConfig.IdsOfHooksToAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.DimensionsToSplitAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);

            MetricAlertConfiguration createdMetricAlertConfig = createdConfig.MetricAlertConfigurations.Single();

            Assert.That(createdMetricAlertConfig.DetectionConfigurationId, Is.EqualTo(detectionConfigId));

            Assert.That(createdMetricAlertConfig.AlertScope, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.TopN));
            Assert.That(createdMetricAlertConfig.AlertScope.SeriesGroupInScope, Is.Null);

            Assert.That(createdMetricAlertConfig.AlertScope.TopNGroupInScope, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertScope.TopNGroupInScope.Top, Is.EqualTo(30));
            Assert.That(createdMetricAlertConfig.AlertScope.TopNGroupInScope.Period, Is.EqualTo(20));
            Assert.That(createdMetricAlertConfig.AlertScope.TopNGroupInScope.MinimumTopCount, Is.EqualTo(10));

            Assert.That(createdMetricAlertConfig.AlertConditions, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition, Is.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.SeverityCondition, Is.Null);

            Assert.That(createdMetricAlertConfig.AlertSnoozeCondition, Is.Null);
            Assert.That(createdMetricAlertConfig.UseDetectionResultToFilterAnomalies, Is.False);
        }

        [RecordedTest]
        public async Task CreateAndGetAlertConfigurationWithOptionalSingleMetricConfigurationMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            await using DisposableDetectionConfiguration disposableDetectionConfig = await CreateTempDetectionConfigurationAsync(adminClient, metricId);

            string hookName0 = Recording.GenerateAlphaNumericId("hook");
            string hookName1 = Recording.GenerateAlphaNumericId("hook");

            var hookToCreate0 = new EmailNotificationHook(hookName0);
            var hookToCreate1 = new EmailNotificationHook(hookName1);

            hookToCreate0.EmailsToAlert.Add("fake@email.com");
            hookToCreate1.EmailsToAlert.Add("fake@email.com");

            await using var disposableHook0 = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate0);
            await using var disposableHook1 = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate1);

            var detectionConfigId = disposableDetectionConfig.Configuration.Id;
            var scope = MetricAnomalyAlertScope.CreateScopeForWholeSeries();
            var metricAlertConfig = new MetricAlertConfiguration(detectionConfigId, scope)
            {
                AlertSnoozeCondition = new MetricAnomalyAlertSnoozeCondition(12, SnoozeScope.Series, true),
                AlertConditions = new MetricAnomalyAlertConditions()
                {
                    MetricBoundaryCondition = new MetricBoundaryCondition(BoundaryDirection.Both)
                    {
                        UpperBound = 20.0,
                        LowerBound = 10.0,
                        CompanionMetricId = metricId,
                        ShouldAlertIfDataPointMissing = true,
                        MeasureType = BoundaryMeasureType.Mean
                    },
                    SeverityCondition = new SeverityCondition(AnomalySeverity.Low, AnomalySeverity.Medium)
                }
            };

            string configName = Recording.GenerateAlphaNumericId("config");
            var description = "This hook was created to test the .NET client.";

            var configToCreate = new AnomalyAlertConfiguration()
            {
                Name = configName,
                IdsOfHooksToAlert = { disposableHook0.Hook.Id, disposableHook1.Hook.Id },
                MetricAlertConfigurations = { metricAlertConfig },
                Description = description
            };

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            AnomalyAlertConfiguration createdConfig = disposableConfig.Configuration;

            Assert.That(createdConfig.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.EqualTo(description));
            Assert.That(createdConfig.CrossMetricsOperator, Is.Null);
            Assert.That(createdConfig.IdsOfHooksToAlert.Count, Is.EqualTo(2));
            Assert.That(createdConfig.IdsOfHooksToAlert.Contains(disposableHook0.Hook.Id));
            Assert.That(createdConfig.IdsOfHooksToAlert.Contains(disposableHook1.Hook.Id));
            Assert.That(createdConfig.DimensionsToSplitAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);

            MetricAlertConfiguration createdMetricAlertConfig = createdConfig.MetricAlertConfigurations.Single();

            Assert.That(createdMetricAlertConfig.DetectionConfigurationId, Is.EqualTo(detectionConfigId));

            Assert.That(createdMetricAlertConfig.AlertScope, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.WholeSeries));
            Assert.That(createdMetricAlertConfig.AlertScope.SeriesGroupInScope, Is.Null);
            Assert.That(createdMetricAlertConfig.AlertScope.TopNGroupInScope, Is.Null);

            Assert.That(createdMetricAlertConfig.AlertConditions, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.Direction, Is.EqualTo(BoundaryDirection.Both));
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.UpperBound, Is.EqualTo(20.0));
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.LowerBound, Is.EqualTo(10.0));
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.CompanionMetricId, Is.EqualTo(metricId));
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.ShouldAlertIfDataPointMissing, Is.True);
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.MeasureType, Is.EqualTo(BoundaryMeasureType.Mean));
            Assert.That(createdMetricAlertConfig.AlertConditions.SeverityCondition, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.SeverityCondition.MinimumAlertSeverity, Is.EqualTo(AnomalySeverity.Low));
            Assert.That(createdMetricAlertConfig.AlertConditions.SeverityCondition.MaximumAlertSeverity, Is.EqualTo(AnomalySeverity.Medium));

            Assert.That(createdMetricAlertConfig.AlertSnoozeCondition, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertSnoozeCondition.AutoSnooze, Is.EqualTo(12));
            Assert.That(createdMetricAlertConfig.AlertSnoozeCondition.SnoozeScope, Is.EqualTo(SnoozeScope.Series));
            Assert.That(createdMetricAlertConfig.AlertSnoozeCondition.IsOnlyForSuccessive, Is.True);

            Assert.That(createdMetricAlertConfig.UseDetectionResultToFilterAnomalies, Is.False);
        }

        [RecordedTest]
        public async Task CreateAndGetAlertConfigurationWithMultipleMetricConfigurations()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            await using DisposableDetectionConfiguration disposableDetectionConfig = await CreateTempDetectionConfigurationAsync(adminClient, metricId);

            // Configure the Metric Alert Configurations to be used.

            var detectionConfigId = disposableDetectionConfig.Configuration.Id;
            var scope = MetricAnomalyAlertScope.CreateScopeForWholeSeries();
            var metricAlertConfig0 = new MetricAlertConfiguration(detectionConfigId, scope)
            {
                AlertConditions = new MetricAnomalyAlertConditions()
                {
                    MetricBoundaryCondition = new MetricBoundaryCondition(BoundaryDirection.Up) { UpperBound = 20.0 }
                },
                UseDetectionResultToFilterAnomalies = true
            };
            var metricAlertConfig1 = new MetricAlertConfiguration(detectionConfigId, scope)
            {
                AlertConditions = new MetricAnomalyAlertConditions()
                {
                    MetricBoundaryCondition = new MetricBoundaryCondition(BoundaryDirection.Down) { LowerBound = 10.0 }
                }
            };

            // Create the Anomaly Alert Configuration.

            string configName = Recording.GenerateAlphaNumericId("config");

            var configToCreate = new AnomalyAlertConfiguration()
            {
                Name = configName,
                MetricAlertConfigurations = { metricAlertConfig0, metricAlertConfig1 },
                CrossMetricsOperator = MetricAlertConfigurationsOperator.Xor
            };

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            // Get the created configuration and validate top-level members.

            AnomalyAlertConfiguration createdConfig = disposableConfig.Configuration;

            Assert.That(createdConfig.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.CrossMetricsOperator, Is.EqualTo(MetricAlertConfigurationsOperator.Xor));
            Assert.That(createdConfig.IdsOfHooksToAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.DimensionsToSplitAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);
            Assert.That(createdConfig.MetricAlertConfigurations.Count, Is.EqualTo(2));

            // Validate the first Metric Alert Configuration.

            MetricAlertConfiguration createdMetricAlertConfig0 = createdConfig.MetricAlertConfigurations[0];

            Assert.That(createdMetricAlertConfig0.DetectionConfigurationId, Is.EqualTo(detectionConfigId));

            Assert.That(createdMetricAlertConfig0.AlertScope, Is.Not.Null);
            Assert.That(createdMetricAlertConfig0.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.WholeSeries));
            Assert.That(createdMetricAlertConfig0.AlertScope.SeriesGroupInScope, Is.Null);
            Assert.That(createdMetricAlertConfig0.AlertScope.TopNGroupInScope, Is.Null);

            Assert.That(createdMetricAlertConfig0.AlertConditions, Is.Not.Null);
            Assert.That(createdMetricAlertConfig0.AlertConditions.MetricBoundaryCondition, Is.Not.Null);
            Assert.That(createdMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.Direction, Is.EqualTo(BoundaryDirection.Up));
            Assert.That(createdMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.UpperBound, Is.EqualTo(20.0));
            Assert.That(createdMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.LowerBound, Is.Null);
            Assert.That(createdMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.CompanionMetricId, Is.Null);
            Assert.That(createdMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.ShouldAlertIfDataPointMissing, Is.False);
            Assert.That(createdMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.MeasureType, Is.EqualTo(BoundaryMeasureType.Value));
            Assert.That(createdMetricAlertConfig0.AlertConditions.SeverityCondition, Is.Null);

            Assert.That(createdMetricAlertConfig0.AlertSnoozeCondition, Is.Null);
            Assert.That(createdMetricAlertConfig0.UseDetectionResultToFilterAnomalies, Is.True);

            // Validate the second Metric Alert Configuration.

            MetricAlertConfiguration createdMetricAlertConfig1 = createdConfig.MetricAlertConfigurations[1];

            Assert.That(createdMetricAlertConfig1.DetectionConfigurationId, Is.EqualTo(detectionConfigId));

            Assert.That(createdMetricAlertConfig1.AlertScope, Is.Not.Null);
            Assert.That(createdMetricAlertConfig1.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.WholeSeries));
            Assert.That(createdMetricAlertConfig1.AlertScope.SeriesGroupInScope, Is.Null);
            Assert.That(createdMetricAlertConfig1.AlertScope.TopNGroupInScope, Is.Null);

            Assert.That(createdMetricAlertConfig1.AlertConditions, Is.Not.Null);
            Assert.That(createdMetricAlertConfig1.AlertConditions.MetricBoundaryCondition, Is.Not.Null);
            Assert.That(createdMetricAlertConfig1.AlertConditions.MetricBoundaryCondition.Direction, Is.EqualTo(BoundaryDirection.Down));
            Assert.That(createdMetricAlertConfig1.AlertConditions.MetricBoundaryCondition.UpperBound, Is.Null);
            Assert.That(createdMetricAlertConfig1.AlertConditions.MetricBoundaryCondition.LowerBound, Is.EqualTo(10.0));
            Assert.That(createdMetricAlertConfig1.AlertConditions.MetricBoundaryCondition.CompanionMetricId, Is.Null);
            Assert.That(createdMetricAlertConfig1.AlertConditions.MetricBoundaryCondition.ShouldAlertIfDataPointMissing, Is.False);
            Assert.That(createdMetricAlertConfig1.AlertConditions.MetricBoundaryCondition.MeasureType, Is.EqualTo(BoundaryMeasureType.Value));
            Assert.That(createdMetricAlertConfig1.AlertConditions.SeverityCondition, Is.Null);

            Assert.That(createdMetricAlertConfig1.AlertSnoozeCondition, Is.Null);
            Assert.That(createdMetricAlertConfig1.UseDetectionResultToFilterAnomalies, Is.False);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateAlertConfigurationWithMinimumSetup(bool useTokenCrendential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCrendential);
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            await using DisposableDetectionConfiguration disposableDetectionConfig = await CreateTempDetectionConfigurationAsync(adminClient, metricId);

            // Configure the Metric Alert Configurations to be used.

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var hookToCreate = new EmailNotificationHook(hookName) { EmailsToAlert = { "fake@email.com" } };

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            var detectionConfigId = disposableDetectionConfig.Configuration.Id;
            var scope = MetricAnomalyAlertScope.CreateScopeForWholeSeries();
            var metricAlertConfig0 = new MetricAlertConfiguration(detectionConfigId, scope)
            {
                AlertSnoozeCondition = new MetricAnomalyAlertSnoozeCondition(12, SnoozeScope.Series, true),
                AlertConditions = new MetricAnomalyAlertConditions()
                {
                    MetricBoundaryCondition = new MetricBoundaryCondition(BoundaryDirection.Both)
                    {
                        UpperBound = 20.0,
                        LowerBound = 10.0,
                        CompanionMetricId = metricId,
                        ShouldAlertIfDataPointMissing = true
                    },
                    SeverityCondition = new SeverityCondition(AnomalySeverity.Low, AnomalySeverity.Medium)
                }
            };
            var metricAlertConfig1 = new MetricAlertConfiguration(detectionConfigId, scope)
            {
                UseDetectionResultToFilterAnomalies = true
            };

            // Create the Anomaly Alert Configuration.

            string configName = Recording.GenerateAlphaNumericId("config");
            var hookIds = new List<string>() { disposableHook.Hook.Id };

            var configToCreate = new AnomalyAlertConfiguration()
            {
                Name = configName,
                IdsOfHooksToAlert = { disposableHook.Hook.Id },
                MetricAlertConfigurations = { metricAlertConfig0, metricAlertConfig1 },
                CrossMetricsOperator = MetricAlertConfigurationsOperator.Xor
            };

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            // Update the created configuration.

            AnomalyAlertConfiguration configToUpdate = disposableConfig.Configuration;

            configToUpdate.CrossMetricsOperator = MetricAlertConfigurationsOperator.Or;

            AnomalyAlertConfiguration updatedConfig = await adminClient.UpdateAlertConfigurationAsync(configToUpdate);

            // Validate top-level members.

            Assert.That(updatedConfig.Id, Is.EqualTo(configToUpdate.Id));
            Assert.That(updatedConfig.Name, Is.EqualTo(configName));
            Assert.That(updatedConfig.Description, Is.Empty);
            Assert.That(updatedConfig.CrossMetricsOperator, Is.EqualTo(MetricAlertConfigurationsOperator.Or));
            Assert.That(updatedConfig.IdsOfHooksToAlert, Is.EqualTo(hookIds));
            Assert.That(updatedConfig.DimensionsToSplitAlert, Is.Not.Null.And.Empty);
            Assert.That(updatedConfig.MetricAlertConfigurations, Is.Not.Null);
            Assert.That(updatedConfig.MetricAlertConfigurations.Count, Is.EqualTo(2));

            // Validate the first Metric Alert Configuration.

            MetricAlertConfiguration updatedMetricAlertConfig0 = updatedConfig.MetricAlertConfigurations[0];

            Assert.That(updatedMetricAlertConfig0.DetectionConfigurationId, Is.EqualTo(detectionConfigId));

            Assert.That(updatedMetricAlertConfig0.AlertScope, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig0.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.WholeSeries));
            Assert.That(updatedMetricAlertConfig0.AlertScope.SeriesGroupInScope, Is.Null);
            Assert.That(updatedMetricAlertConfig0.AlertScope.TopNGroupInScope, Is.Null);

            Assert.That(updatedMetricAlertConfig0.AlertConditions, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.Direction, Is.EqualTo(BoundaryDirection.Both));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.UpperBound, Is.EqualTo(20.0));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.LowerBound, Is.EqualTo(10.0));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.CompanionMetricId, Is.EqualTo(metricId));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.ShouldAlertIfDataPointMissing, Is.True);
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.MeasureType, Is.EqualTo(BoundaryMeasureType.Value));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.SeverityCondition, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig0.AlertConditions.SeverityCondition.MinimumAlertSeverity, Is.EqualTo(AnomalySeverity.Low));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.SeverityCondition.MaximumAlertSeverity, Is.EqualTo(AnomalySeverity.Medium));

            Assert.That(updatedMetricAlertConfig0.AlertSnoozeCondition, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig0.AlertSnoozeCondition.AutoSnooze, Is.EqualTo(12));
            Assert.That(updatedMetricAlertConfig0.AlertSnoozeCondition.SnoozeScope, Is.EqualTo(SnoozeScope.Series));
            Assert.That(updatedMetricAlertConfig0.AlertSnoozeCondition.IsOnlyForSuccessive, Is.True);

            Assert.That(updatedMetricAlertConfig0.UseDetectionResultToFilterAnomalies, Is.False);

            // Validate the second Metric Alert Configuration.

            MetricAlertConfiguration updatedMetricAlertConfig1 = updatedConfig.MetricAlertConfigurations[1];

            Assert.That(updatedMetricAlertConfig1.DetectionConfigurationId, Is.EqualTo(detectionConfigId));

            Assert.That(updatedMetricAlertConfig1.AlertScope, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig1.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.WholeSeries));
            Assert.That(updatedMetricAlertConfig1.AlertScope.SeriesGroupInScope, Is.Null);
            Assert.That(updatedMetricAlertConfig1.AlertScope.TopNGroupInScope, Is.Null);

            Assert.That(updatedMetricAlertConfig1.AlertConditions, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig1.AlertConditions.MetricBoundaryCondition, Is.Null);
            Assert.That(updatedMetricAlertConfig1.AlertConditions.SeverityCondition, Is.Null);
            Assert.That(updatedMetricAlertConfig1.AlertSnoozeCondition, Is.Null);
            Assert.That(updatedMetricAlertConfig1.UseDetectionResultToFilterAnomalies, Is.True);
        }

        [RecordedTest]
        public async Task UpdateAlertConfigurationWithEveryMember()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            await using DisposableDetectionConfiguration disposableDetectionConfig = await CreateTempDetectionConfigurationAsync(adminClient, metricId);

            // Configure the Metric Alert Configurations to be used.

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var hookToCreate = new EmailNotificationHook(hookName) { EmailsToAlert = { "fake@email.com" } };

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            var detectionConfigId = disposableDetectionConfig.Configuration.Id;
            var scope = MetricAnomalyAlertScope.CreateScopeForWholeSeries();
            var metricAlertConfig0 = new MetricAlertConfiguration(detectionConfigId, scope)
            {
                AlertSnoozeCondition = new MetricAnomalyAlertSnoozeCondition(12, SnoozeScope.Series, true),
                AlertConditions = new MetricAnomalyAlertConditions()
                {
                    MetricBoundaryCondition = new MetricBoundaryCondition(BoundaryDirection.Both)
                    {
                        UpperBound = 20.0,
                        LowerBound = 10.0,
                        CompanionMetricId = metricId,
                        ShouldAlertIfDataPointMissing = true
                    },
                    SeverityCondition = new SeverityCondition(AnomalySeverity.Low, AnomalySeverity.Medium)
                }
            };
            var metricAlertConfig1 = new MetricAlertConfiguration(detectionConfigId, scope)
            {
                UseDetectionResultToFilterAnomalies = true
            };

            // Create the Anomaly Alert Configuration.

            string configName = Recording.GenerateAlphaNumericId("config");
            var description = "This hook was created to test the .NET client.";
            var hookIds = new List<string>() { disposableHook.Hook.Id };
            var metricAlertConfigs = new List<MetricAlertConfiguration>() { metricAlertConfig0, metricAlertConfig1 };

            var configToCreate = new AnomalyAlertConfiguration()
            {
                Name = configName,
                IdsOfHooksToAlert = { disposableHook.Hook.Id },
                MetricAlertConfigurations = { metricAlertConfig0, metricAlertConfig1 },
                CrossMetricsOperator = MetricAlertConfigurationsOperator.Xor
            };

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            // Update the created configuration.

            AnomalyAlertConfiguration configToUpdate = disposableConfig.Configuration;

            configToUpdate.Description = description;
            configToUpdate.IdsOfHooksToAlert.Clear();
            configToUpdate.DimensionsToSplitAlert.Add(TempDataFeedDimensionNameA);
            configToUpdate.CrossMetricsOperator = MetricAlertConfigurationsOperator.And;
            configToUpdate.MetricAlertConfigurations.RemoveAt(1);

            var newScope = MetricAnomalyAlertScope.CreateScopeForTopNGroup(50, 40, 30);
            var newMetricAlertConfig = new MetricAlertConfiguration(detectionConfigId, newScope)
            {
                AlertSnoozeCondition = new MetricAnomalyAlertSnoozeCondition(4, SnoozeScope.Metric, true),
                UseDetectionResultToFilterAnomalies = true
            };
            configToUpdate.MetricAlertConfigurations.Add(newMetricAlertConfig);

            MetricAlertConfiguration metricAlertConfigToUpdate = configToUpdate.MetricAlertConfigurations[0];

            metricAlertConfigToUpdate.AlertConditions.MetricBoundaryCondition.UpperBound = 15.0;
            metricAlertConfigToUpdate.AlertConditions.MetricBoundaryCondition.LowerBound = 5.0;
            metricAlertConfigToUpdate.AlertConditions.MetricBoundaryCondition.CompanionMetricId = null;
            metricAlertConfigToUpdate.AlertConditions.MetricBoundaryCondition.ShouldAlertIfDataPointMissing = false;
            metricAlertConfigToUpdate.AlertConditions.MetricBoundaryCondition.MeasureType = BoundaryMeasureType.Mean;

            metricAlertConfigToUpdate.AlertConditions.SeverityCondition = new SeverityCondition(AnomalySeverity.Medium, AnomalySeverity.High);

            metricAlertConfigToUpdate.AlertSnoozeCondition = null;

            AnomalyAlertConfiguration updatedConfig = await adminClient.UpdateAlertConfigurationAsync(configToUpdate);

            // Validate top-level members.

            Assert.That(updatedConfig.Id, Is.EqualTo(configToUpdate.Id));
            Assert.That(updatedConfig.Name, Is.EqualTo(configName));
            Assert.That(updatedConfig.Description, Is.EqualTo(description));
            Assert.That(updatedConfig.CrossMetricsOperator, Is.EqualTo(MetricAlertConfigurationsOperator.And));
            Assert.That(updatedConfig.IdsOfHooksToAlert, Is.Not.Null.And.Empty);
            Assert.That(updatedConfig.DimensionsToSplitAlert.Single(), Is.EqualTo(TempDataFeedDimensionNameA));
            Assert.That(updatedConfig.MetricAlertConfigurations, Is.Not.Null);

            // Validate the first Metric Alert Configuration.

            MetricAlertConfiguration updatedMetricAlertConfig0 = updatedConfig.MetricAlertConfigurations[0];

            Assert.That(updatedMetricAlertConfig0.DetectionConfigurationId, Is.EqualTo(detectionConfigId));

            Assert.That(updatedMetricAlertConfig0.AlertScope, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig0.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.WholeSeries));
            Assert.That(updatedMetricAlertConfig0.AlertScope.SeriesGroupInScope, Is.Null);
            Assert.That(updatedMetricAlertConfig0.AlertScope.TopNGroupInScope, Is.Null);

            Assert.That(updatedMetricAlertConfig0.AlertConditions, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.Direction, Is.EqualTo(BoundaryDirection.Both));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.UpperBound, Is.EqualTo(15.0));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.LowerBound, Is.EqualTo(5.0));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.CompanionMetricId, Is.Null);
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.ShouldAlertIfDataPointMissing, Is.False);
            Assert.That(updatedMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.MeasureType, Is.EqualTo(BoundaryMeasureType.Mean));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.SeverityCondition, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig0.AlertConditions.SeverityCondition.MinimumAlertSeverity, Is.EqualTo(AnomalySeverity.Medium));
            Assert.That(updatedMetricAlertConfig0.AlertConditions.SeverityCondition.MaximumAlertSeverity, Is.EqualTo(AnomalySeverity.High));

            Assert.That(updatedMetricAlertConfig0.AlertSnoozeCondition, Is.Null);
            Assert.That(updatedMetricAlertConfig0.UseDetectionResultToFilterAnomalies, Is.False);

            // Validate the second Metric Alert Configuration.

            MetricAlertConfiguration updatedMetricAlertConfig1 = updatedConfig.MetricAlertConfigurations[1];

            Assert.That(updatedMetricAlertConfig1.DetectionConfigurationId, Is.EqualTo(detectionConfigId));

            Assert.That(updatedMetricAlertConfig1.AlertScope, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig1.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.TopN));
            Assert.That(updatedMetricAlertConfig1.AlertScope.SeriesGroupInScope, Is.Null);
            Assert.That(updatedMetricAlertConfig1.AlertScope.TopNGroupInScope, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig1.AlertScope.TopNGroupInScope.Top, Is.EqualTo(50));
            Assert.That(updatedMetricAlertConfig1.AlertScope.TopNGroupInScope.Period, Is.EqualTo(40));
            Assert.That(updatedMetricAlertConfig1.AlertScope.TopNGroupInScope.MinimumTopCount, Is.EqualTo(30));

            Assert.That(updatedMetricAlertConfig1.AlertConditions, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig1.AlertConditions.MetricBoundaryCondition, Is.Null);
            Assert.That(updatedMetricAlertConfig1.AlertConditions.SeverityCondition, Is.Null);

            Assert.That(updatedMetricAlertConfig1.AlertSnoozeCondition, Is.Not.Null);
            Assert.That(updatedMetricAlertConfig1.AlertSnoozeCondition.AutoSnooze, Is.EqualTo(4));
            Assert.That(updatedMetricAlertConfig1.AlertSnoozeCondition.SnoozeScope, Is.EqualTo(SnoozeScope.Metric));
            Assert.That(updatedMetricAlertConfig1.AlertSnoozeCondition.IsOnlyForSuccessive, Is.True);

            Assert.That(updatedMetricAlertConfig1.UseDetectionResultToFilterAnomalies, Is.True);
        }

        [RecordedTest]
        public async Task UpdateRootLevelMembersWithNullSetsToDefault()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            await using DisposableDetectionConfiguration disposableDetectionConfig = await CreateTempDetectionConfigurationAsync(adminClient, metricId);
            var detectionConfigId = disposableDetectionConfig.Configuration.Id;

            string configName = Recording.GenerateAlphaNumericId("config");

            var configToCreate = new AnomalyAlertConfiguration()
            {
                Name = configName,
                Description = "description",
                MetricAlertConfigurations =
                {
                    new MetricAlertConfiguration(detectionConfigId, MetricAnomalyAlertScope.CreateScopeForWholeSeries())
                }
            };

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            AnomalyAlertConfiguration configToUpdate = disposableConfig.Configuration;

            configToUpdate.Description = null;

            AnomalyAlertConfiguration updatedConfig = await adminClient.UpdateAlertConfigurationAsync(configToUpdate);

            Assert.That(updatedConfig.Description, Is.Empty);
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetAlertConfigurations(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            var configCount = 0;

            await foreach (AnomalyAlertConfiguration config in adminClient.GetAlertConfigurationsAsync(DetectionConfigurationId))
            {
                Assert.That(config.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(config.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(config.Description, Is.Not.Null);
                Assert.That(config.IdsOfHooksToAlert, Is.Not.Null);
                Assert.That(config.DimensionsToSplitAlert, Is.Not.Null);
                Assert.That(config.MetricAlertConfigurations, Is.Not.Null.And.Not.Empty);

                if (config.MetricAlertConfigurations.Count == 1)
                {
                    Assert.That(config.CrossMetricsOperator, Is.Null);
                }
                else if (config.MetricAlertConfigurations.Count == 2)
                {
                    Assert.That(config.CrossMetricsOperator, Is.Not.Null);
                    Assert.That(config.CrossMetricsOperator, Is.Not.EqualTo(default(MetricAlertConfigurationsOperator)));
                }
                else
                {
                    Assert.That(config.CrossMetricsOperator, Is.Not.Null);
                    Assert.That(config.CrossMetricsOperator, Is.Not.EqualTo(default(MetricAlertConfigurationsOperator)));
                    Assert.That(config.CrossMetricsOperator, Is.Not.EqualTo(MetricAlertConfigurationsOperator.Xor));
                }

                foreach (string hookId in config.IdsOfHooksToAlert)
                {
                    Assert.That(hookId, Is.Not.Null.And.Not.Empty);
                }

                foreach (MetricAlertConfiguration metricConfig in config.MetricAlertConfigurations)
                {
                    ValidateMetricAlertConfiguration(metricConfig);
                }

                if (++configCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(configCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public void GetAlertConfigurationsWithOptionalSkip()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var options = new GetAlertConfigurationsOptions()
            {
                Skip = SkipSamples
            };

            AsyncPageable<AnomalyAlertConfiguration> configs = adminClient.GetAlertConfigurationsAsync(DetectionConfigurationId);
            AsyncPageable<AnomalyAlertConfiguration> configsWithSkip = adminClient.GetAlertConfigurationsAsync(DetectionConfigurationId, options);
            var getConfigsCount = configs.ToEnumerableAsync().Result.Count;
            var getConfigsWithSkipCount = configsWithSkip.ToEnumerableAsync().Result.Count;

            Assert.That(getConfigsCount, Is.EqualTo(getConfigsWithSkipCount + SkipSamples));
        }

        [RecordedTest]
        public async Task GetAlertConfigurationsWithOptionalMaxPageSize()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var options = new GetAlertConfigurationsOptions()
            {
                MaxPageSize = MaxPageSizeSamples
            };

            AsyncPageable<AnomalyAlertConfiguration> configsWithMaxPageSize = adminClient.GetAlertConfigurationsAsync(DetectionConfigurationId, options);

            var configCount = 0;

            await foreach (Page<AnomalyAlertConfiguration> page in configsWithMaxPageSize.AsPages())
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
        public async Task DeleteAlertConfiguration(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);
            await using DisposableDataFeed disposableDataFeed = await CreateTempDataFeedAsync(adminClient);
            string metricId = disposableDataFeed.DataFeed.MetricIds[TempDataFeedMetricName];
            await using DisposableDetectionConfiguration disposableDetectionConfig = await CreateTempDetectionConfigurationAsync(adminClient, metricId);

            string configName = Recording.GenerateAlphaNumericId("config");
            var detectionConfigId = disposableDetectionConfig.Configuration.Id;
            var scope = MetricAnomalyAlertScope.CreateScopeForWholeSeries();
            var configToCreate = new AnomalyAlertConfiguration()
            {
                Name = configName,
                MetricAlertConfigurations = { new(detectionConfigId, scope) }
            };

            string configId = null;

            try
            {
                AnomalyAlertConfiguration createdConfig = await adminClient.CreateAlertConfigurationAsync(configToCreate);
                configId = createdConfig.Id;

                Assert.That(configId, Is.Not.Null.And.Not.Empty);
            }
            finally
            {
                if (configId != null)
                {
                    await adminClient.DeleteAlertConfigurationAsync(configId);

                    var errorCause = "Not Found";
                    Assert.That(async () => await adminClient.GetAlertConfigurationAsync(configId), Throws.InstanceOf<RequestFailedException>().With.Message.Contains(errorCause));
                }
            }
        }

        private void ValidateMetricAlertConfiguration(MetricAlertConfiguration configuration)
        {
            Assert.That(configuration.DetectionConfigurationId, Is.Not.Null.And.Not.Empty);
            Assert.That(configuration.AlertScope, Is.Not.Null);

            if (configuration.AlertScope.ScopeType == MetricAnomalyAlertScopeType.WholeSeries)
            {
                Assert.That(configuration.AlertScope.SeriesGroupInScope, Is.Null);
                Assert.That(configuration.AlertScope.TopNGroupInScope, Is.Null);
            }
            else if (configuration.AlertScope.ScopeType == MetricAnomalyAlertScopeType.SeriesGroup)
            {
                Assert.That(configuration.AlertScope.TopNGroupInScope, Is.Null);
                ValidateGroupKey(configuration.AlertScope.SeriesGroupInScope);
            }
            else if (configuration.AlertScope.ScopeType == MetricAnomalyAlertScopeType.TopN)
            {
                Assert.That(configuration.AlertScope.SeriesGroupInScope, Is.Null);
                Assert.That(configuration.AlertScope.TopNGroupInScope, Is.Not.Null);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid ScopeType value!");
            }

            Assert.That(configuration.AlertConditions, Is.Not.Null);

            MetricBoundaryCondition boundaryCondition = configuration.AlertConditions.MetricBoundaryCondition;
            SeverityCondition severityCondition = configuration.AlertConditions.SeverityCondition;

            if (boundaryCondition != null)
            {
                if (boundaryCondition.Direction == BoundaryDirection.Up)
                {
                    Assert.That(boundaryCondition.UpperBound, Is.Not.Null);
                    Assert.That(boundaryCondition.LowerBound, Is.Null);
                }
                else if (boundaryCondition.Direction == BoundaryDirection.Down)
                {
                    Assert.That(boundaryCondition.UpperBound, Is.Null);
                    Assert.That(boundaryCondition.LowerBound, Is.Not.Null);
                }
                else if (boundaryCondition.Direction == BoundaryDirection.Both)
                {
                    Assert.That(boundaryCondition.UpperBound, Is.Not.Null);
                    Assert.That(boundaryCondition.LowerBound, Is.Not.Null);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid BoundaryDirection value!");
                }

                if (boundaryCondition.CompanionMetricId != null)
                {
                    Assert.That(boundaryCondition.CompanionMetricId, Is.Not.Empty);
                }

                Assert.That(boundaryCondition.ShouldAlertIfDataPointMissing, Is.Not.Null);
            }

            if (severityCondition != null)
            {
                Assert.That(severityCondition.MinimumAlertSeverity, Is.Not.EqualTo(default(AnomalySeverity)));
                Assert.That(severityCondition.MaximumAlertSeverity, Is.Not.EqualTo(default(AnomalySeverity)));
            }

            if (configuration.AlertSnoozeCondition != null)
            {
                Assert.That(configuration.AlertSnoozeCondition.SnoozeScope, Is.Not.EqualTo(default(SnoozeScope)));
            }

            Assert.That(configuration.UseDetectionResultToFilterAnomalies, Is.Not.Null);
        }

        private async Task<DisposableDetectionConfiguration> CreateTempDetectionConfigurationAsync(MetricsAdvisorAdministrationClient adminClient, string metricId)
        {
            var config = new AnomalyDetectionConfiguration()
            {
                Name = Recording.GenerateAlphaNumericId("dataFeed"),
                MetricId = metricId,
                WholeSeriesDetectionConditions = new MetricWholeSeriesDetectionCondition()
                {
                    HardThresholdCondition = new HardThresholdCondition(AnomalyDetectorDirection.Up, new SuppressCondition(1, 1.0))
                    {
                        UpperBound = 1.0
                    }
                }
            };

            return await DisposableDetectionConfiguration.CreateDetectionConfigurationAsync(adminClient, config);
        }
    }
}
