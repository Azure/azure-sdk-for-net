// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Analytics.Synapse.Tests;
using Azure.Identity;
using NUnit.Framework;
using Azure.Analytics.Synapse.Artifacts.Models;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class Sample6_HelloWorldLinkedService : SamplesBase<SynapseTestEnvironment>
    {
        [Test]
        public async Task LinkedServiceSample()
        {
            #region Snippet:CreateLinkedServiceClientPrep
#if SNIPPET
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";

            // Replace the string below with your actual datalake endpoint url.
            string dataLakeEndpoint = "<my-datalake-url>";
#else
            string endpoint = TestEnvironment.EndpointUrl;

            string dataLakeEndpoint = "adl://test.azuredatalakestore.net/";
#endif
            string serviceName = "Test-LinkedService";
            #endregion

            #region Snippet:CreateLinkedServiceClient
            LinkedServiceClient client = new LinkedServiceClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreateLinkedService
            LinkedServiceResource serviceResource = new LinkedServiceResource(new AzureDataLakeStoreLinkedService(dataLakeEndpoint));
            LinkedServiceCreateOrUpdateLinkedServiceOperation operation = client.StartCreateOrUpdateLinkedService(serviceName, serviceResource);
            Response<LinkedServiceResource> createdService = await operation.WaitForCompletionAsync();
            #endregion

            #region Snippet:RetrieveLinkedService
            LinkedServiceResource retrievedService = client.GetLinkedService(serviceName);
            #endregion

            #region Snippet:ListLinkedServices
            Pageable<LinkedServiceResource> linkedServices = client.GetLinkedServicesByWorkspace();
            foreach (LinkedServiceResource linkedService in linkedServices)
            {
                System.Console.WriteLine(linkedService.Name);
            }
            #endregion

            #region Snippet:DeleteLinkedService
            LinkedServiceDeleteLinkedServiceOperation deleteLinkedServiceOperation = client.StartDeleteLinkedService(serviceName);
            await deleteLinkedServiceOperation.WaitForCompletionResponseAsync();
            #endregion
        }
    }
}
