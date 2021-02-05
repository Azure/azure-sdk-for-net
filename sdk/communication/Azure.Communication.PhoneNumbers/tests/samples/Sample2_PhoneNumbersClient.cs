// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Communication.Administration.Tests;
using Azure.Communication.PhoneNumbers;
using Azure.Communication.PhoneNumbers.Models;
using Azure.Communication.PhoneNumbers.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Administration.Tests.Samples
{
    /// <summary>
    /// Basic Azure Communication Administration samples.
    /// </summary>
    public class Sample2_PhoneNumbersClient : PhoneNumbersClientLiveTestBase
    {
        public Sample2_PhoneNumbersClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [AsyncOnly]
        public async Task PurchaseAndReleaseAsync()
        {
            if (!IncludePhoneNumberLiveTests)
                Assert.Ignore("Include phone number live tests flag is off.");

            var client = CreateClient(false);

            const string countryCode = "US";

            #region Snippet:StartSearchPhoneNumbersAsync

            PhoneNumberSearchRequest searchRequest = new PhoneNumberSearchRequest(PhoneNumberType.Geographic, PhoneNumberAssignmentType.User,
                 new PhoneNumberCapabilities(PhoneNumberCapabilityValue.InboundOutbound, PhoneNumberCapabilityValue.None));

            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, searchRequest);
            //@@ await purchaseOperation.WaitForCompletionAsync();
            /*@@*/
            await WaitForCompletionAsync(searchOperation);

            #endregion Snippet:ReservePhoneNumbersAsync

            #region Snippet:StartPurchaseReservationAsync

            var purchaseOperation = await client.StartPurchasePhoneNumbersAsync(searchOperation.Id);
            //@@ await purchaseOperation.WaitForCompletionAsync();
            /*@@*/
            await WaitForCompletionAsync(purchaseOperation);

            #endregion Snippet:StartPurchaseReservationAsync

            #region Snippet:ListAcquiredPhoneNumbersAsync
            var acquiredPhoneNumbers = client.ListPhoneNumbersAsync();

            await foreach (var phoneNumber in acquiredPhoneNumbers)
            {
                Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
            }
            #endregion Snippet:ListAcquiredPhoneNumbersAsync

            var acquiredPhoneNumber = acquiredPhoneNumbers.ToEnumerableAsync().Result.Single().PhoneNumber;
            acquiredPhoneNumbers = client.ListPhoneNumbersAsync();

            var beforeReleaseNumberCount = (await acquiredPhoneNumbers.ToEnumerableAsync()).Count;

            #region Snippet:ReleasePhoneNumbersAsync

            //@@var acquiredPhoneNumber = "<acquired_phone_number>";
            var releaseOperation = client.StartReleasePhoneNumber(acquiredPhoneNumber);
            //@@ await purchaseOperation.WaitForCompletionAsync();
            /*@@*/
            await WaitForCompletionAsync(releaseOperation);

            #endregion Snippet:ReleasePhoneNumbersAsync

            acquiredPhoneNumbers = client.ListPhoneNumbersAsync();
            var afterReleaseNumberCount = (await acquiredPhoneNumbers.ToEnumerableAsync()).Count;
            Assert.AreEqual(1, beforeReleaseNumberCount - afterReleaseNumberCount);
        }

        private ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T> operation) where T : notnull
            => operation.WaitForCompletionAsync(TestEnvironment.Mode == RecordedTestMode.Playback ? TimeSpan.Zero : TimeSpan.FromSeconds(2), default);

        [Test]
        [SyncOnly]
        public void PurchaseAndRelease()
        {
            if (!IncludePhoneNumberLiveTests)
                Assert.Ignore("Include phone number live tests flag is off.");

            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:CreatePhoneNumbersClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new PhoneNumbersClient(connectionString);
            #endregion Snippet:CreatePhoneNumbersClient

            client = CreateClient(false);

            const string countryCode = "US";

            #region Snippet:SearchPhoneNumbers

            PhoneNumberSearchRequest searchRequest = new PhoneNumberSearchRequest(PhoneNumberType.Geographic, PhoneNumberAssignmentType.User,
                 new PhoneNumberCapabilities(PhoneNumberCapabilityValue.InboundOutbound, PhoneNumberCapabilityValue.None));

            var searchOperation = client.StartSearchAvailablePhoneNumbers(countryCode, searchRequest);

            while (!searchOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/
                SleepIfNotInPlaybackMode();

                searchOperation.UpdateStatus();
            }

            #endregion Snippet:SearchPhoneNumbers

            #region Snippet:StartPurchaseSearch
            var purchaseOperation = client.StartPurchasePhoneNumbers(searchOperation.Id);

            while (!purchaseOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/
                SleepIfNotInPlaybackMode();

                purchaseOperation.UpdateStatus();
            }
            #endregion Snippet:StartPurchaseSearch

            #region Snippet:ListAcquiredPhoneNumbers
            var acquiredPhoneNumbers = client.ListPhoneNumbers();

            foreach (var phoneNumber in acquiredPhoneNumbers)
            {
                Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
            }
            #endregion Snippet:ListAcquiredPhoneNumbers

            var acquiredPhoneNumber = searchOperation.Value.PhoneNumbers.Single();
            acquiredPhoneNumbers = client.ListPhoneNumbers();
            var beforeReleaseNumberCount = acquiredPhoneNumbers.Count();

            #region Snippet:ReleasePhoneNumbers
            //@@var acquiredPhoneNumber = "<acquired_phone_number>";
            var releaseOperation = client.StartReleasePhoneNumber(acquiredPhoneNumber);

            while (!releaseOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/
                SleepIfNotInPlaybackMode();

                releaseOperation.UpdateStatus();
            }
            #endregion Snippet:ReleasePhoneNumbers

            acquiredPhoneNumbers = client.ListPhoneNumbers();
            var afterReleaseNumberCount = acquiredPhoneNumbers.Count();
            Assert.AreEqual(1, beforeReleaseNumberCount - afterReleaseNumberCount);
        }

        private void SleepIfNotInPlaybackMode()
        {
            if (TestEnvironment.Mode != RecordedTestMode.Playback)
                Thread.Sleep(2000);
        }
    }
}
