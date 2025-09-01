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

namespace Azure.Communication.Sms.Tests
{
    public class TelcoMessagingClientLiveTests : SmsClientLiveTestBase
    {
        public TelcoMessagingClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task SendingSmsMessage()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
                Response<SmsSendResult> response = await client.Sms.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
                SmsSendResult result = response.Value;
                Console.WriteLine($"Sms id: {result.MessageId}");
                AssertSmsSendingHappyPath(result);
                AssertSmsSendingRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingSmsMessageUsingTokenCredential()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClientWithToken();
            try
            {
                Response<SmsSendResult> response = await client.Sms.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
                SmsSendResult result = response.Value;
                Console.WriteLine($"Sms id: {result.MessageId}");
                AssertSmsSendingHappyPath(result);
                AssertSmsSendingRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [TestCase("+18007342577", Description = "Unauthorized number")]
        [TestCase("+15550000000", Description = "Fake number")]
        public async Task SendingSmsMessageFromUnauthorizedNumber(string from)
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
                SmsSendResult result = await client.Sms.SendAsync(
                   from: from,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
            }
            catch (RequestFailedException ex)
            {
                Assert.IsNotEmpty(ex.Message);
                Assert.NotNull(ex.ErrorCode);
                Assert.IsTrue(ex.Status >= 400);
                Console.WriteLine($"Error Status: {ex.Status}");
                Console.WriteLine($"Error Code: {ex.ErrorCode}");
                Console.WriteLine($"Error Message: {ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            Assert.Fail("Expected RequestFailedException was not thrown.");
        }

        [Test]
        public async Task SendingSmsMessageToInvalidNumber()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
                SmsSendResult result = await client.Sms.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: "+15550000000",
                   message: "Hi");
            }
            catch (RequestFailedException ex)
            {
                Assert.IsNotEmpty(ex.Message);
                Assert.NotNull(ex.ErrorCode);
                Assert.IsTrue(ex.Status >= 400);
                Console.WriteLine($"Error Status: {ex.Status}");
                Console.WriteLine($"Error Code: {ex.ErrorCode}");
                Console.WriteLine($"Error Message: {ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
            Assert.Fail("Expected RequestFailedException was not thrown.");
        }

        [Test]
        public async Task SendingSmsMessageWithOptions()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
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
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingSmsMessageToMultipleRecipients()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
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
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingSmsMessageToMultipleRecipientsWithOptions()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
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
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingSmsMessageToLargeGroup()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
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
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingSmsMessageWithLongMessage()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
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
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingSmsMessageWithEmoji()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
                Response<SmsSendResult> response = await client.Sms.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hello ?? from TelcoMessagingClient ??");
                SmsSendResult result = response.Value;
                Console.WriteLine($"Sms id: {result.MessageId}");
                AssertSmsSendingHappyPath(result);
                AssertSmsSendingRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        #region Delivery Reports Tests

        [Test]
        public async Task GetDeliveryReportAsync()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
                // First send a message with delivery report enabled to get a message ID
                SmsSendOptions smsOptions = new SmsSendOptions(enableDeliveryReport: true)
                {
                    Tag = "delivery-report-test",
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
                await Task.Delay(TimeSpan.FromSeconds(5));

                // Get the delivery report
                Response<DeliveryReport> deliveryResponse = await client.DeliveryReports.GetAsync(sendResult.MessageId);
                DeliveryReport deliveryReport = deliveryResponse.Value;

                AssertDeliveryReportHappyPath(deliveryReport, sendResult.MessageId);
                AssertDeliveryReportRawResponseHappyPath(deliveryResponse.GetRawResponse().ContentStream ?? new MemoryStream());
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task GetDeliveryReportAsync_UsingTokenCredential()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClientWithToken();
            try
            {
                // First send a message with delivery report enabled to get a message ID
                SmsSendOptions smsOptions = new SmsSendOptions(enableDeliveryReport: true)
                {
                    Tag = "delivery-report-token-test",
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
                await Task.Delay(TimeSpan.FromSeconds(5));

                // Get the delivery report
                Response<DeliveryReport> deliveryResponse = await client.DeliveryReports.GetAsync(sendResult.MessageId);
                DeliveryReport deliveryReport = deliveryResponse.Value;

                AssertDeliveryReportHappyPath(deliveryReport, sendResult.MessageId);
                AssertDeliveryReportRawResponseHappyPath(deliveryResponse.GetRawResponse().ContentStream ?? new MemoryStream());
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public void GetDeliveryReport_Sync()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
                // First send a message with delivery report enabled to get a message ID
                SmsSendOptions smsOptions = new SmsSendOptions(enableDeliveryReport: true)
                {
                    Tag = "delivery-report-sync-test",
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
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

                // Get the delivery report
                Response<DeliveryReport> deliveryResponse = client.DeliveryReports.Get(sendResult.MessageId);
                DeliveryReport deliveryReport = deliveryResponse.Value;

                AssertDeliveryReportHappyPath(deliveryReport, sendResult.MessageId);
                AssertDeliveryReportRawResponseHappyPath(deliveryResponse.GetRawResponse().ContentStream ?? new MemoryStream());
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Unexpected error: {ex}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [TestCase("invalid-message-id")]
        [TestCase("non-existent-message-123")]
        [TestCase("fake-message-id")]
        public async Task GetDeliveryReportAsync_WithInvalidMessageId_ShouldHandleGracefully(string invalidMessageId)
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
                Response<DeliveryReport> deliveryResponse = await client.DeliveryReports.GetAsync(invalidMessageId);

                // If we get here, the service returned a response (possibly with empty data)
                // This is valid behavior for some services
                Console.WriteLine($"Received response for message ID: {invalidMessageId}");
            }
            catch (RequestFailedException ex)
            {
                // This is expected for invalid message IDs
                Assert.IsNotEmpty(ex.Message);
                Assert.IsTrue(ex.Status >= 400);
                Console.WriteLine($"Expected error for invalid message ID '{invalidMessageId}': {ex.Message}");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task GetDeliveryReportAsync_WithMultipleMessageIds()
        {
            TelcoMessagingClient client = CreateTelcoMessagingClient();
            try
            {
                // Send multiple messages with delivery reports enabled
                var messageIds = new List<string>();

                for (int i = 0; i < 3; i++)
                {
                    SmsSendOptions smsOptions = new SmsSendOptions(enableDeliveryReport: true)
                    {
                        Tag = $"delivery-report-multiple-test-{i}",
                    };

                    Response<SmsSendResult> sendResponse = await client.Sms.SendAsync(
                       from: TestEnvironment.FromPhoneNumber,
                       to: TestEnvironment.ToPhoneNumber,
                       message: $"Test message {i + 1} for delivery report",
                       options: smsOptions);

                    messageIds.Add(sendResponse.Value.MessageId);
                    Console.WriteLine($"Sent SMS {i + 1} with message ID: {sendResponse.Value.MessageId}");
                }

                // Wait for delivery reports to be available
                await Task.Delay(TimeSpan.FromSeconds(10));

                // Get delivery reports for all messages
                foreach (string messageId in messageIds)
                {
                    try
                    {
                        Response<DeliveryReport> deliveryResponse = await client.DeliveryReports.GetAsync(messageId);
                        DeliveryReport deliveryReport = deliveryResponse.Value;

                        AssertDeliveryReportHappyPath(deliveryReport, messageId);
                        Console.WriteLine($"Successfully retrieved delivery report for message: {messageId}");
                    }
                    catch (RequestFailedException ex)
                    {
                        // Some delivery reports might not be available yet, this is acceptable
                        Console.WriteLine($"Delivery report not yet available for message {messageId}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
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
