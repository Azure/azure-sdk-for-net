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
        [AsyncOnly]
        public async void CreateOrUpdateAppComponentAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            Uri enpointUrl = new Uri("https://" + endpoint);
            TokenCredential credential = TestEnvironment.Credential;

            // creating LoadTesting Administration Client
            LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(enpointUrl, credential);

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
