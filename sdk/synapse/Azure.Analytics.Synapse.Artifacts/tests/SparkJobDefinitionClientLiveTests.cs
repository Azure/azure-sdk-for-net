// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="SparkJobDefinitionClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [Ignore("Requires upload of zip from https://github.com/Azure-Samples/Synapse/tree/main/Spark/DotNET as samples/net/wordcount/wordcount.zip to associated storage.")]
    public class SparkJobDefinitionClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        internal class DisposableSparkJobDefinition : IAsyncDisposable
        {
            private readonly SparkJobDefinitionClient _client;
            public SparkJobDefinitionResource Resource;

            private DisposableSparkJobDefinition (SparkJobDefinitionClient client, SparkJobDefinitionResource resource)
            {
                _client = client;
                Resource = resource;
            }

            public string Name => Resource.Name;

            public static async ValueTask<DisposableSparkJobDefinition> Create (SparkJobDefinitionClient client, TestRecording recording, string storageFileSystemName, string storageAccountName) =>
                new DisposableSparkJobDefinition (client, await CreateResource(client, recording, storageFileSystemName, storageAccountName));

            public static async ValueTask<SparkJobDefinitionResource> CreateResource (SparkJobDefinitionClient client, TestRecording recording, string storageFileSystemName, string storageAccountName)
            {
                string jobName = recording.GenerateId("SparkJobDefinition", 16);

                string file = string.Format("abfss://{0}@{1}.dfs.core.windows.net/samples/net/wordcount/wordcount.zip", storageFileSystemName, storageAccountName);
                SparkJobProperties jobProperties = new SparkJobProperties (file, "28g", 4, "28g", 4, 2);
                SparkJobDefinition jobDefinition = new SparkJobDefinition (new BigDataPoolReference (BigDataPoolReferenceType.BigDataPoolReference, "sparkchhamosyna"), jobProperties);
                SparkJobDefinitionResource resource = new SparkJobDefinitionResource (jobDefinition);
                SparkJobDefinitionCreateOrUpdateSparkJobDefinitionOperation createOperation = await client.StartCreateOrUpdateSparkJobDefinitionAsync(jobName, resource);
                return await createOperation.WaitForCompletionAsync();
            }

            public async ValueTask DisposeAsync()
            {
                SparkJobDefinitionDeleteSparkJobDefinitionOperation deleteOperation = await _client.StartDeleteSparkJobDefinitionAsync (Name);
                await deleteOperation.WaitForCompletionAsync();
            }
        }

        public SparkJobDefinitionClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private SparkJobDefinitionClient CreateClient()
        {
            return InstrumentClient(new SparkJobDefinitionClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestGetSparkJob()
        {
            SparkJobDefinitionClient client = CreateClient ();
            await using DisposableSparkJobDefinition sparkJobDefinition = await DisposableSparkJobDefinition.Create (client, Recording, TestEnvironment.StorageFileSystemName, TestEnvironment.StorageAccountName);

            IList<SparkJobDefinitionResource> jobs = await client.GetSparkJobDefinitionsByWorkspaceAsync().ToListAsync();
            Assert.GreaterOrEqual(jobs.Count, 1);

            foreach (var expectedJob in jobs)
            {
                SparkJobDefinitionResource actualJob = await client.GetSparkJobDefinitionAsync(expectedJob.Name);
                Assert.AreEqual(expectedJob.Name, actualJob.Name);
                Assert.AreEqual(expectedJob.Id, actualJob.Id);
            }
        }

        [RecordedTest]
        public async Task TestDeleteSparkJob()
        {
            SparkJobDefinitionClient client = CreateClient();

            SparkJobDefinitionResource resource = await DisposableSparkJobDefinition.CreateResource (client, Recording, TestEnvironment.StorageFileSystemName, TestEnvironment.StorageAccountName);

            SparkJobDefinitionDeleteSparkJobDefinitionOperation deleteOperation = await client.StartDeleteSparkJobDefinitionAsync  (resource.Name);
            await deleteOperation.WaitAndAssertSuccessfulCompletion();
        }

        [RecordedTest]
        public async Task TestRenameSparkJob()
        {
            SparkJobDefinitionClient client = CreateClient();

            SparkJobDefinitionResource resource = await DisposableSparkJobDefinition.CreateResource (client, this.Recording, TestEnvironment.StorageFileSystemName, TestEnvironment.StorageAccountName);

            string newSparkJobName = Recording.GenerateId("Pipeline2", 16);

            SparkJobDefinitionRenameSparkJobDefinitionOperation renameOperation = await client.StartRenameSparkJobDefinitionAsync (resource.Name, new ArtifactRenameRequest () { NewName = newSparkJobName } );
            await renameOperation.WaitForCompletionAsync();

            SparkJobDefinitionResource sparkJob = await client.GetSparkJobDefinitionAsync (newSparkJobName);
            Assert.AreEqual (newSparkJobName, sparkJob.Name);

            SparkJobDefinitionDeleteSparkJobDefinitionOperation deleteOperation = await client.StartDeleteSparkJobDefinitionAsync (newSparkJobName);
            await deleteOperation.WaitForCompletionAsync();
        }

        [Ignore ("https://github.com/Azure/azure-sdk-for-net/issues/18079 - SYNAPSE_API_ISSUE - Parameter name: ClassName")]
        [RecordedTest]
        public async Task TestExecute()
        {
            SparkJobDefinitionClient client = CreateClient();
            await using DisposableSparkJobDefinition sparkJobDefinition = await DisposableSparkJobDefinition.Create (client, Recording, TestEnvironment.StorageFileSystemName, TestEnvironment.StorageAccountName);

            SparkJobDefinitionExecuteSparkJobDefinitionOperation executeOperation = await client.StartExecuteSparkJobDefinitionAsync(sparkJobDefinition.Name);
            SparkBatchJob job = await executeOperation.WaitForCompletionAsync();
        }

        [Ignore ("https://github.com/Azure/azure-sdk-for-net/issues/18079 - SYNAPSE_API_ISSUE - Causes internal error")]
        [RecordedTest]
        public async Task TestDebug()
        {
            SparkJobDefinitionClient client = CreateClient();
            await using DisposableSparkJobDefinition sparkJobDefinition = await DisposableSparkJobDefinition.Create (client, Recording, TestEnvironment.StorageFileSystemName, TestEnvironment.StorageAccountName);

            SparkJobDefinitionDebugSparkJobDefinitionOperation debugOperation = await client.StartDebugSparkJobDefinitionAsync(sparkJobDefinition.Resource);
            SparkBatchJob job = await debugOperation.WaitForCompletionAsync();
        }
    }
}
