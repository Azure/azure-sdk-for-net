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
    /// The suite of tests for the <see cref="NotebookClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class NotebookClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        internal class DisposableNotebook : IAsyncDisposable
        {
            private readonly NotebookClient _client;
            public NotebookResource Resource;

            private DisposableNotebook (NotebookClient client, NotebookResource resource)
            {
                _client = client;
                Resource = resource;
            }

            public string Name => Resource.Name;

            public static async ValueTask<DisposableNotebook> Create (NotebookClient client, TestRecording recording) =>
                new DisposableNotebook (client, await CreateResource(client, recording));

            public static async ValueTask<NotebookResource> CreateResource (NotebookClient client, TestRecording recording)
            {
                string name = recording.GenerateId("Notebook", 16);

                Notebook notebook = new Notebook (
                    new NotebookMetadata { LanguageInfo = new NotebookLanguageInfo(name: "Python") },
                    nbformat: 4,
                    nbformatMinor: 2,
                    new List<NotebookCell>()
                );
                NotebookCreateOrUpdateNotebookOperation createOperation = await client.StartCreateOrUpdateNotebookAsync(name, new NotebookResource(name, notebook));
                return await createOperation.WaitForCompletionAsync();
            }

            public async ValueTask DisposeAsync()
            {
                NotebookDeleteNotebookOperation operation = await _client.StartDeleteNotebookAsync (Name);
                await operation.WaitForCompletionAsync();
            }
        }

        public NotebookClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private NotebookClient CreateClient()
        {
            return InstrumentClient(new NotebookClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestGetNotebook()
        {
            NotebookClient client = CreateClient ();
            await using DisposableNotebook notebook = await DisposableNotebook.Create (client, this.Recording);

            IList<NotebookResource> notebooks = await client.GetNotebooksByWorkspaceAsync().ToListAsync();
            Assert.GreaterOrEqual(notebooks.Count, 1);

            foreach (var expectedNotebook in notebooks)
            {
                NotebookResource actualNotebook = await client.GetNotebookAsync(expectedNotebook.Name);
                Assert.AreEqual(expectedNotebook.Name, actualNotebook.Name);
                Assert.AreEqual(expectedNotebook.Id, actualNotebook.Id);
                Assert.AreEqual(expectedNotebook.Properties.BigDataPool?.ReferenceName, actualNotebook.Properties.BigDataPool?.ReferenceName);
            }
        }

        [RecordedTest]
        public async Task TestDeleteNotebook()
        {
            NotebookClient client = CreateClient();

            NotebookResource resource = await DisposableNotebook.CreateResource (client, this.Recording);

            NotebookDeleteNotebookOperation operation = await client.StartDeleteNotebookAsync (resource.Name);
            await operation.WaitAndAssertSuccessfulCompletion();
        }

        [RecordedTest]
        public async Task TestRenameLinkedService()
        {
            NotebookClient client = CreateClient();

            NotebookResource resource = await DisposableNotebook.CreateResource (client, Recording);

            string newNotebookName = Recording.GenerateId("Notebook2", 16);

            NotebookRenameNotebookOperation renameOperation = await client.StartRenameNotebookAsync (resource.Name, new ArtifactRenameRequest () { NewName = newNotebookName } );
            await renameOperation.WaitForCompletionAsync();

            NotebookResource notebook = await client.GetNotebookAsync (newNotebookName);
            Assert.AreEqual (newNotebookName, notebook.Name);

            NotebookDeleteNotebookOperation operation = await client.StartDeleteNotebookAsync (newNotebookName);
            await operation.WaitForCompletionAsync();
        }

        [Ignore ("https://github.com/Azure/azure-sdk-for-net/issues/18080 - Notebook summary appears to require Synapse.Spark execution first")]
        [RecordedTest]
        public async Task TestGetSummary()
        {
            NotebookClient client = CreateClient();

            await using DisposableNotebook notebook = await DisposableNotebook.Create (client, this.Recording);
            AsyncPageable<NotebookResource> summary = client.GetNotebookSummaryByWorkSpaceAsync ();
            Assert.GreaterOrEqual((await summary.ToListAsync()).Count, 1);
        }
    }
}
