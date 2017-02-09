// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Insights.Tests.Helpers;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Xunit;

namespace Insights.Tests.BasicTests
{
    public class ServiceDiagnosticSettingsTests : TestBase
    {
        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";

        [Fact]
        public void LogProfiles_PutTest()
        {
            var expResponse = CreateDiagnosticSettings();
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetInsightsManagementClient(handler);

            var parameters = CreateDiagnosticSettingsParams();

            ServiceDiagnosticSettingsResource response = insightsClient.ServiceDiagnosticSettings.CreateOrUpdate(resourceUri: ResourceUri, parameters: parameters);
            AreEqual(expResponse, response);
        }

        [Fact]
        public void LogProfiles_GetTest()
        {
            var expResponse = CreateDiagnosticSettings();
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetInsightsManagementClient(handler);

            ServiceDiagnosticSettingsResource actualResponse = insightsClient.ServiceDiagnosticSettings.Get(resourceUri: ResourceUri);
            AreEqual(expResponse, actualResponse);
        }

        private static ServiceDiagnosticSettingsResource CreateDiagnosticSettingsParams()
        {
            return new ServiceDiagnosticSettingsResource
            {
                StorageAccountId = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1",
                ServiceBusRuleId = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/ns1/authorizationRules/authrule",
                WorkspaceId = "wsId",
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
                StorageAccountId = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1",
                ServiceBusRuleId = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/ns1/authorizationRules/authrule",
                WorkspaceId = "wsId",
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
