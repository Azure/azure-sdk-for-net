// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Identity;
using Azure.AI.Projects;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.AI.Inference;
using Azure.Core.TestFramework;

namespace Azure.AI.Projects.OneDP.Tests
{
    public class Sample_Datasets : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void DatasetsExample()
        {
            #region Snippet:DatasetsExample_CreateClient
#if SNIPPET
            var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var datasetName = TestEnvironment.DATASETNAME;
#endif
            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
            Datasets datasets = projectClient.GetDatasetsClient();
            #endregion

            #region Snippet:Datasets_UploadFileAndCreate
            Console.WriteLine("Uploading a single file to create Dataset version '1'...");
            var dataset = datasets.UploadFileAndCreate(
                name: datasetName,
                version: "1",
                filePath: "sample_folder/sample_file1.txt"
                );
            Console.WriteLine(dataset);
            #endregion

            #region Snippet:Datasets_UploadFolderAndCreate
            Console.WriteLine("Uploading folder to create Dataset version '2'...");
            dataset = datasets.UploadFolderAndCreate(
                name: datasetName,
                version: "2",
                folderPath: "sample_folder"
            );
            Console.WriteLine(dataset.DatasetUri);
            #endregion

            #region Snippet:Datasets_GetVersion
            Console.WriteLine("Retrieving Dataset version '1'...");
            dataset = datasets.GetVersion(datasetName, "1");
            Console.WriteLine(dataset.DatasetUri);
            #endregion

            #region Snippet:Datasets_ListVersions
            Console.WriteLine($"Listing all versions for Dataset '{datasetName}':");
            foreach (var ds in datasets.GetVersions(datasetName))
            {
                Console.WriteLine(ds.DatasetUri);
            }
            #endregion

            #region Snippet:Datasets_DeleteVersions
            Console.WriteLine("Deleting Dataset versions '1' and '2'...");
            datasets.DeleteVersion(datasetName, "1");
            datasets.DeleteVersion(datasetName, "2");
            #endregion
        }
    }
};
