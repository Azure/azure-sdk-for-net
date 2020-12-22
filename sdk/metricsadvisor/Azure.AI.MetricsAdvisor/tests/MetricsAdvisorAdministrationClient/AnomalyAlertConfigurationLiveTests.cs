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
        public async Task CreateAndGetAlertConfigurationWithWholeSeriesScope()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var scope = MetricAnomalyAlertScope.GetScopeForWholeSeries();
            var metricAlertConfig = new MetricAnomalyAlertConfiguration(DetectionConfigurationId, scope);

            string configName = Recording.GenerateAlphaNumericId("config");
            var metricAlertConfigs = new List<MetricAnomalyAlertConfiguration>() { metricAlertConfig };

            var configToCreate = new AnomalyAlertConfiguration(configName, new List<string>(), metricAlertConfigs);

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            AnomalyAlertConfiguration createdConfig = await adminClient.GetAlertConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.CrossMetricsOperator, Is.Null);
            Assert.That(createdConfig.IdsOfHooksToAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);

            MetricAnomalyAlertConfiguration createdMetricAlertConfig = createdConfig.MetricAlertConfigurations.Single();

            Assert.That(createdMetricAlertConfig.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));

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

            DimensionKey groupKey = new DimensionKey();
            groupKey.AddDimensionColumn("city", "Delhi");

            var scope = MetricAnomalyAlertScope.GetScopeForSeriesGroup(groupKey);
            var metricAlertConfig = new MetricAnomalyAlertConfiguration(DetectionConfigurationId, scope);

            string configName = Recording.GenerateAlphaNumericId("config");
            var metricAlertConfigs = new List<MetricAnomalyAlertConfiguration>() { metricAlertConfig };

            var configToCreate = new AnomalyAlertConfiguration(configName, new List<string>(), metricAlertConfigs);

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            AnomalyAlertConfiguration createdConfig = await adminClient.GetAlertConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.CrossMetricsOperator, Is.Null);
            Assert.That(createdConfig.IdsOfHooksToAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);

            MetricAnomalyAlertConfiguration createdMetricAlertConfig = createdConfig.MetricAlertConfigurations.Single();

            Assert.That(createdMetricAlertConfig.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));

            Assert.That(createdMetricAlertConfig.AlertScope, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.SeriesGroup));
            Assert.That(createdMetricAlertConfig.AlertScope.TopNGroupInScope, Is.Null);

            ValidateGroupKey(createdMetricAlertConfig.AlertScope.SeriesGroupInScope);

            Dictionary<string, string> dimensionColumns = createdMetricAlertConfig.AlertScope.SeriesGroupInScope.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(1));
            Assert.That(dimensionColumns["city"], Is.EqualTo("Delhi"));

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

            var topNGroup = new TopNGroupScope(30, 20, 10);
            var scope = MetricAnomalyAlertScope.GetScopeForTopNGroup(topNGroup);
            var metricAlertConfig = new MetricAnomalyAlertConfiguration(DetectionConfigurationId, scope);

            string configName = Recording.GenerateAlphaNumericId("config");
            var metricAlertConfigs = new List<MetricAnomalyAlertConfiguration>() { metricAlertConfig };

            var configToCreate = new AnomalyAlertConfiguration(configName, new List<string>(), metricAlertConfigs);

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            AnomalyAlertConfiguration createdConfig = await adminClient.GetAlertConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.CrossMetricsOperator, Is.Null);
            Assert.That(createdConfig.IdsOfHooksToAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);

            MetricAnomalyAlertConfiguration createdMetricAlertConfig = createdConfig.MetricAlertConfigurations.Single();

            Assert.That(createdMetricAlertConfig.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));

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

            string hookName0 = Recording.GenerateAlphaNumericId("hook");
            string hookName1 = Recording.GenerateAlphaNumericId("hook");

            var hookToCreate0 = new WebNotificationHook(hookName0, "http://contoso.com");
            var hookToCreate1 = new WebNotificationHook(hookName1, "http://contoso.com");

            await using var disposableHook0 = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate0);
            await using var disposableHook1 = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate1);

            var scope = MetricAnomalyAlertScope.GetScopeForWholeSeries();
            var metricAlertConfig = new MetricAnomalyAlertConfiguration(DetectionConfigurationId, scope)
            {
                AlertSnoozeCondition = new MetricAnomalyAlertSnoozeCondition(12, SnoozeScope.Series, true),
                AlertConditions = new MetricAnomalyAlertConditions()
                {
                    MetricBoundaryCondition = new MetricBoundaryCondition(BoundaryDirection.Both)
                    {
                        UpperBound = 20.0,
                        LowerBound = 10.0,
                        CompanionMetricId = MetricId,
                        TriggerForMissing = true
                    },
                    SeverityCondition = new SeverityCondition(AnomalySeverity.Low, AnomalySeverity.Medium)
                }
            };

            string configName = Recording.GenerateAlphaNumericId("config");
            var description = "This hook was created to test the .NET client.";
            var hookIds = new List<string>(){ disposableHook0.Id, disposableHook1.Id };
            var metricAlertConfigs = new List<MetricAnomalyAlertConfiguration>() { metricAlertConfig };

            var configToCreate = new AnomalyAlertConfiguration(configName, hookIds, metricAlertConfigs)
            {
                Description = description
            };

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            AnomalyAlertConfiguration createdConfig = await adminClient.GetAlertConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.EqualTo(description));
            Assert.That(createdConfig.CrossMetricsOperator, Is.Null);
            Assert.That(createdConfig.IdsOfHooksToAlert, Is.EqualTo(hookIds));
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);

            MetricAnomalyAlertConfiguration createdMetricAlertConfig = createdConfig.MetricAlertConfigurations.Single();

            Assert.That(createdMetricAlertConfig.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));

            Assert.That(createdMetricAlertConfig.AlertScope, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertScope.ScopeType, Is.EqualTo(MetricAnomalyAlertScopeType.WholeSeries));
            Assert.That(createdMetricAlertConfig.AlertScope.SeriesGroupInScope, Is.Null);
            Assert.That(createdMetricAlertConfig.AlertScope.TopNGroupInScope, Is.Null);

            Assert.That(createdMetricAlertConfig.AlertConditions, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition, Is.Not.Null);
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.Direction, Is.EqualTo(BoundaryDirection.Both));
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.UpperBound, Is.EqualTo(20.0));
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.LowerBound, Is.EqualTo(10.0));
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.CompanionMetricId, Is.EqualTo(MetricId));
            Assert.That(createdMetricAlertConfig.AlertConditions.MetricBoundaryCondition.TriggerForMissing, Is.True);
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

            // Configure the Metric Anomaly Alert Configurations to be used.

            var scope = MetricAnomalyAlertScope.GetScopeForWholeSeries();
            var metricAlertConfig0 = new MetricAnomalyAlertConfiguration(DetectionConfigurationId, scope)
            {
                AlertConditions = new MetricAnomalyAlertConditions()
                {
                    MetricBoundaryCondition = new MetricBoundaryCondition(BoundaryDirection.Up) { UpperBound = 20.0 }
                },
                UseDetectionResultToFilterAnomalies = true
            };
            var metricAlertConfig1 = new MetricAnomalyAlertConfiguration(DetectionConfigurationId, scope)
            {
                AlertConditions = new MetricAnomalyAlertConditions()
                {
                    MetricBoundaryCondition = new MetricBoundaryCondition(BoundaryDirection.Down) { LowerBound = 10.0 }
                }
            };

            // Create the Anomaly Alert Configuration.

            string configName = Recording.GenerateAlphaNumericId("config");
            var metricAlertConfigs = new List<MetricAnomalyAlertConfiguration>() { metricAlertConfig0, metricAlertConfig1 };

            var configToCreate = new AnomalyAlertConfiguration(configName, new List<string>(), metricAlertConfigs)
            {
                CrossMetricsOperator = MetricAnomalyAlertConfigurationsOperator.Xor
            };

            await using var disposableConfig = await DisposableAlertConfiguration.CreateAlertConfigurationAsync(adminClient, configToCreate);

            // Get the created configuration and validate top-level members.

            AnomalyAlertConfiguration createdConfig = await adminClient.GetAlertConfigurationAsync(disposableConfig.Id);

            Assert.That(createdConfig.Id, Is.EqualTo(disposableConfig.Id));
            Assert.That(createdConfig.Name, Is.EqualTo(configName));
            Assert.That(createdConfig.Description, Is.Empty);
            Assert.That(createdConfig.CrossMetricsOperator, Is.EqualTo(MetricAnomalyAlertConfigurationsOperator.Xor));
            Assert.That(createdConfig.IdsOfHooksToAlert, Is.Not.Null.And.Empty);
            Assert.That(createdConfig.MetricAlertConfigurations, Is.Not.Null);
            Assert.That(createdConfig.MetricAlertConfigurations.Count, Is.EqualTo(2));

            // Validate the first Metric Anomaly Alert Configuration.

            MetricAnomalyAlertConfiguration createdMetricAlertConfig0 = createdConfig.MetricAlertConfigurations[0];

            Assert.That(createdMetricAlertConfig0.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));

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
            Assert.That(createdMetricAlertConfig0.AlertConditions.MetricBoundaryCondition.TriggerForMissing, Is.False);
            Assert.That(createdMetricAlertConfig0.AlertConditions.SeverityCondition, Is.Null);

            Assert.That(createdMetricAlertConfig0.AlertSnoozeCondition, Is.Null);
            Assert.That(createdMetricAlertConfig0.UseDetectionResultToFilterAnomalies, Is.True);

            // Validate the second Metric Anomaly Alert Configuration.

            MetricAnomalyAlertConfiguration createdMetricAlertConfig1 = createdConfig.MetricAlertConfigurations[1];

            Assert.That(createdMetricAlertConfig1.DetectionConfigurationId, Is.EqualTo(DetectionConfigurationId));

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
            Assert.That(createdMetricAlertConfig1.AlertConditions.MetricBoundaryCondition.TriggerForMissing, Is.False);
            Assert.That(createdMetricAlertConfig1.AlertConditions.SeverityCondition, Is.Null);

            Assert.That(createdMetricAlertConfig1.AlertSnoozeCondition, Is.Null);
            Assert.That(createdMetricAlertConfig1.UseDetectionResultToFilterAnomalies, Is.False);
        }
    }
}
