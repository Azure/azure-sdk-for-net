// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.LoadTesting.Tests.Samples
{
    public partial class LoadTestingSamples: SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CreateOrUpdateTest()
        {
            #region Snippet:Azure_Developer_LoadTesting_CreatingClient

            string endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            // creating LoadTesting Client
            LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

            // getting appropirate Subclient
            LoadTestAdministrationClient loadTestAdministrationClient = loadTestingClient.getLoadTestAdministration();

            #endregion

            #region Snippet:Azure_Developer_LoadTesting_CreatOrUpdateTest

            // provide unique identifier for your test
            string testId = "my-test-id";

            // all data needs to be passed while creating a loadtest
            var data = new
            {
                description = "This is created using SDK",
                displayName = "SDK's LoadTest",
                loadTestConfig = new
                {
                    engineInstances = 1,
                    splitAllCSVs = false,
                },
                secrets = new { },
                enviornmentVariables = new { },
                passFailCriteria = new
                {
                    passFailMetrics = new { },
                }
            };

            try
            {
                Response response = loadTestAdministrationClient.CreateOrUpdateTest(testId, RequestContent.Create(data));

                // if the test is created successfully, printing response
                Console.WriteLine(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error : ", e.Message));
            }
            #endregion
        }
    }
}
