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
using Azure.Messaging.EventHubs.Tests;

namespace Azure.Messaging.EventHubs.Stress
{
    public class BufferedProducerTest
    {
        private Metrics metrics;

        public async Task Run(string connectionString, string eventHubName, string appInsightsKey, int durationInHours)
        {
            metrics = new Metrics(appInsightsKey);
            using var publishCancellationSource = new CancellationTokenSource();

            var runDuration = TimeSpan.FromHours(durationInHours);
            publishCancellationSource.CancelAfter(runDuration);

            try
            {
                var testRun = TestRun(connectionString, eventHubName, publishCancellationSource.Token).ConfigureAwait(false);

                while (!publishCancellationSource.IsCancellationRequested)
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(45), publishCancellationSource.Token);
                    }
                    catch (TaskCanceledException)
                    {
                        metrics.Client.TrackTrace("Run is ending");
                    }
                }
                // If we want period status updates - metrics would need to be tracked in this class so that they are accessible
            }
            catch (Exception ex) when
                (ex is OutOfMemoryException
                || ex is StackOverflowException
                || ex is ThreadAbortException)
            {
                Environment.FailFast(ex.Message);
            }
            catch (Exception ex)
            {
                metrics.Client.TrackException(ex);
            }
        }

        private async Task TestRun(string connectionString, string eventHubName, CancellationToken cancellationToken)
        {
            var publishingTasks = default(IEnumerable<Task>);
            var runDuration = Stopwatch.StartNew();

            try
            {
                publishingTasks = Enumerable
                    .Range(0, 2)
                    .Select(_ => Task.Run(() => new BufferedPublisher(connectionString, eventHubName, metrics).Start(cancellationToken)))
                    .ToList();

                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken).ConfigureAwait(false);
                }
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
                metrics.Client.GetMetric(metrics.TotalExceptions).TrackValue(1);
                metrics.Client.GetMetric(metrics.GeneralExceptions).TrackValue(1);
                metrics.Client.TrackException(ex);
            }

            // The run is ending.  Clean up the outstanding background operations and
            // complete the necessary metrics tracking.

            try
            {
                await Task.WhenAll(publishingTasks).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                metrics.Client.GetMetric(metrics.TotalExceptions).TrackValue(1);
                metrics.Client.GetMetric(metrics.GeneralExceptions).TrackValue(1);
                metrics.Client.TrackException(ex);
            }
            finally
            {
                runDuration.Stop();
            }
        }
    }
}