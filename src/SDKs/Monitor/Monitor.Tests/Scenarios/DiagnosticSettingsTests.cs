// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Monitor.Tests.Scenarios
{
    public class DiagnosticSettingsTests : TestBase
    {
        //private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";
        private const string ResourceUri = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Rac46PostSwapRG/providers/Microsoft.Web/sites/alertruleTest";
        private RecordedDelegatingHandler handler;

        public DiagnosticSettingsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        /// <summary>
        /// User needs several permissions before executing these commands. Otherwise it fails for some authorization issue.
        /// </summary>
        [Fact(Skip = "Needs to be recorded again.")]
        [Trait("Category", "Scenario")]
        public void CreateGetUpdateDiagnosticSetting()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var insightsClient = GetMonitorManagementClient(context, handler);

                var parameters = CreateDiagnosticSettings();

                DiagnosticSettingsResource response = insightsClient.DiagnosticSettings.CreateOrUpdate(
                    resourceUri: ResourceUri,
                    parameters: parameters,
                    name: "service");

                if (!this.IsRecording)
                {
                    Check(response, parameters);
                }

                DiagnosticSettingsResource actual = insightsClient.DiagnosticSettings.Get(resourceUri: ResourceUri, name: "service");

                if (!this.IsRecording)
                {
                    Check(actual, parameters);

                    Utilities.AreEqual(response, actual);
                }
            }
        }

        private static DiagnosticSettingsResource CreateDiagnosticSettings()
        {
            return new DiagnosticSettingsResource
            {
                EventHubAuthorizationRuleId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default/providers/microsoft.servicebus/namespaces/serblp1/authorizationrules/ar1",
                EventHubName = "myeventhub",
                StorageAccountId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default-Storage-westus/providers/microsoft.storage/storageaccounts/salp1",
                WorkspaceId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default/providers/microsoft.operationalinsights/workspaces/myworkspace",
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
        
        private static void Check(DiagnosticSettingsResource expected, DiagnosticSettingsResource actual)
        {
            Assert.Equal(expected.StorageAccountId, actual.StorageAccountId);
            Assert.Equal(expected.EventHubAuthorizationRuleId, actual.EventHubAuthorizationRuleId);
            Assert.Equal(expected.EventHubName, actual.EventHubName);
            Assert.Equal(expected.WorkspaceId, actual.WorkspaceId);
        }
    }
}

