// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System;
using System.Collections.Generic;
//@@ using Azure.Communication.Sms;
#endregion Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System.Threading.Tasks;
using NUnit.Framework;

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
                SmsSendResult result = await client.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
                Console.WriteLine($"Sms id: {result.MessageId}");
                assertHappyPath(result);
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
                SmsSendResult result = await client.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
                Console.WriteLine($"Sms id: {result.MessageId}");
                assertHappyPath(result);
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
        public async Task SendingSmsMessageFromFakeNumber()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                SmsSendResult result = await client.SendAsync(
                   from: "+15550000000",
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
            }
            catch (RequestFailedException ex)
            {
                Assert.IsNotEmpty(ex.Message);
                Assert.True(ex.Message.Contains("400"));
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingSmsMessageToFakeNumber()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                SmsSendResult result = await client.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: "+15550000000",
                   message: "Hi");
                Assert.AreEqual(400, result.HttpStatusCode);
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
        public async Task SendingSmsMessageFromUnauthorizedNumber()
        {
            SmsClient client = CreateSmsClient();
            try
            {
                SmsSendResult result = await client.SendAsync(
                   from: "+18007342577",
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
            }
            catch (RequestFailedException ex)
            {
                Assert.IsNotEmpty(ex.Message);
                // TODO: re-enable this when service change is made
                // Assert.True(ex.Message.Contains("401"));
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
                    to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber },
                   message: "Hi",
                   options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                   {
                       Tag = "marketing", // custom tags
                   });
                foreach (SmsSendResult result in response.Value)
                {
                    Console.WriteLine($"Sms id: {result.MessageId}");
                    assertHappyPath(result);
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
                SmsSendResult firstMessageResult = await client.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
                SmsSendResult secondMessageResult = await client.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");

                Assert.AreNotEqual(firstMessageResult.MessageId, secondMessageResult.MessageId);
                assertHappyPath(firstMessageResult);
                assertHappyPath(secondMessageResult);
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
            SmsClient client = CreateSmsClient();
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

        public void assertHappyPath(SmsSendResult sendResult)
        {
            Assert.True(sendResult.Successful);
            Assert.AreEqual(202, sendResult.HttpStatusCode);
            Assert.IsFalse(string.IsNullOrWhiteSpace(sendResult.MessageId));
        }
    }
}
