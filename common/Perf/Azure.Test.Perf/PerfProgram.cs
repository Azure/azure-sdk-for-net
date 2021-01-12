// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.PerfStress;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.Test.Perf
{
    public static class PerfProgram
    {
        private static int[] _completedOperations;
        private static TimeSpan[] _lastCompletionTimes;
        private static List<TimeSpan>[] _latencies;
        private static List<TimeSpan>[] _correctedLatencies;
        private static Channel<(TimeSpan, Stopwatch)> _pendingOperations;

        public static async Task Main(Assembly assembly, string[] args)
        {
            var testTypes = assembly.ExportedTypes
                .Where(t => typeof(IPerfTest).IsAssignableFrom(t) && !t.IsAbstract);

            if (testTypes.Any())
            {
                var optionTypes = PerfStressUtilities.GetOptionTypes(testTypes);
                await PerfStressUtilities.Parser.ParseArguments(args, optionTypes).MapResult<PerfOptions, Task>(
                    async o =>
                    {
                        var verbName = o.GetType().GetCustomAttribute<VerbAttribute>().Name;
                        var testType = testTypes.Where(t => PerfStressUtilities.GetVerbName(t.Name) == verbName).Single();
                        await Run(testType, o);
                    },
                    errors => Task.CompletedTask
                );
            }
            else
            {
                Console.WriteLine($"Assembly '{assembly.GetName().Name}' does not contain any types implementing 'IPerfStressTest'");
            }
        }

        private static async Task Run(Type testType, PerfOptions options)
        {
            // Require Server GC, since most performance-sensitive usage will be in ASP.NET apps which
            // enable Server GC by default.  Though Server GC is disabled on 1-core machines as of
            // .NET Core 3.0 (https://github.com/dotnet/runtime/issues/12484).
            if (Environment.ProcessorCount > 1 && !GCSettings.IsServerGC)
            {
                throw new InvalidOperationException("Requires server GC");
            }

            if (options.JobStatistics)
            {
                Console.WriteLine("Application started.");
            }

            Console.WriteLine("=== Versions ===");
            Console.WriteLine($"Runtime: {Environment.Version}");
            var azureAssemblies = testType.Assembly.GetReferencedAssemblies()
                .Where(a => a.Name.StartsWith("Azure", StringComparison.OrdinalIgnoreCase) || a.Name.StartsWith("Microsoft.Azure", StringComparison.OrdinalIgnoreCase))
                .Where(a => !a.Name.Equals("Azure.Test.Perf", StringComparison.OrdinalIgnoreCase))
                .OrderBy(a => a.Name);
            foreach (var a in azureAssemblies)
            {
                Console.WriteLine($"{a.Name}: {a.Version}");
            }
            Console.WriteLine();

            Console.WriteLine("=== Options ===");
            Console.WriteLine(JsonSerializer.Serialize(options, options.GetType(), new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
            Console.WriteLine();

            using var setupStatusCts = new CancellationTokenSource();
            var setupStatusThread = PerfStressUtilities.PrintStatus("=== Setup ===", () => ".", newLine: false, setupStatusCts.Token);

            using var cleanupStatusCts = new CancellationTokenSource();
            Thread cleanupStatusThread = null;

            var tests = new IPerfTest[options.Parallel];
            for (var i = 0; i < options.Parallel; i++)
            {
                tests[i] = (IPerfTest)Activator.CreateInstance(testType, options);
            }

            try
            {
                try
                {
                    await tests[0].GlobalSetupAsync();

                    try
                    {
                        await Task.WhenAll(tests.Select(t => t.SetupAsync()));
                        setupStatusCts.Cancel();
                        setupStatusThread.Join();

                        if (options.Warmup > 0)
                        {
                            await RunTestsAsync(tests, options, "Warmup", warmup: true);
                        }

                        for (var i = 0; i < options.Iterations; i++)
                        {
                            var title = "Test";
                            if (options.Iterations > 1)
                            {
                                title += " " + (i + 1);
                            }
                            await RunTestsAsync(tests, options, title);
                        }
                    }
                    catch (AggregateException ae)
                    {
                        foreach (Exception e in ae.InnerExceptions)
                        {
                            Console.WriteLine($"Exception: {e}");
                        }
                        throw;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Exception: {e}");
                        throw;
                    }
                    finally
                    {
                        if (!options.NoCleanup)
                        {
                            if (cleanupStatusThread == null)
                            {
                                cleanupStatusThread = PerfStressUtilities.PrintStatus("=== Cleanup ===", () => ".", newLine: false, cleanupStatusCts.Token);
                            }

                            await Task.WhenAll(tests.Select(t => t.CleanupAsync()));
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Exception: {e}");
                    throw;
                }
                finally
                {
                    if (!options.NoCleanup)
                    {
                        if (cleanupStatusThread == null)
                        {
                            cleanupStatusThread = PerfStressUtilities.PrintStatus("=== Cleanup ===", () => ".", newLine: false, cleanupStatusCts.Token);
                        }

                        await tests[0].GlobalCleanupAsync();
                    }
                }
            }
            finally
            {
                await Task.WhenAll(tests.Select(t => t.DisposeAsync().AsTask()));
            }

            cleanupStatusCts.Cancel();
            if (cleanupStatusThread != null)
            {
                cleanupStatusThread.Join();
            }
        }

        private static async Task RunTestsAsync(IPerfTest[] tests, PerfOptions options, string title, bool warmup = false)
        {
            var durationSeconds = warmup ? options.Warmup : options.Duration;

            // Always disable jobStatistics and latency during warmup
            var jobStatistics = warmup ? false : options.JobStatistics;
            var latency = warmup ? false : options.Latency;

            _completedOperations = new int[options.Parallel];
            _lastCompletionTimes = new TimeSpan[options.Parallel];

            if (latency)
            {
                _latencies = new List<TimeSpan>[options.Parallel];
                for (var i = 0; i < options.Parallel; i++)
                {
                    _latencies[i] = new List<TimeSpan>();
                }

                if (options.Rate.HasValue)
                {
                    _correctedLatencies = new List<TimeSpan>[options.Parallel];
                    for (var i = 0; i < options.Parallel; i++)
                    {
                        _correctedLatencies[i] = new List<TimeSpan>();
                    }
                }
            }

            var duration = TimeSpan.FromSeconds(durationSeconds);
            using var testCts = new CancellationTokenSource(duration);
            var cancellationToken = testCts.Token;

            var lastCompleted = 0;

            using var progressStatusCts = new CancellationTokenSource();
            var progressStatusThread = PerfStressUtilities.PrintStatus(
                $"=== {title} ===" + Environment.NewLine +
                "Current\t\tTotal",
                () =>
                {
                    var totalCompleted = _completedOperations.Sum();
                    var currentCompleted = totalCompleted - lastCompleted;
                    lastCompleted = totalCompleted;
                    return currentCompleted + "\t\t" + totalCompleted;
                },
                newLine: true,
                progressStatusCts.Token,
                options.StatusInterval
                );

            Thread pendingOperationsThread = null;
            if (options.Rate.HasValue)
            {
                _pendingOperations = Channel.CreateUnbounded<ValueTuple<TimeSpan, Stopwatch>>();
                pendingOperationsThread = WritePendingOperations(options.Rate.Value, cancellationToken);
            }

            if (options.Sync)
            {
                var threads = new Thread[options.Parallel];

                for (var i = 0; i < options.Parallel; i++)
                {
                    var j = i;
                    threads[i] = new Thread(() => RunLoop(tests[j], j, latency, cancellationToken));
                    threads[i].Start();
                }
                for (var i = 0; i < options.Parallel; i++)
                {
                    threads[i].Join();
                }
            }
            else
            {
                var tasks = new Task[options.Parallel];
                for (var i = 0; i < options.Parallel; i++)
                {
                    var j = i;
                    // Call Task.Run() instead of directly calling RunLoopAsync(), to ensure the requested
                    // level of parallelism is achieved even if the test RunAsync() completes synchronously.
                    tasks[j] = Task.Run(() => RunLoopAsync(tests[j], j, latency, cancellationToken));
                }
                await Task.WhenAll(tasks);
            }

            if (pendingOperationsThread != null)
            {
                pendingOperationsThread.Join();
            }

            progressStatusCts.Cancel();
            progressStatusThread.Join();

            Console.WriteLine("=== Results ===");

            var totalOperations = _completedOperations.Sum();
            var operationsPerSecond = _completedOperations.Zip(_lastCompletionTimes, (operations, time) => (operations / time.TotalSeconds)).Sum();
            var secondsPerOperation = 1 / operationsPerSecond;
            var weightedAverageSeconds = totalOperations / operationsPerSecond;

            Console.WriteLine($"Completed {totalOperations} operations in a weighted-average of {weightedAverageSeconds:N2}s " +
                $"({operationsPerSecond:N2} ops/s, {secondsPerOperation:N3} s/op)");
            Console.WriteLine();

            if (latency)
            {
                PrintLatencies("Latency Distribution", _latencies);

                if (_correctedLatencies != null)
                {
                    PrintLatencies("Corrected Latency Distribution", _correctedLatencies);
                }
            }

            if (jobStatistics)
            {
                var output = new BenchmarkOutput();

                output.Metadata.Add(new BenchmarkMetadata
                {
                    Source = "PerfStress",
                    Name = "perfstress/throughput",
                    ShortDescription = "Throughput (ops/sec)",
                    LongDescription = "Throughput (ops/sec)",
                    Format = "n2",
                });

                output.Measurements.Add(new BenchmarkMeasurement
                {
                    Timestamp = DateTime.UtcNow,
                    Name = "perfstress/throughput",
                    Value = operationsPerSecond,
                });

                Console.WriteLine("#StartJobStatistics");
                Console.WriteLine(JsonSerializer.Serialize(output));
                Console.WriteLine("#EndJobStatistics");
            }
        }

        private static void PrintLatencies(string header, List<TimeSpan>[] latencies)
        {
            Console.WriteLine($"=== {header} ===");
            var sortedLatencies = latencies.Aggregate<IEnumerable<TimeSpan>>((list1, list2) => list1.Concat(list2)).ToArray();
            Array.Sort(sortedLatencies);
            var percentiles = new double[] { 0.5, 0.75, 0.9, 0.99, 0.999, 0.9999, 0.99999, 1.0 };
            foreach (var percentile in percentiles)
            {
                Console.WriteLine($"{percentile,8:P3}\t{sortedLatencies[(int)(sortedLatencies.Length * percentile) - 1].TotalMilliseconds:N2}ms");
            }
            Console.WriteLine();
        }

        private static void RunLoop(IPerfTest test, int index, bool latency, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            var latencySw = new Stopwatch();
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (latency)
                    {
                        latencySw.Restart();
                    }

                    test.Run(cancellationToken);

                    if (latency)
                    {
                        _latencies[index].Add(latencySw.Elapsed);
                    }

                    _completedOperations[index]++;
                    _lastCompletionTimes[index] = sw.Elapsed;
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private static async Task RunLoopAsync(IPerfTest test, int index, bool latency, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();
            var latencySw = new Stopwatch();
            (TimeSpan Start, Stopwatch Stopwatch) operation = (TimeSpan.Zero, null);

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (_pendingOperations != null)
                    {
                        operation = await _pendingOperations.Reader.ReadAsync(cancellationToken);
                    }

                    if (latency)
                    {
                        latencySw.Restart();
                    }

                    await test.RunAsync(cancellationToken);

                    if (latency)
                    {
                        _latencies[index].Add(latencySw.Elapsed);

                        if (_pendingOperations != null)
                        {
                            _correctedLatencies[index].Add(operation.Stopwatch.Elapsed - operation.Start);
                        }
                    }

                    _completedOperations[index]++;
                    _lastCompletionTimes[index] = sw.Elapsed;
                }
            }
            catch (Exception e)
            {
                // Ignore if any part of the exception chain is type OperationCanceledException
                if (!PerfStressUtilities.ContainsOperationCanceledException(e))
                {
                    throw;
                }
            }
        }

        private static Thread WritePendingOperations(int rate, CancellationToken token)
        {
            var thread = new Thread(() =>
            {
                var sw = Stopwatch.StartNew();
                int writtenOperations = 0;
                TimeSpan sleep = TimeSpan.FromSeconds(1.0 / rate);

                while (!token.IsCancellationRequested)
                {
                    while (writtenOperations < (rate * sw.Elapsed.TotalSeconds))
                    {
                        _pendingOperations.Writer.TryWrite(ValueTuple.Create(sw.Elapsed, sw));
                        writtenOperations++;
                    }

                    Thread.Sleep(sleep);
                }
            });

            thread.Start();

            return thread;
        }
    }
}
