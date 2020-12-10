// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;
using Azure.Analytics.Synapse.Artifacts.Models;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class DataFlowSnippets : SampleFixture
    {
        [Test]
        public void DataFlowSample()
        {
            #region Snippet:CreateDataFlowClient
            // Replace the string below with your actual workspace url.
            string workspaceUrl = "<my-workspace-url>";
            /*@@*/workspaceUrl = TestEnvironment.WorkspaceUrl;
            DataFlowClient client = new DataFlowClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateDataFlow
            DataFlowCreateOrUpdateDataFlowOperation operation = client.StartCreateOrUpdateDataFlow("MyDataFlow", new DataFlowResource(new DataFlow()));
            operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion

            #region Snippet:RetrieveDataFlow
            DataFlowResource dataFlow = client.GetDataFlow("MyDataFlow");
            #endregion

            #region Snippet:ListDataFlows
            Pageable<DataFlowResource> dataFlows = client.GetDataFlowsByWorkspace();
            foreach (DataFlowResource flow in dataFlows)
            {
                System.Console.WriteLine(flow.Name);
            }
            #endregion

            #region Snippet:DeleteDataFlow
            client.StartDeleteDataFlow("MyDataFlow");
            #endregion
        }
    }
}
