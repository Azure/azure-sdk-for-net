// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.LoadTesting.Tests.Samples
{
    public partial class LoadTestingSamples : SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CloneTest()
        {
#if SNIPPET
            // The data-plane endpoint is obtained from Control Plane APIs with "https://"
            // To obtain endpoint please follow: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.LoadTesting#data-plane-endpoint
            Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
            TokenCredential credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            Uri endpointUrl = new Uri("https://" + endpoint);
            TokenCredential credential = TestEnvironment.Credential;
#endif
            LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);

            #region Snippet:Azure_Developer_LoadTesting_CloneTest

            string sourceTestId = "existing-test-id";
            string newTestId = "cloned-test-id";

            var data = new
            {
                sourceTestId = sourceTestId,
            };

            try
            {
                Response response = loadTestAdministrationClient.CreateOrUpdateTest(newTestId, RequestContent.Create(data));
                Console.WriteLine(response.Content.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
        }
    }
}