// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;

namespace Azure.Communication.Sms.Tests.samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    public partial class Sample1_SmsClient
    {
        public SmsClient CreateSmsClient()
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

        public async Task SendingSMSMessage()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_Tests_SendAsync
            SmsSendResult sendResult = await smsClient.SendAsync(
                from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                to: "<to-phone-number>", // E.164 formatted recipient phone number
                message: "Hi");
            Console.WriteLine($"Sms id: {sendResult.MessageId}");
            #endregion Snippet:Azure_Communication_Sms_Tests_SendAsync
            Console.WriteLine($"Send Result Successful: {sendResult.Successful}");
        }

        public async Task SendingGroupSMSMessageWithOptions()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions
            Response<IEnumerable<SmsSendResult>> response = await smsClient.SendAsync(
                from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }, // E.164 formatted recipient phone numbers
                message: "Weekly Promotion!",
                options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                {
                    Tag = "marketing", // custom tags
                });
            IEnumerable<SmsSendResult> results = response.Value;
            foreach (SmsSendResult result in results)
            {
                Console.WriteLine($"Sms id: {result.MessageId}");
                Console.WriteLine($"Send Result Successful: {result.Successful}");
            }
            #endregion Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions
        }
    }
}
