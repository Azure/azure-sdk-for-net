// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            #region Snippet:Azure_Developer_LoadTesting_CreateAdminClient

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
#endregion

#region Snippet:Azure_Developer_LoadTesting_CreateOrUpdateTest
            string testId = "my-test-id";
            Uri keyVaultSecretUrl = new Uri("https://sdk-testing-keyvault.vault.azure.net/secrets/sdk-secret");

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
                secrets = new
                {
                    secret1 = new
                    {
                        value = keyVaultSecretUrl.ToString(),
                        type = "AKV_SECRET_URI"
                    }
                },
                enviornmentVariables = new
                {
                    myVariable = "my-value"
                },
                passFailCriteria = new
                {
                    passFailMetrics = new
                    {
                        condition1 = new
                        {
                            clientmetric = "response_time_ms",
                            aggregate = "avg",
                            condition = ">",
                            value = 300
                        },
                        condition2 = new
                        {
                            clientmetric = "error",
                            aggregate = "percentage",
                            condition = ">",
                            value = 50
                        },
                        condition3 = new
                        {
                            clientmetric = "latency",
                            aggregate = "avg",
                            condition = ">",
                            value = 200,
                            requestName = "GetCustomerDetails"
                        }
                    },
                }
            };

            try
            {
                Response response = loadTestAdministrationClient.CreateOrUpdateTest(testId, RequestContent.Create(data));
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
