// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

namespace Azure.Monitor.Query.Tests
{
    public class MetricsTestData
    {
        private static Task _initialization;
        private static readonly object _initializationLock = new object();

        private readonly MonitorQueryTestEnvironment _testEnvironment;
        private static TimeSpan AllowedMetricAge = TimeSpan.FromMinutes(25);
        public string Name1 { get; } = "Guinness";
        public string Name2 { get; } = "Bessie";
        public TimeSpan Duration { get; } = TimeSpan.FromMinutes(15);
        public DateTimeOffset StartTime { get; }
        public string MetricName { get; }
        public string MetricNamespace { get; }
        public DateTimeOffset EndTime => StartTime.Add(Duration);

        public MetricsTestData(MonitorQueryTestEnvironment environment, DateTimeOffset dateTimeOffset)
        {
            _testEnvironment = environment;

            // The service allows metrics sent maximum 4 minutes into the future
            var maxTimeInTheFuture = dateTimeOffset.AddMinutes(4);
            // Snap to 15 minute intervals
            StartTime = dateTimeOffset.AddTicks(- (dateTimeOffset.Ticks % Duration.Ticks));
            // Back off until we are in the allowed range
            while (StartTime + Duration > maxTimeInTheFuture)
            {
                StartTime -= Duration;
            }

            MetricName = "CowsHappiness";
            MetricNamespace = "Cows";
        }

        public async Task InitializeAsync()
        {
            if (_testEnvironment.Mode == RecordedTestMode.Playback)
            {
                return;
            }

            lock (_initializationLock)
            {
                _initialization ??= Initialize();
            }

            await _initialization;
        }

        private async Task Initialize()
        {
            var metricClient = new MetricsQueryClient(_testEnvironment.MetricsEndpoint, _testEnvironment.Credential);

            var senderClient = new MetricsSenderClient(
                _testEnvironment.MetricsLocation,
                _testEnvironment.MetricsIngestionEndpoint,
                _testEnvironment.MetricsResource,
                _testEnvironment.Credential,
                new SenderClientOptions()
                {
                    Diagnostics = { IsLoggingContentEnabled = true }
                });

            while (!await MetricsPropagated(metricClient))
            {
                // Stop sending when we are past the allowed threshold
                if (DateTimeOffset.UtcNow - StartTime < AllowedMetricAge)
                {
                    await SendData(senderClient);
                }

                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        private async Task SendData(MetricsSenderClient senderClient)
        {
            var names = new[] { Name1, Name2 };

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
                            new(new[] { name }, 5 * i, 20 * i, 30 * i, 1 + i)
                        }))));
                }
            }
        }

        private async Task<bool> MetricsPropagated(MetricsQueryClient metricQueryClient)
        {
            try
            {
                var metrics = await metricQueryClient.QueryResourceAsync(_testEnvironment.MetricsResource, new[] {MetricName},
                    new MetricsQueryOptions()
                    {
                        TimeRange = new QueryTimeRange(StartTime, Duration),
                        MetricNamespace = MetricNamespace,
                        Granularity = TimeSpan.FromMinutes(1),
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

                foreach (var data in timeSeries.Values)
                {
                    if (data.Count == null)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (RequestFailedException e) when (e.ErrorCode == "BadRequest")
            {
                return false;
            }
        }

        private record MetricDataDocument(DateTimeOffset time, MetricData data);
        private record MetricData(MetricBaseData baseData);
        private record MetricBaseData(string metric, string @namespace, string[] dimNames, SeriesValue[] series);
        private record SeriesValue(string[] dimValues, float min, float max, float sum, int count);
    }
}
