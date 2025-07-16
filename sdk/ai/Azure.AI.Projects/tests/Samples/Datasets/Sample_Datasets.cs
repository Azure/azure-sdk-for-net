// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

// TODO: issue with UploadFile/UploadFolder: Error Message: System.ClientModel.ClientResultException : Service request failed. Status: 500 (Received 400 from a service request)
// need to compare api calls with pre-SCM transition or figure out where there is an issue, possibly work with Josh Love for SCM issues
// TODO: having issues with Get(datasetName, datasetVersion) and GetCredentials(datasetName, datasetVersion) methods -- not finding full ID
// TODO: having issues with GetVersions(datasetName) and GetDatasetVersions() methods -- looping/excessive time in net462, works in net8.0 and 9.0
// TODO: remove debugging code before releasing

namespace Azure.AI.Projects.Tests
{
    public class Sample_Datasets : SamplesBase<AIProjectsTestEnvironment>
    {
        private void EnableSystemClientModelDebugging()
        {
            // Enable System.ClientModel diagnostics
            ActivitySource.AddActivityListener(new ActivityListener
            {
                ShouldListenTo = _ => true,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
                ActivityStarted = activity => Console.WriteLine($"Started: {activity.DisplayName}"),
                ActivityStopped = activity => Console.WriteLine($"Stopped: {activity.DisplayName} - Duration: {activity.Duration}")
            });
        }

        private AIProjectClient CreateDebugClient(string endpoint)
        {
            var options = new AIProjectClientOptions();

            // Add custom pipeline policy for debugging
            options.AddPolicy(new DebugPipelinePolicy(), PipelinePosition.PerCall);

            return new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential(), options);
        }

        // Custom pipeline policy for debugging System.ClientModel requests
        private class DebugPipelinePolicy : PipelinePolicy
        {
            public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int index)
            {
                Console.WriteLine($"Request: {message.Request.Method} {message.Request.Uri}");

                ProcessNext(message, pipeline, index);

                Console.WriteLine($"Response: {message.Response?.Status} {message.Response?.ReasonPhrase}");
            }

            public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int index)
            {
                Console.WriteLine($"Async Request: {message.Request.Method} {message.Request.Uri}");

                var result = ProcessNextAsync(message, pipeline, index);

                Console.WriteLine($"Async Response: {message.Response?.Status} {message.Response?.ReasonPhrase}");
                return result;
            }
        }

        [Test]
        [SyncOnly]
        public void DatasetsExample()
        {
            EnableSystemClientModelDebugging();

            #region Snippet:AI_Projects_DatasetsExampleSync
#if SNIPPET
            var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
            var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
            var datasetVersion1 = System.Environment.GetEnvironmentVariable("DATASET_VERSION_1") ?? "1.0";
            var datasetVersion2 = System.Environment.GetEnvironmentVariable("DATASET_VERSION_2") ?? "2.0";
            var filePath = System.Environment.GetEnvironmentVariable("SAMPLE_FILE_PATH") ?? "sample_folder/sample_file1.txt";
            var folderPath = System.Environment.GetEnvironmentVariable("SAMPLE_FOLDER_PATH") ?? "sample_folder";
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var connectionName = TestEnvironment.CONNECTIONNAME;
            var datasetName = TestEnvironment.DATASETNAME;
            var filePath = TestEnvironment.SAMPLEFILEPATH;
            var folderPath = TestEnvironment.SAMPLEFOLDERPATH;
            var datasetVersion1 = "1.0";
            var datasetVersion2 = "2.0";
            try
            {
                datasetVersion1 = TestEnvironment.DATASETVERSION1;
                datasetVersion2 = TestEnvironment.DATASETVERSION2;
            }
            catch
            {
                datasetVersion1 = "1.0";
                datasetVersion2 = "2.0";
            }
#endif
            AIProjectClient projectClient = CreateDebugClient(endpoint); // new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

            Console.WriteLine($"Uploading a single file to create Dataset version {datasetVersion1}:");
            FileDatasetVersion fileDataset = projectClient.Datasets.UploadFile(
                name: datasetName,
                version: datasetVersion1,
                filePath: filePath,
                connectionName: connectionName
                );
            Console.WriteLine(fileDataset);

            Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}:");
            FolderDatasetVersion folderDataset = projectClient.Datasets.UploadFolder(
                name: datasetName,
                version: datasetVersion2,
                folderPath: folderPath,
                connectionName: connectionName,
                filePattern: new Regex(".*\\.txt")
            );
            Console.WriteLine(folderDataset);

            Console.WriteLine($"Retrieving Dataset version {datasetVersion1}:");
            DatasetVersion dataset = projectClient.Datasets.Get(datasetName, datasetVersion1);
            Console.WriteLine(dataset.Id);

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
            AssetCredentialResponse credentials = projectClient.Datasets.GetCredentials(datasetName, datasetVersion1);
            Console.WriteLine(credentials);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            foreach (DatasetVersion ds in projectClient.Datasets.GetVersions(datasetName))
            {
                Console.WriteLine(ds);
                Console.WriteLine(ds.Id);
                Console.WriteLine(ds.Version);
            }

            // TODO: delete this when Get() is fixed
            TimeSpan timeout = TimeSpan.FromSeconds(60);
            using var cancellationTokenSource = new CancellationTokenSource(timeout);

            Console.WriteLine($"Listing latest versions for all datasets:");
            var datasetVersions = projectClient.Datasets.Get(cancellationToken: cancellationTokenSource.Token);
            foreach (DatasetVersion ds in datasetVersions)
            {
                Console.WriteLine($"{ds.Name}, {ds.Version}, {ds.Id}");
            }

            Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}:");
            projectClient.Datasets.Delete(datasetName, datasetVersion1);
            projectClient.Datasets.Delete(datasetName, datasetVersion2);
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task DatasetsExampleAsync()
        {
            EnableSystemClientModelDebugging();

            #region Snippet:AI_Projects_DatasetsExampleAsync
#if SNIPPET
            var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
            var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
            var datasetVersion1 = System.Environment.GetEnvironmentVariable("DATASET_VERSION_1") ?? "1.0";
            var datasetVersion2 = System.Environment.GetEnvironmentVariable("DATASET_VERSION_2") ?? "2.0";
            var filePath = System.Environment.GetEnvironmentVariable("SAMPLE_FILE_PATH") ?? "sample_folder/sample_file1.txt";
            var folderPath = System.Environment.GetEnvironmentVariable("SAMPLE_FOLDER_PATH") ?? "sample_folder";
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var datasetName = TestEnvironment.DATASETNAME;
            var connectionName = TestEnvironment.CONNECTIONNAME;
            var filePath = TestEnvironment.SAMPLEFILEPATH;
            var folderPath = TestEnvironment.SAMPLEFOLDERPATH;
            var datasetVersion1 = "1.0";
            var datasetVersion2 = "2.0";
            try
            {
                datasetVersion1 = TestEnvironment.DATASETVERSION1;
                datasetVersion2 = TestEnvironment.DATASETVERSION2;
            }
            catch
            {
                datasetVersion1 = "1.0";
                datasetVersion2 = "2.0";
            }
#endif
            AIProjectClient projectClient = CreateDebugClient(endpoint); // new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

            Console.WriteLine($"Uploading a single file to create Dataset version {datasetVersion1}...");
            FileDatasetVersion fileDataset = await projectClient.Datasets.UploadFileAsync(
                name: datasetName,
                version: datasetVersion1,
                filePath: filePath,
                connectionName: connectionName
                );
            Console.WriteLine(fileDataset);

            Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}...");
            FolderDatasetVersion folderDataset = await projectClient.Datasets.UploadFolderAsync(
                name: datasetName,
                version: datasetVersion2,
                folderPath: folderPath,
                connectionName: connectionName,
                filePattern: new Regex(".*\\.txt")
            );
            Console.WriteLine(folderDataset);

            Console.WriteLine($"Retrieving Dataset version {datasetVersion1}...");
            DatasetVersion dataset = await projectClient.Datasets.GetAsync(datasetName, datasetVersion1);
            Console.WriteLine(dataset);

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
            AssetCredentialResponse credentials = await projectClient.Datasets.GetCredentialsAsync(datasetName, datasetVersion1);
            Console.WriteLine(credentials);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            await foreach (DatasetVersion ds in projectClient.Datasets.GetVersionsAsync(datasetName))
            {
                Console.WriteLine(ds.Version);
            }

            // Console.WriteLine($"Listing latest versions for all datasets:");
            // await foreach (DatasetVersion ds in projectClient.Datasets.GetDatasetVersionsAsync())
            // {
            //     Console.WriteLine(ds);
            // }

            Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}...");
            await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion1);
            await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion2);
            #endregion
        }
    }
};
