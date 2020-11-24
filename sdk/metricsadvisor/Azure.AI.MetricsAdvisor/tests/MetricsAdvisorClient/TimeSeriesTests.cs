// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class TimeSeriesTests : ClientTestBase
    {
        public TimeSeriesTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void GetDimensionValuesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            Assert.That(() => client.GetDimensionValuesAsync(null, "dimensionName"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetDimensionValuesAsync("", "dimensionName"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetDimensionValuesAsync("metricId", null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetDimensionValuesAsync("metricId", ""), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => client.GetDimensionValues(null, "dimensionName"), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetDimensionValues("", "dimensionName"), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetDimensionValues("metricId", null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetDimensionValues("metricId", ""), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void GetMetricSeriesDefinitionsValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetMetricSeriesDefinitionsOptions(default);

            Assert.That(() => client.GetMetricSeriesDefinitionsAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricSeriesDefinitionsAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricSeriesDefinitionsAsync("metricId", null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetMetricSeriesDefinitions(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricSeriesDefinitions("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricSeriesDefinitions("metricId", null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetMetricSeriesDataValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var seriesToFilter = new List<DimensionKey>();
            var options = new GetMetricSeriesDataOptions(seriesToFilter, default, default);

            Assert.That(() => client.GetMetricSeriesDataAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricSeriesDataAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricSeriesDataAsync("metricId", null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetMetricSeriesData(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricSeriesData("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricSeriesData("metricId", null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void GetMetricEnrichmentStatusesValidatesArguments()
        {
            MetricsAdvisorClient client = GetMetricsAdvisorClient();

            var options = new GetMetricEnrichmentStatusesOptions(default, default);

            Assert.That(() => client.GetMetricEnrichmentStatusesAsync(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichmentStatusesAsync("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichmentStatusesAsync("metricId", null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => client.GetMetricEnrichmentStatuses(null, options), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => client.GetMetricEnrichmentStatuses("", options), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => client.GetMetricEnrichmentStatuses("metricId", null), Throws.InstanceOf<ArgumentNullException>());
        }

        private MetricsAdvisorClient GetMetricsAdvisorClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorClient(fakeEndpoint, fakeCredential);
        }
    }
}
