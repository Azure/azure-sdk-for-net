// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Monitor.Tests.Scenarios
{
    public class ServiceDiagnosticSettingsTests : TestBase
    {
        //private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";
        private const string ResourceUri = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/Microsoft.Web/sites/alertruleTest";
        private RecordedDelegatingHandler handler;

        public ServiceDiagnosticSettingsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }


        /// <summary>
        /// User needs several permissions before executing these commands. Otherwise it fails for some authorization issue.
        /// </summary>
        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateGetUpdateServiceDiagnosticSetting()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var expResponse = CreateDiagnosticSettings();
                var insightsClient = GetMonitorManagementClient(context, handler);

                var parameters = CreateDiagnosticSettingsParams();

                ServiceDiagnosticSettingsResource response = insightsClient.ServiceDiagnosticSettings.CreateOrUpdate(
                    resourceUri: ResourceUri,
                    parameters: parameters);

                if (!this.IsRecording)
                {
                    Check(response);

                    // AreEqual(expResponse, response);
                }

                ServiceDiagnosticSettingsResource actualResponse = insightsClient.ServiceDiagnosticSettings.Get(resourceUri: ResourceUri);

                if (!this.IsRecording)
                {
                    Check(actualResponse);

                    Utilities.AreEqual(response, actualResponse);
                }

                ServiceDiagnosticSettingsResourcePatch patchResource = new ServiceDiagnosticSettingsResourcePatch(
                    tags: response.Tags,
                    storageAccountId: response.StorageAccountId,
                    serviceBusRuleId: response.ServiceBusRuleId,
                    eventHubAuthorizationRuleId: response.EventHubAuthorizationRuleId,
                    metrics: response.Metrics,
                    logs: response.Logs,
                    workspaceId: response.WorkspaceId
                );

                patchResource.Metrics[0].RetentionPolicy.Days = 10;
                patchResource.Metrics[0].RetentionPolicy.Enabled = true;
                patchResource.Metrics[0].Enabled = true;

                patchResource.Logs = new List<LogSettings>
                {
                    new LogSettings
                    {
                            RetentionPolicy = new RetentionPolicy
                            {
                                Days = 5,
                                Enabled = true
                            }
                    }
                };

                // TODO: fails with message: 'Category' is not supported
                ServiceDiagnosticSettingsResource patchResponse = null;

                Assert.Throws<ErrorResponseException>(
                    () => patchResponse = insightsClient.ServiceDiagnosticSettings.Update(
                        resourceUri: ResourceUri,
                        serviceDiagnosticSettingsResource: patchResource));

                if (!this.IsRecording && patchResponse != null)
                {
                    Check(patchResponse);

                    Assert.Equal(actualResponse.Id, patchResponse.Id);
                    Assert.NotNull(patchResponse.Logs);
                    Assert.True(patchResource.Metrics[0].Enabled);
                }
            }
        }

        private static ServiceDiagnosticSettingsResource CreateDiagnosticSettingsParams()
        {
            return new ServiceDiagnosticSettingsResource
            {
                EventHubAuthorizationRuleId = null,
                StorageAccountId = null, // "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default-Storage-westus/providers/microsoft.storage/storageaccounts/salp1",
                ServiceBusRuleId = null, // "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default/providers/microsoft.servicebus/namespaces/serblp1/authorizationrules/ar1",
                WorkspaceId = null, // "providers/microsoft.storage",
                Logs = new List<LogSettings>(),
                Metrics = new List<MetricSettings>
                {
                    new MetricSettings
                    {
                        Enabled = false,
                        RetentionPolicy = new RetentionPolicy
                        {
                            Enabled = false,
                            Days = 0
                        },
                        TimeGrain = TimeSpan.FromMinutes(1)
                    }
                },
                Location = string.Empty
            };
        }

        private static ServiceDiagnosticSettingsResource CreateDiagnosticSettings()
        {
            return new ServiceDiagnosticSettingsResource
            {
                StorageAccountId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default-Storage-westus/providers/microsoft.storage/storageaccounts/salp1",
                //ServiceBusRuleId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default/providers/microsoft.servicebus/namespaces/serblp1/authorizationrules/ar1",
                WorkspaceId = "providers/microsoft.storage",
                Logs = new List<LogSettings>
                {
                    new LogSettings
                    {
                        RetentionPolicy = new RetentionPolicy
                        {
                            Days = 90,
                            Enabled = true
                        }
                    }
                },
                Metrics = new List<MetricSettings>
                {
                    new MetricSettings
                    {
                        Enabled = true,
                        RetentionPolicy = new RetentionPolicy
                        {
                            Enabled = true,
                            Days = 90
                        },
                        TimeGrain = TimeSpan.FromMinutes(1)
                    }
                }
            };
        }

        private static void Check(ServiceDiagnosticSettingsResource act)
        {
            Assert.False(string.IsNullOrWhiteSpace(act.Name));
            Assert.False(string.IsNullOrWhiteSpace(act.Id));
        }
    }
}
