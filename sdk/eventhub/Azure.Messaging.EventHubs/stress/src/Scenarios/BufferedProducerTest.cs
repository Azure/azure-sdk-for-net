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

            var publishingTasks = default(IEnumerable<Task>);

            try
            {
                publishingTasks = Enumerable
                    .Range(0, 2)
                    .Select(_ => Task.Run(() => new BufferedPublisher(connectionString, eventHubName, metrics).Start(publishCancellationSource.Token)))
                    .ToList();

                while (!publishCancellationSource.Token.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromMinutes(1), publishCancellationSource.Token).ConfigureAwait(false);
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
                metrics.Client.TrackException(ex);
                Environment.FailFast(ex.Message);
            }
            catch (Exception ex)
            {
                metrics.Client.GetMetric(metrics.TotalExceptions).TrackValue(1);
                metrics.Client.GetMetric(metrics.GeneralExceptions).TrackValue(1);
                metrics.Client.TrackException(ex);
            }

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
        }
    }
}