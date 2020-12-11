// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;
using Azure.Analytics.Synapse.Artifacts.Models;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class DataFlowSnippets : SampleFixture
    {
        [Test]
        public async Task DataFlowSample()
        {
            #region Snippet:CreateDataFlowClient
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;
            DataFlowClient client = new DataFlowClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateDataFlow
            DataFlowCreateOrUpdateDataFlowOperation operation = client.StartCreateOrUpdateDataFlow("MyDataFlow", new DataFlowResource(new DataFlow()));
            Response<DataFlowResource> createdDataflow = await operation.WaitForCompletionAsync();
            #endregion

            #region Snippet:RetrieveDataFlow
            DataFlowResource retrievedDataflow = client.GetDataFlow("MyDataFlow");
            #endregion

            #region Snippet:ListDataFlows
            Pageable<DataFlowResource> dataFlows = client.GetDataFlowsByWorkspace();
            foreach (DataFlowResource dataflow in dataFlows)
            {
                System.Console.WriteLine(dataflow.Name);
            }
            #endregion

            #region Snippet:DeleteDataFlow
            client.StartDeleteDataFlow("MyDataFlow");
            #endregion
        }
    }
}
