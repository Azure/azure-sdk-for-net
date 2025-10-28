// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.PerfStress;
using BenchmarkDotNet.Running;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private const int BYTES_PER_MEGABYTE = 1024 * 1024;

        private static IPerfTest[] _perfTests;
        private static IList<long> _completedOperations => _perfTests.Select(p => p.CompletedOperations).ToList();
        private static IList<TimeSpan> _lastCompletionTimes => _perfTests.Select(p => p.LastCompletionTime).ToList();
        private static IList<IList<TimeSpan>> _latencies => _perfTests.Select(p => p.Latencies).ToList();
        private static IList<IList<TimeSpan>> _correctedLatencies => _perfTests.Select(p => p.CorrectedLatencies).ToList();
        private static Channel<(TimeSpan Start, Stopwatch Stopwatch)> _pendingOperations;

        private static long CompletedOperations => _completedOperations.Sum();
        private static double OperationsPerSecond => _completedOperations.Zip(_lastCompletionTimes,
            (operations, time) => operations > 0 ? (operations / time.TotalSeconds) : 0)
            .Sum();

        public static async Task Main(Assembly assembly, string[] args)
        {
            // See if we want to run a BenchmarkDotNet microbenchmark
            if (args.Length > 0 && args[0].Equals("micro", StringComparison.OrdinalIgnoreCase))
            {
                BenchmarkSwitcher.FromAssembly(assembly).Run(args.Skip(1).ToArray());
                return;
            }

            var testTypes = assembly.ExportedTypes
                .Where(t => typeof(IPerfTest).IsAssignableFrom(t) && !t.IsAbstract);

            if (testTypes.Any())
            {
                var optionTypes = PerfUtilities.GetOptionTypes(testTypes);
                await PerfUtilities.Parser.ParseArguments(args, optionTypes).MapResult<PerfOptions, Task>(
                    async o =>
                    {
                        var verbName = o.GetType().GetCustomAttribute<VerbAttribute>().Name;
                        var testType = testTypes.Where(t => PerfUtilities.GetVerbName(t.Name) == verbName).Single();
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

            Console.WriteLine("=== Options ===");
            Console.WriteLine(JsonSerializer.Serialize(options, options.GetType(), new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
            Console.WriteLine();

            ConfigureThreadPool(options);

            PrintEnvironment();

            using var setupStatusCts = new CancellationTokenSource();
            var setupStatusThread = PerfUtilities.PrintStatus("=== Setup ===", () => ".", newLine: false, setupStatusCts.Token);

            using var cleanupStatusCts = new CancellationTokenSource();
            Thread cleanupStatusThread = null;

            var tests = new IPerfTest[options.Parallel];
            _perfTests = tests;

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

                        using var postSetupStatusCts = new CancellationTokenSource();
                        var postSetupStatusThread = PerfUtilities.PrintStatus("=== Post Setup ===", () => ".", newLine: false, postSetupStatusCts.Token);

                        await Task.WhenAll(tests.Select(t => t.PostSetupAsync()));

                        postSetupStatusCts.Cancel();
                        postSetupStatusThread.Join();

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
                        try
                        {
                            using var preCleanupStatusCts = new CancellationTokenSource();
                            var preCleanupStatusThread = PerfUtilities.PrintStatus("=== Pre Cleanup ===", () => ".", newLine: false, preCleanupStatusCts.Token);
                            await Task.WhenAll(tests.Select(t => t.PreCleanupAsync()));
                            preCleanupStatusCts.Cancel();
                            preCleanupStatusThread.Join();
                        }
                        finally
                        {
                            if (!options.NoCleanup)
                            {
                                if (cleanupStatusThread == null)
                                {
                                    cleanupStatusThread = PerfUtilities.PrintStatus("=== Cleanup ===", () => ".", newLine: false, cleanupStatusCts.Token);
                                }

                                await Task.WhenAll(tests.Select(t => t.CleanupAsync()));
                            }
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
                            cleanupStatusThread = PerfUtilities.PrintStatus("=== Cleanup ===", () => ".", newLine: false, cleanupStatusCts.Token);
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

            // I would prefer to print assembly versions at the start of testing, but they cannot be determined until
            // code in each assembly has been executed, so this must wait until after testing is complete.
            PrintAssemblyVersions(testType);
        }

        private static void ConfigureThreadPool(PerfOptions options)
        {
            if (options.MinWorkerThreads.HasValue || options.MinIOCompletionThreads.HasValue)
            {
                ThreadPool.GetMinThreads(out var minWorkerThreads, out var minIOCompletionThreads);
                var successful = ThreadPool.SetMinThreads(options.MinWorkerThreads ?? minWorkerThreads,
                    options.MinIOCompletionThreads ?? minIOCompletionThreads);

                if (!successful)
                {
                    throw new InvalidOperationException("ThreadPool.SetMinThreads() was unsuccessful");
                }
            }

            if (options.MaxWorkerThreads.HasValue || options.MaxIOCompletionThreads.HasValue)
            {
                ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxIOCompletionThreads);
                var successful = ThreadPool.SetMaxThreads(options.MaxWorkerThreads ?? maxWorkerThreads,
                    options.MaxIOCompletionThreads ?? maxIOCompletionThreads);

                if (!successful)
                {
                    throw new InvalidOperationException("ThreadPool.SetMaxThreads() was unsuccessful");
                }
            }
        }

        private static void PrintEnvironment()
        {
            Console.WriteLine("=== Environment ===");

            Console.WriteLine($"GCSettings.IsServerGC: {GCSettings.IsServerGC}");

            Console.WriteLine($"Environment.ProcessorCount: {Environment.ProcessorCount}");
            Console.WriteLine($"Environment.Is64BitProcess: {Environment.Is64BitProcess}");

            ThreadPool.GetMinThreads(out var minWorkerThreads, out var minCompletionPortThreads);
            ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxCompletionPortThreads);
            Console.WriteLine($"ThreadPool.MinWorkerThreads: {minWorkerThreads}");
            Console.WriteLine($"ThreadPool.MinCompletionPortThreads: {minCompletionPortThreads}");
            Console.WriteLine($"ThreadPool.MaxWorkerThreads: {maxWorkerThreads}");
            Console.WriteLine($"ThreadPool.MaxCompletionPortThreads: {maxCompletionPortThreads}");

            Console.WriteLine();
        }

        private static void PrintAssemblyVersions(Type testType)
        {
            Console.WriteLine("=== Versions ===");

            Console.WriteLine($"Runtime:         {Environment.Version}");

            var referencedAssemblies = testType.Assembly.GetReferencedAssemblies();

            var azureLoadedAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                // Include all Track1 and Track2 assemblies
                .Where(a => a.GetName().Name.StartsWith("Azure", StringComparison.OrdinalIgnoreCase) ||
                            a.GetName().Name.StartsWith("Microsoft.Azure", StringComparison.OrdinalIgnoreCase))
                // Exclude Azure.Core.TestFramework since it is only used to setup environment and should not impact results
                .Where(a => !a.GetName().Name.Equals("Azure.Core.TestFramework", StringComparison.OrdinalIgnoreCase))
                .OrderBy(a => a.GetName().Name);

            foreach (var a in azureLoadedAssemblies)
            {
                var name = a.GetName().Name;
                var referencedVersion = referencedAssemblies.Where(r => r.Name == name).SingleOrDefault()?.Version;
                var loadedVersion = a.GetName().Version;
                var informationalVersion = FileVersionInfo.GetVersionInfo(a.Location).ProductVersion;
                var debuggableAttribute = (DebuggableAttribute)(a.GetCustomAttribute(typeof(DebuggableAttribute)));

                Console.WriteLine($"{name}:");
                if (referencedVersion != null)
                {
                    Console.WriteLine($"  Referenced:    {referencedVersion}");
                }
                Console.WriteLine($"  Loaded:        {loadedVersion}");
                Console.WriteLine($"  Informational: {informationalVersion}");
                Console.WriteLine($"  JITOptimizer:  {(debuggableAttribute.IsJITOptimizerDisabled ? "Disabled" : "Enabled")}");
            }

            Console.WriteLine();
        }

        private static async Task RunTestsAsync(IPerfTest[] tests, PerfOptions options, string title, bool warmup = false)
        {
            var durationSeconds = warmup ? options.Warmup : options.Duration;

            // Always disable jobStatistics and latency during warmup
            var jobStatistics = warmup ? false : options.JobStatistics;
            var latency = warmup ? false : options.Latency;

            var duration = TimeSpan.FromSeconds(durationSeconds);
            using var testCts = new CancellationTokenSource(duration);
            var cancellationToken = testCts.Token;

            var cpuStopwatch = Stopwatch.StartNew();
            TimeSpan lastCpuElapsed = default;
            var startCpuTime = Process.GetCurrentProcess().TotalProcessorTime;
            var lastCpuTime = Process.GetCurrentProcess().TotalProcessorTime;

            long lastCompleted = 0;

            using var progressStatusCts = new CancellationTokenSource();
            var progressStatusThread = PerfUtilities.PrintStatus(
                $"=== {title} ===" + Environment.NewLine +
                $"{"Current",11}   {"Total",15}   {"Average",14}   {"CPU",7}    {"WorkingSet",10}    {"PrivateMemory",13}",
                () =>
                {
                    var totalCompleted = CompletedOperations;
                    var currentCompleted = totalCompleted - lastCompleted;
                    var averageCompleted = OperationsPerSecond;
                    lastCompleted = totalCompleted;

                    var process = Process.GetCurrentProcess();

                    var cpuElapsed = cpuStopwatch.Elapsed;
                    var cpuTime = process.TotalProcessorTime;
                    var currentCpuElapsed = (cpuElapsed - lastCpuElapsed).TotalMilliseconds;
                    var currentCpuTime = (cpuTime - lastCpuTime).TotalMilliseconds;
                    var cpuPercentage = (currentCpuTime / currentCpuElapsed) / Environment.ProcessorCount;
                    lastCpuElapsed = cpuElapsed;
                    lastCpuTime = cpuTime;

                    var privateMemoryMB = ((double)process.PrivateMemorySize64) / (BYTES_PER_MEGABYTE);
                    var workingSetMB = ((double)process.WorkingSet64) / (BYTES_PER_MEGABYTE);

                    // Max Widths
                    // Current: NNN,NNN,NNN (11)
                    // Total: NNN,NNN,NNN,NNN (15)
                    // Average: NNN,NNN,NNN.NN (14)
                    // CPU: NNN.NN% (7)
                    // Memory: NNN,NNN.NN (10)
                    return $"{currentCompleted,11:N0}   {totalCompleted,15:N0}   {averageCompleted,14:N2}   {cpuPercentage * 100,6:N2}%   " +
                        $"{workingSetMB,10:N2}M   {privateMemoryMB,13:N2}M";
                },
                newLine: true,
                progressStatusCts.Token,
                options.StatusInterval
                );

            Thread pendingOperationsThread = null;
            if (options.Rate.HasValue)
            {
                _pendingOperations = Channel.CreateUnbounded<ValueTuple<TimeSpan, Stopwatch>>();

                foreach (var test in tests)
                {
                    test.PendingOperations = _pendingOperations;
                }

                pendingOperationsThread = WritePendingOperations(options.Rate.Value, cancellationToken);
            }

            if (options.Sync)
            {
                var threads = new Thread[options.Parallel];

                for (var i = 0; i < options.Parallel; i++)
                {
                    var j = i;
                    threads[i] = new Thread(() =>
                    {
                        try
                        {
                            tests[j].RunAll(cancellationToken);
                        }
                        catch (Exception e)
                        {
                            if (cancellationToken.IsCancellationRequested && PerfUtilities.ContainsOperationCanceledException(e))
                            {
                                // If the test has been canceled, ignore if any part of the exception chain is OperationCanceledException.
                            }
                            else
                            {
                                throw;
                            }
                        }
                    });
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
                    tasks[j] = Task.Run(async () =>
                    {
                        try
                        {
                            await tests[j].RunAllAsync(cancellationToken);
                        }
                        catch (Exception e)
                        {
                            if (cancellationToken.IsCancellationRequested && PerfUtilities.ContainsOperationCanceledException(e))
                            {
                                // If the test has been canceled, ignore if any part of the exception chain is OperationCanceledException.
                            }
                            else
                            {
                                throw;
                            }
                        }
                    });
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

            var totalOperations = CompletedOperations;
            var operationsPerSecond = OperationsPerSecond;
            var secondsPerOperation = 1 / operationsPerSecond;
            var weightedAverageSeconds = totalOperations / operationsPerSecond;

            var cpuElapsed = cpuStopwatch.Elapsed.TotalMilliseconds;
            var cpuTime = (Process.GetCurrentProcess().TotalProcessorTime - startCpuTime).TotalMilliseconds;
            var cpuPercentage = (cpuTime / cpuElapsed) / Environment.ProcessorCount;

            Console.WriteLine($"Completed {totalOperations:N0} operations in a weighted-average of {NumberFormatter.Format(weightedAverageSeconds, 4)}s " +
                $"({NumberFormatter.Format(operationsPerSecond, 4)} ops/s, {NumberFormatter.Format(secondsPerOperation, 4)} s/op, " +
                $"{NumberFormatter.Format(cpuPercentage * 100, 2)}% CPU)");
            Console.WriteLine();

            if (latency)
            {
                PrintLatencies("Latency Distribution", _latencies);

                if (_correctedLatencies.Any(list => list != null))
                {
                    PrintLatencies("Corrected Latency Distribution", _correctedLatencies);
                }

                if (!string.IsNullOrEmpty(options.ResultsFile))
                {
                    WriteResults(options.ResultsFile, (options as SizeOptions)?.Size ?? -1);
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

        private static void PrintLatencies(string header, IList<IList<TimeSpan>> latencies)
        {
            Console.WriteLine($"=== {header} ===");
            var sortedLatencies = latencies.SelectMany(l => l).ToArray();
            Array.Sort(sortedLatencies);
            if (sortedLatencies.Length == 0)
            {
                Console.WriteLine("No latency results.");
                Console.WriteLine();
                return;
            }

            var percentiles = new double[] { 0.5, 0.75, 0.9, 0.99, 0.999, 0.9999, 0.99999, 1.0 };
            foreach (var percentile in percentiles)
            {
                var index = Math.Max(0, (int)(sortedLatencies.Length * percentile) - 1);
                Console.WriteLine($"{percentile * 100,7:N3}%   {sortedLatencies[index].TotalMilliseconds,8:N2}ms");
            }
            Console.WriteLine();
        }

        private static void WriteResults(string path, long operationSize)
        {
            var latencies = _latencies.SelectMany(x => x).Select(l => new OperationResult
            {
                Time = l.TotalMilliseconds,
                Size = operationSize,
            }).ToArray();
            string json = JsonSerializer.Serialize(latencies, options: new JsonSerializerOptions()
            {
                WriteIndented = true,
            });
            File.WriteAllText(path, json);
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
                        _pendingOperations.Writer.TryWrite((sw.Elapsed, sw));
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
