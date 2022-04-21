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

namespace Azure.Messaging.EventHubs.Stress
{
    internal class EventProducerTest
    {
        private Metrics metrics;
        private ProducerConfiguration testConfiguration;

        public EventProducerTest(ProducerConfiguration configuration)
        {
            testConfiguration = configuration;
            metrics = new Metrics(configuration.InstrumentationKey);
        }

        public async Task Run()
        {
            using var publishCancellationSource = new CancellationTokenSource();

            var runDuration = TimeSpan.FromHours(testConfiguration.DurationInHours);
            publishCancellationSource.CancelAfter(runDuration);

            var publishingTasks = default(IEnumerable<Task>);

            try
            {
                // Begin publishing events in the background.

                publishingTasks = Enumerable
                    .Range(0, testConfiguration.ProducerCount)
                    .Select(_ => Task.Run(() => new Publisher(testConfiguration, metrics).Start(publishCancellationSource.Token)))
                    .ToList();

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
                metrics.Client.TrackException(ex);
            }

            // The run is ending.  Clean up the outstanding background operations and
            // complete the necessary metrics tracking.

            try
            {
                publishCancellationSource.Cancel();
                await Task.WhenAll(publishingTasks).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                metrics.Client.TrackException(ex);
            }
            finally
            {
                // flush metrics
            }
        }
    }
}