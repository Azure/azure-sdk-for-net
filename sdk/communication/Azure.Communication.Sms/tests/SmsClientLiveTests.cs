// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System;
/*@@*/ using System.IO;
//@@ using Azure.Communication.Sms;
#endregion Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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
                Response<SmsSendResult> response = await client.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
                SmsSendResult result = response.Value;
                Console.WriteLine($"Sms id: {result.MessageId}");
                assertHappyPath(result);
                assertRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
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
                assertHappyPath(result);
                assertRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
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
                Assert.True(ex.Message.Contains("401"));
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
                assertRawResponseHappyPath(response.GetRawResponse().ContentStream ?? new MemoryStream());
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
                Response<SmsSendResult> firstMessageResponse = await client.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
                Response<SmsSendResult> secondMessageResponse = await client.SendAsync(
                   from: TestEnvironment.FromPhoneNumber,
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");

                assertRawResponseHappyPath(firstMessageResponse.GetRawResponse().ContentStream ?? new MemoryStream());
                assertRawResponseHappyPath(secondMessageResponse.GetRawResponse().ContentStream ?? new MemoryStream());

                SmsSendResult firstMessageResult = firstMessageResponse.Value;
                SmsSendResult secondMessageResult = secondMessageResponse.Value;

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

        public void assertRawResponseHappyPath(Stream contentStream)
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
