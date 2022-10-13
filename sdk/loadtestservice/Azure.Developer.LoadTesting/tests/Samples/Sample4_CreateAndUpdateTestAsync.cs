// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Developer.LoadTesting.Tests.Samples
{
    public partial class LoadTestingSamples: SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task CreateAndUpdateTestAsync()
        {
            #region Snippet:CreatingClient

            string endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            // creating LoadTesting Client
            LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

            // getting appropirate Subclient
            TestRunClient testRunClient = loadTestingClient.getLoadTestRun();

            #endregion

            #region Snippet:CreatOrUpdateTest

            // provide unique identifier for your test
            string testId = "my-test-id";

            // provide unique testrun id
            string testRunId = "my-test-run-id";

            // all other data to be sent to testRun
            var data = new
            {
                testid = testId,
                displayName = "Some display name"
            };

            try
            {
                // uploading file
                Response response = await testRunClient.CreateAndUpdateTestAsync(testRunId, RequestContent.Create(data));
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
