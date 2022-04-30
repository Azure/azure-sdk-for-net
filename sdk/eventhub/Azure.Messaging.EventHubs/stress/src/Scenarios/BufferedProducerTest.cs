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
using Azure.Core.Diagnostics;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using System.Diagnostics.Tracing;

namespace Azure.Messaging.EventHubs.Stress
{
    internal class BufferedProducerTest
    {
        private Metrics _metrics;
        private BufferedProducerTestConfig _testConfiguration;

        public BufferedProducerTest(BufferedProducerTestConfig testConfiguration)
        {
            _testConfiguration = testConfiguration;
            _metrics = new Metrics(testConfiguration.InstrumentationKey);
        }

        public async Task Run()
        {
            // Create a new metrics instance for the given test run.
            _metrics = new Metrics(_testConfiguration.InstrumentationKey);

            // Set up cancellation token
            using var enqueueingCancellationSource = new CancellationTokenSource();
            var runDuration = TimeSpan.FromHours(_testConfiguration.DurationInHours);
            enqueueingCancellationSource.CancelAfter(runDuration);

            using var azureEventListener = new AzureEventSourceListener(SendHeardException, EventLevel.Error);

            var enqueuingTasks = default(IEnumerable<Task>);

            // Start two buffered producer background tasks
            try
            {
                enqueuingTasks = Enumerable
                    .Range(0, 2)
                    .Select(_ => Task.Run(() => new BufferedPublisher(_testConfiguration, _metrics).Start(enqueueingCancellationSource.Token)))
                    .ToList();

                // Periodically update garbage collection metrics
                while (!enqueueingCancellationSource.Token.IsCancellationRequested)
                {
                    UpdateEnvironmentStatistics(_metrics);
                    await Task.Delay(TimeSpan.FromMinutes(1), enqueueingCancellationSource.Token).ConfigureAwait(false);
                }

                await Task.WhenAll(enqueuingTasks).ConfigureAwait(false);
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
                _metrics.Client.TrackException(ex);
                Environment.FailFast(ex.Message);
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