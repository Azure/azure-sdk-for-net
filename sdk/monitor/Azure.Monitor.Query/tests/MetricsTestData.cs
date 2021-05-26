// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsTestData
    {
        private static bool _initialized;
        private readonly MonitorQueryClientTestEnvironment _testEnvironment;
        public string Name1 { get; } = "Guinness";
        public string Name2 { get; } = "Bessie";
        public TimeSpan Duration { get; } = TimeSpan.FromMinutes(15);
        public DateTimeOffset StartTime { get; }
        public string MetricName { get; }
        public string MetricNamespace { get; }
        public DateTimeOffset EndTime => StartTime.Add(Duration);

        public MetricsTestData(RecordedTestBase<MonitorQueryClientTestEnvironment> test)
        {
            _testEnvironment = test.TestEnvironment;

            var recordingUtcNow = test.Recording.UtcNow;
            // Snap to 15 minute intervals
            StartTime = recordingUtcNow.AddTicks(- Duration.Ticks - recordingUtcNow.Ticks % Duration.Ticks);

            MetricName = "CowsHappiness";
            MetricNamespace = "Cows";
        }

        public async Task InitializeAsync()
        {
            if (_testEnvironment.Mode == RecordedTestMode.Playback || _initialized)
            {
                return;
            }

            _initialized = true;
            var metricClient = new MetricsClient(_testEnvironment.MetricsEndpoint, _testEnvironment.Credential);

            while (!await MetricsPropagated(metricClient))
            {
                await SendData();

                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        private async Task SendData()
        {
            var senderClient = new MetricsSenderClient(_testEnvironment.Location, _testEnvironment.MetricsIngestionEndpoint, _testEnvironment.MetricsResource, _testEnvironment.Credential, new SenderClientOptions());

            var names = new[] {Name1, Name2};

            foreach (var name in names)
            {
                for (int i = 0; i < Duration.Minutes; i++)
                {
                    await senderClient.SendAsync(new MetricDataDocument(StartTime.AddMinutes(i), new(new(
                        MetricName,
                        MetricNamespace,
                        new[] { "Name" },
                        new SeriesValue[]
                        {
                            new(new[] {name}, 5 * i, 20 * i, 30 * i,  1 + i)
                        }))));
                }
            }
        }

        private async Task<bool> MetricsPropagated(MetricsClient metricClient)
        {
            var nsExists =  (await metricClient.GetMetricNamespacesAsync(_testEnvironment.MetricsResource)).Value.Any(ns => ns.Name == MetricNamespace);

            if (!nsExists)
            {
                return false;
            }

            var metrics = await metricClient.QueryAsync(_testEnvironment.MetricsResource, new[] {MetricName},
                new MetricsQueryOptions()
                {
                    TimeSpan = new DateTimeRange(StartTime, Duration),
                    MetricNamespace = MetricNamespace,
                    Interval = TimeSpan.FromMinutes(1),
                    Aggregations =
                    {
                        MetricAggregationType.Count
                    }
                });

            var timeSeries = metrics.Value.Metrics[0].TimeSeries.FirstOrDefault();
            if (timeSeries == null)
            {
                return false;
            }

            foreach (var data in timeSeries.Data)
            {
                if (data.Count == null)
                {
                    return false;
                }
            }

            return true;
        }

        private record MetricDataDocument(DateTimeOffset time, MetricData data);
        private record MetricData(MetricBaseData baseData);
        private record MetricBaseData(string metric, string @namespace, string[] dimNames, SeriesValue[] series);
        private record SeriesValue(string[] dimValues, float min, float max, float sum, int count);
    }
}