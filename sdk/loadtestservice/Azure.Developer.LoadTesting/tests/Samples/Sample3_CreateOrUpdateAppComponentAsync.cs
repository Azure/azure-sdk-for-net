// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.Developer.LoadTesting.Tests.Samples
{
    public partial class LoadTestingSamples : SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task CreateOrUpdateAppComponentAsync()
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

            #region Snippet:Azure_Developer_LoadTesting_CreateOrUpdateAppComponentAsync

            string testId = "my-loadtest";
            string resourceId = TestEnvironment.ResourceId;

            try
            {
                Response response = await loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(testId,
                        RequestContent.Create(
                                new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                                {
                                    { "components",  new Dictionary<string, Dictionary<string, string>>
                                        {
                                            { resourceId, new Dictionary<string, string>
                                                {
                                                    { "resourceId", resourceId },
                                                    { "resourceName", "App-Service-Sample-Demo" },
                                                    { "resourceType", "Microsoft.Web/sites" },
                                                    { "kind", "web" }
                                                }
                                            }
                                        }
                                    }
                                }
                            )
                    );

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
