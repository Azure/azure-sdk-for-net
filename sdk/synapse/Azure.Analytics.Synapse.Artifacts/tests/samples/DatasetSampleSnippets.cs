// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class DatasetSnippets : SampleFixture
    {
        [Test]
        public async Task DatasetSample()
        {
            #region Snippet:CreateDatasetClient
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;
            DatasetClient client = new DatasetClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateDataset
            DatasetCreateOrUpdateDatasetOperation operation = client.StartCreateOrUpdateDataset("MyDataset", new DatasetResource(new Dataset(new LinkedServiceReference(LinkedServiceReferenceType.LinkedServiceReference, TestEnvironment.WorkspaceName + "-WorkspaceDefaultStorage"))));
            Response<DatasetResource> createdDataset = await operation.WaitForCompletionAsync();
            #endregion

            #region Snippet:RetrieveDataset
            DatasetResource retrievedDataset = client.GetDataset("MyDataset");
            #endregion

            #region Snippet:ListDatasets
            Pageable<DatasetResource> datasets = client.GetDatasetsByWorkspace();
            foreach (DatasetResource dataset in datasets)
            {
                System.Console.WriteLine(dataset.Name);
            }
            #endregion

            #region Snippet:DeleteDataset
            client.StartDeleteDataset("MyDataset");
            #endregion
        }
    }
}
