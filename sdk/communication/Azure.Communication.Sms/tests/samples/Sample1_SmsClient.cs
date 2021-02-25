// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Collections;

namespace Azure.Communication.Sms.Tests.samples
{
    /// <summary>
    /// Samples to send sms
    /// </summary>
    public partial class Sample1_SmsClient : SamplesBase<SmsClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void SendSms()
        {
            SmsClient smsClient = CreateSmsClient();

            #region Snippet:Azure_Communication_SmsClient_Send_Troubleshooting
            try
            {
                #region Snippet:Azure_Communication_SmsClient_Send
                SmsSendResult result = smsClient.Send(
                    //@@ from: "+18001230000", // Phone number acquired on your Azure Communication resource
                    //@@ to: "+18005670000", // recipient's phone-number
                    /*@@*/ from: TestEnvironment.PhoneNumber,
                    /*@@*/ to: TestEnvironment.PhoneNumber,
                    message: "Hello"); // message-to-send
                Console.WriteLine($" MessageId: {result.MessageId} Sent to: {result.To}");
                #endregion Snippet:Azure_Communication_SmsClient_Send
                /*@@*/ Assert.IsFalse(string.IsNullOrWhiteSpace(result.MessageId));
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion Snippet:Azure_Communication_SmsClient_Send_Troubleshooting
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        [SyncOnly]
        public void SendSingleAndGroupSms()
        {
            SmsClient smsClient = CreateSmsClient();

            #region Snippet:Azure_Communication_SmsClient_Send_SingleSmsWithOptions
            /// Send an sms to a single recipient
            SmsSendResult sendSmsResult = smsClient.Send(
                //@@ from: "+18001230000", // Phone number acquired on your Azure Communication resource
                //@@ to: "+18005670000",
                /*@@*/ from: TestEnvironment.PhoneNumber,
                /*@@*/ to: TestEnvironment.PhoneNumber,
                message: "Hello 👋",
                options: new SmsSendOptions(true /*EnableDeliveryReport*/) // OPTIONAL
                {
                    Tag = "customer-service", // custom tags
                });
            Console.WriteLine($" MessageId: {sendSmsResult.MessageId} Sent to: {sendSmsResult.To}");
            /*@@*/ Assert.IsFalse(string.IsNullOrWhiteSpace(sendSmsResult.MessageId));
            #endregion Snippet:Azure_Communication_SmsClient_Send_SingleSmsWithOptions

            #region Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions
            /// send an sms to multiple recipients
            Response<IEnumerable<SmsSendResult>> results = smsClient.Send(
                //@@ from: "+18001230000", // Phone number acquired on your Azure Communication resource
                //@@ to: new[] { "+18005670000", "+18005670001", "+18005670002" },
                /*@@*/ from: TestEnvironment.PhoneNumber,
                /*@@*/ to: new[] { TestEnvironment.PhoneNumber, TestEnvironment.PhoneNumber },
                message: "Holiday Promotion",
                options: new SmsSendOptions(true /*EnableDeliveryReport*/) // OPTIONAL
                {
                    Tag = "marketing", // custom tags
                });
            foreach (SmsSendResult result in results.Value)
            {
                Console.WriteLine($" MessageId: {result.MessageId} Sent to: {result.To}");
                /*@@*/ Assert.IsFalse(string.IsNullOrWhiteSpace(result.MessageId));
            }
            #endregion Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions
        }

        [Test]
        [AsyncOnly]
        public async Task SendSingleAndGroupSmsAsync()
        {
            SmsClient smsClient = CreateSmsClient();

            #region Snippet:Azure_Communication_SmsClient_SendAsync_SingleSmsWithOptions
            /// send an sms to a single recipient asynchronously
            SmsSendResult sendSmsResult = await smsClient.SendAsync(
                from: TestEnvironment.PhoneNumber, // leased-phone-number
                to: TestEnvironment.PhoneNumber,
                message: "Hello 👋",
                options: new SmsSendOptions(true /*EnableDeliveryReport*/) // OPTIONAL
                {
                    Tag = "customer-service", // custom tags
                });
            Console.WriteLine($" MessageId: {sendSmsResult.MessageId} Sent to: {sendSmsResult.To}");
            /*@@*/ Assert.IsFalse(string.IsNullOrWhiteSpace(sendSmsResult.MessageId));
            #endregion Snippet:Azure_Communication_SmsClient_SendAsync_SingleSmsWithOptions

            #region Snippet:Azure_Communication_SmsClient_SendAsync_GroupSmsWithOptions
            /// send an sms to a multiple recipients asynchronously
            Response<IEnumerable<SmsSendResult>> results = await smsClient.SendAsync(
                from: TestEnvironment.PhoneNumber, // leased-phone-number
                to: new[] { TestEnvironment.PhoneNumber, TestEnvironment.PhoneNumber },
                message: "Holiday Promotion",
                options: new SmsSendOptions(true /*EnableDeliveryReport*/) // OPTIONAL
                {
                    Tag = "marketing", // custom tags
                });
            foreach (SmsSendResult result in results.Value)
            {
                Console.WriteLine($" MessageId: {result.MessageId} Sent to: {result.To}");
                /*@@*/ Assert.IsFalse(string.IsNullOrWhiteSpace(result.MessageId));
            }
            #endregion Snippet:Azure_Communication_SmsClient_SendAsync_GroupSmsWithOptions
        }

        private SmsClient CreateSmsClient()
        {
            #region Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
            //@@ string connectionString = YOUR_CONNECTION_STRING; // Find your Communication Services resource in the Azure portal
            /*@@*/ string connectionString = TestEnvironment.ConnectionString;
            SmsClient client = new SmsClient(connectionString);
            #endregion Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
            return client;
        }
        public SmsClient CreateSmsClientWithToken()
        {
            #region Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
            string endpoint = "<endpoint_url>";
            TokenCredential tokenCredential = new DefaultAzureCredential();
            SmsClient client = new SmsClient(new Uri(endpoint), tokenCredential);
            #endregion Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
            return client;
        }
    }
}
