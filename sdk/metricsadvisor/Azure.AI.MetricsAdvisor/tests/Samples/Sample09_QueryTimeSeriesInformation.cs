// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [Test]
        public async Task GetDimensionValuesAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string metricId = MetricId;

            string dimensionName = "city";
            var options = new GetDimensionValuesOptions() { TopCount = 10 };

            Console.WriteLine($"The dimension '{dimensionName}' can assume the following values (limited to 10):");

            int dimensionValueCount = 0;

            await foreach (string dimensionValue in client.GetDimensionValuesAsync(metricId, dimensionName, options))
            {
                Console.WriteLine($"  {dimensionValue}");

                // Print at most 10 values.
                if (++dimensionValueCount >= 10)
                {
                    break;
                }
            }
        }

        [Test]
        public async Task GetValuesOfDimensionWithAnomaliesAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string detectionConfigurationId = DetectionConfigurationId;

            string dimensionName = "city";

            var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endTime = DateTimeOffset.UtcNow;
            var options = new GetValuesOfDimensionWithAnomaliesOptions(startTime, endTime)
            {
                TopCount = 10
            };

            Console.WriteLine($"The dimension '{dimensionName}' assumed the following values on anomalous data points (limited to 10):");

            int dimensionValueCount = 0;

            await foreach (string dimensionValue in client.GetValuesOfDimensionWithAnomaliesAsync(detectionConfigurationId, dimensionName, options))
            {
                Console.WriteLine($"  {dimensionValue}");

                // Print at most 10 values.
                if (++dimensionValueCount >= 10)
                {
                    break;
                }
            }
        }

        [Test]
        public async Task GetMetricEnrichmentStatusesAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string metricId = MetricId;

            var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endTime = DateTimeOffset.UtcNow;
            var options = new GetMetricEnrichmentStatusesOptions(startTime, endTime) { TopCount = 5 };

            int statusCount = 0;

            await foreach (EnrichmentStatus enrichmentStatus in client.GetMetricEnrichmentStatusesAsync(metricId, options))
            {
                Console.WriteLine($"Ingestion timestamp: {enrichmentStatus.Timestamp}");
                Console.WriteLine($"Status: {enrichmentStatus.Status}");
                Console.WriteLine($"Message: {enrichmentStatus.Message}");
                Console.WriteLine();

                // Print at most 5 entries.
                if (++statusCount >= 5)
                {
                    break;
                }
            }
        }

        [Test]
        public async Task GetMetricSeriesDefinitionsAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string metricId = MetricId;

            var activeSince = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var options = new GetMetricSeriesDefinitionsOptions(activeSince) { TopCount = 5 };

            int definitionCount = 0;

            await foreach (MetricSeriesDefinition definition in client.GetMetricSeriesDefinitionsAsync(metricId, options))
            {
                Console.WriteLine("Time series key:");

                foreach (KeyValuePair<string, string> keyValuePair in definition.SeriesKey.AsDictionary())
                {
                    Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                }

                Console.WriteLine();

                // Print at most 5 time series.
                if (++definitionCount >= 5)
                {
                    break;
                }
            }
        }

        [Test]
        public async Task GetMetricSeriesDataAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string metricId = MetricId;

            var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endTime = DateTimeOffset.UtcNow;
            var options = new GetMetricSeriesDataOptions(startTime, endTime);

            // Only the two time series with the keys specified below will be returned.

            var seriesKey1 = new DimensionKey();
            seriesKey1.AddDimensionColumn("city", "Belo Horizonte");
            seriesKey1.AddDimensionColumn("category", "__SUM__");

            var seriesKey2 = new DimensionKey();
            seriesKey2.AddDimensionColumn("city", "Hong Kong");
            seriesKey2.AddDimensionColumn("category", "Industrial & Scientific");

            options.SeriesToFilter.Add(seriesKey1);
            options.SeriesToFilter.Add(seriesKey2);

            await foreach (MetricSeriesData seriesData in client.GetMetricSeriesDataAsync(metricId, options))
            {
                Console.WriteLine($"Time series metric ID: {seriesData.Definition.MetricId}");
                Console.WriteLine("Time series key:");

                foreach (KeyValuePair<string, string> keyValuePair in seriesData.Definition.SeriesKey.AsDictionary())
                {
                    Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                }

                Console.WriteLine("Data points:");

                // Print at most 3 points per time series.
                for (int pointIndex = 0; pointIndex < 3; pointIndex++)
                {
                    Console.WriteLine($"  Point {pointIndex}:");
                    Console.WriteLine($"   - Timestamp: {seriesData.Timestamps[pointIndex]}");
                    Console.WriteLine($"   - Value: {seriesData.Values[pointIndex]}");
                }

                Console.WriteLine();
            }
        }

        [Test]
        public async Task GetMetricEnrichedSeriesDataAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string detectionConfigurationId = DetectionConfigurationId;

            // Only the two time series with the keys specified below will be returned.

            var seriesKey1 = new DimensionKey();
            seriesKey1.AddDimensionColumn("city", "Belo Horizonte");
            seriesKey1.AddDimensionColumn("category", "__SUM__");

            var seriesKey2 = new DimensionKey();
            seriesKey2.AddDimensionColumn("city", "Hong Kong");
            seriesKey2.AddDimensionColumn("category", "Industrial & Scientific");

            var seriesKeys = new List<DimensionKey>() { seriesKey1, seriesKey2 };

            var startTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endTime = DateTimeOffset.UtcNow;

            await foreach (MetricEnrichedSeriesData seriesData in client.GetMetricEnrichedSeriesDataAsync(seriesKeys, detectionConfigurationId, startTime, endTime))
            {
                Console.WriteLine("Time series key:");

                foreach (KeyValuePair<string, string> keyValuePair in seriesData.SeriesKey.AsDictionary())
                {
                    Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                }

                Console.WriteLine("Data points:");

                // Print at most 2 points per time series.
                for (int pointIndex = 0; pointIndex < 2; pointIndex++)
                {
                    Console.WriteLine($"  Point {pointIndex}:");
                    Console.WriteLine($"   - Timestamp: {seriesData.Timestamps[pointIndex]}");
                    Console.WriteLine($"   - Value: {seriesData.Values[pointIndex]}");
                    Console.WriteLine($"   - Expected value: {seriesData.ExpectedValues[pointIndex]}");
                    Console.WriteLine($"   - Lower boundary: {seriesData.LowerBoundaries[pointIndex]}");
                    Console.WriteLine($"   - Upper boundary: {seriesData.UpperBoundaries[pointIndex]}");
                    Console.WriteLine($"   - Is this point an anomaly: {seriesData.IsAnomaly[pointIndex]}");
                    Console.WriteLine($"   - Period: {seriesData.Periods[pointIndex]}");
                }

                Console.WriteLine();
            }
        }
    }
}
