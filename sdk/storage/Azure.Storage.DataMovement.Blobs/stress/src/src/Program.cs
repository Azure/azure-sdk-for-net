// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;
using CommandLine;
using Azure.Core;
using Azure.Identity;
using Azure.Storage.Stress;

namespace Azure.Storage.DataMovement.Blobs.Stress;
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
    public static async Task Main()
    {
        // Parse command line arguments
        await RunAllScenarios().ConfigureAwait(false);
    }

    /// <summary>
    ///   Starts a background task for each test and role that needs to be run in this process, and waits for all
    ///   test runs to completed before finishing the run.
    /// </summary>
    private static async Task RunAllScenarios()
    {
        // See if there are environment variables available to use in the .env file
        var environment = new Dictionary<string, string>();
        var environmentFile = Environment.GetEnvironmentVariable("ENV_FILE");
        environment = EnvironmentReader.LoadFromFile(environmentFile);

        environment.TryGetValue(DataMovementBlobStressConstants.EnvironmentVariables.ApplicationInsightsKey, out var appInsightsKey);
        environment.TryGetValue(DataMovementBlobStressConstants.EnvironmentVariables.StorageBlobEndpoint, out var blobEndpoint);
        Console.Out.WriteLine($"Finished reading environment file\n" +
            $"ApplicationInsightsKey: {appInsightsKey}\n" +
            $"Blob Endpoint: {blobEndpoint}\n");

        // Check values

        // If a job index is provided, a single role is started, otherwise, all specified roles within the
        // test scenario runs are run in parallel.

        TokenCredential tokenCredential = new DefaultAzureCredential();
        Console.Out.WriteLine($"Retrieved Token Credential");

        using var cancellationSource = new CancellationTokenSource();
        var runDuration = TimeSpan.FromHours(1);
        cancellationSource.CancelAfter(runDuration);

        var metrics = new Metrics(appInsightsKey);

        using var azureEventListener = new AzureEventSourceListener((args, level) => metrics.Client.TrackTrace($"EventWritten: {args.ToString()} Level: {level}."), EventLevel.Warning);
        Console.Out.WriteLine($"Started up Source Listener");

        try
        {
            metrics.Client.Context.GlobalProperties["TestName"] = "UploadSingleBlockBlob";
            string guid = Guid.NewGuid().ToString();

            metrics.Client.TrackEvent("Starting a test run.");
            Console.Out.WriteLine($"Starting test run...");

            TestScenarioBase testScenarioInstance = new BlobSingleUploadScenario(new Uri(blobEndpoint), tokenCredential, metrics, guid);

            var testRun = testScenarioInstance.RunTestAsync(cancellationSource.Token);

            while (!testRun.IsCompleted)
            {
                metrics.UpdateEnvironmentStatistics();
                await Task.Delay(TimeSpan.FromMinutes(5), cancellationSource.Token).ConfigureAwait(false);
            }

            metrics.Client.TrackEvent("Test run is ending.");
            Console.Out.WriteLine("Test run is ending.");
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
            Console.Out.WriteLine($"Exception: {ex.StackTrace}");
        }
        finally
        {
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
        "UploadSingleBlockBlob" => TestScenarioName.UploadSingleBlockBlobTest,
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
