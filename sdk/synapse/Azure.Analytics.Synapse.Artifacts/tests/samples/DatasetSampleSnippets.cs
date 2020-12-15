// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;
using Azure.Analytics.Synapse.Artifacts.Models;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class DatasetSnippets : SampleFixture
    {
        private DatasetClient DatasetClient;

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            #region Snippet:CreateDatasetClient
            // Create a new Dataset client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            DatasetClient client = new DatasetClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            this.DatasetClient = client;
        }

        [Test]
        public void CreateDataset()
        {
            #region Snippet:CreateDataset
            DatasetCreateOrUpdateDatasetOperation operation = DatasetClient.StartCreateOrUpdateDataset("MyDataset", new DatasetResource(new Dataset(new LinkedServiceReference(LinkedServiceReferenceType.LinkedServiceReference, TestEnvironment.WorkspaceName + "-WorkspaceDefaultStorage"))));
            DatasetResource dataset = operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion
        }

        [Test]
        public void RetrieveDataset()
        {
            #region Snippet:RetrieveDataset
            DatasetResource dataset = DatasetClient.GetDataset("MyDataset");
            #endregion
        }

        [Test]
        public void ListDatasets()
        {
            #region Snippet:ListDatasets
            Pageable<DatasetResource> datasets = DatasetClient.GetDatasetsByWorkspace();
            foreach (DatasetResource dataset in datasets)
            {
                System.Console.WriteLine(dataset.Name);
            }
            #endregion
        }

        [Test]
        public void DeleteDataset()
        {
            #region Snippet:DeleteDataset
            DatasetClient.StartDeleteDataset("MyDataset");
            #endregion
        }
    }
}
