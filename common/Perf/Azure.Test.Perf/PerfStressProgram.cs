﻿using CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Azure.Test.PerfStress
{
    public static class PerfStressProgram
    {
        private static int[] _completedOperations;
        private static TimeSpan[] _lastCompletionTimes;
        private static List<TimeSpan>[] _latencies;
        private static List<TimeSpan>[] _correctedLatencies;
        private static Channel<(TimeSpan, Stopwatch)> _pendingOperations;

        public static async Task Main(Assembly assembly, string[] args)
        {
            var testTypes = assembly.ExportedTypes
                .Where(t => typeof(IPerfStressTest).IsAssignableFrom(t) && !t.IsAbstract);

            if (testTypes.Any())
            {
                var optionTypes = GetOptionTypes(testTypes);
                await Parser.Default.ParseArguments(args, optionTypes).MapResult<PerfStressOptions, Task>(
                    async o =>
                    {
                        var verbName = o.GetType().GetCustomAttribute<VerbAttribute>().Name;
                        var testType = testTypes.Where(t => GetVerbName(t.Name) == verbName).Single();
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

        private static async Task Run(Type testType, PerfStressOptions options)
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
                .Where(a => a.Name.StartsWith("Azure", StringComparison.OrdinalIgnoreCase))
                .Where(a => !a.Name.Equals("Azure.Test.PerfStress", StringComparison.OrdinalIgnoreCase))
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
            var setupStatusThread = PrintStatus("=== Setup ===", () => ".", newLine: false, setupStatusCts.Token);

            using var cleanupStatusCts = new CancellationTokenSource();
            Thread cleanupStatusThread = null;

            var tests = new IPerfStressTest[options.Parallel];
            for (var i = 0; i < options.Parallel; i++)
            {
                tests[i] = (IPerfStressTest)Activator.CreateInstance(testType, options);
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
                            await RunTestsAsync(tests, options.Sync, options.Parallel, options.Rate, options.Warmup, "Warmup");
                        }

                        for (var i = 0; i < options.Iterations; i++)
                        {
                            var title = "Test";
                            if (options.Iterations > 1)
                            {
                                title += " " + (i + 1);
                            }
                            await RunTestsAsync(tests, options.Sync, options.Parallel, options.Rate, options.Duration, title, options.JobStatistics, options.Latency);
                        }
                    }
                    finally
                    {
                        if (!options.NoCleanup)
                        {
                            if (cleanupStatusThread == null)
                            {
                                cleanupStatusThread = PrintStatus("=== Cleanup ===", () => ".", newLine: false, cleanupStatusCts.Token);
                            }

                            await Task.WhenAll(tests.Select(t => t.CleanupAsync()));
                        }
                    }
                }
                finally
                {
                    if (!options.NoCleanup)
                    {
                        if (cleanupStatusThread == null)
                        {
                            cleanupStatusThread = PrintStatus("=== Cleanup ===", () => ".", newLine: false, cleanupStatusCts.Token);
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

        private static async Task RunTestsAsync(IPerfStressTest[] tests, bool sync, int parallel, int? rate,
            int durationSeconds, string title, bool jobStatistics = false, bool latency = false)
        {
            _completedOperations = new int[parallel];
            _lastCompletionTimes = new TimeSpan[parallel];

            if (latency)
            {
                _latencies = new List<TimeSpan>[parallel];
                for (var i = 0; i < parallel; i++)
                {
                    _latencies[i] = new List<TimeSpan>();
                }

                if (rate.HasValue)
                {
                    _correctedLatencies = new List<TimeSpan>[parallel];
                    for (var i = 0; i < parallel; i++)
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
            var progressStatusThread = PrintStatus(
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
                progressStatusCts.Token);

            Thread pendingOperationsThread = null;
            if (rate.HasValue)
            {
                _pendingOperations = Channel.CreateUnbounded<ValueTuple<TimeSpan, Stopwatch>>();
                pendingOperationsThread = WritePendingOperations(rate.Value, cancellationToken);
            }

            if (sync)
            {
                var threads = new Thread[parallel];

                for (var i = 0; i < parallel; i++)
                {
                    var j = i;
                    threads[i] = new Thread(() => RunLoop(tests[j], j, latency, cancellationToken));
                    threads[i].Start();
                }
                for (var i = 0; i < parallel; i++)
                {
                    threads[i].Join();
                }
            }
            else
            {
                var tasks = new Task[parallel];
                for (var i = 0; i < parallel; i++)
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

        private static void RunLoop(IPerfStressTest test, int index, bool latency, CancellationToken cancellationToken)
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

        private static async Task RunLoopAsync(IPerfStressTest test, int index, bool latency, CancellationToken cancellationToken)
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
                if (!ContainsOperationCanceledException(e))
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

        // Run in dedicated thread instead of using async/await in ThreadPool, to ensure this thread has priority
        // and never fails to run to due ThreadPool starvation.
        private static Thread PrintStatus(string header, Func<object> status, bool newLine, CancellationToken token)
        {
            var thread = new Thread(() =>
            {
                Console.WriteLine(header);

                bool needsExtraNewline = false;

                while (!token.IsCancellationRequested)
                {
                    try
                    {
                        Sleep(TimeSpan.FromSeconds(1), token);
                    }
                    catch (OperationCanceledException)
                    {
                    }

                    var obj = status();

                    if (newLine)
                    {
                        Console.WriteLine(obj);
                    }
                    else
                    {
                        Console.Write(obj);
                        needsExtraNewline = true;
                    }
                }

                if (needsExtraNewline)
                {
                    Console.WriteLine();
                }

                Console.WriteLine();
            });

            thread.Start();

            return thread;
        }

        private static void Sleep(TimeSpan timeout, CancellationToken token)
        {
            var sw = Stopwatch.StartNew();
            while (sw.Elapsed < timeout)
            {
                if (token.IsCancellationRequested)
                {
                    // Simulate behavior of Task.Delay(TimeSpan, CancellationToken)
                    throw new OperationCanceledException();
                }

                Thread.Sleep(TimeSpan.FromMilliseconds(10));
            }
        }

        private static bool ContainsOperationCanceledException(Exception e)
        {
            if (e is OperationCanceledException)
            {
                return true;
            }
            else if (e.InnerException != null)
            {
                return ContainsOperationCanceledException(e.InnerException);
            }
            else
            {
                return false;
            }
        }

        // Dynamically create option types with a "Verb" attribute
        private static Type[] GetOptionTypes(IEnumerable<Type> testTypes)
        {
            var optionTypes = new List<Type>();

            var ab = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("Options"), AssemblyBuilderAccess.Run);
            var mb = ab.DefineDynamicModule("Options");

            foreach (var t in testTypes)
            {
                var baseOptionsType = t.GetConstructors().First().GetParameters()[0].ParameterType;
                var tb = mb.DefineType(t.Name + "Options", TypeAttributes.Public, baseOptionsType);

                var attrCtor = typeof(VerbAttribute).GetConstructor(new Type[] { typeof(string), typeof(bool) });
                var verbName = GetVerbName(t.Name);
                tb.SetCustomAttribute(new CustomAttributeBuilder(attrCtor,
                    new object[] { verbName, attrCtor.GetParameters()[1].DefaultValue }));

                optionTypes.Add(tb.CreateType());
            }

            return optionTypes.ToArray();
        }

        private static string GetVerbName(string testName)
        {
            var lower = testName.ToLowerInvariant();
            return lower.EndsWith("test") ? lower.Substring(0, lower.Length - 4) : lower;
        }
    }
}
