// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Monitor.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;

namespace Monitor.Tests.Scenarios
{
    public class LogProfilesTests : TestBase
    {
        private const string ResourceId = "/subscriptions/07c0b09d-9f69-4e6e-8d05-f59f67299cb2/providers/Microsoft.Insights/logprofiles/default";
        private static string DefaultName = "default";
        private RecordedDelegatingHandler handler;

        public LogProfilesTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateGetListUpdateDeleteLogProfile()
        {
            // The second argument in the call to Start (missing in this case) controls the name of the output file.
            // By default the system will use the name of the current method as file for the output (when recording.)
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                LogProfileResource expResponse = CreateLogProfile();

                var insightsClient = GetMonitorManagementClient(context, handler);

                var parameters = CreateLogProfileParams();

                LogProfileResource actualResponse = insightsClient.LogProfiles.CreateOrUpdate(
                    logProfileName: DefaultName, 
                    parameters: parameters);

                if (!this.IsRecording)
                {
                    // TODO: Create a check and use it here
                    Assert.False(string.IsNullOrWhiteSpace(actualResponse.Id));
                    Assert.Equal(DefaultName, actualResponse.Name);
                    Assert.NotNull(actualResponse.Categories);
                    Assert.NotNull(actualResponse.Locations);
                    Assert.True(actualResponse.Categories.Count > 0);
                    Assert.True(actualResponse.Locations.Count > 0);

                    // AreEqual(expResponse, actualResponse);
                }

                LogProfileResource retrievedSingleResponse = insightsClient.LogProfiles.Get(logProfileName: DefaultName);

                if (!this.IsRecording)
                {
                    Utilities.AreEqual(actualResponse, retrievedSingleResponse);
                }

                IEnumerable<LogProfileResource> actualProfiles = insightsClient.LogProfiles.List();

                if (!this.IsRecording)
                {
                    var listActualProfiles = actualProfiles.ToList();
                    Assert.NotNull(listActualProfiles);
                    Assert.True(listActualProfiles.Count > 0);
                    var selected = listActualProfiles.FirstOrDefault(p => string.Equals(p.Id, retrievedSingleResponse.Id, StringComparison.OrdinalIgnoreCase));
                    Assert.NotNull(selected);
                    Utilities.AreEqual(retrievedSingleResponse, selected);
                }

                LogProfileResourcePatch patchResource = new LogProfileResourcePatch(
                    locations: retrievedSingleResponse.Locations,
                    categories: retrievedSingleResponse.Categories,
                    retentionPolicy: retrievedSingleResponse.RetentionPolicy,
                    tags: retrievedSingleResponse.Tags,
                    serviceBusRuleId: retrievedSingleResponse.ServiceBusRuleId,
                    storageAccountId: retrievedSingleResponse.StorageAccountId);

                // TODO: Fails with 'MethodNotAllowed'
                LogProfileResource updatedResponse = null;
                Assert.Throws<ErrorResponseException>(
                    () => updatedResponse = insightsClient.LogProfiles.Update(
                        logProfileName: DefaultName,
                        logProfilesResource: patchResource));

                if (!this.IsRecording && updatedResponse != null)
                {
                    Utilities.AreEqual(retrievedSingleResponse, updatedResponse);
                }

                LogProfileResource secondRetrievedactualResponse = insightsClient.LogProfiles.Get(logProfileName: DefaultName);

                if (!this.IsRecording && updatedResponse != null)
                {
                    Utilities.AreEqual(updatedResponse, secondRetrievedactualResponse);
                }

                AzureOperationResponse deleteResponse = insightsClient.LogProfiles.DeleteWithHttpMessagesAsync(logProfileName: DefaultName).Result;

                if (!this.IsRecording)
                {
                    Assert.Equal(HttpStatusCode.OK, deleteResponse.Response.StatusCode);
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
    }
}
