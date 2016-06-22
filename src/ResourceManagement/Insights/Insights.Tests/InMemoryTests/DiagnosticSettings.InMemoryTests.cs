//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Insights.Tests.Helpers;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;

namespace Insights.Tests.InMemoryTests
{
    public class DiagnosticSettingsInMemoryTests : TestBase
    {
        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";

        [Fact]
        public void LogProfiles_PutTest()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Empty),
            };

            var handler = new RecordedDelegatingHandler(response);
            InsightsManagementClient customClient = this.GetInsightsManagementClient(handler);

            var parameters = new ServiceDiagnosticSettingsPutParameters
            {
                Properties = CreateDiagnosticSettings()
            };

            customClient.ServiceDiagnosticSettingsOperations.Put(ResourceUri, parameters);
            var actualResponse = JsonExtensions.FromJson<ServiceDiagnosticSettingsPutParameters>(handler.Request);
            AreEqual(parameters.Properties, actualResponse.Properties);
        }

        [Fact]
        public void LogProfiles_GetTest()
        {
            var diagnosticSettings = CreateDiagnosticSettings();
            var expectedResponse = new ServiceDiagnosticSettingsGetResponse()
            {
                Name = "service",
                Properties = diagnosticSettings,
                RequestId = "request id",
                StatusCode = HttpStatusCode.OK
            };

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedResponse.ToJson()),
            };

            var handler = new RecordedDelegatingHandler(response);
            InsightsManagementClient customClient = this.GetInsightsManagementClient(handler);
            ServiceDiagnosticSettingsGetResponse actualResponse = customClient.ServiceDiagnosticSettingsOperations.Get(ResourceUri);
            AreEqual(expectedResponse.Properties, actualResponse.Properties);
        }

        private static ServiceDiagnosticSettings CreateDiagnosticSettings()
        {
            return new ServiceDiagnosticSettings
            {
                StorageAccountId = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1",
                ServiceBusRuleId = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/ns1/authorizationRules/authrule",
                StorageAccountName = "sa1",
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

        private static void AreEqual(ServiceDiagnosticSettings exp, ServiceDiagnosticSettings act)
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
            Assert.Equal(exp.StorageAccountName, act.StorageAccountName);
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
