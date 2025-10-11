// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests.samples
{
    /// <summary>
    /// Samples that demonstrate TelcoMessagingClient usage for README.md file.
    /// </summary>
    public partial class Sample3_TelcoMessagingClient : SmsClientLiveTestBase
    {
        public Sample3_TelcoMessagingClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [AsyncOnly]
        public async Task SendingSMSMessageAsync()
        {
            TelcoMessagingClient telcoMessagingClient = CreateTelcoMessagingClient();
            #region Snippet:Azure_Communication_Sms_Tests_TelcoMessaging_SendAsync
            SmsSendResult sendResult = await telcoMessagingClient.Sms.SendAsync(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: "<to-phone-number>", // E.164 formatted recipient phone number
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: TestEnvironment.ToPhoneNumber,
                message: "Hi");
            Console.WriteLine($"Sms id: {sendResult.MessageId}");
            #endregion Snippet:Azure_Communication_Sms_Tests_TelcoMessaging_SendAsync
            Console.WriteLine($"Send Result Successful: {sendResult.Successful}");
        }

        [Test]
        [AsyncOnly]
        public async Task SendingGroupSMSMessageWithOptionsAsync()
        {
            TelcoMessagingClient telcoMessagingClient = CreateTelcoMessagingClient();
            #region Snippet:Azure_Communication_TelcoMessagingClient_Send_GroupSmsWithOptionsAsync
            var response = await telcoMessagingClient.Sms.SendAsync(
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
            #endregion Snippet:Azure_Communication_TelcoMessagingClient_Send_GroupSmsWithOptionsAsync
        }

        [Test]
        [SyncOnly]
        public void SendingSMSMessage()
        {
            TelcoMessagingClient telcoMessagingClient = CreateTelcoMessagingClient();
            #region Snippet:Azure_Communication_Sms_Tests_TelcoMessaging_Send
            SmsSendResult sendResult = telcoMessagingClient.Sms.Send(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: "<to-phone-number>", // E.164 formatted recipient phone number
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: TestEnvironment.ToPhoneNumber,
                message: "Hi");
            Console.WriteLine($"Sms id: {sendResult.MessageId}");
            #endregion Snippet:Azure_Communication_Sms_Tests_TelcoMessaging_Send
            Console.WriteLine($"Send Result Successful: {sendResult.Successful}");
        }

        [Test]
        [SyncOnly]
        public void SendingGroupSMSMessageWithOptions()
        {
            TelcoMessagingClient telcoMessagingClient = CreateTelcoMessagingClient();
            #region Snippet:Azure_Communication_TelcoMessagingClient_Send_GroupSmsWithOptions
            var response = telcoMessagingClient.Sms.Send(
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
            #endregion Snippet:Azure_Communication_TelcoMessagingClient_Send_GroupSmsWithOptions
        }

        [Test]
        [AsyncOnly]
        public async Task CheckOptOutAsync()
        {
            TelcoMessagingClient telcoMessagingClient = CreateTelcoMessagingClient();
            #region Snippet:Azure_Communication_Sms_OptOuts_Tests_TelcoMessaging_CheckAsync
            var optOutCheckResults = await telcoMessagingClient.OptOuts.CheckAsync(
               //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
               //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
               /*@@*/ from: TestEnvironment.FromPhoneNumber,
               /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber });
            foreach (var result in optOutCheckResults.Value)
            {
                Console.WriteLine($"{result.To}: {result.IsOptedOut}");
            }
            #endregion Snippet:Azure_Communication_Sms_OptOuts_Tests_TelcoMessaging_CheckAsync
        }

        [Test]
        [AsyncOnly]
        public async Task AddOptOutAsync()
        {
            TelcoMessagingClient telcoMessagingClient = CreateTelcoMessagingClient();
            #region Snippet:Azure_Communication_Sms_OptOuts_Tests_TelcoMessaging_AddAsync
            var optOutAddResults = await telcoMessagingClient.OptOuts.AddAsync(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber });
            foreach (var result in optOutAddResults.Value)
            {
                Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
            }
            #endregion Snippet:Azure_Communication_Sms_OptOuts_Tests_TelcoMessaging_AddAsync
        }

        [Test]
        [AsyncOnly]
        public async Task RemoveOptOutAsync()
        {
            TelcoMessagingClient telcoMessagingClient = CreateTelcoMessagingClient();
            #region Snippet:Azure_Communication_Sms_OptOuts_Tests_TelcoMessaging_RemoveAsync
            var optOutRemoveResults = await telcoMessagingClient.OptOuts.RemoveAsync(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber });

            foreach (var result in optOutRemoveResults.Value)
            {
                Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
            }
            #endregion Snippet:Azure_Communication_Sms_OptOuts_Tests_TelcoMessaging_RemoveAsync
        }

        [Test]
        [AsyncOnly]
        public async Task GetDeliveryReportAsync()
        {
            TelcoMessagingClient telcoMessagingClient = CreateTelcoMessagingClient();

            // First send a message to get a message ID
            SmsSendResult sendResult = await telcoMessagingClient.Sms.SendAsync(
                from: TestEnvironment.FromPhoneNumber,
                to: TestEnvironment.ToPhoneNumber,
                message: "Test message for delivery report");

            // Wait a moment for the message to be processed
            await Task.Delay(2000);

            #region Snippet:Azure_Communication_Sms_Tests_DeliveryReports_GetAsync
            var deliveryReport = await telcoMessagingClient.DeliveryReports.GetAsync(/*@@*/sendResult.MessageId);
            //@@ var deliveryReport = await telcoMessagingClient.DeliveryReports.GetAsync("<message-id>");
            Console.WriteLine($"Message {deliveryReport.Value.MessageId} delivery status: {deliveryReport.Value.DeliveryStatus}");
            if (deliveryReport.Value.DeliveryAttempts != null)
            {
                foreach (var attempt in deliveryReport.Value.DeliveryAttempts)
                {
                    Console.WriteLine($"Attempt at {attempt.Timestamp}: {attempt.SegmentsSucceeded} succeeded, {attempt.SegmentsFailed} failed");
                }
            }
            #endregion Snippet:Azure_Communication_Sms_Tests_DeliveryReports_GetAsync
        }

        [Test]
        [SyncOnly]
        public void GetDeliveryReport()
        {
            TelcoMessagingClient telcoMessagingClient = CreateTelcoMessagingClient();

            // First send a message to get a message ID
            SmsSendResult sendResult = telcoMessagingClient.Sms.Send(
                from: TestEnvironment.FromPhoneNumber,
                to: TestEnvironment.ToPhoneNumber,
                message: "Test message for delivery report");

            #region Snippet:Azure_Communication_Sms_Tests_DeliveryReports_Get
            var deliveryReport = telcoMessagingClient.DeliveryReports.Get(/*@@*/sendResult.MessageId);
            //@@ var deliveryReport = telcoMessagingClient.DeliveryReports.Get("<message-id>");
            Console.WriteLine($"Message {deliveryReport.Value.MessageId} delivery status: {deliveryReport.Value.DeliveryStatus}");
            if (deliveryReport.Value.DeliveryAttempts != null)
            {
                foreach (var attempt in deliveryReport.Value.DeliveryAttempts)
                {
                    Console.WriteLine($"Attempt at {attempt.Timestamp}: {attempt.SegmentsSucceeded} succeeded, {attempt.SegmentsFailed} failed");
                }
            }
            #endregion Snippet:Azure_Communication_Sms_Tests_DeliveryReports_Get
        }
    }
}
