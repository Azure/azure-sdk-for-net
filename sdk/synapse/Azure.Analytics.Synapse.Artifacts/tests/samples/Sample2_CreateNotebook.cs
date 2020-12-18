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
    public partial class NotebookSample
    {
        [Test]
        public async Task CreateAndUploadNotebook()
        {
            string notebookName = "demo_notebook";
            string endpoint = TestEnvironment.EndpointUrl;

            var client = new NotebookClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());

            var cell = new NotebookCell("code", new NotebookMetadata (), new string[] {
                "from azureml.opendatasets import NycTlcYellow\n",
                "\n",
                "data = NycTlcYellow()\n",
                "df = data.to_spark_dataframe()\n",
                "# Display 10 rows\n",
                "display(df.limit(10))"
            });
            var notebook = new Notebook(new NotebookMetadata(), 4, 2, new NotebookCell[] { cell });
            var notebookResource = new NotebookResource(notebookName, notebook);

            NotebookCreateOrUpdateNotebookOperation operation = await client.StartCreateOrUpdateNotebookAsync(notebookName, notebookResource);
            await operation.WaitForCompletionAsync();
            Console.WriteLine("Notebook is created");
        }
    }
}
