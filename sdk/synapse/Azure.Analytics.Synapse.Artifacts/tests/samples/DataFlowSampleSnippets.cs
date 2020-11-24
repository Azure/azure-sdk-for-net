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
        private DataFlowClient DataFlowClient;

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            #region Snippet:CreateDataFlowClient
            // Create a new DataFlow client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            DataFlowClient client = new DataFlowClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            this.DataFlowClient = client;
        }

        [Test]
        public void CreateDataFlow()
        {
            #region Snippet:CreateDataFlow
            DataFlowCreateOrUpdateDataFlowOperation operation = DataFlowClient.StartCreateOrUpdateDataFlow("MyDataFlow", new DataFlowResource(new DataFlow()));
            DataFlowResource dataFlow = operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion
        }

        [Test]
        public void RetrieveDataFlow()
        {
            #region Snippet:RetrieveDataFlow
            DataFlowResource dataFlow = DataFlowClient.GetDataFlow("MyDataFlow");
            #endregion
        }

        [Test]
        public void ListDataFlows()
        {
            #region Snippet:ListDataFlows
            Pageable<DataFlowResource> dataFlows = DataFlowClient.GetDataFlowsByWorkspace();
            foreach (DataFlowResource dataFlow in dataFlows)
            {
                System.Console.WriteLine(dataFlow.Name);
            }
            #endregion
        }

        [Test]
        public void DeleteDataFlow()
        {
            #region Snippet:DeleteDataFlow
            DataFlowClient.StartDeleteDataFlow("MyDataFlow");
            #endregion
        }
    }
}
