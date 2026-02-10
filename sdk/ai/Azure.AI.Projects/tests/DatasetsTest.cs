// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class DatasetsTest : ProjectsClientTestBase
    {
        public DatasetsTest(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        // The call UploadFileAsync will Get the BlobClient and
        // use it to upload the data. This call will not beintercepted and hence
        // cannot be recorded.
        [LiveOnly]
        public async Task DatasetsFileTest()
        {
            var connectionName = TestEnvironment.STORAGECONNECTIONNAME;
            // Use the nect code to crete the recording.
            // var datasetName = string.Concat(TestEnvironment.DATASETNAME, "-", Guid.NewGuid().ToString("N").Substring(0, 8));
            // And record the created data set name into the next line.
            var datasetName = string.Concat(TestEnvironment.DATASETNAME, "-623621a9");
            var filePath = "sample_file_for_upload.txt";
            System.IO.File.WriteAllText(
                path: filePath,
                contents: "Just a test file.");
            var datasetVersion = TestEnvironment.DATASETVERSION1;

            AIProjectClient projectClient = GetTestProjectClient();
            try
            {
                await projectClient.Datasets.DeleteAsync(datasetName, datasetVersion);
            }
            catch
            {
                // Nothing here.
            }
            Console.WriteLine($"Uploading a single file to create Dataset with name {datasetName} and version {datasetVersion}:");
            FileDataset fileDataset = await projectClient.Datasets.UploadFileAsync(
                name: datasetName,
                version: datasetVersion,
                filePath: filePath,
                connectionName: connectionName
                );
            ValidateDataset(
                fileDataset,
                expectedDatasetType: "FileDataset",
                expectedDatasetName: datasetName,
                expectedDatasetVersion: datasetVersion,
                // Uncomment check when the ADO work item 4885314 will be resolved.
                // expectedConnectionName: connectionName
                expectedConnectionName: null
            );

            Console.WriteLine($"Retrieving Dataset version {datasetVersion}:");
            AIProjectDataset dataset = await projectClient.Datasets.GetDatasetAsync(datasetName, datasetVersion);
            ValidateDataset(
                dataset,
                expectedDatasetType: "FileDatasetVersion",
                expectedDatasetName: datasetName,
                expectedDatasetVersion: datasetVersion,
                // Uncomment check when the ADO work item 4885314 will be resolved.
                // expectedConnectionName: connectionName
                expectedConnectionName: null
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
                // Uncomment check when the ADO work item 4885314 will be resolved.
                // expectedConnectionName: connectionName
                expectedConnectionName: null
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
            catch (ClientResultException ex) when (ex.Status == 404)
            {
                exceptionThrown = true;
                Console.WriteLine($"Expected exception when retrieving deleted dataset: {ex.Message}");
            }
            Assert.That(exceptionThrown, Is.True, "Expected an exception when retrieving a deleted dataset version.");
        }
    }
};
