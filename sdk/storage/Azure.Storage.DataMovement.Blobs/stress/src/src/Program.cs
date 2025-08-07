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
    public static async Task Main(string[] args)
    {
        // Parse command line arguments
        await CommandLine.Parser.Default.ParseArguments<Options>(args).WithParsedAsync(RunOptions).ConfigureAwait(false);
    }

    /// <summary>
    ///   Starts a background task for each test and role that needs to be run in this process, and waits for all
    ///   test runs to completed before finishing the run.
    /// </summary>
    private static async Task RunOptions(Options opts)
    {
        // See if there are environment variables available to use in the .env file
        var environment = new Dictionary<string, string>();
        var environmentFile = Environment.GetEnvironmentVariable("ENV_FILE");
        environment = EnvironmentReader.LoadFromFile(environmentFile);

        environment.TryGetValue(DataMovementBlobStressConstants.EnvironmentVariables.ApplicationInsightsKey, out var appInsightsKey);
        environment.TryGetValue(DataMovementBlobStressConstants.EnvironmentVariables.StorageSourceBlobEndpoint, out var blobSourceEndpoint);
        environment.TryGetValue(DataMovementBlobStressConstants.EnvironmentVariables.StorageDestinationBlobEndpoint, out var blobDestinationEndpoint);

        // Check values

        // If a job index is provided, a single role is started, otherwise, all specified roles within the
        // test scenario runs are run in parallel.

        TokenCredential tokenCredential = new DefaultAzureCredential();

        using var cancellationSource = new CancellationTokenSource();
        var runDuration = TimeSpan.FromHours(1);
        cancellationSource.CancelAfter(runDuration);

        var metrics = new Metrics(appInsightsKey);

        using var azureEventListener = new AzureEventSourceListener((args, level) => metrics.Client.TrackTrace($"EventWritten: {args.ToString()} Level: {level}."), EventLevel.Warning);

        try
        {
            TestScenarioName testScenarioName = StringToTestScenario(opts.Test);
            metrics.Client.Context.GlobalProperties["TestName"] = opts.Test;
            string guid = Guid.NewGuid().ToString();

            metrics.Client.TrackEvent($"Starting a test {testScenarioName} run.");

            TestScenarioBase testScenario = null;
            TransferManagerOptions transferManagerOptions = new TransferManagerOptions()
            {
                MaximumConcurrency = opts.Parallel,
            };
            TransferOptions transferOptions = new()
            {
                MaximumTransferChunkSize = opts.BlockSize,
                InitialTransferSize = opts.InitialTransferSize,
            };
            switch (testScenarioName)
            {
                case TestScenarioName.UploadSingleBlockBlob:
                    testScenario = new UploadBlockBlobSingleScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.UploadDirectoryBlockBlob:
                    testScenario = new UploadBlockBlobDirectoryScenario(
                        destinationBlobUri: new Uri(blobSourceEndpoint),
                        blobSize: opts.Size,
                        blobCount: opts.Count,
                        transferManagerOptions: transferManagerOptions,
                        transferOptions: transferOptions,
                        tokenCredential: tokenCredential,
                        metrics: metrics,
                        testRunId: guid);
                    break;
                case TestScenarioName.DownloadSingleBlockBlob:
                    testScenario = new DownloadBlockBlobSingleScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.DownloadDirectoryBlockBlob:
                    testScenario = new DownloadBlockBlobDirectoryScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        opts.Count,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.CopySingleBlockBlob:
                    testScenario = new CopyBlockBlobSingleScenario(
                        new Uri(blobSourceEndpoint),
                        new Uri(blobDestinationEndpoint),
                        opts.Size,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.CopyDirectoryBlockBlob:
                    testScenario = new CopyBlockBlobDirectoryScenario(
                        new Uri(blobSourceEndpoint),
                        new Uri(blobDestinationEndpoint),
                        opts.Size,
                        opts.Count,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.UploadSingleAppendBlob:
                    testScenario = new UploadAppendBlobSingleScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.UploadDirectoryAppendBlob:
                    testScenario = new UploadAppendBlobDirectoryScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        opts.Count,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.DownloadSingleAppendBlob:
                    testScenario = new DownloadAppendBlobSingleScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.DownloadDirectoryAppendBlob:
                    testScenario = new DownloadAppendBlobDirectoryScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        opts.Count,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.CopySingleAppendBlob:
                    testScenario = new CopyAppendBlobSingleScenario(
                        new Uri(blobSourceEndpoint),
                        new Uri(blobDestinationEndpoint),
                        opts.Size,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.CopyDirectoryAppendBlob:
                    testScenario = new CopyAppendBlobDirectoryScenario(
                        new Uri(blobSourceEndpoint),
                        new Uri(blobDestinationEndpoint),
                        opts.Size,
                        opts.Count,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.UploadSinglePageBlob:
                    testScenario = new UploadPageBlobSingleScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.UploadDirectoryPageBlob:
                    testScenario = new UploadPageBlobDirectoryScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        opts.Count,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.DownloadSinglePageBlob:
                    testScenario = new DownloadPageBlobSingleScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.DownloadDirectoryPageBlob:
                    testScenario = new DownloadPageBlobDirectoryScenario(
                        new Uri(blobSourceEndpoint),
                        opts.Size,
                        opts.Count,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.CopySinglePageBlob:
                    testScenario = new CopyPageBlobSingleScenario(
                        new Uri(blobSourceEndpoint),
                        new Uri(blobDestinationEndpoint),
                        opts.Size,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                case TestScenarioName.CopyDirectoryPageBlob:
                    testScenario = new CopyPageBlobDirectoryScenario(
                        new Uri(blobSourceEndpoint),
                        new Uri(blobDestinationEndpoint),
                        opts.Size,
                        opts.Count,
                        transferManagerOptions,
                        transferOptions,
                        tokenCredential,
                        tokenCredential,
                        metrics,
                        guid);
                    break;
                default:
                    throw new Exception("No Scenario or Invalid scenario passed");
            }

            var testRun = testScenario.RunTestAsync(cancellationSource.Token);

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
        DataMovementBlobStressConstants.TestScenarioNameStr.UploadSingleBlockBlob => TestScenarioName.UploadSingleBlockBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.UploadDirectoryBlockBlob => TestScenarioName.UploadDirectoryBlockBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.DownloadSingleBlockBlob => TestScenarioName.DownloadSingleBlockBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.DownloadDirectoryBlockBlob => TestScenarioName.DownloadDirectoryBlockBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.CopySingleBlockBlob => TestScenarioName.CopySingleBlockBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.CopyDirectoryBlockBlob => TestScenarioName.CopyDirectoryBlockBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.UploadSingleAppendBlob => TestScenarioName.UploadSingleAppendBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.UploadDirectoryAppendBlob => TestScenarioName.UploadDirectoryAppendBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.DownloadSingleAppendBlob => TestScenarioName.DownloadSingleAppendBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.DownloadDirectoryAppendBlob => TestScenarioName.DownloadDirectoryAppendBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.CopySingleAppendBlob => TestScenarioName.CopySingleAppendBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.CopyDirectoryAppendBlob => TestScenarioName.CopyDirectoryAppendBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.UploadSinglePageBlob => TestScenarioName.UploadSinglePageBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.UploadDirectoryPageBlob => TestScenarioName.UploadDirectoryPageBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.DownloadSinglePageBlob => TestScenarioName.DownloadSinglePageBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.DownloadDirectoryPageBlob => TestScenarioName.DownloadDirectoryPageBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.CopySinglePageBlob => TestScenarioName.CopySinglePageBlob,
        DataMovementBlobStressConstants.TestScenarioNameStr.CopyDirectoryPageBlob => TestScenarioName.CopyDirectoryPageBlob,
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

        [Option('s', "size", HelpText = "Size of each objects to transfer.")]
        public int? Size { get; set; }

        [Option('b', "blockSize", HelpText = "Size of the chunk/block size")]
        public int? BlockSize { get; set; }

        [Option('i', "initialTransferSize", HelpText = "Initial transfer size.")]
        public int? InitialTransferSize { get; set; }

        [Option('c', "count", HelpText = "Number of objects to transfer.")]
        public int? Count { get; set; }

        [Option('d', "duration", HelpText = "Duration of the test run.")]
        public int? Duration { get; set; }

        [Option('p', "parallel", HelpText = "Maximum concurrency.")]
        public int? Parallel { get; set; }
    }
}
