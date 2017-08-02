// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Xunit;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Monitor.Tests.Scenarios
{
    public class ActionGroupsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Scenario")]
        public void CreateOrUpdateActionGroupTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName, "CreateOrUpdateActionGroupTest"))
            {
                ActionGroupResource expectedParameters = GetCreateOrUpdateActionGroupParameter();

                var handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
                var insightsClient = GetMonitorManagementClient(context, handler);

                var result = insightsClient.ActionGroups.CreateOrUpdate(
                    resourceGroupName: "rg1", 
                    actionGroupName: expectedParameters.Name, 
                    actionGroup: expectedParameters);

                AreEqual(expectedParameters, result);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void GetActionGroupTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName, "GetActionGroupTest"))
            {
                var expectedActionGroup = GetCreateOrUpdateActionGroupParameter();

                var handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
                var insightsClient = GetMonitorManagementClient(context, handler);

                var actionGroup = insightsClient.ActionGroups.Get(
                    resourceGroupName: "rg1",
                    actionGroupName: "name1");

                AreEqual(expectedActionGroup, actionGroup);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListActionGroupsBySusbscriptionTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                List<ActionGroupResource> expectedParameters = GetActionGroups();

                var handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
                var insightsClient = GetMonitorManagementClient(context, handler);

                var actualGroups = insightsClient.ActionGroups.ListBySubscriptionId();

                AreEqual(expectedParameters.ToList(), actualGroups.ToList());
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListActionGroupsByResourceGroupTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                List<ActionGroupResource> expectedParameters = GetActionGroups();

                var handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
                var insightsClient = GetMonitorManagementClient(context, handler);

                var actualGroups = insightsClient.ActionGroups.ListByResourceGroup(resourceGroupName: "rg1");

                AreEqual(expectedParameters.ToList(), actualGroups.ToList());
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void DeleteActionGroupTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
                var insightsClient = GetMonitorManagementClient(context, handler);

                AzureOperationResponse response = insightsClient.ActionGroups.DeleteWithHttpMessagesAsync(
                    resourceGroupName: "rg1",
                    actionGroupName: "name1").Result;

                Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
            }
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void EnableActionGroupTest()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
                var insightsClient = GetMonitorManagementClient(context, handler);

                AzureOperationResponse response = insightsClient.ActionGroups.EnableReceiverWithHttpMessagesAsync(
                    resourceGroupName: "rg1",
                    actionGroupName: "name1",
                    receiverName: "name1").Result;

                Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
            }
        }

        private static List<ActionGroupResource> GetActionGroups()
        {
            return new List<ActionGroupResource>
            {
                GetCreateOrUpdateActionGroupParameter(),
                GetCreateOrUpdateActionGroupParameter(),
                GetCreateOrUpdateActionGroupParameter()
            };
        }

        private static void AreEqual(ActionGroupResource exp, ActionGroupResource act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.Id, act.Id);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Location, act.Location);
                Assert.Equal(exp.GroupShortName, act.GroupShortName);
                Assert.Equal(exp.Enabled, act.Enabled);
                AreEqual(exp.Tags, act.Tags);
                AreEqual(exp.EmailReceivers, act.EmailReceivers);
                AreEqual(exp.SmsReceivers, act.SmsReceivers);
                AreEqual(exp.WebhookReceivers, act.WebhookReceivers);
            }
        }

        private static void AreEqual(IList<EmailReceiver> exp, IList<EmailReceiver> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(IList<ActionGroupResource> exp, IList<ActionGroupResource> act)
        {
            if (exp != null)
            {
                Assert.NotNull(act);
                Assert.Equal(exp.Count, act.Count);
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
            else
            {
                Assert.Null(act);
            }
        }

        private static void AreEqual(IList<SmsReceiver> exp, IList<SmsReceiver> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(IList<WebhookReceiver> exp, IList<WebhookReceiver> act)
        {
            if (exp != null)
            {
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
            }
        }

        private static void AreEqual(EmailReceiver exp, EmailReceiver act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.EmailAddress, act.EmailAddress);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Status, act.Status);
            }
        }

        private static void AreEqual(SmsReceiver exp, SmsReceiver act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.PhoneNumber, act.PhoneNumber);
                Assert.Equal(exp.Name, act.Name);
                Assert.Equal(exp.Status, act.Status);
            }
        }

        private static void AreEqual(WebhookReceiver exp, WebhookReceiver act)
        {
            if (exp != null)
            {
                Assert.Equal(exp.ServiceUri, act.ServiceUri);
                Assert.Equal(exp.Name, act.Name);
            }
        }

        private static ActionGroupResource GetCreateOrUpdateActionGroupParameter(
            string name = "name1", 
            List<EmailReceiver> emailReceivers = null, 
            List<SmsReceiver> smsReceivers = null,
            List<WebhookReceiver> webhookReceivers = null)
        {
            // Name and id won't be serialized since they are readonly
            return new ActionGroupResource(
                id: "long name",
                name: name,
                location: "location",
                groupShortName: name,
                enabled: true,
                tags: new Dictionary<string, string>()
                {
                    {"key1", "val1"}
                },
                emailReceivers: emailReceivers,
                smsReceivers: smsReceivers,
                webhookReceivers: webhookReceivers
            );
        }
    }
}
