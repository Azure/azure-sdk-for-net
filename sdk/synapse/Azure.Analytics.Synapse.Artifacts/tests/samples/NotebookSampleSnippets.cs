// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class NotebookSnippets : SampleFixture
    {
        [Test]
        public async Task NotebookSample()
        {
            #region Snippet:CreateNotebookClient
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;
            NotebookClient client = new NotebookClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
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
            Response<NotebookResource> createdNotebook = await operation.WaitForCompletionAsync();
            #endregion

            #region Snippet:RetrieveNotebook
            NotebookResource retrievedNotebook = client.GetNotebook("MyNotebook");
            #endregion

            #region Snippet:ListNotebooks
            Pageable<NotebookResource> notebooks = client.GetNotebooksByWorkspace();
            foreach (NotebookResource notebook in notebooks)
            {
                System.Console.WriteLine(notebook.Name);
            }
            #endregion

            #region Snippet:DeleteNotebook
            client.StartDeleteNotebook("MyNotebook");
            #endregion
        }
    }
}
