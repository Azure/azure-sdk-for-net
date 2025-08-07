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
    public partial class LoadTestingSamples : SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task CreateOrUpdateTestProfileAsync()
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

            // creating LoadTesting Administration Client
            LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);

            #region Snippet:Azure_Developer_LoadTesting_CreateOrUpdateTestProfileAsync
            string testProfileId = "my-test-profile-id";
            string testId = "my-test-id"; // This test is already created
            string targetResourceId = TestEnvironment.TargetResourceId;

            var data = new
            {
                description = "This is created using SDK",
                displayName = "SDK's Test Profile",
                testId = testId,
                targetResourceId = targetResourceId,
                targetResourceConfigurations = new
                {
                    kind = "FunctionsFlexConsumption",
                    configurations = new
                    {
                        config1 = new
                        {
                            instanceMemoryMB = 2048,
                            httpConcurrency = 20
                        },
                        config2 = new
                        {
                            instanceMemoryMB = 4096,
                            httpConcurrency = 20
                        }
                    }
                }
            };

            try
            {
                Response response = await loadTestAdministrationClient.CreateOrUpdateTestProfileAsync(testProfileId, RequestContent.Create(data));
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
