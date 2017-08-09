// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor.Management;
using Microsoft.Azure.Management.Monitor.Management.Models;
using Xunit;
using Microsoft.Rest.Azure;

namespace Monitor.Tests.BasicTests
{
    public class ActionGroupsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Mock")]
        public void CreateOrUpdateActionGroupTest()
        {
            ActionGroupResource expectedParameters = GetCreateOrUpdateActionGroupParameter();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expectedParameters.Name + "\",\"id\":\"" + expectedParameters.Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var result = insightsClient.ActionGroups.CreateOrUpdate(resourceGroupName: "rg1", actionGroupName: expectedParameters.Name, actionGroup: expectedParameters);

            AreEqual(expectedParameters, result);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void GetActionGroupTest()
        {
            var expectedActionGroup = GetCreateOrUpdateActionGroupParameter(name: "name4");

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedActionGroup, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expectedActionGroup.Name + "\",\"id\":\"" + expectedActionGroup.Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actionGroup = insightsClient.ActionGroups.Get(
                resourceGroupName: "rg1",
                actionGroupName: "name4");

            AreEqual(expectedActionGroup, actionGroup);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListActionGroupsBySusbscriptionTest()
        {
            List<ActionGroupResource> expectedParameters = GetActionGroups();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expectedParameters[0].Name + "\",\"id\":\"" + expectedParameters[0].Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actualGroups = insightsClient.ActionGroups.ListBySubscriptionId();

            AreEqual(expectedParameters.ToList(), actualGroups.ToList());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void ListActionGroupsByResourceGroupTest()
        {
            List<ActionGroupResource> expectedParameters = GetActionGroups();

            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);
            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expectedParameters, insightsClient.SerializationSettings);
            serializedObject = serializedObject.Replace("{", "{\"name\":\"" + expectedParameters[0].Name + "\",\"id\":\"" + expectedParameters[0].Id + "\",");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(string.Concat("{ \"value\":", serializedObject, "}"))
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            var actualGroups = insightsClient.ActionGroups.ListByResourceGroup(resourceGroupName: "rg1");

            AreEqual(expectedParameters.ToList(), actualGroups.ToList());
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void DeleteActionGroupTest()
        {
            var handler = new RecordedDelegatingHandler();
            var monitorManagementClient = GetMonitorManagementClient(handler);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

            handler = new RecordedDelegatingHandler(expectedResponse);
            monitorManagementClient = GetMonitorManagementClient(handler);

            AzureOperationResponse response = monitorManagementClient.ActionGroups.DeleteWithHttpMessagesAsync(
                resourceGroupName: " rg1",
                actionGroupName: "name1").Result;

            Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
        }

        [Fact]
        [Trait("Category", "Mock")]
        public void EnableActionGroupTest()
        {
            var handler = new RecordedDelegatingHandler();
            var monitorManagementClient = GetMonitorManagementClient(handler);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);

            handler = new RecordedDelegatingHandler(expectedResponse);
            monitorManagementClient = GetMonitorManagementClient(handler);

            AzureOperationResponse response = monitorManagementClient.ActionGroups.EnableReceiverWithHttpMessagesAsync(
                resourceGroupName: " rg1", 
                actionGroupName: "name1",
                receiverName: "receiverName1").Result;

            Assert.Equal(HttpStatusCode.OK, response.Response.StatusCode);
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
                Utilities.AreEqual(exp.Tags, act.Tags);
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
                for (int i = 0; i < exp.Count; i++)
                {
                    AreEqual(exp[i], act[i]);
                }
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
