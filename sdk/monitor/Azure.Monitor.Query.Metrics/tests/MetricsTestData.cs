// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Monitor.Query.Metrics.Tests
{
    public class MetricsTestData
    {
        private static Task _initialization;
        private static readonly object _initializationLock = new object();

        private readonly MonitorQueryMetricsTestEnvironment _testEnvironment;
        private static TimeSpan AllowedMetricAge = TimeSpan.FromMinutes(25);
        public string Name1 { get; } = "Guinness";
        public string Name2 { get; } = "Bessie";
        public TimeSpan Duration { get; } = TimeSpan.FromMinutes(15);
        public DateTimeOffset StartTime { get; }
        public string MetricName { get; }
        public string MetricNamespace { get; }
        public DateTimeOffset EndTime => StartTime.Add(Duration);

        public MetricsTestData(MonitorQueryMetricsTestEnvironment environment, DateTimeOffset dateTimeOffset)
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
            // Note: The new package doesn't have MetricsQueryClient, only MetricsClient for batch operations
            // For individual resource queries, we would need to use the original package or handle differently
            // For now, commenting out the initialization since it depends on MetricsQueryClient

            var senderClient = new MetricsSenderClient(
                _testEnvironment.DataplaneEndpoint,
                _testEnvironment.MonitorIngestionEndpoint,
                _testEnvironment.MetricsResource,
                _testEnvironment.Credential,
                new SenderClientOptions()
                {
                    Diagnostics = { IsLoggingContentEnabled = true }
                });

            // Simplified initialization without MetricsQueryClient dependency
            await SendData(senderClient);

            // Wait a bit for propagation
            await Task.Delay(TimeSpan.FromSeconds(30));
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

        private record MetricDataDocument(DateTimeOffset time, MetricData data);
        private record MetricData(MetricBaseData baseData);
        private record MetricBaseData(string metric, string @namespace, string[] dimNames, SeriesValue[] series);
        private record SeriesValue(string[] dimValues, float min, float max, float sum, int count);
    }
}
