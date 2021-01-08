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
    public partial class Sample5_HelloWorldDataset : SampleFixture
    {
        [Test]
        public async Task DatasetSample()
        {
            #region Snippet:CreateDatasetClientPrep
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;

            string storageName = "<my-storage-name>";
            /*@@*/storageName = TestEnvironment.WorkspaceName + "-WorkspaceDefaultStorage";

            string dataSetName = "Test-Dataset";
            #endregion

            #region Snippet:CreateDatasetClient
            DatasetClient client = new DatasetClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateDataset
            Dataset data = new Dataset(new LinkedServiceReference(LinkedServiceReferenceType.LinkedServiceReference, storageName));
            DatasetCreateOrUpdateDatasetOperation operation = client.StartCreateOrUpdateDataset(dataSetName, new DatasetResource(data));
            Response<DatasetResource> createdDataset = await operation.WaitForCompletionAsync();
            #endregion

            #region Snippet:RetrieveDataset
            DatasetResource retrievedDataset = client.GetDataset(dataSetName);
            #endregion

            #region Snippet:ListDatasets
            Pageable<DatasetResource> datasets = client.GetDatasetsByWorkspace();
            foreach (DatasetResource dataset in datasets)
            {
                System.Console.WriteLine(dataset.Name);
            }
            #endregion

            #region Snippet:DeleteDataset
            DatasetDeleteDatasetOperation deleteDatasetOperation = client.StartDeleteDataset(dataSetName);
            await deleteDatasetOperation.WaitForCompletionAsync();
            #endregion
        }
    }
}
