// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System;
//@@ using Azure.Communication.Sms;
#endregion Snippet:Azure_Communication_Sms_Tests_UsingStatements
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests
{
    public class SmsClientLiveTests : RecordedTestBase<SmsClientTestEnvironment>
    {
        public SmsClientLiveTests(bool isAsync) : base(isAsync)
            => Sanitizer = new SmsClientRecordedTestSanitizer();

        [Test]
        public async Task SendingAnSmsMessage()
        {
            SmsClient client = InstrumentClient(
                new SmsClient(
                    TestEnvironment.ConnectionString,
                    InstrumentClientOptions(new SmsClientOptions())));

            #region Snippet:Azure_Communication_Sms_Tests_Troubleshooting
            try
            {
                #region Snippet:Azure_Communication_Sms_Tests_SendAsync
                SendSmsResponse result = await client.SendAsync(
                   //@@ from: new PhoneNumber("+18001230000"), // Phone number acquired on your Azure Communication resource
                   //@@ to: new PhoneNumber("+18005670000"),
                   /*@@*/ from: new PhoneNumberIdentifier(TestEnvironment.PhoneNumber),
                   /*@@*/ to: new PhoneNumberIdentifier(TestEnvironment.PhoneNumber),
                   message: "Hi");
                Console.WriteLine($"Sms id: {result.MessageId}");
                #endregion Snippet:Azure_Communication_Sms_Tests_SendAsync
                /*@@*/ Assert.IsFalse(string.IsNullOrWhiteSpace(result.MessageId));
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
    }
}
