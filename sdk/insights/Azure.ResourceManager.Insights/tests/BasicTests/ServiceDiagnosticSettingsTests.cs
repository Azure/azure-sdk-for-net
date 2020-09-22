// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using Insights.Tests.Helpers;
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
            mockResponse.SetContent(string.Concat("{ \"value\":", expResponse.ToJson(), "}"));
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var parameters = CreateDiagnosticSettingsParams();

            DiagnosticSettingsResource response = await insightsClient.DiagnosticSettings.CreateOrUpdateAsync(ResourceUri, DiagSetName, parameters);
            Assert.AreEqual(expResponse, response);
        }

        [Test]
        public async Task LogProfiles_GetTest()
        {
            var expResponse = CreateDiagnosticSettings();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(string.Concat("{ \"value\":", expResponse.ToJson(), "}"));
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            DiagnosticSettingsResource actualResponse = await insightsClient.DiagnosticSettings.GetAsync(ResourceUri,DiagSetName);
            Assert.AreEqual(expResponse, actualResponse);
        }

        private static DiagnosticSettingsResource CreateDiagnosticSettingsParams()
        {
            return new DiagnosticSettingsResource(null, DiagSetName, null,"/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1", "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/ns1/authorizationRules/authrule",null,null,
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
                    },"wsId",null
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
    }
}
