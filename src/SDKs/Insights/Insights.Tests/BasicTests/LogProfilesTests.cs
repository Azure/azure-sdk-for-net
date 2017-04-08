// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Insights.Tests.Helpers;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Xunit;

namespace Insights.Tests.BasicTests
{
    public class LogProfilesTests : TestBase
    {
        private const string ResourceId = "/subscriptions/0e44ac0a-5911-482b-9edd-3e67625d45b5/providers/microsoft.insights/logprofiles/default";

        private static string DefaultName = "default";

        [Fact]
        public void LogProfiles_CreateOrUpdateTest()
        {
            LogProfileResource expResponse = CreateLogProfile();
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetInsightsManagementClient(handler);

            var parameters = CreateLogProfileParams();

            LogProfileResource actualResponse = insightsClient.LogProfiles.CreateOrUpdate(logProfileName: DefaultName, parameters: parameters);

            AreEqual(expResponse, actualResponse);
        }

        [Fact]
        public void LogProfiles_DeleteTest()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Empty)
            };

            var handler = new RecordedDelegatingHandler(response);
            InsightsManagementClient customClient = this.GetInsightsManagementClient(handler);

            customClient.LogProfiles.Delete(logProfileName: DefaultName);
        }

        [Fact]
        public void LogProfiles_GetTest()
        {
            var expResponse = CreateLogProfile();
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetInsightsManagementClient(handler);

            LogProfileResource actualResponse = insightsClient.LogProfiles.Get(logProfileName: DefaultName);
            AreEqual(expResponse, actualResponse);
        }

        [Fact]
        public void LogProfiles_ListTest()
        {
            var logProfile = CreateLogProfile();
            var expResponse = new List<LogProfileResource>
            {
                logProfile
            };

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetInsightsManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetInsightsManagementClient(handler);

            IList<LogProfileResource> actualResponse = insightsClient.LogProfiles.List().ToList<LogProfileResource>();

            Assert.Equal(expResponse.Count, actualResponse.Count);
            AreEqual(expResponse[0], actualResponse[0]);
        }

        private static LogProfileResource CreateLogProfile()
        {
            return new LogProfileResource
            {
                StorageAccountId = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1",
                ServiceBusRuleId = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/sb1/authorizationrules/ar1",
                Categories = new List<string> { "Delete", "Write" },
                Locations = new List<string> { "global", "eastus" },
                RetentionPolicy = new RetentionPolicy
                {
                    Days = 4,
                    Enabled = true,
                }
            };
        }

        private static LogProfileResource CreateLogProfileParams()
        {
            return new LogProfileResource
            {
                StorageAccountId = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.storage/storageaccounts/sa1",
                ServiceBusRuleId = "/subscriptions/4d7e91d4-e930-4bb5-a93d-163aa358e0dc/resourceGroups/Default-Web-westus/providers/microsoft.servicebus/namespaces/sb1/authorizationrules/ar1",
                Categories = new List<string> { "Delete", "Write" },
                Locations = new List<string> { "global", "eastus" },
                RetentionPolicy = new RetentionPolicy
                {
                    Days = 4,
                    Enabled = true,
                },
                Location = ""
            };
        }

        private static void AreEqual(LogProfileResource exp, LogProfileResource act)
        {
            if (exp != null)
            {
                CompareListString(exp.Categories, act.Categories);
                CompareListString(exp.Locations, act.Locations);

                Assert.Equal(exp.RetentionPolicy.Enabled, act.RetentionPolicy.Enabled);
                Assert.Equal(exp.RetentionPolicy.Days, act.RetentionPolicy.Days);
                Assert.Equal(exp.ServiceBusRuleId, act.ServiceBusRuleId);
                Assert.Equal(exp.StorageAccountId, act.StorageAccountId);
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
                Assert.Equal(null, act);
            }

            Assert.False(act == null, "List can't be null");

            for (int i = 0; i < exp.Count; i++)
            {
                if (i >= act.Count)
                {
                    Assert.Equal(exp.Count, act.Count);
                }

                string cat1 = exp[i];
                string cat2 = act[i];
                Assert.Equal(cat1, cat2);
            }

            Assert.Equal(exp.Count, act.Count);
        }
    }
}
