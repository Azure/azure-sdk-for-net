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


        [Fact(Skip = "Failing for some authorization issue")]
        [Trait("Category", "Scenario")]
        public void CreateOrUpdateServiceDiagnosticSettingTest()
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
                    AreEqual(expResponse, response);
                }
            }
        }

        [Fact(Skip = "Failing for some authorization issue")]
        [Trait("Category", "Scenario")]
        public void UpdateServiceDiagnosticSettingTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resource = CreateDiagnosticSettings();
                var insightsClient = GetMonitorManagementClient(context, handler);

                ServiceDiagnosticSettingsResourcePatch patchResource = new ServiceDiagnosticSettingsResourcePatch(
                    tags: resource.Tags,
                    storageAccountId: resource.StorageAccountId,
                    serviceBusRuleId: resource.ServiceBusRuleId,
                    eventHubAuthorizationRuleId: resource.EventHubAuthorizationRuleId,
                    metrics: resource.Metrics,
                    logs: resource.Logs,
                    workspaceId: resource.WorkspaceId
                );

                ServiceDiagnosticSettingsResource response = insightsClient.ServiceDiagnosticSettings.Update(
                    resourceUri: ResourceUri,
                    serviceDiagnosticSettingsResource: patchResource);

                if (!this.IsRecording)
                {
                    AreEqual(resource, response);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetServiceDiagnosticSettingTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var expResponse = CreateDiagnosticSettings();
                var insightsClient = GetMonitorManagementClient(context, handler);

                ServiceDiagnosticSettingsResource actualResponse = insightsClient.ServiceDiagnosticSettings.Get(resourceUri: ResourceUri);

                if (!this.IsRecording)
                {
                    Check(actualResponse);
                }
            }
        }

        private static ServiceDiagnosticSettingsResource CreateDiagnosticSettingsParams()
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
                },
                Location = ""
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
            if (act == null)
            {
                return;
            }

            Assert.False(string.IsNullOrWhiteSpace(act.Name));
            Assert.False(string.IsNullOrWhiteSpace(act.Id));
        }

        private static void AreEqual(ServiceDiagnosticSettingsResource exp, ServiceDiagnosticSettingsResource act)
        {
            if (exp == act)
            {
                return;
            }

            if (exp == null)
            {
                Assert.Equal(null, act);
            }

            Assert.False(act == null, "Actual value can't be null");

            CompareLists(exp.Logs, act.Logs);
            CompareLists(exp.Metrics, act.Metrics);

            Assert.Equal(exp.StorageAccountId, act.StorageAccountId);
            Assert.Equal(exp.WorkspaceId, act.WorkspaceId);
            Assert.Equal(exp.ServiceBusRuleId, act.ServiceBusRuleId);
        }

        private static void Compare<T>(T exp, T act)
        {
            Type t = typeof(T);
            if (t == typeof(LogSettings))
            {
                Compare(exp as LogSettings, act as LogSettings);
            }
            else if (t == typeof(LogSettings))
            {
                Compare(exp as MetricSettings, act as MetricSettings);
            }
        }

        private static void Compare(LogSettings exp, LogSettings act)
        {
            Assert.Equal(exp.Enabled, act.Enabled);
            Assert.Equal(exp.Category, act.Category);
            Compare(exp.RetentionPolicy, act.RetentionPolicy);
        }

        private static void Compare(RetentionPolicy exp, RetentionPolicy act)
        {
            Assert.Equal(exp.Enabled, act.Enabled);
            Assert.Equal(exp.Days, act.Days);
        }

        private static void CompareLists<T>(IList<T> exp, IList<T> act)
        {
            if (exp == act)
            {
                return;
            }

            if (exp == null)
            {
                Assert.Equal(null, act);
            }

            Assert.False(act == null, "Actual value can't be null");

            for (int i = 0; i < exp.Count; i++)
            {
                if (i >= act.Count)
                {
                    Assert.Equal(exp.Count, act.Count);
                }

                T cat1 = exp[i];
                T cat2 = act[i];
                Compare<T>(cat1, cat2);
            }

            Assert.Equal(exp.Count, act.Count);
        }
    }
}
