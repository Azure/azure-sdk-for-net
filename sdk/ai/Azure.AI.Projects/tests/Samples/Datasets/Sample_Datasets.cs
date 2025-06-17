// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using System.Text.RegularExpressions;

namespace Azure.AI.Projects.Tests
{
    public class Sample_Datasets : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DatasetsExample()
        {
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
            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
            Datasets datasets = projectClient.GetDatasetsClient();

            Console.WriteLine($"Uploading a single file to create Dataset version {datasetVersion1}:");
            DatasetVersion dataset = datasets.UploadFile(
                name: datasetName,
                version: datasetVersion1,
                filePath: filePath,
                connectionName: connectionName
                );
            Console.WriteLine(dataset);

            Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}:");
            dataset = datasets.UploadFolder(
                name: datasetName,
                version: datasetVersion2,
                folderPath: folderPath,
                connectionName: connectionName,
                filePattern: new Regex(".*\\.txt")
            );
            Console.WriteLine(dataset);

            Console.WriteLine($"Retrieving Dataset version {datasetVersion1}:");
            dataset = datasets.GetDataset(datasetName, datasetVersion1);
            Console.WriteLine(dataset);

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
            AssetCredentialResponse credentials = datasets.GetCredentials(datasetName, datasetVersion1);
            Console.WriteLine(credentials);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            foreach (var ds in datasets.GetVersions(datasetName))
            {
                Console.WriteLine(ds);
                Console.WriteLine(ds.Version);
            }

            Console.WriteLine($"Listing latest versions for all datasets:");
            foreach (var ds in datasets.GetDatasetVersions())
            {
                Console.WriteLine(ds);
            }

            Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}:");
            datasets.Delete(datasetName, datasetVersion1);
            datasets.Delete(datasetName, datasetVersion2);
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task DatasetsExampleAsync()
        {
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
            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
            Datasets datasets = projectClient.GetDatasetsClient();

            Console.WriteLine($"Uploading a single file to create Dataset version {datasetVersion1}...");
            DatasetVersion dataset = await datasets.UploadFileAsync(
                name: datasetName,
                version: datasetVersion1,
                filePath: filePath,
                connectionName: connectionName
                );
            Console.WriteLine(dataset);

            Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion2}...");
            dataset = await datasets.UploadFolderAsync(
                name: datasetName,
                version: datasetVersion2,
                folderPath: folderPath,
                connectionName: connectionName,
                filePattern: new Regex(".*\\.txt")
            );
            Console.WriteLine(dataset);

            Console.WriteLine($"Retrieving Dataset version {datasetVersion1}...");
            dataset = await datasets.GetDatasetAsync(datasetName, datasetVersion1);
            Console.WriteLine(dataset);

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
            AssetCredentialResponse credentials = await datasets.GetCredentialsAsync(datasetName, datasetVersion1);
            Console.WriteLine(credentials);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            await foreach (var ds in datasets.GetVersionsAsync(datasetName))
            {
                Console.WriteLine(ds.Version);
            }

            Console.WriteLine($"Listing latest versions for all datasets:");
            await foreach (var ds in datasets.GetDatasetVersionsAsync())
            {
                Console.WriteLine(ds);
            }

            Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}...");
            await datasets.DeleteAsync(datasetName, datasetVersion1);
            await datasets.DeleteAsync(datasetName, datasetVersion2);
            #endregion
        }
    }
};
