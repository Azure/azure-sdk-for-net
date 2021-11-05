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
    public class MetricNamespacesTest : InsightsManagementClientMockedBase
    {
        public MetricNamespacesTest(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        public async Task MetricAlertsStatusListTest()
        {
            var MetricNamespaceList = new List<MetricNamespace>()
                                            { new MetricNamespace("Id1","Type1","Name1",new MetricNamespaceName("MetricNamespaceNameValue1")) };
            var content = @"
{
    'value':[
        {
        'id': 'Id1',
        'type': 'Type1',
        'name': 'Name1',
        'properties': {
                'metricNamespaceName': 'MetricNamespaceNameValue1'
                    }
        }
    ]
}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.MetricNamespaces.ListAsync("resourceUri").ToEnumerableAsync();
            AreEqual(MetricNamespaceList, result);
        }

        private void AreEqual(List<MetricNamespace> exp, List<MetricNamespace> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        private void AreEqual(MetricNamespace exp, MetricNamespace act)
        {
            Assert.AreEqual(exp.Id, act.Id);
            Assert.AreEqual(exp.Name,act.Name);
            AreEqual(exp.Properties, act.Properties);
            Assert.AreEqual(exp.Type, act.Type);
        }

        private void AreEqual(MetricNamespaceName exp, MetricNamespaceName act)
        {
            Assert.AreEqual(exp.MetricNamespaceNameValue,act.MetricNamespaceNameValue);
        }
    }
}
