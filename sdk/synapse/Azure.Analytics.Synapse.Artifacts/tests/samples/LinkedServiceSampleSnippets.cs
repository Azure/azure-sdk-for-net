// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;
using Azure.Analytics.Synapse.Artifacts.Models;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class LinkedServiceSnippets : SampleFixture
    {
        private LinkedServiceClient LinkedServiceClient;

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            #region Snippet:CreateLinkedServiceClient
            // Create a new LinkedService client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            LinkedServiceClient client = new LinkedServiceClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            this.LinkedServiceClient = client;
        }

        [Test]
        public void CreateLinkedService()
        {
            #region Snippet:CreateLinkedService
            LinkedServiceCreateOrUpdateLinkedServiceOperation operation = LinkedServiceClient.StartCreateOrUpdateLinkedService("MyLinkedService", new LinkedServiceResource(new AzureDataLakeStoreLinkedService("adl://test.azuredatalakestore.net/")));
            LinkedServiceResource linkedService = operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion
        }

        [Test]
        public void RetrieveLinkedService()
        {
            #region Snippet:RetrieveLinkedService
            LinkedServiceResource linkedService = LinkedServiceClient.GetLinkedService("MyLinkedService");
            #endregion
        }

        [Test]
        public void ListLinkedServices()
        {
            #region Snippet:ListLinkedServices
            Pageable<LinkedServiceResource> linkedServices = LinkedServiceClient.GetLinkedServicesByWorkspace();
            foreach (LinkedServiceResource linkedService in linkedServices)
            {
                System.Console.WriteLine(linkedService.Name);
            }
            #endregion
        }

        [Test]
        public void DeleteLinkedService()
        {
            #region Snippet:DeleteLinkedService
            LinkedServiceClient.StartDeleteLinkedService("MyLinkedService");
            #endregion
        }
    }
}
