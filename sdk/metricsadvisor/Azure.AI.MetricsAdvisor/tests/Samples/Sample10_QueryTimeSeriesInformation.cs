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
        public async Task GetMetricDimensionValuesAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string metricId = MetricId;

            string dimensionName = "Dim1";
            var options = new GetMetricDimensionValuesOptions() { MaxPageSize = 10 };

            Console.WriteLine($"The dimension '{dimensionName}' can assume the following values (limited to 10):");

            int dimensionValueCount = 0;

            await foreach (string dimensionValue in client.GetMetricDimensionValuesAsync(metricId, dimensionName, options))
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
        public async Task GetAnomalyDimensionValuesAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var client = new MetricsAdvisorClient(new Uri(endpoint), credential);

            string detectionConfigurationId = DetectionConfigurationId;

            string dimensionName = "Dim1";

            var startsOn = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endsOn = DateTimeOffset.UtcNow;
            var options = new GetAnomalyDimensionValuesOptions(startsOn, endsOn)
            {
                MaxPageSize = 10
            };

            Console.WriteLine($"The dimension '{dimensionName}' assumed the following values on anomalous data points (limited to 10):");

            int dimensionValueCount = 0;

            await foreach (string dimensionValue in client.GetAnomalyDimensionValuesAsync(detectionConfigurationId, dimensionName, options))
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

            var startsOn = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endsOn = DateTimeOffset.UtcNow;
            var options = new GetMetricEnrichmentStatusesOptions(startsOn, endsOn) { MaxPageSize = 5 };

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
            var options = new GetMetricSeriesDefinitionsOptions(activeSince) { MaxPageSize = 5 };

            int definitionCount = 0;

            await foreach (MetricSeriesDefinition definition in client.GetMetricSeriesDefinitionsAsync(metricId, options))
            {
                Console.WriteLine("Time series key:");

                foreach (KeyValuePair<string, string> keyValuePair in definition.SeriesKey)
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

            var startsOn = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endsOn = DateTimeOffset.UtcNow;
            var options = new GetMetricSeriesDataOptions(startsOn, endsOn);

            // Only the two time series with the keys specified below will be returned.

            var dimensions = new Dictionary<string, string>()
            {
                { "Dim1", "JPN" },
                { "Dim2", "__SUM__" }
            };
            var seriesKey1 = new DimensionKey(dimensions);

            dimensions = new Dictionary<string, string>()
            {
                { "Dim1", "USD" },
                { "Dim2", "US" }
            };
            var seriesKey2 = new DimensionKey(dimensions);

            options.SeriesKeys.Add(seriesKey1);
            options.SeriesKeys.Add(seriesKey2);

            await foreach (MetricSeriesData seriesData in client.GetMetricSeriesDataAsync(metricId, options))
            {
                Console.WriteLine($"Time series metric ID: {seriesData.MetricId}");
                Console.WriteLine("Time series key:");

                foreach (KeyValuePair<string, string> keyValuePair in seriesData.SeriesKey)
                {
                    Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                }

                Console.WriteLine("Data points:");

                // Print at most 3 points per time series.
                int totalPoints = seriesData.Timestamps.Count < 3 ? seriesData.Timestamps.Count : 3;

                for (int pointIndex = 0; pointIndex < totalPoints; pointIndex++)
                {
                    Console.WriteLine($"  Point {pointIndex}:");
                    Console.WriteLine($"   - Timestamp: {seriesData.Timestamps[pointIndex]}");
                    Console.WriteLine($"   - Metric value: {seriesData.MetricValues[pointIndex]}");
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

            var dimensions = new Dictionary<string, string>()
            {
                { "region", "Karachi" },
                { "category", "__SUM__" }
            };
            var seriesKey1 = new DimensionKey(dimensions);

            dimensions = new Dictionary<string, string>()
            {
                { "region", "Cairo" },
                { "category", "Shoes Handbags & Sunglasses" }
            };
            var seriesKey2 = new DimensionKey(dimensions);

            var seriesKeys = new List<DimensionKey>() { seriesKey1, seriesKey2 };

            var startsOn = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var endsOn = DateTimeOffset.UtcNow;

            await foreach (MetricEnrichedSeriesData seriesData in client.GetMetricEnrichedSeriesDataAsync(detectionConfigurationId, seriesKeys, startsOn, endsOn))
            {
                Console.WriteLine("Time series key:");

                foreach (KeyValuePair<string, string> keyValuePair in seriesData.SeriesKey)
                {
                    Console.WriteLine($"  Dimension '{keyValuePair.Key}': {keyValuePair.Value}");
                }

                Console.WriteLine("Data points:");

                // Print at most 2 points per time series.
                int totalPoints = seriesData.Timestamps.Count < 2 ? seriesData.Timestamps.Count : 2;

                for (int pointIndex = 0; pointIndex < totalPoints; pointIndex++)
                {
                    Console.WriteLine($"  Point {pointIndex}:");
                    Console.WriteLine($"   - Timestamp: {seriesData.Timestamps[pointIndex]}");
                    Console.WriteLine($"   - Metric value: {seriesData.MetricValues[pointIndex]}");
                    Console.WriteLine($"   - Expected metric value: {seriesData.ExpectedMetricValues[pointIndex]}");
                    Console.WriteLine($"   - Lower boundary: {seriesData.LowerBoundaryValues[pointIndex]}");
                    Console.WriteLine($"   - Upper boundary: {seriesData.UpperBoundaryValues[pointIndex]}");
                    Console.WriteLine($"   - Is this point an anomaly: {seriesData.IsAnomaly[pointIndex]}");
                    Console.WriteLine($"   - Period: {seriesData.Periods[pointIndex]}");
                }

                Console.WriteLine();
            }
        }
    }
}
