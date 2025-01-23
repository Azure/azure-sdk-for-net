// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Sms.Tests.samples
{
    /// <summary>
    /// Samples that are used in the README.md file.
    /// </summary>
    public partial class Sample2_OptOutsApi : SmsClientLiveTestBase
    {
        public Sample2_OptOutsApi(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [AsyncOnly]
        public async Task CheckOptOutAsync()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_CheckAsync
            var optOutCheckResults = await smsClient.OptOuts.CheckAsync(
               //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
               //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
               /*@@*/ from: TestEnvironment.FromPhoneNumber,
               /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber });
            foreach (var result in optOutCheckResults.Value)
            {
                Console.WriteLine($"{result.To}: {result.IsOptedOut}");
            }
            #endregion Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_CheckAsync
        }

        [Test]
        [AsyncOnly]
        public async Task AddOptOutAsync()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_AddAsync
            var optOutAddResults = await smsClient.OptOuts.AddAsync(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber });
            foreach (var result in optOutAddResults.Value)
            {
                Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
            }
            #endregion Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_AddAsync
        }

        [Test]
        [AsyncOnly]
        public async Task RemoveOptOutAsync()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_RemoveAsync
            var optOutRemoveResults = await smsClient.OptOuts.RemoveAsync(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber });

            foreach (var result in optOutRemoveResults.Value)
            {
                Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
            }
            #endregion Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_RemoveAsync
        }

        [Test]
        [SyncOnly]
        public void CheckOptOut()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_Check
            var optOutCheckResults = smsClient.OptOuts.Check(
               //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
               //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
               /*@@*/ from: TestEnvironment.FromPhoneNumber,
               /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber });
            foreach (var result in optOutCheckResults.Value)
            {
                Console.WriteLine($"{result.To}: {result.IsOptedOut}");
            }
            #endregion Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_Check
        }

        [Test]
        [SyncOnly]
        public void AddOptOut()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_Add
            var optOutAddResults = smsClient.OptOuts.Add(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber });
            foreach (var result in optOutAddResults.Value)
            {
                Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
            }
            #endregion Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_Add
        }

        [Test]
        [SyncOnly]
        public void RemoveOptOut()
        {
            SmsClient smsClient = CreateSmsClient();
            #region Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_Remove
            var optOutRemoveResults = smsClient.OptOuts.Remove(
                //@@ from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
                //@@ to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }); // E.164 formatted recipient phone numbers
                /*@@*/ from: TestEnvironment.FromPhoneNumber,
                /*@@*/ to: new string[] { TestEnvironment.ToPhoneNumber, TestEnvironment.ToPhoneNumber });

            foreach (var result in optOutRemoveResults.Value)
            {
                Console.WriteLine($"{result.To}: {result.HttpStatusCode}");
            }
            #endregion Snippet:Azure_Communication_Sms_OptOuts_Tests_Samples_Remove
        }
    }
}
