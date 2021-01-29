// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Identity;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests.samples
{
    /// <summary>
    /// Samples to send sms
    /// </summary>
    public partial class Sample1_SmsClient
    {
        [Test]
        [SyncOnly]
        public void SendSms()
        {
            SmsClient smsClient = CreateSmsClient();

            #region Snippet:SendSms
            /// Send an sms
            SmsSendResult sendSmsResult = smsClient.Send(
                from: "<leased-phone-number>",
                to: "<to-phone-number>",
                message: "<message-to-send>");

            Console.WriteLine("MessageId: " + sendSmsResult.MessageId);
            #endregion Snippet:SendSms
        }

        [Test]
        [SyncOnly]
        public void SendSingleAndGroupSms()
        {
            SmsClient smsClient = CreateSmsClient();

            #region Snippet:SendSms
            /// Send an sms to a single recipient
            SmsSendResult sendSmsResult = smsClient.Send(
                from: "<leased-phone-number>",
                to: "<to-phone-number>",
                message: "<message-to-send>",
                options: new SmsSendOptions // OPTIONAL
                    {
                    EnableDeliveryReport = true,
                    Tag = "<custom-tags>",
                });

            Console.WriteLine("MessageId: " + sendSmsResult.MessageId);
            #endregion Snippet:SendSms

            #region Snippet:SendGroupSms
            /// send an sms to multiple recipients
            Pageable<SmsSendResult> results = smsClient.Send(
                from: "<leased-phone-number>",
                to: new[] { "<to-phone-number-1>", "<to-phone-number-2>", "<to-phone-number-3>" },
                message: "<group-message-to-send>",
                options: new SmsSendOptions // OPTIONAL
                    {
                    EnableDeliveryReport = true,
                    Tag = "<custom-tags>",
                });
            foreach (SmsSendResult result in results)
            {
                Console.WriteLine($" MessageId: {result.MessageId} Sent to: {result.To}");
            }
            #endregion Snippet:SendGroupSms
        }

        [Test]
        [AsyncOnly]
        public async Task SendSingleAndGroupSmsAsync()
        {
            SmsClient smsClient = CreateSmsClient();

            // SendSmsOptions is an optional field. It can be used
            // to enable a delivery report to the Azure Event Grid
            // and to add custom tags in the request
            SmsSendOptions sendSmsOptions = new SmsSendOptions
            {
                EnableDeliveryReport = true,
                Tag = "<custom-tags>",
            };

            #region Snippet:SendSms
            /// send an sms to a single recipient asynchronously
            SmsSendResult sendSmsResult = await smsClient.SendAsync(
                from: "<leased-phone-number>",
                to: "<to-phone-number>",
                message: "<message-to-send>",
                sendSmsOptions); //OPTIONAL
            Console.WriteLine($" MessageId: {sendSmsResult.MessageId} Sent to: {sendSmsResult.To}");
            #endregion Snippet:SendSms

            #region Snippet:SendGroupSms
            /// send an sms to a multiple recipients asynchronously
            AsyncPageable<SmsSendResult> results = smsClient.SendAsync(
                from: "<leased-phone-number>",
                to: new[] { "<to-phone-number-1>", "<to-phone-number-2>", "<to-phone-number-3>" },
                message: "<group-message-to-send>",
                sendSmsOptions); // OPTIONAL
            await foreach (SmsSendResult result in results)
            {
                Console.WriteLine($" MessageId: {result.MessageId} Sent to: {result.To}");
            }
            #endregion Snippet:SendGroupSms
        }

        private SmsClient CreateSmsClient()
        {
            #region Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
            string connectionString = "YOUR_CONNECTION_STRING"; // Find your Communication Services resource in the Azure portal
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
