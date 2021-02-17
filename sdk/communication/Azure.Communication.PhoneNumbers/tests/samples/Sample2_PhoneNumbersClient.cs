// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.PhoneNumbers;
using Azure.Communication.PhoneNumbers.Models;
using Azure.Communication.PhoneNumbers.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Communication.PhoneNumbers.Tests.Samples
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

            #region Snippet:SearchPhoneNumbersAsync

            var capabilities = new PhoneNumberCapabilities(PhoneNumberCapabilityValue.None, PhoneNumberCapabilityValue.Outbound);
            var searchOptions = new PhoneNumberSearchOptions { AreaCode = "844", Quantity = 1 };

            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities, searchOptions);
            //@@ await purchaseOperation.WaitForCompletionAsync();
            /*@@*/ await WaitForCompletionAsync(searchOperation);

            #endregion Snippet:SearchPhoneNumbersAsync

            #region Snippet:StartPurchaseSearchAsync

            var purchaseOperation = await client.StartPurchasePhoneNumbersAsync(searchOperation.Value.SearchId);
            //@@ await purchaseOperation.WaitForCompletionAsync();
            /*@@*/ await WaitForCompletionAsync(purchaseOperation);

            #endregion Snippet:StartPurchaseSearchAsync

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
            /*@@*/ await WaitForCompletionAsync(releaseOperation);

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

            #region Snippet:CreatePhoneNumbersClientWithTokenCredential
            // Get an endpoint to our Azure Communication resource.
            //@@var endpoint = new Uri("<endpoint_url>");
            //@@TokenCredential tokenCredential = new DefaultAzureCredential();
            //@@client = new PhoneNumbersClient(endpoint, tokenCredential);
            #endregion Snippet:CreatePhoneNumbersClientWithTokenCredential

            client = CreateClient(false);

            const string countryCode = "US";

            #region Snippet:SearchPhoneNumbers

            var capabilities = new PhoneNumberCapabilities(PhoneNumberCapabilityValue.None, PhoneNumberCapabilityValue.Outbound);
            var searchOptions = new PhoneNumberSearchOptions { AreaCode = "844", Quantity = 1 };

            var searchOperation = client.StartSearchAvailablePhoneNumbers(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities, searchOptions);

            while (!searchOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/ SleepIfNotInPlaybackMode();
                searchOperation.UpdateStatus();
            }

            #endregion Snippet:SearchPhoneNumbers

            #region Snippet:StartPurchaseSearch
            var purchaseOperation = client.StartPurchasePhoneNumbers(searchOperation.Value.SearchId);

            while (!purchaseOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/ SleepIfNotInPlaybackMode();
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
                /*@@*/ SleepIfNotInPlaybackMode();
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
