// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Monitor.Tests.Scenarios
{
    public class ActionGroupsTests : TestBase
    {
        private const string ResourceGroupName = "Default-ActivityLogAlerts";
        private const string ActionGroupName = "andygroup-donotuse";
        private RecordedDelegatingHandler handler;

        public ActionGroupsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact(Skip="Needs to be recorded again.")]
        [Trait("Category", "Scenario")]
        public void CreateEnableListDeleteActionGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var insightsClient = GetMonitorManagementClient(context, handler);
                this.VerifyExistenceOrCreateResourceGroup(resourceGroupName: ResourceGroupName, location: "Global");

                ActionGroupResource expectedParameters = GetCreateOrUpdateActionGroupParameter();
                ActionGroupResource result = insightsClient.ActionGroups.CreateOrUpdate(
                    resourceGroupName: ResourceGroupName, 
                    actionGroupName: ActionGroupName, 
                    actionGroup: expectedParameters);

                if (!this.IsRecording)
                {
                    // TODO: Create a check with these commands
                    Assert.False(string.IsNullOrWhiteSpace(result.Id));
                    Assert.Equal(ActionGroupName, result.Name);
                    Assert.NotNull(result.EmailReceivers);
                    Assert.NotNull(result.SmsReceivers);

                    // AreEqual(expectedParameters, result);
                }

                ActionGroupResource singleActionGroup = insightsClient.ActionGroups.Get(
                    resourceGroupName: ResourceGroupName,
                    actionGroupName: ActionGroupName);

                if (!this.IsRecording)
                {
                    Utilities.AreEqual(result, singleActionGroup);
                }

                IEnumerable<ActionGroupResource> actualGroups = insightsClient.ActionGroups.ListBySubscriptionId();

                if (!this.IsRecording)
                {
                    var listActualGroups = actualGroups.ToList();
                    Assert.NotNull(listActualGroups);
                    Assert.True(listActualGroups.Count > 0);

                    // Utilities.AreEqual(new List<ActionGroupResource> { expectedParameters }, listActualGroups);
                }

                actualGroups = insightsClient.ActionGroups.ListByResourceGroup(resourceGroupName: ResourceGroupName);

                if (!this.IsRecording)
                {
                    var listActualGroups = actualGroups.ToList();
                    Assert.NotNull(listActualGroups);
                    Assert.True(listActualGroups.Count > 0);

                    // Utilities.AreEqual(new List<ActionGroupResource> { expectedParameters }, actualGroups.ToList());
                }

                // TODO: it responds 'already enabled' (Conflict: 409)
                AzureOperationResponse response = insightsClient.ActionGroups.EnableReceiverWithHttpMessagesAsync(
                    resourceGroupName: ResourceGroupName,
                            actionGroupName: ActionGroupName,
                            receiverName: "emailreceiver").Result;

                if (!this.IsRecording)
                {
                    Assert.Equal(HttpStatusCode.Conflict, response.Response.StatusCode);
                }

                response = insightsClient.ActionGroups.DeleteWithHttpMessagesAsync(
                    resourceGroupName: ResourceGroupName,
                    actionGroupName: ActionGroupName).Result;

                if (!this.IsRecording)
                {
                    Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
                }
            }
        }

        private static ActionGroupResource GetCreateOrUpdateActionGroupParameter(
            string name = ActionGroupName, 
            List<EmailReceiver> emailReceivers = null, 
            List<SmsReceiver> smsReceivers = null,
            List<WebhookReceiver> webhookReceivers = null)
        {
            // Name and id won't be serialized since they are readonly
            return new ActionGroupResource(
                name: name,
                location: "Global",
                groupShortName: "andygroup",
                enabled: false,
                tags: new Dictionary<string, string>(),
                emailReceivers: emailReceivers ?? new List<EmailReceiver>
                    {
                        new EmailReceiver(name: "emailreceiver", emailAddress: "andyshen@microsoft.com", status: ReceiverStatus.Disabled)
                    },
                smsReceivers: smsReceivers ?? new List<SmsReceiver>
                    {
                        new SmsReceiver(name: "smsreceiver", countryCode: "1", phoneNumber: "7817386781", status: ReceiverStatus.Enabled)

                    },
                webhookReceivers: webhookReceivers
            );
        }
    }
}
