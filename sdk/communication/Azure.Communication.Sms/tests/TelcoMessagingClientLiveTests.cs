// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System;
//@@ using Azure.Communication.Sms;
#endregion Snippet:Azure_Communication_Sms_Tests_UsingStatements

using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Communication.Sms.Models;
using Azure.Core.TestFramework;
using System.Threading;

namespace Azure.Communication.Sms.Tests
{
    public class TelcoMessagingClientLiveTests : SmsClientLiveTestBase
    {
        public TelcoMessagingClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task SendingSmsMessage()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            Response<SmsSendResult> response = await client.Sms.SendAsync(
               from: TestEnvironment.FromPhoneNumber,
               to: TestEnvironment.ToPhoneNumber,
               message: "Hi");
            SmsSendResult result = response.Value;
            Console.WriteLine($"Sms id: {result.MessageId}");
            AssertSmsSendingHappyPath(result);
            AssertSmsSendingRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
        }

        [RecordedTest]
        public async Task SendingSmsMessageUsingTokenCredential()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClientWithToken();

            Response<SmsSendResult> response = await client.Sms.SendAsync(
               from: TestEnvironment.FromPhoneNumber,
               to: TestEnvironment.ToPhoneNumber,
               message: "Hi");
            SmsSendResult result = response.Value;
            Console.WriteLine($"Sms id: {result.MessageId}");
            AssertSmsSendingHappyPath(result);
            AssertSmsSendingRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
        }

        [RecordedTest]
        [TestCase("+18007342577", Description = "Unauthorized number")]
        [TestCase("+15550000000", Description = "Fake number")]
        public void SendingSmsMessageFromUnauthorizedNumber(string from)
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            Assert.ThrowsAsync<RequestFailedException>(async () =>
                await client.Sms.SendAsync(
                   from: from,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi"));
        }

        [RecordedTest]
        public void SendingSmsMessageToInvalidNumber()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            Assert.ThrowsAsync<RequestFailedException>(async () =>
                await client.Sms.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: "+15550000000",
                   message: "Hi"));
        }

        [RecordedTest]
        public async Task SendingSmsMessageWithOptions()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            SmsSendOptions smsOptions = new SmsSendOptions(enableDeliveryReport: true)
            {
                Tag = "custom tag",
            };
            Response<SmsSendResult> response = await client.Sms.SendAsync(
               from: TestEnvironment.FromPhoneNumber,
               to: TestEnvironment.ToPhoneNumber,
               message: "Hi",
               options: smsOptions);
            SmsSendResult result = response.Value;
            Console.WriteLine($"Sms id: {result.MessageId}");
            AssertSmsSendingHappyPath(result);
            AssertSmsSendingRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
        }

        [RecordedTest]
        public async Task SendingSmsMessageToMultipleRecipients()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            var to = new List<string> { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber };
            Response<IReadOnlyList<SmsSendResult>> response = await client.Sms.SendAsync(
               from: TestEnvironment.FromPhoneNumber,
               to: to,
               message: "Hi");
            IReadOnlyList<SmsSendResult> results = response.Value;
            foreach (SmsSendResult result in results)
            {
                Console.WriteLine($"Sms id: {result.MessageId}");
                AssertSmsSendingHappyPath(result);
            }
        }

        [RecordedTest]
        public async Task SendingSmsMessageToMultipleRecipientsWithOptions()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            SmsSendOptions smsOptions = new SmsSendOptions(enableDeliveryReport: true)
            {
                Tag = "custom tag for multiple recipients",
            };
            var to = new List<string> { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber };
            Response<IReadOnlyList<SmsSendResult>> response = await client.Sms.SendAsync(
               from: TestEnvironment.FromPhoneNumber,
               to: to,
               message: "Hi from TelcoMessagingClient",
               options: smsOptions);
            IReadOnlyList<SmsSendResult> results = response.Value;
            foreach (SmsSendResult result in results)
            {
                Console.WriteLine($"Sms id: {result.MessageId}");
                AssertSmsSendingHappyPath(result);
            }
        }

        [RecordedTest]
        public async Task SendingSmsMessageToLargeGroup()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            var to = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                to.Add(TestEnvironment.ToPhoneNumber);
            }

            Response<IReadOnlyList<SmsSendResult>> response = await client.Sms.SendAsync(
               from: TestEnvironment.FromPhoneNumber,
               to: to,
               message: "Hi from TelcoMessagingClient to large group");
            IReadOnlyList<SmsSendResult> results = response.Value;
            Assert.AreEqual(10, results.Count);
            foreach (SmsSendResult result in results)
            {
                Console.WriteLine($"Sms id: {result.MessageId}");
                AssertSmsSendingHappyPath(result);
            }
        }

        [RecordedTest]
        public async Task SendingSmsMessageWithLongMessage()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            string longMessage = new string('a', 300); // 300 character message
            Response<SmsSendResult> response = await client.Sms.SendAsync(
               from: TestEnvironment.FromPhoneNumber,
               to: TestEnvironment.ToPhoneNumber,
               message: longMessage);
            SmsSendResult result = response.Value;
            Console.WriteLine($"Sms id: {result.MessageId}");
            AssertSmsSendingHappyPath(result);
            AssertSmsSendingRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
        }

        [RecordedTest]
        public async Task SendingSmsMessageWithEmoji()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            Response<SmsSendResult> response = await client.Sms.SendAsync(
               from: TestEnvironment.FromPhoneNumber,
               to: TestEnvironment.ToPhoneNumber,
               message: "Hello 👋 from TelcoMessagingClient 😎");
            SmsSendResult result = response.Value;
            Console.WriteLine($"Sms id: {result.MessageId}");
            AssertSmsSendingHappyPath(result);
            AssertSmsSendingRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
        }

        #region Delivery Reports Tests

        [RecordedTest]
        public async Task GetDeliveryReportAsync()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            int deliveryReportTimeoutInSeconds = 60;

            // First send a message with delivery report enabled to get a message ID
            SmsSendOptions smsOptions = new SmsSendOptions(enableDeliveryReport: true)
            {
                Tag = "delivery-report-test",
                DeliveryReportTimeoutInSeconds = deliveryReportTimeoutInSeconds
            };

            Response<SmsSendResult> sendResponse = await client.Sms.SendAsync(
               from: TestEnvironment.FromPhoneNumber,
               to: TestEnvironment.ToPhoneNumber,
               message: "Test message for delivery report",
               options: smsOptions);

            SmsSendResult sendResult = sendResponse.Value;
            Assert.IsNotEmpty(sendResult.MessageId);
            Console.WriteLine($"Sent SMS with message ID: {sendResult.MessageId}");

            // Wait a bit for the delivery report to be available
            await Task.Delay(TimeSpan.FromSeconds(deliveryReportTimeoutInSeconds + 2));

            // Get the delivery report
            Response<DeliveryReport> deliveryResponse = await client.DeliveryReports.GetAsync(sendResult.MessageId);
            DeliveryReport deliveryReport = deliveryResponse.Value;

            AssertDeliveryReportHappyPath(deliveryReport, sendResult.MessageId);
            AssertDeliveryReportRawResponseHappyPath(deliveryResponse.GetRawResponse().ContentStream ?? new MemoryStream());
        }

        [RecordedTest]
        public async Task GetDeliveryReportAsync_UsingTokenCredential()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClientWithToken();
            int deliveryReportTimeoutInSeconds = 60;

            // First send a message with delivery report enabled to get a message ID
            SmsSendOptions smsOptions = new SmsSendOptions(enableDeliveryReport: true)
            {
                Tag = "delivery-report-token-test",
                DeliveryReportTimeoutInSeconds = deliveryReportTimeoutInSeconds
            };

            Response<SmsSendResult> sendResponse = await client.Sms.SendAsync(
               from: TestEnvironment.FromPhoneNumber,
               to: TestEnvironment.ToPhoneNumber,
               message: "Test message for delivery report with token",
               options: smsOptions);

            SmsSendResult sendResult = sendResponse.Value;
            Assert.IsNotEmpty(sendResult.MessageId);
            Console.WriteLine($"Sent SMS with message ID: {sendResult.MessageId}");

            // Wait a bit for the delivery report to be available
            await Task.Delay(TimeSpan.FromSeconds(deliveryReportTimeoutInSeconds + 2));

            // Get the delivery report
            Response<DeliveryReport> deliveryResponse = await client.DeliveryReports.GetAsync(sendResult.MessageId);
            DeliveryReport deliveryReport = deliveryResponse.Value;

            AssertDeliveryReportHappyPath(deliveryReport, sendResult.MessageId);
            AssertDeliveryReportRawResponseHappyPath(deliveryResponse.GetRawResponse().ContentStream ?? new MemoryStream());
        }

        [RecordedTest]
        [SyncOnly]
        public void GetDeliveryReport_Sync()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            int deliveryReportTimeoutInSeconds = 60;

            // First send a message with delivery report enabled to get a message ID
            SmsSendOptions smsOptions = new SmsSendOptions(enableDeliveryReport: true)
            {
                Tag = "delivery-report-sync-test",
                DeliveryReportTimeoutInSeconds = deliveryReportTimeoutInSeconds
            };

            Response<SmsSendResult> sendResponse = client.Sms.Send(
               from: TestEnvironment.FromPhoneNumber,
               to: TestEnvironment.ToPhoneNumber,
               message: "Test message for delivery report sync",
               options: smsOptions);

            SmsSendResult sendResult = sendResponse.Value;
            Assert.IsNotEmpty(sendResult.MessageId);
            Console.WriteLine($"Sent SMS with message ID: {sendResult.MessageId}");

            // Wait a bit for the delivery report to be available
            Thread.Sleep(TimeSpan.FromSeconds(deliveryReportTimeoutInSeconds + 2));

            // Get the delivery report
            Response<DeliveryReport> deliveryResponse = client.DeliveryReports.Get(sendResult.MessageId);
            DeliveryReport deliveryReport = deliveryResponse.Value;

            AssertDeliveryReportHappyPath(deliveryReport, sendResult.MessageId);
            AssertDeliveryReportRawResponseHappyPath(deliveryResponse.GetRawResponse().ContentStream ?? new MemoryStream());
        }

        [RecordedTest]
        [TestCase("invalid-message-id")]
        [TestCase("non-existent-message-123")]
        [TestCase("fake-message-id")]
        public async Task GetDeliveryReportAsync_WithInvalidMessageId_ShouldHandleGracefully(string invalidMessageId)
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            // This test allows both success (with empty data) or RequestFailedException
            try
            {
                Response<DeliveryReport> deliveryResponse = await client.DeliveryReports.GetAsync(invalidMessageId);

                // If we get here, the service returned a response (possibly with empty data)
                // This is valid behavior for some services
                Console.WriteLine($"Received response for message ID: {invalidMessageId}");
            }
            catch (RequestFailedException ex)
            {
                // This is also expected for invalid message IDs
                Assert.IsNotEmpty(ex.Message);
                Assert.IsTrue(ex.Status >= 400);
                Console.WriteLine($"Expected error for invalid message ID '{invalidMessageId}': {ex.Message}");
            }
        }

        [RecordedTest]
        [SyncOnly]
        [TestCase("non-existent-sync-message")]
        [TestCase("sync-missing-id-456")]
        public void GetDeliveryReport_WithNonExistentMessageId_ShouldReturn404_Sync(string nonExistentMessageId)
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();

            // Getting delivery report for non-existent message should always result in 404 error (sync version)
            RequestFailedException? exception = Assert.Throws<RequestFailedException>(() =>
                client.DeliveryReports.Get(nonExistentMessageId));

            // Verify the error is a 404 Not Found
            Assert.NotNull(exception, "Exception should not be null");
            Assert.AreEqual(404, exception!.Status, $"Expected 404 Not Found for non-existent message ID '{nonExistentMessageId}', but got {exception.Status}");
            Assert.IsNotEmpty(exception.Message, "Exception message should not be empty");
            Console.WriteLine($"Confirmed 404 error for non-existent message ID '{nonExistentMessageId}': {exception.Message}");
        }

        #endregion

        /// <summary>
        /// Asserts that SMS sending was successful by validating the result.
        /// </summary>
        /// <param name="result">The SMS send result to validate.</param>
        private void AssertSmsSendingHappyPath(SmsSendResult result)
        {
            Assert.NotNull(result);
            Assert.IsNotEmpty(result.MessageId);
            Assert.IsTrue(result.Successful);
            Assert.IsNotEmpty(result.To);
            Assert.IsTrue(result.HttpStatusCode >= 200 && result.HttpStatusCode < 300);
        }

        /// <summary>
        /// Asserts that the raw response contains expected SMS response structure.
        /// </summary>
        /// <param name="responseStream">The raw response stream to validate.</param>
        private void AssertSmsSendingRawResponseHappyPath(Stream responseStream)
        {
            Assert.NotNull(responseStream);
            Assert.IsTrue(responseStream.Length > 0);
        }

        /// <summary>
        /// Asserts that delivery report retrieval was successful by validating the result.
        /// </summary>
        /// <param name="deliveryReport">The delivery report to validate.</param>
        /// <param name="expectedMessageId">The expected message ID.</param>
        private void AssertDeliveryReportHappyPath(DeliveryReport deliveryReport, string expectedMessageId)
        {
            Assert.NotNull(deliveryReport);
            Assert.IsNotEmpty(deliveryReport.MessageId);
            Assert.AreEqual(expectedMessageId, deliveryReport.MessageId);

            // DeliveryStatus should be a valid enum value
            Assert.NotNull(deliveryReport.DeliveryStatus);
            Console.WriteLine($"Delivery status: {deliveryReport.DeliveryStatus}");

            // DeliveryAttempts might be null or contain data
            if (deliveryReport.DeliveryAttempts != null)
            {
                foreach (var attempt in deliveryReport.DeliveryAttempts)
                {
                    Assert.NotNull(attempt);
                    Assert.NotNull(attempt.Timestamp);
                    Console.WriteLine($"Delivery attempt at {attempt.Timestamp}: {attempt.SegmentsSucceeded} succeeded, {attempt.SegmentsFailed} failed");
                }
            }
        }

        /// <summary>
        /// Asserts that the raw response contains expected delivery report response structure.
        /// </summary>
        /// <param name="responseStream">The raw response stream to validate.</param>
        private void AssertDeliveryReportRawResponseHappyPath(Stream responseStream)
        {
            Assert.NotNull(responseStream);
            Assert.IsTrue(responseStream.Length > 0);
        }
    }
}
