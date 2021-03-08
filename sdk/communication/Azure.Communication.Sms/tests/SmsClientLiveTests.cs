// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System;
using System.Collections.Generic;
//@@ using Azure.Communication.Sms;
#endregion Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientLiveTests : RecordedTestBase<SmsClientTestEnvironment>
    {
        public SmsClientLiveTests(bool isAsync) : base(isAsync)
            => Sanitizer = new SmsClientRecordedTestSanitizer();

        [Test]
        public async Task SendingSmsMessage()
        {
            SmsClient client = InstrumentClient(
                new SmsClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new SmsClientOptions())));
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
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingSmsMessageUsingTokenCredential()
        {
            TokenCredential tokenCredential;
            if (Mode == RecordedTestMode.Playback)
            {
                tokenCredential = new MockCredential();
            }
            else
            {
                tokenCredential = new DefaultAzureCredential();
            }
            SmsClient client = InstrumentClient(
                new SmsClient(
                    new Uri(ConnectionString.Parse(TestEnvironment.ConnectionString, allowEmptyValues: true).GetRequired("endpoint")),
                    tokenCredential,
                    InstrumentClientOptions(new SmsClientOptions())));

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
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingSmsMessageFromFakeNumber()
        {
            SmsClient client = InstrumentClient(
                new SmsClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new SmsClientOptions())));
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
            SmsClient client = InstrumentClient(
                new SmsClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new SmsClientOptions())));
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
            }

            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingSmsMessageFromUnauthorizedNumber()
        {
            SmsClient client = InstrumentClient(
                new SmsClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new SmsClientOptions())));
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
                Assert.True(ex.Message.Contains("404"));
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
            SmsClient client = InstrumentClient(
                new SmsClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new SmsClientOptions())));
            try
            {
                Response<IEnumerable<SmsSendResult>> response = await client.SendAsync(
                    from: TestEnvironment.FromPhoneNumber,
                    to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber },
                   message: "Hi",
                   options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                   {
                       Tag = "marketing", // custom tags
                   });
                IEnumerable<SmsSendResult> results = response.Value;
                foreach (SmsSendResult result in results)
                {
                    Console.WriteLine($"Sms id: {result.MessageId}");
                    assertHappyPath(result);
                }
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        [Test]
        public async Task SendingTwoSmsMessages()
        {
            SmsClient client = InstrumentClient(
                new SmsClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new SmsClientOptions())));
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
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex}");
            }
        }

        public void assertHappyPath(SmsSendResult sendResult)
        {
            Assert.True(sendResult.Successful);
            Assert.AreEqual(202, sendResult.HttpStatusCode);
            Assert.IsFalse(string.IsNullOrWhiteSpace(sendResult.MessageId));
        }
    }
}
