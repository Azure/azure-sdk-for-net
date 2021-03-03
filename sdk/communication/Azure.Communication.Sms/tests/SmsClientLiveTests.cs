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

            #region Snippet:Azure_Communication_Sms_Tests_Troubleshooting
            try
            {
                #region Snippet:Azure_Communication_Sms_Tests_SendAsync
                SmsSendResult result = await client.SendAsync(
                   //@@ from: "+18001230000" // Phone number acquired on your Azure Communication resource
                   //@@ to: "+18005670000",
                   /*@@*/ from: TestEnvironment.FromPhoneNumber,
                   /*@@*/ to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
                Console.WriteLine($"Sms id: {result.MessageId}");
                #endregion Snippet:Azure_Communication_Sms_Tests_SendAsync
                /*@@*/ Assert.IsFalse(string.IsNullOrWhiteSpace(result.MessageId));
                /*@@*/ Assert.AreEqual(202, result.HttpStatusCode);
                /*@@*/ Assert.IsTrue(result.Successful);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion Snippet:Azure_Communication_Sms_Tests_Troubleshooting
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
                Assert.IsFalse(string.IsNullOrWhiteSpace(result.MessageId));
                Assert.AreEqual(202, result.HttpStatusCode);
                Assert.IsTrue(result.Successful);
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
                   from: "+18001234567",
                   to: TestEnvironment.ToPhoneNumber,
                   message: "Hi");
            }
            catch (RequestFailedException ex)
            {
                Assert.IsNotEmpty(ex.Message);
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
                #region Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions
                Response<IEnumerable<SmsSendResult>> response = await client.SendAsync(
                   //@@ from: "+18001230000" // Phone number acquired on your Azure Communication resource
                   //@@ to: new string[] {"+18005670000", "+18008900000}",
                   /*@@*/ from: TestEnvironment.FromPhoneNumber,
                   /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber },
                   message: "Hi",
                   options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                   {
                       Tag = "marketing", // custom tags
                   });
                IEnumerable<SmsSendResult> results = response.Value;
                foreach (SmsSendResult result in results)
                {
                    Console.WriteLine($"Sms id: {result.MessageId}");
                    /*@@*/ Assert.IsFalse(string.IsNullOrWhiteSpace(result.MessageId));
                    /*@@*/ Assert.AreEqual(202, result.HttpStatusCode);
                    /*@@*/ Assert.IsTrue(result.Successful);
                }
                #endregion Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions

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
    }
}
