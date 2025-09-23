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
using Azure.AI.Projects.Tests.Utils;

namespace Azure.AI.Projects.Tests
{
    public class DatasetsTest : ProjectsClientTestBase
    {
        public DatasetsTest(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        [RecordedTest]
        [Ignore("Calls to Azure.Storage.Blobs are not recorded with SCM structure")]
        public async Task DatasetsFileTest()
        {
            var connectionName = TestEnvironment.CONNECTIONNAME;
            var datasetName = string.Concat(TestEnvironment.DATASETNAME, "-", Guid.NewGuid().ToString("N").Substring(0, 8));
            var filePath = TestEnvironment.SAMPLEFILEPATH;
            var datasetVersion = TestEnvironment.DATASETVERSION1;

            AIProjectClient projectClient = GetTestClient();

            if (IsAsync)
            {
                await DatasetsFileTestAsync(projectClient, datasetName, connectionName, filePath, datasetVersion);
            }
            else
            {
                DatasetsFileTestSync(projectClient, datasetName, connectionName, filePath, datasetVersion);
            }
        }

        private void DatasetsFileTestSync(AIProjectClient projectClient, string datasetName, string connectionName, string filePath, string datasetVersion)
        {
            Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion}:");
            FileDatasetVersion fileDataset = projectClient.Datasets.UploadFile(
                name: datasetName,
                version: datasetVersion,
                filePath: filePath,
                connectionName: connectionName
                );
            ValidateDataset(
                fileDataset,
                expectedDatasetType: "FileDatasetVersion",
                expectedDatasetName: datasetName,
                expectedDatasetVersion: datasetVersion,
                expectedConnectionName: connectionName
            );

            Console.WriteLine($"Retrieving Dataset version {datasetVersion}:");
            AIProjectDataset dataset = projectClient.Datasets.GetDataset(datasetName, datasetVersion);
            ValidateDataset(
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
            ValidateDataset(
                fileDataset,
                expectedDatasetType: "FileDatasetVersion",
                expectedDatasetName: datasetName,
                expectedDatasetVersion: (datasetVersion + 1).ToString(),
                expectedConnectionName: connectionName
            );

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion}:");
            DatasetCredential credentials = projectClient.Datasets.GetCredentials(datasetName, datasetVersion);
            ValidateAssetCredential(credentials);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasetVersions(datasetName))
            {
                ValidateDataset(ds, expectedDatasetName: datasetName);
            }

            Console.WriteLine($"Listing latest versions for all datasets:");
            foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasets())
            {
                ValidateDataset(ds);
            }

            Console.WriteLine($"Deleting Dataset versions {datasetVersion} and {datasetVersion + 1}:");
            projectClient.Datasets.Delete(datasetName, datasetVersion);
            projectClient.Datasets.Delete(datasetName, (datasetVersion + 1).ToString());

            Console.WriteLine($"Attempt to delete the dataset again. Should return 204, not an exception:");
            projectClient.Datasets.Delete(datasetName, datasetVersion);

            Console.WriteLine($"Attempt to retrieve non-existing dataset version {datasetVersion}:");
            bool exceptionThrown = false;
            try
            {
                projectClient.Datasets.GetDataset(datasetName, datasetVersion);
            }
            catch (RequestFailedException ex) when (ex.Status == 204)
            {
                exceptionThrown = true;
                Console.WriteLine($"Expected exception when retrieving deleted dataset: {ex.Message}");
            }
            Assert.IsTrue(exceptionThrown, "Expected an exception when retrieving a deleted dataset version.");
        }

        private async Task DatasetsFileTestAsync(AIProjectClient projectClient, string datasetName, string connectionName, string filePath, string datasetVersion)
        {
            Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion}:");
            FileDatasetVersion fileDataset = await projectClient.Datasets.UploadFileAsync(
                name: datasetName,
                version: datasetVersion,
                filePath: filePath,
                connectionName: connectionName
                );
            ValidateDataset(
                fileDataset,
                expectedDatasetType: "FileDatasetVersion",
                expectedDatasetName: datasetName,
                expectedDatasetVersion: datasetVersion,
                expectedConnectionName: connectionName
            );

            Console.WriteLine($"Retrieving Dataset version {datasetVersion}:");
            AIProjectDataset dataset = await projectClient.Datasets.GetDatasetAsync(datasetName, datasetVersion);
            ValidateDataset(
                dataset,
                expectedDatasetType: "FileDatasetVersion",
                expectedDatasetName: datasetName,
                expectedDatasetVersion: datasetVersion,
                expectedConnectionName: connectionName
            );

            Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {(datasetVersion + 1).ToString()}:");
            fileDataset = await projectClient.Datasets.UploadFileAsync(
                name: datasetName,
                version: (datasetVersion + 1).ToString(),
                filePath: filePath,
                connectionName: connectionName
                );
            ValidateDataset(
                fileDataset,
                expectedDatasetType: "FileDatasetVersion",
                expectedDatasetName: datasetName,
                expectedDatasetVersion: (datasetVersion + 1).ToString(),
                expectedConnectionName: connectionName
            );

            Console.WriteLine($"Retrieving credentials of Dataset {datasetName} version {datasetVersion}:");
            DatasetCredential credentials = await projectClient.Datasets.GetCredentialsAsync(datasetName, datasetVersion);
            ValidateAssetCredential(credentials);

            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            await foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasetVersionsAsync(datasetName))
            {
                ValidateDataset(ds, expectedDatasetName: datasetName);
            }

            Console.WriteLine($"Listing latest versions for all datasets:");
            await foreach (AIProjectDataset ds in projectClient.Datasets.GetDatasetsAsync())
            {
                ValidateDataset(ds);
            }

            Console.WriteLine($"Deleting Dataset versions {datasetVersion} and {datasetVersion + 1}:");
            await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion);
            await projectClient.Datasets.DeleteAsync(datasetName, (datasetVersion + 1).ToString());

            Console.WriteLine($"Attempt to delete the dataset again. Should return 204, not an exception:");
            await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion);

            Console.WriteLine($"Attempt to retrieve non-existing dataset version {datasetVersion}:");
            bool exceptionThrown = false;
            try
            {
                await projectClient.Datasets.GetDatasetAsync(datasetName, datasetVersion);
            }
            catch (RequestFailedException ex) when (ex.Status == 204)
            {
                exceptionThrown = true;
                Console.WriteLine($"Expected exception when retrieving deleted dataset: {ex.Message}");
            }
            Assert.IsTrue(exceptionThrown, "Expected an exception when retrieving a deleted dataset version.");
        }
    }
};
