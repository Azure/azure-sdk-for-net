// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Monitor.Tests.Scenarios
{
    public class LogProfilesTests : TestBase
    {
        private const string ResourceId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/providers/microsoft.insights/logprofiles/default";
        private static string DefaultName = "default";
        private RecordedDelegatingHandler handler;

        public LogProfilesTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateOrUpdateLogProfileTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                LogProfileResource expResponse = CreateLogProfile();

                var insightsClient = GetMonitorManagementClient(context, handler);

                var parameters = CreateLogProfileParams();

                LogProfileResource actualResponse = insightsClient.LogProfiles.CreateOrUpdate(
                    logProfileName: DefaultName, 
                    parameters: parameters);

                if (!this.IsRecording)
                {
                    AreEqual(expResponse, actualResponse);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void DeleteLogProfileTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var insightsClient = GetMonitorManagementClient(context, handler);

                insightsClient.LogProfiles.Delete(logProfileName: DefaultName);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetLogProfileTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var expResponse = CreateLogProfile();
                var insightsClient = GetMonitorManagementClient(context, handler);

                LogProfileResource actualResponse = insightsClient.LogProfiles.Get(logProfileName: DefaultName);

                if (!this.IsRecording)
                {
                    AreEqual(expResponse, actualResponse);
                }
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListLogProfilesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var logProfile = CreateLogProfile();
                var expResponse = new List<LogProfileResource>
                {
                    logProfile
                };

                var insightsClient = GetMonitorManagementClient(context, handler);

                IList<LogProfileResource> actualResponse = insightsClient.LogProfiles.List().ToList<LogProfileResource>();

                if (!this.IsRecording)
                {
                    Assert.Equal(expResponse.Count, actualResponse.Count);
                    AreEqual(expResponse[0], actualResponse[0]);
                }
            }
        }

        [Fact(Skip = "Fails with 'MethodNotAllowed'")]
        [Trait("Category", "Scenario")]
        public void UpdateLogProfilesTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                LogProfileResource resource = CreateLogProfile();
                var insightsClient = GetMonitorManagementClient(context, handler);

                LogProfileResourcePatch patchResource = new LogProfileResourcePatch(
                    locations: resource.Locations,
                    categories: resource.Categories,
                    retentionPolicy: resource.RetentionPolicy,
                    tags: resource.Tags,
                    serviceBusRuleId: resource.ServiceBusRuleId,
                    storageAccountId: resource.StorageAccountId);

                LogProfileResource actualResponse = insightsClient.LogProfiles.Update(
                    logProfileName: DefaultName,
                    logProfilesResource: patchResource);

                if (!this.IsRecording)
                {
                    AreEqual(resource, actualResponse);
                }
            }
        }

        private static LogProfileResource CreateLogProfile()
        {
            return new LogProfileResource
            {
                StorageAccountId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default-Storage-westus/providers/microsoft.storage/storageaccounts/salp1",
                //ServiceBusRuleId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default/providers/microsoft.servicebus/namespaces/serblp1/authorizationrules/ar1",
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
                StorageAccountId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default-Storage-westus/providers/microsoft.storage/storageaccounts/salp1",
                //ServiceBusRuleId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/resourceGroups/Default/providers/microsoft.servicebus/namespaces/serblp1/authorizationrules/ar1",
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
