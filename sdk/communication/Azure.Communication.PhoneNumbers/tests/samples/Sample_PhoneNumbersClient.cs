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
    /// Basic Azure Communication Phone Numbers samples.
    /// </summary>
    public class Sample_PhoneNumbersClient : PhoneNumbersClientLiveTestBase
    {
        public Sample_PhoneNumbersClient(bool isAsync) : base(isAsync)
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

            var capabilities = new PhoneNumberCapabilities(calling:PhoneNumberCapabilityType.None, sms:PhoneNumberCapabilityType.Outbound);

            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities);
            //@@ await searchOperation.WaitForCompletionAsync();
            /*@@*/ await WaitForCompletionAsync(searchOperation);

            #endregion Snippet:SearchPhoneNumbersAsync

            #region Snippet:StartPurchaseSearchAsync

            var purchaseOperation = await client.StartPurchasePhoneNumbersAsync(searchOperation.Value.SearchId);
            //@@ await purchaseOperation.WaitForCompletionAsync();
            /*@@*/ await WaitForCompletionAsync(purchaseOperation);

            #endregion Snippet:StartPurchaseSearchAsync

            #region Snippet:ListAcquiredPhoneNumbersAsync
            var acquiredPhoneNumbers = client.GetPhoneNumbersAsync();

            await foreach (var phoneNumber in acquiredPhoneNumbers)
            {
                Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
            }
            #endregion Snippet:ListAcquiredPhoneNumbersAsync

            var acquiredPhoneNumber = searchOperation.Value.PhoneNumbers.Single();

            #region Snippet:UpdateCapabilitiesNumbersAsync
            var updateCapabilitiesOperation = client.StartUpdateCapabilities(acquiredPhoneNumber, calling: PhoneNumberCapabilityType.Outbound, sms: PhoneNumberCapabilityType.InboundOutbound);

            //@@ await updateCapabilitiesOperation.WaitForCompletionAsync();
            /*@@*/ await WaitForCompletionAsync(updateCapabilitiesOperation);

            #endregion Snippet:UpdateCapabilitiesNumbersAsync

            Assert.AreEqual(PhoneNumberCapabilityType.Outbound, updateCapabilitiesOperation.Value.Capabilities.Calling);
            Assert.AreEqual(PhoneNumberCapabilityType.InboundOutbound, updateCapabilitiesOperation.Value.Capabilities.Sms);

            acquiredPhoneNumbers = client.GetPhoneNumbersAsync();
            var beforeReleaseNumberCount = (await acquiredPhoneNumbers.ToEnumerableAsync()).Count;

            #region Snippet:ReleasePhoneNumbersAsync

            //@@var acquiredPhoneNumber = "<acquired_phone_number>";
            var releaseOperation = client.StartReleasePhoneNumber(acquiredPhoneNumber);
            //@@ await releaseOperation.WaitForCompletionAsync();
            /*@@*/ await WaitForCompletionAsync(releaseOperation);

            #endregion Snippet:ReleasePhoneNumbersAsync

            acquiredPhoneNumbers = client.GetPhoneNumbersAsync();
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

            var capabilities = new PhoneNumberCapabilities(calling:PhoneNumberCapabilityType.None, sms:PhoneNumberCapabilityType.Outbound);

            var searchOperation = client.StartSearchAvailablePhoneNumbers(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities);

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
            var acquiredPhoneNumbers = client.GetPhoneNumbers();

            foreach (var phoneNumber in acquiredPhoneNumbers)
            {
                Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
            }
            #endregion Snippet:ListAcquiredPhoneNumbers

            var acquiredPhoneNumber = searchOperation.Value.PhoneNumbers.Single();

            #region Snippet:UpdateCapabilitiesNumbers
            var updateCapabilitiesOperation = client.StartUpdateCapabilities(acquiredPhoneNumber, calling:PhoneNumberCapabilityType.Outbound, sms:PhoneNumberCapabilityType.InboundOutbound);

            while (!updateCapabilitiesOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/ SleepIfNotInPlaybackMode();
                updateCapabilitiesOperation.UpdateStatus();
            }

            #endregion Snippet:UpdateCapabilitiesNumbers

            Assert.AreEqual(PhoneNumberCapabilityType.Outbound, updateCapabilitiesOperation.Value.Capabilities.Calling);
            Assert.AreEqual(PhoneNumberCapabilityType.InboundOutbound, updateCapabilitiesOperation.Value.Capabilities.Sms);

            acquiredPhoneNumbers = client.GetPhoneNumbers();
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

            acquiredPhoneNumbers = client.GetPhoneNumbers();
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
