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

            string endpoint = TestEnvironment.Endpoint;
            Uri enpointUrl = new Uri("https://"+endpoint);
            TokenCredential credential = TestEnvironment.Credential;

            // creating LoadTesting Administration Client
            LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(enpointUrl, credential);
            #endregion

            #region Snippet:Azure_Developer_LoadTesting_CreateOrUpdateTest
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
