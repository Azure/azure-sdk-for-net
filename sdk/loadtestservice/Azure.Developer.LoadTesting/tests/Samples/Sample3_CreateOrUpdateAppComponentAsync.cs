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
            string endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            // creating LoadTesting Client
            LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

            // getting appropriate Subclient
            LoadTestAdministrationClient loadTestAdministrationClient = loadTestingClient.getLoadTestAdministration();

            #region Snippet:Azure_Developer_LoadTesting_CreateOrUpdateAppComponentAsync

            // provide unique identifier for your test
            string testId = "my-test-id";

            // provide unique app component id
            string appComponentId = "my-app-component-id";
            string subscriptionId = "00000000-0000-0000-0000-000000000000";

            string appComponentConnectionString = "/subscriptions/" + subscriptionId + "/resourceGroups/App-Service-Sample-Demo-rg/providers/Microsoft.Web/sites/App-Service-Sample-Demo";

            // all other data to be sent to AppComponent
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
                        subscriptionId = subscriptionId
                    }
                }
            };

            try
            {
                // create or update app component
                Response response = await loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(appComponentId, RequestContent.Create(data));

                // if successfully, printing response
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
