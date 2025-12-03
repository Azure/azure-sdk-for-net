// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.AI.Agents.Persistent;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class Sample_VectorStoreWithDatasets : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void VectorStoreWithDatasetsExample()
        {
            #region Snippet:AI_Projects_VectorStoreWithDatasetsInitializeProjectClient
#if SNIPPET
            var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var datasetName = System.Environment.GetEnvironmentVariable("DATASET_NAME");
            var datasetVersion = System.Environment.GetEnvironmentVariable("DATASET_VERSION");
            var filePath = System.Environment.GetEnvironmentVariable("SAMPLE_FILE_PATH");
            var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var datasetName = String.Concat(TestEnvironment.DATASETNAME, "-", Guid.NewGuid().ToString("N").Substring(0, 8));
            var datasetVersion = "1.0";
            var filePath = TestEnvironment.SAMPLEFILEPATH;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif

            AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

            #endregion

            #region Snippet:AI_Projects_VectorStoreWithDatasetsDatasetCreation
            Console.WriteLine("Retrieve the default Azure Storage Account connection to use when creating a dataset");
            AIProjectConnection storageConnection = projectClient.Connections.GetDefaultConnection(ConnectionType.AzureStorageAccount);

            Console.WriteLine($"Uploading a file to create Dataset with name {datasetName} and version {datasetVersion}:");
            FileDataset fileDataset = projectClient.Datasets.UploadFile(
                name: datasetName,
                version: datasetVersion,
                filePath: filePath,
                connectionName: storageConnection.Name
            );

            #endregion

            #region Snippet:AI_Projects_VectorStoreWithDatasetsCreateVectorStoreAndAgent
            PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();

            Console.WriteLine("Initialize the vector store source using the created dataset");
            VectorStoreDataSource vectorStoreDataSource = new VectorStoreDataSource(assetIdentifier: fileDataset.Id, assetType: VectorStoreDataSourceAssetType.UriAsset);

            Console.WriteLine("Call to create the vector store in the service");
            PersistentAgentsVectorStore vectorStore = agentsClient.VectorStores.CreateVectorStore(
                name: "MyVectorStore",
                storeConfiguration: new VectorStoreConfiguration(
                    dataSources: [vectorStoreDataSource]
                )
            );

            FileSearchToolResource fileSearchResource = new([vectorStore.Id], null);

            Console.WriteLine("Create agent with file search tool backed by the created vector store");
            PersistentAgent agent = agentsClient.Administration.CreateAgent(
                model: modelDeploymentName,
                name: "my-agent",
                instructions: "You are helpful agent.",
                tools: [new FileSearchToolDefinition()],
                toolResources: new ToolResources() { FileSearch = fileSearchResource }
            );
            #endregion
        }
    }
}
