// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Communication.PhoneNumbers.Tests.Samples
{
    /// <summary>
    /// Basic Azure Communication Phone Numbers samples.
    /// </summary>
    public class Sample_PhoneNumbersClient : PhoneNumbersClientLiveTestBase
    {
        private readonly Guid _staticReservationId = Guid.Parse("6227aeb8-8086-4824-9586-05c04e96f37b");
        private Guid _reservationId;

        public Sample_PhoneNumbersClient(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Initializes the GUID that will be used for reservations created during this test run.
        /// It also ensures that it is properly sanitized for playback mode.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            _reservationId = Guid.NewGuid();

            // Replace any GUIDs in the request/response bodies with a static GUID for playback mode.
            // This will only be applied to the recordings of this test class.
            // NOTE: We are adding the new sanitizers at the start so that they are applied before the PhoneNumbers sanitization, which can malform the GUIDs.
            string guidPattern = @"[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}";
            BodyRegexSanitizers.Insert(0, new BodyRegexSanitizer(guidPattern) { Value = _staticReservationId.ToString() });
            UriRegexSanitizers.Insert(0, new UriRegexSanitizer(guidPattern) { Value = _staticReservationId.ToString() });
            HeaderRegexSanitizers.Insert(0, new HeaderRegexSanitizer("Location") { Regex = guidPattern, Value = _staticReservationId.ToString() });
            HeaderRegexSanitizers.Insert(0, new HeaderRegexSanitizer("Operation-Location") { Regex = guidPattern, Value = _staticReservationId.ToString() });
            HeaderRegexSanitizers.Insert(0, new HeaderRegexSanitizer("operation-id") { Regex = guidPattern, Value = _staticReservationId.ToString() });
            HeaderRegexSanitizers.Insert(0, new HeaderRegexSanitizer("reservation-purchase-id") { Regex = guidPattern, Value = _staticReservationId.ToString() });
        }

        [Test]
        [AsyncOnly]
        [Ignore("Test is failing in playback mode due to an issue with LRO not completing")]
        public async Task PurchaseAndReleaseAsync()
        {
            if (SkipPhoneNumberLiveTests)
                Assert.Ignore("Skip phone number live tests flag is on.");

            var client = CreateClient(AuthMethod.ConnectionString, false);

            const string countryCode = "US";

            #region Snippet:SearchPhoneNumbersAsync

            var capabilities = new PhoneNumberCapabilities(calling: PhoneNumberCapabilityType.None, sms: PhoneNumberCapabilityType.Outbound);

            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities);
            //@@ await searchOperation.WaitForCompletionAsync();
            /*@@*/

            #endregion Snippet:SearchPhoneNumbersAsync

            await WaitForCompletionAsync(searchOperation);

            #region Snippet:StartPurchaseSearchAsync

            var purchaseOperation = await client.StartPurchasePhoneNumbersAsync(searchOperation.Value.SearchId);
            //@@ await purchaseOperation.WaitForCompletionResponseAsync();
            /*@@*/

            #endregion Snippet:StartPurchaseSearchAsync

            await WaitForCompletionResponseAsync(purchaseOperation!);
            Assert.AreEqual(purchaseOperation.GetRawResponse().Status, 200);

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
            /*@@*/

            #endregion Snippet:UpdateCapabilitiesNumbersAsync

            await WaitForCompletionAsync(updateCapabilitiesOperation);
            Assert.AreEqual(PhoneNumberCapabilityType.Outbound, updateCapabilitiesOperation.Value.Capabilities.Calling);
            Assert.AreEqual(PhoneNumberCapabilityType.InboundOutbound, updateCapabilitiesOperation.Value.Capabilities.Sms);

            #region Snippet:ReleasePhoneNumbersAsync

            //@@var purchasedPhoneNumber = "<purchased_phone_number>";
            var releaseOperation = await client.StartReleasePhoneNumberAsync(purchasedPhoneNumber);
            //@@ await releaseOperation.WaitForCompletionResponseAsync();
            /*@@*/
            await WaitForCompletionResponseAsync(releaseOperation);

            #endregion Snippet:ReleasePhoneNumbersAsync

            var purchasedPhoneNumbersAfterReleaseStatus = "";
            try
            {
                var purchasedPhoneNumbersAfterReleaseOperation = await client.GetPurchasedPhoneNumberAsync(purchasedPhoneNumber);
                purchasedPhoneNumbersAfterReleaseStatus = purchasedPhoneNumbersAfterReleaseOperation.GetRawResponse().ReasonPhrase;
            }
            catch (RequestFailedException e)
            {
                purchasedPhoneNumbersAfterReleaseStatus = e.ErrorCode;
            }
            Assert.AreEqual("NotFound", purchasedPhoneNumbersAfterReleaseStatus);
        }

        private ValueTask<Response<T>> WaitForCompletionAsync<T>(Operation<T> operation) where T : notnull
            => InstrumentOperation(operation).WaitForCompletionAsync(TimeSpan.FromSeconds(2), default);

        private ValueTask<Response> WaitForCompletionResponseAsync(Operation operation)
            => InstrumentOperation(operation).WaitForCompletionResponseAsync(TimeSpan.FromSeconds(2), default);

        [Test]
        [SyncOnly]
        [Ignore("Test is failing in playback mode due to an issue with LRO not completing")]
        public void PurchaseAndRelease()
        {
            if (SkipPhoneNumberLiveTests)
                Assert.Ignore("Skip phone number live tests flag is on.");

            var connectionString = TestEnvironment.LiveTestStaticConnectionString;

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

            var capabilities = new PhoneNumberCapabilities(calling: PhoneNumberCapabilityType.None, sms: PhoneNumberCapabilityType.Outbound);

            var searchOperation = client.StartSearchAvailablePhoneNumbers(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities);

            while (!searchOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/
                SleepIfNotInPlaybackMode();
                searchOperation.UpdateStatus();
            }

            #endregion Snippet:SearchPhoneNumbers

            #region Snippet:StartPurchaseSearch
            var purchaseOperation = client.StartPurchasePhoneNumbers(searchOperation.Value.SearchId);
            while (!purchaseOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/
                SleepIfNotInPlaybackMode();
                purchaseOperation.UpdateStatus();
            }

            #endregion Snippet:StartPurchaseSearch

            Assert.AreEqual(purchaseOperation.GetRawResponse().Status, 200);

            #region Snippet:GetPurchasedPhoneNumbers
            var purchasedPhoneNumbers = client.GetPurchasedPhoneNumbers();

            foreach (var phoneNumber in purchasedPhoneNumbers)
            {
                Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
            }
            #endregion Snippet:GetPurchasedPhoneNumbers

            var purchasedPhoneNumber = searchOperation.Value.PhoneNumbers.Single();

            #region Snippet:UpdateCapabilitiesNumbers
            var updateCapabilitiesOperation = client.StartUpdateCapabilities(purchasedPhoneNumber, calling: PhoneNumberCapabilityType.Outbound, sms: PhoneNumberCapabilityType.InboundOutbound);

            while (!updateCapabilitiesOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/
                SleepIfNotInPlaybackMode();
                updateCapabilitiesOperation.UpdateStatus();
            }

            #endregion Snippet:UpdateCapabilitiesNumbers

            Assert.AreEqual(PhoneNumberCapabilityType.Outbound, updateCapabilitiesOperation.Value.Capabilities.Calling);
            Assert.AreEqual(PhoneNumberCapabilityType.InboundOutbound, updateCapabilitiesOperation.Value.Capabilities.Sms);

            #region Snippet:ReleasePhoneNumbers
            //@@var purchasedPhoneNumber = "<purchased_phone_number>";
            var releaseOperation = client.StartReleasePhoneNumber(purchasedPhoneNumber);

            while (!releaseOperation.HasCompleted)
            {
                //@@ Thread.Sleep(2000);
                /*@@*/
                SleepIfNotInPlaybackMode();
                releaseOperation.UpdateStatus();
            }

            #endregion Snippet:ReleasePhoneNumbers

            var purchasedPhoneNumbersAfterReleaseStatus = "";
            try
            {
                var purchasedPhoneNumbersAfterReleaseOperation = client.GetPurchasedPhoneNumber(purchasedPhoneNumber);
                purchasedPhoneNumbersAfterReleaseStatus = purchasedPhoneNumbersAfterReleaseOperation.GetRawResponse().ReasonPhrase;
            }
            catch (RequestFailedException e)
            {
                purchasedPhoneNumbersAfterReleaseStatus = e.ErrorCode;
            }
            Assert.AreEqual("NotFound", purchasedPhoneNumbersAfterReleaseStatus);
        }

        [TestCase]
        [AsyncOnly]
        [Ignore("Test is failing in playback mode due to an issue with LRO not completing")]
        public async Task PurchaseReservationAsync()
        {
            if (SkipPhoneNumberLiveTests)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }

            PhoneNumbersClient client = CreateClient(AuthMethod.ConnectionString, false);

            #region Snippet:BrowseAvailablePhoneNumbersAsync

            var browseRequest = new PhoneNumbersBrowseOptions("US", PhoneNumberType.TollFree);
            var browseResponse = await client.BrowseAvailableNumbersAsync(browseRequest);
            var availablePhoneNumbers = browseResponse.Value.PhoneNumbers;

            #endregion Snippet:BrowseAvailablePhoneNumbersAsync

            var reservationId = GetReservationId();

            #region Snippet:CreateReservationAsync
            // Reserve the first two available phone numbers.
            var phoneNumbersToReserve = availablePhoneNumbers.Take(2).ToList();

            // The reservation ID needs to be a unique GUID.
            //@@var reservationId = Guid.NewGuid();

            var request = new CreateOrUpdateReservationOptions(reservationId)
            {
                PhoneNumbersToAdd = phoneNumbersToReserve
            };
            var response = await client.CreateOrUpdateReservationAsync(request);
            var reservation = response.Value;

            #endregion Snippet:CreateReservationAsync

            Assert.IsTrue(phoneNumbersToReserve.All(n => reservation.PhoneNumbers.ContainsKey(n.Id)));
            Assert.AreNotEqual(PhoneNumberAvailabilityStatus.Error, reservation.PhoneNumbers[phoneNumbersToReserve.First().Id]);
            Assert.AreNotEqual(PhoneNumberAvailabilityStatus.Error, reservation.PhoneNumbers[phoneNumbersToReserve.Last().Id]);

            #region Snippet:CheckForPartialFailure
            var phoneNumbersWithError = reservation.PhoneNumbers.Values
                .Where(n => n.Status == PhoneNumberAvailabilityStatus.Error);

            if (phoneNumbersWithError.Any())
            {
                // Handle the error for the phone numbers that failed to reserve.
                foreach (var phoneNumber in phoneNumbersWithError)
                {
                    Console.WriteLine($"Failed to reserve phone number {phoneNumber.Id}. Error Code: {phoneNumber.Error?.Code} - Message: {phoneNumber.Error?.Message}");
                }
            }
            #endregion Snippet:CheckForPartialFailure

            #region Snippet:StartPurchaseReservationAsync
            var purchaseReservationOperation = await client.StartPurchaseReservationAsync(reservationId);
            //@@ await purchaseReservationOperation.WaitForCompletionResponseAsync();
            /*@@*/

            #endregion Snippet:StartPurchaseReservationAsync

            while (!purchaseReservationOperation.HasCompleted)
            {
                SleepIfNotInPlaybackMode();
                await purchaseReservationOperation.UpdateStatusAsync();
            }

            #region Snippet:ValidateReservationPurchaseAsync

            var purchasedReservationResponse = await client.GetReservationAsync(reservationId);
            var purchasedReservation = purchasedReservationResponse.Value;

            var failedPhoneNumbers = purchasedReservation.PhoneNumbers.Values
                .Where(n => n.Status == PhoneNumberAvailabilityStatus.Error);

            if (failedPhoneNumbers.Any())
            {
                // Handle the error for the phone numbers that failed to reserve.
                foreach (var phoneNumber in failedPhoneNumbers)
                {
                    Console.WriteLine($"Failed to purchase phone number {phoneNumber.Id}. Error Code: {phoneNumber.Error?.Code} - Message: {phoneNumber.Error?.Message}");
                }
            }

            #endregion Snippet:ValidateReservationPurchaseAsync

            Assert.IsTrue(purchasedReservation.PhoneNumbers.All(n => n.Value.Status == PhoneNumberAvailabilityStatus.Purchased));

            // Release the number to prevent additional costs.
            foreach (var phoneNumberToReserve in phoneNumbersToReserve)
            {
                var releaseOperation = await client.StartReleasePhoneNumberAsync(phoneNumberToReserve.Id);
                while (!releaseOperation.HasCompleted)
                {
                    SleepIfNotInPlaybackMode();
                    await releaseOperation.UpdateStatusAsync();
                }
            }
        }

        [TestCase]
        [SyncOnly]
        [Ignore("Test is failing in playback mode due to an issue with LRO not completing")]
        public void PurchaseReservation()
        {
            if (SkipPhoneNumberLiveTests)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }

            PhoneNumbersClient client = CreateClient(AuthMethod.ConnectionString, false);

            #region Snippet:BrowseAvailablePhoneNumbers

            var browseRequest = new PhoneNumbersBrowseOptions("US", PhoneNumberType.TollFree);
            var browseResponse = client.BrowseAvailableNumbers(browseRequest);
            var availablePhoneNumbers = browseResponse.Value.PhoneNumbers;

            #endregion Snippet:BrowseAvailablePhoneNumbers

            var reservationId = GetReservationId();

            #region Snippet:CreateReservation
            // Reserve the first two available phone numbers.
            var phoneNumbersToReserve = availablePhoneNumbers.Take(2).ToList();

            // The reservation ID needs to be a unique GUID.
            //@@var reservationId = Guid.NewGuid();

            var request = new CreateOrUpdateReservationOptions(reservationId)
            {
                PhoneNumbersToAdd = phoneNumbersToReserve
            };
            var response = client.CreateOrUpdateReservation(request);
            var reservation = response.Value;

            #endregion Snippet:CreateReservation

            Assert.IsTrue(phoneNumbersToReserve.All(n => reservation.PhoneNumbers.ContainsKey(n.Id)));
            Assert.AreNotEqual(PhoneNumberAvailabilityStatus.Error, reservation.PhoneNumbers[phoneNumbersToReserve.First().Id]);
            Assert.AreNotEqual(PhoneNumberAvailabilityStatus.Error, reservation.PhoneNumbers[phoneNumbersToReserve.Last().Id]);

            var phoneNumbersWithError = reservation
                .PhoneNumbers
                .Values
                .Where(n => n.Status == PhoneNumberAvailabilityStatus.Error);

            if (phoneNumbersWithError.Any())
            {
                // Handle the error for the phone numbers that failed to reserve.
                foreach (var phoneNumber in phoneNumbersWithError)
                {
                    Console.WriteLine($"Failed to reserve phone number {phoneNumber.Id}. Error Code: {phoneNumber.Error?.Code} - Message: {phoneNumber.Error?.Message}");
                }
            }

            #region Snippet:StartPurchaseReservation
            var purchaseReservationOperation = client.StartPurchaseReservation(reservationId);
            //@@purchaseReservationOperation.WaitForCompletionResponse();

            #endregion Snippet:StartPurchaseReservation

            while (!purchaseReservationOperation.HasCompleted)
            {
                SleepIfNotInPlaybackMode();
                purchaseReservationOperation.UpdateStatus();
            }

            #region Snippet:ValidateReservationPurchase

            var purchasedReservationResponse = client.GetReservation(reservationId);
            var purchasedReservation = purchasedReservationResponse.Value;

            var failedPhoneNumbers = purchasedReservation.PhoneNumbers.Values
                .Where(n => n.Status == PhoneNumberAvailabilityStatus.Error);

            if (failedPhoneNumbers.Any())
            {
                // Handle the error for the phone numbers that failed to reserve.
                foreach (var phoneNumber in failedPhoneNumbers)
                {
                    Console.WriteLine($"Failed to purchase phone number {phoneNumber.Id}. Error Code: {phoneNumber.Error?.Code} - Message: {phoneNumber.Error?.Message}");
                }
            }

            #endregion Snippet:ValidateReservationPurchase

            Assert.IsTrue(purchasedReservation.PhoneNumbers.All(n => n.Value.Status == PhoneNumberAvailabilityStatus.Purchased));

            // Release the number to prevent additional costs.
            foreach (var phoneNumberToReserve in phoneNumbersToReserve)
            {
                var releaseOperation = client.StartReleasePhoneNumber(phoneNumberToReserve.Id);
                while (!releaseOperation.HasCompleted)
                {
                    SleepIfNotInPlaybackMode();
                    releaseOperation.UpdateStatus();
                }
            }
        }

        // Gets either the static reservation ID for playback or a new reservation ID for live tests.
        protected Guid GetReservationId()
        {
            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                return _staticReservationId;
            return _reservationId;
        }
    }
}
