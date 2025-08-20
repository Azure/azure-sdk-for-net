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
    // TODO: all tests as async by default
    public class DatasetsTest : ProjectsClientTestBase
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
            var connectionName = TestEnvironment.CONNECTIONNAME;
            var datasetName = string.Concat(TestEnvironment.DATASETNAME, "-", Guid.NewGuid().ToString("N").Substring(0, 8));
            var filePath = TestEnvironment.SAMPLEFILEPATH;
            // var folderPath = TestEnvironment.SAMPLEFOLDERPATH;
            var datasetVersion = TestEnvironment.DATASETVERSION1;

            AIProjectClient projectClient = GetTestClient();

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
            DatasetVersion dataset = projectClient.Datasets.GetDataset(datasetName, datasetVersion);
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
                projectClient.Datasets.GetDataset(datasetName, datasetVersion);
            }
            catch (RequestFailedException ex) when (ex.Status == 204)
            {
                exceptionThrown = true;
                Console.WriteLine($"Expected exception when retrieving deleted dataset: {ex.Message}");
                // TODO: add details about what the exception should contain
            }
            Assert.IsTrue(exceptionThrown, "Expected an exception when retrieving a deleted dataset version.");
        }
    }
};
