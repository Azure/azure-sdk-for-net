// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class Sample_Datasets : SamplesBase<AIProjectsTestEnvironment>
    {
        private static string GetPath(string target, [CallerFilePath] string pth = "")
        {
            var dirName = Path.GetDirectoryName(pth) ?? "";
            return Path.Combine(dirName, target);
        }

        [Test]
        [SyncOnly]
        public void DatasetsExample()
        {
            #region Snippet:AI_Projects_DatasetsExampleSync
#if SNIPPET
            var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var datasetName = TestEnvironment.DATASETNAME;
#endif
            AIProjectClient projectClient = new(new Uri(endpoint), new AzureCliCredential());
            Datasets datasets = projectClient.GetDatasetsClient();

            Console.WriteLine("Uploading a single file to create Dataset version '1'...");
            FileDatasetVersion datasetResponse = datasets.UploadFile(
                name: datasetName,
                version: "1",
                filePath: GetPath(target: "sample_folder/sample_file1.txt")
                );
            Console.WriteLine(datasetResponse);

            Console.WriteLine("Uploading folder to create Dataset version '2'...");
            FolderDatasetVersion folderDatasetResponse = datasets.UploadFolder(
                name: datasetName,
                version: "2",
                folderPath: GetPath(target: "sample_folder")
            );
            Console.WriteLine(folderDatasetResponse);

            Console.WriteLine("Retrieving Dataset version '1'...");
            DatasetVersion dataset = datasets.GetDataset(datasetName, "1");
            Console.WriteLine(dataset);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            foreach (var ds in datasets.GetVersions(datasetName))
            {
                Console.WriteLine(ds);
            }

            Console.WriteLine($"Listing latest versions for all datasets:");
            foreach (var ds in datasets.GetDatasetVersions())
            {
                Console.WriteLine(ds);
            }

            Console.WriteLine("Deleting Dataset versions '1' and '2'...");
            datasets.Delete(datasetName, "1");
            datasets.Delete(datasetName, "2");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task DatasetsExampleAsync()
        {
            #region Snippet:AI_Projects_DatasetsExampleAsync
#if SNIPPET
            var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var datasetName = TestEnvironment.DATASETNAME;
#endif
            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
            Datasets datasets = projectClient.GetDatasetsClient();

            Console.WriteLine("Uploading a single file to create Dataset version '1'...");
            FileDatasetVersion datasetResponse = datasets.UploadFile(
                name: datasetName,
                version: "1",
                filePath: GetPath(target: "sample_folder/sample_file1.txt")
                );
            Console.WriteLine(datasetResponse);

            Console.WriteLine("Uploading folder to create Dataset version '2'...");
            FolderDatasetVersion folderDatasetResponse = datasets.UploadFolder(
                name: datasetName,
                version: "2",
                folderPath: GetPath(target: "sample_folder")
            );
            Console.WriteLine(folderDatasetResponse);

            Console.WriteLine("Retrieving Dataset version '1'...");
            DatasetVersion dataset = await datasets.GetDatasetAsync(datasetName, "1");
            Console.WriteLine(dataset);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            await foreach (var ds in datasets.GetVersionsAsync(datasetName))
            {
                Console.WriteLine(ds);
            }

            Console.WriteLine($"Listing latest versions for all datasets:");
            await foreach (var ds in datasets.GetDatasetVersionsAsync())
            {
                Console.WriteLine(ds);
            }

            Console.WriteLine("Deleting Dataset versions '1' and '2'...");
            await datasets.DeleteAsync(datasetName, "1");
            await datasets.DeleteAsync(datasetName, "2");
            #endregion
        }
    }
};
