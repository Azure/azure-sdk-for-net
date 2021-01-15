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
        /// <summary>
        /// Initializes a new instance of the <see cref="NotebookClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public NotebookClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task TestGetNotebook()
        {
            await foreach (var expectedNotebook in NotebookClient.GetNotebooksByWorkspaceAsync())
            {
                NotebookResource actualNotebook = await NotebookClient.GetNotebookAsync(expectedNotebook.Name);
                Assert.AreEqual(expectedNotebook.Name, actualNotebook.Name);
                Assert.AreEqual(expectedNotebook.Id, actualNotebook.Id);
                Assert.AreEqual(expectedNotebook.Properties.BigDataPool?.ReferenceName, actualNotebook.Properties.BigDataPool?.ReferenceName);
            }
        }

        [Test]
        public async Task TestCreateNotebook()
        {
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
            NotebookCreateOrUpdateNotebookOperation operation = await NotebookClient.StartCreateOrUpdateNotebookAsync(notebookName, new NotebookResource(notebookName, notebook));
            NotebookResource notebookResource = await operation.WaitForCompletionAsync();
            Assert.AreEqual(notebookName, notebookResource.Name);
        }

        [Test]
        public async Task TestDeleteNotebook()
        {
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
            NotebookCreateOrUpdateNotebookOperation createOperation = await NotebookClient.StartCreateOrUpdateNotebookAsync(notebookName, new NotebookResource(notebookName, notebook));
            await createOperation.WaitForCompletionAsync();

            NotebookDeleteNotebookOperation deleteOperation = await NotebookClient.StartDeleteNotebookAsync(notebookName);
            Response response = await deleteOperation.WaitForCompletionAsync();
            Assert.AreEqual(200, response.Status);
        }
    }
}
