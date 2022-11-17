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
        [AsyncOnly]
        public async Task CreateOrUpdateTestAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            // creating LoadTesting Client
            LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

            // getting appropriate Subclient
            LoadTestAdministrationClient loadTestAdministrationClient = loadTestingClient.getLoadTestAdministration();

            #region Snippet:Azure_Developer_LoadTesting_CreateOrUpdateTestAsync

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
                secrets = new
                {
                    secret1 = new
                    {
                        value = "https://sdk-testing-keyvault.vault.azure.net/secrets/sdk-secret",
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
                Response response = await loadTestAdministrationClient.CreateOrUpdateTestAsync(testId, RequestContent.Create(data));

                // if the test is created successfully, printing response
                Console.WriteLine(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Error : ", e.Message));
            }
            #endregion
        }
    }
}
