// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Core;
using System;
using System.Collections.Generic;

namespace Azure.Developer.LoadTesting.Tests.Samples
{
    public partial class LoadTestingSamples : SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void BeginTestRun()
        {
            #region Snippet:Azure_Developer_LoadTesting_CreateTestRunClient
#if SNIPPT
            // The data-plane endpoint is obtained from Control Plane APIs with "https://"
            Uri endpointUrl = new Uri("https://data-plane-guid.region.cnt-prod.loadtesting.azure.com");
            TokenCredential credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            Uri endpointUrl = new Uri("https://" + endpoint);
            TokenCredential credential = TestEnvironment.Credential;
#endif

            // creating LoadTesting TestRun Client
            LoadTestRunClient loadTestRunClient = new LoadTestRunClient(endpointUrl, credential);
            #endregion

            #region Snippet:Azure_Developer_LoadTesting_BeginTestRun

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
                TestRunOperation operation = loadTestRunClient.BeginTestRun(
                        WaitUntil.Started, testRunId, RequestContent.Create(data)
                   );

                // get inital response
                Response initialResponse = operation.GetRawResponse();
                Console.WriteLine(initialResponse.Content.ToString());

                // waiting for testrun to get completed
                operation.WaitForCompletion();

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
