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
        [Test]
        public void LinkedServiceSample()
        {
            #region Snippet:CreateLinkedServiceClient
            // Replace the string below with your actual workspace url.
            string workspaceUrl = "<my-workspace-url>";
            /*@@*/workspaceUrl = TestEnvironment.WorkspaceUrl;
            LinkedServiceClient client = new LinkedServiceClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateLinkedService
            LinkedServiceCreateOrUpdateLinkedServiceOperation operation = client.StartCreateOrUpdateLinkedService("MyLinkedService", new LinkedServiceResource(new AzureDataLakeStoreLinkedService("adl://test.azuredatalakestore.net/")));
            operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion

            #region Snippet:RetrieveLinkedService
            LinkedServiceResource linkedService = client.GetLinkedService("MyLinkedService");
            #endregion

            #region Snippet:ListLinkedServices
            Pageable<LinkedServiceResource> linkedServices = client.GetLinkedServicesByWorkspace();
            foreach (LinkedServiceResource service in linkedServices)
            {
                System.Console.WriteLine(service.Name);
            }
            #endregion

            #region Snippet:DeleteLinkedService
            client.StartDeleteLinkedService("MyLinkedService");
            #endregion
        }
    }
}
