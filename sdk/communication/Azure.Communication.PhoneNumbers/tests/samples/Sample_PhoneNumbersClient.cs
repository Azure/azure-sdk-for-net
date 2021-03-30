// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;
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

            var client = CreateClient(AuthMethod.ConnectionString, false);

            const string countryCode = "US";

            #region Snippet:SearchPhoneNumbersAsync

            var capabilities = new PhoneNumberCapabilities(calling:PhoneNumberCapabilityType.None, sms:PhoneNumberCapabilityType.Outbound);

            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities);
            //@@ await searchOperation.WaitForCompletionAsync();
            /*@@*/ await WaitForCompletionAsync(searchOperation);

            #endregion Snippet:SearchPhoneNumbersAsync

            #region Snippet:StartPurchaseSearchAsync

            var purchaseOperation = await client.StartPurchasePhoneNumbersAsync(searchOperation.Value.SearchId);
            //@@ await purchaseOperation.WaitForCompletionResponseAsync();
            /*@@*/ await WaitForCompletionResponseAsync(purchaseOperation!);

            #endregion Snippet:StartPurchaseSearchAsync

            #region Snippet:GetPurchasedPhoneNumbersAsync
            var purchasedPhoneNumbers = client.GetPurchasedPhoneNumbersAsync();

            await foreach (var phoneNumber in purchasedPhoneNumbers)
            {
                Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
            }
            #endregion Snippet:GetPurchasedPhoneNumbersAsync

            var purchasedPhoneNumber = searchOperation.Value.PhoneNumbers.Single();

            #region Snippet:UpdateCapabilitiesNumbersAsync
            var updateCapabilitiesOperation = await client.StartUpdateCapabilitiesAsync(purchasedPhoneNumber, calling: PhoneNumberCapabilityType.Outbound, sms: PhoneNumberCapabilityType.InboundOutbound);

            //@@ await updateCapabilitiesOperation.WaitForCompletionAsync();
            /*@@*/ await WaitForCompletionAsync(updateCapabilitiesOperation);

            #endregion Snippet:UpdateCapabilitiesNumbersAsync

            Assert.AreEqual(PhoneNumberCapabilityType.Outbound, updateCapabilitiesOperation.Value.Capabilities.Calling);
            Assert.AreEqual(PhoneNumberCapabilityType.InboundOutbound, updateCapabilitiesOperation.Value.Capabilities.Sms);

            purchasedPhoneNumbers = client.GetPurchasedPhoneNumbersAsync();
            var beforeReleaseNumberCount = (await purchasedPhoneNumbers.ToEnumerableAsync()).Count;

            #region Snippet:ReleasePhoneNumbersAsync

            //@@var purchasedPhoneNumber = "<purchased_phone_number>";
            var releaseOperation = await client.StartReleasePhoneNumberAsync(purchasedPhoneNumber);
            //@@ await releaseOperation.WaitForCompletionResponseAsync();
            /*@@*/ await WaitForCompletionResponseAsync(releaseOperation);

            #endregion Snippet:ReleasePhoneNumbersAsync

            purchasedPhoneNumbers = client.GetPurchasedPhoneNumbersAsync();
            var afterReleaseNumberCount = (await purchasedPhoneNumbers.ToEnumerableAsync()).Count;
            Assert.AreEqual(1, beforeReleaseNumberCount - afterReleaseNumberCount);
        }

        private ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T> operation) where T : notnull
            => operation.WaitForCompletionAsync(TestEnvironment.Mode == RecordedTestMode.Playback ? TimeSpan.Zero : TimeSpan.FromSeconds(2), default);

        private ValueTask<Response> WaitForCompletionResponseAsync(Operation operation)
            => operation.WaitForCompletionResponseAsync(TestEnvironment.Mode == RecordedTestMode.Playback ? TimeSpan.Zero : TimeSpan.FromSeconds(2), default);

        [Test]
        [SyncOnly]
        public void PurchaseAndRelease()
        {
            if (!IncludePhoneNumberLiveTests)
                Assert.Ignore("Include phone number live tests flag is off.");

            var connectionString = TestEnvironment.LiveTestConnectionString;

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

            client = CreateClient(AuthMethod.ConnectionString, false);

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

            #region Snippet:GetPurchasedPhoneNumbers
            var purchasedPhoneNumbers = client.GetPurchasedPhoneNumbers();

            foreach (var phoneNumber in purchasedPhoneNumbers)
            {
                Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
            }
            #endregion Snippet:GetPurchasedPhoneNumbers

            var purchasedPhoneNumber = searchOperation.Value.PhoneNumbers.Single();

            #region Snippet:UpdateCapabilitiesNumbers
            var updateCapabilitiesOperation = client.StartUpdateCapabilities(purchasedPhoneNumber, calling:PhoneNumberCapabilityType.Outbound, sms:PhoneNumberCapabilityType.InboundOutbound);

            while (!updateCapabilitiesOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/ SleepIfNotInPlaybackMode();
                updateCapabilitiesOperation.UpdateStatus();
            }

            #endregion Snippet:UpdateCapabilitiesNumbers

            Assert.AreEqual(PhoneNumberCapabilityType.Outbound, updateCapabilitiesOperation.Value.Capabilities.Calling);
            Assert.AreEqual(PhoneNumberCapabilityType.InboundOutbound, updateCapabilitiesOperation.Value.Capabilities.Sms);

            purchasedPhoneNumbers = client.GetPurchasedPhoneNumbers();
            var beforeReleaseNumberCount = purchasedPhoneNumbers.Count();

            #region Snippet:ReleasePhoneNumbers
            //@@var purchasedPhoneNumber = "<purchased_phone_number>";
            var releaseOperation = client.StartReleasePhoneNumber(purchasedPhoneNumber);

            while (!releaseOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/ SleepIfNotInPlaybackMode();
                releaseOperation.UpdateStatus();
            }
            #endregion Snippet:ReleasePhoneNumbers

            purchasedPhoneNumbers = client.GetPurchasedPhoneNumbers();
            var afterReleaseNumberCount = purchasedPhoneNumbers.Count();
            Assert.AreEqual(1, beforeReleaseNumberCount - afterReleaseNumberCount);
        }

        private void SleepIfNotInPlaybackMode()
        {
            if (TestEnvironment.Mode != RecordedTestMode.Playback)
                Thread.Sleep(2000);
        }
    }
}
