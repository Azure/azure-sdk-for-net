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
    public partial class LinkedServiceSnippets : SampleFixture
    {
        [Test]
        public async Task LinkedServiceSample()
        {
            #region Snippet:CreateLinkedServiceClient
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;
            LinkedServiceClient client = new LinkedServiceClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateLinkedService
            LinkedServiceResource serviceResource = new LinkedServiceResource(new AzureDataLakeStoreLinkedService("adl://test.azuredatalakestore.net/"));
            LinkedServiceCreateOrUpdateLinkedServiceOperation operation = client.StartCreateOrUpdateLinkedService("MyLinkedService", serviceResource);
            Response<LinkedServiceResource> createdService = await operation.WaitForCompletionAsync();
            #endregion

            #region Snippet:RetrieveLinkedService
            LinkedServiceResource retrievedService = client.GetLinkedService("MyLinkedService");
            #endregion

            #region Snippet:ListLinkedServices
            Pageable<LinkedServiceResource> linkedServices = client.GetLinkedServicesByWorkspace();
            foreach (LinkedServiceResource linkedService in linkedServices)
            {
                System.Console.WriteLine(linkedService.Name);
            }
            #endregion

            #region Snippet:DeleteLinkedService
            client.StartDeleteLinkedService("MyLinkedService");
            #endregion
        }
    }
}
