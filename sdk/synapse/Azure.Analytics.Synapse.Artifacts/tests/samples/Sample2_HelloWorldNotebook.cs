// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Synapse.Samples
{
    /// <summary>
    /// This sample demonstrates how to create and upload a notebook using asynchronous methods of <see cref="NotebookClient"/>.
    /// </summary>
    public partial class Sample2_HelloWorldNotebook : SampleFixture
    {
        [Test]
        public async Task CreateAndUploadNotebook()
        {
            #region Snippet:CreateNotebookClient
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;
            var client = new NotebookClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:ConfigureNotebookResource
            string notebookName = "Test-Notebook";
            var cell = new NotebookCell("code", new NotebookMetadata (), new string[] {
                "from azureml.opendatasets import NycTlcYellow\n",
                "\n",
                "data = NycTlcYellow()\n",
                "df = data.to_spark_dataframe()\n",
                "# Display 10 rows\n",
                "display(df.limit(10))"
            });
            var newNotebook = new Notebook(new NotebookMetadata(), 4, 2, new NotebookCell[] { cell });
            var notebookResource = new NotebookResource(notebookName, newNotebook);
            #endregion

            #region Snippet:CreateNotebook
            NotebookCreateOrUpdateNotebookOperation operation = await client.StartCreateOrUpdateNotebookAsync(notebookName, notebookResource);
            await operation.WaitForCompletionAsync();
            Console.WriteLine("The notebook is created");
            #endregion

            #region Snippet:RetrieveNotebook
            NotebookResource retrievedNotebook = client.GetNotebook(notebookName);
            #endregion

            #region Snippet:ListNotebooks
            Pageable<NotebookResource> notebooks = client.GetNotebooksByWorkspace();
            foreach (NotebookResource notebook in notebooks)
            {
                Console.WriteLine(notebook.Name);
            }
            #endregion

            #region Snippet:DeleteNotebook
            NotebookDeleteNotebookOperation deleteNotebookOperation = client.StartDeleteNotebook(notebookName);
            await deleteNotebookOperation.WaitForCompletionAsync();
            #endregion
        }
    }
}
