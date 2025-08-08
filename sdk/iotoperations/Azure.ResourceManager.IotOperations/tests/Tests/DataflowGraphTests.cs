// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure; // RequestFailedException
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.ResourceManager.IotOperations.Models;

namespace Azure.ResourceManager.IotOperations.Tests
{
    public class DataflowGraphTests : IotOperationsManagementClientBase
    {
        public DataflowGraphTests(bool isAsync) : base(isAsync) { }

        [SetUp]
        public async Task ClearAndInitialize()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
                await InitializeClients();
        }

        [TestCase]
        [RecordedTest]
        public async Task TestDataflowGraphs()
        {
            // Get the DataflowGraph collection
            var dataflowProfileCollection = await GetDataflowProfileCollectionAsync(ResourceGroup);
            var dataflowProfileResource = await dataflowProfileCollection.GetAsync(DataflowProfilesName);
            var graphCollection = dataflowProfileResource.Value.GetDataflowGraphResources();

            // Use a unique name to avoid conflicts with in-progress operations
            var graphName = Recording.GenerateAssetName("sdk-test-dataflowgraph-");

            // Best-effort cleanup if an earlier run left a resource
            try
            {
                var existing = await graphCollection.GetAsync(graphName);
                await existing.Value.DeleteAsync(WaitUntil.Completed);
            }
            catch (RequestFailedException)
            {
                // ignore if not found
            }

            // Create DataflowGraph
            var graphData = CreateDataflowGraphResourceData();
            var createOperation = await graphCollection.CreateOrUpdateAsync(
                WaitUntil.Completed,
                graphName,
                graphData
            );
            var createdGraph = createOperation.Value;
            Assert.IsNotNull(createdGraph);
            Assert.IsNotNull(createdGraph.Data);
            Assert.IsNotNull(createdGraph.Data.Properties);

            // Delete DataflowGraph
            await createdGraph.DeleteAsync(WaitUntil.Completed);

            // Verify DataflowGraph is deleted
            Assert.ThrowsAsync<RequestFailedException>(
                async () => await createdGraph.GetAsync()
            );
        }

        private DataflowGraphResourceData CreateDataflowGraphResourceData()
        {
            return new DataflowGraphResourceData
            {
                Properties = new DataflowGraphProperties(
                    new DataflowGraphNode[]
                    {
                        new DataflowGraphSourceNode("temperature", new DataflowGraphSourceSettings("default", new string[] { "telemetry/temperature" })),
                        new DataflowGraphGraphNode("my-graph", new DataflowGraphNodeGraphSettings("my-registry-endpoint", "my-wasm-module:1.4.3")
                        {
                            Configuration = { new DataflowGraphGraphNodeConfiguration("key1", "value1"), new DataflowGraphGraphNodeConfiguration("key2", "value2") },
                        }),
                        new DataflowGraphDestinationNode("alert", new DataflowGraphDestinationNodeSettings("default", "telemetry/temperature/alert")),
                        new DataflowGraphDestinationNode("fabric", new DataflowGraphDestinationNodeSettings("fabric", "my-table")
                        {
                            OutputSchemaSettings = new DataflowGraphDestinationSchemaSettings(DataflowGraphDestinationSchemaSerializationFormat.Parquet)
                            {
                                SchemaRef = "aio-sr://namespace/alert-parquet:1",
                            },
                        })
                    },
                    new DataflowGraphNodeConnection[]
                    {
                        new DataflowGraphNodeConnection(new DataflowGraphConnectionInput("temperature")
                        {
                            Schema = new DataflowGraphConnectionSchemaSettings
                            {
                                SerializationFormat = DataflowGraphConnectionSchemaSerializationFormat.Avro,
                                SchemaRef = "aio-sr://namespace/temperature:1",
                            },
                        }, new DataflowGraphConnectionOutput("my-graph")),
                        new DataflowGraphNodeConnection(new DataflowGraphConnectionInput("my-graph.alert-output")
                        {
                            Schema = new DataflowGraphConnectionSchemaSettings
                            {
                                SerializationFormat = DataflowGraphConnectionSchemaSerializationFormat.Avro,
                                SchemaRef = "aio-sr://namespace/alert:1",
                            },
                        }, new DataflowGraphConnectionOutput("alert")),
                        new DataflowGraphNodeConnection(new DataflowGraphConnectionInput("my-graph.fabric-output")
                        {
                            Schema = new DataflowGraphConnectionSchemaSettings
                            {
                                SerializationFormat = DataflowGraphConnectionSchemaSerializationFormat.Avro,
                                SchemaRef = "aio-sr://namespace/fabric:1",
                            },
                        }, new DataflowGraphConnectionOutput("fabric")),
                    }
                                                )
            };
        }
    }
}
