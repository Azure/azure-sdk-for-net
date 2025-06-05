﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
    public class SmsClientLiveTests : SmsClientLiveTestBase
    {
        public SmsClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task SendingSmsMessage()
        {
            SmsClient client = CreateSmsClient();
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task SendingSmsFromNullNumberShouldThrow()
        {
            SmsClient client = CreateSmsClientWithoutOptions();
            try
            {
                SmsSendResult result = await client.SendAsync(
                   from: null,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
            Assert.Fail("SendAsync should have thrown an exception.");
        }

        [Test]
        public async Task SendingSmsToNullNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = null;
                Response<IReadOnlyList<SmsSendResult>> result = await client.SendAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to,
                    message: "Hi");
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("to", ex.ParamName);
                return;
            }
            Assert.Fail("SendAsync should have thrown an exception.");
        }

        [Test]
        public async Task CheckOptOutFromNullNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber];
                Response<IReadOnlyList<OptOutResponseItem>> result = await client.OptOuts.CheckAsync(
                    from: null,
                    to: to);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
            Assert.Fail("CheckAsync should have thrown an exception.");
        }

        [Test]
        public async Task CheckOptOutToNullNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = null;
                Response<IReadOnlyList<OptOutResponseItem>> result = await client.OptOuts.CheckAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("to", ex.ParamName);
                return;
            }
            Assert.Fail("CheckAsync should have thrown an exception.");
        }

        [Test]
        public async Task CheckOptOutToCollectionContainingNullShouldThrow()
        {
            SmsClient client = CreateSmsClient();
            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                IEnumerable<string>? to =
                [
                    TestEnvironment.ToPhoneNumber,
                    null
                ];
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

                Response<IReadOnlyList<OptOutResponseItem>> result = await client.OptOuts.CheckAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("to", ex.ParamName);
                return;
            }
            Assert.Fail("CheckAsync should have thrown an exception.");
        }

        [Test]
        public async Task CheckOptOutToInvalidNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();

            try
            {
                IEnumerable<string>? to = ["+15550000000"];
                Response<IReadOnlyList<OptOutResponseItem>> result = await client.OptOuts.CheckAsync(
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

        [Test]
        public async Task AddOptOutFromNullNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber];
                Response<IReadOnlyList<OptOutAddResponseItem>> result = await client.OptOuts.AddAsync(
                    from: null,
                    to: to);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
            Assert.Fail("AddAsync should have thrown an exception.");
        }

        [Test]
        public async Task AddOptOutToNullNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = null;
                Response<IReadOnlyList<OptOutAddResponseItem>> result = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("to", ex.ParamName);
                return;
            }
            Assert.Fail("AddAsync should have thrown an exception.");
        }

        [Test]
        public async Task AddOptOutToCollectionContainingNullShouldThrow()
        {
            SmsClient client = CreateSmsClient();
            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                IEnumerable<string>? to =
                [
                    TestEnvironment.ToPhoneNumber,
                    null
                ];
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

                Response<IReadOnlyList<OptOutAddResponseItem>> result = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("to", ex.ParamName);
                return;
            }
            Assert.Fail("AddAsync should have thrown an exception.");
        }

        [Test]
        public async Task AddOptOutToInvalidNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();

            try
            {
                IEnumerable<string>? to = ["+15550000000"];
                Response<IReadOnlyList<OptOutAddResponseItem>> result = await client.OptOuts.AddAsync(
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

        [Test]
        public async Task RemoveOptOutFromNullNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber];
                Response<IReadOnlyList<OptOutRemoveResponseItem>> result = await client.OptOuts.RemoveAsync(
                    from: null,
                    to: to);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("from", ex.ParamName);
                return;
            }
            Assert.Fail("RemoveAsync should have thrown an exception.");
        }

        [Test]
        public async Task RemoveOptOutToNullNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = null;
                Response<IReadOnlyList<OptOutRemoveResponseItem>> result = await client.OptOuts.RemoveAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("to", ex.ParamName);
                return;
            }
            Assert.Fail("RemoveAsync should have thrown an exception.");
        }

        [Test]
        public async Task RemoveOptOutToCollectionContainingNullShouldThrow()
        {
            SmsClient client = CreateSmsClient();
            try
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                IEnumerable<string>? to =
                [
                    TestEnvironment.ToPhoneNumber,
                    null
                ];
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

                Response<IReadOnlyList<OptOutRemoveResponseItem>> result = await client.OptOuts.RemoveAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("to", ex.ParamName);
                return;
            }
            Assert.Fail("RemoveAsync should have thrown an exception.");
        }

        [Test]
        public async Task RemoveOptOutToInvalidNumberShouldThrow()
        {
            SmsClient client = CreateSmsClient();

            try
            {
                IEnumerable<string>? to = ["+15550000000"];
                Response<IReadOnlyList<OptOutRemoveResponseItem>> result = await client.OptOuts.RemoveAsync(
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

        [Test]
        public async Task AddOptOutEndpointShouldMarkRecipientAsOptedOut()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber];

                Response<IReadOnlyList<OptOutAddResponseItem>> addResult = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutResponseItem>> checkResult = await client.OptOuts.CheckAsync(
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

        [Test]
        public async Task RemoveOptOutEndpointShouldMarkRecipientAsOptedIn()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber];

                Response<IReadOnlyList<OptOutAddResponseItem>> addResult = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutRemoveResponseItem>> removeResult = await client.OptOuts.RemoveAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutResponseItem>> checkResult = await client.OptOuts.CheckAsync(
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

        [Test]
        public async Task AddOptOutEndpointShouldMarkRecipientsAsOptedOut()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber];

                Response<IReadOnlyList<OptOutAddResponseItem>> addResult = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutResponseItem>> checkResult = await client.OptOuts.CheckAsync(
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

        [Test]
        public async Task RemoveOptOutEndpointShouldMarkRecipientsAsOptedIn()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                IEnumerable<string>? to = [TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber];

                Response<IReadOnlyList<OptOutAddResponseItem>> addResult = await client.OptOuts.AddAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutRemoveResponseItem>> removeResult = await client.OptOuts.RemoveAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: to);

                Response<IReadOnlyList<OptOutResponseItem>> checkResult = await client.OptOuts.CheckAsync(
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

        private void AssertOptOutRawResponseBadRequest(Stream contentStream)
        {
            if (contentStream.Length > 0)
            {
                StreamReader streamReader = new StreamReader(contentStream);
                streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                string rawResponse = streamReader.ReadToEnd();
                Assert.True(rawResponse.Contains("\"code\":\"InvalidInput\""));
                return;
            }
            Assert.Fail("Response content stream is empty.");
        }
    }
}
