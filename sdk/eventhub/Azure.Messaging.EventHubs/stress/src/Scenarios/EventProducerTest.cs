// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class EventProducerTest
    {
        private Metrics _metrics;
        private EventProducerTestConfig _testConfiguration;

        public EventProducerTest(EventProducerTestConfig testConfiguration)
        {
            _testConfiguration = testConfiguration;
            _metrics = new Metrics(testConfiguration.InstrumentationKey);
        }

        public async Task Run()
        {
            using var publishCancellationSource = new CancellationTokenSource();

            var runDuration = TimeSpan.FromHours(_testConfiguration.DurationInHours);
            publishCancellationSource.CancelAfter(runDuration);

            using var azureEventListener = new AzureEventSourceListener(SendHeardException, EventLevel.Error);

            var publishingTasks = default(IEnumerable<Task>);

            try
            {
                // Begin publishing events in the background.

                publishingTasks = Enumerable
                    .Range(0, 2)
                    .Select(_ => Task.Run(() => new Publisher(_testConfiguration, _metrics).Start(publishCancellationSource.Token)))
                    .ToList();

                // Periodically update garbage collection metrics
                while (!publishCancellationSource.Token.IsCancellationRequested)
                {
                    UpdateEnvironmentStatistics(_metrics);
                    await Task.Delay(TimeSpan.FromMinutes(1), publishCancellationSource.Token).ConfigureAwait(false);
                }

                await Task.WhenAll(publishingTasks).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                // No action needed.
            }
            catch (Exception ex) when
                (ex is OutOfMemoryException
                || ex is StackOverflowException
                || ex is ThreadAbortException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _metrics.Client.TrackException(ex);
            }

            // The run is ending.  Clean up the outstanding background operations.

            try
            {
                publishCancellationSource.Cancel();
                await Task.WhenAll(publishingTasks).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _metrics.Client.TrackException(ex);
            }
            finally
            {
                // Flush and wait for all metrics to be aggregated and sent to application insights
                _metrics.Client.Flush();
                await Task.Delay(60000).ConfigureAwait(false);
            }
        }

        private void UpdateEnvironmentStatistics(Metrics _metrics)
        {
            _metrics.Client.GetMetric(_metrics.GenerationZeroCollections).TrackValue(GC.CollectionCount(0));
            _metrics.Client.GetMetric(_metrics.GenerationOneCollections).TrackValue(GC.CollectionCount(1));
            _metrics.Client.GetMetric(_metrics.GenerationTwoCollections).TrackValue(GC.CollectionCount(2));
        }

        private void SendHeardException(EventWrittenEventArgs args, string level)
        {
            var output = args.ToString();
            _metrics.Client.TrackTrace($"EventWritten: {output} Level: {level}.");
        }
    }
}