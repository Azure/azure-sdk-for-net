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
    public class DiagnosticSettingsCategoryTest : InsightsManagementClientMockedBase
    {
        public DiagnosticSettingsCategoryTest(bool isAsync)
            : base(isAsync)
        { }

        [Test]
        public async Task GetDiagnosticSettingsCategoryTest()
        {
            var ExpectDiagnosticSettingsCategoryResource = new DiagnosticSettingsCategoryResource("ID1", "Name1", "type1", CategoryType.Logs);
            var content = @"
{

    'id': 'ID1',
    'name': 'Name1',
    'type': 'type1',
    'properties':
                {
                    'categoryType': 'Logs'
                }

}
".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.DiagnosticSettingsCategory.GetAsync("resourceUri", "name1")).Value;
            AreEqual(ExpectDiagnosticSettingsCategoryResource, result);
        }

        private void AreEqual(DiagnosticSettingsCategoryResource exp, DiagnosticSettingsCategoryResource act)
        {
            Assert.AreEqual(exp.Id,act.Id);
            Assert.AreEqual(exp.Name, act.Name);
            Assert.AreEqual(exp.CategoryType.Value, act.CategoryType.Value);
        }

        [Test]
        public async Task ListDiagnosticSettingsCategoryTest()
        {
            var ExpectDiagnosticSettingsCategoryResource = new List<DiagnosticSettingsCategoryResource>() { new DiagnosticSettingsCategoryResource("ID1", "Name1", "type1", CategoryType.Logs) };
            var content = @"
{
    'value':[
{

    'id': 'ID1',
    'name': 'Name1',
    'type': 'type1',
    'properties':
                {
                    'categoryType': 'Logs'
                }

}
]
}

".Replace("'", "\"");
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.DiagnosticSettingsCategory.ListAsync("resourceUri")).Value.Value;
            AreEqual(ExpectDiagnosticSettingsCategoryResource, result);
        }

        private void AreEqual(IReadOnlyList<DiagnosticSettingsCategoryResource> exp, IReadOnlyList<DiagnosticSettingsCategoryResource> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }
    }
}
