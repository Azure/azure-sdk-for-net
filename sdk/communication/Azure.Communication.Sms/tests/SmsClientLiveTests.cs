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

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientLiveTests : SmsClientLiveTestBase
    {
        public SmsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task SendingSmsMessageUsingTokenCredential()
        {
            SmsClient client = CreateSmsClientWithToken();
            try
            {
                Response<SmsSendResult> response = await client.SendAsync(
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

        [RecordedTest]
        [TestCase("+18007342577", Description = "Unauthorized number")]
        [TestCase("+15550000000", Description = "Fake number")]
        public async Task SendingSmsMessageFromUnauthorizedNumber(string from)
        {
            SmsClient client = CreateSmsClientWithNullOptions();
            try
            {
                SmsSendResult result = await client.SendAsync(
                   from: from,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
            }
            catch (RequestFailedException ex)
            {
                Assert.IsNotEmpty(ex.Message);
                Assert.True(ex.Message.Contains("401")); // Unauthorized
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [RecordedTest]
        public async Task SendingSmsMessageToGroupWithOptions()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                var response = await client.SendAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: [TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber],
                   message: "Hi",
                   options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                   {
                       Tag = "marketing", // custom tags
                       DeliveryReportTimeoutInSeconds = 90 // OPTIONAL
                   });
                AssertSmsSendingRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
                foreach (SmsSendResult result in response.Value)
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

        [RecordedTest]
        public async Task SendingTwoSmsMessages()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                Response<SmsSendResult> firstMessageResponse = await client.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
                Response<SmsSendResult> secondMessageResponse = await client.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");

                AssertSmsSendingRawResponseHappyPath(firstMessageResponse.GetRawResponse().ContentStream ?? new MemoryStream());
                AssertSmsSendingRawResponseHappyPath(secondMessageResponse.GetRawResponse().ContentStream ?? new MemoryStream());

                SmsSendResult firstMessageResult = firstMessageResponse.Value;
                SmsSendResult secondMessageResult = secondMessageResponse.Value;

                Assert.AreNotEqual(firstMessageResult.MessageId, secondMessageResult.MessageId);
                AssertSmsSendingHappyPath(firstMessageResult);
                AssertSmsSendingHappyPath(secondMessageResult);
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

        [RecordedTest]
        public async Task CheckOptOutToInvalidNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();

            try
            {
                IEnumerable<string>? to = ["+15550000000"];
                Response<IReadOnlyList<OptOutCheckResponseItem>> result = await client.OptOuts.CheckAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex.Message.Contains("InvalidInput"));
                return;
            }

            Assert.Fail("CheckAsync should have thrown an exception.");
        }

        [RecordedTest]
        public async Task AddOptOutToInvalidNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();

            try
            {
                IEnumerable<string>? to = ["+15550000000"];
                Response<IReadOnlyList<OptOutOperationResponseItem>> result = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex.Message.Contains("InvalidInput"));
                return;
            }

            Assert.Fail("AddAsync should have thrown an exception.");
        }

        [RecordedTest]
        public async Task RemoveOptOutToInvalidNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();

            try
            {
                IEnumerable<string>? to = ["+15550000000"];
                Response<IReadOnlyList<OptOutOperationResponseItem>> result = await client.OptOuts.RemoveAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);
            }
            catch (RequestFailedException ex)
            {
                Assert.That(ex.Message.Contains("InvalidInput"));
                return;
            }

            Assert.Fail("RemoveAsync should have thrown an exception.");
        }

        [RecordedTest]
        public async Task AddOptOutEndpointShouldMarkRecipientAsOptedOut()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber];

                Response<IReadOnlyList<OptOutOperationResponseItem>> addResult = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutCheckResponseItem>> checkResult = await client.OptOuts.CheckAsync(
                  from: TestEnvironment.FromPhoneNumber,
                  to: to);

                Assert.IsTrue(checkResult.Value[0].IsOptedOut);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception should not have been thrown.");
                Console.WriteLine(ex);
                return;
            }
        }

        [RecordedTest]
        public async Task RemoveOptOutEndpointShouldMarkRecipientAsOptedIn()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber];

                Response<IReadOnlyList<OptOutOperationResponseItem>> addResult = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutOperationResponseItem>> removeResult = await client.OptOuts.RemoveAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutCheckResponseItem>> checkResult = await client.OptOuts.CheckAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Assert.IsFalse(checkResult.Value[0].IsOptedOut);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception should not have been thrown.");
                Console.WriteLine(ex);
                return;
            }
        }

        [RecordedTest]
        public async Task AddOptOutEndpointShouldMarkRecipientsAsOptedOut()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber];

                Response<IReadOnlyList<OptOutOperationResponseItem>> addResult = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutCheckResponseItem>> checkResult = await client.OptOuts.CheckAsync(
                  from: TestEnvironment.FromPhoneNumber,
                  to: to);

                Assert.IsTrue(checkResult.Value[0].IsOptedOut);
                Assert.IsTrue(checkResult.Value[1].IsOptedOut);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception should not have been thrown.");
                Console.WriteLine(ex);
                return;
            }
        }

        [RecordedTest]
        public async Task RemoveOptOutEndpointShouldMarkRecipientsAsOptedIn()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber];

                Response<IReadOnlyList<OptOutOperationResponseItem>> addResult = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutOperationResponseItem>> removeResult = await client.OptOuts.RemoveAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutCheckResponseItem>> checkResult = await client.OptOuts.CheckAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Assert.IsFalse(checkResult.Value[0].IsOptedOut);
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception should not have been thrown.");
                Console.WriteLine(ex);
                return;
            }
        }

        [RecordedTest]
        public async Task GetDeliveryReport_WithValidMessageId()
        {
            SmsClient client = CreateSmsClient();

            // First send a message to get a valid message ID
            Response<SmsSendResult> sendResponse = await client.SendAsync(
                from: TestEnvironment.FromPhoneNumber,
                to: TestEnvironment.ToPhoneNumber,
                message: "Test message for delivery report");

            string messageId = sendResponse.Value.MessageId;
            Assert.IsFalse(string.IsNullOrWhiteSpace(messageId));

            // Wait a bit for the message to be processed
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(2000);
            }

            try
            {
                // Get delivery report
                Response<DeliveryReport> reportResponse = await client.GetDeliveryReportAsync(messageId);
                DeliveryReport report = reportResponse.Value;

                Console.WriteLine($"Message ID: {report.MessageId}");
                Console.WriteLine($"From: {report.From}, To: {report.To}");
                Console.WriteLine($"Delivery Status: {report.DeliveryStatus}");
                Console.WriteLine($"Status Details: {report.DeliveryStatusDetails}");

                Assert.AreEqual(messageId, report.MessageId);
                Assert.AreEqual(TestEnvironment.FromPhoneNumber, report.From);
                Assert.AreEqual(TestEnvironment.ToPhoneNumber, report.To);
                Assert.NotNull(report.DeliveryStatus);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Error getting delivery report: {ex.Message}");
                // Don't fail if service is not ready yet - this is expected in some environments
                if (ex.Status != 404)
                {
                    throw;
                }
            }
        }

        [RecordedTest]
        public async Task GetDeliveryReport_WithInvalidMessageId_ReturnsError()
        {
            SmsClient client = CreateSmsClient();
            string invalidMessageId = "invalid-message-id-12345";

            try
            {
                Response<DeliveryReport> response = await client.GetDeliveryReportAsync(invalidMessageId);
                Assert.Fail("Expected RequestFailedException for invalid message ID");
            }
            catch (RequestFailedException ex)
            {
                // Service may return either 400 (Bad Request) or 404 (Not Found) for invalid message IDs
                Assert.That(ex.Status, Is.EqualTo(400).Or.EqualTo(404));
                Console.WriteLine($"Expected error: {ex.Message}");
            }
        }

        [RecordedTest]
        public async Task GetDeliveryReport_UsingTokenCredential_WithValidMessageId()
        {
            SmsClient client = CreateSmsClientWithToken();

            // First send a message to get a valid message ID
            Response<SmsSendResult> sendResponse = await client.SendAsync(
                from: TestEnvironment.FromPhoneNumber,
                to: TestEnvironment.ToPhoneNumber,
                message: "Test message for delivery report with AAD");

            string messageId = sendResponse.Value.MessageId;
            Assert.IsFalse(string.IsNullOrWhiteSpace(messageId));

            // Wait a bit for the message to be processed
            if (Mode != RecordedTestMode.Playback)
            {
                await Task.Delay(2000);
            }

            try
            {
                // Get delivery report using AAD authentication
                Response<DeliveryReport> reportResponse = await client.GetDeliveryReportAsync(messageId);
                DeliveryReport report = reportResponse.Value;

                Assert.AreEqual(messageId, report.MessageId);
                Assert.AreEqual(TestEnvironment.FromPhoneNumber, report.From);
                Assert.AreEqual(TestEnvironment.ToPhoneNumber, report.To);
                Assert.NotNull(report.DeliveryStatus);
            }
            catch (RequestFailedException ex)
            {
                // Don't fail if service is not ready yet
                if (ex.Status != 404)
                {
                    throw;
                }
            }
        }

        [RecordedTest]
        public async Task GetDeliveryReport_UsingTokenCredential_WithInvalidMessageId()
        {
            SmsClient client = CreateSmsClientWithToken();
            string invalidMessageId = "invalid-message-id-aad-test";

            try
            {
                Response<DeliveryReport> response = await client.GetDeliveryReportAsync(invalidMessageId);
                Assert.Fail("Expected RequestFailedException for invalid message ID with AAD");
            }
            catch (RequestFailedException ex)
            {
                // Service may return 400, 401, or 404 for invalid message IDs
                Assert.That(ex.Status, Is.EqualTo(400).Or.EqualTo(401).Or.EqualTo(404));
            }
        }

        private void AssertSmsSendingHappyPath(SmsSendResult sendResult)
        {
            Assert.True(sendResult.Successful);
            Assert.AreEqual(202, sendResult.HttpStatusCode);
            Assert.IsFalse(string.IsNullOrWhiteSpace(sendResult.MessageId));
        }

        private void AssertSmsSendingRawResponseHappyPath(Stream contentStream)
        {
            if (contentStream.Length > 0)
            {
                StreamReader streamReader = new StreamReader(contentStream);
                streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                string rawResponse = streamReader.ReadToEnd();
                Assert.True(rawResponse.Contains("\"repeatabilityResult\":\"accepted\""));
                return;
            }
            Assert.Fail("Response content stream is empty.");
        }
    }
}
