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

        [Test]
        public async Task TestGetNotebook()
        {
            NotebookClient client = CreateClient ();
            await foreach (var expectedNotebook in client.GetNotebooksByWorkspaceAsync())
            {
                NotebookResource actualNotebook = await client.GetNotebookAsync(expectedNotebook.Name);
                Assert.AreEqual(expectedNotebook.Name, actualNotebook.Name);
                Assert.AreEqual(expectedNotebook.Id, actualNotebook.Id);
                Assert.AreEqual(expectedNotebook.Properties.BigDataPool?.ReferenceName, actualNotebook.Properties.BigDataPool?.ReferenceName);
            }
        }

        [Test]
        public async Task TestCreateNotebook()
        {
            NotebookClient client = CreateClient ();

            Notebook notebook = new Notebook(
                new NotebookMetadata
                {
                    LanguageInfo = new NotebookLanguageInfo(name: "Python")
                },
                nbformat: 4,
                nbformatMinor: 2,
                new List<NotebookCell>()
            );
            string notebookName = Recording.GenerateName("Notebook");
            NotebookCreateOrUpdateNotebookOperation operation = await client.StartCreateOrUpdateNotebookAsync(notebookName, new NotebookResource(notebookName, notebook));
            NotebookResource notebookResource = await operation.WaitForCompletionAsync();
            Assert.AreEqual(notebookName, notebookResource.Name);
        }

        [Test]
        public async Task TestDeleteNotebook()
        {
            NotebookClient client = CreateClient ();

            string notebookName = Recording.GenerateName("Notebook");

            Notebook notebook = new Notebook(
                new NotebookMetadata
                {
                    LanguageInfo = new NotebookLanguageInfo(name: "Python")
                },
                nbformat: 4,
                nbformatMinor: 2,
                new List<NotebookCell>()
            );
            NotebookCreateOrUpdateNotebookOperation createOperation = await client.StartCreateOrUpdateNotebookAsync(notebookName, new NotebookResource(notebookName, notebook));
            await createOperation.WaitForCompletionAsync();

            NotebookDeleteNotebookOperation deleteOperation = await client.StartDeleteNotebookAsync(notebookName);
            Response response = await deleteOperation.WaitForCompletionAsync();
            Assert.AreEqual(200, response.Status);
        }
    }
}
