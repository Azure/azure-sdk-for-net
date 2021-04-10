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
    public class ActionGroupsTests : InsightsManagementClientMockedBase
    {
        public ActionGroupsTests(bool isAsync)
            : base(isAsync)
        { }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [Test]
        public async Task ActionGroupsCreateOrUpdateTest()
        {
            var actionGroupResource = new ActionGroupResource("ONE","Name",null,"West Us",
                                                              new Dictionary<string,string>(),null,true,
                                                              new List<EmailReceiver>() { new EmailReceiver("Email", "Email@AZ", true,ReceiverStatus.Enabled) },
                                                              new List<SmsReceiver>() { new SmsReceiver("SmsName","countryCode","phoneNum",ReceiverStatus.Enabled) },
                                                              new List<WebhookReceiver>(),
                                                              new List<ItsmReceiver>(),
                                                              new List<AzureAppPushReceiver>(),
                                                              new List<AutomationRunbookReceiver>(),
                                                              new List<VoiceReceiver>(),
                                                              new List<LogicAppReceiver>(),
                                                              new List<AzureFunctionReceiver>(),
                                                              new List<ArmRoleReceiver>());
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                            'id': 'ONE',
                            'name': 'Name',
                            'type': null,
                            'location': 'West Us',
                            'tags': { },
                            'properties':
                                {
                                    'groupShortName': null,
                                    'enabled': true,
                                    'emailReceivers': [
                                        {
                                            'name': 'Email',
                                            'emailAddress': 'Email@AZ',
                                            'useCommonAlertSchema': true,
                                            'status': 'Enabled'
                                        }
                                    ],
                                    'smsReceivers': [
                                        {
                                            'name': 'SmsName',
                                            'countryCode': 'countryCode',
                                            'phoneNumber': 'phoneNum',
                                            'status': 'Enabled'
                                        }
                                ],
                                    'webhookReceivers': [],
                                    'itsmReceivers': [],
                                    'azureAppPushReceivers': [],
                                    'automationRunbookReceivers': [],
                                    'voiceReceivers': [],
                                    'logicAppReceivers': [],
                                    'azureFunctionReceivers': [],
                                    'armRoleReceivers': []
                                }
                            
                        }
            ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.ActionGroups.CreateOrUpdateAsync("rg1","actGroup1", actionGroupResource)).Value;
            AreEqual(actionGroupResource, result);
        }
        private void AreEqual(ActionGroupResource exp, ActionGroupResource act)
        {
            if (exp != null)
            {
                Assert.AreEqual(exp.Location, act.Location);
                Assert.AreEqual(exp.Name, act.Name);
                Assert.AreEqual(exp.Enabled, act.Enabled);
                AreEqual(exp.EmailReceivers, act.EmailReceivers);
                AreEqual(exp.SmsReceivers,act.SmsReceivers);
            }
        }

        private void AreEqual(IList<EmailReceiver> exp, IList<EmailReceiver> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }

        private void AreEqual(EmailReceiver exp, EmailReceiver act)
        {
            Assert.AreEqual(exp.EmailAddress, act.EmailAddress);
            Assert.AreEqual(exp.Name, act.Name);
            Assert.AreEqual(exp.Status, act.Status);
            Assert.AreEqual(exp.UseCommonAlertSchema, act.UseCommonAlertSchema);
        }

        private void AreEqual(IList<SmsReceiver> exp, IList<SmsReceiver> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }
        private void AreEqual(SmsReceiver exp, SmsReceiver act)
        {
            Assert.AreEqual(exp.CountryCode, act.CountryCode);
            Assert.AreEqual(exp.Name, act.Name);
            Assert.AreEqual(exp.Status, act.Status);
            Assert.AreEqual(exp.PhoneNumber, act.PhoneNumber);
        }

        [Test]
        public async Task ActionGroupsDeleteTest()
        {
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            await insightsClient.ActionGroups.DeleteAsync("rg1", "actGroup1");
        }

        [Test]
        public async Task ActionGroupsGetTest()
        {
            var actionGroupResource = new ActionGroupResource("ONE", "Name", null, "West Us",
                                                  new Dictionary<string, string>(), null, true,
                                                  new List<EmailReceiver>() { new EmailReceiver("Email", "Email@AZ", true, ReceiverStatus.Enabled) },
                                                  new List<SmsReceiver>() { new SmsReceiver("SmsName", "countryCode", "phoneNum", ReceiverStatus.Enabled) },
                                                  new List<WebhookReceiver>(),
                                                  new List<ItsmReceiver>(),
                                                  new List<AzureAppPushReceiver>(),
                                                  new List<AutomationRunbookReceiver>(),
                                                  new List<VoiceReceiver>(),
                                                  new List<LogicAppReceiver>(),
                                                  new List<AzureFunctionReceiver>(),
                                                  new List<ArmRoleReceiver>());
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                            'id': 'ONE',
                            'name': 'Name',
                            'type': null,
                            'location': 'West Us',
                            'tags': { },
                            'properties':
                                {
                                    'groupShortName': null,
                                    'enabled': true,
                                    'emailReceivers': [
                                        {
                                            'name': 'Email',
                                            'emailAddress': 'Email@AZ',
                                            'useCommonAlertSchema': true,
                                            'status': 'Enabled'
                                        }
                                    ],
                                    'smsReceivers': [
                                        {
                                            'name': 'SmsName',
                                            'countryCode': 'countryCode',
                                            'phoneNumber': 'phoneNum',
                                            'status': 'Enabled'
                                        }
                                ],
                                    'webhookReceivers': [],
                                    'itsmReceivers': [],
                                    'azureAppPushReceivers': [],
                                    'automationRunbookReceivers': [],
                                    'voiceReceivers': [],
                                    'logicAppReceivers': [],
                                    'azureFunctionReceivers': [],
                                    'armRoleReceivers': []
                                }
                            
                        }
            ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = (await insightsClient.ActionGroups.GetAsync("rg1", "actGroup1")).Value;
            AreEqual(actionGroupResource,result);
        }

        [Test]
        public async Task ActionGroupsListByResourceGroupTest()
        {
            List< ActionGroupResource> exceptionResourcesList = new List<ActionGroupResource>(){ new ActionGroupResource("ONE", "Name", null, "West Us",
                                                  new Dictionary<string, string>(), null, true,
                                                  new List<EmailReceiver>() { new EmailReceiver("Email", "Email@AZ", true, ReceiverStatus.Enabled) },
                                                  new List<SmsReceiver>() { new SmsReceiver("SmsName", "countryCode", "phoneNum", ReceiverStatus.Enabled) },
                                                  new List<WebhookReceiver>(),
                                                  new List<ItsmReceiver>(),
                                                  new List<AzureAppPushReceiver>(),
                                                  new List<AutomationRunbookReceiver>(),
                                                  new List<VoiceReceiver>(),
                                                  new List<LogicAppReceiver>(),
                                                  new List<AzureFunctionReceiver>(),
                                                  new List<ArmRoleReceiver>())};
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                            'value':[{
                            'id': 'ONE',
                            'name': 'Name',
                            'type': null,
                            'location': 'West Us',
                            'tags': { },
                            'properties':
                                {
                                    'groupShortName': null,
                                    'enabled': true,
                                    'emailReceivers': [
                                        {
                                            'name': 'Email',
                                            'emailAddress': 'Email@AZ',
                                            'useCommonAlertSchema': true,
                                            'status': 'Enabled'
                                        }
                                    ],
                                    'smsReceivers': [
                                        {
                                            'name': 'SmsName',
                                            'countryCode': 'countryCode',
                                            'phoneNumber': 'phoneNum',
                                            'status': 'Enabled'
                                        }
                                ],
                                    'webhookReceivers': [],
                                    'itsmReceivers': [],
                                    'azureAppPushReceivers': [],
                                    'automationRunbookReceivers': [],
                                    'voiceReceivers': [],
                                    'logicAppReceivers': [],
                                    'azureFunctionReceivers': [],
                                    'armRoleReceivers': []
                                }
                            }]
                        }
            ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.ActionGroups.ListByResourceGroupAsync("rg1").ToEnumerableAsync();
            AreEqual(exceptionResourcesList, result);
        }

        [Test]
        public async Task ActionGroupsListBySubscriptionIdTest()
        {
            List<ActionGroupResource> exceptionResourcesList = new List<ActionGroupResource>(){ new ActionGroupResource("ONE", "Name", null, "West Us",
                                                  new Dictionary<string, string>(), null, true,
                                                  new List<EmailReceiver>() { new EmailReceiver("Email", "Email@AZ", true, ReceiverStatus.Enabled) },
                                                  new List<SmsReceiver>() { new SmsReceiver("SmsName", "countryCode", "phoneNum", ReceiverStatus.Enabled) },
                                                  new List<WebhookReceiver>(),
                                                  new List<ItsmReceiver>(),
                                                  new List<AzureAppPushReceiver>(),
                                                  new List<AutomationRunbookReceiver>(),
                                                  new List<VoiceReceiver>(),
                                                  new List<LogicAppReceiver>(),
                                                  new List<AzureFunctionReceiver>(),
                                                  new List<ArmRoleReceiver>())};
            var mockResponse = new MockResponse((int)HttpStatusCode.OK);
            var content = @"{
                            'value':[{
                            'id': 'ONE',
                            'name': 'Name',
                            'type': null,
                            'location': 'West Us',
                            'tags': { },
                            'properties':
                                {
                                    'groupShortName': null,
                                    'enabled': true,
                                    'emailReceivers': [
                                        {
                                            'name': 'Email',
                                            'emailAddress': 'Email@AZ',
                                            'useCommonAlertSchema': true,
                                            'status': 'Enabled'
                                        }
                                    ],
                                    'smsReceivers': [
                                        {
                                            'name': 'SmsName',
                                            'countryCode': 'countryCode',
                                            'phoneNumber': 'phoneNum',
                                            'status': 'Enabled'
                                        }
                                ],
                                    'webhookReceivers': [],
                                    'itsmReceivers': [],
                                    'azureAppPushReceivers': [],
                                    'automationRunbookReceivers': [],
                                    'voiceReceivers': [],
                                    'logicAppReceivers': [],
                                    'azureFunctionReceivers': [],
                                    'armRoleReceivers': []
                                }
                            }]
                        }
            ".Replace("'", "\"");
            mockResponse.SetContent(content);
            var mockTransport = new MockTransport(mockResponse);
            var insightsClient = GetInsightsManagementClient(mockTransport);
            var result = await insightsClient.ActionGroups.ListBySubscriptionIdAsync().ToEnumerableAsync();
            AreEqual(exceptionResourcesList, result);
        }

        private void AreEqual(List<ActionGroupResource> exp, IList<ActionGroupResource> act)
        {
            for (int i = 0; i < exp.Count; i++)
            {
                AreEqual(exp[i], act[i]);
            }
        }
    }
}
