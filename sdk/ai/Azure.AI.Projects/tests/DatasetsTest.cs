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
using Azure.Identity;
using NUnit.Framework.Internal;

namespace Azure.AI.Projects.Tests
{
    // TODO: all tests as async by default
    public class DatasetsTest : RecordedTestBase<AIProjectsTestEnvironment>
    {
        public DatasetsTest(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        // TODO: skip if it is not live+not recorded (blob storage is not recorded)
        // TODO finish i dont want to do this rn

        [RecordedTest]
        public void DatasetsFileTest()
        {
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var connectionName = TestEnvironment.CONNECTIONNAME;
            var datasetName = string.Concat(TestEnvironment.DATASETNAME, "-", Guid.NewGuid().ToString("N").Substring(0, 8));
            var filePath = TestEnvironment.SAMPLEFILEPATH;
            // var folderPath = TestEnvironment.SAMPLEFOLDERPATH;
            var datasetVersion = TestEnvironment.DATASETVERSION1;

            AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

            Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion}:");
            FileDatasetVersion fileDataset = projectClient.Datasets.UploadFile(
                name: datasetName,
                version: datasetVersion,
                filePath: filePath,
                connectionName: connectionName
                );
            TestBase.ValidateDataset(
                fileDataset,
                expectedDatasetType: "FileDatasetVersion",
                expectedDatasetName: datasetName,
                expectedDatasetVersion: datasetVersion,
                expectedConnectionName: connectionName
            );

            Console.WriteLine($"Retrieving Dataset version {datasetVersion}:");
            DatasetVersion dataset = projectClient.Datasets.Get(datasetName, datasetVersion);
            TestBase.ValidateDataset(
                dataset,
                expectedDatasetType: "FileDatasetVersion",
                expectedDatasetName: datasetName,
                expectedDatasetVersion: datasetVersion,
                expectedConnectionName: connectionName
            );

            Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {(datasetVersion + 1).ToString()}:");
            fileDataset = projectClient.Datasets.UploadFile(
                name: datasetName,
                version: (datasetVersion + 1).ToString(),
                filePath: filePath,
                connectionName: connectionName
                );
            TestBase.ValidateDataset(
                fileDataset,
                expectedDatasetType: "FileDatasetVersion",
                expectedDatasetName: datasetName,
                expectedDatasetVersion: (datasetVersion + 1).ToString(),
                expectedConnectionName: connectionName
            );

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion}:");
            DatasetCredential credentials = projectClient.Datasets.GetCredentials(datasetName, datasetVersion);
            TestBase.ValidateAssetCredential(credentials);

            // Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            // foreach (DatasetVersion ds in projectClient.Datasets.GetVersions(datasetName))
            // {
            //     TestBase.ValidateDataset(ds, expectedDatasetName: datasetName);
            // }

            // Console.WriteLine($"Listing latest versions for all datasets:");
            // foreach (DatasetVersion ds in projectClient.Datasets.Get())
            // {
            //     TestBase.ValidateDataset(ds);
            // }

            Console.WriteLine($"Deleting Dataset versions {datasetVersion} and {datasetVersion + 1}:");
            projectClient.Datasets.Delete(datasetName, datasetVersion);
            projectClient.Datasets.Delete(datasetName, (datasetVersion + 1).ToString());

            Console.WriteLine($"Attempt to delete the dataset again. Should return 204, not an exception:");
            projectClient.Datasets.Delete(datasetName, datasetVersion);

            Console.WriteLine($"Attempt to retrieve non-existing dataset version {datasetVersion}:");
            bool exceptionThrown = false;
            try
            {
                projectClient.Datasets.Get(datasetName, datasetVersion);
            }
            catch (RequestFailedException ex) when (ex.Status == 204)
            {
                exceptionThrown = true;
                Console.WriteLine($"Expected exception when retrieving deleted dataset: {ex.Message}");
                // TODO: add details about what the exception should contain
            }
            Assert.IsTrue(exceptionThrown, "Expected an exception when retrieving a deleted dataset version.");
        }

        // [RecordedTest]
        // [AsyncOnly]
        // public async Task DatasetsExampleAsync()
        // {
        //     var endpoint = TestEnvironment.PROJECTENDPOINT;
        //     var connectionName = TestEnvironment.CONNECTIONNAME;
        //     var datasetName = String.Concat(TestEnvironment.DATASETNAME, "-", Guid.NewGuid().ToString("N").Substring(0, 8));
        //     var filePath = TestEnvironment.SAMPLEFILEPATH;
        //     var folderPath = TestEnvironment.SAMPLEFOLDERPATH;
        //     var datasetVersion = "1.0";
        //     var datasetVersion + 1 = "2.0";
        //     try
        //     {
        //         datasetVersion = TestEnvironment.datasetVersion;
        //         datasetVersion + 1 = TestEnvironment.datasetVersion + 1;
        //     }
        //     catch
        //     {
        //         datasetVersion = "1.0";
        //         datasetVersion + 1 = "2.0";
        //     }

        //     AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

        //     Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion}:");
        //     FileDatasetVersion fileDataset = await projectClient.Datasets.UploadFileAsync(
        //         name: datasetName,
        //         version: datasetVersion,
        //         filePath: filePath,
        //         connectionName: connectionName
        //         );
        //     Console.WriteLine(fileDataset);

        //     Console.WriteLine($"Uploading folder to create Dataset version {datasetVersion + 1}:");
        //     FolderDatasetVersion folderDataset = await projectClient.Datasets.UploadFolderAsync(
        //         name: datasetName,
        //         version: datasetVersion + 1,
        //         folderPath: folderPath,
        //         connectionName: connectionName,
        //         filePattern: new Regex(".*\\.txt")
        //     );
        //     Console.WriteLine(folderDataset);

        //     Console.WriteLine($"Retrieving Dataset version {datasetVersion}:");
        //     DatasetVersion dataset = await projectClient.Datasets.GetAsync(datasetName, datasetVersion);
        //     Console.WriteLine(dataset.Id);

        //     Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion}:");
        //     DatasetCredential credentials = await projectClient.Datasets.GetCredentialsAsync(datasetName, datasetVersion);
        //     Console.WriteLine(credentials);

        //     Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
        //     await foreach (DatasetVersion ds in projectClient.Datasets.GetVersionsAsync(datasetName))
        //     {
        //         Console.WriteLine(ds);
        //         Console.WriteLine(ds.Version);
        //     }

        //     Console.WriteLine($"Listing latest versions for all datasets:");
        //     await foreach (DatasetVersion ds in projectClient.Datasets.GetAsync())
        //     {
        //         Console.WriteLine($"{ds.Name}, {ds.Version}, {ds.Id}");
        //     }

        //     Console.WriteLine($"Deleting Dataset versions {datasetVersion} and {datasetVersion + 1}:");
        //     await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion);

        //     try
        //     {
        //         await projectClient.Datasets.GetAsync(datasetName, datasetVersion);
        //         Console.WriteLine($"Dataset version {datasetVersion} should not exist, but was retrieved successfully.");
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Expected exception when retrieving deleted dataset version 1: {ex.Message}");
        //     }

        //     await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion + 1);

        //     try
        //     {
        //         await projectClient.Datasets.GetAsync(datasetName, datasetVersion + 1);
        //         Console.WriteLine($"Dataset version {datasetVersion + 1} should not exist, but was retrieved successfully.");
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine($"Expected exception when retrieving deleted dataset version 2: {ex.Message}");
        //     }
        // }
    }
};
