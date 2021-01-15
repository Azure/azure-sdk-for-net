// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorLiveTestBase : RecordedTestBase<MetricsAdvisorTestEnvironment>
    {
        public MetricsAdvisorLiveTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            Sanitizer = new MetricsAdvisorRecordedTestSanitizer();
        }

        public MetricsAdvisorLiveTestBase(bool isAsync) : base(isAsync)
        {
            Sanitizer = new MetricsAdvisorRecordedTestSanitizer();
        }

        internal const string DetectionConfigurationId = "fb5a6ed6-2b9e-4b72-8b0c-0046ead1c15c";
        internal const string IncidentId = "736eed64368bb6a372e855322a15a736-174e1756000";
        internal const string AlertConfigurationId = "204a211a-c5f4-45f3-a30e-512fb25d1d2c";
        internal const string AlertId = "17571a77000";
        internal const string MetricId = "27e3015f-04fd-44ba-a20b-bc529a0aebae";
        internal const string DataFeedId = "9860df01-e740-40ec-94a2-6351813552ba";

        protected int MaximumSamplesCount => 10;

        protected DateTimeOffset SamplingStartTime => DateTimeOffset.Parse("2020-10-01T00:00:00Z");

        protected DateTimeOffset SamplingEndTime => DateTimeOffset.Parse("2020-10-31T00:00:00Z");

        public MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            return InstrumentClient(new MetricsAdvisorAdministrationClient(
                new Uri(TestEnvironment.MetricsAdvisorUri),
                new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey),
                InstrumentClientOptions(new MetricsAdvisorClientsOptions())));
        }

        public MetricsAdvisorClient GetMetricsAdvisorClient()
        {
            return InstrumentClient(new MetricsAdvisorClient(
                new Uri(TestEnvironment.MetricsAdvisorUri),
                new MetricsAdvisorKeyCredential(TestEnvironment.MetricsAdvisorSubscriptionKey, TestEnvironment.MetricsAdvisorApiKey),
                InstrumentClientOptions(new MetricsAdvisorClientsOptions())));
        }

        protected void ValidateSeriesKey(DimensionKey seriesKey)
        {
            Assert.That(seriesKey, Is.Not.Null);

            Dictionary<string, string> dimensionColumns = seriesKey.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.EqualTo(2));
            Assert.That(dimensionColumns.ContainsKey("city"));
            Assert.That(dimensionColumns.ContainsKey("category"));

            Assert.That(dimensionColumns["city"], Is.Not.Null.And.Not.Empty);
            Assert.That(dimensionColumns["category"], Is.Not.Null.And.Not.Empty);
        }

        protected void ValidateGroupKey(DimensionKey groupKey)
        {
            Assert.That(groupKey, Is.Not.Null);

            Dictionary<string, string> dimensionColumns = groupKey.AsDictionary();

            Assert.That(dimensionColumns.Count, Is.GreaterThan(0));
            Assert.That(dimensionColumns.Count, Is.LessThanOrEqualTo(2));

            foreach (KeyValuePair<string, string> column in dimensionColumns)
            {
                Assert.That(column.Key, Is.EqualTo("city").Or.EqualTo("category"));
                Assert.That(column.Value, Is.Not.Null.And.Not.Empty);
            }
        }
    }
}
