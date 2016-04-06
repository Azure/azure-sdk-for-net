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
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using Insights.Tests.Helpers;
using Microsoft.Azure.Management.Insights;
using Microsoft.Azure.Management.Insights.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Xunit;

namespace Insights.Tests.InMemoryTests
{
    public class LogProfilesInMemoryTests : TestBase
    {
        private const string ResourceId = "/subscriptions/0e44ac0a-5911-482b-9edd-3e67625d45b5/providers/microsoft.insights/logprofiles/default";

        private static string DefaultName = "default";

        [Fact]
        public void LogProfiles_CreateOrUpdateTest()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Empty)
            };

            var handler = new RecordedDelegatingHandler(response);
            InsightsManagementClient customClient = this.GetInsightsManagementClient(handler);

            var parameters = new LogProfileCreatOrUpdateParameters
            {
                Properties = CreateLogProfile()
            };

            customClient.LogProfilesOperations.CreateOrUpdate(DefaultName, parameters);

            var actualRequest = JsonExtensions.FromJson<LogProfileCreatOrUpdateParameters>(handler.Request);
            AreEqual(parameters.Properties, actualRequest.Properties);
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

            customClient.LogProfilesOperations.Delete(DefaultName);
        }

        [Fact]
        public void LogProfiles_GetTest()
        {
            var logProfile = CreateLogProfile();
            var expectedResponse = new LogProfileGetResponse()
            {
                Id = ResourceId,
                Name = DefaultName,
                Properties = logProfile,
                RequestId = "request id",
                StatusCode = HttpStatusCode.OK
            };

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedResponse.ToJson()),
            };

            var handler = new RecordedDelegatingHandler(response);
            InsightsManagementClient customClient = this.GetInsightsManagementClient(handler);

            LogProfileGetResponse actualResponse = customClient.LogProfilesOperations.Get(DefaultName);
            AreEqual(expectedResponse.Properties, actualResponse.Properties);
        }

        [Fact]
        public void LogProfiles_ListTest()
        {
            var logProfile = CreateLogProfile();

            var expectedResponse = new LogProfileListResponse
            {
                LogProfileCollection = new LogProfileCollection
                {
                    Value = new List<LogProfileResource>
                    {
                        new LogProfileResource()
                        {
                            Id = ResourceId,
                            Name = DefaultName,
                            Properties = logProfile
                        }
                    }
                }
            };

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(expectedResponse.LogProfileCollection.ToJson()),
            };

            var handler = new RecordedDelegatingHandler(response);
            InsightsManagementClient customClient = this.GetInsightsManagementClient(handler);

            LogProfileListResponse actualResponse = customClient.LogProfilesOperations.List();

            Assert.Equal(expectedResponse.LogProfileCollection.Value.Count, actualResponse.LogProfileCollection.Value.Count);
            AreEqual(
                expectedResponse.LogProfileCollection.Value[0].Properties,
                actualResponse.LogProfileCollection.Value[0].Properties);
        }

        private static LogProfile CreateLogProfile()
        {
            return new LogProfile
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

        private static void AreEqual(LogProfile exp, LogProfile act)
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
