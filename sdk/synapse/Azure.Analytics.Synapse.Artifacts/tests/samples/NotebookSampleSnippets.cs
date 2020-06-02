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
        private NotebookClient notebookClient;

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            #region Snippet:CreateNotebookClient
            // Create a new notebook client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            NotebookClient client = new NotebookClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            this.notebookClient = client;
        }

        [Test]
        public void CreateNotebook()
        {
            #region Snippet:CreateNotebook
            Notebook notebook = new Notebook(
                new NotebookMetadata
                {
                    LanguageInfo = new NotebookLanguageInfo(name: "Python")
                },
                nbformat: 4,
                nbformatMinor: 2,
                new List<NotebookCell>()
            );
            NotebookResource createdNotebook = notebookClient.CreateOrUpdateNotebook("MyNotebook", new NotebookResource(notebook));
            #endregion
        }

        [Test]
        public void RetrieveNotebook()
        {
            #region Snippet:RetrieveNotebook
            NotebookResource notebook = notebookClient.GetNotebook("MyNotebook");
            #endregion
        }

        [Test]
        public void ListNotebooks()
        {
            #region Snippet:ListNotebooks
            Pageable<NotebookResource> notebooks = notebookClient.GetNotebooksByWorkspace();
            foreach (NotebookResource notebook in notebooks)
            {
                System.Console.WriteLine(notebook.Name);
            }
            #endregion
        }

        [Test]
        public void DeleteNotebook()
        {
            #region Snippet:DeleteNotebook
            notebookClient.DeleteNotebook("MyNotebook");
            #endregion
        }
    }
}
