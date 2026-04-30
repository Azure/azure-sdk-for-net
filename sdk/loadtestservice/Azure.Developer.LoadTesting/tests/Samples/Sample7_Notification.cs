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
        public void CreateOrUpdateNotificationRule()
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

            #region Snippet:Azure_Developer_LoadTesting_CreateOrUpdateNotificationRule

            string notificationRuleId = "my-notification-rule-id";
            string actionGroupResourceId = "/subscriptions/<subscription-id>/resourceGroups/<resource-group>/providers/microsoft.insights/actionGroups/<action-group-name>";

            var data = new
            {
                displayName = "My Notification Rule",
                scope = "Tests",
                actionGroupIds = new[] { actionGroupResourceId },
                events = new object[]
                {
                    new
                    {
                        eventType = "TestRunEnded",
                        condition = new
                        {
                            testRunStatuses = new[] { "DONE", "CANCELLED", "FAILED" },
                            testRunResults = new[] { "PASSED", "NOT_APPLICABLE" }
                        }
                    },
                    new
                    {
                        eventType = "TestRunStarted"
                    }
                }
            };

            try
            {
                Response response = loadTestAdministrationClient.CreateOrUpdateNotificationRule(notificationRuleId, RequestContent.Create(data));
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
        public void GetNotificationRule()
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

            #region Snippet:Azure_Developer_LoadTesting_GetNotificationRule

            string notificationRuleId = "my-notification-rule-id";

            try
            {
                Response<NotificationRule> response = loadTestAdministrationClient.GetNotificationRule(notificationRuleId);
                Console.WriteLine($"Notification Rule Id: {response.Value.NotificationRuleId}");
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
        public void ListNotificationRules()
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

            #region Snippet:Azure_Developer_LoadTesting_ListNotificationRules

            try
            {
                Pageable<NotificationRule> notificationRules = loadTestAdministrationClient.GetNotificationRules();

                foreach (NotificationRule rule in notificationRules)
                {
                    Console.WriteLine($"Notification Rule Id: {rule.NotificationRuleId}");
                    Console.WriteLine($"Display Name: {rule.DisplayName}");
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
        public void DeleteNotificationRule()
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

            #region Snippet:Azure_Developer_LoadTesting_DeleteNotificationRule

            string notificationRuleId = "my-notification-rule-id";

            try
            {
                Response response = loadTestAdministrationClient.DeleteNotificationRule(notificationRuleId);
                Console.WriteLine($"Notification Rule {notificationRuleId} deleted successfully. Status: {response.Status}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            #endregion
        }
    }
}