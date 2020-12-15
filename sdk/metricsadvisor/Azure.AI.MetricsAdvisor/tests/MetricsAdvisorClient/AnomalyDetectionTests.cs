// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class AnomalyDetectionTests : ClientTestBase
    {
        public AnomalyDetectionTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void GetAnomaliesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetAnomaliesForDetectionConfigurationOptions(default, default);

            Assert.That(() => client.GetAnomaliesAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomaliesAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomaliesAsync("configId", options: null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetAnomalies(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetAnomalies("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetAnomalies("configId", options: null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetIncidentsValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetIncidentsForDetectionConfigurationOptions(default, default);

            Assert.That(() => client.GetIncidentsAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentsAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentsAsync("configId", options: null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetIncidents(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidents("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidents("configId", options: null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetIncidentRootCausesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetIncidentRootCausesAsync(null, "incidentId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentRootCausesAsync("", "incidentId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentRootCausesAsync("configId", null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentRootCausesAsync("configId", ""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetIncidentRootCauses(null, "incidentId"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentRootCauses("", "incidentId"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetIncidentRootCauses("configId", null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetIncidentRootCauses("configId", ""), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetIncidentRootCausesForIncidentValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetIncidentRootCausesAsync(null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetIncidentRootCauses(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetValuesOfDimensionsWithAnomaliesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetValuesOfDimensionWithAnomaliesOptions(default, default);

            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync(null, "dimensionName", options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync("", "dimensionName", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync("configId", null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync("configId", "", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomaliesAsync("configId", "dimensionName", null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetValuesOfDimensionWithAnomalies(null, "dimensionName", options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomalies("", "dimensionName", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomalies("configId", null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomalies("configId", "", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetValuesOfDimensionWithAnomalies("configId", "dimensionName", null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetMetricEnrichedSeriesDataValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var emptyList = new List<DimensionKey>();
            var seriesKeys = new List<DimensionKey>() { new DimensionKey() };

            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(null, "configId", default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(emptyList, "configId", default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(seriesKeys, null, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesDataAsync(seriesKeys, "", default, default), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetMetricEnrichedSeriesData(null, "configId", default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData(emptyList, "configId", default, default), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData(seriesKeys, null, default, default), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichedSeriesData(seriesKeys, "", default, default), Throws.InstanceOf<ArgumentException>());
        }

        private MetricsAdvisorClient GetMetricsAdvisorClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorClient(fakeEndpoint, fakeCredential);
        }
    }
}
