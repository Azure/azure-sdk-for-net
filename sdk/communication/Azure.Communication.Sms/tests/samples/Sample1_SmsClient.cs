// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests.samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    public partial class Sample1_SmsClient : SmsClientLiveTestBase
    {
        public Sample1_SmsClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [AsyncOnly]
        public async Task SendingSMSMessageAsync()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_Tests_SendAsync
            SmsSendResult sendResult = await smsClient.SendAsync(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: "<to-phone-number>", // E.164 formatted recipient phone number
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: TestEnvironment.ToPhoneNumber,
                message: "Hi");
            Console.WriteLine($"Sms id: {sendResult.MessageId}");
            #endregion Snippet:Azure_Communication_Sms_Tests_SendAsync
            Console.WriteLine($"Send Result Successful: {sendResult.Successful}");
        }

        [Test]
        [AsyncOnly]
        public async Task SendingGroupSMSMessageWithOptionsAsync()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptionsAsync
            var response = await smsClient.SendAsync(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }, // E.164 formatted recipient phone numbers
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber },
                message: "Weekly Promotion!",
                options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                {
                    Tag = "marketing", // custom tags
                    DeliveryReportTimeoutInSeconds = 90
                });
            foreach (SmsSendResult result in response.Value)
            {
                Console.WriteLine($"Sms id: {result.MessageId}");
                Console.WriteLine($"Send Result Successful: {result.Successful}");
            }
            #endregion Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptionsAsync
        }

        [Test]
        [SyncOnly]
        public void SendingSMSMessage()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_Tests_Send
            SmsSendResult sendResult = smsClient.Send(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: "<to-phone-number>", // E.164 formatted recipient phone number
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: TestEnvironment.ToPhoneNumber,
                message: "Hi");
            Console.WriteLine($"Sms id: {sendResult.MessageId}");
            #endregion Snippet:Azure_Communication_Sms_Tests_SendAsync
            Console.WriteLine($"Send Result Successful: {sendResult.Successful}");
        }

        [Test]
        [SyncOnly]
        public void SendingGroupSMSMessageWithOptions()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions
            var response = smsClient.Send(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }, // E.164 formatted recipient phone numbers
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber },
                message: "Weekly Promotion!",
                options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                {
                    Tag = "marketing", // custom tags
                    DeliveryReportTimeoutInSeconds = 90,
                    MessagingConnect = new MessagingConnectOptions("PartnerApiKey", "PartnerName")  // OPTIONAL
                });
            foreach (SmsSendResult result in response.Value)
            {
                Console.WriteLine($"Sms id: {result.MessageId}");
                Console.WriteLine($"Send Result Successful: {result.Successful}");
            }
            #endregion Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions
        }

        [Test]
        public async Task SendMessageTroubleShooting()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_Tests_Troubleshooting
            try
            {
                var response = await smsClient.SendAsync(
                    //@@ from: "<from-phone-number>" // Your E.164 formatted phone number used to send SMS
                    //@@ to: new string [] {"<to-phone-number-1>", "<to-phone-number-2>"}, // E.164 formatted recipient phone number
                    /*@@*/ from: TestEnvironment.FromPhoneNumber,
                    /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber },
                    message: "Weekly Promotion!",
                    options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                    {
                        Tag = "marketing", // custom tags
                    });
                foreach (SmsSendResult result in response.Value)
                {
                    if (result.Successful)
                    {
                        Console.WriteLine($"Successfully sent this message: {result.MessageId} to {result.To}.");
                    }
                    else
                    {
                        Console.WriteLine($"Something went wrong when trying to send this message {result.MessageId} to {result.To}.");
                        Console.WriteLine($"Status code {result.HttpStatusCode} and error message {result.ErrorMessage}.");
                    }
                }
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion Snippet:Azure_Communication_Sms_Tests_Troubleshooting
        }
    }
}
