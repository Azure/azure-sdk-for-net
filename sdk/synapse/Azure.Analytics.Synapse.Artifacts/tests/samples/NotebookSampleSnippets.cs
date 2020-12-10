// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;
using System.Collections.Generic;
using Azure.Analytics.Synapse.Artifacts.Models;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class NotebookSnippets : SampleFixture
    {
        [Test]
        public void NotebookSample()
        {
            #region Snippet:CreateNotebookClient
            // Replace the string below with your actual workspace url.
            string workspaceUrl = "<my-workspace-url>";
            /*@@*/workspaceUrl = TestEnvironment.WorkspaceUrl;
            NotebookClient client = new NotebookClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateNotebook
            Notebook newNotebook = new Notebook(
                new NotebookMetadata
                {
                    LanguageInfo = new NotebookLanguageInfo(name: "Python")
                },
                nbformat: 4,
                nbformatMinor: 2,
                new List<NotebookCell>()
            );
            string notebookName = "MyNotebook";
            NotebookCreateOrUpdateNotebookOperation operation = client.StartCreateOrUpdateNotebook(notebookName, new NotebookResource(notebookName, newNotebook));
            NotebookResource notebookResource = operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion

            #region Snippet:RetrieveNotebook
            NotebookResource notebook = client.GetNotebook("MyNotebook");
            #endregion

            #region Snippet:ListNotebooks
            Pageable<NotebookResource> notebooks = client.GetNotebooksByWorkspace();
            foreach (NotebookResource book in notebooks)
            {
                System.Console.WriteLine(book.Name);
            }
            #endregion

            #region Snippet:DeleteNotebook
            client.StartDeleteNotebook("MyNotebook");
            #endregion
        }
    }
}
