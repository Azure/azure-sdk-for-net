// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class ServiceDiagnosticSettingsTests : InsightsManagementClientMockedBase
    {
        public ServiceDiagnosticSettingsTests(bool isAsync)
            : base(isAsync)
        { }

        private const string ResourceUri = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.web/serverFarms/DefaultServerFarm";
        private const string DiagSetName = "DiagSetName";
        [Test]
        public async Task LogProfiles_PutTest()
        {
            var expResponse = CreateDiagnosticSettings();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"
        {
                'id': null,
            'name': 'DiagSetName',
            'type': null,
            'properties': {
                    'storageAccountId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1',
                'serviceBusRuleId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/ns1/authorizationRules/authrule',
                'eventHubAuthorizationRuleId': null,
                'eventHubName': null,
                'metrics': [
                    {
                        'timeGrain': 'PT1M',
                        'category': null,
                        'enabled': true,
                        'retentionPolicy': {
                            'enabled': true,
                            'days': 90
                        }
                }
                ],
                'logs': [
                    {
                        'category': null,
                        'enabled': true,
                        'retentionPolicy': {
                            'enabled': true,
                            'days': 90
                        }
                    }
                ],
                'workspaceId': 'wsId',
                'logAnalyticsDestinationType': null
            }
        }
".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var parameters = CreateDiagnosticSettingsParams();
            DiagnosticSettingsResource response = await insightsClient.DiagnosticSettings.CreateOrUpdateAsync(ResourceUri, DiagSetName, parameters);
            AreEqual(expResponse, response);
        }

        [Test]
        public async Task LogProfiles_GetTest()
        {
            var expResponse = CreateDiagnosticSettings();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"
        {
                'id': null,
            'name': 'DiagSetName',
            'type': null,
            'properties': {
                    'storageAccountId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1',
                'serviceBusRuleId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/ns1/authorizationRules/authrule',
                'eventHubAuthorizationRuleId': null,
                'eventHubName': null,
                'metrics': [
                    {
                        'timeGrain': 'PT1M',
                        'category': null,
                        'enabled': true,
                        'retentionPolicy': {
                            'enabled': true,
                            'days': 90
                        }
                }
                ],
                'logs': [
                    {
                        'category': null,
                        'enabled': true,
                        'retentionPolicy': {
                            'enabled': true,
                            'days': 90
                        }
                    }
                ],
                'workspaceId': 'wsId',
                'logAnalyticsDestinationType': null
            }
        }
".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            DiagnosticSettingsResource actualResponse = await insightsClient.DiagnosticSettings.GetAsync(ResourceUri, DiagSetName);
            AreEqual(expResponse, actualResponse);
        }
        [Test]
        public async Task DiagnosticSettingDeleteAsync()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.DiagnosticSettings.DeleteAsync(ResourceUri, DiagSetName);
        }

        [Test]
        public async Task DiagnosticSettingListAsync()
        {
            var expResponse = new List<DiagnosticSettingsResource>() { CreateDiagnosticSettings() };
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"
        { 
'value':[{
                'id': null,
            'name': 'DiagSetName',
            'type': null,
            'properties': {
                    'storageAccountId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1',
                'serviceBusRuleId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/ns1/authorizationRules/authrule',
                'eventHubAuthorizationRuleId': null,
                'eventHubName': null,
                'metrics': [
                    {
                        'timeGrain': 'PT1M',
                        'category': null,
                        'enabled': true,
                        'retentionPolicy': {
                            'enabled': true,
                            'days': 90
                        }
                }
                ],
                'logs': [
                    {
                        'category': null,
                        'enabled': true,
                        'retentionPolicy': {
                            'enabled': true,
                            'days': 90
                        }
                    }
                ],
                'workspaceId': 'wsId',
                'logAnalyticsDestinationType': null
            }
}]
        }
".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var actualResponse = (await insightsClient.DiagnosticSettings.ListAsync(ResourceUri)).Value.Value;
            AreEqual(expResponse, actualResponse);
        }

        private void AreEqual(IList<DiagnosticSettingsResource> exp, IReadOnlyList<DiagnosticSettingsResource> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static DiagnosticSettingsResource CreateDiagnosticSettingsParams()
        {
            return new DiagnosticSettingsResource(null, DiagSetName, null, "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1", "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/ns1/authorizationRules/authrule", null, null,
                    new List<MetricSettings>
                    {
                        new MetricSettings(true)
                        {
                            TimeGrain =TimeSpan.FromMinutes(1),
                            RetentionPolicy= new RetentionPolicy(days:90,enabled:true)
                        }
                    },
                    new List<LogSettings>
                    {
                        new LogSettings(true)
                        {
                            RetentionPolicy = new RetentionPolicy(days:90,enabled:true)
                        }
                    }, "wsId", null
                );
        }

        private static DiagnosticSettingsResource CreateDiagnosticSettings()
        {
            return new DiagnosticSettingsResource(null, DiagSetName, null, "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1", "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/ns1/authorizationRules/authrule", null, null,
                new List<MetricSettings>
                {
                    new MetricSettings(true)
                    {
                        TimeGrain =TimeSpan.FromMinutes(1),
                        RetentionPolicy= new RetentionPolicy(days:90,enabled:true)
                    }
                },
                new List<LogSettings>
                {
                    new LogSettings(true)
                    {
                        RetentionPolicy=new RetentionPolicy(days:90,enabled:true)
                    }
                }, "wsId", null
                );
        }

        private static void AreEqual(DiagnosticSettingsResource exp, DiagnosticSettingsResource act)
        {
            if (exp == act)
            {
                return;
            }

            if (exp == null)
            {
                Assert.Null(act);
            }

            Assert.False(act == null, "Actual value can't be null");

            CompareLists(exp.Logs, act.Logs);
            CompareLists(exp.Metrics, act.Metrics);

            Assert.AreEqual(exp.StorageAccountId, act.StorageAccountId);
            Assert.AreEqual(exp.WorkspaceId, act.WorkspaceId);
            Assert.AreEqual(exp.ServiceBusRuleId, act.ServiceBusRuleId);
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
            Assert.AreEqual(exp.Enabled, act.Enabled);
            Assert.AreEqual(exp.Category, act.Category);
            Compare(exp.RetentionPolicy, act.RetentionPolicy);
        }

        private static void Compare(RetentionPolicy exp, RetentionPolicy act)
        {
            Assert.AreEqual(exp.Enabled, act.Enabled);
            Assert.AreEqual(exp.Days, act.Days);
        }

        private static void CompareLists<T>(IList<T> exp, IList<T> act)
        {
            if (exp == act)
            {
                return;
            }

            if (exp == null)
            {
                Assert.Null(act);
            }

            Assert.False(act == null, "Actual value can't be null");

            for (int i = 0; i < exp.Count; i++)
            {
                if (i >= act.Count)
                {
                    Assert.AreEqual(exp.Count, act.Count);
                }

                T cat1 = exp[i];
                T cat2 = act[i];
                Compare<T>(cat1, cat2);
            }

            Assert.AreEqual(exp.Count, act.Count);
        }
    }
}
