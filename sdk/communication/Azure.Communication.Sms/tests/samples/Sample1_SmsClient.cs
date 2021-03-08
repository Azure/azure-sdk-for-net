// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests.samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    public partial class Sample1_SmsClient : RecordedTestBase<SmsClientTestEnvironment>
    {
        public Sample1_SmsClient(bool isAsync) : base(isAsync)
            => Sanitizer = new SmsClientRecordedTestSanitizer();

        public SmsClient CreateSmsClient()
        {
            var connectionString = TestEnvironment.ConnectionString;
            SmsClient client = new SmsClient(connectionString, InstrumentClientOptions(new SmsClientOptions()));

            #region Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
            //@@var connectionString = "<connection_string>"; // Find your Communication Services resource in the Azure portal
            //@@SmsClient client = new SmsClient(connectionString);
            #endregion Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClient
            return InstrumentClient(client);
        }

        public SmsClient CreateSmsClientWithToken()
        {
            string endpoint = TestEnvironment.Endpoint.ToString();

            #region Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
            //@@string endpoint = "<endpoint_url>";
            TokenCredential tokenCredential = new DefaultAzureCredential();
            /*@@*/SmsClient client = new SmsClient(new Uri(endpoint), tokenCredential, InstrumentClientOptions(new SmsClientOptions()));
            //@@ SmsClient client = new SmsClient(new Uri(endpoint), tokenCredential);
            #endregion Snippet:Azure_Communication_Sms_Tests_Samples_CreateSmsClientWithToken
            return InstrumentClient(client);
        }

        [Test]
        public async Task SendingSMSMessage()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_Tests_SendAsync
            SmsSendResult sendResult = await smsClient.SendAsync(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: "<to-phone-number>", // E.164 formatted recipient phone number
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: TestEnvironment.ToPhoneNumber,
                message: "Hi");
            Console.WriteLine($"Sms id: {sendResult.MessageId}");
            #endregion Snippet:Azure_Communication_Sms_Tests_SendAsync
            Console.WriteLine($"Send Result Successful: {sendResult.Successful}");
        }

        [Test]
        public async Task SendingGroupSMSMessageWithOptions()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions
            Response<IEnumerable<SmsSendResult>> response = await smsClient.SendAsync(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }, // E.164 formatted recipient phone numbers
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber },
                message: "Weekly Promotion!",
                options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                {
                    Tag = "marketing", // custom tags
                });
            IEnumerable<SmsSendResult> results = response.Value;
            foreach (SmsSendResult result in results)
            {
                Console.WriteLine($"Sms id: {result.MessageId}");
                Console.WriteLine($"Send Result Successful: {result.Successful}");
            }
            #endregion Snippet:Azure_Communication_SmsClient_Send_GroupSmsWithOptions
        }

        [Test]
        public async Task SendMessageTroubleShooting()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_Tests_Troubleshooting
            try
            {
                Response<IEnumerable<SmsSendResult>> response = await smsClient.SendAsync(
                    //@@ from: "<from-phone-number>" // Your E.164 formatted phone number used to send SMS
                    //@@ to: new string [] {"<to-phone-number-1>", "<to-phone-number-2>"}, // E.164 formatted recipient phone number
                    /*@@*/ from: TestEnvironment.FromPhoneNumber,
                    /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber },
                    message: "Weekly Promotion!",
                    options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
                {
                    Tag = "marketing", // custom tags
                });
                IEnumerable<SmsSendResult> results = response.Value;
                foreach (SmsSendResult result in results)
                {
                    if (result.Successful)
                    {
                        Console.WriteLine($"Successfully sent this message: {result.MessageId} to {result.To}.");
                    }
                    else
                    {
                        Console.WriteLine($"Something went wrong when trying to send this message {result.MessageId} to {result.To}.");
                        Console.WriteLine($"Status code {result.HttpStatusCode} and error message {result.ErrorMessage}.");
                    }
                }
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion Snippet:Azure_Communication_Sms_Tests_Troubleshooting
        }
    }
}
