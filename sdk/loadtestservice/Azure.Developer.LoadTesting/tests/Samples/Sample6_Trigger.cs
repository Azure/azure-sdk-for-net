// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.LoadTesting.Tests.Samples
{
    public partial class LoadTestingSamples : SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void CreateOrUpdateTrigger()
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

            #region Snippet:Azure_Developer_LoadTesting_CreateOrUpdateTrigger

            string triggerId = "my-trigger-id";
            string testId = "my-test-id";

            var data = new
            {
                displayName = "My Scheduled Trigger",
                kind = "ScheduleTestsTrigger",
                testIds = new[] { testId },
                startDateTime = DateTimeOffset.UtcNow.AddDays(1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                recurrence = new
                {
                    frequency = "Daily",
                    interval = 1,
                    recurrenceEnd = new
                    {
                        endDateTime = DateTimeOffset.UtcNow.AddDays(30).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                    }
                }
            };

            try
            {
                Response response = loadTestAdministrationClient.CreateOrUpdateTrigger(triggerId, RequestContent.Create(data));
                Console.WriteLine(response.Content.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
        }

        [Test]
        [SyncOnly]
        public void GetTrigger()
        {
#if SNIPPET
            Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
            TokenCredential credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            Uri endpointUrl = new Uri("https://" + endpoint);
            TokenCredential credential = TestEnvironment.Credential;
#endif
            LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);

            #region Snippet:Azure_Developer_LoadTesting_GetTrigger

            string triggerId = "my-trigger-id";

            try
            {
                Response<LoadTestingTrigger> response = loadTestAdministrationClient.GetTrigger(triggerId);
                Console.WriteLine($"Trigger Id: {response.Value.TriggerId}");
                Console.WriteLine($"Display Name: {response.Value.DisplayName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
        }

        [Test]
        [SyncOnly]
        public void ListTriggers()
        {
#if SNIPPET
            Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
            TokenCredential credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            Uri endpointUrl = new Uri("https://" + endpoint);
            TokenCredential credential = TestEnvironment.Credential;
#endif
            LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);

            #region Snippet:Azure_Developer_LoadTesting_ListTriggers

            try
            {
                Pageable<LoadTestingTrigger> triggers = loadTestAdministrationClient.GetTriggers();

                foreach (LoadTestingTrigger trigger in triggers)
                {
                    Console.WriteLine($"Trigger Id: {trigger.TriggerId}");
                    Console.WriteLine($"Display Name: {trigger.DisplayName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
        }

        [Test]
        [SyncOnly]
        public void DeleteTrigger()
        {
#if SNIPPET
            Uri endpointUrl = new Uri("https://" + <your resource URI obtained from steps above>);
            TokenCredential credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            Uri endpointUrl = new Uri("https://" + endpoint);
            TokenCredential credential = TestEnvironment.Credential;
#endif
            LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(endpointUrl, credential);

            #region Snippet:Azure_Developer_LoadTesting_DeleteTrigger

            string triggerId = "my-trigger-id";

            try
            {
                Response response = loadTestAdministrationClient.DeleteTrigger(triggerId);
                Console.WriteLine($"Trigger {triggerId} deleted successfully. Status: {response.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
        }
    }
}