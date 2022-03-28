using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using dotenv.net;

namespace EventProducerTest
{
    public static class Program
    {
        private static readonly TimeSpan DefaultProcessReportInterval = TimeSpan.FromSeconds(45);
        private static readonly TimeSpan DefaultRunDuration = TimeSpan.FromHours(72);
        private static readonly string DefaultErrorLogPath = Path.Combine(Environment.CurrentDirectory, $"producer-run-errors-{ DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") }.log");

        public static async Task Main(string[] args)
        {
            var runDuration = DefaultRunDuration;
            var errorLogPath = DefaultErrorLogPath;

            var ENV_FILE = Environment.GetEnvironmentVariable("ENV_FILE");
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: new[] {ENV_FILE}));

            var connectionString = Environment.GetEnvironmentVariable("EVENTHUB_NAMESPACE_CONNECTION_STRING");
            var eventHubName = Environment.GetEnvironmentVariable("EVENTHUB_NAME_EPT");

            using var cancellationSource = new CancellationTokenSource();
            using var errorWriter = new StreamWriter(File.Open(errorLogPath, FileMode.Create, FileAccess.Write, FileShare.Read));
            using var metricsWriter = Console.Out;
            using var azureEventListener = ListenForEventSourceErrors(errorWriter);

            try
            {
                var message = $"{ Environment.NewLine }{ Environment.NewLine }=============================={ Environment.NewLine }  Run Starting{ Environment.NewLine }=============================={ Environment.NewLine }";
                metricsWriter.WriteLine(message);
                errorWriter.WriteLine(message);

                cancellationSource.CancelAfter(runDuration);

                var configuration = new TestConfiguration
                {
                    EventHubsConnectionString = connectionString,
                    EventHub = eventHubName
                };

                var testRun = new TestRun(configuration);
                var testRunTask = testRun.Start(cancellationSource.Token);

                // Make an initial metrics report now that the run is taking place.

                await (Task.Delay(TimeSpan.FromSeconds(1)));
                await ReportMetricsAsync(metricsWriter, testRun.Metrics, runDuration, configuration);

                // Allow the run to take place, periodically reporting.

                while (!cancellationSource.IsCancellationRequested)
                {
                    try
                    {
                        await Task.Delay(DefaultProcessReportInterval, cancellationSource.Token);
                    }
                    catch (TaskCanceledException)
                    {
                        message = $"{ Environment.NewLine }{ Environment.NewLine }--------------------------------------------------------------------------{ Environment.NewLine }  The run is ending.  Waiting for clean-up and final reporting...{ Environment.NewLine }--------------------------------------------------------------------------{ Environment.NewLine }";
                        metricsWriter.WriteLine(message);
                        errorWriter.WriteLine(message);
                    }

                    await Task.WhenAll
                    (
                        ReportMetricsAsync(metricsWriter, testRun.Metrics, runDuration, configuration),
                        ReportErrorsAsync(errorWriter, testRun.ErrorsObserved)
                    );
                }

                // Allow the run to complete and then perform a final pas on reporting
                // to ensure that any straggling operations are captures.

                await testRunTask;
                Interlocked.Exchange(ref testRun.Metrics.RunDurationMilliseconds, runDuration.TotalMilliseconds);

                await Task.WhenAll
                (
                    ReportMetricsAsync(metricsWriter, testRun.Metrics, runDuration, configuration),
                    ReportErrorsAsync(errorWriter, testRun.ErrorsObserved)
                );

                message = $"{ Environment.NewLine }{ Environment.NewLine }=============================={ Environment.NewLine }  Run Complete{ Environment.NewLine }==============================";
                metricsWriter.WriteLine(message);
                errorWriter.WriteLine(message);
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
                var message = $"{ Environment.NewLine }{ Environment.NewLine }=============================={ Environment.NewLine }  Error in the main loop.  Run aborting.  Message: [{ ex.Message }]{ Environment.NewLine }==============================";
                metricsWriter.WriteLine(message);
                errorWriter.WriteLine(message);
            }
            finally
            {
                errorWriter.Close();
            }
        }

        private static Task ReportMetricsAsync(TextWriter writer,
                                               Metrics metrics,
                                               TimeSpan runDuration,
                                               TestConfiguration configuration)
        {
            long metric;

            var message = new StringBuilder();

            // Run time

            var runDurationMilliseconds = Interlocked.CompareExchange(ref metrics.RunDurationMilliseconds, 0.0, 0.0);
            var currentDuration = TimeSpan.FromMilliseconds(runDurationMilliseconds > 0.0 ? runDurationMilliseconds : 1);
            var averageMemory =  metrics.TotalMemoryUsed / metrics.MemorySamples;

            message.AppendLine("Run Metrics");
            message.AppendLine("=========================");
            message.AppendLine($"\tRun Duration:\t\t\t{ runDuration.ToString(@"dd\.hh\:mm\:ss") }");
            message.AppendLine($"\tElapsed:\t\t\t{ currentDuration.ToString(@"dd\.hh\:mm\:ss") } ({ (currentDuration / runDuration).ToString("P", CultureInfo.InvariantCulture) })");
            message.AppendLine($"\tTotal Processor Time:\t\t{ metrics.TotalProcessorTime.ToString(@"dd\.hh\:mm\:ss") }");
            message.AppendLine($"\tAverage Memory Use:\t\t{ FormatBytes(averageMemory) }");
            message.AppendLine($"\tCurrent Memory Use:\t\t{ FormatBytes(metrics.MemoryUsed) }");
            message.AppendLine($"\tPeak Memory Use:\t\t{ FormatBytes(metrics.PeakPhysicalMemory) }");
            message.AppendLine($"\tGC Gen 0 Collections:\t\t{ metrics.GenerationZeroCollections.ToString("n0") }");
            message.AppendLine($"\tGC Gen 1 Collections:\t\t{ metrics.GenerationOneCollections.ToString("n0") }");
            message.AppendLine($"\tGC Gen 2 Collections:\t\t{ metrics.GenerationTwoCollections.ToString("n0") }");
            message.AppendLine($"\tNumber of Publishers:\t\t{ configuration.ProducerCount.ToString("n0") }");
            message.AppendLine($"\tConcurrent Sends per Publisher:\t{ configuration.ConcurrentSends.ToString("n0") }");
            message.AppendLine($"\tTarget Batch Size:\t\t{ configuration.PublishBatchSize.ToString("n0") } (events)");
            message.AppendLine($"\tMinimum Message Size:\t\t{ configuration.PublishingBodyMinBytes.ToString("n0") } (bytes)");
            message.AppendLine($"\tLarge Message Factor:\t\t{ configuration.LargeMessageRandomFactorPercent } %");
            message.AppendLine();

            // Publish and read pairing

            message.AppendLine("Publishing");
            message.AppendLine("=========================");

            var publishAttempts = (double)Interlocked.Read(ref metrics.PublishAttempts);
            message.AppendLine($"\tSend Attempts:\t\t\t{ publishAttempts.ToString("n0") }");
            publishAttempts = (publishAttempts > 0) ? publishAttempts : 0.001;

            var batches = (double)Interlocked.Read(ref metrics.BatchesPublished);
            message.AppendLine($"\tBatches Published:\t\t{ batches.ToString("n0") } ({ (batches / publishAttempts).ToString("P", CultureInfo.InvariantCulture) })");
            batches = (batches > 0) ? batches : 0.001;

            metric = Interlocked.Read(ref metrics.EventsPublished);
            message.AppendLine($"\tEvents Published:\t\t{ metric.ToString("n0") }");
            message.AppendLine($"\tAverage Events per Batch:\t{ ( metric / batches).ToString("n0") }");

            metric = Interlocked.Read(ref metrics.TotalPublshedSizeBytes);
            message.AppendLine($"\tAverage Batch Size:\t\t{ FormatBytes((long)(metric / batches)) }");

            message.AppendLine();

            // Client health

            message.AppendLine("Client Health");
            message.AppendLine("=========================");

            metric = Interlocked.Read(ref metrics.ProducerRestarted);
            message.AppendLine($"\tProducer Restarts:\t\t{ metric }");

            var cancelledSends = Interlocked.Read(ref metrics.CanceledSendExceptions);
            message.AppendLine($"\tAborted Sends:\t\t\t{ cancelledSends }");

            message.AppendLine();

            // Exceptions

            message.AppendLine("Exception Breakdown");
            message.AppendLine("=========================");

            var totalExceptions = (double)Interlocked.Read(ref metrics.TotalExceptions);
            message.AppendLine($"\tExceptions for All Operations:\t{ totalExceptions.ToString("n0") } ({ (totalExceptions / publishAttempts).ToString("P", CultureInfo.InvariantCulture) })");
            totalExceptions = (totalExceptions > 0) ? totalExceptions : 0.001;

            metric = Interlocked.Read(ref metrics.SendExceptions);
            message.AppendLine($"\tException During Send:\t\t{ metric.ToString("n0") } ({ (metric / totalExceptions).ToString("P", CultureInfo.InvariantCulture) })");

            metric = Interlocked.Read(ref metrics.GeneralExceptions);
            message.AppendLine($"\tGeneral Exceptions:\t\t{ metric.ToString("n0") } ({ (metric / totalExceptions).ToString("P", CultureInfo.InvariantCulture) })");

            metric = Interlocked.Read(ref metrics.TimeoutExceptions);
            message.AppendLine($"\tTimeout Exceptions:\t\t{ metric.ToString("n0") } ({ (metric / totalExceptions).ToString("P", CultureInfo.InvariantCulture) })");

            message.AppendLine($"\tOperation Canceled Exceptions:\t{ cancelledSends.ToString("n0") } ({ (cancelledSends / totalExceptions).ToString("P", CultureInfo.InvariantCulture) })");

            metric = Interlocked.Read(ref metrics.CommunicationExceptions);
            message.AppendLine($"\tCommunication Exceptions:\t{ metric.ToString("n0") } ({ (metric / totalExceptions).ToString("P", CultureInfo.InvariantCulture) })");

            metric = Interlocked.Read(ref metrics.ServiceBusyExceptions);
            message.AppendLine($"\tService Busy Exceptions:\t{ metric.ToString("n0") } ({ (metric / totalExceptions).ToString("P", CultureInfo.InvariantCulture) })");

            // Spacing

            message.AppendLine();
            message.AppendLine();
            message.AppendLine();
            message.AppendLine();

            return writer.WriteLineAsync(message.ToString());
        }

        private static string FormatBytes(long bytes)
        {
            const long scale = 1024;

            var orders = new string[]{ "TB", "MB", "KB", "bytes" };
            var max = (long)Math.Pow(scale, (orders.Length - 1));

            foreach (string order in orders)
            {
                if (bytes > max)
                {
                    return string.Format("{0:n2} {1}", Decimal.Divide(bytes, max), order);
                }

                max /= scale;
            }

            return "0 bytes";
        }

         private static async Task ReportErrorsAsync(TextWriter writer,
                                                     ConcurrentBag<Exception> exceptions)
        {
            var nowStamp = $"[{ DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss:tt") }] ";

            Exception currentException;

            while (exceptions.TryTake(out currentException))
            {
                await writer.WriteLineAsync
                (
                    $"{ nowStamp }[ { currentException.GetType().Name } ]{Environment.NewLine}{ currentException.Message ?? "No message available" }{ Environment.NewLine }{ currentException.StackTrace ?? "No stack trace available" }{ Environment.NewLine }< { currentException.InnerException?.GetType()?.Name ?? "No Inner Exception" } >{ Environment.NewLine }"
                );
            }

            writer.Flush();
        }

        private static AzureEventSourceListener ListenForEventSourceErrors(TextWriter writer)
        {
            void processLogEvent(EventWrittenEventArgs args, string message)
            {
                try
                {
                    writer.WriteLine
                    (
                        $"[ { args.EventSource } :: { args.EventName } ]{Environment.NewLine}{ message ?? "No message available" }{ Environment.NewLine }{ "No stack trace available" }{ Environment.NewLine }"
                    );
                }
                catch
                {
                    // This is likely due to a race condition while ending a run.  Ignore.
                }
            }

            return new AzureEventSourceListener(processLogEvent, EventLevel.Error);
        }

        private static CommandLineArguments ParseAndPromptForArguments(string[] commandLineArgs)
        {
            var parsedArgs = ParseArguments(commandLineArgs);

            // Prompt for the Event Hubs connection string, if it wasn't passed.

            while (string.IsNullOrEmpty(parsedArgs.EventHubsConnectionString))
            {
                Console.Write("Please provide the connection string for the Event Hubs namespace that you'd like to use and then press Enter: ");
                parsedArgs.EventHubsConnectionString = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            // Prompt for the Event Hub name, if it wasn't passed.

            while (string.IsNullOrEmpty(parsedArgs.EventHub))
            {
                Console.Write("Please provide the name of the Event Hub that you'd like to use and then press Enter: ");
                parsedArgs.EventHub = Console.ReadLine().Trim();
                Console.WriteLine();
            }

            return parsedArgs;
        }

        private static CommandLineArguments ParseArguments(string[] args)
        {
            // If at least two arguments were passed with no argument designator, then assume they're values and
            // accept them positionally.

            if ((args.Length >= 2)
                && (!args[0].StartsWith(CommandLineArguments.ArgumentPrefix))
                && (!args[1].StartsWith(CommandLineArguments.ArgumentPrefix)))
            {
                var parsed = new CommandLineArguments
                {
                    EventHubsConnectionString = args[0],
                    EventHub = args[1]
                };

                if ((args.Length >= 5) && (!args[4].StartsWith(CommandLineArguments.ArgumentPrefix)))
                {
                    parsed.RunDurationHours = args[4];
                }

                if ((args.Length >= 6) && (!args[5].StartsWith(CommandLineArguments.ArgumentPrefix)))
                {
                    parsed.LogPath = args[4];
                }

                return parsed;
            }

            var parsedArgs = new CommandLineArguments();

            // Enumerate the arguments that were passed, stopping one before the
            // end, since we're scanning forward by an item to retrieve values;  if a
            // command was passed in the last position, there was no accompanying value,
            // so it isn't useful.

            for (var index = 0; index < args.Length - 1; ++index)
            {
                // Remove any excess spaces to comparison purposes.

                args[index] = args[index].Trim();

                // Since we're evaluating the next token in sequence as a value in the
                // checks that follow, if it is an argument, we'll skip to the next iteration.

                if (args[index + 1].StartsWith(CommandLineArguments.ArgumentPrefix))
                {
                    continue;
                }

                // If the current token is one of our known arguments, capture the next token in sequence as it's
                // value, since we've already ruled out that it is another argument name.

                if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.EventHubsConnectionString) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.EventHubsConnectionString = args[index + 1].Trim();
                }
                else if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.EventHub) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.EventHub = args[index + 1].Trim();
                }
                else if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.RunDurationHours) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.RunDurationHours = args[index + 1].Trim();
                }
                else if (args[index].Equals($"{ CommandLineArguments.ArgumentPrefix }{ nameof(CommandLineArguments.LogPath) }", StringComparison.OrdinalIgnoreCase))
                {
                    parsedArgs.LogPath = args[index + 1].Trim();
                }
            }

            return parsedArgs;
        }

        private class CommandLineArguments
        {
            public const string ArgumentPrefix = "--";
            public string EventHubsConnectionString;
            public string EventHub;
            public string RunDurationHours;
            public string LogPath;
        }
    }
}