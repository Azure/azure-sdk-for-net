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
        [Test]
        public void DatasetSample()
        {
            #region Snippet:CreateDatasetClient
            // Replace the string below with your actual workspace url.
            string workspaceUrl = "<my-workspace-url>";
            /*@@*/workspaceUrl = TestEnvironment.WorkspaceUrl;
            DatasetClient client = new DatasetClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateDataset
            DatasetCreateOrUpdateDatasetOperation operation = client.StartCreateOrUpdateDataset("MyDataset", new DatasetResource(new Dataset(new LinkedServiceReference(LinkedServiceReferenceType.LinkedServiceReference, TestEnvironment.WorkspaceName + "-WorkspaceDefaultStorage"))));
            operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion

            #region Snippet:RetrieveDataset
            DatasetResource dataset = client.GetDataset("MyDataset");
            #endregion

            #region Snippet:ListDatasets
            Pageable<DatasetResource> datasets = client.GetDatasetsByWorkspace();
            foreach (DatasetResource set in datasets)
            {
                System.Console.WriteLine(set.Name);
            }
            #endregion

            #region Snippet:DeleteDataset
            client.StartDeleteDataset("MyDataset");
            #endregion
        }
    }
}
