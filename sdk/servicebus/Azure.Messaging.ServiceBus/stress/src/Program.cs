// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using CommandLine;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Messaging.ServiceBus.Stress;

/// <summary>
///   The main program thread that allows for both local and deployed test runs.
///   Determines which tests should be run and starts them in the background.
/// </summary>
///
public class Program
{
    /// <summary>
    ///   Parses the command line <see cref="Options" /> and runs the specified tests.
    /// </summary>
    ///
    /// <param name="args">The command line inputs.</param>
    ///
    public static async Task Main(string[] args)
    {
        // Parse command line arguments
        await CommandLine.Parser.Default.ParseArguments<Options>(args).WithParsedAsync(RunOptions).ConfigureAwait(false);
    }

    /// <summary>
    ///   Starts a background task for each test and role that needs to be run in this process, and waits for all
    ///   test runs to completed before finishing the run.
    /// </summary>
    ///
    /// <param name="opts">The parsed command line inputs.</param>
    ///
    private static async Task RunOptions(Options opts)
    {
        // See if there are environment variables available to use in the .env file
        var environment = new Dictionary<string, string>();
        var environmentFile = Environment.GetEnvironmentVariable("ENV_FILE");
        environment = EnvironmentReader.LoadFromFile(environmentFile);

        environment.TryGetValue(EnvironmentVariables.ApplicationInsightsKey, out var appInsightsKey);
        environment.TryGetValue(EnvironmentVariables.ServiceBusConnectionString, out var serviceBusConnectionString);

        // If a job index is provided, a single role is started, otherwise, all specified roles within the
        // test scenario runs are run in parallel.

        var testParameters = new TestParameters();
        testParameters.ServiceBusConnectionString = serviceBusConnectionString;

        using var cancellationSource = new CancellationTokenSource();
        var runDuration = TimeSpan.FromHours(testParameters.DurationInHours);
        cancellationSource.CancelAfter(runDuration);

        var metrics = new Metrics(appInsightsKey);

        using var azureEventListener = new AzureEventSourceListener((args, level) => metrics.Client.TrackTrace($"EventWritten: {args.ToString()} Level: {level}."), EventLevel.Warning);

        try
        {
            var testScenario = StringToTestScenario(opts.Test);
            var testScenarioName = testScenario.ToString();
            metrics.Client.Context.GlobalProperties["TestName"] = testScenarioName;

            var queueName = string.Empty;
            environment.TryGetValue(EnvironmentVariables.ServiceBusQueue, out queueName);

            var sessionQueueName = string.Empty;
            environment.TryGetValue(EnvironmentVariables.ServiceBusSessionQueue, out sessionQueueName);

            metrics.Client.TrackEvent("Starting a test run.");

            TestScenario testScenarioInstance = null;

            switch (testScenario)
            {
                case TestScenarioName.SendReceiveTest:
                    testParameters.QueueName = queueName;
                    testScenarioInstance = new SendReceiveTest(testParameters, metrics, opts.Role);
                    break;

                case TestScenarioName.SendReceiveBatchesTest:
                    testParameters.QueueName = queueName;
                    testScenarioInstance = new SendReceiveBatchesTest(testParameters, metrics, opts.Role);
                    break;

                case TestScenarioName.SessionSendReceiveTest:
                    testParameters.QueueName = sessionQueueName;
                    testScenarioInstance = new SessionSendReceiveTest(testParameters, metrics, opts.Role);
                    break;

                case TestScenarioName.SendProcessTest:
                    testParameters.QueueName = queueName;
                    testScenarioInstance = new SendProcessTest(testParameters, metrics, opts.Role);
                    break;

                case TestScenarioName.SessionSendProcessTest:
                    testParameters.QueueName = sessionQueueName;
                    testScenarioInstance = new SessionSendProcessTest(testParameters, metrics, opts.Role);
                    break;
            }

            var testRun = testScenarioInstance.RunTestAsync(cancellationSource.Token);

            while (!testRun.IsCompleted)
            {
                metrics.UpdateEnvironmentStatistics();
                await Task.Delay(TimeSpan.FromMinutes(5), cancellationSource.Token).ConfigureAwait(false);
            }

            metrics.Client.TrackEvent("Test run is ending.");
        }
        catch (TaskCanceledException)
        {
            // Run is complete
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
        finally
        {
            // The test parameters need to be disposed in order to dispose the SHA 256 hash used to check
            // for message corruption.
            testParameters.Dispose();

            // We need to wait one minute after flushing the Application Insights client. The Application
            // Insights flush is non-deterministic, so we don't want to let the application close until
            // all telemetry has been sent.
            metrics.Client.Flush();
            await Task.Delay(60000).ConfigureAwait(false);
        }
    }

    /// <summary>
    ///   Converts a string into a <see cref="TestScenarioName"/> value.
    /// </summary>
    ///
    /// <param name="testScenario">The string to convert to a <see cref="TestScenarioName"/>.</param>
    ///
    /// <returns>The <see cref="TestScenarioName"/> of the string input.</returns>
    ///
    public static TestScenarioName StringToTestScenario(string testScenario) => testScenario switch
    {
        "SendReceiveTest" or "SendRec" => TestScenarioName.SendReceiveTest,
        "SendReceiveBatchesTest" or "SendRecBatch" => TestScenarioName.SendReceiveBatchesTest,
        "SessionSendReceiveTest" or "SessionSendRec" => TestScenarioName.SessionSendReceiveTest,
        "SessionSendProcessTest" or "SessionSendProc" => TestScenarioName.SessionSendProcessTest,
        "SendProcessTest" or "SendProc" => TestScenarioName.SendProcessTest,
        _ => throw new ArgumentNullException(),
    };

    /// <summary>
    ///   The available command line options that can be parsed.
    /// </summary>
    ///
    internal class Options
    {
        [Option('t', "test", HelpText = "Test scenario to run.")]
        public string Test { get; set; }

        [Option('r', "role", HelpText = "Role to run in this container.")]
        public string Role { get; set; }
    }
}