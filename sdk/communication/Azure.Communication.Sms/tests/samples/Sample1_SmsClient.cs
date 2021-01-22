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
        [AsyncOnly]
        public async Task SendSingleAndGroupSmsAsync()
        {
            SmsClient smsClient = CreateSmsClient();

            // SendSmsOptions is an optional field. It can be used
            // to enable a delivery report to the Azure Event Grid
            // and to add custom tags in the request
            SendSmsOptions sendSmsOptions = new SendSmsOptions();
            sendSmsOptions.EnableDeliveryReport = true;
            sendSmsOptions.Tag = "<custom-tags>";

            #region Snippet:SendSms
            /// send an sms to a single recipient asynchronously
            SendSmsResult sendSmsResult = await smsClient.SendAsync("<leased-phone-number>", "<to-phone-number>", "<message-to-send>", sendSmsOptions);
            Console.WriteLine($" MessageId: {sendSmsResult.MessageId} Sent to: {sendSmsResult.To}");
            #endregion Snippet:SendSms

            #region Snippet:SendGroupSms
            /// send an sms to a multiple recipients
            AsyncPageable<SendSmsResult> allSendSmsResults = smsClient.SendAsync("<leased-phone-number>", new string[] { "<to-phone-number-1>", "<to-phone-number-2>", "<to-phone-number-3>" }, "<group-message-to-send>", sendSmsOptions);
            await foreach (SendSmsResult sendSmsResult1 in allSendSmsResults)
            {
                Console.WriteLine($" MessageId: {sendSmsResult1.MessageId} Sent to: {sendSmsResult1.To}");
            }
            #endregion Snippet:SendGroupSms

        }

        [Test]
        [SyncOnly]
        public void SendSingleAndGroupSms()
        {
            SmsClient smsClient = CreateSmsClient();

            // SendSmsOptions is an optional field. It can be used
            // to enable a delivery report to the Azure Event Grid
            // and to add custom tags in the sms request body
            SendSmsOptions sendSmsOptions = new SendSmsOptions();
            sendSmsOptions.EnableDeliveryReport = true;
            sendSmsOptions.Tag = "<custom-tags>";

            #region Snippet:SendSms
            /// Send an sms to a single recipient
            SendSmsResult sendSmsResult = smsClient.Send("<leased-phone-number>", "<to-phone-number>", "<message-to-send>", sendSmsOptions);
            Console.WriteLine("MessageId: " + sendSmsResult.MessageId);
            #endregion Snippet:SendSms

            #region Snippet:SendGroupSms
            /// send an sms to multiple recipients
            Pageable<SendSmsResult> allSendSmsResults = smsClient.Send("<leased-phone-number>", new string[] { "<to-phone-number-1>", "<to-phone-number-2>", "<to-phone-number-3>" }, "<group-message-to-send>", sendSmsOptions);
            foreach (SendSmsResult sendSmsResult1 in allSendSmsResults)
            {
                Console.WriteLine($" MessageId: {sendSmsResult1.MessageId} Sent to: {sendSmsResult1.To}");
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
