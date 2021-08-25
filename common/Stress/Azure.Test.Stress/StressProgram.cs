// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.PerfStress;
using CommandLine;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Test.Stress
{
    public static class StressProgram
    {
        public static async Task Main(Assembly assembly, string[] args)
        {
            var testTypes = assembly.ExportedTypes
                .Where(t => typeof(IStressTest).IsAssignableFrom(t) && !t.IsAbstract);

            if (testTypes.Any())
            {
                var optionTypes = PerfStressUtilities.GetOptionTypes(testTypes);

                await PerfStressUtilities.Parser.ParseArguments(args, optionTypes).MapResult<StressOptions, Task>(
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
                Console.WriteLine($"Assembly '{assembly.GetName().Name}' does not contain any types deriving from 'StressTest'");
            }
        }

        private static async Task Run(Type testType, StressOptions options)
        {
            var header = HeaderString(testType, options);
            Console.WriteLine(header);

            using var setupStatusCts = new CancellationTokenSource();
            var setupStatusThread = PerfStressUtilities.PrintStatus("=== Setup ===", () => ".", newLine: false, setupStatusCts.Token);

            using var cleanupStatusCts = new CancellationTokenSource();
            Thread cleanupStatusThread = null;

            var metricsType = testType.GetConstructors().First().GetParameters()[1].ParameterType;
            var metrics = (StressMetrics)Activator.CreateInstance(metricsType);
            metrics.Duration = TimeSpan.FromSeconds(options.Duration);
            metrics.Options = options;

            var test = (IStressTest)Activator.CreateInstance(testType, options, metrics);

            try
            {
                try
                {
                    await test.SetupAsync();
                    setupStatusCts.Cancel();
                    setupStatusThread.Join();

                    await RunTestAsync(test, options, metrics);
                }
                finally
                {
                    if (!options.NoCleanup)
                    {
                        if (cleanupStatusThread == null)
                        {
                            cleanupStatusThread = PerfStressUtilities.PrintStatus("=== Cleanup ===", () => ".", newLine: false, cleanupStatusCts.Token);
                        }

                        await test.CleanupAsync();
                    }
                }
            }
            finally
            {
                await test.DisposeAsync();
            }

            cleanupStatusCts.Cancel();
            if (cleanupStatusThread != null)
            {
                cleanupStatusThread.Join();
            }

            WriteMetrics(metrics, header, options);
            WriteExceptions(metrics, header, options);
            WriteEvents(metrics, header, options);
        }

        private static string HeaderString(Type testType, StressOptions options)
        {
            var sb = new StringBuilder();

            sb.AppendLine("=== Versions ===");
            sb.AppendLine($"Runtime: {Environment.Version}");
            var azureAssemblies = testType.Assembly.GetReferencedAssemblies()
                .Where(a => a.Name.StartsWith("Azure", StringComparison.OrdinalIgnoreCase))
                .Where(a => !a.Name.Equals("Azure.Test.PerfStress", StringComparison.OrdinalIgnoreCase))
                .OrderBy(a => a.Name);
            foreach (var a in azureAssemblies)
            {
                sb.AppendLine($"{a.Name}: {a.Version}");
            }
            sb.AppendLine();

            sb.AppendLine("=== Environment ===");
            sb.AppendLine($"ProcessorCount: {Environment.ProcessorCount}");
            sb.AppendLine($"GC: {(GCSettings.IsServerGC ? "Server" : "Workstation")}");
            sb.AppendLine();

            sb.AppendLine("=== Options ===");
            sb.AppendLine(JsonSerializer.Serialize(options, options.GetType(), new JsonSerializerOptions()
            {
                WriteIndented = true
            }));
            sb.AppendLine();

            return sb.ToString();
        }

        private static void WriteMetrics(StressMetrics metrics, string header, StressOptions options)
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Final Metrics ===");
            sb.Append(metrics.ToString());
            var metricsString = sb.ToString();

            Console.WriteLine(metricsString);

            if (!string.IsNullOrEmpty(options.MetricsFile))
            {
                File.WriteAllText(options.MetricsFile, header + metricsString);
            }
        }

        private static void WriteExceptions(StressMetrics metrics, string header, StressOptions options)
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Exceptions ===");
            foreach (var exception in metrics.Exceptions)
            {
                sb.AppendLine(exception.ToString());
                sb.AppendLine();
            }
            var exceptionsString = sb.ToString();

            Console.WriteLine(exceptionsString);

            if (!string.IsNullOrEmpty(options.ExceptionsFile))
            {
                File.WriteAllText(options.ExceptionsFile, header + exceptionsString);
            }
        }

        private static void WriteEvents(StressMetrics metrics, string header, StressOptions options)
        {
            var sb = new StringBuilder();
            sb.AppendLine("=== Events ===");
            foreach (var e in metrics.Events)
            {
                sb.AppendLine($"[{e.EventArgs.EventSource.Name} :: {e.EventArgs.EventName}]");
                sb.AppendLine(e.Message);
                sb.AppendLine();
            }
            var eventsString = sb.ToString();

            Console.WriteLine(eventsString);

            if (!string.IsNullOrEmpty(options.EventsFile))
            {
                File.WriteAllText(options.EventsFile, header + eventsString);
            }
        }

        private static async Task RunTestAsync(IStressTest test, StressOptions options, StressMetrics metrics)
        {
            var duration = TimeSpan.FromSeconds(options.Duration);
            using var testCts = new CancellationTokenSource(duration);
            var cancellationToken = testCts.Token;

            metrics.StartAutoUpdate();

            using var progressStatusCts = new CancellationTokenSource();
            var progressStatusThread = PerfStressUtilities.PrintStatus(
                "=== Metrics ===",
                () => metrics.ToString(),
                newLine: true,
                progressStatusCts.Token,
                options.StatusInterval);

            try
            {
                await test.RunAsync(cancellationToken);
            }
            catch (Exception e) when (PerfStressUtilities.ContainsOperationCanceledException(e))
            {
            }
            // TODO: Consider more exception handling, including a special case for OutOfMemoryException, StackOverflowException, etc

            metrics.StopAutoUpdate();

            progressStatusCts.Cancel();
            progressStatusThread.Join();
        }
    }
}
