// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Insights.Models;
using Insights.Tests.Helpers;
using NUnit.Framework;

namespace Azure.ResourceManager.Insights.Tests.BasicTests
{
    [AsyncOnly]
    public class LogProfilesTests : InsightsManagementClientMockedBase
    {
        public LogProfilesTests(bool isAsync)
            : base(isAsync)
        { }

        private const string ResourceId = "/subscriptions/0e44ac0a-5911-482b-9edd-3e67625d45b5/providers/microsoft.insights/logprofiles/default";

        private static string DefaultName = "default";

        [Test]
        public async Task LogProfiles_CreateOrUpdateTest()
        {
            LogProfileResource expResponse = CreateLogProfile();
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            mockResponse.SetContent(expResponse.ToJson());
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var parameters = CreateLogProfileParams();
            LogProfileResource actualResponse = (await insightsClient.LogProfiles.CreateOrUpdateAsync(logProfileName: DefaultName, parameters: parameters)).Value;
            Assert.AreEqual(expResponse, actualResponse);
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
            mockResponse.SetContent(expResponse.ToJson());
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            LogProfileResource actualResponse = await insightsClient.LogProfiles.GetAsync(logProfileName: DefaultName);
            Assert.AreEqual(expResponse, actualResponse);
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
            mockResponse.SetContent(string.Concat("{ \"value\":", expResponse.ToJson(), "}"));
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);

            IList<LogProfileResource> actualResponse = await insightsClient.LogProfiles.ListAsync().ToEnumerableAsync();

            Assert.AreEqual(expResponse.Count, actualResponse.Count);
            Assert.AreEqual(expResponse[0], actualResponse[0]);
        }

        private static LogProfileResource CreateLogProfile()
        {
            return new LogProfileResource(null, null, null, null, null, "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1", "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/sb1/authorizationrules/ar1", new List<string> { "global", "eastus" }, new List<string> { "Delete", "Write" },new RetentionPolicy(true, 4));
        }

        private static LogProfileResource CreateLogProfileParams()
        {
            return new LogProfileResource(null, null, null, null, null, "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1", "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/sb1/authorizationrules/ar1", new List<string> { "global", "eastus" }, new List<string> { "Delete", "Write" }, new RetentionPolicy(true, 4));
        }
    }
}
