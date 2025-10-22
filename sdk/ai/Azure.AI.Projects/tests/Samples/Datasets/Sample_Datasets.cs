// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public partial class Sample_Datasets : SamplesBase<AIProjectsTestEnvironment>
    {
        private static void EnableSystemClientModelDebugging()
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

        private static AIProjectClient CreateDebugClient(string endpoint)
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
            Sample_Datasets.EnableSystemClientModelDebugging();

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
            var connectionName = TestEnvironment.STORAGECONNECTIONNAME;
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

            AIProjectClient projectClient = Sample_Datasets.CreateDebugClient(endpoint);
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
                filePattern: MyRegex()
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
            Sample_Datasets.EnableSystemClientModelDebugging();

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
            var connectionName = TestEnvironment.STORAGECONNECTIONNAME;
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

            AIProjectClient projectClient = Sample_Datasets.CreateDebugClient(endpoint);
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
                filePattern: MyRegex()
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

        [Test]
        [SyncOnly]
        public void DatasetRoundTripSample()
        {
            #region Snippet:AI_Projects_DatasetRoundTripSample_ClientSetup
#if SNIPPET
            var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
            var datasetVersion = System.Environment.GetEnvironmentVariable("DATASET_VERSION") ?? "1.0";
            var filePath = System.Environment.GetEnvironmentVariable("SAMPLE_FILE_PATH") ?? "sample_folder/sample_file1.txt";

            AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var datasetName = String.Concat(TestEnvironment.DATASETNAME, "-", Guid.NewGuid().ToString("N").Substring(0, 8));
            var filePath = TestEnvironment.SAMPLEFILEPATH;
            var folderPath = TestEnvironment.SAMPLEFOLDERPATH;
            var datasetVersion = "1.0";
            try
            {
                datasetVersion = TestEnvironment.DATASETVERSION1;
            }
            catch
            {
                datasetVersion = "1.0";
            }

            AIProjectClient projectClient = Sample_Datasets.CreateDebugClient(endpoint);
#endif
            #endregion

            #region Snippet:AI_Projects_DatasetRoundTripSample_DatasetCreation

            Console.WriteLine("Retrieve the default Azure Storage Account connection to use when creating a dataset");
            AIProjectConnection storageConnection = projectClient.Connections.GetDefaultConnection(ConnectionType.AzureStorageAccount);

            Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion}:");
            FileDataset fileDataset = projectClient.Datasets.UploadFile(
                name: datasetName,
                version: datasetVersion,
                filePath: filePath,
                connectionName: storageConnection.Name
                );
            #endregion

            #region Snippet:AI_Projects_DatasetRoundTripSample_DatasetDownload
            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion}:");
            DatasetCredential credentials = projectClient.Datasets.GetCredentials(datasetName, datasetVersion);

            Console.WriteLine($"Using DatasetCredential to initialize Azure Storage client and download the file to local disk:");

            // Get the blob URI and SAS URI from the dataset credentials
            Uri blobUri = credentials.BlobReference.BlobUri;
            Uri sasUri = credentials.BlobReference.Credential.SasUri;
            Console.WriteLine($"Blob URI: {blobUri}");
            Console.WriteLine($"SAS URI: {sasUri}");

            // Create BlobContainerClient using the SAS URI
            BlobContainerClient containerClient = new BlobContainerClient(sasUri);
            Console.WriteLine($"Container client created successfully");

            // Create BlobClient from the container client using the blob name from BlobUri
            var blobUriBuilder = new UriBuilder(blobUri);
            var blobPathParts = blobUriBuilder.Path.TrimStart('/').Split('/');
            string blobName = string.Join("/", blobPathParts.Skip(1)); // Skip container name, get blob path

            BlobClient blobClient = containerClient.GetBlobClient(blobName);
            Console.WriteLine($"BlobClient created successfully for blob: {blobClient.Name}");

            // Define local download path
            string downloadFileName = $"downloaded_{blobClient.Name.Replace("/", "_")}";
            string downloadPath = Path.Combine(Path.GetTempPath(), downloadFileName);
            Console.WriteLine($"Downloading blob to: {downloadPath}");

            // Download blob to local file
            blobClient.DownloadTo(downloadPath);
            Console.WriteLine($"Downloaded blob '{blobClient.Name}' to '{downloadPath}' - Size: {new FileInfo(downloadPath).Length} bytes");
            #endregion

            // Clean up - delete the downloaded file and dataset
            Console.WriteLine($"Cleaning up - deleting downloaded file: {downloadPath}");
            if (File.Exists(downloadPath))
            {
                File.Delete(downloadPath);
                Console.WriteLine("Downloaded file deleted successfully");
            }

            Console.WriteLine($"Cleaning up - deleting Dataset {datasetName} version {datasetVersion}");
            projectClient.Datasets.Delete(datasetName, datasetVersion);
        }

        [GeneratedRegex(".*\\.txt")]
        private static partial Regex MyRegex();
    }
}
