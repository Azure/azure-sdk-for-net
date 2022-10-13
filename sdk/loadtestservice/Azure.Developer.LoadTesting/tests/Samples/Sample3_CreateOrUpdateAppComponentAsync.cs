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
        public async Task CreateOrUpdateAppComponentAsync()
        {
            #region Snippet:CreatingClient

            string endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            // creating LoadTesting Client
            LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

            // getting appropirate Subclient
            LoadTestAdministrationClient loadTestAdministrationClient = loadTestingClient.getLoadTestAdministration();

            #endregion

            #region Snippet:CreatOrUpdateTest

            // provide unique identifier for your test
            string testId = "my-test-id";

            // provide unique app component id
            string appComponentId = "my-app-component-id";

            string appComponentConnectionString = "/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourceGroups/App-Service-Sample-Demo-rg/providers/Microsoft.Web/sites/App-Service-Sample-Demo";
            // all other data to be sent to AppCompoent
            var data = new
            {
                testid = testId,
                name = "New App Component",
                value = new
                {
                    appComponentConnectionString = new
                    {
                        resourceId = appComponentConnectionString,
                        resourceName = "App-Service-Sample-Demo",
                        resourceType = "Microsoft.Web/sites",
                        subscriptionId = "7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a"
                    }
                }
            };

            try
            {
                // uploading file
                Response response = await loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(appComponentId, RequestContent.Create(data));
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
