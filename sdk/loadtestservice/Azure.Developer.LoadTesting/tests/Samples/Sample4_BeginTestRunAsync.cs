﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Core;
using System;
using System.Threading.Tasks;

namespace Azure.Developer.LoadTesting.Tests.Samples
{
    public partial class LoadTestingSamples : SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task BeginTestRunAsync()
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

            // creating LoadTesting TestRun Client
            LoadTestRunClient loadTestRunClient = new LoadTestRunClient(endpointUrl, credential);

            #region Snippet:Azure_Developer_LoadTesting_BeginTestRunAsync

            string testId = "my-loadtest";
            string resourceId = TestEnvironment.ResourceId;
            string testRunId = "my-loadtest-run";

            // all other data to be sent to testRun
            var data = new
            {
                testid = testId,
                displayName = "My display name"
            };

            try
            {
                TestRunResultOperation operation = await loadTestRunClient.BeginTestRunAsync(
                        WaitUntil.Started, testRunId, RequestContent.Create(data)
                   );

                // get inital response
                Response initialResponse = operation.GetRawResponse();
                Console.WriteLine(initialResponse.Content.ToString());

                // waiting for testrun to get completed
                await operation.WaitForCompletionAsync();

                // final reponse
                Response finalResponse = operation.GetRawResponse();
                Console.WriteLine(finalResponse.Content.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }
    }
}
