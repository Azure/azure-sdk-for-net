// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class LogProfilesTests : InsightsManagementClientMockedBase
    {
        public LogProfilesTests(bool isAsync)
            : base(isAsync)
        { }

        private static string DefaultName = "default";

        [Test]
        public async Task LogProfiles_CreateOrUpdateTest()
        {
            LogProfileResource expResponse = CreateLogProfile();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"
                    {
                        'id': null,
                        'name': null,
                        'type': null,
                        'location': null,
                        'tags': {},
                        'properties':
                            {
                                'storageAccountId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1',
                                'serviceBusRuleId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/sb1/authorizationrules/ar1',
                                'locations': [
                                    'global',
                                    'eastus'
                                ],
                                'categories': [
                                    'Delete',
                                    'Write'
                                ],
                                'retentionPolicy': {
                                    'enabled': true,
                                    'days': 4
                                }
                            }
                    }
                    ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var parameters = CreateLogProfileParams();
            LogProfileResource actualResponse = (await insightsClient.LogProfiles.CreateOrUpdateAsync(logProfileName: DefaultName, parameters: parameters)).Value;
            AreEqual(expResponse, actualResponse);
        }

        [Test]
        public async Task LogProfiles_DeleteTest()
        {
            LogProfileResource expResponse = CreateLogProfile();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);

            await insightsClient.LogProfiles.DeleteAsync(logProfileName: DefaultName);
        }

        [Test]
        public async Task LogProfiles_GetTest()
        {
            var expResponse = CreateLogProfile();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"
                    {
                        'id': null,
                        'name': null,
                        'type': null,
                        'location': null,
                        'tags': {},
                        'properties':
                            {
                                'storageAccountId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1',
                                'serviceBusRuleId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/sb1/authorizationrules/ar1',
                                'locations': [
                                    'global',
                                    'eastus'
                                ],
                                'categories': [
                                    'Delete',
                                    'Write'
                                ],
                                'retentionPolicy': {
                                    'enabled': true,
                                    'days': 4
                                }
                            }
                    }
                    ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            LogProfileResource actualResponse = await insightsClient.LogProfiles.GetAsync(logProfileName: DefaultName);
            AreEqual(expResponse, actualResponse);
        }

        [Test]
        public async Task LogProfiles_ListTest()
        {
            var logProfile = CreateLogProfile();
            var expResponse = new List<LogProfileResource>
            {
                logProfile
            };
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"
                    {
                'value':[
                        {
                        'id': null,
                        'name': null,
                        'type': null,
                        'location': null,
                        'tags': {},
                        'properties':
                            {
                                'storageAccountId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1',
                                'serviceBusRuleId': '/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/sb1/authorizationrules/ar1',
                                'locations': [
                                    'global',
                                    'eastus'
                                ],
                                'categories': [
                                    'Delete',
                                    'Write'
                                ],
                                'retentionPolicy': {
                                    'enabled': true,
                                    'days': 4
                                }
                            }
                        }]
                    }
                    ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);

            IList<LogProfileResource> actualResponse = await insightsClient.LogProfiles.ListAsync().ToEnumerableAsync();

            Assert.AreEqual(expResponse.Count, actualResponse.Count);
            AreEqual(expResponse[0], actualResponse[0]);
        }

        private static void AreEqual(LogProfileResource exp, LogProfileResource act)
        {
            if (exp != null)
            {
                CompareListString(exp.Categories, act.Categories);
                CompareListString(exp.Locations, act.Locations);

                Assert.AreEqual(exp.RetentionPolicy.Enabled, act.RetentionPolicy.Enabled);
                Assert.AreEqual(exp.RetentionPolicy.Days, act.RetentionPolicy.Days);
                Assert.AreEqual(exp.ServiceBusRuleId, act.ServiceBusRuleId);
                Assert.AreEqual(exp.StorageAccountId, act.StorageAccountId);
            }
        }

        private static void CompareListString(IList<string> exp, IList<string> act)
        {
            if (exp == act)
            {
                return;
            }

            if (exp == null)
            {
                Assert.Null(act);
            }

            Assert.False(act == null, "List can't be null");

            for (int i = 0; i < exp.Count; i++)
            {
                if (i >= act.Count)
                {
                    Assert.AreEqual(exp.Count, act.Count);
                }

                string cat1 = exp[i];
                string cat2 = act[i];
                Assert.AreEqual(cat1, cat2);
            }

            Assert.AreEqual(exp.Count, act.Count);
        }

        private static LogProfileResource CreateLogProfile()
        {
            return new LogProfileResource(null, null, null, null, new Dictionary<string, string>(), "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1", "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/sb1/authorizationrules/ar1", new List<string> { "global", "eastus" }, new List<string> { "Delete", "Write" }, new RetentionPolicy(true, 4));
        }

        private static LogProfileResource CreateLogProfileParams()
        {
            return new LogProfileResource(null, null, null, null, new Dictionary<string, string>(), "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1", "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/sb1/authorizationrules/ar1", new List<string> { "global", "eastus" }, new List<string> { "Delete", "Write" }, new RetentionPolicy(true, 4));
        }
    }
}
