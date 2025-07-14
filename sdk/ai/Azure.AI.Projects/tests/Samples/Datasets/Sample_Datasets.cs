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
            DatasetVersion dataset = projectClient.Datasets.GetDataset(datasetName, datasetVersion1);
            Console.WriteLine(dataset);

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
            AssetCredentialResponse credentials = projectClient.Datasets.GetCredentials(datasetName, datasetVersion1);
            Console.WriteLine(credentials);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            foreach (DatasetVersion ds in projectClient.Datasets.GetVersions(datasetName))
            {
                Console.WriteLine(ds);
                Console.WriteLine(ds.Version);
            }

            Console.WriteLine($"Listing latest versions for all datasets:");
            foreach (DatasetVersion ds in projectClient.Datasets.GetDatasetVersions())
            {
                Console.WriteLine(ds);
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
            DatasetVersion dataset = await projectClient.Datasets.GetDatasetAsync(datasetName, datasetVersion1);
            Console.WriteLine(dataset);

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion1}:");
            AssetCredentialResponse credentials = await projectClient.Datasets.GetCredentialsAsync(datasetName, datasetVersion1);
            Console.WriteLine(credentials);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            await foreach (DatasetVersion ds in projectClient.Datasets.GetVersionsAsync(datasetName))
            {
                Console.WriteLine(ds.Version);
            }

            Console.WriteLine($"Listing latest versions for all datasets:");
            await foreach (DatasetVersion ds in projectClient.Datasets.GetDatasetVersionsAsync())
            {
                Console.WriteLine(ds);
            }

            Console.WriteLine($"Deleting Dataset versions {datasetVersion1} and {datasetVersion2}...");
            await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion1);
            await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion2);
            #endregion
        }
    }
};
