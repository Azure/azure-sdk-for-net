using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EventProducerTest
{
    internal class TestRun
    {
        public string Id { get; } = Guid.NewGuid().ToString();

        public bool IsRunning { get; private set; } = false;

        public Metrics Metrics { get; } = new Metrics();

        public ConcurrentBag<Exception> ErrorsObserved { get; } = new ConcurrentBag<Exception>();

        private TestConfiguration Configuration { get; }

        public TestRun(TestConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task Start(CancellationToken cancellationToken)
        {
            IsRunning = true;

            using var process = Process.GetCurrentProcess();
            using var publishCancellationSource = new CancellationTokenSource();

            var publishingTasks = default(IEnumerable<Task>);
            var runDuration = Stopwatch.StartNew();

            try
            {
                // Begin publishing events in the background.

                publishingTasks = Enumerable
                    .Range(0, Configuration.ProducerCount)
                    .Select(_ => Task.Run(() => new Publisher(Configuration, Metrics, ErrorsObserved).Start(publishCancellationSource.Token)))
                    .ToList();

                // Update metrics.

                while (!cancellationToken.IsCancellationRequested)
                {
                    Metrics.UpdateEnvironmentStatistics(process);
                    Interlocked.Exchange(ref Metrics.RunDurationMilliseconds, runDuration.Elapsed.TotalMilliseconds);

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
                Interlocked.Increment(ref Metrics.TotalExceptions);
                Interlocked.Increment(ref Metrics.GeneralExceptions);
                ErrorsObserved.Add(ex);
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
                Interlocked.Increment(ref Metrics.TotalExceptions);
                Interlocked.Increment(ref Metrics.GeneralExceptions);
                ErrorsObserved.Add(ex);
            }
            finally
            {
                runDuration.Stop();
                IsRunning = false;
            }
        }
    }
}