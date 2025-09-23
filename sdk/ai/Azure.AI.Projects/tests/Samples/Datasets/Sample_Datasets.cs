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

            AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var connectionName = TestEnvironment.CONNECTIONNAME;
            var datasetName = String.Concat(TestEnvironment.DATASETNAME, "-", Guid.NewGuid().ToString("N").Substring(0, 8));
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

            AIProjectClient projectClient = CreateDebugClient(endpoint);
#endif

            Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion1}:");
            FileDataset fileDataset = projectClient.Datasets.UploadFile(
                name: datasetName,
                version: datasetVersion1,
                filePath: filePath,
                connectionName: connectionName
                );
            Console.WriteLine(fileDataset);

            Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}:");
            FolderDataset folderDataset = projectClient.Datasets.UploadFolder(
                name: datasetName,
                version: datasetVersion2,
                folderPath: folderPath,
                connectionName: connectionName,
                filePattern: new Regex(".*\\.txt")
            );
            Console.WriteLine(folderDataset);

            Console.WriteLine($"Retrieving Dataset version {datasetVersion1}:");
            AIProjectDataset dataset = projectClient.Datasets.GetDataset(datasetName, datasetVersion1);
            Console.WriteLine(dataset.Id);

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
            DatasetCredential credentials = projectClient.Datasets.GetCredentials(datasetName, datasetVersion1);
            Console.WriteLine(credentials);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasetVersions(datasetName))
            {
                Console.WriteLine(ds);
                Console.WriteLine(ds.Version);
            }

            Console.WriteLine($"Listing latest versions for all datasets:");
            foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasets())
            {
                Console.WriteLine($"{ds.Name}, {ds.Version}, {ds.Id}");
            }

            Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}:");
            projectClient.Datasets.Delete(datasetName, datasetVersion1);
#if !SNIPPET
            try
            {
                projectClient.Datasets.GetDataset(datasetName, datasetVersion1);
                Console.WriteLine($"Dataset version {datasetVersion1} should not exist, but was retrieved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expected exception when retrieving deleted dataset version 1: {ex.Message}");
            }
#endif

            projectClient.Datasets.Delete(datasetName, datasetVersion2);
#if !SNIPPET
            try
            {
                projectClient.Datasets.GetDataset(datasetName, datasetVersion2);
                Console.WriteLine($"Dataset version {datasetVersion2} should not exist, but was retrieved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expected exception when retrieving deleted dataset version 2: {ex.Message}");
            }
#endif

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

            AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var connectionName = TestEnvironment.CONNECTIONNAME;
            var datasetName = String.Concat(TestEnvironment.DATASETNAME, "-", Guid.NewGuid().ToString("N").Substring(0, 8));
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

            AIProjectClient projectClient = CreateDebugClient(endpoint);
#endif

            Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion1}:");
            FileDataset fileDataset = await projectClient.Datasets.UploadFileAsync(
                name: datasetName,
                version: datasetVersion1,
                filePath: filePath,
                connectionName: connectionName
                );
            Console.WriteLine(fileDataset);

            Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}:");
            FolderDataset folderDataset = await projectClient.Datasets.UploadFolderAsync(
                name: datasetName,
                version: datasetVersion2,
                folderPath: folderPath,
                connectionName: connectionName,
                filePattern: new Regex(".*\\.txt")
            );
            Console.WriteLine(folderDataset);

            Console.WriteLine($"Retrieving Dataset version {datasetVersion1}:");
            AIProjectDataset dataset = await projectClient.Datasets.GetDatasetAsync(datasetName, datasetVersion1);
            Console.WriteLine(dataset.Id);

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
            DatasetCredential credentials = await projectClient.Datasets.GetCredentialsAsync(datasetName, datasetVersion1);
            Console.WriteLine(credentials);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            await foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasetVersionsAsync(datasetName))
            {
                Console.WriteLine(ds);
                Console.WriteLine(ds.Version);
            }

            Console.WriteLine($"Listing latest versions for all datasets:");
            await foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasetsAsync())
            {
                Console.WriteLine($"{ds.Name}, {ds.Version}, {ds.Id}");
            }

            Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}:");
            await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion1);
#if !SNIPPET
            try
            {
                await projectClient.Datasets.GetDatasetAsync(datasetName, datasetVersion1);
                Console.WriteLine($"Dataset version {datasetVersion1} should not exist, but was retrieved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expected exception when retrieving deleted dataset version 1: {ex.Message}");
            }
#endif

            await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion2);
#if !SNIPPET
            try
            {
                await projectClient.Datasets.GetDatasetAsync(datasetName, datasetVersion2);
                Console.WriteLine($"Dataset version {datasetVersion2} should not exist, but was retrieved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Expected exception when retrieving deleted dataset version 2: {ex.Message}");
            }
#endif

            #endregion
        }
    }
};
