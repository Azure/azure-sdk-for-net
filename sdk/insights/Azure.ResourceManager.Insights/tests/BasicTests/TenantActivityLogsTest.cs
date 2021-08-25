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
    public class TenantActivityLogsTest : InsightsManagementClientMockedBase
    {
        public TenantActivityLogsTest(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        public async Task TenantActivityLogsListTest()
        {
            var EventDataList = new List<EventData>{
                                        new EventData(
                                            new SenderAuthorization("action","role","scope"),
                                            new Dictionary<string,string>(){ {"tag","tag" } },
                                            "caller","description","Id","eventDataId","correlationId",
                                            new LocalizableString("value","localizedValue"),
                                            new LocalizableString("categoryvalue"),new HttpRequestInfo("clientRequestId","clientIpAddress","method","url"),EventLevel.Warning,"resourcegroupname",
                                            new LocalizableString("resourceProvide"),"resourceId",
                                            new LocalizableString("resourceType"),"operationId",
                                            new LocalizableString("operationName"),
                                            new Dictionary<string,string>(),
                                            new LocalizableString("status"),
                                            new LocalizableString("substatus"),
                                            DateTime.Parse("2014-05-20T13:14:20.7882792Z"),DateTime.Parse("2014-05-20T13:14:20.7882792Z"),"subscriptionId","tenantId"
                                            ) };
            var content = @"
                    {
                        'value':[
                            {
                                'authorization': {
                                    'action': 'action',
                                    'role': 'role',
                                    'scope': 'scope'
                                },
                                'claims': {
                                    'tag': 'tag'
                                },
                                'caller': 'caller',
                                'description': 'description',
                                'id': 'Id',
                                'eventDataId': 'eventDataId',
                                'correlationId': 'correlationId',
                                'eventName': {
                                    'value': 'value',
                                    'localizedValue': 'localizedValue'
                                },
                                'category': {
                                    'value': 'categoryvalue',
                                    'localizedValue': null
                                },
                                'httpRequest': {
                                'clientRequestId': 'clientRequestId',
                                'clientIpAddress': 'clientIpAddress',
                                'method': 'method',
                                'uri': 'url'
                                },
                                'level': 'Warning',
                                'resourceGroupName': 'resourcegroupname',
                                'resourceProviderName': {
                                    'value': 'resourceProvide',
                                    'localizedValue': null
                                },
                                'resourceId': 'resourceId',
                                'resourceType': {
                                    'value': 'resourceType',
                                    'localizedValue': null
                                },
                                'operationId': 'operationId',
                                'operationName': {
                                    'value': 'operationName',
                                    'localizedValue': null
                                },
                                'properties': {},
                                'status': {
                                    'value': 'status',
                                    'localizedValue': null
                                },
                                'subStatus': {
                                    'value': 'substatus',
                                    'localizedValue': null
                                },
                                'eventTimestamp': '2014-05-20T13:14:20.7882792+00:00',
                                'submissionTimestamp': '2014-05-20T13:14:20.7882792+00:00',
                                'subscriptionId': 'subscriptionId',
                                'tenantId': 'tenantId'
                            }
                        ]
}".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.TenantActivityLogs.ListAsync().ToEnumerableAsync();
            AreEqual(EventDataList, result);
        }

        private void AreEqual(List<EventData> exp, List<EventData> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        private void AreEqual(EventData exp, EventData act)
        {
            Assert.AreEqual(exp.Caller, act.Caller);
            Assert.AreEqual(exp.CorrelationId, act.CorrelationId);
            Assert.AreEqual(exp.Description, act.Description);
            Assert.AreEqual(exp.EventDataId, act.EventDataId);
            Assert.AreEqual(exp.EventTimestamp, act.EventTimestamp);
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.OperationId, act.OperationId);
            Assert.AreEqual(exp.ResourceGroupName, act.ResourceGroupName);
            Assert.AreEqual(exp.ResourceId, act.ResourceId);
            Assert.AreEqual(exp.SubmissionTimestamp, act.SubmissionTimestamp);
            Assert.AreEqual(exp.SubscriptionId, act.SubscriptionId);
            Assert.AreEqual(exp.TenantId, act.TenantId);
            Assert.AreEqual(exp.Level.ToString(), act.Level.ToString());
            AreEqual(exp.Authorization, act.Authorization);
            AreEqual(exp.Category, act.Category);
            AreEqual(exp.EventName, act.EventName);
            AreEqual(exp.OperationName, act.OperationName);
            AreEqual(exp.ResourceProviderName, act.ResourceProviderName);
            AreEqual(exp.ResourceType, act.ResourceType);
            AreEqual(exp.Status, act.Status);
            AreEqual(exp.SubStatus, act.SubStatus);

            AreEqual(exp.Claims, act.Claims);
            AreEqual(exp.Properties, act.Properties);

            AreEqual(exp.HttpRequest, act.HttpRequest);
        }

        private void AreEqual(SenderAuthorization exp, SenderAuthorization act)
        {
            Assert.AreEqual(exp.Action, act.Action);
            Assert.AreEqual(exp.Role, act.Role);
            Assert.AreEqual(exp.Scope, act.Scope);
        }

        protected static void AreEqual(IReadOnlyDictionary<string, string> exp, IReadOnlyDictionary<string, string> act)
        {
            if (exp != null)
            {
                foreach (var key in exp.Keys)
                {
                    Assert.AreEqual(exp[key], act[key]);
                }
            }
        }

        private void AreEqual(HttpRequestInfo exp, HttpRequestInfo act)
        {
            Assert.AreEqual(exp.ClientIpAddress, act.ClientIpAddress);
            Assert.AreEqual(exp.ClientRequestId, act.ClientRequestId);
            Assert.AreEqual(exp.Method, act.Method);
            Assert.AreEqual(exp.Uri, act.Uri);
        }
    }
}
